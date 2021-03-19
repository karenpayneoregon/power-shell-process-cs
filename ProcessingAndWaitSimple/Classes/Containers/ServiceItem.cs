using System.ServiceProcess;

namespace ProcessingAndWait.Classes.Containers
{
    public class ServiceItem
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Status { get; set; }
        public string table { get; set; }
        public ServiceStartMode ServiceStartMode { get; set; }
        public override string ToString() => Name;
        /// <summary>
        /// For adding items to a ListView
        /// </summary>
        /// <returns></returns>
        public string[] ItemArray() => new[] { Name, DisplayName, Status };
    }
}