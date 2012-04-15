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

using MovablePython;
using System.Diagnostics;

namespace focus
{
    public partial class DarkForm : Form
    {
        private const int GWL_STYLE = (-16);
        private const int GWL_EXSTYLE = (-20);

        MovablePython.Hotkey hotkey = new MovablePython.Hotkey();
        MovablePython.Hotkey catchEsc = new MovablePython.Hotkey();
        MovablePython.Hotkey catchSave = new MovablePython.Hotkey();
        //ForegroundTracker tracker = new ForegroundTracker();
        IntPtr target = IntPtr.Zero;
        private NotifyIcon trayIcon = new NotifyIcon();
        private ContextMenu trayMenu = new ContextMenu();
        Hotkey catchSolid = new Hotkey();
        DateTime lastPressTime = DateTime.Now;
        Options options;

        bool Foreground
        {
            get
            {
                var target = GetForegroundWindow();
                return target == this.Handle;
            }
        }

        public DarkForm()
        {
            InitializeComponent();

            pictureBox1.MouseWheel += new MouseEventHandler(panel1_MouseWheel);

            ShowInTaskbar = false;
            //pictureBox1.BackColor = Color.Red;
            //BackColor = Color.FromArgb(120, Color.Black);
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.Black;
            TransparencyKey = Color.Red;
            InitLightForm();
            InitHotkeys();
            InitTray();
        }

        private void panel1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta != 0)
            {
                Properties.Settings.Default.Opacity =
                    Math.Min(1, Math.Max(0, Properties.Settings.Default.Opacity + e.Delta / 12000.0));
            }
        }

        private void ResetCatchToggle()
        {
            //hotkey.Unregister();
            if (hotkey.Registered)
            {
                hotkey.Unregister();
            }
            hotkey = new Hotkey();
            hotkey.Control = Properties.Settings.Default.Control;
            hotkey.Shift = Properties.Settings.Default.Shift;
            hotkey.Alt = Properties.Settings.Default.Alt;
            hotkey.KeyCode = (Keys)(byte)char.ToUpper(Properties.Settings.Default.Key[0]);
            hotkey.Pressed += delegate { Follow(); };
            hotkey.Register(this);
        }

        private void InitHotkeys()
        {
            ResetCatchToggle();

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
                if (Foreground)
                {
                    Properties.Settings.Default.Save();
                }
            };
            catchSave.Register(this);

            catchSolid.KeyCode = Keys.CapsLock;
            catchSolid.Pressed += delegate
            {
                if ((DateTime.Now - lastPressTime).TotalSeconds < 0.5)
                {
                    int old = NativeMethods.GetWindowLong(Handle, GWL_EXSTYLE);
                    int flag = (int)(WindowStyles.WS_EX_TRANSPARENT);
                    NativeMethods.SetWindowLong(Handle, GWL_EXSTYLE,
                        (old & flag) != 0 ? old & ~flag : old | flag);
                }
                lastPressTime = DateTime.Now;
            };
            catchSolid.Register(this);
        }

        private void InitLightForm()
        {
            MdiClient Client = new MdiClient();
            Controls.Add(Client);
            Form Child = new LightForm();

            Child.Size = new Size(100, 100);
            //Child.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Child.StartPosition = FormStartPosition.CenterParent;
            Child.MaximizeBox = false;
            Child.MinimizeBox = false;

            Child.MdiParent = this;
            pictureBox1.Controls.Add(Child);
            Child.Show();
        }

        private void InitTray()
        {
            trayMenu.MenuItems.Add("Options", delegate
            {
                if (options == null)
                {
                    options = new Options();
                    options.UpdateSettings += delegate
                    {
                        //Properties.Settings.Default.Save();
                        ResetCatchToggle();
                    };
                }
                options.Show();
            });
            trayMenu.MenuItems.Add("Exit", delegate { this.Close(); });
            trayIcon.Text = "focus";
            trayIcon.Icon = new Icon(Properties.Resources._32, 32, 32);
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;
        }

        private void BecomeTopmost()
        {
            TopMost = false;
            TopMost = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Hide();
            Location = new Point(881222, 881222);
            BecomeTopmost();
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

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

        private bool ExistTargetToAttach
        {
            get
            {
                return this.target != GetForegroundWindow() && !Foreground;
            }
        }

        private void AttachToTarget(IntPtr target)
        {
            this.target = target;
            RECT rect = new RECT();
            GetWindowRect(this.target, ref rect);
            Left = rect.Left;
            Top = rect.Top;
            Width = rect.Right - rect.Left;
            Height = rect.Bottom - rect.Top;
            Show();
            Focus();
        }

        private void AttachToForground()
        {
            AttachToTarget(GetForegroundWindow());
        }

        private void DetachFromTarget()
        {
            this.target = IntPtr.Zero;
            Hide();
        }

        private void Follow()
        {
            if (ExistTargetToAttach)
            {
                AttachToForground();
            }
            else
            {
                DetachFromTarget();
            }
        }
    }
}
