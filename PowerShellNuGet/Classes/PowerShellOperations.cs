using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;

namespace PowerShellNuGet.Classes
{
    /// <summary>
    /// Examples for working with PowerShell where original code was taken from
    /// https://docs.microsoft.com/en-us/powershell/scripting/developer/hosting/adding-and-invoking-commands?view=powershell-7.1
    /// and modified for this article
    /// </summary>
    public class PowerShellOperations
    {
        public delegate void OnProcess(ProcessItem sender);
        /// <summary>
        /// Raised event when invoking a pipeline
        /// </summary>
        public static event OnProcess ProcessItemHandler;

        /// <summary>
        /// Synchronous processing
        /// </summary>
        public static void Example1()
        {
            var ps = PowerShell.Create().AddCommand("Get-Process");
            IAsyncResult pipeAsyncResult = ps.BeginInvoke();

            foreach (PSObject result in ps.EndInvoke(pipeAsyncResult))
            {

                ProcessItemHandler?.Invoke(new ProcessItem()
                {
                    Value = $"{result.Members["ProcessName"].Value,-20}{result.Members["Id"].Value}"
                });
                
            }
        }

        /// <summary>
        /// Asynchronous processing
        /// </summary>
        /// <returns></returns>
        public static async Task Example2Task()
        {
            await Task.Run(async () =>
            {
                await Task.Delay(0);
                var ps = PowerShell.Create().AddCommand("Get-Process");

                var pipeAsyncResult = ps.BeginInvoke();

                foreach (var result in ps.EndInvoke(pipeAsyncResult))
                {
                    
                    ProcessItemHandler?.Invoke(new ProcessItem()
                    {
                        Value = $"{result.Members["ProcessName"].Value,-20}{result.Members["Id"].Value}"
                    });

                }

            });

        }

        static readonly string ScriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "runner.ps1");
        /// <summary>
        /// Run a PowerShell script
        /// </summary>
        /// <returns></returns>
        public static string RunScript()
        {
            // create PowerShell runspace
            var runspace = RunspaceFactory.CreateRunspace();

            // open it
            runspace.Open();

            // create a pipeline and feed it the script text
            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(ScriptPath);
            
            pipeline.Commands.Add("Out-String");

            // execute the script
            var results = pipeline.Invoke();

            // close the runspace
            runspace.Close();

            // convert the script result into a single string
            StringBuilder stringBuilder = new();
            
            foreach (var psObject in results)
            {
                stringBuilder.AppendLine(psObject.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}
