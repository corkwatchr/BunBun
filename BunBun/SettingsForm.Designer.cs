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
            groupBox1 = new GroupBox();
            label4 = new Label();
            nudInactivityMinutes = new NumericUpDown();
            chkInactiveDeactivation = new CheckBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudStopIntervalMinutes).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudInactivityMinutes).BeginInit();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(325, 474);
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
            btnCancel.Location = new Point(510, 474);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 46);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // nudStopIntervalMinutes
            // 
            nudStopIntervalMinutes.Location = new Point(226, 20);
            nudStopIntervalMinutes.Maximum = new decimal(new int[] { 1440, 0, 0, 0 });
            nudStopIntervalMinutes.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudStopIntervalMinutes.Name = "nudStopIntervalMinutes";
            nudStopIntervalMinutes.Size = new Size(100, 39);
            nudStopIntervalMinutes.TabIndex = 4;
            nudStopIntervalMinutes.TextAlign = HorizontalAlignment.Center;
            nudStopIntervalMinutes.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(347, 23);
            label1.Name = "label1";
            label1.Size = new Size(100, 32);
            label1.TabIndex = 5;
            label1.Text = "minutes";
            // 
            // chkEnableAutoActivation
            // 
            chkEnableAutoActivation.AutoSize = true;
            chkEnableAutoActivation.Location = new Point(38, 58);
            chkEnableAutoActivation.Name = "chkEnableAutoActivation";
            chkEnableAutoActivation.Size = new Size(343, 36);
            chkEnableAutoActivation.TabIndex = 6;
            chkEnableAutoActivation.Text = "Activate randomly between:";
            chkEnableAutoActivation.UseVisualStyleBackColor = true;
            chkEnableAutoActivation.CheckedChanged += chkEnableAutoActivation_CheckedChanged;
            // 
            // dtpMorningStart
            // 
            dtpMorningStart.CustomFormat = "h:mm tt";
            dtpMorningStart.Format = DateTimePickerFormat.Custom;
            dtpMorningStart.Location = new Point(38, 100);
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
            dtpMorningEnd.Location = new Point(312, 100);
            dtpMorningEnd.Name = "dtpMorningEnd";
            dtpMorningEnd.ShowUpDown = true;
            dtpMorningEnd.Size = new Size(200, 39);
            dtpMorningEnd.TabIndex = 10;
            dtpMorningEnd.Value = new DateTime(2026, 11, 9, 8, 0, 0, 0);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(248, 103);
            label2.Name = "label2";
            label2.Size = new Size(54, 32);
            label2.TabIndex = 11;
            label2.Text = "and";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(248, 211);
            label3.Name = "label3";
            label3.Size = new Size(54, 32);
            label3.TabIndex = 14;
            label3.Text = "and";
            // 
            // dtpEveningStart
            // 
            dtpEveningStart.CustomFormat = "h:mm tt";
            dtpEveningStart.Format = DateTimePickerFormat.Custom;
            dtpEveningStart.Location = new Point(38, 209);
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
            dtpEveningEnd.Location = new Point(312, 209);
            dtpEveningEnd.Name = "dtpEveningEnd";
            dtpEveningEnd.ShowUpDown = true;
            dtpEveningEnd.Size = new Size(200, 39);
            dtpEveningEnd.TabIndex = 13;
            dtpEveningEnd.Value = new DateTime(2026, 11, 9, 17, 0, 0, 0);
            // 
            // chkEnableAutoDeactivation
            // 
            chkEnableAutoDeactivation.AutoSize = true;
            chkEnableAutoDeactivation.Location = new Point(38, 167);
            chkEnableAutoDeactivation.Name = "chkEnableAutoDeactivation";
            chkEnableAutoDeactivation.Size = new Size(370, 36);
            chkEnableAutoDeactivation.TabIndex = 15;
            chkEnableAutoDeactivation.Text = "Deactivate randomly between:";
            chkEnableAutoDeactivation.UseVisualStyleBackColor = true;
            chkEnableAutoDeactivation.CheckedChanged += chkEnableAutoDeactivation_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(nudInactivityMinutes);
            groupBox1.Controls.Add(chkInactiveDeactivation);
            groupBox1.Controls.Add(chkEnableAutoActivation);
            groupBox1.Controls.Add(chkEnableAutoDeactivation);
            groupBox1.Controls.Add(dtpMorningStart);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(dtpMorningEnd);
            groupBox1.Controls.Add(dtpEveningEnd);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(dtpEveningStart);
            groupBox1.Location = new Point(45, 72);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(590, 376);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Optional Settings";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(152, 319);
            label4.Name = "label4";
            label4.Size = new Size(231, 32);
            label4.TabIndex = 18;
            label4.Text = "minutes of inactivity";
            // 
            // nudInactivityMinutes
            // 
            nudInactivityMinutes.Location = new Point(38, 316);
            nudInactivityMinutes.Maximum = new decimal(new int[] { 1440, 0, 0, 0 });
            nudInactivityMinutes.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudInactivityMinutes.Name = "nudInactivityMinutes";
            nudInactivityMinutes.Size = new Size(100, 39);
            nudInactivityMinutes.TabIndex = 17;
            nudInactivityMinutes.TextAlign = HorizontalAlignment.Center;
            nudInactivityMinutes.Value = new decimal(new int[] { 60, 0, 0, 0 });
            // 
            // chkInactiveDeactivation
            // 
            chkInactiveDeactivation.AutoSize = true;
            chkInactiveDeactivation.Location = new Point(38, 274);
            chkInactiveDeactivation.Name = "chkInactiveDeactivation";
            chkInactiveDeactivation.Size = new Size(368, 36);
            chkInactiveDeactivation.TabIndex = 16;
            chkInactiveDeactivation.Text = "Automatically deactivate after:";
            chkInactiveDeactivation.UseVisualStyleBackColor = true;
            chkInactiveDeactivation.CheckedChanged += chkInactiveDeactivation_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(53, 23);
            label5.Name = "label5";
            label5.Size = new Size(153, 32);
            label5.TabIndex = 17;
            label5.Text = "Stomp every:";
            // 
            // SettingsForm
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(682, 541);
            Controls.Add(label5);
            Controls.Add(groupBox1);
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
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudInactivityMinutes).EndInit();
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
        private GroupBox groupBox1;
        private Label label4;
        private NumericUpDown nudInactivityMinutes;
        private CheckBox chkInactiveDeactivation;
        private Label label5;
    }
}