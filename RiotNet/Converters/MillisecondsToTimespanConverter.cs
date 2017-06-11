using System;
using Newtonsoft.Json;

namespace RiotNet.Converters
{
    /// <summary>
    /// Converts a <see cref="TimeSpan"/> to and from a number of seconds in JSON.
    /// </summary>
    public class MillisecondsToTimeSpanConverter : JsonConverter
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">The type to convert.</param>
        /// <returns><value>true</value> if this converter can convert the specified type; otherwise <value>false</value>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TimeSpan) || objectType == typeof(TimeSpan?);
        }

        /// <summary>
        /// Reads the JSON representation of the time span.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                    var seconds = (long)reader.Value;
                    return TimeSpan.FromMilliseconds(seconds);
                case JsonToken.Float:
                    var dobuleSeconds = (double)reader.Value;
                    return TimeSpan.FromMilliseconds(dobuleSeconds);
                case JsonToken.Null:
                    return null;
                default:
                    throw new JsonException("Can only deseialize TimeSpan from integer or float. Path: " + reader.Path);
            }
        }

        /// <summary>
        /// Writes the JSON representation of the time span.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The date to write.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var time = value as TimeSpan?;
            if (time == null)
                writer.WriteNull();
            else
                writer.WriteValue((long)time.Value.TotalMilliseconds);
        }
    }
}
