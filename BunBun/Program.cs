using BunBun;

// Only one bunny per desk. The fixed GUID keeps the name from colliding with
// any other app; "Local\" scopes it to the current Windows sign-in session.
const string MutexName = @"Local\BunBun-0965efd3-fa20-4a17-a5f9-44281f49c5ba";

// `using var` keeps the mutex alive (and owned) until the app exits.
using var mutex = new Mutex(initiallyOwned: true, MutexName, out bool createdNew);

// Initialize first so the message box below gets the same visual styles and DPI settings.
ApplicationConfiguration.Initialize();

if (!createdNew)
{
    MessageBox.Show(
        "BunBun is already running. 🐰\r\n\r\n" +
        "Look for the bunny in the notification area.\r\n" +
        "You may need to click the ^ arrow to see it.",
        "BunBun",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);

    return;
}

Application.Run(new BunBunContext());
