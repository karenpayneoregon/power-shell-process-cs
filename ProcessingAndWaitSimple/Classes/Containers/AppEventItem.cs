using System;


namespace ProcessingAndWait.Classes.Containers
{
    /// <summary>
    /// Container for Get-Events from PowerShell
    /// </summary>
    /// <remarks>
    /// Class was generated automatically in Visual Studio by copying sample json, create a new
    /// class, select from Visual Studio's edit menu, paste special then Parse JSON as class. An
    /// extra class RootObject is created which is not needed and the default class name of Class1
    /// is changed to AppEventItem.
    /// </remarks>
    public class AppEventItem
    {
        public string MachineName { get; set; }
        public object[] Data { get; set; }
        public int Index { get; set; }
        public string Category { get; set; }
        public int CategoryNumber { get; set; }
        public int EventID { get; set; }
        public int EntryType { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string[] ReplacementStrings { get; set; }
        public int InstanceId { get; set; }
        //[JsonIgnore]
        public DateTime TimeGenerated { get; set; }
        public string UserName { get; set; }
        public object Site { get; set; }
        public object Container { get; set; }

        public string[] ItemArray() => new[] { Category, TimeGenerated.ToString(format: "hh:mm:ss t"), Message };
        public override string ToString() => Source;
    }

}
