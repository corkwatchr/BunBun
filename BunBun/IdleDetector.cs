using System.Runtime.InteropServices;

namespace BunBun;

/// <summary>
/// Tracks how long it has been since the user really touched the keyboard or mouse.
///
/// Windows' idle clock (GetLastInputInfo) is reset by *any* input, including the
/// F15 that BunBun injects - that is exactly how the stomp keeps Teams happy. So
/// the raw idle clock would never get past one stomp interval. Instead, this class
/// watches for changes in Windows' "last input" time and ignores the change that
/// BunBun's own stomp causes. Any other change counts as real user activity.
///
/// Usage: call <see cref="BeginSyntheticInput"/> right before sending the F15 and
/// <see cref="EndSyntheticInput"/> right after it.
/// </summary>
public sealed class IdleDetector
{
    // Allowance for Windows to record the injected key after SendKeys returns.
    private const uint SyntheticGraceMilliseconds = 1000;

    // All ticks are GetTickCount-style milliseconds (they wrap every ~49.7 days,
    // so they are always compared with unchecked unsigned subtraction).
    private uint _lastSeenInputTick;
    private uint _lastUserInputTick;

    private bool _hasSyntheticWindow;
    private uint _syntheticStartTick;
    private uint _syntheticEndTick;

    public IdleDetector()
    {
        _lastSeenInputTick = GetLastInputTick();
        _lastUserInputTick = _lastSeenInputTick;
    }

    /// <summary>
    /// How long since the last real (non-BunBun) keyboard or mouse input,
    /// or since the last <see cref="Reset"/>, whichever is more recent.
    /// </summary>
    public TimeSpan GetIdleTime()
    {
        Update();

        return TimeSpan.FromMilliseconds(
            unchecked(NowTick() - _lastUserInputTick));
    }

    /// <summary>
    /// Restarts the idle clock, e.g. when BunBun is (re)activated, so that an
    /// automatic morning activation isn't immediately undone by overnight idleness.
    /// </summary>
    public void Reset()
    {
        Update();

        _lastUserInputTick = NowTick();
    }

    /// <summary>Call immediately before injecting the F15.</summary>
    public void BeginSyntheticInput()
    {
        // Record any real input that happened since the last check, so the
        // stomp can't hide it.
        Update();

        _syntheticStartTick = NowTick();
        _hasSyntheticWindow = false;
    }

    /// <summary>Call immediately after injecting the F15.</summary>
    public void EndSyntheticInput()
    {
        _syntheticEndTick = unchecked(NowTick() + SyntheticGraceMilliseconds);
        _hasSyntheticWindow = true;
    }

    private void Update()
    {
        uint tick = GetLastInputTick();

        if (tick == _lastSeenInputTick)
            return;

        _lastSeenInputTick = tick;

        if (IsSynthetic(tick))
            return;

        // Only move forward (Reset may have set a later time than this input).
        if (unchecked((int)(tick - _lastUserInputTick)) > 0)
            _lastUserInputTick = tick;
    }

    private bool IsSynthetic(uint tick) =>
        _hasSyntheticWindow &&
        unchecked(tick - _syntheticStartTick) <=
        unchecked(_syntheticEndTick - _syntheticStartTick);

    private static uint NowTick() => unchecked((uint)Environment.TickCount);

    // ****************************************************************************************
    //  WIN32
    // ****************************************************************************************

    [StructLayout(LayoutKind.Sequential)]
    private struct LASTINPUTINFO
    {
        public uint cbSize;
        public uint dwTime;
    }

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

    private uint GetLastInputTick()
    {
        var info = new LASTINPUTINFO
        {
            cbSize = (uint)Marshal.SizeOf<LASTINPUTINFO>()
        };

        // On failure, report "nothing new" rather than a false idle period.
        return GetLastInputInfo(ref info) ? info.dwTime : _lastSeenInputTick;
    }
}
