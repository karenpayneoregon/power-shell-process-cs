using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PowerShellNuGet.Classes;
using PowerShellNuGet.Extensions;

namespace PowerShellNuGet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            PowerShellOperations.ProcessItemHandler+= PowerShellOperationsOnProcessItemHandler;
                
        }

        /// <summary>
        /// Event invoked for each process in <see cref="PowerShellOperations.Example1"/> and
        /// <see cref="PowerShellOperations.Example2Task"/>
        ///
        /// The method <see cref="PowerShellOperations.Example2Task"/> requires <see cref="ControlExtensions.InvokeIfRequired"/>
        /// to prevent cross threading violation while <see cref="PowerShellOperations.Example1"/> does not cause a violation
        /// 
        /// </summary>
        /// <param name="sender"></param>
        private void PowerShellOperationsOnProcessItemHandler(ProcessItem sender)
        {
            
            ResultsTextBox.InvokeIfRequired(tb =>
            {
                tb.AppendTextWithNewLines($"{sender}".RemoveExtraSpaces().Beautify());
            });
            
        }
        /// <summary>
        /// Synchronous processing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Example1Button_Click(object sender, EventArgs e)
        {
            ResultsTextBox.Text = "";
            PowerShellOperations.Example1();
        }
        /// <summary>
        /// Asynchronous processing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Example2Button_Click(object sender, EventArgs e)
        {
            ResultsTextBox.Text = "";
            await PowerShellOperations.Example2Task();
        }
    }
}
