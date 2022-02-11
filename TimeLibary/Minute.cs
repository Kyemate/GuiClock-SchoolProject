using System;

namespace ClockLibary
{
    public class Minute
    {
        public int Value { get; set; } = 0;

        public Minute() { }

        public Minute(int minute) => Value = minute > 59 || minute < 0 ? 0 : minute;

        public void Tick() => Value = Value == 59 ? 0 : ++Value;

        public static Minute operator +(Minute a, Minute b)
        {
            DateTime time = DateTime.Parse($"00:{a.Value}");


            time = time.AddMinutes(b.Value);

            return new Minute(time.Minute);
        }

    }
}
