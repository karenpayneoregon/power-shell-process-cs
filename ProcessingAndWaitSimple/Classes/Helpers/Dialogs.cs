﻿using System.Windows.Forms;

namespace ProcessingAndWait.Classes.Helpers
{
    public static class Dialogs
    {

        public static bool Question(string text)
        {
            return (MessageBox.Show(
                text,
                Application.ProductName,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes);
        }
    }
}