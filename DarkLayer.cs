using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace focus
{
    public partial class DarkLayer : Form
    {
        Form target = null;

        public Form Target
        {
            get
            {
                return target;
            }
        }

        /// <summary>
        /// Get the low-level windows flag that will be given to CreateWindow.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                //cp.ExStyle |= 0x20; // WS_EX_TRANSPARENT
                //cp.ExStyle |= 0x80; // WS_EX_TOOLWINDOW 
                cp.ExStyle |= (int)(
                    WindowStyles.WS_EX_TRANSPARENT |
                    WindowStyles.WS_EX_TOOLWINDOW |
                    WindowStyles.WS_EX_NOACTIVATE
                    );
                return cp;
            }
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        public DarkLayer()
        {
            InitializeComponent();

            Opacity = 0.5;
            FormBorderStyle = FormBorderStyle.None;
            SizeGripStyle = SizeGripStyle.Hide;
            //StartPosition = FormStartPosition.Manual;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowIcon = false;
            ShowInTaskbar = false;
            SetStyle(ControlStyles.Selectable, false);
            BackColor = Color.Black;
            //NativeMethods.ShowWithoutActivate(this);

            //Visible = false;
        }

        ~DarkLayer()
        {
            Unbind();
        }

        private void DarkLayer_Load(object sender, EventArgs e)
        {
            //Visible = false;
            //Follow();
            //Visible = true;
        }

        public void Bind(Form target)
        {
            this.target = target;
            this.target.LocationChanged += new EventHandler(Target_LocationChanged);
            this.target.SizeChanged += new EventHandler(Target_SizeChanged);
            this.target.ResizeBegin += new EventHandler(Target_ResizeBegin);
            this.target.ResizeEnd += new EventHandler(Target_ResizeEnd);
            this.target.VisibleChanged += new EventHandler(Target_VisibleChanged);
            //Follow();
            //Show();
        }

        public void Unbind()
        {
            if (Binded())
            {
                this.target.LocationChanged -= new EventHandler(Target_LocationChanged);
                this.target.SizeChanged -= new EventHandler(Target_SizeChanged);
                this.target.ResizeBegin -= new EventHandler(Target_ResizeBegin);
                this.target.ResizeEnd -= new EventHandler(Target_ResizeEnd);
                this.target.VisibleChanged -= new EventHandler(Target_VisibleChanged);
                this.target = null;
                HideLayer();
            }
        }

        public bool Binded()
        {
            return this.target != null;
        }

        void Target_LocationChanged(object sender, EventArgs e)
        {
            Follow();
        }

        void Target_SizeChanged(object sender, EventArgs e)
        {
            Follow();
        }

        void Target_ResizeBegin(object sender, EventArgs e)
        {
            HideLayer();
        }

        void Target_ResizeEnd(object sender, EventArgs e)
        {
            Follow();
        }

        void Target_VisibleChanged(object sender, EventArgs e)
        {
            Follow();
        }

        private void Follow()
        {
            if (Binded())
            {
                if (Target.Visible)
                {
                    if (Target.TopMost)
                    {
                        //NativeMethods.MakeTopMost(this);
                        TopMost = false;
                        TopMost = true;
                        //TopMost = false;
                    }
                    this.Location = Target.Location;
                    this.Size = Target.Size;
                    ShowLayer();
                }
                else
                {
                    HideLayer();
                }
            }
            else
            {
                HideLayer();
            }
            //Invalidate();
        }

        private void HideLayer()
        {
            //this.Location = new Point(65535, 65535);
            //this.Size = new Size(1, 1);
            //this.Visible = false;
            Hide();
        }

        private void ShowLayer()
        {
            Show();
        }
    }
}
