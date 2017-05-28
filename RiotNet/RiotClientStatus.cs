using RiotNet.Models;
using System.Threading;
using System.Threading.Tasks;

namespace RiotNet
{
    public partial interface IRiotClient
    {
        /// <summary>
        /// Gets the data for the shard for the specified platform. This method uses the LoL Status API.
        /// </summary>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<ShardStatus> GetShardDataAsync(PlatformId? platformId = null, CancellationToken token = default(CancellationToken));
    }

    public partial class RiotClient
    {
        /// <summary>
        /// Gets the base URL for status requests.
        /// </summary>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <returns>The base URL.</returns>
        protected string GetStatusBaseUrl(PlatformId? platformId)
        {
            return $"https://{GetServerName(platformId)}/lol/status/v3";
        }

        /// <summary>
        /// Gets the data for the shard for the specified platform. This method uses the LoL Status API.
        /// </summary>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<ShardStatus> GetShardDataAsync(PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<ShardStatus>($"{GetStatusBaseUrl(platformId)}/shard-data", token);
        }
    }
}
