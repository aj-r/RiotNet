using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RiotNet.Models;

namespace RiotNet.Converters
{
    /// <summary>
    /// Converts a <see cref="PlayerPosition"/> in JSON to a consistent CLR format.
    /// </summary>
    public class PlayerPositionConverter : JsonConverter
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">The type to convert.</param>
        /// <returns><value>true</value> if this converter can convert the specified type; otherwise <value>false</value>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(PlayerPosition) || objectType == typeof(PlayerPosition?);
        }

        /// <summary>
        /// Reads the JSON representation of the PlayerPosition.
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
                case JsonToken.Null:
                    return null;
                case JsonToken.Integer:
                    return (PlayerPosition)(long)reader.Value;
                case JsonToken.String:
                    PlayerPosition p;
                    var stringValue = (string)reader.Value;
                    if (Enum.TryParse(stringValue, out p))
                        return p;
                    // "BOTTOM" and "MID" are also valid values, even though they are not technincally members of the enum.
                    if (stringValue == "BOTTOM")
                        return PlayerPosition.BOT;
                    if (stringValue == "MID")
                        return PlayerPosition.MIDDLE;
                    throw new JsonException("'" + stringValue + "' is not a valid PlayerPosition. Path: " + reader.Path);
                default:
                    throw new JsonException("Unexpected token reading PlayerPosition. Expected Integer or String, but got " + reader.TokenType + ". Path: " + reader.Path);
            }
        }

        /// <summary>
        /// Writes the JSON representation of the PlayerPosition.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The date to write.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var playerPosition = value as PlayerPosition?;
            if (playerPosition == null)
            {
                writer.WriteNull();
            }
            else
            {
                writer.WriteValue((int)playerPosition.Value);
            }
        }
    }
}
