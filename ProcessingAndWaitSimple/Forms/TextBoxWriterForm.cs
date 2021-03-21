using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProcessingAndWait.Classes;
using ProcessingAndWait.Classes.Helpers;
using static ProcessingAndWait.Classes.Helpers.Dialogs;

namespace ProcessingAndWait.Forms
{
    /*
     * Redirect Console output
     */
    public partial class TextBoxWriterForm : Form
    {
        private readonly TextWriter _textWriter;
        public TextBoxWriterForm()
        {
            InitializeComponent();
            
            _textWriter = new TextBoxWriter(textBox1);
            Console.SetOut(_textWriter);
           
            
            Shown += OnShown;
        }

        private async void OnShown(object sender, EventArgs e)
        {
            Console.WriteLine($@"Today: {DateTime.Now:D}");
            Console.WriteLine();
            
            Console.WriteLine("Addresses");

            var families = await PowerShellOperations.GetAddressFamilyContainerAsJson();

            foreach (var family in families)
            {
                Console.WriteLine(family);
            }

            Console.WriteLine();
            
            Console.WriteLine("Up time");

            var details = await PowerShellOperations1.GetComputerInformationTask();
            Console.WriteLine($"Up time\n{details.OsUptime}");

            Console.WriteLine();

            Console.WriteLine("Visual Studio path");
            var vsPath = Environment.GetEnvironmentVariable("VisualStudioDir");

            Console.WriteLine(string.IsNullOrWhiteSpace(vsPath) ? "Not installed" : vsPath);

            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            
            if (Question("Clear text box?"))
            {
                textBox1.Clear();
            }
            
        }
    }
}
