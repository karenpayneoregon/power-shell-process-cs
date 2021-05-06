using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using PowerShellLibrary.Containers;

namespace PowerShellLibrary.Classes
{
    public class Operations
    {
        public static async Task<DateContainer> GetPartialComputerInformationTask(string fileName)
        {

            var start = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                RedirectStandardOutput = true,
                Arguments = "Get-ComputerInfo | select BiosReleaseDate,OsLocalDateTime,OsLastBootUpTime,OsUptime | ConvertTo-Json",
                CreateNoWindow = true
            };

            using var process = Process.Start(start);
            using var reader = process.StandardOutput;

            process.EnableRaisingEvents = true;

            var fileContents = await reader.ReadToEndAsync();

            await File.WriteAllTextAsync(fileName, fileContents);
            await process.WaitForExitAsync();

            var json = await File.ReadAllTextAsync(fileName);

            return JSonHelper.DeserializeObjectUnixEpochDateTime<DateContainer>(json);

        }
    }
}
