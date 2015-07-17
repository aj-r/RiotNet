using System.IO;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;
 
namespace RiotNet
{
    /// <summary>
    /// An adapter that allows Json.Net to be used with RestSharp.
    /// </summary>
    public class RestSharpJsonNetSerializer : ISerializer, IDeserializer
    {
        /// <summary>
        /// Gets or sets the settings to use for serialization and deserialization.
        /// </summary>
        private readonly RiotClientSettings settings;

        /// <summary>
        /// Creates a new <see cref="RestSharpJsonNetSerializer"/> instance.
        /// </summary>
        internal RestSharpJsonNetSerializer(RiotClientSettings settings)
        {
            this.settings = settings;
            ContentType = "application/json";
        }
 
        /// <summary>
        /// Serializes the request as JSON.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <returns>A string representing the serialized object.</returns>
        public string Serialize(object obj)
        {
            using (var stringWriter = new StringWriter())
            using (var jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.Formatting = settings.JsonFormatting;
                jsonTextWriter.QuoteChar = '"';

                var serializer = JsonSerializer.CreateDefault(RiotClient.JsonSettings);
                serializer.Serialize(jsonTextWriter, obj);

                return stringWriter.ToString();
            }
        }

        /// <summary>
        /// Deserializes the response as JSON.
        /// </summary>
        /// <typeparam name="T">The type of object to deserialize to.</typeparam>
        /// <param name="response">The response to deserialize.</param>
        /// <returns>The deserialized object.</returns>
        public T Deserialize<T>(IRestResponse response)
        {
            using (var stringReader = new StringReader(response.Content))
            using (var jsonTextReader = new JsonTextReader(stringReader))
            {
                var serializer = JsonSerializer.CreateDefault(RiotClient.JsonSettings);
                return serializer.Deserialize<T>(jsonTextReader);
            }
        }

        /// <summary>
        /// Gets or sets the Content-Type to use for JSON requests.
        /// </summary>
        public string ContentType { get; set; }

        string ISerializer.DateFormat { get; set; }
        string ISerializer.RootElement { get; set; }
        string ISerializer.Namespace { get; set; }
        string IDeserializer.DateFormat { get; set; }
        string IDeserializer.RootElement { get; set; }
        string IDeserializer.Namespace { get; set; }
    }
}
