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
            // populate controls
        }

        private void btnOK_Click(
            object sender,
            EventArgs e)
        {
            Settings = new BunBunSettings
            {
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
