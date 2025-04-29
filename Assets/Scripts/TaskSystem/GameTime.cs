namespace TaskSystem
{
    public struct GameTime
    {
        public int Hour;
        public int Minute;

        public GameTime(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
        }

        public bool IsBefore(int hour, int minute)
        {
            return Hour < hour || (Hour == hour && Minute < minute);
        }

        public override string ToString()
        {
            return $"{Hour:D2}:{Minute:D2}";
        }
    }
}
