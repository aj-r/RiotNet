using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RiotNet.Converters
{
    /// <summary>
    /// Converts a <see cref="DateTime"/> to and from JSON in epoch milliseconds format.
    /// </summary>
    public class EpochDateTimeConverter : DateTimeConverterBase
    {
        private static DateTime epochReferenceDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

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
            if (reader.TokenType == JsonToken.Null)
            {
                if (objectType != typeof(DateTime?))
                    throw new JsonException("Cannot deserialize null as a non-nullable DateTime.");
                return null;

            }
            if (reader.TokenType != JsonToken.Integer)
                throw new JsonException("Can only deseialize DateTime from integer representing epoch time.");
            var epochTime = (long)reader.Value;
            // Riot's "epoch time" is actually in milliseconds, not seconds.
            return epochReferenceDate.AddMilliseconds(epochTime);
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
                var d = dateTime.Value;
                if (d.Kind == DateTimeKind.Local)
                    d = d.ToUniversalTime();
                var difference = d - epochReferenceDate;
                var time = Convert.ToInt64(difference.TotalSeconds);
                writer.WriteValue(time);
            }
        }
    }
}
