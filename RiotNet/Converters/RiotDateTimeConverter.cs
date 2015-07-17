using System;
using System.Globalization;
using Newtonsoft.Json;

namespace RiotNet.Converters
{
    /// <summary>
    /// Converts a <see cref="DateTime"/> to and from JSON in Riot's string-encoded date-time format.
    /// </summary>
    public class RiotDateTimeConverter : JsonConverter
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">The type to convert.</param>
        /// <returns><value>true</value> if this converter can convert the specified type; otherwise <value>false</value>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime) || objectType == typeof(DateTime?);
        }

        /// <summary>
        /// Reads the JSON representation of the date.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.String)
                throw new JsonException("Can only deseialize DateTime from string.");
            var s = (string)reader.Value;
            var time = DateTime.Parse(s, null, DateTimeStyles.None);
            return time;
        }

        /// <summary>
        /// Writes the JSON representation of the date.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The date to write.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dateTime = value as DateTime?;
            if (dateTime == null)
            {
                writer.WriteNull();
            }
            else
            {
                var s = dateTime.Value.ToString("MMM dd, yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                writer.WriteValue(s);
            }
        }
    }
}
