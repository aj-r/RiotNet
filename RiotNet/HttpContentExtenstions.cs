using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace RiotNet
{
    public static class HttpContentExtenstions
    {
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
