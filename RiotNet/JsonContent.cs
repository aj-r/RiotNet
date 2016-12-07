using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RiotNet
{
    public class JsonContent : HttpContent
    {
        private object content;

        /// <summary>
        /// Initializes a new instance of the <see cref="PushStreamContent"/> class. The
        /// <paramref name="onStreamAvailable"/> action is called when an output stream
        /// has become available allowing the action to write to it directly. When the 
        /// stream is closed, it will signal to the content that is has completed and the 
        /// HTTP request or response will be completed.
        /// </summary>
        /// <param name="onStreamAvailable">The action to call when an output stream
        /// is available. Close the stream to complete the HTTP request or response.</param>
        public JsonContent(object content)
        {
            this.content = content;
            Headers.ContentType = new MediaTypeHeaderValue("application/json");
        }

        /// <inheritdoc />
        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            var serializeToStreamTask = new TaskCompletionSource<bool>();

            var serializer = JsonSerializer.Create(RiotClient.JsonSettings);
            var writer = new StreamWriter(stream);
            serializer.Serialize(writer, content);

            return Task.FromResult(true);
        }

        /// <inheritdoc />
        protected override bool TryComputeLength(out long length)
        {
            length = -1;
            return false;
        }
    }
}
