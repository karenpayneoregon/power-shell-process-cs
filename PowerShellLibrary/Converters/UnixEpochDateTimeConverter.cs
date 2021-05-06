using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace PowerShellLibrary.Converters
{
    /// <summary>
    /// Used for deserializing json with Microsoft date format.
    /// </summary>
    /// <remarks>
    /// This class was code by Microsoft
    /// https://docs.microsoft.com/en-us/dotnet/standard/datetime/system-text-json-support
    ///
    /// Karen Payne took advantage of current C# features
    /// </remarks>
    public sealed class UnixEpochDateTimeConverter : JsonConverter<DateTime>
    {
        static readonly DateTime epochDateTime = new(1970, 1, 1, 0, 0, 0);
        static readonly Regex regex = new("^/Date\\(([^+-]+)\\)/$", RegexOptions.CultureInvariant);

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {

            string formatted = reader.GetString();
            Match match = regex.Match(formatted!);

            return !match.Success || !long.TryParse(match.Groups[1].Value, NumberStyles.Integer, CultureInfo.InvariantCulture, out long unixTime) ?
                throw new JsonException() :
                epochDateTime.AddMilliseconds(unixTime);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            long unixTime = Convert.ToInt64((value - epochDateTime).TotalMilliseconds);

            var formatted = FormattableString.Invariant($"/Date({unixTime})/");
            writer.WriteStringValue(formatted);

        }
    }
}