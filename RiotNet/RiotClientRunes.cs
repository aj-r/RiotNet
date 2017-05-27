using RiotNet.Models;
using System.Threading;
using System.Threading.Tasks;

namespace RiotNet
{
    public partial interface IRiotClient
    {
        /// <summary>
        /// Gets the list of rune pages that a summoner has created. This method uses the Runes API.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<RunePages> GetRunesBySummonerIdAsync(long summonerId, PlatformId? platformId = null, CancellationToken token = default(CancellationToken));
    }

    public partial class RiotClient
    {
        /// <summary>
        /// Gets the base URL for runes requests.
        /// </summary>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <returns>The base URL.</returns>
        protected string GetRunesBaseUrl(PlatformId? platformId)
        {
            return $"https://{GetServerName(platformId)}/lol/platform/v3";
        }

        public Task<RunePages> GetRunesBySummonerIdAsync(long summonerId, PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<RunePages>($"{GetRunesBaseUrl(platformId)}/runes/by-summoner/{summonerId}", token);
        }
    }
}
