using System;

namespace ClockLibary
{
    public class Hour
    {
        public int Value { get; set; } = 0;

        public Hour() { }
        public Hour(int hour) => Value = hour > 23 || hour < 0 ? 0 : hour;

        public void Tick() => Value = Value == 23 ? 0 : ++Value;

        public static Hour operator +(Hour a, Hour b)
        {
            DateTime time = DateTime.Parse($"{a.Value}:00");

            time = time.AddHours(b.Value);

            return new Hour(time.Hour);
        }

    }
}
