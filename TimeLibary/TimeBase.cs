using System;
using System.Timers;

namespace ClockLibary
{
#pragma warning disable CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
#pragma warning disable CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
    [System.ComponentModel.DesignerCategory("Code")]
    public abstract class TimeBase : Timer, ITime
    {

        public virtual Hour Hour { get; set; } = new Hour();
        public virtual Minute Minute { get; set; } = new Minute();

        public TimeBase() { }

        public TimeBase(int hour, int minute)
        {
            if (hour <= 24 && hour >= 0 && minute >= 0 && minute <= 60)
            {
                Hour.Value = hour;
                Minute.Value = minute;
            }
            else
            {
                Hour.Value = 0;
                Minute.Value = 0;
            }
        }

        public string GetTime()
        {
            return $"{Hour.Value:00}:{Minute.Value:00}";
        }

        public bool CompareTime(int hour, int minute)
        {
            return (Hour.Value == hour) && (Minute.Value == minute);
        }

        public bool CompareTime(TimeBase time)
        {
            return (Hour.Value == time.Hour.Value) && (Minute.Value == time.Minute.Value);
        }

        public bool Set(int hour, int minute)
        {
            if (hour <= 24 && hour >= 0 && minute >= 0 && minute <= 60)
            {
                Hour.Value = hour;
                Minute.Value = minute;
                return true;
            }
            return false;
        }
        public Time ToTime()
        {
            return new Time(Hour.Value, Minute.Value);
        }

        #region Operator overload
        public static bool operator ==(TimeBase a, TimeBase b) =>
            a?.Hour.Value == b?.Hour.Value && a?.Minute.Value == b?.Minute.Value;

        public static bool operator !=(TimeBase a, TimeBase b) =>
            a?.Hour.Value != b?.Hour.Value || a?.Minute.Value != b?.Minute.Value;

        public static bool operator >(TimeBase a, TimeBase b) =>
            DateTime.Parse(a.GetTime()) > DateTime.Parse(b.GetTime());

        public static bool operator <(TimeBase a, TimeBase b) =>
            DateTime.Parse(a.GetTime()) < DateTime.Parse(b.GetTime());

        public static bool operator >=(TimeBase a, TimeBase b) =>
            DateTime.Parse(a.GetTime()) >= DateTime.Parse(b.GetTime());

        public static bool operator <=(TimeBase a, TimeBase b) =>
            DateTime.Parse(a.GetTime()) <= DateTime.Parse(b.GetTime());

        #endregion
    }
}
