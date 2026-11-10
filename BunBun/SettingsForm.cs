using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
        }

        private void LoadSettings()
        {
            nudStopIntervalMinutes.Value = Math.Clamp(
                Settings.StompIntervalMinutes,
                nudStopIntervalMinutes.Minimum,
                nudStopIntervalMinutes.Maximum);

            chkEnableAutoActivation.Checked = Settings.EnableMorningActivation;
            dtpMorningStart.Value = ToPickerValue(Settings.MorningStart);
            dtpMorningEnd.Value = ToPickerValue(Settings.MorningEnd);

            chkEnableAutoDeactivation.Checked = Settings.EnableEveningDeactivation;
            dtpEveningStart.Value = ToPickerValue(Settings.EveningStart);
            dtpEveningEnd.Value = ToPickerValue(Settings.EveningEnd);
        }

        // The time pickers hold a full DateTime; only the time part is shown and used.
        private static DateTime ToPickerValue(TimeOnly time) =>
            DateTime.Today.Add(time.ToTimeSpan());

        private void btnOK_Click(
            object sender,
            EventArgs e)
        {
            Settings = new BunBunSettings
            {
                StompCount = Settings.StompCount,
                StompIntervalMinutes = (int)nudStopIntervalMinutes.Value,
                EnableMorningActivation = chkEnableAutoActivation.Checked,
                MorningStart = TimeOnly.FromDateTime(dtpMorningStart.Value),
                MorningEnd = TimeOnly.FromDateTime(dtpMorningEnd.Value),
                EnableEveningDeactivation = chkEnableAutoDeactivation.Checked,
                EveningStart = TimeOnly.FromDateTime(dtpEveningStart.Value),
                EveningEnd = TimeOnly.FromDateTime(dtpEveningEnd.Value)
            };
        }

    }
}
