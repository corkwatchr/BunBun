namespace BunBun
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
			btnOk = new Button();
			btnCancel = new Button();
			nudStopIntervalMinutes = new NumericUpDown();
			label1 = new Label();
			chkEnableAutoActivation = new CheckBox();
			dtpMorningStart = new DateTimePicker();
			dtpMorningEnd = new DateTimePicker();
			label2 = new Label();
			label3 = new Label();
			dtpEveningStart = new DateTimePicker();
			dtpEveningEnd = new DateTimePicker();
			chkEnableAutoDeactivation = new CheckBox();
			((System.ComponentModel.ISupportInitialize)nudStopIntervalMinutes).BeginInit();
			SuspendLayout();
			// 
			// btnOk
			// 
			btnOk.DialogResult = DialogResult.OK;
			btnOk.Location = new Point(250, 306);
			btnOk.Margin = new Padding(2, 2, 2, 2);
			btnOk.Name = "btnOk";
			btnOk.Size = new Size(115, 36);
			btnOk.TabIndex = 0;
			btnOk.Text = "OK";
			btnOk.UseVisualStyleBackColor = true;
			btnOk.Click += btnOK_Click;
			// 
			// btnCancel
			// 
			btnCancel.DialogResult = DialogResult.Cancel;
			btnCancel.Location = new Point(392, 306);
			btnCancel.Margin = new Padding(2, 2, 2, 2);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(115, 36);
			btnCancel.TabIndex = 1;
			btnCancel.Text = "Cancel";
			btnCancel.UseVisualStyleBackColor = true;
			// 
			// nudStopIntervalMinutes
			// 
			nudStopIntervalMinutes.Location = new Point(47, 75);
			nudStopIntervalMinutes.Margin = new Padding(2, 2, 2, 2);
			nudStopIntervalMinutes.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			nudStopIntervalMinutes.Name = "nudStopIntervalMinutes";
			nudStopIntervalMinutes.Size = new Size(77, 31);
			nudStopIntervalMinutes.TabIndex = 4;
			nudStopIntervalMinutes.Value = new decimal(new int[] { 4, 0, 0, 0 });
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(136, 80);
			label1.Margin = new Padding(2, 0, 2, 0);
			label1.Name = "label1";
			label1.Size = new Size(283, 25);
			label1.TabIndex = 5;
			label1.Text = "Stomp Interval Minutes (Default 4)";
			// 
			// chkEnableAutoActivation
			// 
			chkEnableAutoActivation.AutoSize = true;
			chkEnableAutoActivation.Location = new Point(47, 125);
			chkEnableAutoActivation.Margin = new Padding(2, 2, 2, 2);
			chkEnableAutoActivation.Name = "chkEnableAutoActivation";
			chkEnableAutoActivation.Size = new Size(293, 29);
			chkEnableAutoActivation.TabIndex = 6;
			chkEnableAutoActivation.Text = "Enable Auto Activation Between:";
			chkEnableAutoActivation.UseVisualStyleBackColor = true;
			// 
			// dtpMorningStart
			// 
			dtpMorningStart.CustomFormat = "h:mm tt";
			dtpMorningStart.Format = DateTimePickerFormat.Custom;
			dtpMorningStart.Location = new Point(47, 158);
			dtpMorningStart.Margin = new Padding(2, 2, 2, 2);
			dtpMorningStart.Name = "dtpMorningStart";
			dtpMorningStart.ShowUpDown = true;
			dtpMorningStart.Size = new Size(155, 31);
			dtpMorningStart.TabIndex = 7;
			dtpMorningStart.Value = new DateTime(2026, 11, 9, 7, 30, 0, 0);
			// 
			// dtpMorningEnd
			// 
			dtpMorningEnd.CustomFormat = "h:mm tt";
			dtpMorningEnd.Format = DateTimePickerFormat.Custom;
			dtpMorningEnd.Location = new Point(258, 158);
			dtpMorningEnd.Margin = new Padding(2, 2, 2, 2);
			dtpMorningEnd.Name = "dtpMorningEnd";
			dtpMorningEnd.ShowUpDown = true;
			dtpMorningEnd.Size = new Size(155, 31);
			dtpMorningEnd.TabIndex = 10;
			dtpMorningEnd.Value = new DateTime(2026, 11, 9, 8, 0, 0, 0);
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(218, 163);
			label2.Margin = new Padding(2, 0, 2, 0);
			label2.Name = "label2";
			label2.Size = new Size(29, 25);
			label2.TabIndex = 11;
			label2.Text = "to";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(218, 248);
			label3.Margin = new Padding(2, 0, 2, 0);
			label3.Name = "label3";
			label3.Size = new Size(29, 25);
			label3.TabIndex = 14;
			label3.Text = "to";
			// 
			// dtpEveningStart
			// 
			dtpEveningStart.CustomFormat = "h:mm tt";
			dtpEveningStart.Format = DateTimePickerFormat.Custom;
			dtpEveningStart.Location = new Point(47, 243);
			dtpEveningStart.Margin = new Padding(2, 2, 2, 2);
			dtpEveningStart.Name = "dtpEveningStart";
			dtpEveningStart.ShowUpDown = true;
			dtpEveningStart.Size = new Size(155, 31);
			dtpEveningStart.TabIndex = 12;
			dtpEveningStart.Value = new DateTime(2026, 11, 9, 16, 30, 0, 0);
			// 
			// dtpEveningEnd
			// 
			dtpEveningEnd.CustomFormat = "h:mm tt";
			dtpEveningEnd.Format = DateTimePickerFormat.Custom;
			dtpEveningEnd.Location = new Point(258, 243);
			dtpEveningEnd.Margin = new Padding(2, 2, 2, 2);
			dtpEveningEnd.Name = "dtpEveningEnd";
			dtpEveningEnd.ShowUpDown = true;
			dtpEveningEnd.Size = new Size(155, 31);
			dtpEveningEnd.TabIndex = 13;
			dtpEveningEnd.Value = new DateTime(2026, 11, 9, 17, 0, 0, 0);
			// 
			// chkEnableAutoDeactivation
			// 
			chkEnableAutoDeactivation.AutoSize = true;
			chkEnableAutoDeactivation.Location = new Point(47, 210);
			chkEnableAutoDeactivation.Margin = new Padding(2, 2, 2, 2);
			chkEnableAutoDeactivation.Name = "chkEnableAutoDeactivation";
			chkEnableAutoDeactivation.Size = new Size(312, 29);
			chkEnableAutoDeactivation.TabIndex = 15;
			chkEnableAutoDeactivation.Text = "Enable Auto Deactivation Between:";
			chkEnableAutoDeactivation.UseVisualStyleBackColor = true;
			// 
			// SettingsForm
			// 
			AcceptButton = btnOk;
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = btnCancel;
			ClientSize = new Size(615, 352);
			Controls.Add(chkEnableAutoDeactivation);
			Controls.Add(label3);
			Controls.Add(dtpEveningEnd);
			Controls.Add(dtpEveningStart);
			Controls.Add(label2);
			Controls.Add(dtpMorningEnd);
			Controls.Add(chkEnableAutoActivation);
			Controls.Add(dtpMorningStart);
			Controls.Add(label1);
			Controls.Add(nudStopIntervalMinutes);
			Controls.Add(btnCancel);
			Controls.Add(btnOk);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(2, 2, 2, 2);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "SettingsForm";
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = " BunBun Settings";
			((System.ComponentModel.ISupportInitialize)nudStopIntervalMinutes).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btnOk;
        private Button btnCancel;
        private NumericUpDown nudStopIntervalMinutes;
        private Label label1;
        private CheckBox chkEnableAutoActivation;
        private DateTimePicker dtpMorningStart;
        private DateTimePicker dtpMorningEnd;        
        private CheckBox chkEnableAutoDeactivation;
        private DateTimePicker dtpEveningStart;
        private DateTimePicker dtpEveningEnd;
        private Label label2;
        private Label label3;
    }
}