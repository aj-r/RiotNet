using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace RiotNet
{
    /// <summary>
    /// RiotNet extensions for HttpContent.
    /// </summary>
    public static class HttpContentExtenstions
    {
        /// <summary>
        /// Reads JSON content and deserializes it as the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the object to deserialize.</typeparam>
        /// <param name="content">An HttpContent containing JSON data.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public static async Task<T> ReadAsAsync<T>(this HttpContent content)
        {
            var serializer = JsonSerializer.Create(RiotClient.JsonSettings);

            using (var stream = await content.ReadAsStreamAsync().ConfigureAwait(false))
            using (var reader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return serializer.Deserialize<T>(jsonReader);
            }
        }
    }
}
