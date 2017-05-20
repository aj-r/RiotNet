using Newtonsoft.Json;
using RiotNet.Models;
using System;
using System.Reflection;

namespace RiotNet.Converters
{
    /// <summary>
    /// Converts a platform ID to and from JSON. A platform ID of "NA" (for old summoners) will be interpreted as NA1.
    /// </summary>
    public class PlatformIdConverter : TolerantStringEnumConverter
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">The type to convert.</param>
        /// <returns><value>true</value> if this converter can convert the specified type; otherwise <value>false</value>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(PlatformId?).GetTypeInfo().IsAssignableFrom(objectType);
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
            if (reader.TokenType == JsonToken.String)
            {
                string enumText = reader.Value.ToString();
                if (enumText == "NA")
                    return PlatformId.NA1;
            }
            return base.ReadJson(reader, objectType, existingValue, serializer);
        }
    }
}
