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
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<ShardStatus> GetShardDataAsync(string platformId = null, CancellationToken token = default(CancellationToken));
    }

    public partial class RiotClient
    {
        private const string statusBasePath = "status/v3";

        /// <summary>
        /// Gets the data for the shard for the specified platform. This method uses the LoL Status API.
        /// </summary>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<ShardStatus> GetShardDataAsync(string platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<ShardStatus>($"{statusBasePath}/shard-data", $"{statusBasePath}/shard-data", platformId, token);
        }
    }
}
