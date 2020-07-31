// Modified example converter from dotnet repo
// https://github.com/dotnet/runtime/issues/30776

using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace api.Converters
{
    public class DateConverter : JsonConverter<DateTime>
    {
        private const string _dateFormat = "MM/dd/yyyy";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {

            string dateString = reader.GetString();
            DateTime parsedDate;

            // If the date can't be parsed throw exception
            if (!DateTime.TryParseExact(dateString, _dateFormat, null, DateTimeStyles.None, out parsedDate))
            {
                throw new Exception("Unexpected value format, unable to parse DateTime format MM/DD/YYYY.");
            }

            return parsedDate;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            // https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings
            writer.WriteStringValue(value.ToString(_dateFormat));
        }
    }
}