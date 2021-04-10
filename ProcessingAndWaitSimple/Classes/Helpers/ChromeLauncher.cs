using System;
using System.Diagnostics;
using Microsoft.Win32;

namespace ProcessingAndWait.Classes.Helpers
{
    /// <summary>
    /// For opening a page in Chrome browser
    /// </summary>
    /// <remarks>
    /// * If Chrome.exe was in the path this class is not needed.
    /// * If the user running the app does not have read permissions to the registry
    ///   a runtime exception will be thrown.
    /// </remarks>
    public static class ChromeLauncher
    {
        private const string ChromeAppKey = @"\Software\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe";

        private static string ChromeAppFileName =>
            (string)(Registry.GetValue($"HKEY_LOCAL_MACHINE{ChromeAppKey}", "", null) ??
                     Registry.GetValue($"HKEY_CURRENT_USER{ChromeAppKey}"  , "", null));

        /// <summary>
        /// Open link or page
        /// </summary>
        /// <param name="url">page to display</param>
        public static void OpenLink(string url)
        {
            var chromeAppFileName = ChromeAppFileName;
            
            if (string.IsNullOrWhiteSpace(chromeAppFileName))
            {
                throw new Exception("Could not find chrome.exe!!!");
            }
            
            Process.Start(chromeAppFileName, url);
        }
    }
}