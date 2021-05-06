using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProcessingAndWait.Classes;
using ProcessingAndWait.Classes.Containers;
using ProcessingAndWait.Classes.Helpers;
using ProcessingAndWait.Forms;
using ProcessingAndWait.LanguageExtensions;
using StopWatchLibrary;

namespace ProcessingAndWait
{
    public partial class Form1 : Form
    {
        private FileHelpers _fileHelpers = new FileHelpers();
        
        public Form1()
        {
            InitializeComponent();
            Closing += OnClosing;
            
            Shown += OnShown;
            
            FileHelpers.RemoveFiles();
            
            _fileHelpers.Created += FileHelpersOnCreated;
            _fileHelpers.Start();
            
            Debug.WriteLine(DateTime.Now.AddDays(-1).ToString("d"));
            
        }

        private void OnShown(object? sender, EventArgs e)
        {
            ActiveControl = RunScriptButton;
        }

        private void FileHelpersOnCreated(object sender, FileSystemEventArgs e)
        {
            FilesListBox.InvokeIfRequired(listbox =>
            {
                listbox.Items.Add(e.Name!);
                listbox.SelectedIndex = FilesListBox.Items.Count -1;
            });

        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            _fileHelpers.Stop();
        }


        /// <summary>
        /// Get IP address synchronously
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private  void GetIpAddressVersion1Button_Click(object sender, EventArgs e)
        {
            IpAddressTextBox1.Text = "";
            IpAddressTextBox1.Text = PowerShellOperations.GetIpAddressSync();
        }
        
        /// <summary>
        /// Get IP address asynchronously
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void GetIpAddressVersion2Button_Click(object sender, EventArgs e)
        {
            IpAddressTextBox2.Text = "";
            
            string ipAddress = "";
            
            await Task.Run(async () => { ipAddress = await PowerShellOperations.GetIpAddressTask(); });

            IpAddressTextBox2.Text = !string.IsNullOrWhiteSpace(ipAddress) ? ipAddress : "Failed to obtain IP address";
            
        }
        /// <summary>
        /// In this case the file name is a parameter to the PowerShell command and
        /// more details are obtained
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void GetIpAddressVersion3Button_Click(object sender, EventArgs e)
        {
            IpItem ipAddress = new();

            await Task.Run(async () => { ipAddress = await PowerShellOperations1.GetIpAddressAsJsonTask(); });

            MessageBox.Show(!string.IsNullOrWhiteSpace(ipAddress.Ip) ? ipAddress.Details : "Operation failed");
        }
        private async void AddressFamilyButton_Click(object sender, EventArgs e)
        {
            
            FamilyListBox.DataSource = null;
            var families = await PowerShellOperations.GetAddressFamilyContainerAsJson();
            FamilyListBox.DataSource = families;
            
        }

        /// <summary>
        /// Get all services and their status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void GetServicesAsJsonButton_Click(object sender, EventArgs e)
        {
            ServicesListView.Items.Clear();

            var serviceItems = await PowerShellOperations.GetServicesAsJson();
            ServiceCountLabel.Text = serviceItems.Count.ToString();
            
            ServicesListView.BeginUpdate();

            try
            {
                foreach (var serviceItem in serviceItems)
                {
                    ServicesListView.Items.Add(new ListViewItem(serviceItem.ItemArray()));
                }

                ServicesListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                
                /*
                 * Example for finding an item (service) in the ListView and if found
                 * scroll to the item.
                 *
                 * In this case to ensure SQLEXPRESS service is running.
                 */
                var listViewItem = ServicesListView.FindItemWithText("MSSQL$SQLEXPRESS");
                if (listViewItem != null)
                {
                    var index = ServicesListView.Items.IndexOf(listViewItem);
                    ServicesListView.Items[index].Selected = true;
                    ServicesListView.EnsureVisible(index);
                }
                else
                {
                    ServicesListView.Items[0].Selected = true;
                    ServicesListView.EnsureVisible(0);
                }
                
                ActiveControl = ServicesListView;
                
            }
            finally
            {
                ServicesListView.EndUpdate();
            }

        }

        /// <summary>
        /// Get services to an html page presented in Chrome browser.
        /// The return type is named tuple which allows multiple items to be returned,
        /// in this case a bool indicating if the operation completed properly or failed
        /// and on failure return the exception. We could also return the exception text
        /// rather than the entire exception object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void GetServicesHtmlButton_Click(object sender, EventArgs e)
        {
            var (success, exception) = await PowerShellOperations.GetServicesAsHtml();

            if (!success)
            {
                MessageBox.Show($"Failed to open page\n{exception.Message}");
            }
        }

        private async void GetApplicationEventsJsonButton_Click(object sender, EventArgs e)
        {
            
            JsonTimeTextBox.Text = "";
            GetApplicationEventsJsonButton.Enabled = false;

            if (!Properties.Settings.Default.DonotShowAgain)
            {
                MessageBox.Show("This may take awhile, feel free to run other operations while waiting.");
                Properties.Settings.Default.DonotShowAgain =true;
                Properties.Settings.Default.Save();
            }
            

            try
            {
                StopWatcher.Instance.Start();
                var serviceItems = await PowerShellOperations1.GetApplicationEventsAsJson();
                JsonTimeTextBox.Text = $"{StopWatcher.Instance.ElapsedFormatted}";

                var f = new EventsForm(serviceItems);

                f.ShowDialog();
            }
            finally
            {
                GetApplicationEventsJsonButton.Enabled = true;
            }

        }
        /// <summary>
        /// Simple code sample to grab information from the system registry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void RunScriptButton_Click(object sender, EventArgs e)
        {
            const string fileName = "regFile.txt";
            var results = await PowerShellOperations1.GetRegistryInformationAsJson(fileName);
            if (results)
            {
                var lines = FileHelpers.ReadAllLines(fileName);
                MessageBox.Show(lines.Count.ToString());
            }
            else
            {
                MessageBox.Show("Operation failed");
            }

        }
        /// <summary>
        /// Get time zone information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void TimeZoneButton_Click(object sender, EventArgs e)
        {
            var timeZone = await PowerShellOperations1.GetTimeZoneTask();
            MessageBox.Show($"{timeZone.StandardName}\nSupports daylight savings {timeZone.SupportsDaylightSavingTime.ToYesNoString()}");
        }

        /// <summary>
        /// Get computer information
        /// Note OsUpTime has a ToString override
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ComputerInformationButton_Click(object sender, EventArgs e)
        {
            var details = await PowerShellOperations1.GetComputerInformationTask();

            MessageBox.Show($"Up time\n{details.OsUptime}\n{details.OsLocalDateTime.ToString("G")}");
        }

        private void OpenExecutableFolder_Click(object sender, EventArgs e)
        {
            FileHelpers.OpenExecutableFolder();
        }
        /// <summary>
        /// Used when Windows marks file(s) with mark of the web which usually happens
        /// when downloading files from the web such as a Visual Studio project.
        ///
        /// To test, pass in a folder name that exists with one or more files with
        /// the mark of the web, run, inspect the files via their property dialog to
        /// confirm the code worked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UnblockFolderButton_Click(object sender, EventArgs e)
        {
            PowerShellOperations1.UnblockFiles("C:\\OED\\DataValidationWindowsForms1");
        }
    }
}
