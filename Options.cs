using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace focus
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();

            var bind = new Binding("Value", Properties.Settings.Default, "Opacity");
            bind.Format += (sender, e) => { e.Value = (int)Math.Round((double)e.Value * 100); };
            opacityTrackBar.DataBindings.Add(bind);
            opacityTrackBar.ValueChanged += delegate
            {
                Properties.Settings.Default.Opacity = opacityTrackBar.Value / 100.0;
            };

            //controlCheckBox.CheckedChanged += delegate
            //{
            //    Properties.Settings.Default.Control = controlCheckBox.Checked;
            //};
            //shiftCheckBox.CheckedChanged += delegate
            //{
            //    Properties.Settings.Default.Shift = shiftCheckBox.Checked;
            //};
            //altCheckBox.CheckedChanged += delegate
            //{
            //    Properties.Settings.Default.Alt = altCheckBox.Checked;
            //};
            //keyComboBox.TextChanged += delegate
            //{
            //    Properties.Settings.Default.Key = keyComboBox.Text;
            //};
        }

        public event EventHandler UpdateSettings;

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            UpdateSettings(this, null);
            Hide();
            e.Cancel = true;
            //base.OnFormClosing(e);

            //if (e.CloseReason == CloseReason.WindowsShutDown) return;

            //// Confirm user wants to close
            //switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
            //{
            //    case DialogResult.No:
            //        e.Cancel = true;
            //        break;
            //    default:
            //        break;
            //}
        }
    }
}
