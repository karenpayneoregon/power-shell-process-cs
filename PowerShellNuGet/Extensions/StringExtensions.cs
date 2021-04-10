using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation.Remoting;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PowerShellNuGet.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Determine if string is empty
        /// </summary>
        /// <param name="sender">String to test if null or whitespace</param>
        /// <returns>true if empty or false if not empty</returns>
        [DebuggerStepThrough]
        public static bool IsNullOrWhiteSpace(this string sender) => string.IsNullOrWhiteSpace(sender);
        //[DebuggerStepThrough]
        public static string RemoveExtraSpaces(this string sender, string replacement = " ")
        {
            var count = sender.Count(x => x == ' ');
            
            if (count == 0)
            {
                sender.AlphaToInteger(out var item);
                sender = sender.Replace(item.ToString(), $"  {item}");
            }
            
            var options = RegexOptions.None;
            var regex = new Regex("[ ]{2,}", options);
            var result = regex.Replace(sender, replacement);
            
            return result;

        }
        //[DebuggerStepThrough]
        public static string Beautify(this string sender)
        {
            var parts = sender.Split(' ');
            
            /*
             * If we hit the else I'd consider fringe cases for this example,
             * for real life this would be done different although and have
             * the final results in a ListView.
             *
             * A good example to not use a ternary operator.
             */
            string result;
            if (parts.Length == 2)
            {
                result = $"{parts[0],-70},{parts[1]}";
            }
            else
            {
                result = sender;
            }

            return result.Replace(",", "");
        }

        /// <summary>
        /// Get numbers from string
        /// </summary>
        /// <param name="text"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool AlphaToInteger(this string text, out int result)
        {
            var value = Regex.Replace(text, "[^0-9]", "");
            return int.TryParse(value, out result);
        }
    }
}
