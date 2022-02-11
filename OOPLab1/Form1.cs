using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ClockLibary;

namespace OOPLab1
{
    public partial class Form1 : Form {

        public Form1()
        {
            InitializeComponent();
            audioCombobox.DataSource = Enum.GetValues(typeof(AlarmSound));
            audioCombobox.SelectedIndex = 0;
            //Set clock timer thread to UI thread
            _clock.SynchronizingObject = this;
            _clock.Elapsed += clock_Elapsed;
            _clock.Interval = 1000;
            
        }
        
        private readonly Clock _clock = new Clock();
        private List<Alarm> _alarmList = new List<Alarm>();
        private AlarmEffect _alarmEffect = new AlarmEffect();
        private Alarm _selectedAlarm = null;

        #region Clock
        private void clockBtn_Click(object sender, EventArgs e)
        {
            clockBtn.Focus();
            if(!_clock.Enabled)
            {
                _clock.Set(timePicker.Value.Hour, timePicker.Value.Minute);
                formSkin.Text = "GUI Clock: " + _clock.GetTime();
                formSkin.Invalidate(false);
                clockBtn.BaseColor = ColorTranslator.FromHtml("#A80005");
                clockBtn.Text = "Stop";
                timePicker.Hide();
                clockBtn.Location = timePicker.Location;
                _clock.Start();
                
            }
            else
            {
                clockBtn.BaseColor = Color.ForestGreen;
                clockBtn.Text = "Start";
                timePicker.Value = DateTime.Parse(_clock.GetTime());
                timePicker.Show();
                clockBtn.Location = new Point(267, 12);
                _clock.Stop();
            }
        }
        

        private void clock_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            bool active = false;
            AlarmSound sound = AlarmSound.Silent;
            formSkin.Text = "GUI Clock: " + _clock.GetTime();
            formSkin.Invalidate(false);

            foreach (var alarm in _alarmList)
            {
                if (alarm.UpdateState(_clock) == AlarmState.Alert)
                {
                    active = true;
                    if(sound == AlarmSound.Silent)
                        sound = alarm.Sound;
                }
                
            }
            if(active)
            {
                if (_alarmEffect.IsDisposed)
                {
                    _alarmEffect = new AlarmEffect();
                    _alarmEffect.Sound = sound;
                    _alarmEffect.Show();
                }
                else if (!_alarmEffect.Visible)
                {
                    _alarmEffect.Sound = sound;
                    _alarmEffect.Show();
                }
                //if (_alarmEffect.Sound == AlarmSound.Silent)
                //    _alarmEffect.PlaySound(sound);

                dismissBtn.Show();
            }
            else
            {
                dismissBtn.Hide();
                if (!_alarmEffect.IsDisposed)
                    _alarmEffect.Hide();
            }
            alarmOLV.RefreshObjects(_alarmList);
        }


        #endregion

        private void flatButton1_Click(object sender, EventArgs e)
        {

            var alarmList = new List<Alarm>();

            alarmList.Add(new Alarm(21, 43));
            alarmList.Add(new Alarm(22, 2));
            alarmList.Add(new Alarm(22, 5));
            alarmList.Add(new Alarm(23, 55));
            alarmList.Add(new Alarm(00, 03));
            _alarmList.AddRange(alarmList);

            alarmOLV.SetObjects(_alarmList);
            //foreach(Alarm alarm in alarmList)
            //{
            //    ListViewItem lvi = new ListViewItem(new string[] { alarm.Check().ToString(), alarm.GetTime(), "3" });
            //    listView1.Items.Add(lvi);
            //}
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("frm act");
            TopMost = true;
            TopMost = false;
        }

        private void objectListView1_FormatRow(object sender, BrightIdeasSoftware.FormatRowEventArgs e)
        {
            Alarm alarm = (Alarm)e.Model;
            AlarmState state = alarm.UpdateState(_clock);
            if(state == AlarmState.Alert)
                e.Item.BackColor = Color.Red;
        }

        private void alarmOLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (alarmOLV.SelectedIndex != -1)
            {
                _selectedAlarm = _alarmList[alarmOLV.SelectedIndex];
                deleteAlarmBtn.Enabled = true;
                activateAlarmBtn.Text = _selectedAlarm.State == AlarmState.Off ? "Activate" : "Deactivate";
                activateAlarmBtn.BaseColor = _selectedAlarm.State == AlarmState.Off ? Color.ForestGreen : Color.Red;
                activateAlarmBtn.Enabled = true;

            }
            else
            {
                deleteAlarmBtn.Enabled = false;
                activateAlarmBtn.Text = "Activate";
                activateAlarmBtn.BaseColor = Color.ForestGreen;
                activateAlarmBtn.Enabled = false;
                _selectedAlarm = null;
            }
        }


        #region Buttons
        private void activateAlarmBtn_Click(object sender, EventArgs e)
        {

            _selectedAlarm.State = _selectedAlarm.State == AlarmState.Off ? AlarmState.On : AlarmState.Off;
            activateAlarmBtn.Text = _selectedAlarm.State == AlarmState.Off ? "Activate" : "Deactivate";
            activateAlarmBtn.BaseColor = _selectedAlarm.State == AlarmState.Off ? Color.ForestGreen : Color.Red;

            alarmOLV.UpdateObject(_selectedAlarm);
        }

        private void addAlarmBtn_Click(object sender, EventArgs e)
        {
            Alarm alarm = new Alarm(alarmTimePicker.Value.Hour, alarmTimePicker.Value.Minute, (AlarmSound)audioCombobox.SelectedItem);
            _alarmList.Add(alarm);
            alarmOLV.AddObject(alarm);
        }

        private void deleteAlarmBtn_Click(object sender, EventArgs e)
        {
            _alarmList.RemoveAt(alarmOLV.SelectedIndex);
            alarmOLV.SetObjects(_alarmList);
            alarmOLV.SelectedIndex = -1;
            alarmOLV_SelectedIndexChanged(null, null);

        }

        private void dismissBtn_Click(object sender, EventArgs e)
        {

            foreach (var alarm in _alarmList)
            {
                if (alarm.State == AlarmState.Alert)
                    alarm.State = AlarmState.On;
            }

            if (!_alarmEffect.IsDisposed)
                _alarmEffect.Hide();

            dismissBtn.Hide();
        }
        #endregion

        #region Close/Minimize bottons
        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void miniBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;

        }

        #endregion


        private void alarmTimePicker_ValueChanged(object sender, EventArgs e)
        {
            timeSlider.Value = (alarmTimePicker.Value.Hour * 60) + alarmTimePicker.Value.Minute;
        }

        private void timeSlider_Scroll(object sender, EventArgs e)
        {
            int hour = timeSlider.Value / 60;
            int minute = timeSlider.Value - (hour * 60);
            alarmTimePicker.Value = DateTime.Parse($"{hour}:{minute}");
        }

        private void audioCombobox_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip.SetToolTip(audioCombobox, "Choose alarm sound");
        }

        private void timeSlider_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip.SetToolTip(timeSlider, "Set alarm time");
        }
    }
}
