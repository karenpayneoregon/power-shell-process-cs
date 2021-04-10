namespace ProcessingAndWait.Classes.Containers
{
    public class BaseUtcOffset
    {
        public long Ticks { get; set; }
        public int Days { get; set; }
        public int Hours { get; set; }
        public int Milliseconds { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public float TotalDays { get; set; }
        public int TotalHours { get; set; }
        public int TotalMilliseconds { get; set; }
        public int TotalMinutes { get; set; }
        public int TotalSeconds { get; set; }
    }
}