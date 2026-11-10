using BunBun.Properties;
using Microsoft.Win32;

namespace BunBun;

public class BunBunContext : ApplicationContext
{
    private BunBunSettings _settings;
    private const string RegistryKeyName = "BunBun";
    private readonly NotifyIcon _notifyIcon;
    private readonly System.Windows.Forms.Timer _timer;
    private ToolStripMenuItem? _startupMenuItem;
    private ToolStripMenuItem? _activeMenuItem;
    private DateTime? _lastStompTime;
    private bool _active = true;
    private bool _stomping;

    public BunBunContext()
    {
        _settings = SettingsManager.Load();

        var menu = new ContextMenuStrip();

        menu.Items.Add(
            "Stomp Now!",
            null,
            async (_, _) => await StompAsync());

        menu.Items.Add(new ToolStripSeparator());

        _activeMenuItem = new ToolStripMenuItem("Active")
        {
            Checked = _active
        };

        _activeMenuItem.Click += (_, _) =>
        {
            _active = !_active;

            _activeMenuItem.Checked = _active;

            if (_active)
            {
                SetHappyState();
            }
            else
            {
                SetPausedState();
            }
        };

        menu.Items.Add(_activeMenuItem);

        menu.Items.Add(new ToolStripSeparator());

        _startupMenuItem = new ToolStripMenuItem("Run At Startup")
        {
            Checked = IsStartupEnabled()
        };

        _startupMenuItem.Click += (_, _) =>
        {
            ToggleStartup();
        };

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

        _notifyIcon = new NotifyIcon
        {
            Icon = Resources.Happy,
            Visible = true,
            Text = "BunBun is watching."
        };

        _notifyIcon.ContextMenuStrip = menu;

        _notifyIcon.DoubleClick += (_, _) =>
        {
            var lastStomp =
                _lastStompTime?.ToString("t") ?? "Never";

            _notifyIcon.ShowBalloonTip(
                3000,
                "BunBun",
                _active
                    ? $"Idle state not found. Get it? 🐰😜\nLast stomp: {lastStomp}"
                    : "BunBun is currently paused.",
                ToolTipIcon.None);
        };

        _timer = new System.Windows.Forms.Timer();

        _timer.Tick += async (_, _) =>
        {
            if (_active)
            {
                await StompAsync();
            }
        };

        ApplySettings();
        
        _timer.Start();
    }

    private void ShowSettings()
    {
        using var dlg = new SettingsForm(_settings);

        if (dlg.ShowDialog() == DialogResult.OK)
        {
            _settings = dlg.Settings;

            SettingsManager.Save(_settings);

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

        if (_active)
        {
            SetHappyState();
        }
        else
        {
            SetPausedState();
        }
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

            if (_active)
            {
                SetHappyState();
            }
            else
            {
                SetPausedState();
            }
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

    private void Exit()
    {
        _timer.Stop();
        _timer.Dispose();

        _notifyIcon.Visible = false;
        _notifyIcon.Dispose();

        ExitThread();
    }
}
