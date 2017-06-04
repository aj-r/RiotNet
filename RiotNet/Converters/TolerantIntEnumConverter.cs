using Newtonsoft.Json;
using System;
using System.Linq;
using System.Reflection;

namespace RiotNet.Converters
{
    /// <summary>
    /// Converts an enum to and from JSON. If the JSON string value does not exist in the enum, the value is still converted instead of throwing an exception. Values are serialized as numbers.
    /// </summary>
    public class TolerantIntEnumConverter : JsonConverter
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">The type to convert.</param>
        /// <returns><value>true</value> if this converter can convert the specified type; otherwise <value>false</value>.</returns>
        public override bool CanConvert(Type objectType)
        {
            var type = IsNullableType(objectType) ? Nullable.GetUnderlyingType(objectType) : objectType;
            return type.GetTypeInfo().IsEnum;
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
            var isNullable = IsNullableType(objectType);
            var enumType = isNullable ? Nullable.GetUnderlyingType(objectType) : objectType;

            if (reader.TokenType == JsonToken.Integer)
            {
                // Note that Enum.ToObject will succeed even if the value is not in range of the enum.
                return Enum.ToObject(enumType, reader.Value);
            }
            else if (reader.TokenType == JsonToken.String)
            {
                string enumText = reader.Value.ToString();

                if (!string.IsNullOrEmpty(enumText))
                {
                    var names = Enum.GetNames(enumType);
                    var match = names.FirstOrDefault(n => string.Equals(n, enumText, StringComparison.OrdinalIgnoreCase));

                    if (match != null)
                        return Enum.Parse(enumType, match);
                }
            }

            // Value not found.
            if (isNullable)
                return null;

            // We can't return null for non-nullable types... use -1 to indicate that the value was not found.
            return Enum.ToObject(enumType, -1);
        }

        /// <summary>
        /// Writes the JSON representation of the enum.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The date to write.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }

        private static bool IsNullableType(Type t)
        {
            return t.GetTypeInfo().IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
    }
}
