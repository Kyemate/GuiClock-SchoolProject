using System;

namespace ClockLibary
{
    public class Time : TimeBase, ITime
    {
        public Time() { }

        public Time(int hour, int minute) : base(hour, minute) { }

        public Time(Hour hour, Minute minute) : base(hour.Value, minute.Value) { }

        public override Hour Hour { get { return base.Hour; } set { base.Hour = value; } }
        public override Minute Minute { get { return base.Minute; } set { base.Minute = value; } }

        #region operator overload
        public static Time operator +(TimeBase a, Time b)
        {
            DateTime time = DateTime.Parse(a.GetTime());
            time = time.AddHours(b.Hour.Value);
            time = time.AddMinutes(b.Minute.Value);

            return new Time(time.Hour, time.Minute);
        }
        public static Time operator +(Time a, TimeBase b)
        {
            DateTime time = DateTime.Parse(a.GetTime());

            time = time.AddHours(b.Hour.Value);
            time = time.AddMinutes(b.Minute.Value);

            return new Time(time.Hour, time.Minute);
        }

        public static Time operator +(Time a, Hour b)
        {
            DateTime time = DateTime.Parse(a.GetTime());

            time = time.AddHours(b.Value);

            return new Time(time.Hour, time.Minute);
        }

        public static Time operator +(Time a, Minute b)
        {
            DateTime time = DateTime.Parse(a.GetTime());

            time = time.AddMinutes(b.Value);

            return new Time(time.Hour, time.Minute);
        }
        #endregion
    }
}
