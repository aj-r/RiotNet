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
    /// Converts a range in JSON to a consistent CLR format.
    /// </summary>
    /// <remarks>
    /// A range value from the Riot Games API could be a list of integers, or the string "self".
    /// We want to convert the string "self" to an array containing a single zero.
    /// </remarks>
    public class RangeConverter : JsonConverter
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">The type to convert.</param>
        /// <returns><value>true</value> if this converter can convert the specified type; otherwise <value>false</value>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ListOfInt);
        }

        /// <summary>
        /// Reads the JSON representation of the ranges.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var ranges = new ListOfInt();
            switch (reader.TokenType)
            {
                case JsonToken.StartArray:
                    while (reader.Read() && reader.TokenType != JsonToken.EndArray)
                    {
                        if (reader.TokenType == JsonToken.Integer)
                            ranges.Add((int)(long)reader.Value);
                        else if (reader.TokenType == JsonToken.Float)
                            ranges.Add((int)Math.Round((double)reader.Value));
                        else
                            throw new JsonException("Unexcpected token type when reading range value: " + reader.TokenType + ". Expected Integer. Path: " + reader.Path);
                    }
                    break;
                case JsonToken.String:
                    ranges.Add(0);
                    break;
                default:
                    throw new JsonException("Can only deseialize 'range' from an array of integers, or the string 'self'. Path: " + reader.Path);
            }
            return ranges;
        }

        /// <summary>
        /// Writes the JSON representation of the ranges.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The date to write.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var ranges = value as ListOfInt;
            if (ranges == null)
            {
                writer.WriteNull();
            }
            else
            {
                if (ranges.Any(r => r != 0))
                {
                    writer.WriteStartArray();
                    foreach (var range in ranges)
                        writer.WriteValue(range);
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteValue("self");
                }
            }
        }
    }
}
