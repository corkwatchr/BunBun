namespace BunBun;

public enum ScheduledChange
{
    None,
    Activate,
    Deactivate
}

/// <summary>
/// Decides when BunBun should automatically wake up in the morning and go to
/// sleep in the evening. Each day a random time is picked inside each
/// configured window, and each change happens at most once per day.
/// </summary>
public sealed class ActivitySchedule
{
    private readonly Random _random = new();

    private DateOnly _day;
    private ScheduledEvent _morning = ScheduledEvent.Done;
    private ScheduledEvent _evening = ScheduledEvent.Done;

    public ActivitySchedule(BunBunSettings settings, DateTime now)
    {
        StartNewDay(settings, now);
    }

    public TimeOnly? NextActivation => _morning.Pending ? _morning.At : null;

    public TimeOnly? NextDeactivation => _evening.Pending ? _evening.At : null;

    /// <summary>
    /// Call after the user changes settings. Changes that have not happened
    /// yet today get a new random time, chosen from what is left of the
    /// window, so saving the settings never triggers an immediate change.
    /// </summary>
    public void Reschedule(BunBunSettings settings, DateTime now)
    {
        var time = TimeOnly.FromDateTime(now);

        if (_morning.Pending || !settings.EnableMorningActivation)
        {
            _morning = PickRemaining(
                settings.EnableMorningActivation,
                settings.MorningStart,
                settings.MorningEnd,
                time);
        }

        if (_evening.Pending || !settings.EnableEveningDeactivation)
        {
            _evening = PickRemaining(
                settings.EnableEveningDeactivation,
                settings.EveningStart,
                settings.EveningEnd,
                time);
        }
    }

    /// <summary>
    /// Returns the change that is due now, if any. A change whose time has
    /// already passed is caught up (for example after the PC wakes from
    /// sleep). If both are due, the later one (deactivation) wins.
    /// </summary>
    public ScheduledChange GetDueChange(BunBunSettings settings, DateTime now)
    {
        if (DateOnly.FromDateTime(now) != _day)
        {
            StartNewDay(settings, now);
        }

        var time = TimeOnly.FromDateTime(now);
        var result = ScheduledChange.None;

        if (_morning.IsDue(time))
        {
            _morning = ScheduledEvent.Done;
            result = ScheduledChange.Activate;
        }

        if (_evening.IsDue(time))
        {
            _evening = ScheduledEvent.Done;
            result = ScheduledChange.Deactivate;
        }

        return result;
    }

    private void StartNewDay(BunBunSettings settings, DateTime now)
    {
        _day = DateOnly.FromDateTime(now);

        _morning = Pick(
            settings.EnableMorningActivation,
            settings.MorningStart,
            settings.MorningEnd);

        _evening = Pick(
            settings.EnableEveningDeactivation,
            settings.EveningStart,
            settings.EveningEnd);
    }

    private ScheduledEvent Pick(bool enabled, TimeOnly start, TimeOnly end)
    {
        if (!enabled)
            return ScheduledEvent.Done;

        if (end < start)
            (start, end) = (end, start);

        return ScheduledEvent.Scheduled(RandomBetween(start, end));
    }

    private ScheduledEvent PickRemaining(
        bool enabled,
        TimeOnly start,
        TimeOnly end,
        TimeOnly now)
    {
        if (!enabled)
            return ScheduledEvent.Done;

        if (end < start)
            (start, end) = (end, start);

        if (now > end)
            return ScheduledEvent.Done;

        return ScheduledEvent.Scheduled(RandomBetween(now > start ? now : start, end));
    }

    private TimeOnly RandomBetween(TimeOnly start, TimeOnly end)
    {
        var span = end.ToTimeSpan() - start.ToTimeSpan();

        var offset = TimeSpan.FromSeconds(
            _random.NextDouble() * span.TotalSeconds);

        return start.Add(offset);
    }

    private readonly record struct ScheduledEvent(bool Pending, TimeOnly At)
    {
        public static ScheduledEvent Done => new(false, default);

        public static ScheduledEvent Scheduled(TimeOnly at) => new(true, at);

        public bool IsDue(TimeOnly now) => Pending && now >= At;
    }
}
