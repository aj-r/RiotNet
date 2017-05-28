using RiotNet.Models;
using System.Threading;
using System.Threading.Tasks;

namespace RiotNet
{
    public partial interface IRiotClient
    {
        /// <summary>
        /// Gets the list of mastery pages that a summoner has created. This method uses the Masteries API.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<MasteryPages> GetMasteriesBySummonerIdAsync(long summonerId, PlatformId? platformId = null, CancellationToken token = default(CancellationToken));
    }

    public partial class RiotClient
    {
        /// <summary>
        /// Gets the base URL for masteries requests.
        /// </summary>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <returns>The base URL.</returns>
        protected string GetMasteriesBaseUrl(PlatformId? platformId)
        {
            return $"https://{GetServerName(platformId)}/lol/platform/v3";
        }

        /// <summary>
        /// Gets the list of mastery pages that a summoner has created. This method uses the Masteries API.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<MasteryPages> GetMasteriesBySummonerIdAsync(long summonerId, PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<MasteryPages>($"{GetMasteriesBaseUrl(platformId)}/masteries/by-summoner/{summonerId}", token);
        }
    }
}
