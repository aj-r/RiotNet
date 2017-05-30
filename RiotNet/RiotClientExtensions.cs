using RiotNet.Models;
using System.Threading;
using System.Threading.Tasks;

namespace RiotNet
{
    /// <summary>
    /// Extension methods for the <see cref="IRiotClient"/> interface.
    /// </summary>
    public static class RiotClientExtensions
    {
        /// <summary>
        /// Gets information about the current game a summoner is playing. This is an alias for <see cref="IRiotClient.GetActiveGameBySummonerIdAsync"/>.
        /// </summary>
        /// <param name="riotClient">The IRiotClient instance.</param>
        /// <param name="summonerId">The summoner ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="IRiotClient.PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public static Task<CurrentGameInfo> GetCurrentGameBySummonerIdAsync(this IRiotClient riotClient, long summonerId, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            return riotClient.GetActiveGameBySummonerIdAsync(summonerId, platformId, token);
        }
        /// <summary>
        /// Gets the status of the shard for the specified platform. This is an alias for <see cref="IRiotClient.GetShardDataAsync"/>.
        /// </summary>
        /// <param name="riotClient">The IRiotClient instance.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="IRiotClient.PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public static Task<ShardStatus> GetShardStatusAsync(this IRiotClient riotClient, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            return riotClient.GetShardDataAsync(platformId, token);
        }
    }
}
