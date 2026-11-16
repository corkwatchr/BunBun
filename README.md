# 🐰 BunBun

> A tiny, completely unnecessary, absolutely essential Windows tray utility.

BunBun is a lightweight .NET Windows application that lives in your system tray and periodically presses the mythical **F15** key to convince Windows that you're still present.

Why F15?

Because most keyboards don't actually have one.

That makes it the perfect key for generating harmless activity without interfering with normal typing, gaming, coding, spreadsheeting, rabbit care, or any other important business.

---

## 🐇 What Does It Do?

Every four minutes (or however often you tell it to), BunBun performs a highly sophisticated operation:

1. Thinks about stomping.
2. Warns you that a stomp is coming.
3. Stomps the invisible F15 key.
4. Returns to being a happy bunny.

This tiny pulse helps prevent Windows and applications such as Teams from drifting into an idle/away state during long periods of reading, meetings, presentations, video calls, documentation work, debugging sessions, or staring thoughtfully at code.

---

## 🎨 Bunny Status Colors

BunBun communicates exclusively through tray icon mood swings.

| Color | State | Meaning |
|---------|---------|---------|
| 🟢 Green | Happy | BunBun is active and monitoring the situation. |
| 🟡 Yellow | Warning | A stomp is being prepared. Stand back. |
| 🔴 Red | STOMP! | The F15 key has been delivered with extreme bunny force. |

The transition sequence is:

```text
Happy 🟢
    ↓
Warning 🟡
    ↓
STOMP! 🔴
    ↓
Happy 🟢
```

Nature heals.

---

## 🖱 System Tray Menu

Right-click BunBun in the notification area to access its controls.

### 🦶 Stomp Now!

Immediately performs a stomp without waiting for the normal timer.

Useful if:

- Teams is getting suspicious.
- Windows seems sleepy.
- You simply enjoy pressing buttons.

### ✅ Active

Enables or pauses BunBun.

When active:

- Automatic stomps continue at the configured interval (four minutes by default).

When paused:

- No stomping occurs.
- Tray icon changes to the warning state.
- BunBun patiently waits for reactivation.

### 🚀 Run At Startup

Adds or removes BunBun from:

```text
HKCU\Software\Microsoft\Windows\CurrentVersion\Run
```

When enabled, BunBun starts automatically when you sign in to Windows.

### ⚙ Settings...

Opens the Settings dialog, where you can fine-tune the bunny. See [Settings](#-settings) below.

### ℹ About...

Shows the version, the stomp interval, the stomp count, and when the last stomp happened.

### ❌ Exit

Shuts down BunBun and sends the bunny home.

---

## 🐰 Double-Click Action

Double-clicking the tray icon displays a status balloon.

When active, BunBun proudly reports its most recent stomp time.

When paused, BunBun politely admits that it isn't doing anything.

If any automatic changes are coming up today, BunBun also tells you when it plans to clock in (**Auto-start**) or clock out (**Auto-pause**).

---

## ⚙ Settings

Choose **Settings...** from the tray menu to configure BunBun. Your choices are saved to:

```text
%AppData%\BunBun\settings.json
```

### 🦶 Stomp every: _N_ minutes

How often BunBun stomps. The default is 4 minutes, which keeps Teams' 5-minute idle timer firmly in check.

### 🌅 Activate randomly between

BunBun can clock in for you in the morning. Pick a time window, and each day BunBun picks a random moment inside it to wake up and start stomping.

Random, because a bunny that arrives at exactly 7:30:00 every single day looks suspiciously like a bunny.

### 🌙 Deactivate randomly between

The evening version. Each day BunBun picks a random moment in this window to pause and go to bed.

If the PC was asleep when the moment arrived, BunBun catches up as soon as it wakes.

### 💤 Automatically deactivate after _N_ minutes of inactivity

If there's no keyboard or mouse activity for this many minutes (60 by default), BunBun assumes you've wandered off and pauses itself. This way you don't look "Available" all afternoon while you're actually at lunch, at the dentist, or under a blanket.

But wait, doesn't BunBun's own stomping count as activity?

Not to BunBun. BunBun knows the sound of its own feet. It ignores its own F15 stomps and only counts *real* human input.

A few more things to know:

- Time the PC spends asleep counts as idle time.
- Each time BunBun is activated (by you or by the morning schedule), the inactivity clock starts over. That way, a morning wake-up isn't undone by a whole night of idleness.
- Once BunBun has paused for inactivity, it stays paused until you reactivate it.

---

## 🔧 Technical Details

- Built with **.NET 11**
- Uses **Windows Forms**
- Runs entirely from the system tray
- No visible main window
- Sends the virtual **F15** key using `SendKeys.SendWait`
- Uses a timer-based pulse (every 4 minutes by default)
- Checks the daily schedule and inactivity every 30 seconds
- Detects real user activity with `GetLastInputInfo`, ignoring BunBun's own stomps
- Saves settings and a lifetime stomp count to `%AppData%\BunBun\settings.json`
- Supports user-level startup registration

---

## 🤔 Why Does This Exist?

Because sometimes you're:

- Reading documentation
- On a phone call
- In a Signal meeting
- Watching a presentation
- Thinking deeply about architecture
- Explaining Blazor to someone
- Explaining why the build machine works only when Steve touches it
- Waiting for Claude

...and Windows decides you've apparently abandoned civilization.

BunBun respectfully disagrees.

---

## ⚠ Disclaimer

This application does not:

- Hack anything
- Inject anything
- Modify system behavior
- Summon actual rabbits

It simply taps an unused function key at intervals and attempts to maintain the illusion that you remain a productive member of society.

---

## 🐇 Official Bunny Philosophy

> "If the human is still breathing, they are probably working."
>
> — BunBun

---

Made with ☕, .NET, and an unreasonable amount of bunny energy.
