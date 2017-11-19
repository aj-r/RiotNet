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
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<RunePages> GetRunesBySummonerIdAsync(long summonerId, string platformId = null, CancellationToken token = default(CancellationToken));
    }

    public partial class RiotClient
    {
        private const string runesBasePath = "platform/v3";

        /// <summary>
        /// Gets the list of rune pages that a summoner has created. This method uses the Runes API.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<RunePages> GetRunesBySummonerIdAsync(long summonerId, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<RunePages>($"{runesBasePath}/runes/by-summoner/{summonerId}", $"{runesBasePath}/runes/by-summoner/{{summonerId}}", platformId, token);
        }
    }
}
