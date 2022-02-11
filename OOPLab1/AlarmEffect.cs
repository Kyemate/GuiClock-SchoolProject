using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ClockLibary;

namespace OOPLab1
{
    public partial class AlarmEffect : Form
    {
        #region external functions
        [DllImport("User32.dll")]
        private static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("User32.dll")]
        private static extern void ReleaseDC(IntPtr hwnd, IntPtr dc);
        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        const int GWL_EXSTYLE = -20;
        const int WS_EX_LAYERED = 0x80000;
        const int WS_EX_TRANSPARENT = 0x20;
        #endregion

        public AlarmSound Sound { get; set; } = AlarmSound.Silent;
        public bool IsPlayingSound { get; set; } = false;

        public AlarmEffect()
        {
            InitializeComponent();

            TopMost = true;
            BackColor = Color.White;
            TransparencyKey = Color.White;
            Size = Screen.PrimaryScreen.Bounds.Size;
            Opacity = 0.7;

            int initialStyle = GetWindowLong(this.Handle, GWL_EXSTYLE);
            SetWindowLong(this.Handle, GWL_EXSTYLE, initialStyle | WS_EX_LAYERED | WS_EX_TRANSPARENT);
        }

        double _opacity = 0;
        bool _increase = true;
        readonly double _speed = 0.15;
        private void blinkTimer_Tick(object sender, EventArgs e)
        {
            if (_increase)
            {
                _opacity += _speed;
                _increase = _opacity <= 0.5;
            }
            else if (!_increase)
            {
                _opacity -= _speed;
                _increase = _opacity <= -1;
            }

            Opacity = _opacity;
        }

        private void AlarmEffect_Load(object sender, EventArgs e)
        {
            blinkTimer.Start();
        }

        private void AlarmEffect_VisibleChanged(object sender, EventArgs e)
        {
            blinkTimer.Enabled = Visible;
            if(Visible)
            {
                PlaySound(Sound);
                blinkTimer.Start();
            }
            else
            {
                blinkTimer.Stop();
                wplayer.controls.stop();
            }
        }

        WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
        public void PlaySound(AlarmSound sound)
        {
            if (sound == AlarmSound.Silent)
                return;
            string fileName = "Nostromo_Alarm.mp3";
            string path = Path.Combine(Environment.CurrentDirectory, @"Audio Files\", fileName);
            wplayer.URL = path;
            if(sound == AlarmSound.Alien)
                wplayer.controls.play();
        }
    }
}
