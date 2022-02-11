using System.Timers;

namespace ClockLibary
{
    [System.ComponentModel.DesignerCategory("Code")]
    public class Clock : TimeBase
    {

        public Clock() { }

        public Clock(int hour, int minute) : base(hour, minute) { }
       
        public new int Hour { get { return base.Hour.Value; } }

        public new int Minute { get { return base.Minute.Value; } }


        //Skriver över System.Timers.Timer.Elapsed och lägger till
        //en tick fuktion för att hålla klock logiken från UI koden.
        public new event ElapsedEventHandler Elapsed
        {
            add
            {
                base.Elapsed += Time_Elapsed;
                base.Elapsed += value;
            }
            remove
            {
                base.Elapsed -= Time_Elapsed;
                base.Elapsed -= value;
            }
        }

        private void Time_Elapsed(object sender, ElapsedEventArgs e)
        {
            base.Minute.Tick();
            if (base.Minute.Value == 0)
                base.Hour.Tick();
        }
    }
}
