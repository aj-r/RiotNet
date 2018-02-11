using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RiotNet
{
    /// <summary>
    /// Represents HTTP content in JSON format.
    /// </summary>
    public class JsonContent : HttpContent
    {
        private object content;

        /// <summary>
        /// Creates a new <see cref="JsonContent"/> instance.
        /// </summary>
        /// <param name="content">The object to serialize in JSON format.</param>
        public JsonContent(object content)
        {
            this.content = content;
            Headers.ContentType = new MediaTypeHeaderValue("application/json");
        }

        /// <inheritdoc />
        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            var serializer = JsonSerializer.Create(RiotClient.JsonSettings);
            var writer = new StreamWriter(stream);
            var jsonWriter = new JsonTextWriter(writer);
            serializer.Serialize(jsonWriter, content);
            return writer.FlushAsync();
        }

        /// <inheritdoc />
        protected override bool TryComputeLength(out long length)
        {
            length = -1;
            return false;
        }
    }
}
