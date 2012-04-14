namespace focus
{
    partial class Options
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
            this.opacityTrackBar = new System.Windows.Forms.TrackBar();
            this.opacityGroupBox = new System.Windows.Forms.GroupBox();
            this.shortcutGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.keyComboBox = new System.Windows.Forms.ComboBox();
            this.altCheckBox = new System.Windows.Forms.CheckBox();
            this.shiftCheckBox = new System.Windows.Forms.CheckBox();
            this.controlCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.opacityTrackBar)).BeginInit();
            this.opacityGroupBox.SuspendLayout();
            this.shortcutGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // opacityTrackBar
            // 
            this.opacityTrackBar.LargeChange = 10;
            this.opacityTrackBar.Location = new System.Drawing.Point(6, 20);
            this.opacityTrackBar.Maximum = 100;
            this.opacityTrackBar.Name = "opacityTrackBar";
            this.opacityTrackBar.Size = new System.Drawing.Size(248, 45);
            this.opacityTrackBar.TabIndex = 3;
            this.opacityTrackBar.TickFrequency = 10;
            // 
            // opacityGroupBox
            // 
            this.opacityGroupBox.Controls.Add(this.opacityTrackBar);
            this.opacityGroupBox.Location = new System.Drawing.Point(12, 12);
            this.opacityGroupBox.Name = "opacityGroupBox";
            this.opacityGroupBox.Size = new System.Drawing.Size(260, 71);
            this.opacityGroupBox.TabIndex = 4;
            this.opacityGroupBox.TabStop = false;
            this.opacityGroupBox.Text = "Opacity";
            // 
            // shortcutGroupBox
            // 
            this.shortcutGroupBox.Controls.Add(this.label3);
            this.shortcutGroupBox.Controls.Add(this.label2);
            this.shortcutGroupBox.Controls.Add(this.label1);
            this.shortcutGroupBox.Controls.Add(this.keyComboBox);
            this.shortcutGroupBox.Controls.Add(this.altCheckBox);
            this.shortcutGroupBox.Controls.Add(this.shiftCheckBox);
            this.shortcutGroupBox.Controls.Add(this.controlCheckBox);
            this.shortcutGroupBox.Location = new System.Drawing.Point(12, 90);
            this.shortcutGroupBox.Name = "shortcutGroupBox";
            this.shortcutGroupBox.Size = new System.Drawing.Size(260, 58);
            this.shortcutGroupBox.TabIndex = 5;
            this.shortcutGroupBox.TabStop = false;
            this.shortcutGroupBox.Text = "Shortcut";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "+";
            // 
            // keyComboBox
            // 
            this.keyComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::focus.Properties.Settings.Default, "Key", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.keyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.keyComboBox.FormattingEnabled = true;
            this.keyComboBox.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.keyComboBox.Location = new System.Drawing.Point(201, 21);
            this.keyComboBox.Name = "keyComboBox";
            this.keyComboBox.Size = new System.Drawing.Size(40, 20);
            this.keyComboBox.TabIndex = 3;
            this.keyComboBox.Text = global::focus.Properties.Settings.Default.Key;
            // 
            // altCheckBox
            // 
            this.altCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.altCheckBox.AutoSize = true;
            this.altCheckBox.Checked = global::focus.Properties.Settings.Default.Alt;
            this.altCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.altCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::focus.Properties.Settings.Default, "Alt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.altCheckBox.Location = new System.Drawing.Point(145, 20);
            this.altCheckBox.Name = "altCheckBox";
            this.altCheckBox.Size = new System.Drawing.Size(33, 22);
            this.altCheckBox.TabIndex = 2;
            this.altCheckBox.Text = "ALT";
            this.altCheckBox.UseVisualStyleBackColor = true;
            // 
            // shiftCheckBox
            // 
            this.shiftCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.shiftCheckBox.AutoSize = true;
            this.shiftCheckBox.Checked = global::focus.Properties.Settings.Default.Shift;
            this.shiftCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::focus.Properties.Settings.Default, "Shift", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.shiftCheckBox.Location = new System.Drawing.Point(77, 20);
            this.shiftCheckBox.Name = "shiftCheckBox";
            this.shiftCheckBox.Size = new System.Drawing.Size(45, 22);
            this.shiftCheckBox.TabIndex = 1;
            this.shiftCheckBox.Text = "SHIFT";
            this.shiftCheckBox.UseVisualStyleBackColor = true;
            // 
            // controlCheckBox
            // 
            this.controlCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.controlCheckBox.AutoSize = true;
            this.controlCheckBox.Checked = global::focus.Properties.Settings.Default.Control;
            this.controlCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.controlCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::focus.Properties.Settings.Default, "Control", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.controlCheckBox.Location = new System.Drawing.Point(15, 20);
            this.controlCheckBox.Name = "controlCheckBox";
            this.controlCheckBox.Size = new System.Drawing.Size(39, 22);
            this.controlCheckBox.TabIndex = 0;
            this.controlCheckBox.Text = "CTRL";
            this.controlCheckBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "+";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(184, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "+";
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 158);
            this.Controls.Add(this.shortcutGroupBox);
            this.Controls.Add(this.opacityGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Options";
            this.Text = "Options";
            ((System.ComponentModel.ISupportInitialize)(this.opacityTrackBar)).EndInit();
            this.opacityGroupBox.ResumeLayout(false);
            this.opacityGroupBox.PerformLayout();
            this.shortcutGroupBox.ResumeLayout(false);
            this.shortcutGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar opacityTrackBar;
        private System.Windows.Forms.GroupBox opacityGroupBox;
        private System.Windows.Forms.GroupBox shortcutGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox keyComboBox;
        private System.Windows.Forms.CheckBox altCheckBox;
        private System.Windows.Forms.CheckBox shiftCheckBox;
        private System.Windows.Forms.CheckBox controlCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}