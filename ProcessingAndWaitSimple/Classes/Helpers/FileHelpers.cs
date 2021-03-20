using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using static System.IO.Path;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingAndWait.Classes.Helpers
{
    public class FileHelpers : FileSystemWatcher
    {

        /// <summary>
        /// Remove result files from Debug folder
        /// </summary>
        public static void RemoveFiles()
        {
            var extensions = new[] { ".txt", ".csv", ".json", ".html" };

            var files = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory)
                .EnumerateFiles()
                .Where(fileInfo => extensions.Contains(fileInfo.Extension.ToLower()))
                .ToArray();

            foreach (var fileInfo in files)
            {
                File.Delete(fileInfo.Name);
            }

        }

        public static void OpenExecutableFolder()
        {
            Process.Start("explorer.exe", AppDomain.CurrentDomain.BaseDirectory);
        }

        public FileHelpers()
        {

            Error += OnError;

            Path = AppDomain.CurrentDomain.BaseDirectory;

            Filters.Add("*.txt");
            Filters.Add("*.csv");
            Filters.Add("*.json");
            Filters.Add("*.html");
            
            EnableRaisingEvents = true;

            NotifyFilter = NotifyFilters.Attributes
                           | NotifyFilters.CreationTime
                           | NotifyFilters.DirectoryName
                           | NotifyFilters.FileName
                           | NotifyFilters.LastAccess
                           | NotifyFilters.LastWrite
                           | NotifyFilters.Security
                           | NotifyFilters.Size;
        }
        public static List<string> ReadAllLines(string fileName) => File.ReadAllLines(fileName).ToList();

        //private void OnCreated(object sender, FileSystemEventArgs e) => NewFileCreated?.Invoke(e.Name);

        public void Start()
        {
            EnableRaisingEvents = true;
        }

        public void Stop()
        {
            EnableRaisingEvents = false;
        }

        private static void OnError(object sender, ErrorEventArgs e) => DisplayException(e.GetException());
        
        /// <summary>
        /// For debug purposes
        /// For a production environment write to a log file
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <remarks>
        /// Recursive method
        /// </remarks>
        private static void DisplayException(Exception ex)
        {
            if (ex == null) return;
            
            Debug.WriteLine($"Message: {ex.Message}");
            Debug.WriteLine("Stacktrace:");
            Debug.WriteLine(ex.StackTrace);
            Debug.WriteLine("");

            DisplayException(ex.InnerException);
        }
    }
}
