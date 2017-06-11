using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace RiotNet.Converters
{
    /// <summary>
    /// Converts a <see cref="DateTime"/> to and from JSON in epoch milliseconds format. Can also deserialize from a string in ISO format.
    /// </summary>
    public class EpochDateTimeConverter : IsoDateTimeConverter
    {
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
                if (objectType != typeof(DateTime?) && objectType != typeof(DateTimeOffset?))
                    throw new JsonSerializationException("Cannot deserialize null as a non-nullable DateTime.");
                return null;
            }
            long epochTime;
            if (reader.TokenType == JsonToken.String)
            {
                if (!long.TryParse((string)reader.Value, out epochTime))
                    return base.ReadJson(reader, objectType, existingValue, serializer);
            }
            else if (reader.TokenType == JsonToken.Date)
            {
                return base.ReadJson(reader, objectType, existingValue, serializer);
            }
            else if (reader.TokenType != JsonToken.Integer)
            {
                throw new JsonSerializationException("Unexpected token found when parsing date. Expected Integer, String, or Date; got " + reader.TokenType + ".");
            }
            else
            {
                epochTime = (long)reader.Value;
            }
            // Riot's "epoch time" is actually in milliseconds, not seconds.
            var dateTime = Conversions.EpochMillisecondsToDateTime(epochTime);
            if (objectType == typeof(DateTimeOffset) || objectType == typeof(DateTimeOffset?))
                return new DateTimeOffset(dateTime);
            return dateTime;
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
                var dateTimeOffset = value as DateTimeOffset?;
                if (dateTimeOffset != null)
                    dateTime = dateTimeOffset.Value.UtcDateTime;
            }
            if (dateTime == null)
            {
                writer.WriteNull();
            }
            else
            {
                var time = Conversions.DateTimeToEpochMilliseconds(dateTime.Value);
                writer.WriteValue(time);
            }
        }
    }
}
