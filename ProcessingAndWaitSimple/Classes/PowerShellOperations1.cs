using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProcessingAndWait.Classes.Containers;

namespace ProcessingAndWait.Classes
{
    /// <summary>
    /// Uses Newtonsoft.Json instead of System.Text.Json as System.Text.Json
    /// does not handle dates formatted as written with
    /// 
    /// Get-EventLog -LogName
    /// 
    /// </summary>
    public class PowerShellOperations1
    {
        public static async Task<IpItem> GetIpAddressAsJsonTask()
        {
            const string fileName = "externalip.json";


            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            var start = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                Arguments = "Invoke-RestMethod -uri https://ipinfo.io/json -outfile externalip.json",
                CreateNoWindow = true
            };


            using var process = Process.Start(start);
            using var reader = process.StandardOutput;

            process.EnableRaisingEvents = true;

            var ipAddressResult = await reader.ReadToEndAsync();
            if (File.Exists(fileName))
            {
                var json = File.ReadAllText(fileName);
                return JsonConvert.DeserializeObject<IpItem>(json);
            }

            return new IpItem();
        }

        /// <summary>
        /// Get event log entries for yesterday onwards
        /// </summary>
        /// <returns>List&lt;AppEventItem&gt;</returns>
        /// <remarks>
        /// The intent here is too
        /// * Show that there are alternates to System.Text.Json methods which fail on dates
        /// * Show that the caller (user interface) remains responsive as in many cases there will be thousands of entries for one day.
        /// * The following pares down what entries to return
        ///       Select-Object Category, Timegenerated, EntryType, Source, Message
        /// * A very short version with different properties: Get-EventLog -LogName System -Newest 10
        /// </remarks>
        public static async Task<List<AppEventItem>> GetApplicationEventsAsJson()
        {

            const string fileName = "Events.csv";

            if (File.Exists(fileName))
            {
                File.Delete(fileName);

            }

            var yesterdayDate = DateTime.Now.AddDays(-1);

            var start = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                RedirectStandardOutput = true,
                Arguments = $"Get-EventLog -LogName application -After {yesterdayDate:d} | Select-Object Category, Timegenerated, EntryType, Source, Message | ConvertTo-Json",
                CreateNoWindow = true
            };

            using var process = Process.Start(start);

            // ReSharper disable once PossibleNullReferenceException
            using var reader = process.StandardOutput;

            process.EnableRaisingEvents = true;

            var fileContents = await reader.ReadToEndAsync();

            await File.WriteAllTextAsync(fileName, fileContents);
            await process.WaitForExitAsync();

            /*
             * This line can also be embedded into the DeserializeObject method
             * Why is not? Because this is clearer code and easier to debug.
             */
            var json = await File.ReadAllTextAsync(fileName);

            /*
             * Read back from file written above
             */
            return JsonConvert.DeserializeObject<List<AppEventItem>>(json);

        }
        

        /// <summary>
        /// Get registry information from
        /// 
        ///     Hkey_local_Machine\Software\Microsoft\ASP.NET
        ///
        /// Done a tad different from the other methods to show running an
        /// external script.
        ///
        /// Note, there may be a temptation to say export Hkey_local_Machine\Software\Microsoft,
        /// this is a lengthy time consuming process.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>If file exists with registry data</returns>
        /// <remarks>
        /// This will fail if insufficient permissions to the registry 
        /// </remarks>
        public static async Task<bool> GetRegistryInformationAsJson(string fileName)
        {
            var scriptFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "runner.ps1");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                await Task.Delay(1000);
            }

            var start = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"{scriptFileName}",
                CreateNoWindow = true
            };

            using var process = Process.Start(start);
            await process.WaitForExitAsync();

            return File.Exists(fileName);

        }

        public static async Task<int> GetWindowsReleaseIdentifier()
        {
            var result = 0;
            // 
            const string fileName = "win.txt";

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            var start = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                RedirectStandardOutput = true,
                Arguments = "(Get-ItemProperty \"HKLM:\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\" -Name ReleaseID).ReleaseId",
                CreateNoWindow = true
            };

            using (var process = Process.Start(start))
            {
                process.EnableRaisingEvents = true;
                
                using (var reader = process.StandardOutput)
                {
                    var fileContents = await reader.ReadToEndAsync();

                    await File.WriteAllTextAsync(fileName, fileContents);
                    await process.WaitForExitAsync();
                    var json = await File.ReadAllTextAsync(fileName);
                    Console.WriteLine();
                }
                
            }
            

            return result;
        }

        /// <summary>
        /// Removed 'mark of the web' from all files in a folder recursively 
        /// </summary>
        /// <param name="folderName">folder to perform the operation on</param>
        public static void UnblockFiles(string folderName)
        {
            if (!Directory.Exists(folderName))
            {
                return;
            }

            var start = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"Get-ChildItem -Path '{folderName}' -Recurse | Unblock-File",
                CreateNoWindow = true
            };

            using var process = Process.Start(start);

        }
        /// <summary>
        /// Get time zone information
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Adapted from
        /// https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.management/get-timezone?view=powershell-7.1
        /// </remarks>
        public static async Task<TimezoneItem> GetTimeZoneTask()
        {

            const string fileName = "timezone.json";

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            var start = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                RedirectStandardOutput = true,
                Arguments = "Get-TimeZone | ConvertTo-Json",
                CreateNoWindow = true
            };

            using var process = Process.Start(start);
            using var reader = process.StandardOutput;

            process.EnableRaisingEvents = true;

            var fileContents = await reader.ReadToEndAsync();

            await File.WriteAllTextAsync(fileName, fileContents);
            await process.WaitForExitAsync();

            /*
             * This line can also be embedded into the DeserializeObject method
             * Why is not? Because this is clearer code and easier to debug.
             */
            var json = await File.ReadAllTextAsync(fileName);

            /*
             * Read back from file written above
             */
            return JsonConvert.DeserializeObject<TimezoneItem>(json);

        }

        public static async Task<MachineComputerInformation> GetComputerInformationTask()
        {

            const string fileName = "computerInformation.json";

            if (File.Exists(fileName))
            {
                File.Delete(fileName);

            }

            var start = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                RedirectStandardOutput = true,
                Arguments = "Get-ComputerInfo | ConvertTo-Json",
                CreateNoWindow = true
            };

            using var process = Process.Start(start);

            // ReSharper disable once PossibleNullReferenceException
            using var reader = process.StandardOutput;

            process.EnableRaisingEvents = true;

            var fileContents = await reader.ReadToEndAsync();

            await File.WriteAllTextAsync(fileName, fileContents);
            await process.WaitForExitAsync();

            /*
             * This line can also be embedded into the DeserializeObject method
             * Why is not? Because this is clearer code and easier to debug.
             */
            var json = await File.ReadAllTextAsync(fileName);

            /*
             * Read back from file written above
             */
            return JsonConvert.DeserializeObject<MachineComputerInformation>(json);

        }
    }
}
