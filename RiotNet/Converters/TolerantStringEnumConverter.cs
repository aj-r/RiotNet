using Newtonsoft.Json;

namespace RiotNet.Converters
{
    /// <summary>
    /// Converts an enum to and from JSON. If the JSON string value does not exist in the enum, the value is converted to -1 instead of throwing an exception. Values are serialized as strings.
    /// </summary>
    public class TolerantStringEnumConverter : TolerantIntEnumConverter
    {
        /// <summary>
        /// Writes the JSON representation of the enum.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The date to write.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value != null)
                writer.WriteValue(value.ToString());
            else
                writer.WriteNull();
        }
    }
}
