using BunBun.Properties;
using Microsoft.Win32;

namespace BunBun;

public class BunBunContext : ApplicationContext
{
	private const string RegistryKeyName = "BunBun";

	private readonly NotifyIcon _notifyIcon;
	private readonly System.Windows.Forms.Timer _timer;

	private ToolStripMenuItem? _startupMenuItem;
	private ToolStripMenuItem? _activeMenuItem;

	private bool _paused;
	private bool _stomping;

	private DateTime _lastStompTime = DateTime.Now;

	public BunBunContext()
	{
		var menu = new ContextMenuStrip();

		menu.Items.Add(
				"Stomp Now!",
				null,
				async (_, _) => await PulseAsync());

		menu.Items.Add(new ToolStripSeparator());

		_activeMenuItem = new ToolStripMenuItem("Active")
		{
			Checked = true
		};

		_activeMenuItem.Click += (_, _) =>
		{
			_paused = _activeMenuItem.Checked;

			_activeMenuItem.Checked = !_paused;

			if (_paused)
			{
				SetPausedState();
			}
			else
			{
				SetHappyState();
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
			_notifyIcon.ShowBalloonTip(
					3000,
					"BunBun",
					_paused
							? "BunBun is currently paused."
							: $"Idle state not found. 🐰😜\nLast stomp: {_lastStompTime:t}",
					ToolTipIcon.None);
		};

		_timer = new System.Windows.Forms.Timer
		{
			Interval = (int)TimeSpan.FromMinutes(4).TotalMilliseconds
		};

		_timer.Tick += async (_, _) =>
		{
			if (!_paused)
			{
				await PulseAsync();
			}
		};

		_timer.Start();

		SetHappyState();
	}

	private async Task PulseAsync()
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

			_lastStompTime = DateTime.Now;

			await Task.Delay(500);

			SetHappyState();
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
