using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Collections;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing.Imaging;
namespace OOPLab1
{
    #pragma warning disable 414
    public class FormSkin : ContainerControl
    {
    

        private static List<WeakReference> __ENCList = new List<WeakReference>();
        private int W;
        private int H;
        private bool Cap;
        private bool _HeaderMaximize;
        private Point MousePoint;
        private object MoveHeight;
        private Color _HeaderColor;
        private Color _BaseColor;
        private Color _BorderColor;
        private Color TextColor;
        private Color _HeaderLight;
        private Color _BaseLight;
        public Color TextLight;
        [Category("Colors")]
        public Color HeaderColor
        {
            get
            {
                return this._HeaderColor;
            }
            set
            {
                this._HeaderColor = value;
            }
        }
        [Category("Colors")]
        public Color BaseColor
        {
            get
            {
                return this._BaseColor;
            }
            set
            {
                this._BaseColor = value;
            }
        }
        [Category("Colors")]
        public Color BorderColor
        {
            get
            {
                return this._BorderColor;
            }
            set
            {
                this._BorderColor = value;
            }
        }
        [Category("Colors")]
        public Color FlatColor
        {
            get
            {
                return Helpers._FlatColor;
            }
            set
            {
                Helpers._FlatColor = value;
            }
        }
        [Category("Options")]
        public bool HeaderMaximize
        {
            get
            {
                return this._HeaderMaximize;
            }
            set
            {
                this._HeaderMaximize = value;
            }
        }
        [DebuggerNonUserCode]
        private static void __ENCAddToList(object value)
        {
            List<WeakReference> _ENCList = FormSkin.__ENCList;
            bool flag = false;
            checked
            {
                try
                {
                    Monitor.Enter(_ENCList, ref flag);
                    bool flag2 = FormSkin.__ENCList.Count == FormSkin.__ENCList.Capacity;
                    if (flag2)
                    {
                        int num = 0;
                        int arg_44_0 = 0;
                        int num2 = FormSkin.__ENCList.Count - 1;
                        int num3 = arg_44_0;
                        while (true)
                        {
                            int arg_95_0 = num3;
                            int num4 = num2;
                            if (arg_95_0 > num4)
                            {
                                break;
                            }
                            WeakReference weakReference = FormSkin.__ENCList[num3];
                            flag2 = weakReference.IsAlive;
                            if (flag2)
                            {
                                bool flag3 = num3 != num;
                                if (flag3)
                                {
                                    FormSkin.__ENCList[num] = FormSkin.__ENCList[num3];
                                }
                                num++;
                            }
                            num3++;
                        }
                        FormSkin.__ENCList.RemoveRange(num, FormSkin.__ENCList.Count - num);
                        FormSkin.__ENCList.Capacity = FormSkin.__ENCList.Count;
                    }
                    FormSkin.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
                }
                finally
                {
                    bool flag3 = flag;
                    if (flag3)
                    {
                        Monitor.Exit(_ENCList);
                    }
                }
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            bool arg_40_0 = e.Button == MouseButtons.Left;
            Rectangle rectangle = new Rectangle(0, 0, this.Width, Conversions.ToInteger(this.MoveHeight));
            Rectangle rectangle2 = rectangle;
            bool flag = arg_40_0 & rectangle2.Contains(e.Location);
            if (flag)
            {
                this.Cap = true;
                this.MousePoint = e.Location;
            }
        }
        private void FormSkin_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            bool headerMaximize = this.HeaderMaximize;
            if (headerMaximize)
            {
                bool arg_45_0 = e.Button == MouseButtons.Left;
                Rectangle rectangle = new Rectangle(0, 0, this.Width, Conversions.ToInteger(this.MoveHeight));
                Rectangle rectangle2 = rectangle;
                bool flag = arg_45_0 & rectangle2.Contains(e.Location);
                if (flag)
                {
                    bool flag2 = this.FindForm().WindowState == FormWindowState.Normal;
                    if (flag2)
                    {
                        this.FindForm().WindowState = FormWindowState.Maximized;
                        this.FindForm().Refresh();
                    }
                    else
                    {
                        flag2 = (this.FindForm().WindowState == FormWindowState.Maximized);
                        if (flag2)
                        {
                            this.FindForm().WindowState = FormWindowState.Normal;
                            this.FindForm().Refresh();
                        }
                    }
                }
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.Cap = false;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            bool cap = this.Cap;
            if (cap)
            {
                this.Parent.Location = Control.MousePosition - (Size)this.MousePoint;
            }
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.ParentForm.FormBorderStyle = FormBorderStyle.None;
            this.ParentForm.AllowTransparency = false;
            this.ParentForm.TransparencyKey = Color.Fuchsia;
            this.ParentForm.FindForm().StartPosition = FormStartPosition.CenterScreen;
            this.Dock = DockStyle.Fill;
            this.Invalidate();
        }
        public FormSkin()
        {
            base.MouseDoubleClick += new MouseEventHandler(this.FormSkin_MouseDoubleClick);
            FormSkin.__ENCAddToList(this);
            this.Cap = false;
            this._HeaderMaximize = false;
            this.MousePoint = new Point(0, 0);
            this.MoveHeight = 50;
            this._HeaderColor = Color.FromArgb(45, 47, 49);
            this._BaseColor = Color.FromArgb(60, 70, 73);
            this._BorderColor = Color.FromArgb(53, 58, 60);
            this.TextColor = Color.FromArgb(234, 234, 234);
            this._HeaderLight = Color.FromArgb(171, 171, 172);
            this._BaseLight = Color.FromArgb(196, 199, 200);
            this.TextLight = Color.FromArgb(45, 47, 49);
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 12f);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Helpers.B = new Bitmap(this.Width, this.Height);
            Helpers.G = Graphics.FromImage(Helpers.B);
            this.W = this.Width;
            this.H = this.Height;
            Rectangle rect = new Rectangle(0, 0, this.W, this.H);
            Rectangle rect2 = new Rectangle(0, 0, this.W, 50);
            Graphics g = Helpers.G;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            g.Clear(this.BackColor);
            g.FillRectangle(new SolidBrush(this._BaseColor), rect);
            g.FillRectangle(new SolidBrush(this._HeaderColor), rect2);
            Graphics arg_E0_0 = g;
            Brush arg_E0_1 = new SolidBrush(Color.FromArgb(243, 243, 243));
            Rectangle rectangle = new Rectangle(8, 16, 4, 18);
            arg_E0_0.FillRectangle(arg_E0_1, rectangle);
            g.FillRectangle(new SolidBrush(Helpers._FlatColor), 16, 16, 4, 18);
            Graphics arg_139_0 = g;
            string arg_139_1 = this.Text; //string arg_139_1 = this.Text;
            Font arg_139_2 = this.Font;
            Brush arg_139_3 = new SolidBrush(this.TextColor);
            rectangle = new Rectangle(26, 15, this.W, this.H);
            arg_139_0.DrawString(arg_139_1, arg_139_2, arg_139_3, rectangle, Helpers.NearSF);
            g.DrawRectangle(new Pen(this._BorderColor), rect);
            base.OnPaint(e);
            Helpers.G.Dispose();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
            Helpers.B.Dispose();
            
        }
    }
    public class FlatButton : Control
    {
        private static List<WeakReference> __ENCList = new List<WeakReference>();
        private int W;
        private int H;
        private bool _Rounded;
        private MouseState State;
        private Color _BaseColor;
        private Color _TextColor;
        [Category("Colors")]
        public Color BaseColor
        {
            get
            {
                return this._BaseColor;
            }
            set
            {
                this._BaseColor = value;
            }
        }
        [Category("Colors")]
        public Color TextColor
        {
            get
            {
                return this._TextColor;
            }
            set
            {
                this._TextColor = value;
            }
        }
        [Category("Options")]
        public bool Rounded
        {
            get
            {
                return this._Rounded;
            }
            set
            {
                this._Rounded = value;
            }
        }
        [DebuggerNonUserCode]
        private static void __ENCAddToList(object value)
        {
            List<WeakReference> _ENCList = FlatButton.__ENCList;
            bool flag = false;
            checked
            {
                try
                {
                    Monitor.Enter(_ENCList, ref flag);
                    bool flag2 = FlatButton.__ENCList.Count == FlatButton.__ENCList.Capacity;
                    if (flag2)
                    {
                        int num = 0;
                        int arg_44_0 = 0;
                        int num2 = FlatButton.__ENCList.Count - 1;
                        int num3 = arg_44_0;
                        while (true)
                        {
                            int arg_95_0 = num3;
                            int num4 = num2;
                            if (arg_95_0 > num4)
                            {
                                break;
                            }
                            WeakReference weakReference = FlatButton.__ENCList[num3];
                            flag2 = weakReference.IsAlive;
                            if (flag2)
                            {
                                bool flag3 = num3 != num;
                                if (flag3)
                                {
                                    FlatButton.__ENCList[num] = FlatButton.__ENCList[num3];
                                }
                                num++;
                            }
                            num3++;
                        }
                        FlatButton.__ENCList.RemoveRange(num, FlatButton.__ENCList.Count - num);
                        FlatButton.__ENCList.Capacity = FlatButton.__ENCList.Count;
                    }
                    FlatButton.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
                }
                finally
                {
                    bool flag3 = flag;
                    if (flag3)
                    {
                        Monitor.Exit(_ENCList);
                    }
                }
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.State = MouseState.Down;
            this.Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.State = MouseState.Over;
            this.Invalidate();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.State = MouseState.Over;
            this.Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.State = MouseState.None;
            this.Invalidate();
        }
        public FlatButton()
        {
            FlatButton.__ENCAddToList(this);
            this._Rounded = false;
            this.State = MouseState.None;
            this._BaseColor = Helpers._FlatColor;
            this._TextColor = Color.FromArgb(243, 243, 243);
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            Size size = new Size(106, 32);
            this.Size = size;
            this.BackColor = Color.Transparent;
            this.Font = new Font("Segoe UI", 12f);
            this.Cursor = Cursors.Hand;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Helpers.B = new Bitmap(this.Width, this.Height);
            Helpers.G = Graphics.FromImage(Helpers.B);
            checked
            {
                this.W = this.Width - 1;
                this.H = this.Height - 1;
                GraphicsPath path = new GraphicsPath();
                Rectangle rectangle = new Rectangle(0, 0, this.W, this.H);
                Graphics g = Helpers.G;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                g.Clear(this.BackColor);
                if (base.Enabled)
                    switch (this.State)
                    {
                        case MouseState.None:
                            {
                                bool rounded = this.Rounded;
                                if (rounded)
                                {
                                    path = Helpers.RoundRec(rectangle, 6);
                                    g.FillPath(new SolidBrush(this._BaseColor), path);
                                    g.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), rectangle, Helpers.CenterSF);
                                }
                                else
                                {
                                    g.FillRectangle(new SolidBrush(this._BaseColor), rectangle);
                                    g.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), rectangle, Helpers.CenterSF);
                                }
                                break;
                            }
                        case MouseState.Over:
                            {
                                bool rounded = this.Rounded;
                                if (rounded)
                                {
                                    path = Helpers.RoundRec(rectangle, 6);
                                    g.FillPath(new SolidBrush(this._BaseColor), path);
                                    g.FillPath(new SolidBrush(Color.FromArgb(20, Color.White)), path);
                                    g.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), rectangle, Helpers.CenterSF);
                                }
                                else
                                {
                                    g.FillRectangle(new SolidBrush(this._BaseColor), rectangle);
                                    g.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.White)), rectangle);
                                    g.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), rectangle, Helpers.CenterSF);
                                }
                                break;
                            }
                        case MouseState.Down:
                            {
                                bool rounded = this.Rounded;
                                if (rounded)
                                {
                                    path = Helpers.RoundRec(rectangle, 6);
                                    g.FillPath(new SolidBrush(this._BaseColor), path);
                                    g.FillPath(new SolidBrush(Color.FromArgb(20, Color.Black)), path);
                                    g.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), rectangle, Helpers.CenterSF);
                                }
                                else
                                {
                                    g.FillRectangle(new SolidBrush(this._BaseColor), rectangle);
                                    g.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.Black)), rectangle);
                                    g.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), rectangle, Helpers.CenterSF);
                                }
                                break;
                            }
                    }
                else
                {
                    bool rounded = this.Rounded;
                    if (rounded)
                    {
                        path = Helpers.RoundRec(rectangle, 6);
                        g.FillPath(new SolidBrush(this._BaseColor), path);
                        g.FillPath(new SolidBrush(Color.FromArgb(100, Color.Black)), path);
                        g.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), rectangle, Helpers.CenterSF);
                    }
                    else
                    {
                        g.FillRectangle(new SolidBrush(this._BaseColor), rectangle);
                        g.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Black)), rectangle);
                        g.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), rectangle, Helpers.CenterSF);
                    }
                }
                base.OnPaint(e);
                Helpers.G.Dispose();
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
                Helpers.B.Dispose();
            }
        }
    }
    public class FlatAlertBox : Control
    {
        [Flags]
        public enum _Kind
        {
            Success = 0,
            Error = 1,
            Info = 2
        }
        private static List<WeakReference> __ENCList = new List<WeakReference>();
        private int W;
        private int H;
        private FlatAlertBox._Kind K;
        private string _Text;
        private MouseState State;
        private int X;
        [AccessedThroughProperty("T")]
        private System.Windows.Forms.Timer _T;
        private Color SuccessColor;
        private Color SuccessText;
        private Color ErrorColor;
        private Color ErrorText;
        private Color InfoColor;
        private Color InfoText;
        public virtual System.Windows.Forms.Timer T
        {
            [DebuggerNonUserCode]
            get
            {
                return this._T;
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler value2 = new EventHandler(this.T_Tick);
                bool flag = this._T != null;
                if (flag)
                {
                    this._T.Tick -= value2;
                }
                this._T = value;
                flag = (this._T != null);
                if (flag)
                {
                    this._T.Tick += value2;
                }
            }
        }
        [Category("Options")]
        public FlatAlertBox._Kind kind
        {
            get
            {
                return this.K;
            }
            set
            {
                this.K = value;
            }
        }
        [Category("Options")]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                bool flag = this._Text != null;
                if (flag)
                {
                    this._Text = value;
                }
            }
        }
        [Category("Options")]
        public new bool Visible
        {
            get
            {
                return !base.Visible;
            }
            set
            {
                base.Visible = value;
            }
        }
        [DebuggerNonUserCode]
        private static void __ENCAddToList(object value)
        {
            List<WeakReference> _ENCList = FlatAlertBox.__ENCList;
            bool flag = false;
            checked
            {
                try
                {
                    Monitor.Enter(_ENCList, ref flag);
                    bool flag2 = FlatAlertBox.__ENCList.Count == FlatAlertBox.__ENCList.Capacity;
                    if (flag2)
                    {
                        int num = 0;
                        int arg_44_0 = 0;
                        int num2 = FlatAlertBox.__ENCList.Count - 1;
                        int num3 = arg_44_0;
                        while (true)
                        {
                            int arg_95_0 = num3;
                            int num4 = num2;
                            if (arg_95_0 > num4)
                            {
                                break;
                            }
                            WeakReference weakReference = FlatAlertBox.__ENCList[num3];
                            flag2 = weakReference.IsAlive;
                            if (flag2)
                            {
                                bool flag3 = num3 != num;
                                if (flag3)
                                {
                                    FlatAlertBox.__ENCList[num] = FlatAlertBox.__ENCList[num3];
                                }
                                num++;
                            }
                            num3++;
                        }
                        FlatAlertBox.__ENCList.RemoveRange(num, FlatAlertBox.__ENCList.Count - num);
                        FlatAlertBox.__ENCList.Capacity = FlatAlertBox.__ENCList.Count;
                    }
                    FlatAlertBox.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
                }
                finally
                {
                    bool flag3 = flag;
                    if (flag3)
                    {
                        Monitor.Exit(_ENCList);
                    }
                }
            }
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Invalidate();
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Height = 42;
        }
        public void ShowControl(FlatAlertBox._Kind Kind, string Str, int Interval)
        {
            this.K = Kind;
            this.Text = Str;
            this.Visible = true;
            this.T = new System.Windows.Forms.Timer();
            this.T.Interval = Interval;
            this.T.Enabled = true;
        }
        private void T_Tick(object sender, EventArgs e)
        {
            this.Visible = false;
            this.T.Enabled = false;
            this.T.Dispose();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.State = MouseState.Down;
            this.Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.State = MouseState.Over;
            this.Invalidate();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.State = MouseState.Over;
            this.Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.State = MouseState.None;
            this.Invalidate();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            this.X = e.X;
            this.Invalidate();
        }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            this.Visible = false;
        }
        public FlatAlertBox()
        {
            FlatAlertBox.__ENCAddToList(this);
            this.State = MouseState.None;
            this.SuccessColor = Color.FromArgb(60, 85, 79);
            this.SuccessText = Color.FromArgb(35, 169, 110);
            this.ErrorColor = Color.FromArgb(87, 71, 71);
            this.ErrorText = Color.FromArgb(254, 142, 122);
            this.InfoColor = Color.FromArgb(70, 91, 94);
            this.InfoText = Color.FromArgb(97, 185, 186);
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.BackColor = Color.FromArgb(60, 70, 73);
            Size size = new Size(576, 42);
            this.Size = size;
            Point location = new Point(10, 61);
            this.Location = location;
            this.Font = new Font("Segoe UI", 10f);
            this.Cursor = Cursors.Hand;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Helpers.B = new Bitmap(this.Width, this.Height);
            Helpers.G = Graphics.FromImage(Helpers.B);
            checked
            {
                this.W = this.Width - 1;
                this.H = this.Height - 1;
                Rectangle rect = new Rectangle(0, 0, this.W, this.H);
                Graphics g = Helpers.G;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                g.Clear(this.BackColor);
                switch (this.K)
                {
                    case FlatAlertBox._Kind.Success:
                        {
                            g.FillRectangle(new SolidBrush(this.SuccessColor), rect);
                            Graphics arg_CC_0 = g;
                            Brush arg_CC_1 = new SolidBrush(this.SuccessText);
                            Rectangle rectangle = new Rectangle(8, 9, 24, 24);
                            arg_CC_0.FillEllipse(arg_CC_1, rectangle);
                            Graphics arg_EF_0 = g;
                            Brush arg_EF_1 = new SolidBrush(this.SuccessColor);
                            rectangle = new Rectangle(10, 11, 20, 20);
                            arg_EF_0.FillEllipse(arg_EF_1, rectangle);
                            Graphics arg_136_0 = g;
                            string arg_136_1 = "ü";
                            Font arg_136_2 = new Font("Wingdings", 22f);
                            Brush arg_136_3 = new SolidBrush(this.SuccessText);
                            rectangle = new Rectangle(7, 7, this.W, this.H);
                            arg_136_0.DrawString(arg_136_1, arg_136_2, arg_136_3, rectangle, Helpers.NearSF);
                            Graphics arg_177_0 = g;
                            string arg_177_1 = this.Text;
                            Font arg_177_2 = this.Font;
                            Brush arg_177_3 = new SolidBrush(this.SuccessText);
                            rectangle = new Rectangle(48, 12, this.W, this.H);
                            arg_177_0.DrawString(arg_177_1, arg_177_2, arg_177_3, rectangle, Helpers.NearSF);
                            Graphics arg_1AE_0 = g;
                            Brush arg_1AE_1 = new SolidBrush(Color.FromArgb(35, Color.Black));
                            rectangle = new Rectangle(this.W - 30, this.H - 29, 17, 17);
                            arg_1AE_0.FillEllipse(arg_1AE_1, rectangle);
                            Graphics arg_1FE_0 = g;
                            string arg_1FE_1 = "r";
                            Font arg_1FE_2 = new Font("Marlett", 8f);
                            Brush arg_1FE_3 = new SolidBrush(this.SuccessColor);
                            rectangle = new Rectangle(this.W - 28, 16, this.W, this.H);
                            arg_1FE_0.DrawString(arg_1FE_1, arg_1FE_2, arg_1FE_3, rectangle, Helpers.NearSF);
                            MouseState state = this.State;
                            bool flag = state == MouseState.Over;
                            if (flag)
                            {
                                Graphics arg_269_0 = g;
                                string arg_269_1 = "r";
                                Font arg_269_2 = new Font("Marlett", 8f);
                                Brush arg_269_3 = new SolidBrush(Color.FromArgb(25, Color.White));
                                rectangle = new Rectangle(this.W - 28, 16, this.W, this.H);
                                arg_269_0.DrawString(arg_269_1, arg_269_2, arg_269_3, rectangle, Helpers.NearSF);
                            }
                            break;
                        }
                    case FlatAlertBox._Kind.Error:
                        {
                            g.FillRectangle(new SolidBrush(this.ErrorColor), rect);
                            Graphics arg_2A5_0 = g;
                            Brush arg_2A5_1 = new SolidBrush(this.ErrorText);
                            Rectangle rectangle = new Rectangle(8, 9, 24, 24);
                            arg_2A5_0.FillEllipse(arg_2A5_1, rectangle);
                            Graphics arg_2C8_0 = g;
                            Brush arg_2C8_1 = new SolidBrush(this.ErrorColor);
                            rectangle = new Rectangle(10, 11, 20, 20);
                            arg_2C8_0.FillEllipse(arg_2C8_1, rectangle);
                            Graphics arg_310_0 = g;
                            string arg_310_1 = "r";
                            Font arg_310_2 = new Font("Marlett", 16f);
                            Brush arg_310_3 = new SolidBrush(this.ErrorText);
                            rectangle = new Rectangle(6, 11, this.W, this.H);
                            arg_310_0.DrawString(arg_310_1, arg_310_2, arg_310_3, rectangle, Helpers.NearSF);
                            Graphics arg_351_0 = g;
                            string arg_351_1 = this.Text;
                            Font arg_351_2 = this.Font;
                            Brush arg_351_3 = new SolidBrush(this.ErrorText);
                            rectangle = new Rectangle(48, 12, this.W, this.H);
                            arg_351_0.DrawString(arg_351_1, arg_351_2, arg_351_3, rectangle, Helpers.NearSF);
                            Graphics arg_388_0 = g;
                            Brush arg_388_1 = new SolidBrush(Color.FromArgb(35, Color.Black));
                            rectangle = new Rectangle(this.W - 32, this.H - 29, 17, 17);
                            arg_388_0.FillEllipse(arg_388_1, rectangle);
                            Graphics arg_3D8_0 = g;
                            string arg_3D8_1 = "r";
                            Font arg_3D8_2 = new Font("Marlett", 8f);
                            Brush arg_3D8_3 = new SolidBrush(this.ErrorColor);
                            rectangle = new Rectangle(this.W - 30, 17, this.W, this.H);
                            arg_3D8_0.DrawString(arg_3D8_1, arg_3D8_2, arg_3D8_3, rectangle, Helpers.NearSF);
                            MouseState state2 = this.State;
                            bool flag = state2 == MouseState.Over;
                            if (flag)
                            {
                                Graphics arg_443_0 = g;
                                string arg_443_1 = "r";
                                Font arg_443_2 = new Font("Marlett", 8f);
                                Brush arg_443_3 = new SolidBrush(Color.FromArgb(25, Color.White));
                                rectangle = new Rectangle(this.W - 30, 15, this.W, this.H);
                                arg_443_0.DrawString(arg_443_1, arg_443_2, arg_443_3, rectangle, Helpers.NearSF);
                            }
                            break;
                        }
                    case FlatAlertBox._Kind.Info:
                        {
                            g.FillRectangle(new SolidBrush(this.InfoColor), rect);
                            Graphics arg_47F_0 = g;
                            Brush arg_47F_1 = new SolidBrush(this.InfoText);
                            Rectangle rectangle = new Rectangle(8, 9, 24, 24);
                            arg_47F_0.FillEllipse(arg_47F_1, rectangle);
                            Graphics arg_4A2_0 = g;
                            Brush arg_4A2_1 = new SolidBrush(this.InfoColor);
                            rectangle = new Rectangle(10, 11, 20, 20);
                            arg_4A2_0.FillEllipse(arg_4A2_1, rectangle);
                            Graphics arg_4EC_0 = g;
                            string arg_4EC_1 = "¡";
                            Font arg_4EC_2 = new Font("Segoe UI", 20f, FontStyle.Bold);
                            Brush arg_4EC_3 = new SolidBrush(this.InfoText);
                            rectangle = new Rectangle(12, -4, this.W, this.H);
                            arg_4EC_0.DrawString(arg_4EC_1, arg_4EC_2, arg_4EC_3, rectangle, Helpers.NearSF);
                            Graphics arg_52D_0 = g;
                            string arg_52D_1 = this.Text;
                            Font arg_52D_2 = this.Font;
                            Brush arg_52D_3 = new SolidBrush(this.InfoText);
                            rectangle = new Rectangle(48, 12, this.W, this.H);
                            arg_52D_0.DrawString(arg_52D_1, arg_52D_2, arg_52D_3, rectangle, Helpers.NearSF);
                            Graphics arg_564_0 = g;
                            Brush arg_564_1 = new SolidBrush(Color.FromArgb(35, Color.Black));
                            rectangle = new Rectangle(this.W - 32, this.H - 29, 17, 17);
                            arg_564_0.FillEllipse(arg_564_1, rectangle);
                            Graphics arg_5B4_0 = g;
                            string arg_5B4_1 = "r";
                            Font arg_5B4_2 = new Font("Marlett", 8f);
                            Brush arg_5B4_3 = new SolidBrush(this.InfoColor);
                            rectangle = new Rectangle(this.W - 30, 17, this.W, this.H);
                            arg_5B4_0.DrawString(arg_5B4_1, arg_5B4_2, arg_5B4_3, rectangle, Helpers.NearSF);
                            MouseState state3 = this.State;
                            bool flag = state3 == MouseState.Over;
                            if (flag)
                            {
                                Graphics arg_61F_0 = g;
                                string arg_61F_1 = "r";
                                Font arg_61F_2 = new Font("Marlett", 8f);
                                Brush arg_61F_3 = new SolidBrush(Color.FromArgb(25, Color.White));
                                rectangle = new Rectangle(this.W - 30, 17, this.W, this.H);
                                arg_61F_0.DrawString(arg_61F_1, arg_61F_2, arg_61F_3, rectangle, Helpers.NearSF);
                            }
                            break;
                        }
                }
                base.OnPaint(e);
                Helpers.G.Dispose();
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
                Helpers.B.Dispose();
            }
        }
    }
    [DefaultEvent("CheckedChanged")]
    public class FlatCheckBox : Control
    {
        public delegate void CheckedChangedEventHandler(object sender);
        [Flags]
        public enum _Options
        {
            Style1 = 0,
            Style2 = 1
        }
        private static List<WeakReference> __ENCList = new List<WeakReference>();
        private int W;
        private int H;
        private MouseState State;
        private FlatCheckBox._Options O;
        private bool _Checked;
        private FlatCheckBox.CheckedChangedEventHandler CheckedChangedEvent;
        private Color _BaseColor;
        private Color _BorderColor;
        private Color _TextColor;
        public event FlatCheckBox.CheckedChangedEventHandler CheckedChanged
        {
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                this.CheckedChangedEvent = (FlatCheckBox.CheckedChangedEventHandler)Delegate.Combine(this.CheckedChangedEvent, value);
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                this.CheckedChangedEvent = (FlatCheckBox.CheckedChangedEventHandler)Delegate.Remove(this.CheckedChangedEvent, value);
            }
        }
        public bool Checked
        {
            get
            {
                return this._Checked;
            }
            set
            {
                this._Checked = value;
                this.Invalidate();
            }
        }
        [Category("Options")]
        public FlatCheckBox._Options Options
        {
            get
            {
                return this.O;
            }
            set
            {
                this.O = value;
            }
        }
        [Category("Colors")]
        public Color BaseColor
        {
            get
            {
                return this._BaseColor;
            }
            set
            {
                this._BaseColor = value;
            }
        }
        [Category("Colors")]
        public Color BorderColor
        {
            get
            {
                return this._BorderColor;
            }
            set
            {
                this._BorderColor = value;
            }
        }
        [DebuggerNonUserCode]
        private static void __ENCAddToList(object value)
        {
            List<WeakReference> _ENCList = FlatCheckBox.__ENCList;
            bool flag = false;
            checked
            {
                try
                {
                    Monitor.Enter(_ENCList, ref flag);
                    bool flag2 = FlatCheckBox.__ENCList.Count == FlatCheckBox.__ENCList.Capacity;
                    if (flag2)
                    {
                        int num = 0;
                        int arg_44_0 = 0;
                        int num2 = FlatCheckBox.__ENCList.Count - 1;
                        int num3 = arg_44_0;
                        while (true)
                        {
                            int arg_95_0 = num3;
                            int num4 = num2;
                            if (arg_95_0 > num4)
                            {
                                break;
                            }
                            WeakReference weakReference = FlatCheckBox.__ENCList[num3];
                            flag2 = weakReference.IsAlive;
                            if (flag2)
                            {
                                bool flag3 = num3 != num;
                                if (flag3)
                                {
                                    FlatCheckBox.__ENCList[num] = FlatCheckBox.__ENCList[num3];
                                }
                                num++;
                            }
                            num3++;
                        }
                        FlatCheckBox.__ENCList.RemoveRange(num, FlatCheckBox.__ENCList.Count - num);
                        FlatCheckBox.__ENCList.Capacity = FlatCheckBox.__ENCList.Count;
                    }
                    FlatCheckBox.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
                }
                finally
                {
                    bool flag3 = flag;
                    if (flag3)
                    {
                        Monitor.Exit(_ENCList);
                    }
                }
            }
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Invalidate();
        }
        protected override void OnClick(EventArgs e)
        {
            this._Checked = !this._Checked;
            FlatCheckBox.CheckedChangedEventHandler checkedChangedEvent = this.CheckedChangedEvent;
            bool flag = checkedChangedEvent != null;
            if (flag)
            {
                checkedChangedEvent(this);
            }
            base.OnClick(e);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Height = 22;
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.State = MouseState.Down;
            this.Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.State = MouseState.Over;
            this.Invalidate();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.State = MouseState.Over;
            this.Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.State = MouseState.None;
            this.Invalidate();
        }
        public FlatCheckBox()
        {
            FlatCheckBox.__ENCAddToList(this);
            this.State = MouseState.None;
            this._BaseColor = Color.FromArgb(45, 47, 49);
            this._BorderColor = Helpers._FlatColor;
            this._TextColor = Color.FromArgb(243, 243, 243);
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.BackColor = Color.FromArgb(60, 70, 73);
            this.Cursor = Cursors.Hand;
            this.Font = new Font("Segoe UI", 10f);
            Size size = new Size(112, 22);
            this.Size = size;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Helpers.B = new Bitmap(this.Width, this.Height);
            Helpers.G = Graphics.FromImage(Helpers.B);
            checked
            {
                this.W = this.Width - 1;
                this.H = this.Height - 1;
                Rectangle rect = new Rectangle(0, 2, this.Height - 5, this.Height - 5);
                Graphics g = Helpers.G;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                g.Clear(this.BackColor);
                switch (this.O)
                {
                    case FlatCheckBox._Options.Style1:
                        {
                            g.FillRectangle(new SolidBrush(this._BaseColor), rect);
                            switch (this.State)
                            {
                                case MouseState.Over:
                                    g.DrawRectangle(new Pen(this._BorderColor), rect);
                                    break;
                                case MouseState.Down:
                                    g.DrawRectangle(new Pen(this._BorderColor), rect);
                                    break;
                            }
                            bool flag = this.Checked;
                            Rectangle r;
                            if (flag)
                            {
                                Graphics arg_14B_0 = g;
                                string arg_14B_1 = "ü";
                                Font arg_14B_2 = new Font("Wingdings", 18f);
                                Brush arg_14B_3 = new SolidBrush(this._BorderColor);
                                r = new Rectangle(5, 7, this.H - 9, this.H - 9);
                                arg_14B_0.DrawString(arg_14B_1, arg_14B_2, arg_14B_3, r, Helpers.CenterSF);
                            }
                            flag = !this.Enabled;
                            if (flag)
                            {
                                g.FillRectangle(new SolidBrush(Color.FromArgb(54, 58, 61)), rect);
                                Graphics arg_1C2_0 = g;
                                string arg_1C2_1 = this.Text;
                                Font arg_1C2_2 = this.Font;
                                Brush arg_1C2_3 = new SolidBrush(Color.FromArgb(140, 142, 143));
                                r = new Rectangle(20, 2, this.W, this.H);
                                arg_1C2_0.DrawString(arg_1C2_1, arg_1C2_2, arg_1C2_3, r, Helpers.NearSF);
                            }
                            Graphics arg_204_0 = g;
                            string arg_204_1 = this.Text;
                            Font arg_204_2 = this.Font;
                            Brush arg_204_3 = new SolidBrush(this._TextColor);
                            r = new Rectangle(20, 2, this.W, this.H);
                            arg_204_0.DrawString(arg_204_1, arg_204_2, arg_204_3, r, Helpers.NearSF);
                            break;
                        }
                    case FlatCheckBox._Options.Style2:
                        {
                            g.FillRectangle(new SolidBrush(this._BaseColor), rect);
                            switch (this.State)
                            {
                                case MouseState.Over:
                                    g.DrawRectangle(new Pen(this._BorderColor), rect);
                                    g.FillRectangle(new SolidBrush(Color.FromArgb(118, 213, 170)), rect);
                                    break;
                                case MouseState.Down:
                                    g.DrawRectangle(new Pen(this._BorderColor), rect);
                                    g.FillRectangle(new SolidBrush(Color.FromArgb(118, 213, 170)), rect);
                                    break;
                            }
                            bool flag = this.Checked;
                            Rectangle r;
                            if (flag)
                            {
                                Graphics arg_2FA_0 = g;
                                string arg_2FA_1 = "ü";
                                Font arg_2FA_2 = new Font("Wingdings", 18f);
                                Brush arg_2FA_3 = new SolidBrush(this._BorderColor);
                                r = new Rectangle(5, 7, this.H - 9, this.H - 9);
                                arg_2FA_0.DrawString(arg_2FA_1, arg_2FA_2, arg_2FA_3, r, Helpers.CenterSF);
                            }
                            flag = !this.Enabled;
                            if (flag)
                            {
                                g.FillRectangle(new SolidBrush(Color.FromArgb(54, 58, 61)), rect);
                                Graphics arg_368_0 = g;
                                string arg_368_1 = this.Text;
                                Font arg_368_2 = this.Font;
                                Brush arg_368_3 = new SolidBrush(Color.FromArgb(48, 119, 91));
                                r = new Rectangle(20, 2, this.W, this.H);
                                arg_368_0.DrawString(arg_368_1, arg_368_2, arg_368_3, r, Helpers.NearSF);
                            }
                            Graphics arg_3AA_0 = g;
                            string arg_3AA_1 = this.Text;
                            Font arg_3AA_2 = this.Font;
                            Brush arg_3AA_3 = new SolidBrush(this._TextColor);
                            r = new Rectangle(20, 2, this.W, this.H);
                            arg_3AA_0.DrawString(arg_3AA_1, arg_3AA_2, arg_3AA_3, r, Helpers.NearSF);
                            break;
                        }
                }
                base.OnPaint(e);
                Helpers.G.Dispose();
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
                Helpers.B.Dispose();
            }
        }
    }
    public class FlatClose : Control
    {
        private static List<WeakReference> __ENCList = new List<WeakReference>();
        private MouseState State;
        private int x;
        private Color _BaseColor;
        private Color _TextColor;
        [Category("Colors")]
        public Color BaseColor
        {
            get
            {
                return this._BaseColor;
            }
            set
            {
                this._BaseColor = value;
            }
        }
        [Category("Colors")]
        public Color TextColor
        {
            get
            {
                return this._TextColor;
            }
            set
            {
                this._TextColor = value;
            }
        }
        [DebuggerNonUserCode]
        private static void __ENCAddToList(object value)
        {
            List<WeakReference> _ENCList = FlatClose.__ENCList;
            bool flag = false;
            checked
            {
                try
                {
                    Monitor.Enter(_ENCList, ref flag);
                    bool flag2 = FlatClose.__ENCList.Count == FlatClose.__ENCList.Capacity;
                    if (flag2)
                    {
                        int num = 0;
                        int arg_44_0 = 0;
                        int num2 = FlatClose.__ENCList.Count - 1;
                        int num3 = arg_44_0;
                        while (true)
                        {
                            int arg_95_0 = num3;
                            int num4 = num2;
                            if (arg_95_0 > num4)
                            {
                                break;
                            }
                            WeakReference weakReference = FlatClose.__ENCList[num3];
                            flag2 = weakReference.IsAlive;
                            if (flag2)
                            {
                                bool flag3 = num3 != num;
                                if (flag3)
                                {
                                    FlatClose.__ENCList[num] = FlatClose.__ENCList[num3];
                                }
                                num++;
                            }
                            num3++;
                        }
                        FlatClose.__ENCList.RemoveRange(num, FlatClose.__ENCList.Count - num);
                        FlatClose.__ENCList.Capacity = FlatClose.__ENCList.Count;
                    }
                    FlatClose.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
                }
                finally
                {
                    bool flag3 = flag;
                    if (flag3)
                    {
                        Monitor.Exit(_ENCList);
                    }
                }
            }
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.State = MouseState.Over;
            this.Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.State = MouseState.Down;
            this.Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.State = MouseState.None;
            this.Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.State = MouseState.Over;
            this.Invalidate();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            this.x = e.X;
            this.Invalidate();
        }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            //Environment.Exit(0);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Size size = new Size(18, 18);
            this.Size = size;
        }
        public FlatClose()
        {
            FlatClose.__ENCAddToList(this);
            this.State = MouseState.None;
            this._BaseColor = Color.FromArgb(168, 35, 35);
            this._TextColor = Color.FromArgb(243, 243, 243);
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.BackColor = Color.White;
            Size size = new Size(18, 18);
            this.Size = size;
            this.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.Font = new Font("Marlett", 10f);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap bitmap = new Bitmap(this.Width, this.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            Graphics graphics2 = graphics;
            graphics2.SmoothingMode = SmoothingMode.HighQuality;
            graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            graphics2.Clear(this.BackColor);
            graphics2.FillRectangle(new SolidBrush(this._BaseColor), rect);
            Graphics arg_A3_0 = graphics2;
            string arg_A3_1 = "r";
            Font arg_A3_2 = this.Font;
            Brush arg_A3_3 = new SolidBrush(this.TextColor);
            Rectangle r = new Rectangle(0, 0, this.Width, this.Height);
            arg_A3_0.DrawString(arg_A3_1, arg_A3_2, arg_A3_3, r, Helpers.CenterSF);
            switch (this.State)
            {
                case MouseState.Over:
                    graphics2.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.White)), rect);
                    break;
                case MouseState.Down:
                    graphics2.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.Black)), rect);
                    break;
            }
            base.OnPaint(e);
            graphics.Dispose();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
            bitmap.Dispose();
        }
    }
    public class FlatMax : Control
    {
        private static List<WeakReference> __ENCList = new List<WeakReference>();
        private MouseState State;
        private int x;
        private Color _BaseColor;
        private Color _TextColor;
        [Category("Colors")]
        public Color BaseColor
        {
            get
            {
                return this._BaseColor;
            }
            set
            {
                this._BaseColor = value;
            }
        }
        [Category("Colors")]
        public Color TextColor
        {
            get
            {
                return this._TextColor;
            }
            set
            {
                this._TextColor = value;
            }
        }
        [DebuggerNonUserCode]
        private static void __ENCAddToList(object value)
        {
            List<WeakReference> _ENCList = FlatMax.__ENCList;
            bool flag = false;
            checked
            {
                try
                {
                    Monitor.Enter(_ENCList, ref flag);
                    bool flag2 = FlatMax.__ENCList.Count == FlatMax.__ENCList.Capacity;
                    if (flag2)
                    {
                        int num = 0;
                        int arg_44_0 = 0;
                        int num2 = FlatMax.__ENCList.Count - 1;
                        int num3 = arg_44_0;
                        while (true)
                        {
                            int arg_95_0 = num3;
                            int num4 = num2;
                            if (arg_95_0 > num4)
                            {
                                break;
                            }
                            WeakReference weakReference = FlatMax.__ENCList[num3];
                            flag2 = weakReference.IsAlive;
                            if (flag2)
                            {
                                bool flag3 = num3 != num;
                                if (flag3)
                                {
                                    FlatMax.__ENCList[num] = FlatMax.__ENCList[num3];
                                }
                                num++;
                            }
                            num3++;
                        }
                        FlatMax.__ENCList.RemoveRange(num, FlatMax.__ENCList.Count - num);
                        FlatMax.__ENCList.Capacity = FlatMax.__ENCList.Count;
                    }
                    FlatMax.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
                }
                finally
                {
                    bool flag3 = flag;
                    if (flag3)
                    {
                        Monitor.Exit(_ENCList);
                    }
                }
            }
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.State = MouseState.Over;
            this.Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.State = MouseState.Down;
            this.Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.State = MouseState.None;
            this.Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.State = MouseState.Over;
            this.Invalidate();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            this.x = e.X;
            this.Invalidate();
        }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            switch (this.FindForm().WindowState)
            {
                case FormWindowState.Normal:
                    this.FindForm().WindowState = FormWindowState.Maximized;
                    break;
                case FormWindowState.Maximized:
                    this.FindForm().WindowState = FormWindowState.Normal;
                    break;
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Size size = new Size(18, 18);
            this.Size = size;
        }
        public FlatMax()
        {
            FlatMax.__ENCAddToList(this);
            this.State = MouseState.None;
            this._BaseColor = Color.FromArgb(45, 47, 49);
            this._TextColor = Color.FromArgb(243, 243, 243);
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.BackColor = Color.White;
            Size size = new Size(18, 18);
            this.Size = size;
            this.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.Font = new Font("Marlett", 12f);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap bitmap = new Bitmap(this.Width, this.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            Graphics graphics2 = graphics;
            graphics2.SmoothingMode = SmoothingMode.HighQuality;
            graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            graphics2.Clear(this.BackColor);
            graphics2.FillRectangle(new SolidBrush(this._BaseColor), rect);
            bool flag = this.FindForm().WindowState == FormWindowState.Maximized;
            if (flag)
            {
                Graphics arg_B7_0 = graphics2;
                string arg_B7_1 = "1";
                Font arg_B7_2 = this.Font;
                Brush arg_B7_3 = new SolidBrush(this.TextColor);
                Rectangle r = new Rectangle(1, 1, this.Width, this.Height);
                arg_B7_0.DrawString(arg_B7_1, arg_B7_2, arg_B7_3, r, Helpers.CenterSF);
            }
            else
            {
                flag = (this.FindForm().WindowState == FormWindowState.Normal);
                if (flag)
                {
                    Graphics arg_10C_0 = graphics2;
                    string arg_10C_1 = "2";
                    Font arg_10C_2 = this.Font;
                    Brush arg_10C_3 = new SolidBrush(this.TextColor);
                    Rectangle r = new Rectangle(1, 1, this.Width, this.Height);
                    arg_10C_0.DrawString(arg_10C_1, arg_10C_2, arg_10C_3, r, Helpers.CenterSF);
                }
            }
            switch (this.State)
            {
                case MouseState.Over:
                    graphics2.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.White)), rect);
                    break;
                case MouseState.Down:
                    graphics2.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.Black)), rect);
                    break;
            }
            base.OnPaint(e);
            graphics.Dispose();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
            bitmap.Dispose();
        }
    }
    public class FlatMini : Control
    {
        private static List<WeakReference> __ENCList = new List<WeakReference>();
        private MouseState State;
        private int x;
        private Color _BaseColor;
        private Color _TextColor;
        [Category("Colors")]
        public Color BaseColor
        {
            get
            {
                return this._BaseColor;
            }
            set
            {
                this._BaseColor = value;
            }
        }
        [Category("Colors")]
        public Color TextColor
        {
            get
            {
                return this._TextColor;
            }
            set
            {
                this._TextColor = value;
            }
        }
        [DebuggerNonUserCode]
        private static void __ENCAddToList(object value)
        {
            List<WeakReference> _ENCList = FlatMini.__ENCList;
            bool flag = false;
            checked
            {
                try
                {
                    Monitor.Enter(_ENCList, ref flag);
                    bool flag2 = FlatMini.__ENCList.Count == FlatMini.__ENCList.Capacity;
                    if (flag2)
                    {
                        int num = 0;
                        int arg_44_0 = 0;
                        int num2 = FlatMini.__ENCList.Count - 1;
                        int num3 = arg_44_0;
                        while (true)
                        {
                            int arg_95_0 = num3;
                            int num4 = num2;
                            if (arg_95_0 > num4)
                            {
                                break;
                            }
                            WeakReference weakReference = FlatMini.__ENCList[num3];
                            flag2 = weakReference.IsAlive;
                            if (flag2)
                            {
                                bool flag3 = num3 != num;
                                if (flag3)
                                {
                                    FlatMini.__ENCList[num] = FlatMini.__ENCList[num3];
                                }
                                num++;
                            }
                            num3++;
                        }
                        FlatMini.__ENCList.RemoveRange(num, FlatMini.__ENCList.Count - num);
                        FlatMini.__ENCList.Capacity = FlatMini.__ENCList.Count;
                    }
                    FlatMini.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
                }
                finally
                {
                    bool flag3 = flag;
                    if (flag3)
                    {
                        Monitor.Exit(_ENCList);
                    }
                }
            }
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.State = MouseState.Over;
            this.Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.State = MouseState.Down;
            this.Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.State = MouseState.None;
            this.Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.State = MouseState.Over;
            this.Invalidate();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            this.x = e.X;
            this.Invalidate();
        }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            switch (this.FindForm().WindowState)
            {
                case FormWindowState.Normal:
                    //this.FindForm().WindowState = FormWindowState.Minimized;
                    break;
                case FormWindowState.Maximized:
                    //this.FindForm().WindowState = FormWindowState.Minimized;
                    break;
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Size size = new Size(18, 18);
            this.Size = size;
        }
        public FlatMini()
        {
            FlatMini.__ENCAddToList(this);
            this.State = MouseState.None;
            this._BaseColor = Color.FromArgb(45, 47, 49);
            this._TextColor = Color.FromArgb(243, 243, 243);
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.BackColor = Color.White;
            Size size = new Size(18, 18);
            this.Size = size;
            this.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.Font = new Font("Marlett", 12f);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap bitmap = new Bitmap(this.Width, this.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            Graphics graphics2 = graphics;
            graphics2.SmoothingMode = SmoothingMode.HighQuality;
            graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            graphics2.Clear(this.BackColor);
            graphics2.FillRectangle(new SolidBrush(this._BaseColor), rect);
            Graphics arg_A3_0 = graphics2;
            string arg_A3_1 = "0";
            Font arg_A3_2 = this.Font;
            Brush arg_A3_3 = new SolidBrush(this.TextColor);
            Rectangle r = new Rectangle(2, 1, this.Width, this.Height);
            arg_A3_0.DrawString(arg_A3_1, arg_A3_2, arg_A3_3, r, Helpers.CenterSF);
            switch (this.State)
            {
                case MouseState.Over:
                    graphics2.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.White)), rect);
                    break;
                case MouseState.Down:
                    graphics2.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.Black)), rect);
                    break;
            }
            base.OnPaint(e);
            graphics.Dispose();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
            bitmap.Dispose();
        }
    }
    public class FlatNumeric : Control
    {
        private static List<WeakReference> __ENCList = new List<WeakReference>();
        private int W;
        private int H;
        private MouseState State;
        private int x;
        private int y;
        private long _Value;
        private long _Min;
        private long _Max;
        private bool Bool;
        private Color _BaseColor;
        private Color _ButtonColor;
        public long Value
        {
            get
            {
                return this._Value;
            }
            set
            {
                bool flag = value <= this._Max & value >= this._Min;
                if (flag)
                {
                    this._Value = value;
                }
                this.Invalidate();
            }
        }
        public long Maximum
        {
            get
            {
                return this._Max;
            }
            set
            {
                bool flag = value > this._Min;
                if (flag)
                {
                    this._Max = value;
                }
                flag = (this._Value > this._Max);
                if (flag)
                {
                    this._Value = this._Max;
                }
                this.Invalidate();
            }
        }
        public long Minimum
        {
            get
            {
                return this._Min;
            }
            set
            {
                bool flag = value < this._Max;
                if (flag)
                {
                    this._Min = value;
                }
                flag = (this._Value < this._Min);
                if (flag)
                {
                    this._Value = this.Minimum;
                }
                this.Invalidate();
            }
        }
        [Category("Colors")]
        public Color BaseColor
        {
            get
            {
                return this._BaseColor;
            }
            set
            {
                this._BaseColor = value;
            }
        }
        [Category("Colors")]
        public Color ButtonColor
        {
            get
            {
                return this._ButtonColor;
            }
            set
            {
                this._ButtonColor = value;
            }
        }
        [DebuggerNonUserCode]
        private static void __ENCAddToList(object value)
        {
            List<WeakReference> _ENCList = FlatNumeric.__ENCList;
            bool flag = false;
            checked
            {
                try
                {
                    Monitor.Enter(_ENCList, ref flag);
                    bool flag2 = FlatNumeric.__ENCList.Count == FlatNumeric.__ENCList.Capacity;
                    if (flag2)
                    {
                        int num = 0;
                        int arg_44_0 = 0;
                        int num2 = FlatNumeric.__ENCList.Count - 1;
                        int num3 = arg_44_0;
                        while (true)
                        {
                            int arg_95_0 = num3;
                            int num4 = num2;
                            if (arg_95_0 > num4)
                            {
                                break;
                            }
                            WeakReference weakReference = FlatNumeric.__ENCList[num3];
                            flag2 = weakReference.IsAlive;
                            if (flag2)
                            {
                                bool flag3 = num3 != num;
                                if (flag3)
                                {
                                    FlatNumeric.__ENCList[num] = FlatNumeric.__ENCList[num3];
                                }
                                num++;
                            }
                            num3++;
                        }
                        FlatNumeric.__ENCList.RemoveRange(num, FlatNumeric.__ENCList.Count - num);
                        FlatNumeric.__ENCList.Capacity = FlatNumeric.__ENCList.Count;
                    }
                    FlatNumeric.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
                }
                finally
                {
                    bool flag3 = flag;
                    if (flag3)
                    {
                        Monitor.Exit(_ENCList);
                    }
                }
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            this.x = e.Location.X;
            this.y = e.Location.Y;
            this.Invalidate();
            bool flag = e.X < checked(this.Width - 23);
            if (flag)
            {
                this.Cursor = Cursors.IBeam;
            }
            else
            {
                this.Cursor = Cursors.Hand;
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            checked
            {
                bool flag = this.x > this.Width - 21 && this.x < this.Width - 3;
                if (flag)
                {
                    bool flag2 = this.y < 15;
                    if (flag2)
                    {
                        bool flag3 = this.Value + 1L <= this._Max;
                        if (flag3)
                        {
                            this._Value += 1L;
                        }
                    }
                    else
                    {
                        bool flag3 = this.Value - 1L >= this._Min;
                        if (flag3)
                        {
                            this._Value -= 1L;
                        }
                    }
                }
                else
                {
                    this.Bool = !this.Bool;
                    this.Focus();
                }
                this.Invalidate();
            }
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            try
            {
                bool flag = this.Bool;
                if (flag)
                {
                    this._Value = Conversions.ToLong(Conversions.ToString(this._Value) + e.KeyChar.ToString());
                }
                flag = (this._Value > this._Max);
                if (flag)
                {
                    this._Value = this._Max;
                }
                this.Invalidate();
            }
            catch (Exception arg_64_0)
            {
                ProjectData.SetProjectError(arg_64_0);
                ProjectData.ClearProjectError();
            }
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            bool flag = e.KeyCode == Keys.Back;
            if (flag)
            {
                this.Value = 0L;
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Height = 30;
        }
        public FlatNumeric()
        {
            FlatNumeric.__ENCAddToList(this);
            this.State = MouseState.None;
            this._BaseColor = Color.FromArgb(45, 47, 49);
            this._ButtonColor = Helpers._FlatColor;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.Font = new Font("Segoe UI", 10f);
            this.BackColor = Color.FromArgb(60, 70, 73);
            this.ForeColor = Color.White;
            this._Min = 0L;
            this._Max = 9999999L;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Helpers.B = new Bitmap(this.Width, this.Height);
            Helpers.G = Graphics.FromImage(Helpers.B);
            this.W = this.Width;
            this.H = this.Height;
            Rectangle rect = new Rectangle(0, 0, this.W, this.H);
            Graphics g = Helpers.G;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            g.Clear(this.BackColor);
            g.FillRectangle(new SolidBrush(this._BaseColor), rect);
            Graphics arg_B9_0 = g;
            Brush arg_B9_1 = new SolidBrush(this._ButtonColor);
            checked
            {
                Rectangle rectangle = new Rectangle(this.Width - 24, 0, 24, this.H);
                arg_B9_0.FillRectangle(arg_B9_1, rectangle);
                Graphics arg_F6_0 = g;
                string arg_F6_1 = "+";
                Font arg_F6_2 = new Font("Segoe UI", 12f);
                Brush arg_F6_3 = Brushes.White;
                Point p = new Point(this.Width - 12, 8);
                arg_F6_0.DrawString(arg_F6_1, arg_F6_2, arg_F6_3, p, Helpers.CenterSF);
                Graphics arg_135_0 = g;
                string arg_135_1 = "-";
                Font arg_135_2 = new Font("Segoe UI", 10f, FontStyle.Bold);
                Brush arg_135_3 = Brushes.White;
                p = new Point(this.Width - 12, 22);
                arg_135_0.DrawString(arg_135_1, arg_135_2, arg_135_3, p, Helpers.CenterSF);
                Graphics arg_180_0 = g;
                string arg_180_1 = Conversions.ToString(this.Value);
                Font arg_180_2 = this.Font;
                Brush arg_180_3 = Brushes.White;
                rectangle = new Rectangle(5, 1, this.W, this.H);
                arg_180_0.DrawString(arg_180_1, arg_180_2, arg_180_3, rectangle, new StringFormat
                {
                    LineAlignment = StringAlignment.Center
                });
                base.OnPaint(e);
                Helpers.G.Dispose();
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
                Helpers.B.Dispose();
            }
        }
    }
    public class FlatColorPalette : Control
    {
        private static List<WeakReference> __ENCList = new List<WeakReference>();
        private int W;
        private int H;
        private Color _Red;
        private Color _Cyan;
        private Color _Blue;
        private Color _LimeGreen;
        private Color _Orange;
        private Color _Purple;
        private Color _Black;
        private Color _Gray;
        private Color _White;
        [Category("Colors")]
        public Color Red
        {
            get
            {
                return this._Red;
            }
            set
            {
                this._Red = value;
            }
        }
        [Category("Colors")]
        public Color Cyan
        {
            get
            {
                return this._Cyan;
            }
            set
            {
                this._Cyan = value;
            }
        }
        [Category("Colors")]
        public Color Blue
        {
            get
            {
                return this._Blue;
            }
            set
            {
                this._Blue = value;
            }
        }
        [Category("Colors")]
        public Color LimeGreen
        {
            get
            {
                return this._LimeGreen;
            }
            set
            {
                this._LimeGreen = value;
            }
        }
        [Category("Colors")]
        public Color Orange
        {
            get
            {
                return this._Orange;
            }
            set
            {
                this._Orange = value;
            }
        }
        [Category("Colors")]
        public Color Purple
        {
            get
            {
                return this._Purple;
            }
            set
            {
                this._Purple = value;
            }
        }
        [Category("Colors")]
        public Color Black
        {
            get
            {
                return this._Black;
            }
            set
            {
                this._Black = value;
            }
        }
        [Category("Colors")]
        public Color Gray
        {
            get
            {
                return this._Gray;
            }
            set
            {
                this._Gray = value;
            }
        }
        [Category("Colors")]
        public Color White
        {
            get
            {
                return this._White;
            }
            set
            {
                this._White = value;
            }
        }
        [DebuggerNonUserCode]
        private static void __ENCAddToList(object value)
        {
            List<WeakReference> _ENCList = FlatColorPalette.__ENCList;
            bool flag = false;
            checked
            {
                try
                {
                    Monitor.Enter(_ENCList, ref flag);
                    bool flag2 = FlatColorPalette.__ENCList.Count == FlatColorPalette.__ENCList.Capacity;
                    if (flag2)
                    {
                        int num = 0;
                        int arg_44_0 = 0;
                        int num2 = FlatColorPalette.__ENCList.Count - 1;
                        int num3 = arg_44_0;
                        while (true)
                        {
                            int arg_95_0 = num3;
                            int num4 = num2;
                            if (arg_95_0 > num4)
                            {
                                break;
                            }
                            WeakReference weakReference = FlatColorPalette.__ENCList[num3];
                            flag2 = weakReference.IsAlive;
                            if (flag2)
                            {
                                bool flag3 = num3 != num;
                                if (flag3)
                                {
                                    FlatColorPalette.__ENCList[num] = FlatColorPalette.__ENCList[num3];
                                }
                                num++;
                            }
                            num3++;
                        }
                        FlatColorPalette.__ENCList.RemoveRange(num, FlatColorPalette.__ENCList.Count - num);
                        FlatColorPalette.__ENCList.Capacity = FlatColorPalette.__ENCList.Count;
                    }
                    FlatColorPalette.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
                }
                finally
                {
                    bool flag3 = flag;
                    if (flag3)
                    {
                        Monitor.Exit(_ENCList);
                    }
                }
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Width = 180;
            this.Height = 80;
        }
        public FlatColorPalette()
        {
            FlatColorPalette.__ENCAddToList(this);
            this._Red = Color.FromArgb(220, 85, 96);
            this._Cyan = Color.FromArgb(10, 154, 157);
            this._Blue = Color.FromArgb(0, 128, 255);
            this._LimeGreen = Color.FromArgb(35, 168, 109);
            this._Orange = Color.FromArgb(253, 181, 63);
            this._Purple = Color.FromArgb(155, 88, 181);
            this._Black = Color.FromArgb(45, 47, 49);
            this._Gray = Color.FromArgb(63, 70, 73);
            this._White = Color.FromArgb(243, 243, 243);
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.BackColor = Color.FromArgb(60, 70, 73);
            Size size = new Size(160, 80);
            this.Size = size;
            this.Font = new Font("Segoe UI", 12f);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Helpers.B = new Bitmap(this.Width, this.Height);
            Helpers.G = Graphics.FromImage(Helpers.B);
            checked
            {
                this.W = this.Width - 1;
                this.H = this.Height - 1;
                Graphics g = Helpers.G;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                g.Clear(this.BackColor);
                Graphics arg_88_0 = g;
                Brush arg_88_1 = new SolidBrush(this._Red);
                Rectangle rectangle = new Rectangle(0, 0, 20, 40);
                arg_88_0.FillRectangle(arg_88_1, rectangle);
                Graphics arg_AA_0 = g;
                Brush arg_AA_1 = new SolidBrush(this._Cyan);
                rectangle = new Rectangle(20, 0, 20, 40);
                arg_AA_0.FillRectangle(arg_AA_1, rectangle);
                Graphics arg_CC_0 = g;
                Brush arg_CC_1 = new SolidBrush(this._Blue);
                rectangle = new Rectangle(40, 0, 20, 40);
                arg_CC_0.FillRectangle(arg_CC_1, rectangle);
                Graphics arg_EE_0 = g;
                Brush arg_EE_1 = new SolidBrush(this._LimeGreen);
                rectangle = new Rectangle(60, 0, 20, 40);
                arg_EE_0.FillRectangle(arg_EE_1, rectangle);
                Graphics arg_110_0 = g;
                Brush arg_110_1 = new SolidBrush(this._Orange);
                rectangle = new Rectangle(80, 0, 20, 40);
                arg_110_0.FillRectangle(arg_110_1, rectangle);
                Graphics arg_132_0 = g;
                Brush arg_132_1 = new SolidBrush(this._Purple);
                rectangle = new Rectangle(100, 0, 20, 40);
                arg_132_0.FillRectangle(arg_132_1, rectangle);
                Graphics arg_154_0 = g;
                Brush arg_154_1 = new SolidBrush(this._Black);
                rectangle = new Rectangle(120, 0, 20, 40);
                arg_154_0.FillRectangle(arg_154_1, rectangle);
                Graphics arg_179_0 = g;
                Brush arg_179_1 = new SolidBrush(this._Gray);
                rectangle = new Rectangle(140, 0, 20, 40);
                arg_179_0.FillRectangle(arg_179_1, rectangle);
                Graphics arg_19E_0 = g;
                Brush arg_19E_1 = new SolidBrush(this._White);
                rectangle = new Rectangle(160, 0, 20, 40);
                arg_19E_0.FillRectangle(arg_19E_1, rectangle);
                Graphics arg_1DD_0 = g;
                string arg_1DD_1 = "Color Palette";
                Font arg_1DD_2 = this.Font;
                Brush arg_1DD_3 = new SolidBrush(this._White);
                rectangle = new Rectangle(0, 22, this.W, this.H);
                arg_1DD_0.DrawString(arg_1DD_1, arg_1DD_2, arg_1DD_3, rectangle, Helpers.CenterSF);
                base.OnPaint(e);
                Helpers.G.Dispose();
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
                Helpers.B.Dispose();
            }
        }
    }
    public class FlatComboBox : ComboBox
    {
        private static List<WeakReference> __ENCList = new List<WeakReference>();
        private int W;
        private int H;
        private int _StartIndex;
        private int x;
        private int y;
        private MouseState State;
        private Color _BaseColor;
        private Color _BGColor;
        private Color _HoverColor;
        [Category("Colors")]
        public Color HoverColor
        {
            get
            {
                return this._HoverColor;
            }
            set
            {
                this._HoverColor = value;
            }
        }
        private int StartIndex
        {
            get
            {
                return this._StartIndex;
            }
            set
            {
                this._StartIndex = value;
                try
                {
                    base.SelectedIndex = value;
                }
                catch (Exception arg_13_0)
                {
                    ProjectData.SetProjectError(arg_13_0);
                    ProjectData.ClearProjectError();
                }
                this.Invalidate();
            }
        }
        [DebuggerNonUserCode]
        private static void __ENCAddToList(object value)
        {
            List<WeakReference> _ENCList = FlatComboBox.__ENCList;
            bool flag = false;
            checked
            {
                try
                {
                    Monitor.Enter(_ENCList, ref flag);
                    bool flag2 = FlatComboBox.__ENCList.Count == FlatComboBox.__ENCList.Capacity;
                    if (flag2)
                    {
                        int num = 0;
                        int arg_44_0 = 0;
                        int num2 = FlatComboBox.__ENCList.Count - 1;
                        int num3 = arg_44_0;
                        while (true)
                        {
                            int arg_95_0 = num3;
                            int num4 = num2;
                            if (arg_95_0 > num4)
                            {
                                break;
                            }
                            WeakReference weakReference = FlatComboBox.__ENCList[num3];
                            flag2 = weakReference.IsAlive;
                            if (flag2)
                            {
                                bool flag3 = num3 != num;
                                if (flag3)
                                {
                                    FlatComboBox.__ENCList[num] = FlatComboBox.__ENCList[num3];
                                }
                                num++;
                            }
                            num3++;
                        }
                        FlatComboBox.__ENCList.RemoveRange(num, FlatComboBox.__ENCList.Count - num);
                        FlatComboBox.__ENCList.Capacity = FlatComboBox.__ENCList.Count;
                    }
                    FlatComboBox.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
                }
                finally
                {
                    bool flag3 = flag;
                    if (flag3)
                    {
                        Monitor.Exit(_ENCList);
                    }
                }
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.State = MouseState.Down;
            this.Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.State = MouseState.Over;
            this.Invalidate();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.State = MouseState.Over;
            this.Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.State = MouseState.None;
            this.Invalidate();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            this.x = e.Location.X;
            this.y = e.Location.Y;
            this.Invalidate();
            bool flag = e.X < checked(this.Width - 41);
            if (flag)
            {
                this.Cursor = Cursors.IBeam;
            }
            else
            {
                this.Cursor = Cursors.Hand;
            }
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            this.Invalidate();
            bool flag = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            if (flag)
            {
                this.Invalidate();
            }
        }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            this.Invalidate();
        }
        public void DrawItem_(object sender, DrawItemEventArgs e)
        {
            bool flag = e.Index < 0;
            if (!flag)
            {
                e.DrawBackground();
                e.DrawFocusRectangle();
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                flag = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
                if (flag)
                {
                    e.Graphics.FillRectangle(new SolidBrush(this._HoverColor), e.Bounds);
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(this._BaseColor), e.Bounds);
                }
                Graphics arg_128_0 = e.Graphics;
                string arg_128_1 = base.GetItemText(RuntimeHelpers.GetObjectValue(base.Items[e.Index]));
                Font arg_128_2 = new Font("Segoe UI", 8f);
                Brush arg_128_3 = Brushes.White;
                Rectangle r = checked(new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height));
                arg_128_0.DrawString(arg_128_1, arg_128_2, arg_128_3, r);
                e.Graphics.Dispose();
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Height = 18;
        }
        public FlatComboBox()
        {
            base.DrawItem += new DrawItemEventHandler(this.DrawItem_);
            FlatComboBox.__ENCAddToList(this);
            this._StartIndex = 0;
            this.State = MouseState.None;
            this._BaseColor = Color.FromArgb(25, 27, 29);
            this._BGColor = Color.FromArgb(45, 47, 49);
            this._HoverColor = Color.FromArgb(35, 168, 109);
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.BackColor = Color.FromArgb(45, 45, 48);
            this.ForeColor = Color.White;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Cursor = Cursors.Hand;
            this.StartIndex = 0;
            this.ItemHeight = 18;
            this.Font = new Font("Segoe UI", 8f, FontStyle.Regular);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Helpers.B = new Bitmap(this.Width, this.Height);
            Helpers.G = Graphics.FromImage(Helpers.B);
            this.W = this.Width;
            this.H = this.Height;
            Rectangle rect = new Rectangle(0, 0, this.W, this.H);
            checked
            {
                Rectangle rect2 = new Rectangle(this.W - 40, 0, this.W, this.H);
                GraphicsPath graphicsPath = new GraphicsPath();
                GraphicsPath graphicsPath2 = new GraphicsPath();
                Graphics g = Helpers.G;
                g.Clear(Color.FromArgb(45, 45, 48));
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                g.FillRectangle(new SolidBrush(this._BGColor), rect);
                graphicsPath.Reset();
                graphicsPath.AddRectangle(rect2);
                g.SetClip(graphicsPath);
                g.FillRectangle(new SolidBrush(this._BaseColor), rect2);
                g.ResetClip();
                g.DrawLine(Pens.White, this.W - 10, 6, this.W - 30, 6);
                g.DrawLine(Pens.White, this.W - 10, 12, this.W - 30, 12);
                g.DrawLine(Pens.White, this.W - 10, 18, this.W - 30, 18);
                Graphics arg_18B_0 = g;
                string arg_18B_1 = this.Text;
                Font arg_18B_2 = this.Font;
                Brush arg_18B_3 = Brushes.White;
                Point p = new Point(4, 6);
                arg_18B_0.DrawString(arg_18B_1, arg_18B_2, arg_18B_3, p, Helpers.NearSF);
                Helpers.G.Dispose();
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
                Helpers.B.Dispose();
            }
        }
    }
    public class FlatContextMenuStrip : ContextMenuStrip
    {
        public class TColorTable : ProfessionalColorTable
        {
            private Color BackColor;
            private Color CheckedColor;
            private Color BorderColor;
            [Category("Colors")]
            public Color _BackColor
            {
                get
                {
                    return this.BackColor;
                }
                set
                {
                    this.BackColor = value;
                }
            }
            [Category("Colors")]
            public Color _CheckedColor
            {
                get
                {
                    return this.CheckedColor;
                }
                set
                {
                    this.CheckedColor = value;
                }
            }
            [Category("Colors")]
            public Color _BorderColor
            {
                get
                {
                    return this.BorderColor;
                }
                set
                {
                    this.BorderColor = value;
                }
            }
            public override Color ButtonSelectedBorder
            {
                get
                {
                    return this.BackColor;
                }
            }
            public override Color CheckBackground
            {
                get
                {
                    return this.CheckedColor;
                }
            }
            public override Color CheckPressedBackground
            {
                get
                {
                    return this.CheckedColor;
                }
            }
            public override Color CheckSelectedBackground
            {
                get
                {
                    return this.CheckedColor;
                }
            }
            public override Color ImageMarginGradientBegin
            {
                get
                {
                    return this.CheckedColor;
                }
            }
            public override Color ImageMarginGradientEnd
            {
                get
                {
                    return this.CheckedColor;
                }
            }
            public override Color ImageMarginGradientMiddle
            {
                get
                {
                    return this.CheckedColor;
                }
            }
            public override Color MenuBorder
            {
                get
                {
                    return this.BorderColor;
                }
            }
            public override Color MenuItemBorder
            {
                get
                {
                    return this.BorderColor;
                }
            }
            public override Color MenuItemSelected
            {
                get
                {
                    return this.CheckedColor;
                }
            }
            public override Color SeparatorDark
            {
                get
                {
                    return this.BorderColor;
                }
            }
            public override Color ToolStripDropDownBackground
            {
                get
                {
                    return this.BackColor;
                }
            }
            public TColorTable()
            {
                this.BackColor = Color.FromArgb(45, 47, 49);
                this.CheckedColor = Helpers._FlatColor;
                this.BorderColor = Color.FromArgb(53, 58, 60);
            }
        }
        private static List<WeakReference> __ENCList = new List<WeakReference>();
        [DebuggerNonUserCode]
        private static void __ENCAddToList(object value)
        {
            List<WeakReference> _ENCList = FlatContextMenuStrip.__ENCList;
            bool flag = false;
            checked
            {
                try
                {
                    Monitor.Enter(_ENCList, ref flag);
                    bool flag2 = FlatContextMenuStrip.__ENCList.Count == FlatContextMenuStrip.__ENCList.Capacity;
                    if (flag2)
                    {
                        int num = 0;
                        int arg_44_0 = 0;
                        int num2 = FlatContextMenuStrip.__ENCList.Count - 1;
                        int num3 = arg_44_0;
                        while (true)
                        {
                            int arg_95_0 = num3;
                            int num4 = num2;
                            if (arg_95_0 > num4)
                            {
                                break;
                            }
                            WeakReference weakReference = FlatContextMenuStrip.__ENCList[num3];
                            flag2 = weakReference.IsAlive;
                            if (flag2)
                            {
                                bool flag3 = num3 != num;
                                if (flag3)
                                {
                                    FlatContextMenuStrip.__ENCList[num] = FlatContextMenuStrip.__ENCList[num3];
                                }
                                num++;
                            }
                            num3++;
                        }
                        FlatContextMenuStrip.__ENCList.RemoveRange(num, FlatContextMenuStrip.__ENCList.Count - num);
                        FlatContextMenuStrip.__ENCList.Capacity = FlatContextMenuStrip.__ENCList.Count;
                    }
                    FlatContextMenuStrip.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
                }
                finally
                {
                    bool flag3 = flag;
                    if (flag3)
                    {
                        Monitor.Exit(_ENCList);
                    }
                }
            }
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Invalidate();
        }
        public FlatContextMenuStrip()
        {
            FlatContextMenuStrip.__ENCAddToList(this);
            this.Renderer = new ToolStripProfessionalRenderer(new FlatContextMenuStrip.TColorTable());
            this.ShowImageMargin = false;
            this.ForeColor = Color.White;
            this.Font = new Font("Segoe UI", 8f);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        }
    }
    public class FlatGroupBox : ContainerControl
    {
        private static List<WeakReference> __ENCList = new List<WeakReference>();
        private int W;
        private int H;
        private bool _ShowText;
        private Color _BaseColor;
        [Category("Colors")]
        public Color BaseColor
        {
            get
            {
                return this._BaseColor;
            }
            set
            {
                this._BaseColor = value;
            }
        }
        public bool ShowText
        {
            get
            {
                return this._ShowText;
            }
            set
            {
                this._ShowText = value;
            }
        }
        [DebuggerNonUserCode]
        private static void __ENCAddToList(object value)
        {
            List<WeakReference> _ENCList = FlatGroupBox.__ENCList;
            bool flag = false;
            checked
            {
                try
                {
                    Monitor.Enter(_ENCList, ref flag);
                    bool flag2 = FlatGroupBox.__ENCList.Count == FlatGroupBox.__ENCList.Capacity;
                    if (flag2)
                    {
                        int num = 0;
                        int arg_44_0 = 0;
                        int num2 = FlatGroupBox.__ENCList.Count - 1;
                        int num3 = arg_44_0;
                        while (true)
                        {
                            int arg_95_0 = num3;
                            int num4 = num2;
                            if (arg_95_0 > num4)
                            {
                                break;
                            }
                            WeakReference weakReference = FlatGroupBox.__ENCList[num3];
                            flag2 = weakReference.IsAlive;
                            if (flag2)
                            {
                                bool flag3 = num3 != num;
                                if (flag3)
                                {
                                    FlatGroupBox.__ENCList[num] = FlatGroupBox.__ENCList[num3];
                                }
                                num++;
                            }
                            num3++;
                        }
                        FlatGroupBox.__ENCList.RemoveRange(num, FlatGroupBox.__ENCList.Count - num);
                        FlatGroupBox.__ENCList.Capacity = FlatGroupBox.__ENCList.Count;
                    }
                    FlatGroupBox.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
                }
                finally
                {
                    bool flag3 = flag;
                    if (flag3)
                    {
                        Monitor.Exit(_ENCList);
                    }
                }
            }
        }
        public FlatGroupBox()
        {
            FlatGroupBox.__ENCAddToList(this);
            this._ShowText = true;
            this._BaseColor = Color.FromArgb(60, 70, 73);
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.BackColor = Color.Transparent;
            Size size = new Size(240, 180);
            this.Size = size;
            this.Font = new Font("Segoe ui", 10f);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Helpers.B = new Bitmap(this.Width, this.Height);
            Helpers.G = Graphics.FromImage(Helpers.B);
            checked
            {
                this.W = this.Width - 1;
                this.H = this.Height - 1;
                GraphicsPath path = new GraphicsPath();
                GraphicsPath path2 = new GraphicsPath();
                GraphicsPath path3 = new GraphicsPath();
                Rectangle rectangle = new Rectangle(8, 8, this.W - 16, this.H - 16);
                Graphics g = Helpers.G;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                g.Clear(this.BackColor);
                path = Helpers.RoundRec(rectangle, 8);
                g.FillPath(new SolidBrush(this._BaseColor), path);
                path2 = Helpers.DrawArrow(28, 2, false);
                g.FillPath(new SolidBrush(this._BaseColor), path2);
                path3 = Helpers.DrawArrow(28, 8, true);
                g.FillPath(new SolidBrush(Color.FromArgb(60, 70, 73)), path3);
                bool showText = this.ShowText;
                if (showText)
                {
                    Graphics arg_145_0 = g;
                    string arg_145_1 = this.Text;
                    Font arg_145_2 = this.Font;
                    Brush arg_145_3 = new SolidBrush(Helpers._FlatColor);
                    Rectangle r = new Rectangle(16, 16, this.W, this.H);
                    arg_145_0.DrawString(arg_145_1, arg_145_2, arg_145_3, r, Helpers.NearSF);
                }
                base.OnPaint(e);
                Helpers.G.Dispose();
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
                Helpers.B.Dispose();
            }
        }
    }
    public class FlatLabel : Label
    {
        private static List<WeakReference> __ENCList = new List<WeakReference>();
        [DebuggerNonUserCode]
        private static void __ENCAddToList(object value)
        {
            List<WeakReference> _ENCList = FlatLabel.__ENCList;
            bool flag = false;
            checked
            {
                try
                {
                    Monitor.Enter(_ENCList, ref flag);
                    bool flag2 = FlatLabel.__ENCList.Count == FlatLabel.__ENCList.Capacity;
                    if (flag2)
                    {
                        int num = 0;
                        int arg_44_0 = 0;
                        int num2 = FlatLabel.__ENCList.Count - 1;
                        int num3 = arg_44_0;
                        while (true)
                        {
                            int arg_95_0 = num3;
                            int num4 = num2;
                            if (arg_95_0 > num4)
                            {
                                break;
                            }
                            WeakReference weakReference = FlatLabel.__ENCList[num3];
                            flag2 = weakReference.IsAlive;
                            if (flag2)
                            {
                                bool flag3 = num3 != num;
                                if (flag3)
                                {
                                    FlatLabel.__ENCList[num] = FlatLabel.__ENCList[num3];
                                }
                                num++;
                            }
                            num3++;
                        }
                        FlatLabel.__ENCList.RemoveRange(num, FlatLabel.__ENCList.Count - num);
                        FlatLabel.__ENCList.Capacity = FlatLabel.__ENCList.Count;
                    }
                    FlatLabel.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
                }
                finally
                {
                    bool flag3 = flag;
                    if (flag3)
                    {
                        Monitor.Exit(_ENCList);
                    }
                }
            }
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Invalidate();
        }
        public FlatLabel()
        {
            FlatLabel.__ENCAddToList(this);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.Font = new Font("Segoe UI", 8f);
            this.ForeColor = Color.White;
            this.BackColor = Color.Transparent;
            this.Text = this.Text;
        }
    }
    public class FlatListBox : Control
    {
        private static List<WeakReference> __ENCList = new List<WeakReference>();
        [AccessedThroughProperty("ListBx")]
        private ListBox _ListBx;
        private string[] _items;
        private Color BaseColor;
        private Color _SelectedColor;
        public virtual ListBox ListBx
        {
            [DebuggerNonUserCode]
            get
            {
                return this._ListBx;
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                DrawItemEventHandler value2 = new DrawItemEventHandler(this.Drawitem);
                bool flag = this._ListBx != null;
                if (flag)
                {
                    this._ListBx.DrawItem -= value2;
                }
                this._ListBx = value;
                flag = (this._ListBx != null);
                if (flag)
                {
                    this._ListBx.DrawItem += value2;
                }
            }
        }
        [Category("Options")]
        public string[] items
        {
            get
            {
                return this._items;
            }
            set
            {
                this._items = value;
                this.ListBx.Items.Clear();
                this.ListBx.Items.AddRange(value);
                this.Invalidate();
            }
        }
        [Category("Colors")]
        public Color SelectedColor
        {
            get
            {
                return this._SelectedColor;
            }
            set
            {
                this._SelectedColor = value;
            }
        }
        public string SelectedItem
        {
            get
            {
                return Conversions.ToString(this.ListBx.SelectedItem);
            }
        }
        public int SelectedIndex
        {
            get
            {
                return this.ListBx.SelectedIndex;
            }
        }
        public int SelectedIndexSet
        {
            get
            {
                return this.ListBx.SelectedIndex;
            }
            set
            {
                this.ListBx.SelectedIndex = value;
            }
        }
        [DebuggerNonUserCode]
        private static void __ENCAddToList(object value)
        {
            List<WeakReference> _ENCList = FlatListBox.__ENCList;
            bool flag = false;
            checked
            {
                try
                {
                    Monitor.Enter(_ENCList, ref flag);
                    bool flag2 = FlatListBox.__ENCList.Count == FlatListBox.__ENCList.Capacity;
                    if (flag2)
                    {
                        int num = 0;
                        int arg_44_0 = 0;
                        int num2 = FlatListBox.__ENCList.Count - 1;
                        int num3 = arg_44_0;
                        while (true)
                        {
                            int arg_95_0 = num3;
                            int num4 = num2;
                            if (arg_95_0 > num4)
                            {
                                break;
                            }
                            WeakReference weakReference = FlatListBox.__ENCList[num3];
                            flag2 = weakReference.IsAlive;
                            if (flag2)
                            {
                                bool flag3 = num3 != num;
                                if (flag3)
                                {
                                    FlatListBox.__ENCList[num] = FlatListBox.__ENCList[num3];
                                }
                                num++;
                            }
                            num3++;
                        }
                        FlatListBox.__ENCList.RemoveRange(num, FlatListBox.__ENCList.Count - num);
                        FlatListBox.__ENCList.Capacity = FlatListBox.__ENCList.Count;
                    }
                    FlatListBox.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
                }
                finally
                {
                    bool flag3 = flag;
                    if (flag3)
                    {
                        Monitor.Exit(_ENCList);
                    }
                }
            }
        }
        public void Clear()
        {
            this.ListBx.Items.Clear();
        }
        public void ClearSelected()
        {
            checked
            {
                int num = this.ListBx.SelectedItems.Count - 1;
                while (true)
                {
                    int arg_46_0 = num;
                    int num2 = 0;
                    if (arg_46_0 < num2)
                    {
                        break;
                    }
                    this.ListBx.Items.Remove(RuntimeHelpers.GetObjectValue(this.ListBx.SelectedItems[num]));
                    num += -1;
                }
            }
        }
        public void Drawitem(object sender, DrawItemEventArgs e)
        {
            bool flag = e.Index < 0;
            checked
            {
                if (!flag)
                {
                    e.DrawBackground();
                    e.DrawFocusRectangle();
                    e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                    e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                    flag = (Strings.InStr(e.State.ToString(), "Selected,", CompareMethod.Binary) > 0);
                    if (flag)
                    {
                        Graphics arg_D2_0 = e.Graphics;
                        Brush arg_D2_1 = new SolidBrush(this._SelectedColor);
                        Rectangle bounds = e.Bounds;
                        Rectangle bounds2 = new Rectangle(bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
                        arg_D2_0.FillRectangle(arg_D2_1, bounds2);
                        Graphics arg_138_0 = e.Graphics;
                        string arg_138_1 = " " + this.ListBx.Items[e.Index].ToString();
                        Font arg_138_2 = new Font("Segoe UI", 8f);
                        Brush arg_138_3 = Brushes.White;
                        bounds = e.Bounds;
                        float arg_138_4 = (float)bounds.X;
                        bounds2 = e.Bounds;
                        arg_138_0.DrawString(arg_138_1, arg_138_2, arg_138_3, arg_138_4, (float)(bounds2.Y + 2));
                    }
                    else
                    {
                        Graphics arg_19C_0 = e.Graphics;
                        Brush arg_19C_1 = new SolidBrush(Color.FromArgb(0, 0, 0)); // ÄNDRAT HÄÄÄÄÄÄÄÄÄÄÄÄÄÄR  51, 53, 55
                        Rectangle bounds2 = e.Bounds;
                        Rectangle bounds = new Rectangle(bounds2.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
                        arg_19C_0.FillRectangle(arg_19C_1, bounds);
                        Graphics arg_202_0 = e.Graphics;
                        string arg_202_1 = " " + this.ListBx.Items[e.Index].ToString();
                        Font arg_202_2 = new Font("Segoe UI", 8f);
                        Brush arg_202_3 = Brushes.White;
                        bounds = e.Bounds;
                        float arg_202_4 = (float)bounds.X;
                        bounds2 = e.Bounds;
                        arg_202_0.DrawString(arg_202_1, arg_202_2, arg_202_3, arg_202_4, (float)(bounds2.Y + 2));
                    }
                    e.Graphics.Dispose();
                }
            }
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            bool flag = !this.Controls.Contains(this.ListBx);
            if (flag)
            {
                this.Controls.Add(this.ListBx);
            }
        }
        public void AddRange(object[] items)
        {
            this.ListBx.Items.Remove("");
            this.ListBx.Items.AddRange(items);
        }
        public void AddItem(object item)
        {
            this.ListBx.Items.Remove("");
            this.ListBx.Items.Add(RuntimeHelpers.GetObjectValue(item));
        }
        public FlatListBox()
        {
            FlatListBox.__ENCAddToList(this);
            this.ListBx = new ListBox();
            this._items = new string[]
			{
				""
			};
           
            this.BaseColor = Color.FromArgb(0, 0, 0); //ÄNDRAT HÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄR 45, 47, 49
            this._SelectedColor = Helpers._FlatColor;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.ListBx.DrawMode = DrawMode.OwnerDrawFixed;
            this.ListBx.ScrollAlwaysVisible = false;
            this.ListBx.HorizontalScrollbar = false;
            this.ListBx.BorderStyle = BorderStyle.None;
            this.ListBx.BackColor = this.BaseColor;
            this.ListBx.ForeColor = Color.White;
            Control arg_CE_0 = this.ListBx;
            Point location = new Point(3, 3);
            arg_CE_0.Location = location;
            this.ListBx.Font = new Font("Segoe UI", 8f);
            this.ListBx.ItemHeight = 20;
            this.ListBx.Items.Clear();
            this.ListBx.IntegralHeight = false;
            Size size = new Size(131, 101);
            this.Size = size;
            this.BackColor = this.BaseColor;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Helpers.B = new Bitmap(this.Width, this.Height);
            Helpers.G = Graphics.FromImage(Helpers.B);
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            Graphics g = Helpers.G;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            g.Clear(this.BackColor);
            Control arg_86_0 = this.ListBx;
            Size size = checked(new Size(this.Width - 6, this.Height - 2));
            arg_86_0.Size = size;
            g.FillRectangle(new SolidBrush(this.BaseColor), rect);
            base.OnPaint(e);
            Helpers.G.Dispose();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
            Helpers.B.Dispose();
        }
    }
    public class FlatProgressBar : Control
    {
        private static List<WeakReference> __ENCList = new List<WeakReference>();
        private int W;
        private int H;
        private int _Value;
        private int _Maximum;
        private Color _BaseColor;
        private Color _ProgressColor;
        private Color _DarkerProgress;
        [Category("Control")]
        public int Maximum
        {
            get
            {
                return this._Maximum;
            }
            set
            {
                bool flag = value < this._Value;
                if (flag)
                {
                    this._Value = value;
                }
                this._Maximum = value;
                this.Invalidate();
            }
        }
        [Category("Control")]
        public int Value
        {
            get
            {
                int value = this._Value;
                bool flag = value == 0;
                int result;
                if (flag)
                {
                    result = 0;
                }
                else
                {
                    result = this._Value;
                }
                return result;
            }
            set
            {
                int num = value;
                bool flag = num > this._Maximum;
                if (flag)
                {
                    value = this._Maximum;
                    this.Invalidate();
                }
                this._Value = value;
                this.Invalidate();
            }
        }
        [Category("Colors")]
        public Color ProgressColor
        {
            get
            {
                return this._ProgressColor;
            }
            set
            {
                this._ProgressColor = value;
            }
        }
        [Category("Colors")]
        public Color DarkerProgress
        {
            get
            {
                return this._DarkerProgress;
            }
            set
            {
                this._DarkerProgress = value;
            }
        }
        [DebuggerNonUserCode]
        private static void __ENCAddToList(object value)
        {
            List<WeakReference> _ENCList = FlatProgressBar.__ENCList;
            bool flag = false;
            checked
            {
                try
                {
                    Monitor.Enter(_ENCList, ref flag);
                    bool flag2 = FlatProgressBar.__ENCList.Count == FlatProgressBar.__ENCList.Capacity;
                    if (flag2)
                    {
                        int num = 0;
                        int arg_44_0 = 0;
                        int num2 = FlatProgressBar.__ENCList.Count - 1;
                        int num3 = arg_44_0;
                        while (true)
                        {
                            int arg_95_0 = num3;
                            int num4 = num2;
                            if (arg_95_0 > num4)
                            {
                                break;
                            }
                            WeakReference weakReference = FlatProgressBar.__ENCList[num3];
                            flag2 = weakReference.IsAlive;
                            if (flag2)
                            {
                                bool flag3 = num3 != num;
                                if (flag3)
                                {
                                    FlatProgressBar.__ENCList[num] = FlatProgressBar.__ENCList[num3];
                                }
                                num++;
                            }
                            num3++;
                        }
                        FlatProgressBar.__ENCList.RemoveRange(num, FlatProgressBar.__ENCList.Count - num);
                        FlatProgressBar.__ENCList.Capacity = FlatProgressBar.__ENCList.Count;
                    }
                    FlatProgressBar.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
                }
                finally
                {
                    bool flag3 = flag;
                    if (flag3)
                    {
                        Monitor.Exit(_ENCList);
                    }
                }
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Height = 42;
        }
        protected override void CreateHandle()
        {
            base.CreateHandle();
            this.Height = 42;
        }
        public void Increment(int Amount)
        {
            checked
            {
                this.Value += Amount;
            }
        }
        public FlatProgressBar()
        {
            FlatProgressBar.__ENCAddToList(this);
            this._Value = 0;
            this._Maximum = 100;
            this._BaseColor = Color.FromArgb(45, 47, 49);
            this._ProgressColor = Helpers._FlatColor;
            this._DarkerProgress = Color.FromArgb(23, 148, 92);
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.BackColor = Color.FromArgb(60, 70, 73);
            this.Height = 42;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Helpers.B = new Bitmap(this.Width, this.Height);
            Helpers.G = Graphics.FromImage(Helpers.B);
            checked
            {
                this.W = this.Width - 1;
                this.H = this.Height - 1;
                Rectangle rect = new Rectangle(0, 24, this.W, this.H);
                GraphicsPath graphicsPath = new GraphicsPath();
                GraphicsPath path = new GraphicsPath();
                GraphicsPath path2 = new GraphicsPath();
                Graphics g = Helpers.G;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                g.Clear(this.BackColor);
                int num = (int)Math.Round(unchecked((double)this._Value / (double)this._Maximum * (double)this.Width));
                int value = this.Value;
                bool flag = value == 0;
                if (flag)
                {
                    g.FillRectangle(new SolidBrush(this._BaseColor), rect);
                    Graphics arg_109_0 = g;
                    Brush arg_109_1 = new SolidBrush(this._ProgressColor);
                    Rectangle rectangle = new Rectangle(0, 24, num - 1, this.H - 1);
                    arg_109_0.FillRectangle(arg_109_1, rectangle);
                }
                else
                {
                    flag = (value == 100);
                    if (flag)
                    {
                        g.FillRectangle(new SolidBrush(this._BaseColor), rect);
                        Graphics arg_15B_0 = g;
                        Brush arg_15B_1 = new SolidBrush(this._ProgressColor);
                        Rectangle rectangle = new Rectangle(0, 24, num - 1, this.H - 1);
                        arg_15B_0.FillRectangle(arg_15B_1, rectangle);
                    }
                    else
                    {
                        g.FillRectangle(new SolidBrush(this._BaseColor), rect);
                        GraphicsPath arg_195_0 = graphicsPath;
                        Rectangle rectangle = new Rectangle(0, 24, num - 1, this.H - 1);
                        arg_195_0.AddRectangle(rectangle);
                        g.FillPath(new SolidBrush(this._ProgressColor), graphicsPath);
                        HatchBrush hatchBrush = new HatchBrush(HatchStyle.Plaid, this._DarkerProgress, this._ProgressColor);
                        Graphics arg_1E1_0 = g;
                        Brush arg_1E1_1 = hatchBrush;
                        rectangle = new Rectangle(0, 24, num - 1, this.H - 1);
                        arg_1E1_0.FillRectangle(arg_1E1_1, rectangle);
                        Rectangle rectangle2 = new Rectangle(num - 18, 0, 34, 16);
                        path = Helpers.RoundRec(rectangle2, 4);
                        g.FillPath(new SolidBrush(this._BaseColor), path);
                        path2 = Helpers.DrawArrow(num - 9, 16, true);
                        g.FillPath(new SolidBrush(this._BaseColor), path2);
                        Graphics arg_286_0 = g;
                        string arg_286_1 = Conversions.ToString(this.Value);
                        Font arg_286_2 = new Font("Segoe UI", 10f);
                        Brush arg_286_3 = new SolidBrush(this._ProgressColor);
                        rectangle = new Rectangle(num - 11, -2, this.W, this.H);
                        arg_286_0.DrawString(arg_286_1, arg_286_2, arg_286_3, rectangle, Helpers.NearSF);
                    }
                }
                base.OnPaint(e);
                Helpers.G.Dispose();
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
                Helpers.B.Dispose();
            }
        }
    }
    public class FlatStatusBar : Control
    {
        private static List<WeakReference> __ENCList = new List<WeakReference>();
        private int W;
        private int H;
        private bool _ShowTimeDate;
        private Color _BaseColor;
        private Color _TextColor;
        private Color _RectColor;
        [Category("Colors")]
        public Color BaseColor
        {
            get
            {
                return this._BaseColor;
            }
            set
            {
                this._BaseColor = value;
            }
        }
        [Category("Colors")]
        public Color TextColor
        {
            get
            {
                return this._TextColor;
            }
            set
            {
                this._TextColor = value;
            }
        }
        [Category("Colors")]
        public Color RectColor
        {
            get
            {
                return this._RectColor;
            }
            set
            {
                this._RectColor = value;
            }
        }
        public bool ShowTimeDate
        {
            get
            {
                return this._ShowTimeDate;
            }
            set
            {
                this._ShowTimeDate = value;
            }
        }
        [DebuggerNonUserCode]
        private static void __ENCAddToList(object value)
        {
            List<WeakReference> _ENCList = FlatStatusBar.__ENCList;
            bool flag = false;
            checked
            {
                try
                {
                    Monitor.Enter(_ENCList, ref flag);
                    bool flag2 = FlatStatusBar.__ENCList.Count == FlatStatusBar.__ENCList.Capacity;
                    if (flag2)
                    {
                        int num = 0;
                        int arg_44_0 = 0;
                        int num2 = FlatStatusBar.__ENCList.Count - 1;
                        int num3 = arg_44_0;
                        while (true)
                        {
                            int arg_95_0 = num3;
                            int num4 = num2;
                            if (arg_95_0 > num4)
                            {
                                break;
                            }
                            WeakReference weakReference = FlatStatusBar.__ENCList[num3];
                            flag2 = weakReference.IsAlive;
                            if (flag2)
                            {
                                bool flag3 = num3 != num;
                                if (flag3)
                                {
                                    FlatStatusBar.__ENCList[num] = FlatStatusBar.__ENCList[num3];
                                }
                                num++;
                            }
                            num3++;
                        }
                        FlatStatusBar.__ENCList.RemoveRange(num, FlatStatusBar.__ENCList.Count - num);
                        FlatStatusBar.__ENCList.Capacity = FlatStatusBar.__ENCList.Count;
                    }
                    FlatStatusBar.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
                }
                finally
                {
                    bool flag3 = flag;
                    if (flag3)
                    {
                        Monitor.Exit(_ENCList);
                    }
                }
            }
        }
        protected override void CreateHandle()
        {
            base.CreateHandle();
            //this.Dock = DockStyle.Bottom;
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Invalidate();
        }
        public string GetTimeDate()
        {
            return string.Concat(new string[]
			{
				Conversions.ToString(DateTime.Now.Date),
				" ",
				Conversions.ToString(DateTime.Now.Hour),
				":",
				Conversions.ToString(DateTime.Now.Minute)
			});
        }
        public FlatStatusBar()
        {
            FlatStatusBar.__ENCAddToList(this);
            this._ShowTimeDate = false;
            this._BaseColor = Color.FromArgb(45, 47, 49);
            this._TextColor = Color.White;
            this._RectColor = Helpers._FlatColor;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.Font = new Font("Segoe UI", 8f);
            this.ForeColor = Color.White;
            Size size = new Size(this.Width, 20);
            this.Size = size;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Helpers.B = new Bitmap(this.Width, this.Height);
            Helpers.G = Graphics.FromImage(Helpers.B);
            this.W = this.Width;
            this.H = this.Height;
            Rectangle rect = new Rectangle(0, 0, this.W, this.H);
            Graphics g = Helpers.G;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            g.Clear(this.BaseColor);
            g.FillRectangle(new SolidBrush(this.BaseColor), rect);
            Graphics arg_C6_0 = g;
            string arg_C6_1 = this.Text;
            Font arg_C6_2 = this.Font;
            Brush arg_C6_3 = Brushes.White;
            Rectangle rectangle = new Rectangle(10, 4, this.W, this.H);
            arg_C6_0.DrawString(arg_C6_1, arg_C6_2, arg_C6_3, rectangle, Helpers.NearSF);
            Graphics arg_E6_0 = g;
            Brush arg_E6_1 = new SolidBrush(this._RectColor);
            rectangle = new Rectangle(4, 4, 4, 14);
            arg_E6_0.FillRectangle(arg_E6_1, rectangle);
            bool showTimeDate = this.ShowTimeDate;
            if (showTimeDate)
            {
                Graphics arg_144_0 = g;
                string arg_144_1 = this.GetTimeDate();
                Font arg_144_2 = this.Font;
                Brush arg_144_3 = new SolidBrush(this._TextColor);
                rectangle = new Rectangle(-4, 2, this.W, this.H);
                arg_144_0.DrawString(arg_144_1, arg_144_2, arg_144_3, rectangle, new StringFormat
                {
                    Alignment = StringAlignment.Far,
                    LineAlignment = StringAlignment.Center
                });
            }
            base.OnPaint(e);
            Helpers.G.Dispose();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
            Helpers.B.Dispose();
        }
    }
    public class FlatStickyButton : Control
    {
        private static List<WeakReference> __ENCList = new List<WeakReference>();
        private int W;
        private int H;
        private MouseState State;
        private bool _Rounded;
        private Color _BaseColor;
        private Color _TextColor;
        private Rectangle Rect
        {
            get
            {
                Rectangle result = new Rectangle(this.Left, this.Top, this.Width, this.Height);
                return result;
            }
        }
        [Category("Colors")]
        public Color BaseColor
        {
            get
            {
                return this._BaseColor;
            }
            set
            {
                this._BaseColor = value;
            }
        }
        [Category("Colors")]
        public Color TextColor
        {
            get
            {
                return this._TextColor;
            }
            set
            {
                this._TextColor = value;
            }
        }
        [Category("Options")]
        public bool Rounded
        {
            get
            {
                return this._Rounded;
            }
            set
            {
                this._Rounded = value;
            }
        }
        [DebuggerNonUserCode]
        private static void __ENCAddToList(object value)
        {
            List<WeakReference> _ENCList = FlatStickyButton.__ENCList;
            bool flag = false;
            checked
            {
                try
                {
                    Monitor.Enter(_ENCList, ref flag);
                    bool flag2 = FlatStickyButton.__ENCList.Count == FlatStickyButton.__ENCList.Capacity;
                    if (flag2)
                    {
                        int num = 0;
                        int arg_44_0 = 0;
                        int num2 = FlatStickyButton.__ENCList.Count - 1;
                        int num3 = arg_44_0;
                        while (true)
                        {
                            int arg_95_0 = num3;
                            int num4 = num2;
                            if (arg_95_0 > num4)
                            {
                                break;
                            }
                            WeakReference weakReference = FlatStickyButton.__ENCList[num3];
                            flag2 = weakReference.IsAlive;
                            if (flag2)
                            {
                                bool flag3 = num3 != num;
                                if (flag3)
                                {
                                    FlatStickyButton.__ENCList[num] = FlatStickyButton.__ENCList[num3];
                                }
                                num++;
                            }
                            num3++;
                        }
                        FlatStickyButton.__ENCList.RemoveRange(num, FlatStickyButton.__ENCList.Count - num);
                        FlatStickyButton.__ENCList.Capacity = FlatStickyButton.__ENCList.Count;
                    }
                    FlatStickyButton.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
                }
                finally
                {
                    bool flag3 = flag;
                    if (flag3)
                    {
                        Monitor.Exit(_ENCList);
                    }
                }
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.State = MouseState.Down;
            this.Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.State = MouseState.Over;
            this.Invalidate();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.State = MouseState.Over;
            this.Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.State = MouseState.None;
            this.Invalidate();
        }
        IEnumerator enumerator = null;
        private bool[] GetConnectedSides()
        {
            bool[] array = new bool[]
			{
				false,
				false,
				false,
				false
			};
            try
            {
                IEnumerator enumerator = this.Parent.Controls.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    Control control = (Control)enumerator.Current;
                    bool flag = control is FlatStickyButton;
                    if (flag)
                    {
                        bool flag2 = control == this | !this.Rect.IntersectsWith(this.Rect);
                        if (!flag2)
                        {
                            double num = checked(Math.Atan2((double)(this.Left - control.Left), (double)(this.Top - control.Top))) * 2.0 / 3.1415926535897931;
                            checked
                            {
                                flag2 = ((double)((long)Math.Round(num) / 1L) == num);
                                if (flag2)
                                {
                                    array[(int)Math.Round(unchecked(num + 1.0))] = true;
                                }
                            }
                        }
                    }
                }
            }
            finally
            {

                bool flag2 = enumerator is IDisposable;
                if (flag2)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
            return array;
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
        }
        public FlatStickyButton()
        {
            FlatStickyButton.__ENCAddToList(this);
            this.State = MouseState.None;
            this._Rounded = false;
            this._BaseColor = Helpers._FlatColor;
            this._TextColor = Color.FromArgb(243, 243, 243);
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            Size size = new Size(106, 32);
            this.Size = size;
            this.BackColor = Color.Transparent;
            this.Font = new Font("Segoe UI", 12f);
            this.Cursor = Cursors.Hand;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Helpers.B = new Bitmap(this.Width, this.Height);
            Helpers.G = Graphics.FromImage(Helpers.B);
            this.W = this.Width;
            this.H = this.Height;
            GraphicsPath path = new GraphicsPath();
            bool[] connectedSides = this.GetConnectedSides();
            GraphicsPath graphicsPath = Helpers.RoundRect(0f, 0f, (float)this.W, (float)this.H, 0.3f, !(connectedSides[2] | connectedSides[1]), !(connectedSides[1] | connectedSides[0]), !(connectedSides[3] | connectedSides[0]), !(connectedSides[3] | connectedSides[2]));
            Rectangle rectangle = new Rectangle(0, 0, this.W, this.H);
            Graphics g = Helpers.G;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            g.Clear(this.BackColor);
            switch (this.State)
            {
                case MouseState.None:
                    {
                        bool rounded = this.Rounded;
                        if (rounded)
                        {
                            path = graphicsPath;
                            g.FillPath(new SolidBrush(this._BaseColor), path);
                            g.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), rectangle, Helpers.CenterSF);
                        }
                        else
                        {
                            g.FillRectangle(new SolidBrush(this._BaseColor), rectangle);
                            g.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), rectangle, Helpers.CenterSF);
                        }
                        break;
                    }
                case MouseState.Over:
                    {
                        bool rounded = this.Rounded;
                        if (rounded)
                        {
                            path = graphicsPath;
                            g.FillPath(new SolidBrush(this._BaseColor), path);
                            g.FillPath(new SolidBrush(Color.FromArgb(20, Color.White)), path);
                            g.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), rectangle, Helpers.CenterSF);
                        }
                        else
                        {
                            g.FillRectangle(new SolidBrush(this._BaseColor), rectangle);
                            g.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.White)), rectangle);
                            g.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), rectangle, Helpers.CenterSF);
                        }
                        break;
                    }
                case MouseState.Down:
                    {
                        bool rounded = this.Rounded;
                        if (rounded)
                        {
                            path = graphicsPath;
                            g.FillPath(new SolidBrush(this._BaseColor), path);
                            g.FillPath(new SolidBrush(Color.FromArgb(20, Color.Black)), path);
                            g.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), rectangle, Helpers.CenterSF);
                        }
                        else
                        {
                            g.FillRectangle(new SolidBrush(this._BaseColor), rectangle);
                            g.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.Black)), rectangle);
                            g.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), rectangle, Helpers.CenterSF);
                        }
                        break;
                    }
            }
            base.OnPaint(e);
            Helpers.G.Dispose();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
            Helpers.B.Dispose();
        }
    }

    public class FlatTabControl : TabControl
    {
        private static List<WeakReference> __ENCList = new List<WeakReference>();
        private int W;
        private int H;
        private Color BGColor;
        private Color _BaseColor;
        private Color _ActiveColor;
        [Category("Colors")]
        public Color BaseColor
        {
            get
            {
                return this._BaseColor;
            }
            set
            {
                this._BaseColor = value;
            }
        }
        [Category("Colors")]
        public Color ActiveColor
        {
            get
            {
                return this._ActiveColor;
            }
            set
            {
                this._ActiveColor = value;
            }
        }
        [DebuggerNonUserCode]
        private static void __ENCAddToList(object value)
        {
            List<WeakReference> _ENCList = FlatTabControl.__ENCList;
            bool flag = false;
            checked
            {
                try
                {
                    Monitor.Enter(_ENCList, ref flag);
                    bool flag2 = FlatTabControl.__ENCList.Count == FlatTabControl.__ENCList.Capacity;
                    if (flag2)
                    {
                        int num = 0;
                        int arg_44_0 = 0;
                        int num2 = FlatTabControl.__ENCList.Count - 1;
                        int num3 = arg_44_0;
                        while (true)
                        {
                            int arg_95_0 = num3;
                            int num4 = num2;
                            if (arg_95_0 > num4)
                            {
                                break;
                            }
                            WeakReference weakReference = FlatTabControl.__ENCList[num3];
                            flag2 = weakReference.IsAlive;
                            if (flag2)
                            {
                                bool flag3 = num3 != num;
                                if (flag3)
                                {
                                    FlatTabControl.__ENCList[num] = FlatTabControl.__ENCList[num3];
                                }
                                num++;
                            }
                            num3++;
                        }
                        FlatTabControl.__ENCList.RemoveRange(num, FlatTabControl.__ENCList.Count - num);
                        FlatTabControl.__ENCList.Capacity = FlatTabControl.__ENCList.Count;
                    }
                    FlatTabControl.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
                }
                finally
                {
                    bool flag3 = flag;
                    if (flag3)
                    {
                        Monitor.Exit(_ENCList);
                    }
                }
            }
        }
        protected override void CreateHandle()
        {
            base.CreateHandle();
            this.Alignment = TabAlignment.Top;
        }
        public FlatTabControl()
        {
            FlatTabControl.__ENCAddToList(this);
            this.BGColor = Color.FromArgb(60, 70, 73);
            this._BaseColor = Color.FromArgb(45, 47, 49);
            this._ActiveColor = Helpers._FlatColor;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.BackColor = Color.FromArgb(60, 70, 73);
            this.Font = new Font("Segoe UI", 10f);
            this.SizeMode = TabSizeMode.Fixed;
            Size itemSize = new Size(120, 40);
            this.ItemSize = itemSize;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Helpers.B = new Bitmap(this.Width, this.Height);
            Helpers.G = Graphics.FromImage(Helpers.B);
            checked
            {
                this.W = this.Width - 1;
                this.H = this.Height - 1;
                Graphics graphics = Helpers.G;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                graphics.Clear(this._BaseColor);
                try
                {
                    this.SelectedTab.BackColor = Color.Black;
                }
                catch (Exception arg_87_0)
                {
                    ProjectData.SetProjectError(arg_87_0);
                    ProjectData.ClearProjectError();
                }
                int arg_A0_0 = 0;
                int num = this.TabCount - 1;
                int num2 = arg_A0_0;
                while (true)
                {
                    int arg_4A5_0 = num2;
                    int num3 = num;
                    if (arg_4A5_0 > num3)
                    {
                        break;
                    }
                    Point location = this.GetTabRect(num2).Location;
                    Point location2 = new Point(location.X + 2, this.GetTabRect(num2).Location.Y);
                    Point arg_110_1 = location2;
                    Size size = new Size(this.GetTabRect(num2).Width, this.GetTabRect(num2).Height);
                    Rectangle rectangle = new Rectangle(arg_110_1, size);
                    Point arg_137_1 = rectangle.Location;
                    size = new Size(rectangle.Width, rectangle.Height);
                    Rectangle rectangle2 = new Rectangle(arg_137_1, size);
                    bool flag = num2 == this.SelectedIndex;
                    if (flag)
                    {
                        graphics.FillRectangle(new SolidBrush(this._BaseColor), rectangle2);
                        graphics.FillRectangle(new SolidBrush(this._ActiveColor), rectangle2);
                        flag = (this.ImageList != null);
                        if (flag)
                        {
                            try
                            {
                                bool flag2 = this.ImageList.Images[this.TabPages[num2].ImageIndex] != null;
                                if (flag2)
                                {
                                    Graphics arg_20E_0 = graphics;
                                    Image arg_20E_1 = this.ImageList.Images[this.TabPages[num2].ImageIndex];
                                    location2 = rectangle2.Location;
                                    location = new Point(location2.X + 8, rectangle2.Location.Y + 6);
                                    arg_20E_0.DrawImage(arg_20E_1, location);
                                    graphics.DrawString("      " + this.TabPages[num2].Text, this.Font, Brushes.White, rectangle2, Helpers.CenterSF);
                                }
                                else
                                {
                                    graphics.DrawString(this.TabPages[num2].Text, this.Font, Brushes.White, rectangle2, Helpers.CenterSF);
                                }
                            }
                            catch (Exception expr_282)
                            {
                                ProjectData.SetProjectError(expr_282);
                                Exception ex = expr_282;
                                throw new Exception(ex.Message);
                            }
                        }
                        else
                        {
                            graphics.DrawString(this.TabPages[num2].Text, this.Font, Brushes.White, rectangle2, Helpers.CenterSF);
                        }
                    }
                    else
                    {
                        graphics.FillRectangle(new SolidBrush(this._BaseColor), rectangle2);
                        bool flag2 = this.ImageList != null;
                        if (flag2)
                        {
                            try
                            {
                                flag = (this.ImageList.Images[this.TabPages[num2].ImageIndex] != null);
                                if (flag)
                                {
                                    Graphics arg_382_0 = graphics;
                                    Image arg_382_1 = this.ImageList.Images[this.TabPages[num2].ImageIndex];
                                    location2 = rectangle2.Location;
                                    location = new Point(location2.X + 8, rectangle2.Location.Y + 6);
                                    arg_382_0.DrawImage(arg_382_1, location);
                                    graphics.DrawString("      " + this.TabPages[num2].Text, this.Font, new SolidBrush(Color.White), rectangle2, new StringFormat
                                    {
                                        LineAlignment = StringAlignment.Center,
                                        Alignment = StringAlignment.Center
                                    });
                                }
                                else
                                {
                                    graphics.DrawString(this.TabPages[num2].Text, this.Font, new SolidBrush(Color.White), rectangle2, new StringFormat
                                    {
                                        LineAlignment = StringAlignment.Center,
                                        Alignment = StringAlignment.Center
                                    });
                                }
                            }
                            catch (Exception expr_42C)
                            {
                                ProjectData.SetProjectError(expr_42C);
                                Exception ex2 = expr_42C;
                                throw new Exception(ex2.Message);
                            }
                        }
                        else
                        {
                            graphics.DrawString(this.TabPages[num2].Text, this.Font, new SolidBrush(Color.White), rectangle2, new StringFormat
                            {
                                LineAlignment = StringAlignment.Center,
                                Alignment = StringAlignment.Center
                            });
                        }
                    }
                    num2++;
                }
                graphics = null;
                base.OnPaint(e);
                Helpers.G.Dispose();
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
                Helpers.B.Dispose();
            }
        }
    }
    [DefaultEvent("TextChanged")]
    public class FlatTextBox : Control
    {
        private static List<WeakReference> __ENCList = new List<WeakReference>();
        private int W;
        private int H;
        private MouseState State;
        [AccessedThroughProperty("TB")]
        private TextBox _TB;
        private HorizontalAlignment _TextAlign;
        private int _MaxLength;
        private bool _ReadOnly;
        private bool _UseSystemPasswordChar;
        private bool _Multiline;
        private Color _BaseColor;
        private Color _TextColor;
        private Color _BorderColor;
        public virtual TextBox TB
        {
            [DebuggerNonUserCode]
            get
            {
                return this._TB;
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._TB = value;
            }
        }
        [Category("Options")]
        public HorizontalAlignment TextAlign
        {
            get
            {
                return this._TextAlign;
            }
            set
            {
                this._TextAlign = value;
                bool flag = this.TB != null;
                if (flag)
                {
                    this.TB.TextAlign = value;
                }
            }
        }
        [Category("Options")]
        public int MaxLength
        {
            get
            {
                return this._MaxLength;
            }
            set
            {
                this._MaxLength = value;
                bool flag = this.TB != null;
                if (flag)
                {
                    this.TB.MaxLength = value;
                }
            }
        }
        [Category("Options")]
        public bool ReadOnly
        {
            get
            {
                return this._ReadOnly;
            }
            set
            {
                this._ReadOnly = value;
                bool flag = this.TB != null;
                if (flag)
                {
                    this.TB.ReadOnly = value;
                }
            }
        }
        [Category("Options")]
        public bool UseSystemPasswordChar
        {
            get
            {
                return this._UseSystemPasswordChar;
            }
            set
            {
                this._UseSystemPasswordChar = value;
                bool flag = this.TB != null;
                if (flag)
                {
                    this.TB.UseSystemPasswordChar = value;
                }
            }
        }
        [Category("Options")]
        public bool Multiline
        {
            get
            {
                return this._Multiline;
            }
            set
            {
                this._Multiline = value;
                bool flag = this.TB != null;
                checked
                {
                    if (flag)
                    {
                        this.TB.Multiline = value;
                        if (value)
                        {
                            this.TB.Height = this.Height - 11;
                        }
                        else
                        {
                            this.Height = this.TB.Height + 11;
                        }
                    }
                }
            }
        }
        [Category("Options")]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                bool flag = this.TB != null;
                if (flag)
                {
                    this.TB.Text = value;
                }
            }
        }
        [Category("Options")]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                bool flag = this.TB != null;
                checked
                {
                    if (flag)
                    {
                        this.TB.Font = value;
                        Control arg_37_0 = this.TB;
                        Point location = new Point(3, 5);
                        arg_37_0.Location = location;
                        this.TB.Width = this.Width - 6;
                        flag = !this._Multiline;
                        if (flag)
                        {
                            this.Height = this.TB.Height + 11;
                        }
                    }
                }
            }
        }
        [Category("Colors")]
        public Color TextColor
        {
            get
            {
                return this._TextColor;
            }
            set
            {
                this._TextColor = value;
            }
        }
        public override Color ForeColor
        {
            get
            {
                return this._TextColor;
            }
            set
            {
                this._TextColor = value;
            }
        }
        [DebuggerNonUserCode]
        private static void __ENCAddToList(object value)
        {
            List<WeakReference> _ENCList = FlatTextBox.__ENCList;
            bool flag = false;
            checked
            {
                try
                {
                    Monitor.Enter(_ENCList, ref flag);
                    bool flag2 = FlatTextBox.__ENCList.Count == FlatTextBox.__ENCList.Capacity;
                    if (flag2)
                    {
                        int num = 0;
                        int arg_44_0 = 0;
                        int num2 = FlatTextBox.__ENCList.Count - 1;
                        int num3 = arg_44_0;
                        while (true)
                        {
                            int arg_95_0 = num3;
                            int num4 = num2;
                            if (arg_95_0 > num4)
                            {
                                break;
                            }
                            WeakReference weakReference = FlatTextBox.__ENCList[num3];
                            flag2 = weakReference.IsAlive;
                            if (flag2)
                            {
                                bool flag3 = num3 != num;
                                if (flag3)
                                {
                                    FlatTextBox.__ENCList[num] = FlatTextBox.__ENCList[num3];
                                }
                                num++;
                            }
                            num3++;
                        }
                        FlatTextBox.__ENCList.RemoveRange(num, FlatTextBox.__ENCList.Count - num);
                        FlatTextBox.__ENCList.Capacity = FlatTextBox.__ENCList.Count;
                    }
                    FlatTextBox.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
                }
                finally
                {
                    bool flag3 = flag;
                    if (flag3)
                    {
                        Monitor.Exit(_ENCList);
                    }
                }
            }
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            bool flag = !this.Controls.Contains(this.TB);
            if (flag)
            {
                this.Controls.Add(this.TB);
            }
        }
        private void OnBaseTextChanged(object s, EventArgs e)
        {
            this.Text = this.TB.Text;
        }
        private void OnBaseKeyDown(object s, KeyEventArgs e)
        {
            bool flag = e.Control && e.KeyCode == Keys.A;
            if (flag)
            {
                this.TB.SelectAll();
                e.SuppressKeyPress = true;
            }
            flag = (e.Control && e.KeyCode == Keys.C);
            if (flag)
            {
                this.TB.Copy();
                e.SuppressKeyPress = true;
            }
        }
        protected override void OnResize(EventArgs e)
        {
            Control arg_12_0 = this.TB;
            Point location = new Point(5, 5);
            arg_12_0.Location = location;
            checked
            {
                this.TB.Width = this.Width - 10;
                bool multiline = this._Multiline;
                if (multiline)
                {
                    this.TB.Height = this.Height - 11;
                }
                else
                {
                    this.Height = this.TB.Height + 11;
                }
                base.OnResize(e);
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.State = MouseState.Down;
            this.Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.State = MouseState.Over;
            this.TB.Focus();
            this.Invalidate();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.State = MouseState.Over;
            this.TB.Focus();
            this.Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.State = MouseState.None;
            this.Invalidate();
        }
        public FlatTextBox()
        {
            FlatTextBox.__ENCAddToList(this);
            this.State = MouseState.None;
            this._TextAlign = HorizontalAlignment.Left;
            this._MaxLength = 32767;
            this._BaseColor = Color.FromArgb(45, 47, 49);
            this._TextColor = Color.FromArgb(192, 192, 192);
            this._BorderColor = Helpers._FlatColor;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.BackColor = Color.Transparent;
            this.TB = new TextBox();
            this.TB.Font = new Font("Segoe UI", 10f);
            this.TB.Text = this.Text;
            this.TB.BackColor = this._BaseColor;
            this.TB.ForeColor = this._TextColor;
            this.TB.MaxLength = this._MaxLength;
            this.TB.Multiline = this._Multiline;
            this.TB.ReadOnly = this._ReadOnly;
            this.TB.UseSystemPasswordChar = this._UseSystemPasswordChar;
            this.TB.BorderStyle = BorderStyle.None;
            Control arg_142_0 = this.TB;
            Point location = new Point(5, 5);
            arg_142_0.Location = location;
            checked
            {
                this.TB.Width = this.Width - 10;
                this.TB.Cursor = Cursors.IBeam;
                bool multiline = this._Multiline;
                if (multiline)
                {
                    this.TB.Height = this.Height - 11;
                }
                else
                {
                    this.Height = this.TB.Height + 11;
                }
                this.TB.TextChanged += new EventHandler(this.OnBaseTextChanged);
                this.TB.KeyDown += new KeyEventHandler(this.OnBaseKeyDown);
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Helpers.B = new Bitmap(this.Width, this.Height);
            Helpers.G = Graphics.FromImage(Helpers.B);
            checked
            {
                this.W = this.Width - 1;
                this.H = this.Height - 1;
                Rectangle rect = new Rectangle(0, 0, this.W, this.H);
                Graphics g = Helpers.G;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                g.Clear(this.BackColor);
                this.TB.BackColor = this._BaseColor;
                this.TB.ForeColor = this._TextColor;
                g.FillRectangle(new SolidBrush(this._BaseColor), rect);
                base.OnPaint(e);
                Helpers.G.Dispose();
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
                Helpers.B.Dispose();
            }
        }
    }
    [DefaultEvent("CheckedChanged")]
    public class FlatToggle : Control
    {
        public delegate void CheckedChangedEventHandler(object sender);
        [Flags]
        public enum _Options
        {
            Style1 = 0,
            Style2 = 1,
            Style3 = 2,
            Style4 = 3,
            Style5 = 4
        }
        private static List<WeakReference> __ENCList = new List<WeakReference>();
        private int W;
        private int H;
        private FlatToggle._Options O;
        private bool _Checked;
        private MouseState State;
        private FlatToggle.CheckedChangedEventHandler CheckedChangedEvent;
        private Color BaseColor;
        private Color BaseColorRed;
        private Color BGColor;
        private Color ToggleColor;
        private Color TextColor;
        public event FlatToggle.CheckedChangedEventHandler CheckedChanged
        {
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                this.CheckedChangedEvent = (FlatToggle.CheckedChangedEventHandler)Delegate.Combine(this.CheckedChangedEvent, value);
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                this.CheckedChangedEvent = (FlatToggle.CheckedChangedEventHandler)Delegate.Remove(this.CheckedChangedEvent, value);
            }
        }
        [Category("Options")]
        public FlatToggle._Options Options
        {
            get
            {
                return this.O;
            }
            set
            {
                this.O = value;
            }
        }
        [Category("Options")]
        public bool Checked
        {
            get
            {
                return this._Checked;
            }
            set
            {
                this._Checked = value;
            }
        }
        [DebuggerNonUserCode]
        private static void __ENCAddToList(object value)
        {
            List<WeakReference> _ENCList = FlatToggle.__ENCList;
            bool flag = false;
            checked
            {
                try
                {
                    Monitor.Enter(_ENCList, ref flag);
                    bool flag2 = FlatToggle.__ENCList.Count == FlatToggle.__ENCList.Capacity;
                    if (flag2)
                    {
                        int num = 0;
                        int arg_44_0 = 0;
                        int num2 = FlatToggle.__ENCList.Count - 1;
                        int num3 = arg_44_0;
                        while (true)
                        {
                            int arg_95_0 = num3;
                            int num4 = num2;
                            if (arg_95_0 > num4)
                            {
                                break;
                            }
                            WeakReference weakReference = FlatToggle.__ENCList[num3];
                            flag2 = weakReference.IsAlive;
                            if (flag2)
                            {
                                bool flag3 = num3 != num;
                                if (flag3)
                                {
                                    FlatToggle.__ENCList[num] = FlatToggle.__ENCList[num3];
                                }
                                num++;
                            }
                            num3++;
                        }
                        FlatToggle.__ENCList.RemoveRange(num, FlatToggle.__ENCList.Count - num);
                        FlatToggle.__ENCList.Capacity = FlatToggle.__ENCList.Count;
                    }
                    FlatToggle.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
                }
                finally
                {
                    bool flag3 = flag;
                    if (flag3)
                    {
                        Monitor.Exit(_ENCList);
                    }
                }
            }
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Invalidate();
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Width = 76;
            this.Height = 33;
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.State = MouseState.Over;
            this.Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.State = MouseState.Down;
            this.Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.State = MouseState.None;
            this.Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.State = MouseState.Over;
            this.Invalidate();
        }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            this._Checked = !this._Checked;
            FlatToggle.CheckedChangedEventHandler checkedChangedEvent = this.CheckedChangedEvent;
            bool flag = checkedChangedEvent != null;
            if (flag)
            {
                checkedChangedEvent(this);
            }
        }
        public FlatToggle()
        {
            FlatToggle.__ENCAddToList(this);
            this._Checked = false;
            this.State = MouseState.None;
            this.BaseColor = Helpers._FlatColor;
            this.BaseColorRed = Color.FromArgb(220, 85, 96);
            this.BGColor = Color.FromArgb(84, 85, 86);
            this.ToggleColor = Color.FromArgb(45, 47, 49);
            this.TextColor = Color.FromArgb(243, 243, 243);
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.BackColor = Color.Transparent;
            Size size = new Size(44, checked(this.Height + 1));
            this.Size = size;
            this.Cursor = Cursors.Hand;
            this.Font = new Font("Segoe UI", 10f);
            size = new Size(76, 33);
            this.Size = size;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Helpers.B = new Bitmap(this.Width, this.Height);
            Helpers.G = Graphics.FromImage(Helpers.B);
            checked
            {
                this.W = this.Width - 1;
                this.H = this.Height - 1;
                GraphicsPath path = new GraphicsPath();
                GraphicsPath graphicsPath = new GraphicsPath();
                Rectangle rectangle = new Rectangle(0, 0, this.W, this.H);
                Rectangle rectangle2 = new Rectangle(this.W / 2, 0, 38, this.H);
                Graphics g = Helpers.G;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                g.Clear(this.BackColor);
                switch (this.O)
                {
                    case FlatToggle._Options.Style1:
                        {
                            path = Helpers.RoundRec(rectangle, 6);
                            graphicsPath = Helpers.RoundRec(rectangle2, 6);
                            g.FillPath(new SolidBrush(this.BGColor), path);
                            g.FillPath(new SolidBrush(this.ToggleColor), graphicsPath);
                            Graphics arg_14A_0 = g;
                            string arg_14A_1 = "OFF";
                            Font arg_14A_2 = this.Font;
                            Brush arg_14A_3 = new SolidBrush(this.BGColor);
                            Rectangle rectangle3 = new Rectangle(19, 1, this.W, this.H);
                            arg_14A_0.DrawString(arg_14A_1, arg_14A_2, arg_14A_3, rectangle3, Helpers.CenterSF);
                            bool @checked = this.Checked;
                            if (@checked)
                            {
                                path = Helpers.RoundRec(rectangle, 6);
                                rectangle3 = new Rectangle(this.W / 2, 0, 38, this.H);
                                graphicsPath = Helpers.RoundRec(rectangle3, 6);
                                g.FillPath(new SolidBrush(this.ToggleColor), path);
                                g.FillPath(new SolidBrush(this.BaseColor), graphicsPath);
                                Graphics arg_1EB_0 = g;
                                string arg_1EB_1 = "ON";
                                Font arg_1EB_2 = this.Font;
                                Brush arg_1EB_3 = new SolidBrush(this.BaseColor);
                                rectangle3 = new Rectangle(8, 7, this.W, this.H);
                                arg_1EB_0.DrawString(arg_1EB_1, arg_1EB_2, arg_1EB_3, rectangle3, Helpers.NearSF);
                            }
                            break;
                        }
                    case FlatToggle._Options.Style2:
                        {
                            path = Helpers.RoundRec(rectangle, 6);
                            rectangle2 = new Rectangle(4, 4, 36, this.H - 8);
                            graphicsPath = Helpers.RoundRec(rectangle2, 4);
                            g.FillPath(new SolidBrush(this.BaseColorRed), path);
                            g.FillPath(new SolidBrush(this.ToggleColor), graphicsPath);
                            g.DrawLine(new Pen(this.BGColor), 18, 20, 18, 12);
                            g.DrawLine(new Pen(this.BGColor), 22, 20, 22, 12);
                            g.DrawLine(new Pen(this.BGColor), 26, 20, 26, 12);
                            Graphics arg_2D9_0 = g;
                            string arg_2D9_1 = "r";
                            Font arg_2D9_2 = new Font("Marlett", 8f);
                            Brush arg_2D9_3 = new SolidBrush(this.TextColor);
                            Rectangle rectangle3 = new Rectangle(19, 2, this.Width, this.Height);
                            arg_2D9_0.DrawString(arg_2D9_1, arg_2D9_2, arg_2D9_3, rectangle3, Helpers.CenterSF);
                            bool @checked = this.Checked;
                            if (@checked)
                            {
                                path = Helpers.RoundRec(rectangle, 6);
                                rectangle2 = new Rectangle(this.W / 2 - 2, 4, 36, this.H - 8);
                                graphicsPath = Helpers.RoundRec(rectangle2, 4);
                                g.FillPath(new SolidBrush(this.BaseColor), path);
                                g.FillPath(new SolidBrush(this.ToggleColor), graphicsPath);
                                g.DrawLine(new Pen(this.BGColor), this.W / 2 + 12, 20, this.W / 2 + 12, 12);
                                g.DrawLine(new Pen(this.BGColor), this.W / 2 + 16, 20, this.W / 2 + 16, 12);
                                g.DrawLine(new Pen(this.BGColor), this.W / 2 + 20, 20, this.W / 2 + 20, 12);
                                Graphics arg_40D_0 = g;
                                string arg_40D_1 = "ü";
                                Font arg_40D_2 = new Font("Wingdings", 14f);
                                Brush arg_40D_3 = new SolidBrush(this.TextColor);
                                rectangle3 = new Rectangle(8, 7, this.Width, this.Height);
                                arg_40D_0.DrawString(arg_40D_1, arg_40D_2, arg_40D_3, rectangle3, Helpers.NearSF);
                            }
                            break;
                        }
                    case FlatToggle._Options.Style3:
                        {
                            path = Helpers.RoundRec(rectangle, 16);
                            rectangle2 = new Rectangle(this.W - 28, 4, 22, this.H - 8);
                            graphicsPath.AddEllipse(rectangle2);
                            g.FillPath(new SolidBrush(this.ToggleColor), path);
                            g.FillPath(new SolidBrush(this.BaseColorRed), graphicsPath);
                            Graphics arg_4AA_0 = g;
                            string arg_4AA_1 = "OFF";
                            Font arg_4AA_2 = this.Font;
                            Brush arg_4AA_3 = new SolidBrush(this.BaseColorRed);
                            Rectangle rectangle3 = new Rectangle(-12, 2, this.W, this.H);
                            arg_4AA_0.DrawString(arg_4AA_1, arg_4AA_2, arg_4AA_3, rectangle3, Helpers.CenterSF);
                            bool @checked = this.Checked;
                            if (@checked)
                            {
                                path = Helpers.RoundRec(rectangle, 16);
                                rectangle2 = new Rectangle(6, 4, 22, this.H - 8);
                                graphicsPath.Reset();
                                graphicsPath.AddEllipse(rectangle2);
                                g.FillPath(new SolidBrush(this.ToggleColor), path);
                                g.FillPath(new SolidBrush(this.BaseColor), graphicsPath);
                                Graphics arg_54E_0 = g;
                                string arg_54E_1 = "ON";
                                Font arg_54E_2 = this.Font;
                                Brush arg_54E_3 = new SolidBrush(this.BaseColor);
                                rectangle3 = new Rectangle(12, 2, this.W, this.H);
                                arg_54E_0.DrawString(arg_54E_1, arg_54E_2, arg_54E_3, rectangle3, Helpers.CenterSF);
                            }
                            break;
                        }
                    case FlatToggle._Options.Style4:
                        {
                            bool @checked = this.Checked;
                            if (@checked)
                            {
                            }
                            break;
                        }
                    case FlatToggle._Options.Style5:
                        {
                            bool @checked = this.Checked;
                            if (@checked)
                            {
                            }
                            break;
                        }
                }
                base.OnPaint(e);
                Helpers.G.Dispose();
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
                Helpers.B.Dispose();
            }
        }
    }
    [DefaultEvent("Scroll")]
    public class FlatTrackBar : Control
    {
        [Flags]
        public enum _Style
        {
            Slider = 0,
            Knob = 1
        }
        public delegate void ScrollEventHandler(object sender);
        private static List<WeakReference> __ENCList = new List<WeakReference>();
        private int W;
        private int H;
        private int Val;
        private bool Bool;
        private Rectangle Track;
        private Rectangle Knob;
        private FlatTrackBar._Style Style_;
        private FlatTrackBar.ScrollEventHandler ScrollEvent;
        private int _Minimum;
        private int _Maximum;
        private int _Value;
        private bool _ShowValue;
        private Color BaseColor;
        private Color _TrackColor;
        private Color SliderColor;
        private Color _HatchColor;
        public event FlatTrackBar.ScrollEventHandler Scroll
        {
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                this.ScrollEvent = (FlatTrackBar.ScrollEventHandler)Delegate.Combine(this.ScrollEvent, value);
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                this.ScrollEvent = (FlatTrackBar.ScrollEventHandler)Delegate.Remove(this.ScrollEvent, value);
            }
        }
        public FlatTrackBar._Style Style
        {
            get
            {
                return this.Style_;
            }
            set
            {
                this.Style_ = value;
            }
        }
        [Category("Colors")]
        public Color TrackColor
        {
            get
            {
                return this._TrackColor;
            }
            set
            {
                this._TrackColor = value;
            }
        }
        [Category("Colors")]
        public Color HatchColor
        {
            get
            {
                return this._HatchColor;
            }
            set
            {
                this._HatchColor = value;
            }
        }

           private int num1 = 0;
        public int Minimum
        {
            get
            {
                int num = num1;
                return num;
            }
            set
            {
                bool flag = value < 0;
                if (flag)
                {
                }
                this._Minimum = value;
                flag = (value > this._Value);
                if (flag)
                {
                    this._Value = value;
                }
                flag = (value > this._Maximum);
                if (flag)
                {
                    this._Maximum = value;
                }
                this.Invalidate();
            }
        }
        public int Maximum
        {
            get
            {
                return this._Maximum;
            }
            set
            {
                bool flag = value < 0;
                if (flag)
                {
                }
                this._Maximum = value;
                flag = (value < this._Value);
                if (flag)
                {
                    this._Value = value;
                }
                flag = (value < this._Minimum);
                if (flag)
                {
                    this._Minimum = value;
                }
                this.Invalidate();
            }
        }
        public int Value
        {
            get
            {
                return this._Value;
            }
            set
            {
                bool flag = value == this._Value;
                if (!flag)
                {
                    flag = (value > this._Maximum || value < this._Minimum);
                    if (flag)
                    {
                    }
                    this._Value = value;
                    this.Invalidate();
                    FlatTrackBar.ScrollEventHandler scrollEvent = this.ScrollEvent;
                    flag = (scrollEvent != null);
                    if (flag)
                    {
                        scrollEvent(this);
                    }
                }
            }
        }
        public bool ShowValue
        {
            get
            {
                return this._ShowValue;
            }
            set
            {
                this._ShowValue = value;
            }
        }
        [DebuggerNonUserCode]
        private static void __ENCAddToList(object value)
        {
            List<WeakReference> _ENCList = FlatTrackBar.__ENCList;
            bool flag = false;
            checked
            {
                try
                {
                    Monitor.Enter(_ENCList, ref flag);
                    bool flag2 = FlatTrackBar.__ENCList.Count == FlatTrackBar.__ENCList.Capacity;
                    if (flag2)
                    {
                        int num = 0;
                        int arg_44_0 = 0;
                        int num2 = FlatTrackBar.__ENCList.Count - 1;
                        int num3 = arg_44_0;
                        while (true)
                        {
                            int arg_95_0 = num3;
                            int num4 = num2;
                            if (arg_95_0 > num4)
                            {
                                break;
                            }
                            WeakReference weakReference = FlatTrackBar.__ENCList[num3];
                            flag2 = weakReference.IsAlive;
                            if (flag2)
                            {
                                bool flag3 = num3 != num;
                                if (flag3)
                                {
                                    FlatTrackBar.__ENCList[num] = FlatTrackBar.__ENCList[num3];
                                }
                                num++;
                            }
                            num3++;
                        }
                        FlatTrackBar.__ENCList.RemoveRange(num, FlatTrackBar.__ENCList.Count - num);
                        FlatTrackBar.__ENCList.Capacity = FlatTrackBar.__ENCList.Count;
                    }
                    FlatTrackBar.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
                }
                finally
                {
                    bool flag3 = flag;
                    if (flag3)
                    {
                        Monitor.Exit(_ENCList);
                    }
                }
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            bool flag = e.Button == MouseButtons.Left;
            if (flag)
            {
                this.Val = checked((int)Math.Round(unchecked(checked((double)(this._Value - this._Minimum) / (double)(this._Maximum - this._Minimum)) * (double)checked(this.Width - 11))));
                this.Track = new Rectangle(this.Val, 0, 10, 20);
                this.Bool = this.Track.Contains(e.Location);
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            checked
            {
                bool flag = this.Bool && e.X > -1 && e.X < this.Width + 1;
                if (flag)
                {
                    this.Value = this._Minimum + (int)Math.Round(unchecked((double)checked(this._Maximum - this._Minimum) * ((double)e.X / (double)this.Width)));
                }
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.Bool = false;
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            bool flag = e.KeyCode == Keys.Subtract;
            checked
            {
                if (flag)
                {
                    bool flag2 = this.Value == 0;
                    if (!flag2)
                    {
                        this.Value--;
                    }
                }
                else
                {
                    bool flag2 = e.KeyCode == Keys.Add;
                    if (flag2)
                    {
                        flag = (this.Value == this._Maximum);
                        if (!flag)
                        {
                            this.Value++;
                        }
                    }
                }
            }
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Invalidate();
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Height = 23;
        }
        public FlatTrackBar()
        {
            FlatTrackBar.__ENCAddToList(this);
            this._Maximum = 10;
            this._ShowValue = false;
            this.BaseColor = Color.FromArgb(45, 47, 49);
            this._TrackColor = Helpers._FlatColor;
            this.SliderColor = Color.FromArgb(25, 27, 29);
            this._HatchColor = Color.FromArgb(23, 148, 92);
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.Height = 18;
            this.BackColor = Color.FromArgb(60, 70, 73);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Helpers.B = new Bitmap(this.Width, this.Height);
            Helpers.G = Graphics.FromImage(Helpers.B);
            checked
            {
                this.W = this.Width - 1;
                this.H = this.Height - 1;
                Rectangle rect = new Rectangle(1, 6, this.W - 2, 8);
                GraphicsPath graphicsPath = new GraphicsPath();
                GraphicsPath graphicsPath2 = new GraphicsPath();
                Graphics g = Helpers.G;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                g.Clear(this.BackColor);
                this.Val = (int)Math.Round(unchecked(checked((double)(this._Value - this._Minimum) / (double)(this._Maximum - this._Minimum)) * (double)checked(this.W - 10)));
                this.Track = new Rectangle(this.Val, 0, 10, 20);
                this.Knob = new Rectangle(this.Val, 4, 11, 14);
                graphicsPath.AddRectangle(rect);
                g.SetClip(graphicsPath);
                Graphics arg_124_0 = g;
                Brush arg_124_1 = new SolidBrush(this.BaseColor);
                Rectangle rectangle = new Rectangle(0, 7, this.W, 8);
                arg_124_0.FillRectangle(arg_124_1, rectangle);
                Graphics arg_15B_0 = g;
                Brush arg_15B_1 = new SolidBrush(this._TrackColor);
                rectangle = new Rectangle(0, 7, this.Track.X + this.Track.Width, 8);
                arg_15B_0.FillRectangle(arg_15B_1, rectangle);
                g.ResetClip();
                HatchBrush hatchBrush = new HatchBrush(HatchStyle.Plaid, this.HatchColor, this._TrackColor);
                Graphics arg_1A5_0 = g;
                Brush arg_1A5_1 = hatchBrush;
                rectangle = new Rectangle(-10, 7, this.Track.X + this.Track.Width, 8);
                arg_1A5_0.FillRectangle(arg_1A5_1, rectangle);
                switch (this.Style)
                {
                    case FlatTrackBar._Style.Slider:
                        graphicsPath2.AddRectangle(this.Track);
                        g.FillPath(new SolidBrush(this.SliderColor), graphicsPath2);
                        break;
                    case FlatTrackBar._Style.Knob:
                        graphicsPath2.AddEllipse(this.Knob);
                        g.FillPath(new SolidBrush(this.SliderColor), graphicsPath2);
                        break;
                }
                bool showValue = this.ShowValue;
                if (showValue)
                {
                    Graphics arg_271_0 = g;
                    string arg_271_1 = Conversions.ToString(this.Value);
                    Font arg_271_2 = new Font("Segoe UI", 8f);
                    Brush arg_271_3 = Brushes.White;
                    rectangle = new Rectangle(1, 6, this.W, this.H);
                    arg_271_0.DrawString(arg_271_1, arg_271_2, arg_271_3, rectangle, new StringFormat
                    {
                        Alignment = StringAlignment.Far,
                        LineAlignment = StringAlignment.Far
                    });
                }
                base.OnPaint(e);
                Helpers.G.Dispose();
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
                Helpers.B.Dispose();
            }
        }
    }
    public class FlatTreeView : TreeView
    {
        private static List<WeakReference> __ENCList = new List<WeakReference>();
        private TreeNodeStates State = 0;
        private Color _BaseColor;
        private Color _LineColor;
        [DebuggerNonUserCode]
        private static void __ENCAddToList(object value)
        {
            List<WeakReference> _ENCList = FlatTreeView.__ENCList;
            bool flag = false;
            checked
            {
                try
                {
                    Monitor.Enter(_ENCList, ref flag);
                    bool flag2 = FlatTreeView.__ENCList.Count == FlatTreeView.__ENCList.Capacity;
                    if (flag2)
                    {
                        int num = 0;
                        int arg_44_0 = 0;
                        int num2 = FlatTreeView.__ENCList.Count - 1;
                        int num3 = arg_44_0;
                        while (true)
                        {
                            int arg_95_0 = num3;
                            int num4 = num2;
                            if (arg_95_0 > num4)
                            {
                                break;
                            }
                            WeakReference weakReference = FlatTreeView.__ENCList[num3];
                            flag2 = weakReference.IsAlive;
                            if (flag2)
                            {
                                bool flag3 = num3 != num;
                                if (flag3)
                                {
                                    FlatTreeView.__ENCList[num] = FlatTreeView.__ENCList[num3];
                                }
                                num++;
                            }
                            num3++;
                        }
                        FlatTreeView.__ENCList.RemoveRange(num, FlatTreeView.__ENCList.Count - num);
                        FlatTreeView.__ENCList.Capacity = FlatTreeView.__ENCList.Count;
                    }
                    FlatTreeView.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
                }
                finally
                {
                    bool flag3 = flag;
                    if (flag3)
                    {
                        Monitor.Exit(_ENCList);
                    }
                }
            }
        }
        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            checked
            {
                try
                {
                    int arg_50_1 = e.Bounds.Location.X;
                    int arg_50_2 = e.Bounds.Location.Y;
                    int arg_50_3 = e.Bounds.Width;
                    Rectangle bounds = e.Bounds;
                    Rectangle rect = new Rectangle(arg_50_1, arg_50_2, arg_50_3, bounds.Height);
                    TreeNodeStates state = this.State;
                    bool flag = state == TreeNodeStates.Default;
                    if (flag)
                    {
                        e.Graphics.FillRectangle(Brushes.Red, rect);
                        Graphics arg_D7_0 = e.Graphics;
                        string arg_D7_1 = e.Node.Text;
                        Font arg_D7_2 = new Font("Segoe UI", 8f);
                        Brush arg_D7_3 = Brushes.LimeGreen;
                        bounds = new Rectangle(rect.X + 2, rect.Y + 2, rect.Width, rect.Height);
                        arg_D7_0.DrawString(arg_D7_1, arg_D7_2, arg_D7_3, bounds, Helpers.NearSF);
                        this.Invalidate();
                    }
                    else
                    {
                        flag = (state == TreeNodeStates.Checked);
                        if (flag)
                        {
                            e.Graphics.FillRectangle(Brushes.Green, rect);
                            Graphics arg_160_0 = e.Graphics;
                            string arg_160_1 = e.Node.Text;
                            Font arg_160_2 = new Font("Segoe UI", 8f);
                            Brush arg_160_3 = Brushes.Black;
                            bounds = new Rectangle(rect.X + 2, rect.Y + 2, rect.Width, rect.Height);
                            arg_160_0.DrawString(arg_160_1, arg_160_2, arg_160_3, bounds, Helpers.NearSF);
                            this.Invalidate();
                        }
                        else
                        {
                            flag = (state == TreeNodeStates.Selected);
                            if (flag)
                            {
                                e.Graphics.FillRectangle(Brushes.Green, rect);
                                Graphics arg_1E9_0 = e.Graphics;
                                string arg_1E9_1 = e.Node.Text;
                                Font arg_1E9_2 = new Font("Segoe UI", 8f);
                                Brush arg_1E9_3 = Brushes.Black;
                                bounds = new Rectangle(rect.X + 2, rect.Y + 2, rect.Width, rect.Height);
                                arg_1E9_0.DrawString(arg_1E9_1, arg_1E9_2, arg_1E9_3, bounds, Helpers.NearSF);
                                this.Invalidate();
                            }
                        }
                    }
                }
                catch (Exception expr_1F9)
                {
                    ProjectData.SetProjectError(expr_1F9);
                    Exception ex = expr_1F9;
                    Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, null);
                    ProjectData.ClearProjectError();
                }
                base.OnDrawNode(e);
            }
        }
        public FlatTreeView()
        {
            FlatTreeView.__ENCAddToList(this);
            this._BaseColor = Color.FromArgb(45, 47, 49);
            this._LineColor = Color.FromArgb(25, 27, 29);
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.BackColor = this._BaseColor;
            this.ForeColor = Color.White;
            this.LineColor = this._LineColor;
            this.DrawMode = TreeViewDrawMode.OwnerDrawAll;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Helpers.B = new Bitmap(this.Width, this.Height);
            Helpers.G = Graphics.FromImage(Helpers.B);
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            Graphics g = Helpers.G;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            g.Clear(this.BackColor);
            g.FillRectangle(new SolidBrush(this._BaseColor), rect);
            Graphics arg_E7_0 = g;
            string arg_E7_1 = this.Text;
            Font arg_E7_2 = new Font("Segoe UI", 8f);
            Brush arg_E7_3 = Brushes.Black;
            Rectangle r = checked(new Rectangle(this.Bounds.X + 2, this.Bounds.Y + 2, this.Bounds.Width, this.Bounds.Height));
            arg_E7_0.DrawString(arg_E7_1, arg_E7_2, arg_E7_3, r, Helpers.NearSF);
            base.OnPaint(e);
            Helpers.G.Dispose();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
            Helpers.B.Dispose();
        }
    }
    [StandardModule]
    public sealed class Helpers
    {
        internal static Graphics G;
        internal static Bitmap B;
        internal static Color _FlatColor = Color.FromArgb(35, 168, 109);
        internal static StringFormat NearSF = new StringFormat
        {
            Alignment = StringAlignment.Near,
            LineAlignment = StringAlignment.Near
        };
        internal static StringFormat CenterSF = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };
        public static GraphicsPath RoundRec(Rectangle Rectangle, int Curve)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            checked
            {
                int num = Curve * 2;
                GraphicsPath arg_2F_0 = graphicsPath;
                Rectangle rect = new Rectangle(Rectangle.X, Rectangle.Y, num, num);
                arg_2F_0.AddArc(rect, -180f, 90f);
                GraphicsPath arg_63_0 = graphicsPath;
                rect = new Rectangle(Rectangle.Width - num + Rectangle.X, Rectangle.Y, num, num);
                arg_63_0.AddArc(rect, -90f, 90f);
                GraphicsPath arg_A1_0 = graphicsPath;
                rect = new Rectangle(Rectangle.Width - num + Rectangle.X, Rectangle.Height - num + Rectangle.Y, num, num);
                arg_A1_0.AddArc(rect, 0f, 90f);
                GraphicsPath arg_D5_0 = graphicsPath;
                rect = new Rectangle(Rectangle.X, Rectangle.Height - num + Rectangle.Y, num, num);
                arg_D5_0.AddArc(rect, 90f, 90f);
                GraphicsPath arg_118_0 = graphicsPath;
                Point point = new Point(Rectangle.X, Rectangle.Height - num + Rectangle.Y);
                Point arg_118_1 = point;
                Point pt = new Point(Rectangle.X, Curve + Rectangle.Y);
                arg_118_0.AddLine(arg_118_1, pt);
                return graphicsPath;
            }
        }
        public static GraphicsPath RoundRect(float x, float y, float w, float h, float r = 0.3f, bool TL = true, bool TR = true, bool BR = true, bool BL = true)
        {
            float num = Math.Min(w, h) * r;
            float num2 = x + w;
            float num3 = y + h;
            GraphicsPath graphicsPath = new GraphicsPath();
            GraphicsPath graphicsPath2 = graphicsPath;
            if (TL)
            {
                graphicsPath2.AddArc(x, y, num, num, 180f, 90f);
            }
            else
            {
                graphicsPath2.AddLine(x, y, x, y);
            }
            if (TR)
            {
                graphicsPath2.AddArc(num2 - num, y, num, num, 270f, 90f);
            }
            else
            {
                graphicsPath2.AddLine(num2, y, num2, y);
            }
            if (BR)
            {
                graphicsPath2.AddArc(num2 - num, num3 - num, num, num, 0f, 90f);
            }
            else
            {
                graphicsPath2.AddLine(num2, num3, num2, num3);
            }
            if (BL)
            {
                graphicsPath2.AddArc(x, num3 - num, num, num, 90f, 90f);
            }
            else
            {
                graphicsPath2.AddLine(x, num3, x, num3);
            }
            graphicsPath2.CloseFigure();
            return graphicsPath;
        }
        public static GraphicsPath DrawArrow(int x, int y, bool flip)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            int num = 12;
            int num2 = 6;
            checked
            {
                if (flip)
                {
                    graphicsPath.AddLine(x + 1, y, x + num + 1, y);
                    graphicsPath.AddLine(x + num, y, x + num2, y + num2 - 1);
                }
                else
                {
                    graphicsPath.AddLine(x, y + num2, x + num, y + num2);
                    graphicsPath.AddLine(x + num, y + num2, x + num2, y);
                }
                graphicsPath.CloseFigure();
                return graphicsPath;
            }
        }
    }
    //[DefaultEvent("CheckedChanged")]
    #region radioButton/need fix
    /*public class FlatRadioButton : Control
    {
        public delegate void CheckedChangedEventHandler(object sender);
        [Flags]
        public enum _Options
        {
            Style1 = 0,
            Style2 = 1
        }
        private static List<WeakReference> __ENCList = new List<WeakReference>();
        private MouseState State;
        private int W;
        private int H;
        private radioButton._Options O;
        private bool _Checked;
        private radioButton.CheckedChangedEventHandler CheckedChangedEvent;
        private Color _BaseColor;
        private Color _BorderColor;
        private Color _TextColor;
        public event radioButton.CheckedChangedEventHandler CheckedChanged
        {
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                this.CheckedChangedEvent = (RadioButton.CheckedChangedEventHandler)Delegate.Combine(this.CheckedChangedEvent, value);
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                this.CheckedChangedEvent = (RadioButton.CheckedChangedEventHandler)Delegate.Remove(this.CheckedChangedEvent, value);
            }
        }
        public bool Checked
        {
            get
            {
                return this._Checked;
            }
            set
            {
                this._Checked = value;
                this.InvalidateControls();
                RadioButton.CheckedChangedEventHandler checkedChangedEvent = this.CheckedChangedEvent;
                bool flag = checkedChangedEvent != null;
                if (flag)
                {
                    checkedChangedEvent(this);
                }
                this.Invalidate();
            }
        }
        [Category("Options")]
        public RadioButton._Options Options
        {
            get
            {
                return this.O;
            }
            set
            {
                this.O = value;
            }
        }
        [DebuggerNonUserCode]
        private static void __ENCAddToList(object value)
        {
            List<WeakReference> _ENCList = RadioButton.__ENCList;
            bool flag = false;
            checked
            {
                try
                {
                    Monitor.Enter(_ENCList, ref flag);
                    bool flag2 = RadioButton.__ENCList.Count == RadioButton.__ENCList.Capacity;
                    if (flag2)
                    {
                        int num = 0;
                        int arg_44_0 = 0;
                        int num2 = RadioButton.__ENCList.Count - 1;
                        int num3 = arg_44_0;
                        while (true)
                        {
                            int arg_95_0 = num3;
                            int num4 = num2;
                            if (arg_95_0 > num4)
                            {
                                break;
                            }
                            WeakReference weakReference = RadioButton.__ENCList[num3];
                            flag2 = weakReference.IsAlive;
                            if (flag2)
                            {
                                bool flag3 = num3 != num;
                                if (flag3)
                                {
                                    RadioButton.__ENCList[num] = RadioButton.__ENCList[num3];
                                }
                                num++;
                            }
                            num3++;
                        }
                        RadioButton.__ENCList.RemoveRange(num, RadioButton.__ENCList.Count - num);
                        RadioButton.__ENCList.Capacity = RadioButton.__ENCList.Count;
                    }
                    RadioButton.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
                }
                finally
                {
                    bool flag3 = flag;
                    if (flag3)
                    {
                        Monitor.Exit(_ENCList);
                    }
                }
            }
        }
        protected override void OnClick(EventArgs e)
        {
            bool flag = !this._Checked;
            if (flag)
            {
                this.Checked = true;
            }
            base.OnClick(e);
        }
        IEnumerator enumerator;
        private void InvalidateControls()
        {
            bool flag = !this.IsHandleCreated || !this._Checked;
            if (!flag)
            {
                try
                {
                    IEnumerator enumerator = this.Parent.Controls.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        Control control = (Control)enumerator.Current;
                        flag = (control != this && control is RadioButton);
                        if (flag)
                        {
                            ((RadioButton)control).Checked = false;
                            this.Invalidate();
                        }
                    }
                }
                finally
                {

                    flag = (enumerator is IDisposable);
                    if (flag)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
            }
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.InvalidateControls();
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Height = 22;
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.State = MouseState.Down;
            this.Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.State = MouseState.Over;
            this.Invalidate();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.State = MouseState.Over;
            this.Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.State = MouseState.None;
            this.Invalidate();
        }
        public  RadioButton()
        {
            RadioButton.__ENCAddToList(this);
            this.State = MouseState.None;
            this._BaseColor = Color.FromArgb(45, 47, 49);
            this._BorderColor = Helpers._FlatColor;
            this._TextColor = Color.FromArgb(243, 243, 243);
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.Cursor = Cursors.Hand;
            Size size = new Size(100, 22);
            this.Size = size;
            this.BackColor = Color.FromArgb(60, 70, 73);
            this.Font = new Font("Segoe UI", 10f);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Helpers.B = new Bitmap(this.Width, this.Height);
            Helpers.G = Graphics.FromImage(Helpers.B);
            checked
            {
                this.W = this.Width - 1;
                this.H = this.Height - 1;
                Rectangle rect = new Rectangle(0, 2, this.Height - 5, this.Height - 5);
                Rectangle rect2 = new Rectangle(4, 6, this.H - 12, this.H - 12);
                Graphics g = Helpers.G;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                g.Clear(this.BackColor);
                switch (this.O)
                {
                    case RadioButton._Options.Style1:
                        {
                            g.FillEllipse(new SolidBrush(this._BaseColor), rect);
                            switch (this.State)
                            {
                                case MouseState.Over:
                                    g.DrawEllipse(new Pen(this._BorderColor), rect);
                                    break;
                                case MouseState.Down:
                                    g.DrawEllipse(new Pen(this._BorderColor), rect);
                                    break;
                            }
                            bool @checked = this.Checked;
                            if (@checked)
                            {
                                g.FillEllipse(new SolidBrush(this._BorderColor), rect2);
                            }
                            break;
                        }
                    case RadioButton._Options.Style2:
                        {
                            g.FillEllipse(new SolidBrush(this._BaseColor), rect);
                            switch (this.State)
                            {
                                case MouseState.Over:
                                    g.DrawEllipse(new Pen(this._BorderColor), rect);
                                    g.FillEllipse(new SolidBrush(Color.FromArgb(118, 213, 170)), rect);
                                    break;
                                case MouseState.Down:
                                    g.DrawEllipse(new Pen(this._BorderColor), rect);
                                    g.FillEllipse(new SolidBrush(Color.FromArgb(118, 213, 170)), rect);
                                    break;
                            }
                            bool @checked = this.Checked;
                            if (@checked)
                            {
                                g.FillEllipse(new SolidBrush(this._BorderColor), rect2);
                            }
                            break;
                        }
                }
                Graphics arg_22B_0 = g;
                string arg_22B_1 = this.Text;
                Font arg_22B_2 = this.Font;
                Brush arg_22B_3 = new SolidBrush(this._TextColor);
                Rectangle r = new Rectangle(20, 2, this.W, this.H);
                arg_22B_0.DrawString(arg_22B_1, arg_22B_2, arg_22B_3, r, Helpers.NearSF);
                base.OnPaint(e);
                Helpers.G.Dispose();
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
                Helpers.B.Dispose();
            }
        }
    }
    */
    #endregion
    internal struct Bloom
    {
        public string _Name;
        private Color _Value;
        public string Name
        {
            get
            {
                return this._Name;
            }
        }
        public Color Value
        {
            get
            {
                return this._Value;
            }
            set
            {
                this._Value = value;
            }
        }
        public string ValueHex
        {
            get
            {
                return "#" + this._Value.R.ToString("X2", null) + this._Value.G.ToString("X2", null) + this._Value.B.ToString("X2", null);
            }
            set
            {
                try
                {
                    this._Value = ColorTranslator.FromHtml(value);
                }
                catch (Exception arg_10_0)
                {
                    ProjectData.SetProjectError(arg_10_0);
                    ProjectData.ClearProjectError();
                }
            }
        }
        public Bloom(string name, Color value)
        {
            this = default(Bloom);
            this._Name = name;
            this._Value = value;
        }
    }
    internal enum MouseState : byte
    {
        None,
        Over,
        Down,
        Block
    }
    internal class PrecisionTimer : IDisposable
    {
        public delegate void TimerDelegate(IntPtr r1, bool r2);
        private bool _Enabled;
        private IntPtr Handle;
        private PrecisionTimer.TimerDelegate TimerCallback;
        public bool Enabled
        {
            get
            {
                return this._Enabled;
            }
        }
        [DebuggerNonUserCode]
        public PrecisionTimer()
        {
        }
        [DllImport("kernel32.dll")]
        private static extern bool CreateTimerQueueTimer(ref IntPtr handle, IntPtr queue, PrecisionTimer.TimerDelegate callback, IntPtr state, uint dueTime, uint period, uint flags);
        [DllImport("kernel32.dll")]
        private static extern bool DeleteTimerQueueTimer(IntPtr queue, IntPtr handle, IntPtr callback);
        public void Create(uint dueTime, uint period, PrecisionTimer.TimerDelegate callback)
        {
            bool flag = this._Enabled;
            if (!flag)
            {
                this.TimerCallback = callback;
                bool flag2 = PrecisionTimer.CreateTimerQueueTimer(ref this.Handle, IntPtr.Zero, this.TimerCallback, IntPtr.Zero, dueTime, period, 0u);
                flag = !flag2;
                if (flag)
                {
                    this.ThrowNewException("CreateTimerQueueTimer");
                }
                this._Enabled = flag2;
            }
        }
        public void Delete()
        {
            bool flag = !this._Enabled;
            if (!flag)
            {
                bool flag2 = PrecisionTimer.DeleteTimerQueueTimer(IntPtr.Zero, this.Handle, IntPtr.Zero);
                flag = (!flag2 && Marshal.GetLastWin32Error() != 997);
                if (flag)
                {
                    this.ThrowNewException("DeleteTimerQueueTimer");
                }
                this._Enabled = !flag2;
            }
        }
        private void ThrowNewException(string name)
        {
            throw new Exception(string.Format("{0} failed. Win32Error: {1}", name, Marshal.GetLastWin32Error()));
        }
        public void Dispose()
        {
            this.Delete();
        }
    }
    internal abstract class ThemeContainer154 : ContainerControl
    {
        protected Graphics G;
        protected Bitmap B;
        private bool DoneCreation;
        private bool HasShown;
        private Rectangle Frame;
        protected MouseState State;
        private bool WM_LMBUTTONDOWN;
        private Point GetIndexPoint;
        private bool B1;
        private bool B2;
        private bool B3;
        private bool B4;
        private int Current;
        private int Previous;
        private Message[] Messages;
        private bool _BackColor;
        private bool _SmartBounds;
        private bool _Movable;
        private bool _Sizable;
        private Color _TransparencyKey;
        private FormBorderStyle _BorderStyle;
        private FormStartPosition _StartPosition;
        private bool _NoRounding;
        private Image _Image;
        private Dictionary<string, Color> Items;
        private string _Customization;
        private bool _Transparent;
        private Size _ImageSize;
        private bool _IsParentForm;
        private int _LockWidth;
        private int _LockHeight;
        private int _Header;
        private bool _ControlMode;
        private bool _IsAnimated;
        private Rectangle OffsetReturnRectangle;
        private Size OffsetReturnSize;
        private Point OffsetReturnPoint;
        private Point CenterReturn;
        private Bitmap MeasureBitmap;
        private Graphics MeasureGraphics;
        private SolidBrush DrawPixelBrush;
        private SolidBrush DrawCornersBrush;
        private Point DrawTextPoint;
        private Size DrawTextSize;
        private Point DrawImagePoint;
        private LinearGradientBrush DrawGradientBrush;
        private Rectangle DrawGradientRectangle;
        private GraphicsPath DrawRadialPath;
        private PathGradientBrush DrawRadialBrush1;
        private LinearGradientBrush DrawRadialBrush2;
        private Rectangle DrawRadialRectangle;
        private GraphicsPath CreateRoundPath;
        private Rectangle CreateRoundRectangle;
        public override DockStyle Dock
        {
            get
            {
                return base.Dock;
            }
            set
            {
                bool flag = !this._ControlMode;
                if (!flag)
                {
                    base.Dock = value;
                }
            }
        }
        [Category("Misc")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                bool flag = value == base.BackColor;
                if (!flag)
                {
                    flag = (!this.IsHandleCreated && this._ControlMode && value == Color.Transparent);
                    if (flag)
                    {
                        this._BackColor = true;
                    }
                    else
                    {
                        base.BackColor = value;
                        flag = (this.Parent != null);
                        if (flag)
                        {
                            bool flag2 = !this._ControlMode;
                            if (flag2)
                            {
                                this.Parent.BackColor = value;
                            }
                            this.ColorHook();
                        }
                    }
                }
            }
        }
        public override Size MinimumSize
        {
            get
            {
                return base.MinimumSize;
            }
            set
            {
                base.MinimumSize = value;
                bool flag = this.Parent != null;
                if (flag)
                {
                    this.Parent.MinimumSize = value;
                }
            }
        }
        public override Size MaximumSize
        {
            get
            {
                return base.MaximumSize;
            }
            set
            {
                base.MaximumSize = value;
                bool flag = this.Parent != null;
                if (flag)
                {
                    this.Parent.MaximumSize = value;
                }
            }
        }
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                this.Invalidate();
            }
        }
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                this.Invalidate();
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ForeColor
        {
            get
            {
                return Color.Empty;
            }
            set
            {
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public override Image BackgroundImage
        {
            get
            {
                return null;
            }
            set
            {
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public override ImageLayout BackgroundImageLayout
        {
            get
            {
                return ImageLayout.None;
            }
            set
            {
            }
        }
        public bool SmartBounds
        {
            get
            {
                return this._SmartBounds;
            }
            set
            {
                this._SmartBounds = value;
            }
        }
        public bool Movable
        {
            get
            {
                return this._Movable;
            }
            set
            {
                this._Movable = value;
            }
        }
        public bool Sizable
        {
            get
            {
                return this._Sizable;
            }
            set
            {
                this._Sizable = value;
            }
        }
        public Color TransparencyKey
        {
            get
            {
                bool flag = this._IsParentForm && !this._ControlMode;
                Color transparencyKey;
                if (flag)
                {
                    transparencyKey = this.ParentForm.TransparencyKey;
                }
                else
                {
                    transparencyKey = this._TransparencyKey;
                }
                return transparencyKey;
            }
            set
            {
                bool flag = value == this._TransparencyKey;
                if (!flag)
                {
                    this._TransparencyKey = value;
                    flag = (this._IsParentForm && !this._ControlMode);
                    if (flag)
                    {
                        this.ParentForm.TransparencyKey = value;
                        this.ColorHook();
                    }
                }
            }
        }
        public FormBorderStyle BorderStyle
        {
            get
            {
                bool flag = this._IsParentForm && !this._ControlMode;
                FormBorderStyle result;
                if (flag)
                {
                    result = this.ParentForm.FormBorderStyle;
                }
                else
                {
                    result = this._BorderStyle;
                }
                return result;
            }
            set
            {
                this._BorderStyle = value;
                bool flag = this._IsParentForm && !this._ControlMode;
                if (flag)
                {
                    this.ParentForm.FormBorderStyle = value;
                    flag = (value != FormBorderStyle.None);
                    if (flag)
                    {
                        this.Movable = false;
                        this.Sizable = false;
                    }
                }
            }
        }
        public FormStartPosition StartPosition
        {
            get
            {
                bool flag = this._IsParentForm && !this._ControlMode;
                FormStartPosition startPosition;
                if (flag)
                {
                    startPosition = this.ParentForm.StartPosition;
                }
                else
                {
                    startPosition = this._StartPosition;
                }
                return startPosition;
            }
            set
            {
                this._StartPosition = value;
                bool flag = this._IsParentForm && !this._ControlMode;
                if (flag)
                {
                    this.ParentForm.StartPosition = value;
                }
            }
        }
        public bool NoRounding
        {
            get
            {
                return this._NoRounding;
            }
            set
            {
                this._NoRounding = value;
                this.Invalidate();
            }
        }
        public Image Image
        {
            get
            {
                return this._Image;
            }
            set
            {
                bool flag = value == null;
                if (flag)
                {
                    this._ImageSize = Size.Empty;
                }
                else
                {
                    this._ImageSize = value.Size;
                }
                this._Image = value;
                this.Invalidate();
            }
        }
        public Bloom[] Colors
        {
            get
            {
                List<Bloom> list = new List<Bloom>();
                Dictionary<string, Color>.Enumerator enumerator = this.Items.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    List<Bloom> arg_3F_0 = list;
                    KeyValuePair<string, Color> current = enumerator.Current;
                    string arg_37_1 = current.Key;
                    KeyValuePair<string, Color> current2 = enumerator.Current;
                    Bloom item = new Bloom(arg_37_1, current2.Value);
                    arg_3F_0.Add(item);
                }
                return list.ToArray();
            }
            set
            {
                checked
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        Bloom bloom = value[i];
                        bool flag = this.Items.ContainsKey(bloom.Name);
                        if (flag)
                        {
                            this.Items[bloom.Name] = bloom.Value;
                        }
                    }
                    this.InvalidateCustimization();
                    this.ColorHook();
                    this.Invalidate();
                }
            }
        }
        public string Customization
        {
            get
            {
                return this._Customization;
            }
            set
            {
                bool flag = Operators.CompareString(value, this._Customization, false) == 0;
                checked
                {
                    if (!flag)
                    {
                        Bloom[] colors = this.Colors;
                        try
                        {
                            byte[] value2 = Convert.FromBase64String(value);
                            int arg_30_0 = 0;
                            int num = colors.Length - 1;
                            int num2 = arg_30_0;
                            while (true)
                            {
                                int arg_59_0 = num2;
                                int num3 = num;
                                if (arg_59_0 > num3)
                                {
                                    break;
                                }
                                colors[num2].Value = Color.FromArgb(BitConverter.ToInt32(value2, num2 * 4));
                                num2++;
                            }
                        }
                        catch (Exception arg_5D_0)
                        {
                            ProjectData.SetProjectError(arg_5D_0);
                            ProjectData.ClearProjectError();
                            return;
                        }
                        this._Customization = value;
                        this.Colors = colors;
                        this.ColorHook();
                        this.Invalidate();
                    }
                }
            }
        }
        public bool Transparent
        {
            get
            {
                return this._Transparent;
            }
            set
            {
                this._Transparent = value;
                bool flag = !this.IsHandleCreated && !this._ControlMode;
                if (!flag)
                {
                    flag = (!value && this.BackColor.A != 255);
                    if (flag)
                    {
                        throw new Exception("Unable to change value to false while a transparent BackColor is in use.");
                    }
                    this.SetStyle(ControlStyles.Opaque, !value);
                    this.SetStyle(ControlStyles.SupportsTransparentBackColor, value);
                    this.InvalidateBitmap();
                    this.Invalidate();
                }
            }
        }
        protected Size ImageSize
        {
            get
            {
                return this._ImageSize;
            }
        }
        protected bool IsParentForm
        {
            get
            {
                return this._IsParentForm;
            }
        }
        protected bool IsParentMdi
        {
            get
            {
                bool flag = this.Parent == null;
                return !flag && this.Parent.Parent != null;
            }
        }
        protected int LockWidth
        {
            get
            {
                return this._LockWidth;
            }
            set
            {
                this._LockWidth = value;
                bool flag = this.LockWidth != 0 && this.IsHandleCreated;
                if (flag)
                {
                    this.Width = this.LockWidth;
                }
            }
        }
        protected int LockHeight
        {
            get
            {
                return this._LockHeight;
            }
            set
            {
                this._LockHeight = value;
                bool flag = this.LockHeight != 0 && this.IsHandleCreated;
                if (flag)
                {
                    this.Height = this.LockHeight;
                }
            }
        }
        protected int Header
        {
            get
            {
                return this._Header;
            }
            set
            {
                this._Header = value;
                bool flag = !this._ControlMode;
                if (flag)
                {
                    this.Frame = checked(new Rectangle(7, 7, this.Width - 14, value - 7));
                    this.Invalidate();
                }
            }
        }
        protected bool ControlMode
        {
            get
            {
                return this._ControlMode;
            }
            set
            {
                this._ControlMode = value;
                this.Transparent = this._Transparent;
                bool flag = this._Transparent && this._BackColor;
                if (flag)
                {
                    this.BackColor = Color.Transparent;
                }
                this.InvalidateBitmap();
                this.Invalidate();
            }
        }
        protected bool IsAnimated
        {
            get
            {
                return this._IsAnimated;
            }
            set
            {
                this._IsAnimated = value;
                this.InvalidateTimer();
            }
        }
        public ThemeContainer154()
        {
            this.Messages = new Message[9];
            this._SmartBounds = true;
            this._Movable = true;
            this._Sizable = true;
            this.Items = new Dictionary<string, Color>();
            this._Header = 24;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.Opaque | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this._ImageSize = Size.Empty;
            this.Font = new Font("Verdana", 8f);
            this.MeasureBitmap = new Bitmap(1, 1);
            this.MeasureGraphics = Graphics.FromImage(this.MeasureBitmap);
            this.DrawRadialPath = new GraphicsPath();
            this.InvalidateCustimization();
        }
        protected sealed override void OnHandleCreated(EventArgs e)
        {
            bool flag = this.DoneCreation;
            if (flag)
            {
                this.InitializeMessages();
            }
            this.InvalidateCustimization();
            this.ColorHook();
            flag = (this._LockWidth != 0);
            if (flag)
            {
                this.Width = this._LockWidth;
            }
            flag = (this._LockHeight != 0);
            if (flag)
            {
                this.Height = this._LockHeight;
            }
            flag = !this._ControlMode;
            if (flag)
            {
                base.Dock = DockStyle.Fill;
            }
            this.Transparent = this._Transparent;
            flag = (this._Transparent && this._BackColor);
            if (flag)
            {
                this.BackColor = Color.Transparent;
            }
            base.OnHandleCreated(e);
        }
        protected sealed override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            bool flag = this.Parent == null;
            if (!flag)
            {
                this._IsParentForm = (this.Parent is Form);
                flag = !this._ControlMode;
                if (flag)
                {
                    this.InitializeMessages();
                    flag = this._IsParentForm;
                    if (flag)
                    {
                        this.ParentForm.FormBorderStyle = this._BorderStyle;
                        this.ParentForm.TransparencyKey = this._TransparencyKey;
                        flag = !this.DesignMode;
                        if (flag)
                        {
                            this.ParentForm.Shown += new EventHandler(this.FormShown);
                        }
                    }
                    this.Parent.BackColor = this.BackColor;
                }
                this.OnCreation();
                this.DoneCreation = true;
                this.InvalidateTimer();
            }
        }
        private void DoAnimation(bool i)
        {
            this.OnAnimation();
            if (i)
            {
                this.Invalidate();
            }
        }
        protected sealed override void OnPaint(PaintEventArgs e)
        {
            bool flag = this.Width == 0 || this.Height == 0;
            if (!flag)
            {
                flag = (this._Transparent && this._ControlMode);
                if (flag)
                {
                    this.PaintHook();
                    e.Graphics.DrawImage(this.B, 0, 0);
                }
                else
                {
                    this.G = e.Graphics;
                    this.PaintHook();
                }
            }
        }
        protected override void OnHandleDestroyed(EventArgs e)
        {
            ThemeShare.RemoveAnimationCallback(new ThemeShare.AnimationDelegate(this.DoAnimation));
            base.OnHandleDestroyed(e);
        }
        private void FormShown(object sender, EventArgs e)
        {
            bool flag = this._ControlMode || this.HasShown;
            if (!flag)
            {
                flag = (this._StartPosition == FormStartPosition.CenterParent || this._StartPosition == FormStartPosition.CenterScreen);
                if (flag)
                {
                    Rectangle bounds = Screen.PrimaryScreen.Bounds;
                    Rectangle bounds2 = this.ParentForm.Bounds;
                    Form arg_88_0 = this.ParentForm;
                    Point location = checked(new Point(bounds.Width / 2 - bounds2.Width / 2, bounds.Height / 2 - bounds2.Width / 2));
                    arg_88_0.Location = location;
                }
                this.HasShown = true;
            }
        }
        protected sealed override void OnSizeChanged(EventArgs e)
        {
            bool flag = this._Movable && !this._ControlMode;
            if (flag)
            {
                this.Frame = checked(new Rectangle(7, 7, this.Width - 14, this._Header - 7));
            }
            this.InvalidateBitmap();
            this.Invalidate();
            base.OnSizeChanged(e);
        }
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            bool flag = this._LockWidth != 0;
            if (flag)
            {
                width = this._LockWidth;
            }
            flag = (this._LockHeight != 0);
            if (flag)
            {
                height = this._LockHeight;
            }
            base.SetBoundsCore(x, y, width, height, specified);
        }
        private void SetState(MouseState current)
        {
            this.State = current;
            this.Invalidate();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            bool flag = !this._IsParentForm || this.ParentForm.WindowState != FormWindowState.Maximized;
            if (flag)
            {
                bool flag2 = this._Sizable && !this._ControlMode;
                if (flag2)
                {
                    this.InvalidateMouse();
                }
            }
            base.OnMouseMove(e);
        }
        protected override void OnEnabledChanged(EventArgs e)
        {
            bool enabled = this.Enabled;
            if (enabled)
            {
                this.SetState(MouseState.None);
            }
            else
            {
                this.SetState(MouseState.Block);
            }
            base.OnEnabledChanged(e);
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            this.SetState(MouseState.Over);
            base.OnMouseEnter(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            this.SetState(MouseState.Over);
            base.OnMouseUp(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            this.SetState(MouseState.None);
            bool flag = this.GetChildAtPoint(this.PointToClient(Control.MousePosition)) != null;
            if (flag)
            {
                bool flag2 = this._Sizable && !this._ControlMode;
                if (flag2)
                {
                    this.Cursor = Cursors.Default;
                    this.Previous = 0;
                }
            }
            base.OnMouseLeave(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            bool flag = e.Button == MouseButtons.Left;
            if (flag)
            {
                this.SetState(MouseState.Down);
            }
            flag = ((!this._IsParentForm || this.ParentForm.WindowState != FormWindowState.Maximized) && !this._ControlMode);
            if (flag)
            {
                bool flag2 = this._Movable && this.Frame.Contains(e.Location);
                if (flag2)
                {
                    this.Capture = false;
                    this.WM_LMBUTTONDOWN = true;
                    this.DefWndProc(ref this.Messages[0]);
                }
                else
                {
                    flag2 = (this._Sizable && this.Previous != 0);
                    if (flag2)
                    {
                        this.Capture = false;
                        this.WM_LMBUTTONDOWN = true;
                        this.DefWndProc(ref this.Messages[this.Previous]);
                    }
                }
            }
            base.OnMouseDown(e);
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            bool flag = this.WM_LMBUTTONDOWN && m.Msg == 513;
            if (flag)
            {
                this.WM_LMBUTTONDOWN = false;
                this.SetState(MouseState.Over);
                flag = !this._SmartBounds;
                if (!flag)
                {
                    flag = this.IsParentMdi;
                    if (flag)
                    {
                        Rectangle bounds = new Rectangle(Point.Empty, this.Parent.Parent.Size);
                        this.CorrectBounds(bounds);
                    }
                    else
                    {
                        this.CorrectBounds(Screen.FromControl(this.Parent).WorkingArea);
                    }
                }
            }
        }
        private int GetIndex()
        {
            this.GetIndexPoint = this.PointToClient(Control.MousePosition);
            this.B1 = (this.GetIndexPoint.X < 7);
            checked
            {
                this.B2 = (this.GetIndexPoint.X > this.Width - 7);
                this.B3 = (this.GetIndexPoint.Y < 7);
                this.B4 = (this.GetIndexPoint.Y > this.Height - 7);
                bool flag = this.B1 && this.B3;
                int result;
                if (flag)
                {
                    result = 4;
                }
                else
                {
                    flag = (this.B1 && this.B4);
                    if (flag)
                    {
                        result = 7;
                    }
                    else
                    {
                        flag = (this.B2 && this.B3);
                        if (flag)
                        {
                            result = 5;
                        }
                        else
                        {
                            flag = (this.B2 && this.B4);
                            if (flag)
                            {
                                result = 8;
                            }
                            else
                            {
                                flag = this.B1;
                                if (flag)
                                {
                                    result = 1;
                                }
                                else
                                {
                                    flag = this.B2;
                                    if (flag)
                                    {
                                        result = 2;
                                    }
                                    else
                                    {
                                        flag = this.B3;
                                        if (flag)
                                        {
                                            result = 3;
                                        }
                                        else
                                        {
                                            flag = this.B4;
                                            if (flag)
                                            {
                                                result = 6;
                                            }
                                            else
                                            {
                                                result = 0;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                return result;
            }
        }
        private void InvalidateMouse()
        {
            this.Current = this.GetIndex();
            bool flag = this.Current == this.Previous;
            if (!flag)
            {
                this.Previous = this.Current;
                switch (this.Previous)
                {
                    case 0:
                        this.Cursor = Cursors.Default;
                        break;
                    case 1:
                    case 2:
                        this.Cursor = Cursors.SizeWE;
                        break;
                    case 3:
                    case 6:
                        this.Cursor = Cursors.SizeNS;
                        break;
                    case 4:
                    case 8:
                        this.Cursor = Cursors.SizeNWSE;
                        break;
                    case 5:
                    case 7:
                        this.Cursor = Cursors.SizeNESW;
                        break;
                }
            }
        }
        private void InitializeMessages()
        {
            Message[] arg_31_0_cp_0 = this.Messages;
            int arg_31_0_cp_1 = 0;
            IntPtr arg_2C_0 = this.Parent.Handle;
            int arg_2C_1 = 161;
            IntPtr wparam = new IntPtr(2);
            arg_31_0_cp_0[arg_31_0_cp_1] = Message.Create(arg_2C_0, arg_2C_1, wparam, IntPtr.Zero);
            int num = 1;
            checked
            {
                int arg_79_0;
                int num2;
                do
                {
                    Message[] arg_6B_0_cp_0 = this.Messages;
                    int arg_6B_0_cp_1 = num;
                    IntPtr arg_66_0 = this.Parent.Handle;
                    int arg_66_1 = 161;
                    wparam = new IntPtr(num + 9);
                    arg_6B_0_cp_0[arg_6B_0_cp_1] = Message.Create(arg_66_0, arg_66_1, wparam, IntPtr.Zero);
                    num++;
                    arg_79_0 = num;
                    num2 = 8;
                }
                while (arg_79_0 <= num2);
            }
        }
        private void CorrectBounds(Rectangle bounds)
        {
            bool flag = this.Parent.Width > bounds.Width;
            if (flag)
            {
                this.Parent.Width = bounds.Width;
            }
            flag = (this.Parent.Height > bounds.Height);
            if (flag)
            {
                this.Parent.Height = bounds.Height;
            }
            int num = this.Parent.Location.X;
            Point location = this.Parent.Location;
            int num2 = location.Y;
            flag = (num < bounds.X);
            if (flag)
            {
                num = bounds.X;
            }
            flag = (num2 < bounds.Y);
            if (flag)
            {
                num2 = bounds.Y;
            }
            checked
            {
                int num3 = bounds.X + bounds.Width;
                int num4 = bounds.Y + bounds.Height;
                flag = (num + this.Parent.Width > num3);
                if (flag)
                {
                    num = num3 - this.Parent.Width;
                }
                flag = (num2 + this.Parent.Height > num4);
                if (flag)
                {
                    num2 = num4 - this.Parent.Height;
                }
                Control arg_12F_0 = this.Parent;
                location = new Point(num, num2);
                arg_12F_0.Location = location;
            }
        }
        protected Pen GetPen(string name)
        {
            return new Pen(this.Items[name]);
        }
        protected Pen GetPen(string name, float width)
        {
            return new Pen(this.Items[name], width);
        }
        protected SolidBrush GetBrush(string name)
        {
            return new SolidBrush(this.Items[name]);
        }
        protected Color GetColor(string name)
        {
            return this.Items[name];
        }
        protected void SetColor(string name, Color value)
        {
            bool flag = this.Items.ContainsKey(name);
            if (flag)
            {
                this.Items[name] = value;
            }
            else
            {
                this.Items.Add(name, value);
            }
        }
        protected void SetColor(string name, byte r, byte g, byte b)
        {
            this.SetColor(name, Color.FromArgb((int)r, (int)g, (int)b));
        }
        protected void SetColor(string name, byte a, byte r, byte g, byte b)
        {
            this.SetColor(name, Color.FromArgb((int)a, (int)r, (int)g, (int)b));
        }
        protected void SetColor(string name, byte a, Color value)
        {
            this.SetColor(name, Color.FromArgb((int)a, value));
        }
        private void InvalidateBitmap()
        {
            bool flag = this._Transparent && this._ControlMode;
            if (flag)
            {
                bool flag2 = this.Width == 0 || this.Height == 0;
                if (!flag2)
                {
                    this.B = new Bitmap(this.Width, this.Height, PixelFormat.Format32bppPArgb);
                    this.G = Graphics.FromImage(this.B);
                }
            }
            else
            {
                this.G = null;
                this.B = null;
            }
        }
        private void InvalidateCustimization()
        {
            checked
            {
                MemoryStream memoryStream = new MemoryStream(this.Items.Count * 4);
                Bloom[] colors = this.Colors;
                for (int i = 0; i < colors.Length; i++)
                {
                    Bloom bloom = colors[i];
                    memoryStream.Write(BitConverter.GetBytes(bloom.Value.ToArgb()), 0, 4);
                }
                memoryStream.Close();
                this._Customization = Convert.ToBase64String(memoryStream.ToArray());
            }
        }
        private void InvalidateTimer()
        {
            bool flag = this.DesignMode || !this.DoneCreation;
            if (!flag)
            {
                flag = this._IsAnimated;
                if (flag)
                {
                    ThemeShare.AddAnimationCallback(new ThemeShare.AnimationDelegate(this.DoAnimation));
                }
                else
                {
                    ThemeShare.RemoveAnimationCallback(new ThemeShare.AnimationDelegate(this.DoAnimation));
                }
            }
        }
        protected abstract void ColorHook();
        protected abstract void PaintHook();
        protected virtual void OnCreation()
        {
        }
        protected virtual void OnAnimation()
        {
        }
        protected Rectangle Offset(Rectangle r, int amount)
        {
            this.OffsetReturnRectangle = checked(new Rectangle(r.X + amount, r.Y + amount, r.Width - amount * 2, r.Height - amount * 2));
            return this.OffsetReturnRectangle;
        }
        protected Size Offset(Size s, int amount)
        {
            this.OffsetReturnSize = checked(new Size(s.Width + amount, s.Height + amount));
            return this.OffsetReturnSize;
        }
        protected Point Offset(Point p, int amount)
        {
            this.OffsetReturnPoint = checked(new Point(p.X + amount, p.Y + amount));
            return this.OffsetReturnPoint;
        }
        protected Point Center(Rectangle p, Rectangle c)
        {
            this.CenterReturn = checked(new Point(p.Width / 2 - c.Width / 2 + p.X + c.X, p.Height / 2 - c.Height / 2 + p.Y + c.Y));
            return this.CenterReturn;
        }
        protected Point Center(Rectangle p, Size c)
        {
            this.CenterReturn = checked(new Point(p.Width / 2 - c.Width / 2 + p.X, p.Height / 2 - c.Height / 2 + p.Y));
            return this.CenterReturn;
        }
        protected Point Center(Rectangle child)
        {
            return this.Center(this.Width, this.Height, child.Width, child.Height);
        }
        protected Point Center(Size child)
        {
            return this.Center(this.Width, this.Height, child.Width, child.Height);
        }
        protected Point Center(int childWidth, int childHeight)
        {
            return this.Center(this.Width, this.Height, childWidth, childHeight);
        }
        protected Point Center(Size p, Size c)
        {
            return this.Center(p.Width, p.Height, c.Width, c.Height);
        }
        protected Point Center(int pWidth, int pHeight, int cWidth, int cHeight)
        {
            this.CenterReturn = checked(new Point(pWidth / 2 - cWidth / 2, pHeight / 2 - cHeight / 2));
            return this.CenterReturn;
        }
        protected Size Measure()
        {
            Graphics measureGraphics = this.MeasureGraphics;
            bool flag = false;
            Size result;
            try
            {
                Monitor.Enter(measureGraphics, ref flag);
                result = this.MeasureGraphics.MeasureString(this.Text, this.Font, this.Width).ToSize();
            }
            finally
            {
                bool flag2 = flag;
                if (flag2)
                {
                    Monitor.Exit(measureGraphics);
                }
            }
            return result;
        }
        protected Size Measure(string text)
        {
            Graphics measureGraphics = this.MeasureGraphics;
            bool flag = false;
            Size result;
            try
            {
                Monitor.Enter(measureGraphics, ref flag);
                result = this.MeasureGraphics.MeasureString(text, this.Font, this.Width).ToSize();
            }
            finally
            {
                bool flag2 = flag;
                if (flag2)
                {
                    Monitor.Exit(measureGraphics);
                }
            }
            return result;
        }
        protected void DrawPixel(Color c1, int x, int y)
        {
            bool transparent = this._Transparent;
            if (transparent)
            {
                this.B.SetPixel(x, y, c1);
            }
            else
            {
                this.DrawPixelBrush = new SolidBrush(c1);
                this.G.FillRectangle(this.DrawPixelBrush, x, y, 1, 1);
            }
        }
        protected void DrawCorners(Color c1, int offset)
        {
            this.DrawCorners(c1, 0, 0, this.Width, this.Height, offset);
        }
        protected void DrawCorners(Color c1, Rectangle r1, int offset)
        {
            this.DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height, offset);
        }
        protected void DrawCorners(Color c1, int x, int y, int width, int height, int offset)
        {
            checked
            {
                this.DrawCorners(c1, x + offset, y + offset, width - offset * 2, height - offset * 2);
            }
        }
        protected void DrawCorners(Color c1)
        {
            this.DrawCorners(c1, 0, 0, this.Width, this.Height);
        }
        protected void DrawCorners(Color c1, Rectangle r1)
        {
            this.DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height);
        }
        protected void DrawCorners(Color c1, int x, int y, int width, int height)
        {
            bool flag = this._NoRounding;
            checked
            {
                if (!flag)
                {
                    flag = this._Transparent;
                    if (flag)
                    {
                        this.B.SetPixel(x, y, c1);
                        this.B.SetPixel(x + (width - 1), y, c1);
                        this.B.SetPixel(x, y + (height - 1), c1);
                        this.B.SetPixel(x + (width - 1), y + (height - 1), c1);
                    }
                    else
                    {
                        this.DrawCornersBrush = new SolidBrush(c1);
                        this.G.FillRectangle(this.DrawCornersBrush, x, y, 1, 1);
                        this.G.FillRectangle(this.DrawCornersBrush, x + (width - 1), y, 1, 1);
                        this.G.FillRectangle(this.DrawCornersBrush, x, y + (height - 1), 1, 1);
                        this.G.FillRectangle(this.DrawCornersBrush, x + (width - 1), y + (height - 1), 1, 1);
                    }
                }
            }
        }
        protected void DrawBorders(Pen p1, int offset)
        {
            this.DrawBorders(p1, 0, 0, this.Width, this.Height, offset);
        }
        protected void DrawBorders(Pen p1, Rectangle r, int offset)
        {
            this.DrawBorders(p1, r.X, r.Y, r.Width, r.Height, offset);
        }
        protected void DrawBorders(Pen p1, int x, int y, int width, int height, int offset)
        {
            checked
            {
                this.DrawBorders(p1, x + offset, y + offset, width - offset * 2, height - offset * 2);
            }
        }
        protected void DrawBorders(Pen p1)
        {
            this.DrawBorders(p1, 0, 0, this.Width, this.Height);
        }
        protected void DrawBorders(Pen p1, Rectangle r)
        {
            this.DrawBorders(p1, r.X, r.Y, r.Width, r.Height);
        }
        protected void DrawBorders(Pen p1, int x, int y, int width, int height)
        {
            checked
            {
                this.G.DrawRectangle(p1, x, y, width - 1, height - 1);
            }
        }
        protected void DrawText(Brush b1, HorizontalAlignment a, int x, int y)
        {
            this.DrawText(b1, this.Text, a, x, y);
        }
        protected void DrawText(Brush b1, string text, HorizontalAlignment a, int x, int y)
        {
            bool flag = text.Length == 0;
            checked
            {
                if (!flag)
                {
                    this.DrawTextSize = this.Measure(text);
                    this.DrawTextPoint = new Point(this.Width / 2 - this.DrawTextSize.Width / 2, this.Header / 2 - this.DrawTextSize.Height / 2);
                    switch (a)
                    {
                        case HorizontalAlignment.Left:
                            this.G.DrawString(text, this.Font, b1, (float)x, (float)(this.DrawTextPoint.Y + y));
                            break;
                        case HorizontalAlignment.Right:
                            this.G.DrawString(text, this.Font, b1, (float)(this.Width - this.DrawTextSize.Width - x), (float)(this.DrawTextPoint.Y + y));
                            break;
                        case HorizontalAlignment.Center:
                            this.G.DrawString(text, this.Font, b1, (float)(this.DrawTextPoint.X + x), (float)(this.DrawTextPoint.Y + y));
                            break;
                    }
                }
            }
        }
        protected void DrawText(Brush b1, Point p1)
        {
            bool flag = this.Text.Length == 0;
            if (!flag)
            {
                this.G.DrawString(this.Text, this.Font, b1, p1);
            }
        }
        protected void DrawText(Brush b1, int x, int y)
        {
            bool flag = this.Text.Length == 0;
            if (!flag)
            {
                this.G.DrawString(this.Text, this.Font, b1, (float)x, (float)y);
            }
        }
        protected void DrawImage(HorizontalAlignment a, int x, int y)
        {
            this.DrawImage(this._Image, a, x, y);
        }
        protected void DrawImage(Image image, HorizontalAlignment a, int x, int y)
        {
            bool flag = image == null;
            checked
            {
                if (!flag)
                {
                    this.DrawImagePoint = new Point(this.Width / 2 - image.Width / 2, this.Header / 2 - image.Height / 2);
                    switch (a)
                    {
                        case HorizontalAlignment.Left:
                            this.G.DrawImage(image, x, this.DrawImagePoint.Y + y, image.Width, image.Height);
                            break;
                        case HorizontalAlignment.Right:
                            this.G.DrawImage(image, this.Width - image.Width - x, this.DrawImagePoint.Y + y, image.Width, image.Height);
                            break;
                        case HorizontalAlignment.Center:
                            this.G.DrawImage(image, this.DrawImagePoint.X + x, this.DrawImagePoint.Y + y, image.Width, image.Height);
                            break;
                    }
                }
            }
        }
        protected void DrawImage(Point p1)
        {
            this.DrawImage(this._Image, p1.X, p1.Y);
        }
        protected void DrawImage(int x, int y)
        {
            this.DrawImage(this._Image, x, y);
        }
        protected void DrawImage(Image image, Point p1)
        {
            this.DrawImage(image, p1.X, p1.Y);
        }
        protected void DrawImage(Image image, int x, int y)
        {
            bool flag = image == null;
            if (!flag)
            {
                this.G.DrawImage(image, x, y, image.Width, image.Height);
            }
        }
        protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height)
        {
            this.DrawGradientRectangle = new Rectangle(x, y, width, height);
            this.DrawGradient(blend, this.DrawGradientRectangle);
        }
        protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height, float angle)
        {
            this.DrawGradientRectangle = new Rectangle(x, y, width, height);
            this.DrawGradient(blend, this.DrawGradientRectangle, angle);
        }
        protected void DrawGradient(ColorBlend blend, Rectangle r)
        {
            this.DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, 90f);
            this.DrawGradientBrush.InterpolationColors = blend;
            this.G.FillRectangle(this.DrawGradientBrush, r);
        }
        protected void DrawGradient(ColorBlend blend, Rectangle r, float angle)
        {
            this.DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, angle);
            this.DrawGradientBrush.InterpolationColors = blend;
            this.G.FillRectangle(this.DrawGradientBrush, r);
        }
        protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height)
        {
            this.DrawGradientRectangle = new Rectangle(x, y, width, height);
            this.DrawGradient(c1, c2, this.DrawGradientRectangle);
        }
        protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
        {
            this.DrawGradientRectangle = new Rectangle(x, y, width, height);
            this.DrawGradient(c1, c2, this.DrawGradientRectangle, angle);
        }
        protected void DrawGradient(Color c1, Color c2, Rectangle r)
        {
            this.DrawGradientBrush = new LinearGradientBrush(r, c1, c2, 90f);
            this.G.FillRectangle(this.DrawGradientBrush, r);
        }
        protected void DrawGradient(Color c1, Color c2, Rectangle r, float angle)
        {
            this.DrawGradientBrush = new LinearGradientBrush(r, c1, c2, angle);
            this.G.FillRectangle(this.DrawGradientBrush, r);
        }
        public void DrawRadial(ColorBlend blend, int x, int y, int width, int height)
        {
            this.DrawRadialRectangle = new Rectangle(x, y, width, height);
            this.DrawRadial(blend, this.DrawRadialRectangle, width / 2, height / 2);
        }
        public void DrawRadial(ColorBlend blend, int x, int y, int width, int height, Point center)
        {
            this.DrawRadialRectangle = new Rectangle(x, y, width, height);
            this.DrawRadial(blend, this.DrawRadialRectangle, center.X, center.Y);
        }
        public void DrawRadial(ColorBlend blend, int x, int y, int width, int height, int cx, int cy)
        {
            this.DrawRadialRectangle = new Rectangle(x, y, width, height);
            this.DrawRadial(blend, this.DrawRadialRectangle, cx, cy);
        }
        public void DrawRadial(ColorBlend blend, Rectangle r)
        {
            this.DrawRadial(blend, r, r.Width / 2, r.Height / 2);
        }
        public void DrawRadial(ColorBlend blend, Rectangle r, Point center)
        {
            this.DrawRadial(blend, r, center.X, center.Y);
        }
        public void DrawRadial(ColorBlend blend, Rectangle r, int cx, int cy)
        {
            this.DrawRadialPath.Reset();
            checked
            {
                this.DrawRadialPath.AddEllipse(r.X, r.Y, r.Width - 1, r.Height - 1);
                this.DrawRadialBrush1 = new PathGradientBrush(this.DrawRadialPath);
                PathGradientBrush arg_71_0 = this.DrawRadialBrush1;
                Point p = new Point(r.X + cx, r.Y + cy);
                arg_71_0.CenterPoint = p;
                this.DrawRadialBrush1.InterpolationColors = blend;
                bool flag = this.G.SmoothingMode == SmoothingMode.AntiAlias;
                if (flag)
                {
                    this.G.FillEllipse(this.DrawRadialBrush1, r.X + 1, r.Y + 1, r.Width - 3, r.Height - 3);
                }
                else
                {
                    this.G.FillEllipse(this.DrawRadialBrush1, r);
                }
            }
        }
        protected void DrawRadial(Color c1, Color c2, int x, int y, int width, int height)
        {
            this.DrawRadialRectangle = new Rectangle(x, y, width, height);
            this.DrawRadial(c1, c2, this.DrawGradientRectangle);
        }
        protected void DrawRadial(Color c1, Color c2, int x, int y, int width, int height, float angle)
        {
            this.DrawRadialRectangle = new Rectangle(x, y, width, height);
            this.DrawRadial(c1, c2, this.DrawGradientRectangle, angle);
        }
        protected void DrawRadial(Color c1, Color c2, Rectangle r)
        {
            this.DrawRadialBrush2 = new LinearGradientBrush(r, c1, c2, 90f);
            this.G.FillRectangle(this.DrawGradientBrush, r);
        }
        protected void DrawRadial(Color c1, Color c2, Rectangle r, float angle)
        {
            this.DrawRadialBrush2 = new LinearGradientBrush(r, c1, c2, angle);
            this.G.FillEllipse(this.DrawGradientBrush, r);
        }
        public GraphicsPath CreateRound(int x, int y, int width, int height, int slope)
        {
            this.CreateRoundRectangle = new Rectangle(x, y, width, height);
            return this.CreateRound(this.CreateRoundRectangle, slope);
        }
        public GraphicsPath CreateRound(Rectangle r, int slope)
        {
            this.CreateRoundPath = new GraphicsPath(FillMode.Winding);
            this.CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180f, 90f);
            checked
            {
                this.CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270f, 90f);
                this.CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0f, 90f);
                this.CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90f, 90f);
                this.CreateRoundPath.CloseFigure();
                return this.CreateRoundPath;
            }
        }
    }
    internal abstract class ThemeControl154 : Control
    {
        protected Graphics G;
        protected Bitmap B;
        private bool DoneCreation;
        private bool InPosition;
        protected MouseState State;
        private bool _BackColor;
        private bool _NoRounding;
        private Image _Image;
        private bool _Transparent;
        private Dictionary<string, Color> Items;
        private string _Customization;
        private Size _ImageSize;
        private int _LockWidth;
        private int _LockHeight;
        private bool _IsAnimated;
        private Rectangle OffsetReturnRectangle;
        private Size OffsetReturnSize;
        private Point OffsetReturnPoint;
        private Point CenterReturn;
        private Bitmap MeasureBitmap;
        private Graphics MeasureGraphics;
        private SolidBrush DrawPixelBrush;
        private SolidBrush DrawCornersBrush;
        private Point DrawTextPoint;
        private Size DrawTextSize;
        private Point DrawImagePoint;
        private LinearGradientBrush DrawGradientBrush;
        private Rectangle DrawGradientRectangle;
        private GraphicsPath DrawRadialPath;
        private PathGradientBrush DrawRadialBrush1;
        private LinearGradientBrush DrawRadialBrush2;
        private Rectangle DrawRadialRectangle;
        private GraphicsPath CreateRoundPath;
        private Rectangle CreateRoundRectangle;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ForeColor
        {
            get
            {
                return Color.Empty;
            }
            set
            {
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public override Image BackgroundImage
        {
            get
            {
                return null;
            }
            set
            {
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public override ImageLayout BackgroundImageLayout
        {
            get
            {
                return ImageLayout.None;
            }
            set
            {
            }
        }
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                this.Invalidate();
            }
        }
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                this.Invalidate();
            }
        }
        [Category("Misc")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                bool flag = !this.IsHandleCreated && value == Color.Transparent;
                if (flag)
                {
                    this._BackColor = true;
                }
                else
                {
                    base.BackColor = value;
                    flag = (this.Parent != null);
                    if (flag)
                    {
                        this.ColorHook();
                    }
                }
            }
        }
        public bool NoRounding
        {
            get
            {
                return this._NoRounding;
            }
            set
            {
                this._NoRounding = value;
                this.Invalidate();
            }
        }
        public Image Image
        {
            get
            {
                return this._Image;
            }
            set
            {
                bool flag = value == null;
                if (flag)
                {
                    this._ImageSize = Size.Empty;
                }
                else
                {
                    this._ImageSize = value.Size;
                }
                this._Image = value;
                this.Invalidate();
            }
        }
        public bool Transparent
        {
            get
            {
                return this._Transparent;
            }
            set
            {
                this._Transparent = value;
                bool flag = !this.IsHandleCreated;
                if (!flag)
                {
                    flag = (!value && this.BackColor.A != 255);
                    if (flag)
                    {
                        throw new Exception("Unable to change value to false while a transparent BackColor is in use.");
                    }
                    this.SetStyle(ControlStyles.Opaque, !value);
                    this.SetStyle(ControlStyles.SupportsTransparentBackColor, value);
                    if (value)
                    {
                        this.InvalidateBitmap();
                    }
                    else
                    {
                        this.B = null;
                    }
                    this.Invalidate();
                }
            }
        }
        public Bloom[] Colors
        {
            get
            {
                List<Bloom> list = new List<Bloom>();
                Dictionary<string, Color>.Enumerator enumerator = this.Items.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    List<Bloom> arg_3F_0 = list;
                    KeyValuePair<string, Color> current = enumerator.Current;
                    string arg_37_1 = current.Key;
                    KeyValuePair<string, Color> current2 = enumerator.Current;
                    Bloom item = new Bloom(arg_37_1, current2.Value);
                    arg_3F_0.Add(item);
                }
                return list.ToArray();
            }
            set
            {
                checked
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        Bloom bloom = value[i];
                        bool flag = this.Items.ContainsKey(bloom.Name);
                        if (flag)
                        {
                            this.Items[bloom.Name] = bloom.Value;
                        }
                    }
                    this.InvalidateCustimization();
                    this.ColorHook();
                    this.Invalidate();
                }
            }
        }
        public string Customization
        {
            get
            {
                return this._Customization;
            }
            set
            {
                bool flag = Operators.CompareString(value, this._Customization, false) == 0;
                checked
                {
                    if (!flag)
                    {
                        Bloom[] colors = this.Colors;
                        try
                        {
                            byte[] value2 = Convert.FromBase64String(value);
                            int arg_30_0 = 0;
                            int num = colors.Length - 1;
                            int num2 = arg_30_0;
                            while (true)
                            {
                                int arg_59_0 = num2;
                                int num3 = num;
                                if (arg_59_0 > num3)
                                {
                                    break;
                                }
                                colors[num2].Value = Color.FromArgb(BitConverter.ToInt32(value2, num2 * 4));
                                num2++;
                            }
                        }
                        catch (Exception arg_5D_0)
                        {
                            ProjectData.SetProjectError(arg_5D_0);
                            ProjectData.ClearProjectError();
                            return;
                        }
                        this._Customization = value;
                        this.Colors = colors;
                        this.ColorHook();
                        this.Invalidate();
                    }
                }
            }
        }
        protected Size ImageSize
        {
            get
            {
                return this._ImageSize;
            }
        }
        protected int LockWidth
        {
            get
            {
                return this._LockWidth;
            }
            set
            {
                this._LockWidth = value;
                bool flag = this.LockWidth != 0 && this.IsHandleCreated;
                if (flag)
                {
                    this.Width = this.LockWidth;
                }
            }
        }
        protected int LockHeight
        {
            get
            {
                return this._LockHeight;
            }
            set
            {
                this._LockHeight = value;
                bool flag = this.LockHeight != 0 && this.IsHandleCreated;
                if (flag)
                {
                    this.Height = this.LockHeight;
                }
            }
        }
        protected bool IsAnimated
        {
            get
            {
                return this._IsAnimated;
            }
            set
            {
                this._IsAnimated = value;
                this.InvalidateTimer();
            }
        }
        public ThemeControl154()
        {
            this.Items = new Dictionary<string, Color>();
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.Opaque | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this._ImageSize = Size.Empty;
            this.Font = new Font("Verdana", 8f);
            this.MeasureBitmap = new Bitmap(1, 1);
            this.MeasureGraphics = Graphics.FromImage(this.MeasureBitmap);
            this.DrawRadialPath = new GraphicsPath();
            this.InvalidateCustimization();
        }
        protected sealed override void OnHandleCreated(EventArgs e)
        {
            this.InvalidateCustimization();
            this.ColorHook();
            bool flag = this._LockWidth != 0;
            if (flag)
            {
                this.Width = this._LockWidth;
            }
            flag = (this._LockHeight != 0);
            if (flag)
            {
                this.Height = this._LockHeight;
            }
            this.Transparent = this._Transparent;
            flag = (this._Transparent && this._BackColor);
            if (flag)
            {
                this.BackColor = Color.Transparent;
            }
            base.OnHandleCreated(e);
        }
        protected sealed override void OnParentChanged(EventArgs e)
        {
            bool flag = this.Parent != null;
            if (flag)
            {
                this.OnCreation();
                this.DoneCreation = true;
                this.InvalidateTimer();
            }
            base.OnParentChanged(e);
        }
        private void DoAnimation(bool i)
        {
            this.OnAnimation();
            if (i)
            {
                this.Invalidate();
            }
        }
        protected sealed override void OnPaint(PaintEventArgs e)
        {
            bool flag = this.Width == 0 || this.Height == 0;
            if (!flag)
            {
                flag = this._Transparent;
                if (flag)
                {
                    this.PaintHook();
                    e.Graphics.DrawImage(this.B, 0, 0);
                }
                else
                {
                    this.G = e.Graphics;
                    this.PaintHook();
                }
            }
        }
        protected override void OnHandleDestroyed(EventArgs e)
        {
            ThemeShare.RemoveAnimationCallback(new ThemeShare.AnimationDelegate(this.DoAnimation));
            base.OnHandleDestroyed(e);
        }
        protected sealed override void OnSizeChanged(EventArgs e)
        {
            bool transparent = this._Transparent;
            if (transparent)
            {
                this.InvalidateBitmap();
            }
            this.Invalidate();
            base.OnSizeChanged(e);
        }
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            bool flag = this._LockWidth != 0;
            if (flag)
            {
                width = this._LockWidth;
            }
            flag = (this._LockHeight != 0);
            if (flag)
            {
                height = this._LockHeight;
            }
            base.SetBoundsCore(x, y, width, height, specified);
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            this.InPosition = true;
            this.SetState(MouseState.Over);
            base.OnMouseEnter(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            bool inPosition = this.InPosition;
            if (inPosition)
            {
                this.SetState(MouseState.Over);
            }
            base.OnMouseUp(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            bool flag = e.Button == MouseButtons.Left;
            if (flag)
            {
                this.SetState(MouseState.Down);
            }
            base.OnMouseDown(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            this.InPosition = false;
            this.SetState(MouseState.None);
            base.OnMouseLeave(e);
        }
        protected override void OnEnabledChanged(EventArgs e)
        {
            bool enabled = this.Enabled;
            if (enabled)
            {
                this.SetState(MouseState.None);
            }
            else
            {
                this.SetState(MouseState.Block);
            }
            base.OnEnabledChanged(e);
        }
        private void SetState(MouseState current)
        {
            this.State = current;
            this.Invalidate();
        }
        protected Pen GetPen(string name)
        {
            return new Pen(this.Items[name]);
        }
        protected Pen GetPen(string name, float width)
        {
            return new Pen(this.Items[name], width);
        }
        protected SolidBrush GetBrush(string name)
        {
            return new SolidBrush(this.Items[name]);
        }
        protected Color GetColor(string name)
        {
            return this.Items[name];
        }
        protected void SetColor(string name, Color value)
        {
            bool flag = this.Items.ContainsKey(name);
            if (flag)
            {
                this.Items[name] = value;
            }
            else
            {
                this.Items.Add(name, value);
            }
        }
        protected void SetColor(string name, byte r, byte g, byte b)
        {
            this.SetColor(name, Color.FromArgb((int)r, (int)g, (int)b));
        }
        protected void SetColor(string name, byte a, byte r, byte g, byte b)
        {
            this.SetColor(name, Color.FromArgb((int)a, (int)r, (int)g, (int)b));
        }
        protected void SetColor(string name, byte a, Color value)
        {
            this.SetColor(name, Color.FromArgb((int)a, value));
        }
        private void InvalidateBitmap()
        {
            bool flag = this.Width == 0 || this.Height == 0;
            if (!flag)
            {
                this.B = new Bitmap(this.Width, this.Height, PixelFormat.Format32bppPArgb);
                this.G = Graphics.FromImage(this.B);
            }
        }
        private void InvalidateCustimization()
        {
            checked
            {
                MemoryStream memoryStream = new MemoryStream(this.Items.Count * 4);
                Bloom[] colors = this.Colors;
                for (int i = 0; i < colors.Length; i++)
                {
                    Bloom bloom = colors[i];
                    memoryStream.Write(BitConverter.GetBytes(bloom.Value.ToArgb()), 0, 4);
                }
                memoryStream.Close();
                this._Customization = Convert.ToBase64String(memoryStream.ToArray());
            }
        }
        private void InvalidateTimer()
        {
            bool flag = this.DesignMode || !this.DoneCreation;
            if (!flag)
            {
                flag = this._IsAnimated;
                if (flag)
                {
                    ThemeShare.AddAnimationCallback(new ThemeShare.AnimationDelegate(this.DoAnimation));
                }
                else
                {
                    ThemeShare.RemoveAnimationCallback(new ThemeShare.AnimationDelegate(this.DoAnimation));
                }
            }
        }
        protected abstract void ColorHook();
        protected abstract void PaintHook();
        protected virtual void OnCreation()
        {
        }
        protected virtual void OnAnimation()
        {
        }
        protected Rectangle Offset(Rectangle r, int amount)
        {
            this.OffsetReturnRectangle = checked(new Rectangle(r.X + amount, r.Y + amount, r.Width - amount * 2, r.Height - amount * 2));
            return this.OffsetReturnRectangle;
        }
        protected Size Offset(Size s, int amount)
        {
            this.OffsetReturnSize = checked(new Size(s.Width + amount, s.Height + amount));
            return this.OffsetReturnSize;
        }
        protected Point Offset(Point p, int amount)
        {
            this.OffsetReturnPoint = checked(new Point(p.X + amount, p.Y + amount));
            return this.OffsetReturnPoint;
        }
        protected Point Center(Rectangle p, Rectangle c)
        {
            this.CenterReturn = checked(new Point(p.Width / 2 - c.Width / 2 + p.X + c.X, p.Height / 2 - c.Height / 2 + p.Y + c.Y));
            return this.CenterReturn;
        }
        protected Point Center(Rectangle p, Size c)
        {
            this.CenterReturn = checked(new Point(p.Width / 2 - c.Width / 2 + p.X, p.Height / 2 - c.Height / 2 + p.Y));
            return this.CenterReturn;
        }
        protected Point Center(Rectangle child)
        {
            return this.Center(this.Width, this.Height, child.Width, child.Height);
        }
        protected Point Center(Size child)
        {
            return this.Center(this.Width, this.Height, child.Width, child.Height);
        }
        protected Point Center(int childWidth, int childHeight)
        {
            return this.Center(this.Width, this.Height, childWidth, childHeight);
        }
        protected Point Center(Size p, Size c)
        {
            return this.Center(p.Width, p.Height, c.Width, c.Height);
        }
        protected Point Center(int pWidth, int pHeight, int cWidth, int cHeight)
        {
            this.CenterReturn = checked(new Point(pWidth / 2 - cWidth / 2, pHeight / 2 - cHeight / 2));
            return this.CenterReturn;
        }
        protected Size Measure()
        {
            return this.MeasureGraphics.MeasureString(this.Text, this.Font, this.Width).ToSize();
        }
        protected Size Measure(string text)
        {
            return this.MeasureGraphics.MeasureString(text, this.Font, this.Width).ToSize();
        }
        protected void DrawPixel(Color c1, int x, int y)
        {
            bool transparent = this._Transparent;
            if (transparent)
            {
                this.B.SetPixel(x, y, c1);
            }
            else
            {
                this.DrawPixelBrush = new SolidBrush(c1);
                this.G.FillRectangle(this.DrawPixelBrush, x, y, 1, 1);
            }
        }
        protected void DrawCorners(Color c1, int offset)
        {
            this.DrawCorners(c1, 0, 0, this.Width, this.Height, offset);
        }
        protected void DrawCorners(Color c1, Rectangle r1, int offset)
        {
            this.DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height, offset);
        }
        protected void DrawCorners(Color c1, int x, int y, int width, int height, int offset)
        {
            checked
            {
                this.DrawCorners(c1, x + offset, y + offset, width - offset * 2, height - offset * 2);
            }
        }
        protected void DrawCorners(Color c1)
        {
            this.DrawCorners(c1, 0, 0, this.Width, this.Height);
        }
        protected void DrawCorners(Color c1, Rectangle r1)
        {
            this.DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height);
        }
        protected void DrawCorners(Color c1, int x, int y, int width, int height)
        {
            bool flag = this._NoRounding;
            checked
            {
                if (!flag)
                {
                    flag = this._Transparent;
                    if (flag)
                    {
                        this.B.SetPixel(x, y, c1);
                        this.B.SetPixel(x + (width - 1), y, c1);
                        this.B.SetPixel(x, y + (height - 1), c1);
                        this.B.SetPixel(x + (width - 1), y + (height - 1), c1);
                    }
                    else
                    {
                        this.DrawCornersBrush = new SolidBrush(c1);
                        this.G.FillRectangle(this.DrawCornersBrush, x, y, 1, 1);
                        this.G.FillRectangle(this.DrawCornersBrush, x + (width - 1), y, 1, 1);
                        this.G.FillRectangle(this.DrawCornersBrush, x, y + (height - 1), 1, 1);
                        this.G.FillRectangle(this.DrawCornersBrush, x + (width - 1), y + (height - 1), 1, 1);
                    }
                }
            }
        }
        protected void DrawBorders(Pen p1, int offset)
        {
            this.DrawBorders(p1, 0, 0, this.Width, this.Height, offset);
        }
        protected void DrawBorders(Pen p1, Rectangle r, int offset)
        {
            this.DrawBorders(p1, r.X, r.Y, r.Width, r.Height, offset);
        }
        protected void DrawBorders(Pen p1, int x, int y, int width, int height, int offset)
        {
            checked
            {
                this.DrawBorders(p1, x + offset, y + offset, width - offset * 2, height - offset * 2);
            }
        }
        protected void DrawBorders(Pen p1)
        {
            this.DrawBorders(p1, 0, 0, this.Width, this.Height);
        }
        protected void DrawBorders(Pen p1, Rectangle r)
        {
            this.DrawBorders(p1, r.X, r.Y, r.Width, r.Height);
        }
        protected void DrawBorders(Pen p1, int x, int y, int width, int height)
        {
            checked
            {
                this.G.DrawRectangle(p1, x, y, width - 1, height - 1);
            }
        }
        protected void DrawText(Brush b1, HorizontalAlignment a, int x, int y)
        {
            this.DrawText(b1, this.Text, a, x, y);
        }
        protected void DrawText(Brush b1, string text, HorizontalAlignment a, int x, int y)
        {
            bool flag = text.Length == 0;
            checked
            {
                if (!flag)
                {
                    this.DrawTextSize = this.Measure(text);
                    this.DrawTextPoint = this.Center(this.DrawTextSize);
                    switch (a)
                    {
                        case HorizontalAlignment.Left:
                            this.G.DrawString(text, this.Font, b1, (float)x, (float)(this.DrawTextPoint.Y + y));
                            break;
                        case HorizontalAlignment.Right:
                            this.G.DrawString(text, this.Font, b1, (float)(this.Width - this.DrawTextSize.Width - x), (float)(this.DrawTextPoint.Y + y));
                            break;
                        case HorizontalAlignment.Center:
                            this.G.DrawString(text, this.Font, b1, (float)(this.DrawTextPoint.X + x), (float)(this.DrawTextPoint.Y + y));
                            break;
                    }
                }
            }
        }
        protected void DrawText(Brush b1, Point p1)
        {
            bool flag = this.Text.Length == 0;
            if (!flag)
            {
                this.G.DrawString(this.Text, this.Font, b1, p1);
            }
        }
        protected void DrawText(Brush b1, int x, int y)
        {
            bool flag = this.Text.Length == 0;
            if (!flag)
            {
                this.G.DrawString(this.Text, this.Font, b1, (float)x, (float)y);
            }
        }
        protected void DrawImage(HorizontalAlignment a, int x, int y)
        {
            this.DrawImage(this._Image, a, x, y);
        }
        protected void DrawImage(Image image, HorizontalAlignment a, int x, int y)
        {
            bool flag = image == null;
            checked
            {
                if (!flag)
                {
                    this.DrawImagePoint = this.Center(image.Size);
                    switch (a)
                    {
                        case HorizontalAlignment.Left:
                            this.G.DrawImage(image, x, this.DrawImagePoint.Y + y, image.Width, image.Height);
                            break;
                        case HorizontalAlignment.Right:
                            this.G.DrawImage(image, this.Width - image.Width - x, this.DrawImagePoint.Y + y, image.Width, image.Height);
                            break;
                        case HorizontalAlignment.Center:
                            this.G.DrawImage(image, this.DrawImagePoint.X + x, this.DrawImagePoint.Y + y, image.Width, image.Height);
                            break;
                    }
                }
            }
        }
        protected void DrawImage(Point p1)
        {
            this.DrawImage(this._Image, p1.X, p1.Y);
        }
        protected void DrawImage(int x, int y)
        {
            this.DrawImage(this._Image, x, y);
        }
        protected void DrawImage(Image image, Point p1)
        {
            this.DrawImage(image, p1.X, p1.Y);
        }
        protected void DrawImage(Image image, int x, int y)
        {
            bool flag = image == null;
            if (!flag)
            {
                this.G.DrawImage(image, x, y, image.Width, image.Height);
            }
        }
        protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height)
        {
            this.DrawGradientRectangle = new Rectangle(x, y, width, height);
            this.DrawGradient(blend, this.DrawGradientRectangle);
        }
        protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height, float angle)
        {
            this.DrawGradientRectangle = new Rectangle(x, y, width, height);
            this.DrawGradient(blend, this.DrawGradientRectangle, angle);
        }
        protected void DrawGradient(ColorBlend blend, Rectangle r)
        {
            this.DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, 90f);
            this.DrawGradientBrush.InterpolationColors = blend;
            this.G.FillRectangle(this.DrawGradientBrush, r);
        }
        protected void DrawGradient(ColorBlend blend, Rectangle r, float angle)
        {
            this.DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, angle);
            this.DrawGradientBrush.InterpolationColors = blend;
            this.G.FillRectangle(this.DrawGradientBrush, r);
        }
        protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height)
        {
            this.DrawGradientRectangle = new Rectangle(x, y, width, height);
            this.DrawGradient(c1, c2, this.DrawGradientRectangle);
        }
        protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
        {
            this.DrawGradientRectangle = new Rectangle(x, y, width, height);
            this.DrawGradient(c1, c2, this.DrawGradientRectangle, angle);
        }
        protected void DrawGradient(Color c1, Color c2, Rectangle r)
        {
            this.DrawGradientBrush = new LinearGradientBrush(r, c1, c2, 90f);
            this.G.FillRectangle(this.DrawGradientBrush, r);
        }
        protected void DrawGradient(Color c1, Color c2, Rectangle r, float angle)
        {
            this.DrawGradientBrush = new LinearGradientBrush(r, c1, c2, angle);
            this.G.FillRectangle(this.DrawGradientBrush, r);
        }
        public void DrawRadial(ColorBlend blend, int x, int y, int width, int height)
        {
            this.DrawRadialRectangle = new Rectangle(x, y, width, height);
            this.DrawRadial(blend, this.DrawRadialRectangle, width / 2, height / 2);
        }
        public void DrawRadial(ColorBlend blend, int x, int y, int width, int height, Point center)
        {
            this.DrawRadialRectangle = new Rectangle(x, y, width, height);
            this.DrawRadial(blend, this.DrawRadialRectangle, center.X, center.Y);
        }
        public void DrawRadial(ColorBlend blend, int x, int y, int width, int height, int cx, int cy)
        {
            this.DrawRadialRectangle = new Rectangle(x, y, width, height);
            this.DrawRadial(blend, this.DrawRadialRectangle, cx, cy);
        }
        public void DrawRadial(ColorBlend blend, Rectangle r)
        {
            this.DrawRadial(blend, r, r.Width / 2, r.Height / 2);
        }
        public void DrawRadial(ColorBlend blend, Rectangle r, Point center)
        {
            this.DrawRadial(blend, r, center.X, center.Y);
        }
        public void DrawRadial(ColorBlend blend, Rectangle r, int cx, int cy)
        {
            this.DrawRadialPath.Reset();
            checked
            {
                this.DrawRadialPath.AddEllipse(r.X, r.Y, r.Width - 1, r.Height - 1);
                this.DrawRadialBrush1 = new PathGradientBrush(this.DrawRadialPath);
                PathGradientBrush arg_71_0 = this.DrawRadialBrush1;
                Point p = new Point(r.X + cx, r.Y + cy);
                arg_71_0.CenterPoint = p;
                this.DrawRadialBrush1.InterpolationColors = blend;
                bool flag = this.G.SmoothingMode == SmoothingMode.AntiAlias;
                if (flag)
                {
                    this.G.FillEllipse(this.DrawRadialBrush1, r.X + 1, r.Y + 1, r.Width - 3, r.Height - 3);
                }
                else
                {
                    this.G.FillEllipse(this.DrawRadialBrush1, r);
                }
            }
        }
        protected void DrawRadial(Color c1, Color c2, int x, int y, int width, int height)
        {
            this.DrawRadialRectangle = new Rectangle(x, y, width, height);
            this.DrawRadial(c1, c2, this.DrawRadialRectangle);
        }
        protected void DrawRadial(Color c1, Color c2, int x, int y, int width, int height, float angle)
        {
            this.DrawRadialRectangle = new Rectangle(x, y, width, height);
            this.DrawRadial(c1, c2, this.DrawRadialRectangle, angle);
        }
        protected void DrawRadial(Color c1, Color c2, Rectangle r)
        {
            this.DrawRadialBrush2 = new LinearGradientBrush(r, c1, c2, 90f);
            this.G.FillEllipse(this.DrawRadialBrush2, r);
        }
        protected void DrawRadial(Color c1, Color c2, Rectangle r, float angle)
        {
            this.DrawRadialBrush2 = new LinearGradientBrush(r, c1, c2, angle);
            this.G.FillEllipse(this.DrawRadialBrush2, r);
        }
        public GraphicsPath CreateRound(int x, int y, int width, int height, int slope)
        {
            this.CreateRoundRectangle = new Rectangle(x, y, width, height);
            return this.CreateRound(this.CreateRoundRectangle, slope);
        }
        public GraphicsPath CreateRound(Rectangle r, int slope)
        {
            this.CreateRoundPath = new GraphicsPath(FillMode.Winding);
            this.CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180f, 90f);
            checked
            {
                this.CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270f, 90f);
                this.CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0f, 90f);
                this.CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90f, 90f);
                this.CreateRoundPath.CloseFigure();
                return this.CreateRoundPath;
            }
        }
    }
    [StandardModule]
    internal sealed class ThemeModule
    {
        internal static Graphics G = null;
        private static Bitmap TextBitmap;
        private static Graphics TextGraphics;
        private static GraphicsPath CreateRoundPath;
        private static Rectangle CreateRoundRectangle;
        static ThemeModule()
        {
            ThemeModule.TextBitmap = new Bitmap(1, 1);
            ThemeModule.TextGraphics = Graphics.FromImage(ThemeModule.TextBitmap);
        }
        internal static SizeF MeasureString(string text, Font font)
        {
            return ThemeModule.TextGraphics.MeasureString(text, font);
        }
        internal static SizeF MeasureString(string text, Font font, int width)
        {
            return ThemeModule.TextGraphics.MeasureString(text, font, width, StringFormat.GenericTypographic);
        }
        internal static GraphicsPath CreateRound(int x, int y, int width, int height, int slope)
        {
            ThemeModule.CreateRoundRectangle = new Rectangle(x, y, width, height);
            return ThemeModule.CreateRound(ThemeModule.CreateRoundRectangle, slope);
        }
        internal static GraphicsPath CreateRound(Rectangle r, int slope)
        {
            ThemeModule.CreateRoundPath = new GraphicsPath(FillMode.Winding);
            ThemeModule.CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180f, 90f);
            checked
            {
                ThemeModule.CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270f, 90f);
                ThemeModule.CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0f, 90f);
                ThemeModule.CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90f, 90f);
                ThemeModule.CreateRoundPath.CloseFigure();
                return ThemeModule.CreateRoundPath;
            }
        }
    }
    [StandardModule]
    internal sealed class ThemeShare
    {
        public delegate void AnimationDelegate(bool invalidate);
        private static int Frames;
        private static bool Invalidate;
        public static PrecisionTimer ThemeTimer = new PrecisionTimer();
        private const int FPS = 50;
        private const int Rate = 10;
        private static List<ThemeShare.AnimationDelegate> Callbacks = new List<ThemeShare.AnimationDelegate>();
        private static void HandleCallbacks(IntPtr state, bool reserve)
        {
            ThemeShare.Invalidate = (ThemeShare.Frames >= 50);
            bool flag = ThemeShare.Invalidate;
            if (flag)
            {
                ThemeShare.Frames = 0;
            }
            List<ThemeShare.AnimationDelegate> callbacks = ThemeShare.Callbacks;
            bool flag2 = false;
            checked
            {
                try
                {
                    Monitor.Enter(callbacks, ref flag2);
                    int arg_44_0 = 0;
                    int num = ThemeShare.Callbacks.Count - 1;
                    int num2 = arg_44_0;
                    while (true)
                    {
                        int arg_68_0 = num2;
                        int num3 = num;
                        if (arg_68_0 > num3)
                        {
                            break;
                        }
                        ThemeShare.Callbacks[num2](ThemeShare.Invalidate);
                        num2++;
                    }
                }
                finally
                {
                    flag = flag2;
                    if (flag)
                    {
                        Monitor.Exit(callbacks);
                    }
                }
                ThemeShare.Frames += 10;
            }
        }
        private static void InvalidateThemeTimer()
        {
            bool flag = ThemeShare.Callbacks.Count == 0;
            if (flag)
            {
                ThemeShare.ThemeTimer.Delete();
            }
            else
            {
                ThemeShare.ThemeTimer.Create(0u, 10u, new PrecisionTimer.TimerDelegate(ThemeShare.HandleCallbacks));
            }
        }
        public static void AddAnimationCallback(ThemeShare.AnimationDelegate callback)
        {
            List<ThemeShare.AnimationDelegate> callbacks = ThemeShare.Callbacks;
            bool flag = false;
            try
            {
                Monitor.Enter(callbacks, ref flag);
                bool flag2 = ThemeShare.Callbacks.Contains(callback);
                if (!flag2)
                {
                    ThemeShare.Callbacks.Add(callback);
                    ThemeShare.InvalidateThemeTimer();
                }
            }
            finally
            {
                bool flag2 = flag;
                if (flag2)
                {
                    Monitor.Exit(callbacks);
                }
            }
        }
        public static void RemoveAnimationCallback(ThemeShare.AnimationDelegate callback)
        {
            List<ThemeShare.AnimationDelegate> callbacks = ThemeShare.Callbacks;
            bool flag = false;
            try
            {
                Monitor.Enter(callbacks, ref flag);
                bool flag2 = !ThemeShare.Callbacks.Contains(callback);
                if (!flag2)
                {
                    ThemeShare.Callbacks.Remove(callback);
                    ThemeShare.InvalidateThemeTimer();
                }
            }
            finally
            {
                bool flag2 = flag;
                if (flag2)
                {
                    Monitor.Exit(callbacks);
                }
            }
        }
    }


}