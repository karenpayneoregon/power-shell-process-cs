namespace ProcessingAndWait.Classes.Containers
{
    public class TimezoneItem
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string StandardName { get; set; }
        public string DaylightName { get; set; }
        public BaseUtcOffset BaseUtcOffset { get; set; }
        public bool SupportsDaylightSavingTime { get; set; }
    }
}