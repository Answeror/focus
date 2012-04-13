using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
//using System.Drawing.Drawing2D;

namespace focus
{
    public partial class DarkForm : Form
    {
        MovablePython.Hotkey hotkey = new MovablePython.Hotkey();
        MovablePython.Hotkey catchEsc = new MovablePython.Hotkey();
        MovablePython.Hotkey catchSave = new MovablePython.Hotkey();
        //ForegroundTracker tracker = new ForegroundTracker();
        IntPtr target = IntPtr.Zero;
        private NotifyIcon trayIcon = new NotifyIcon();
        private ContextMenu trayMenu = new ContextMenu();

        public DarkForm()
        {
            InitializeComponent();

            this.pictureBox1.MouseWheel += new MouseEventHandler(panel1_MouseWheel);
        }

        private void panel1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta != 0)
            {
                Properties.Settings.Default.Opacity =
                    Math.Min(1, Math.Max(0, Properties.Settings.Default.Opacity + e.Delta / 12000.0));
            }
        }

        bool Foreground
        {
            get
            {
                var target = GetForegroundWindow();
                return target == this.Handle;
            }
        }

        private void InitHotkeys()
        {
            hotkey.Control = true;
            hotkey.Alt = true;
            hotkey.KeyCode = Keys.F;
            //hotkey.Windows = true;
            hotkey.Pressed += delegate { Follow(); };
            hotkey.Register(this);

            catchEsc.KeyCode = Keys.Escape;
            catchEsc.Pressed += delegate
            {
                if (Foreground)
                {
                    DetachFromTarget();
                }
            };
            catchEsc.Register(this);

            catchSave.KeyCode = Keys.S;
            catchSave.Control = true;
            catchSave.Pressed += delegate
            {
                MessageBox.Show(Properties.Settings.Default.Opacity.ToString());
                if (Foreground)
                {
                    Properties.Settings.Default.Save();
                }
            };
            catchSave.Register(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            this.ShowInTaskbar = false;

            //NativeMethods.MakeTopMost(this);
            this.TopMost = false;
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            //this.Opacity = Properties.Settings.Default.Opacity;
            //this.TransparencyKey = System.Drawing.SystemColors.Control;
            //this.TopLevel = true;
            //this.TransparencyKey = Color.FromArgb(255, 220, 33, 55);
            //this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.BackColor = Color.Black;
            this.TransparencyKey = Color.Red;
            //SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //SetStyle(ControlStyles.Opaque, true);
            //this.BackColor = Color.Transparent;

            MdiClient Client = new MdiClient();
            this.Controls.Add(Client);
            Form Child = new LightForm();

            Child.Size = new Size(100, 100);
            //Child.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Child.StartPosition = FormStartPosition.CenterParent;
            Child.MaximizeBox = false;
            Child.MinimizeBox = false;

            Child.MdiParent = this;
            this.pictureBox1.Controls.Add(Child);

            Child.Show();


            InitHotkeys();

            //this.Hide();
            trayMenu.MenuItems.Add("Exit", delegate { this.Close(); });
            trayIcon.Text = "focus";
            trayIcon.Icon = new Icon(Properties.Resources._32, 32, 32);
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;

            //tracker.ForgroundChanged += delegate (IntPtr hwnd)
            //{
            //    if (hwnd != this.Handle)
            //    {
            //        if (hwnd == this.target)
            //        {
            //            AttachToTarget(this.target);
            //        }
            //        else
            //        {
            //            this.Hide();
            //        }
            //    }
            //};
        }

        //private void Form1_Paint(object sender, PaintEventArgs e)
        //{
        //    var hb = new HatchBrush(HatchStyle.Percent50, this.TransparencyKey);

        //    e.Graphics.FillRectangle(hb, this.DisplayRectangle);
        //}

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        void AttachToTarget(IntPtr target)
        {
            this.target = target;
            RECT rect = new RECT();
            GetWindowRect(this.target, ref rect);
            this.Left = rect.Left;
            this.Top = rect.Top;
            this.Width = rect.Right - rect.Left;
            this.Height = rect.Bottom - rect.Top;
            this.Show();
        }

        void DetachFromTarget()
        {
            this.target = IntPtr.Zero;
            this.Hide();
        }

        void Follow()
        {
            var target = GetForegroundWindow();
            if (this.target != target && target != this.Handle)
            {
                AttachToTarget(target);
            }
            else
            {
                DetachFromTarget();
            }
        }
    }
}
