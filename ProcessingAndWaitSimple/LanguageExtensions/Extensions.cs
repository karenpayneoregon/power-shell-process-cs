using System;
using System.ComponentModel;


namespace ProcessingAndWait.LanguageExtensions
{
    public static class Extensions
    {
      
        /// <summary>
        /// Determines if a control needs to be invoked to prevent a cross thread violation. This is a generic
        /// extension method
        /// </summary>
        /// <typeparam name="T">Control</typeparam>
        /// <param name="control">Control</param>
        /// <param name="action">Predicate to run</param>
        /// <example>
        /// <code title="From Form1" >
        /// private void OnTimedEvent(object source, ElapsedEventArgs e)
        /// {
        ///     ElapsedTimerLabel.InvokeIfRequired(label =>
        ///     {
        ///         label.Text = $"{e.SignalTime}";
        ///     });
        /// 
        ///     FileOperations.CheckIfNewIncomingFileIsNeeded();
        /// }
        /// </code>
        /// </example>        
        public static void InvokeIfRequired<T>(this T control, Action<T> action) where T : ISynchronizeInvoke
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new Action(() => action(control)), null);
            }
            else
            {
                action(control);
            }
        }

        /// <summary>
        /// Add asterisk for wild card to start of string
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static string PrependAsterisk(this string sender) => sender.StartsWith('.') ? $"*{sender}" : sender;
    }
}