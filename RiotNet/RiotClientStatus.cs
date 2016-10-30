using RiotNet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiotNet
{
    public partial class RiotClient
    {
        /// <summary>
        /// Gets the currently supported version of the LoL Status API that the client communicates with.
        /// </summary>
        public string LolStatusApiVersion { get { return "v1.0"; } }

        /// <summary>
        /// Gets the list of shards for all reagions. This method uses the LoL Status API.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<List<Shard>> GetShardsAsync()
        {
            return GetAsync<List<Shard>>($"{statusBaseUrl}/shards", useApiKey: false);
        }

        /// <summary>
        /// Gets the status of the shard for the current region. This method uses the LoL Status API.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<ShardStatus> GetShardStatusAsync()
        {
            return GetShardStatusAsync(region);
        }

        /// <summary>
        /// Gets the status of the shard for the specified region. This method uses the LoL Status API.
        /// </summary>
        /// <param name="region">The region for the shard.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<ShardStatus> GetShardStatusAsync(Region region)
        {
            return GetAsync<ShardStatus>($"{statusBaseUrl}/shards/{region}");
        }
    }
}
