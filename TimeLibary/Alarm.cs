namespace ClockLibary
{
    public enum AlarmState
    {
        On,
        Off,
        Alert
    }
    public enum AlarmSound
    {
        Silent,
        Alien,
        Uboat
    }
    public class Alarm : TimeBase
    {
        private Time _autoTurnOffTime = new Time();

        private bool _keepActiveAfterMidnight = false;

        public Alarm(int hour, int minute, AlarmSound sound = AlarmSound.Silent) : base(hour, minute) 
        {
            Sound = sound;
        }

        public AlarmState State { get; set; } = AlarmState.On;

        public AlarmSound Sound { get; set; }

        public string Time { get { return GetTime(); } }

        //uppdaterar och returnerar alarmets "State"
        public AlarmState UpdateState(TimeBase time)
        {
            _keepActiveAfterMidnight = (time != _autoTurnOffTime);


            if (State == AlarmState.Off)
                return State;
            else if (time.CompareTime(Hour.Value, Minute.Value))
            {
                _autoTurnOffTime = time.ToTime() + new Minute(10);
                //True if alarm time + 10 minutes is over midnight
                _keepActiveAfterMidnight = _autoTurnOffTime < time;

                return State = AlarmState.Alert;
            }
            else if (State == AlarmState.Alert)
            {
                if (_keepActiveAfterMidnight)
                    return AlarmState.Alert;
                else if (_autoTurnOffTime <= time)
                    return State = AlarmState.On;
            }

            return State;
        }
        
    }
    
}
