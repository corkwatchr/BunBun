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
            btnOk.Location = new Point(325, 392);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(150, 46);
            btnOk.TabIndex = 0;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(510, 392);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 46);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // nudStopIntervalMinutes
            // 
            nudStopIntervalMinutes.Location = new Point(61, 96);
            nudStopIntervalMinutes.Name = "nudStopIntervalMinutes";
            nudStopIntervalMinutes.Size = new Size(100, 39);
            nudStopIntervalMinutes.TabIndex = 4;
            nudStopIntervalMinutes.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(177, 103);
            label1.Name = "label1";
            label1.Size = new Size(382, 32);
            label1.TabIndex = 5;
            label1.Text = "Stomp Interval Minutes (Default 4)";
            // 
            // chkEnableAutoActivation
            // 
            chkEnableAutoActivation.AutoSize = true;
            chkEnableAutoActivation.Location = new Point(61, 160);
            chkEnableAutoActivation.Name = "chkEnableAutoActivation";
            chkEnableAutoActivation.Size = new Size(392, 36);
            chkEnableAutoActivation.TabIndex = 6;
            chkEnableAutoActivation.Text = "Enable Auto Activation Between:";
            chkEnableAutoActivation.UseVisualStyleBackColor = true;
            // 
            // dtpMorningStart
            // 
            dtpMorningStart.CustomFormat = "h:mm tt";
            dtpMorningStart.Format = DateTimePickerFormat.Custom;
            dtpMorningStart.Location = new Point(61, 202);
            dtpMorningStart.Name = "dtpMorningStart";
            dtpMorningStart.ShowUpDown = true;
            dtpMorningStart.Size = new Size(200, 39);
            dtpMorningStart.TabIndex = 7;
            dtpMorningStart.Value = new DateTime(2026, 11, 9, 7, 30, 0, 0);
            // 
            // dtpMorningEnd
            // 
            dtpMorningEnd.CustomFormat = "h:mm tt";
            dtpMorningEnd.Format = DateTimePickerFormat.Custom;
            dtpMorningEnd.Location = new Point(335, 202);
            dtpMorningEnd.Name = "dtpMorningEnd";
            dtpMorningEnd.ShowUpDown = true;
            dtpMorningEnd.Size = new Size(200, 39);
            dtpMorningEnd.TabIndex = 10;
            dtpMorningEnd.Value = new DateTime(2026, 11, 9, 8, 0, 0, 0);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(284, 209);
            label2.Name = "label2";
            label2.Size = new Size(36, 32);
            label2.TabIndex = 11;
            label2.Text = "to";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(284, 318);
            label3.Name = "label3";
            label3.Size = new Size(36, 32);
            label3.TabIndex = 14;
            label3.Text = "to";
            // 
            // dtpEveningStart
            // 
            dtpEveningStart.CustomFormat = "h:mm tt";
            dtpEveningStart.Format = DateTimePickerFormat.Custom;
            dtpEveningStart.Location = new Point(61, 311);
            dtpEveningStart.Name = "dtpEveningStart";
            dtpEveningStart.ShowUpDown = true;
            dtpEveningStart.Size = new Size(200, 39);
            dtpEveningStart.TabIndex = 12;
            dtpEveningStart.Value = new DateTime(2026, 11, 9, 16, 30, 0, 0);
            // 
            // dtpEveningEnd
            // 
            dtpEveningEnd.CustomFormat = "h:mm tt";
            dtpEveningEnd.Format = DateTimePickerFormat.Custom;
            dtpEveningEnd.Location = new Point(335, 311);
            dtpEveningEnd.Name = "dtpEveningEnd";
            dtpEveningEnd.ShowUpDown = true;
            dtpEveningEnd.Size = new Size(200, 39);
            dtpEveningEnd.TabIndex = 13;
            dtpEveningEnd.Value = new DateTime(2026, 11, 9, 17, 0, 0, 0);
            // 
            // chkEnableAutoDeactivation
            // 
            chkEnableAutoDeactivation.AutoSize = true;
            chkEnableAutoDeactivation.Location = new Point(61, 269);
            chkEnableAutoDeactivation.Name = "chkEnableAutoDeactivation";
            chkEnableAutoDeactivation.Size = new Size(419, 36);
            chkEnableAutoDeactivation.TabIndex = 15;
            chkEnableAutoDeactivation.Text = "Enable Auto Deactivation Between:";
            chkEnableAutoDeactivation.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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