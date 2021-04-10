using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ProcessingAndWait.Classes.Containers;
using ProcessingAndWait.Classes.Helpers;


namespace ProcessingAndWait.Classes
{
    /// <summary>
    /// Code samples using Process.Start rather than using
    /// the NuGet package
    ///
    /// Uses System.Text.Json rather than Newtonsoft.Json
    /// </summary>
    /// <remarks>
    /// Requires .NET 5 or .NET Core
    /// </remarks>
    public class PowerShellOperations
    {

        /// <summary>
        /// Get this computer's IP address synchronous 
        /// </summary>
        /// <returns>Task&lt;string&gt;</returns>
        public static async Task<string> GetIpAddressTask()
        {
            const string fileName = "ipPower_Async.txt";


            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            var start = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                Arguments = "Invoke-RestMethod ipinfo.io/ip",
                CreateNoWindow = true
            };


            using var process = Process.Start(start);
            using var reader = process.StandardOutput;

            process.EnableRaisingEvents = true;

            var ipAddressResult = await reader.ReadToEndAsync();

            await File.WriteAllTextAsync(fileName, ipAddressResult);
            await process.WaitForExitAsync();

            return await File.ReadAllTextAsync(fileName);
        }

        /// <summary>
        /// Get this computer's IP address asynchronous 
        /// </summary>
        /// <returns>Task&lt;string&gt;</returns>        
        public static string GetIpAddressSync()
        {
            const string fileName = "ipPower_Sync.txt";


            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            var start = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                Arguments = "Invoke-RestMethod ipinfo.io/ip",
                CreateNoWindow = true
            };


            using var process = Process.Start(start);
            using var reader = process.StandardOutput;

            process.EnableRaisingEvents = true;

            var ipAddressResult = reader.ReadToEnd();

            File.WriteAllTextAsync(fileName, ipAddressResult);
            process.WaitForExit();

            return File.ReadAllText(fileName);
        }
        /// <summary>
        /// Get services to a text file with json content
        /// </summary>
        /// <returns>List&lt;ServiceItem&gt;</returns>
        public static async Task<List<ServiceItem>> GetServicesAsJson()
        {
            const string fileName = "services.txt";

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            var start = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                Arguments = "Get-Service | Select-Object Name, DisplayName, @{ n='Status'; " + "e={ $_.Status.ToString() } }, @{ n='table'; e={ 'Status' } } | ConvertTo-Json",
                CreateNoWindow = true
            };

            using var process = Process.Start(start);
            using var reader = process.StandardOutput;

            process.EnableRaisingEvents = true;

            var fileContents = await reader.ReadToEndAsync();

            await File.WriteAllTextAsync(fileName, fileContents);
            await process.WaitForExitAsync();

            var json = await File.ReadAllTextAsync(fileName);

            return JsonSerializer.Deserialize<List<ServiceItem>>(json);

        }
        /// <summary>
        /// Get list of IP Addresses
        /// </summary>
        /// <returns></returns>
        public static async Task<List<AddressFamily>> GetAddressFamilyContainerAsJson()
        {
            const string fileName = "addressFamily.txt";

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            var start = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                Arguments = "Get-NetIPAddress -AddressFamily IPv4 | select IPaddress,Interface*  | ConvertTo-Json",
                CreateNoWindow = true
            };

            using var process = Process.Start(start);
            using var reader = process.StandardOutput;

            process.EnableRaisingEvents = true;

            var fileContents = await reader.ReadToEndAsync();

            await File.WriteAllTextAsync(fileName, fileContents);
            await process.WaitForExitAsync();

            var json = await File.ReadAllTextAsync(fileName);

            return JsonSerializer.Deserialize<List<AddressFamily>>(json);

        }
        /// <summary>
        /// Get event log details after a specified date. Since Get-EventLog formats dates
        /// unconventionally the Microsoft deserializer will blow up on the dates so we
        /// need to use 
        /// </summary>
        /// <returns></returns>
        public static async Task<List<AppEventItem>> GetApplicationEventsAsJson()
        {

            const string fileName = "Events.csv";

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }


            // Get-EventLog -LogName application -After 3/03/2021 | Select-Object Timegenerated, EntryType, Source, Message | ConvertTo-Json

            var start = new ProcessStartInfo
            {
                FileName = "powershell.exe",

                RedirectStandardOutput = true,
                Arguments = $"Get-EventLog -LogName application -After {DateTime.Now.AddDays(-1):d} | Select-Object Timegenerated, EntryType, Source, Message | ConvertTo-Json",
                CreateNoWindow = true
            };

            using var process = Process.Start(start);
            Debug.WriteLine(start.Arguments);
            using var reader = process.StandardOutput;

            process.EnableRaisingEvents = true;

            var fileContents = await reader.ReadToEndAsync();

            await File.WriteAllTextAsync(fileName, fileContents);
            await process.WaitForExitAsync();

            var json = await File.ReadAllTextAsync(fileName);

            var test = JsonSerializer.Deserialize<List<AppEventItem>>(json);

            return new List<AppEventItem>();
            //return JsonSerializer.Deserialize<List<AppEventItem>>(json);

        }
        /// <summary>
        /// Get services to web page
        /// </summary>
        public static async Task<(bool, Exception)> GetServicesAsHtml()
        {
            string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "service.html");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            var start = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                Arguments = "Get-Service | Select-Object Name, DisplayName, @{ n='Status'; e={ $_.Status.ToString() } }, @{ n='table'; e={ 'Status' } } | ConvertTo-html",
                CreateNoWindow = true
            };

            using var process = Process.Start(start);
            using var reader = process.StandardOutput;

            process.EnableRaisingEvents = true;

            var fileContents = await reader.ReadToEndAsync();

            await File.WriteAllTextAsync(fileName, fileContents);
            await process.WaitForExitAsync();

            try
            {
                ChromeLauncher.OpenLink(fileName);
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex);
            }

        }

        /// <summary>
        /// Get all services using ServiceController class, not PowerShell
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public static List<ServiceItem> GetServicesConcrete(string serviceName)
        {

            var serviceItems = ServiceController.GetServices().Select(service => new ServiceItem()
            {
                Name = service.ServiceName,
                DisplayName = service.DisplayName,
                ServiceStartMode = service.StartType
            }).ToList();

            return serviceItems;

        }
    }

}
