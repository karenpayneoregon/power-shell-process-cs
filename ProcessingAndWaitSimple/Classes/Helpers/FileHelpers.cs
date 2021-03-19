using System;
using System.Collections.Generic;
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
        /// Path to check for new files
        /// </summary>
        public string MonitorPath { get; set; }
        /// <summary>
        /// Path to move file(s) too
        /// </summary>
        public string TargetPath { get; set; }
        public FileHelpers(string monitorPath, string targetPath, string extension)
        {
            MonitorPath = monitorPath;
            TargetPath = targetPath;

            Created += OnCreated;
            Error += OnError;

            Path = MonitorPath;
            Filter = extension;

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

        private void OnCreated(object sender, FileSystemEventArgs e)
        {

            try
            {
                var targetFile = Combine(TargetPath, GetFileName(e.FullPath));
                
                if (File.Exists(targetFile))
                {
                    File.Delete(targetFile);
                }

                File.Move(e.FullPath, targetFile);
                
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
        }

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
