namespace BunBun
{
    public partial class SettingsForm : Form
    {
        public BunBunSettings Settings { get; private set; }

        public SettingsForm(BunBunSettings settings)
        {
            InitializeComponent();

            Settings = settings;

            LoadSettings();
            UpdateOptionalControlStates();
        }

        private void LoadSettings()
        {
            nudStopIntervalMinutes.Value = Math.Clamp(
                Settings.StompIntervalMinutes,
                nudStopIntervalMinutes.Minimum,
                nudStopIntervalMinutes.Maximum);

            chkEnableAutoActivation.Checked =
                Settings.EnableMorningActivation;

            dtpMorningStart.Value =
                ToPickerValue(Settings.MorningStart);

            dtpMorningEnd.Value =
                ToPickerValue(Settings.MorningEnd);

            chkEnableAutoDeactivation.Checked =
                Settings.EnableEveningDeactivation;

            dtpEveningStart.Value =
                ToPickerValue(Settings.EveningStart);

            dtpEveningEnd.Value =
                ToPickerValue(Settings.EveningEnd);

            chkInactiveDeactivation.Checked =
                Settings.EnableInactivityDeactivation;

            nudInactivityMinutes.Value = Math.Clamp(
                Settings.InactivityMinutes,
                nudInactivityMinutes.Minimum,
                nudInactivityMinutes.Maximum);
        }

        private void UpdateOptionalControlStates()
        {
            bool autoActivationEnabled =
                chkEnableAutoActivation.Checked;

            dtpMorningStart.Enabled = autoActivationEnabled;
            dtpMorningEnd.Enabled = autoActivationEnabled;

            bool autoDeactivationEnabled =
                chkEnableAutoDeactivation.Checked;

            dtpEveningStart.Enabled = autoDeactivationEnabled;
            dtpEveningEnd.Enabled = autoDeactivationEnabled;

            nudInactivityMinutes.Enabled =
                chkInactiveDeactivation.Checked;
        }

        /// <summary>
        /// When both automatic activation and deactivation are enabled,
        /// their time windows must not overlap; otherwise BunBun could be
        /// told to wake up after it has already gone to bed.
        /// Windows that only touch (one ends exactly when the other starts) are allowed.
        /// </summary>
        private bool ValidateTimeWindows()
        {
            if (!chkEnableAutoActivation.Checked ||
                !chkEnableAutoDeactivation.Checked)
            {
                return true;
            }

            var (morningStart, morningEnd) = GetWindow(dtpMorningStart, dtpMorningEnd);
            var (eveningStart, eveningEnd) = GetWindow(dtpEveningStart, dtpEveningEnd);

            bool overlaps =
                morningStart < eveningEnd &&
                eveningStart < morningEnd;

            if (!overlaps)
                return true;

            MessageBox.Show(
                this,
                $"The activation window ({morningStart:t} – {morningEnd:t}) overlaps " +
                $"the deactivation window ({eveningStart:t} – {eveningEnd:t}).\r\n\r\n" +
                "Please adjust the times so they don't overlap. 🐰",
                "BunBun Settings",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            dtpMorningStart.Focus();

            return false;
        }

        // Returns the window in start-to-end order, the same way
        // ActivitySchedule treats a window entered backwards.
        private static (TimeOnly Start, TimeOnly End) GetWindow(
            DateTimePicker startPicker,
            DateTimePicker endPicker)
        {
            var start = TimeOnly.FromDateTime(startPicker.Value);
            var end = TimeOnly.FromDateTime(endPicker.Value);

            return end < start ? (end, start) : (start, end);
        }

        // The time pickers hold a full DateTime;
        // only the time part is shown and used.
        private static DateTime ToPickerValue(TimeOnly time) =>
            DateTime.Today.Add(time.ToTimeSpan());

        private void btnOK_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidateTimeWindows())
            {
                // Keep the dialog open so the user can fix the times.
                DialogResult = DialogResult.None;
                return;
            }

            Settings = new BunBunSettings
            {
                StompCount = Settings.StompCount,

                StompIntervalMinutes =
                    (int)nudStopIntervalMinutes.Value,

                EnableMorningActivation =
                    chkEnableAutoActivation.Checked,

                MorningStart =
                    TimeOnly.FromDateTime(dtpMorningStart.Value),

                MorningEnd =
                    TimeOnly.FromDateTime(dtpMorningEnd.Value),

                EnableEveningDeactivation =
                    chkEnableAutoDeactivation.Checked,

                EveningStart =
                    TimeOnly.FromDateTime(dtpEveningStart.Value),

                EveningEnd =
                    TimeOnly.FromDateTime(dtpEveningEnd.Value),

                EnableInactivityDeactivation =
                    chkInactiveDeactivation.Checked,

                InactivityMinutes =
                    (int)nudInactivityMinutes.Value
            };
        }

        private void chkEnableAutoActivation_CheckedChanged(
            object sender,
            EventArgs e)
        {
            bool enabled = chkEnableAutoActivation.Checked;

            dtpMorningStart.Enabled = enabled;
            dtpMorningEnd.Enabled = enabled;
        }

        private void chkEnableAutoDeactivation_CheckedChanged(
            object sender,
            EventArgs e)
        {
            bool enabled = chkEnableAutoDeactivation.Checked;

            dtpEveningStart.Enabled = enabled;
            dtpEveningEnd.Enabled = enabled;
        }

        private void chkInactiveDeactivation_CheckedChanged(
            object sender,
            EventArgs e)
        {
            nudInactivityMinutes.Enabled =
                chkInactiveDeactivation.Checked;
        }
    }
}