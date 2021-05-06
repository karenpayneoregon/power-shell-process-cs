using System;

namespace PowerShellLibrary.Containers
{
    public class Osuptime
    {
        public long Ticks { get; set; }
        public int Days { get; set; }
        public int Hours { get; set; }
        public int Milliseconds { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public float TotalDays { get; set; }
        public float TotalHours { get; set; }
        public float TotalMilliseconds { get; set; }
        public float TotalMinutes { get; set; }
        public float TotalSeconds { get; set; }
        public override string ToString() => $"{Hours} hours {Minutes} minutes {Days} days";
    }
}
