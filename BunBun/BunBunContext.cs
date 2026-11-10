using BunBun.Properties;
using Microsoft.Win32;

namespace BunBun;

public class BunBunContext : ApplicationContext
{
    // ****************************************************************************************
    //  FIELDS
    //  Settings, the tray icon, the two timers, the daily schedule,
    //  and the current state (active/paused, last stomp time, stomp in progress).
    // ****************************************************************************************

    private BunBunSettings _settings;
    private const string RegistryKeyName = "BunBun";
    private readonly NotifyIcon _notifyIcon;
    private readonly System.Windows.Forms.Timer _timer;
    private readonly System.Windows.Forms.Timer _scheduleTimer;
    private readonly ActivitySchedule _schedule;
    private ToolStripMenuItem? _startupMenuItem;
    private ToolStripMenuItem? _activeMenuItem;
    private DateTime? _lastStompTime;
    private bool _active = true;
    private bool _stomping;

    // ****************************************************************************************
    //  CONSTRUCTOR
    //  Loads the saved settings, builds the tray icon and timers,
    //  applies the settings, and starts everything running.
    // ****************************************************************************************

    public BunBunContext()
    {
        _settings = SettingsManager.Load();

        _notifyIcon = CreateNotifyIcon(BuildContextMenu());

        _timer = CreateStompTimer();

        _schedule = new ActivitySchedule(_settings, DateTime.Now);

        _scheduleTimer = CreateScheduleTimer();

        ApplySettings();

        _timer.Start();

        _scheduleTimer.Start();

        CheckSchedule();
    }

    // ****************************************************************************************
    //  TRAY ICON & MENU SETUP
    //  Builds the notification-area icon and its right-click menu, and wires
    //  each menu item and the double-click to the method that handles it.
    // ****************************************************************************************

    private ContextMenuStrip BuildContextMenu()
    {
        var menu = new ContextMenuStrip();

        menu.Items.Add(
            "Stomp Now!",
            null,
            async (_, _) => await StompAsync());

        menu.Items.Add(new ToolStripSeparator());

        _activeMenuItem = CreateActiveMenuItem();
        menu.Items.Add(_activeMenuItem);

        menu.Items.Add(new ToolStripSeparator());

        _startupMenuItem = CreateStartupMenuItem();
        menu.Items.Add(_startupMenuItem);

        menu.Items.Add(new ToolStripSeparator());

        menu.Items.Add(
            "Settings...",
            null,
            (_, _) => ShowSettings());

        menu.Items.Add(
            "About...",
            null,
            (_, _) => ShowAbout());

        menu.Items.Add(new ToolStripSeparator());

        menu.Items.Add(
            "Exit",
            null,
            (_, _) => Exit());

        return menu;
    }

    private ToolStripMenuItem CreateActiveMenuItem()
    {
        var item = new ToolStripMenuItem("Active")
        {
            Checked = _active
        };

        item.Click += (_, _) => ToggleActive();

        return item;
    }

    private ToolStripMenuItem CreateStartupMenuItem()
    {
        var item = new ToolStripMenuItem("Run At Startup")
        {
            Checked = IsStartupEnabled()
        };

        item.Click += (_, _) => ToggleStartup();

        return item;
    }

    private NotifyIcon CreateNotifyIcon(ContextMenuStrip menu)
    {
        var icon = new NotifyIcon
        {
            Icon = Resources.Happy,
            Visible = true,
            Text = "BunBun is watching.",
            ContextMenuStrip = menu
        };

        icon.DoubleClick += (_, _) => ShowStatusBalloon();

        return icon;
    }

    // ****************************************************************************************
    //  TIMERS
    //  The stomp timer fires every few minutes (from Settings) and stomps
    //  while BunBun is active. The schedule timer checks every 30 seconds
    //  whether it is time for the automatic morning start or evening pause.
    // ****************************************************************************************

    private System.Windows.Forms.Timer CreateStompTimer()
    {
        var timer = new System.Windows.Forms.Timer();

        timer.Tick += async (_, _) => await OnTimerTickAsync();

        return timer;
    }

    private System.Windows.Forms.Timer CreateScheduleTimer()
    {
        var timer = new System.Windows.Forms.Timer
        {
            // Checking often keeps the change close to its random time and
            // catches up quickly after the PC wakes from sleep.
            Interval = (int)TimeSpan.FromSeconds(30).TotalMilliseconds
        };

        timer.Tick += (_, _) => CheckSchedule();

        return timer;
    }

    private async Task OnTimerTickAsync()
    {
        if (_active)
        {
            await StompAsync();
        }
    }

    // ****************************************************************************************
    //  ACTIVE / PAUSED STATE & DAILY SCHEDULE
    //  Switches BunBun between active and paused, either by hand from the menu
    //  or automatically at the random morning and evening times.
    // ****************************************************************************************

    private void ToggleActive()
    {
        SetActive(!_active);
    }

    private void SetActive(bool active)
    {
        _active = active;

        _activeMenuItem!.Checked = _active;

        UpdateIconState();
    }

    private void CheckSchedule()
    {
        switch (_schedule.GetDueChange(_settings, DateTime.Now))
        {
            case ScheduledChange.Activate when !_active:
                SetActive(true);
                ShowBalloon("Good morning! BunBun is back on duty. 🐰🌞");
                break;

            case ScheduledChange.Deactivate when _active:
                SetActive(false);
                ShowBalloon("BunBun is done for the day. Good night! 🐰💤");
                break;
        }
    }

    // ****************************************************************************************
    //  STOMPING
    //  The heart of BunBun: plays the warning/stomp icon animation,
    //  presses the invisible F15 key so Windows (and Teams) see activity,
    //  and records the stomp in the saved settings.
    // ****************************************************************************************

    private async Task StompAsync()
    {
        if (_stomping)
            return;

        try
        {
            _stomping = true;

            SetWarningState();

            await Task.Delay(500);

            SetStompState();

            SendF15();

            _settings.RecordStomp();

            SettingsManager.Save(_settings);

            _lastStompTime = DateTime.Now;

            await Task.Delay(500);

            UpdateIconState();
        }
        finally
        {
            _stomping = false;
        }
    }

    private static void SendF15()
    {
        // Try to find F15 on your keyboard.
        // It's not there.
        // But it's a key that exists and is unused in most apps.
        SendKeys.SendWait("{F15}");
    }

    // ****************************************************************************************
    //  TRAY ICON APPEARANCE
    //  Sets the bunny picture and hover text for each state:
    //  happy (active), paused, warning (about to stomp), and stomp.
    // ****************************************************************************************

    private void UpdateIconState()
    {
        if (_active)
        {
            SetHappyState();
        }
        else
        {
            SetPausedState();
        }
    }

    private void SetHappyState()
    {
        _notifyIcon.Icon = Resources.Happy;

        _notifyIcon.Text =
                $"BunBun Active {_lastStompTime:t}";
    }

    private void SetWarningState()
    {
        _notifyIcon.Icon = Resources.Warning;

        _notifyIcon.Text =
                "Preparing stomp...";
    }

    private void SetStompState()
    {
        _notifyIcon.Icon = Resources.Stomp;

        _notifyIcon.Text =
                "STOMP!";
    }

    private void SetPausedState()
    {
        _notifyIcon.Icon = Resources.Warning;

        _notifyIcon.Text =
                "BunBun Paused";
    }

    // ****************************************************************************************
    //  MESSAGES TO THE USER
    //  Pop-up balloons from the tray icon (status, schedule changes) and the About box.
    // ****************************************************************************************

    private void ShowStatusBalloon()
    {
        var lastStomp =
            _lastStompTime?.ToString("t") ?? "Never";

        var message = _active
            ? $"Idle state not found. Get it? 🐰😜\nLast stomp: {lastStomp}"
            : "BunBun is currently paused.";

        if (_schedule.NextActivation is { } wake)
            message += $"\nAuto-start: {wake:t}";

        if (_schedule.NextDeactivation is { } sleep)
            message += $"\nAuto-pause: {sleep:t}";

        ShowBalloon(message);
    }

    private void ShowBalloon(string message)
    {
        _notifyIcon.ShowBalloonTip(
            3000,
            "BunBun",
            message,
            ToolTipIcon.None);
    }

    private void ShowAbout()
    {
        var version =
            typeof(BunBunContext)
                .Assembly
                .GetName()
                .Version;

        MessageBox.Show(
            $"BunBun v{version}\r\n\r\n" +
            "A highly sophisticated bunny-powered idle prevention system.\r\n\r\n" +
            $"Stomp Interval: {_settings.StompIntervalMinutes} minute(s)\r\n" +
            $"Stomp Count: {_settings.StompCount:N0}\r\n" +
            $"Last Stomp: {_lastStompTime?.ToString("t") ?? "Never"}" + "\r\n\r\n" +
            "🐰",
            "About BunBun...",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    // ****************************************************************************************
    //  SETTINGS
    //  Opens the Settings dialog, saves the user's changes, and applies them
    //  to the stomp timer, the daily schedule, and the tray icon.
    // ****************************************************************************************

    private void ShowSettings()
    {
        using var dlg = new SettingsForm(_settings);

        if (dlg.ShowDialog() == DialogResult.OK)
        {
            _settings = dlg.Settings;

            SettingsManager.Save(_settings);

            _schedule.Reschedule(_settings, DateTime.Now);

            ApplySettings();
        }
    }

    private void ApplySettings()
    {
        _activeMenuItem!.Checked = _active;

        _timer.Interval =
            (int)TimeSpan
                .FromMinutes(_settings.StompIntervalMinutes)
                .TotalMilliseconds;

        UpdateIconState();
    }

    // ****************************************************************************************
    //  RUN AT WINDOWS STARTUP
    //  Reads and toggles the registry "Run" entry that launches BunBun when
    //  the user signs in to Windows.
    // ****************************************************************************************

    private bool IsStartupEnabled()
    {
        using var key = Registry.CurrentUser.OpenSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Run");

        return key?.GetValue(RegistryKeyName) != null;
    }

    private void ToggleStartup()
    {
        using var key = Registry.CurrentUser.OpenSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Run",
                writable: true);

        if (key == null)
            return;

        if (IsStartupEnabled())
        {
            key.DeleteValue(RegistryKeyName, false);

            if (_startupMenuItem != null)
                _startupMenuItem.Checked = false;
        }
        else
        {
            var exePath = Application.ExecutablePath;

            key.SetValue(
                    RegistryKeyName,
                    $"\"{exePath}\"");

            if (_startupMenuItem != null)
                _startupMenuItem.Checked = true;
        }
    }

    // ****************************************************************************************
    //  SHUTDOWN
    //  Stops the timers, removes the tray icon, and closes the app.
    // ****************************************************************************************

    private void Exit()
    {
        _timer.Stop();
        _timer.Dispose();

        _scheduleTimer.Stop();
        _scheduleTimer.Dispose();

        _notifyIcon.Visible = false;
        _notifyIcon.Dispose();

        ExitThread();
    }
}
