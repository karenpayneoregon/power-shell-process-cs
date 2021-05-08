using System;
using static System.DateTime;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerShellLibrary.LanguageExtensions
{
    public static class HelperExtensions
    {
        public static DateTime UnixTimeStampToDateTime(this double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
        public static DateTime RemoveMilliseconds(this DateTime dateTime) =>
            ParseExact(dateTime.ToString("yyyy-MM-dd HH:mm:ss"), "yyyy-MM-dd HH:mm:ss", null);
        public static DateTime RemoveSeconds(this DateTime dateTime) =>
            ParseExact(dateTime.ToString("yyyy-MM-dd HH:mm"), "yyyy-MM-dd HH:mm", null);

        public static DateTime RemoveMillisecondsAndSeconds(this DateTime dateTime) =>
            ParseExact(dateTime.ToString("yyyy-MM-dd HH:mm"), "yyyy-MM-dd HH:mm", null);
    }
}
