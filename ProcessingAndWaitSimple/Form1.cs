using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProcessingAndWait.Classes;
using ProcessingAndWait.Classes.Helpers;
using StopWatchLibrary;

namespace ProcessingAndWait
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            RemoveFiles();
        }

        /// <summary>
        /// Remove result files from Debug folder
        /// </summary>
        private void RemoveFiles()
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
        /// <summary>
        /// Get IP address synchronously
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void GetIpAddressVersion1Button_Click(object sender, EventArgs e)
        {
            IpAddressTextBox1.Text = "";
            var ipAddress = await PowerShellOperations.GetIpAddress();
            IpAddressTextBox1.Text = ipAddress;
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
            
            await Task.Run(async () => { ipAddress = await PowerShellOperations.GetIpAddress(); });

            if (!string.IsNullOrWhiteSpace(ipAddress))
            {
                IpAddressTextBox2.Text = ipAddress;
            }
            else
            {
                IpAddressTextBox2.Text = "Failed to obtain IP address";
            }
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
    }

   
}
