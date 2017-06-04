using Newtonsoft.Json;
using System;

namespace RiotNet.Converters
{
    /// <summary>
    /// Converts an enum to and from JSON. If the JSON string value does not exist in the enum, the value is still converted instead of throwing an exception. Values are serialized as numbers.
    /// </summary>
    public class WinStringConverter : JsonConverter
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">The type to convert.</param>
        /// <returns><value>true</value> if this converter can convert the specified type; otherwise <value>false</value>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(bool);
        }

        /// <summary>
        /// Reads the JSON representation of the enum.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
                return false;
            string text = reader.Value.ToString();
            return string.Equals(text, "Win", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Writes the JSON representation of the enum.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The date to write.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var win = value as bool?;
            writer.WriteValue(win == true ? "Win" : "Fail");
        }
    }
}
