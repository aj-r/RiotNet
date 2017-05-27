using RiotNet.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RiotNet
{
    public partial interface IRiotClient
    {
        /// <summary>
        /// Gets information about a summoner's mastery of a champion. This method uses the Champion Mastery API.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <param name="championId">The champion ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<ChampionMastery> GetChampionMasteryAsync(long summonerId, long championId, PlatformId? platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets information about a summoner's mastery of all champions they have played. This method uses the Champion Mastery API.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<List<ChampionMastery>> GetChampionMasteriesAsync(long summonerId, PlatformId? platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets a summoner's champion mastery score (the sum of the champion levels of all champions for that summoner). This method uses the Champion Mastery API.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<int> GetChampionMasteryScoreAsync(long summonerId, PlatformId? platformId = null, CancellationToken token = default(CancellationToken));
    }

    public partial class RiotClient
    {
        /// <summary>
        /// Gets the base URL for champion mastery requests.
        /// </summary>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <returns>The base URL.</returns>
        protected string GetChampionMasteryBaseUrl(PlatformId? platformId)
        {
            return $"https://{GetServerName(platformId)}/lol/champion-mastery/v3";
        }

        public Task<ChampionMastery> GetChampionMasteryAsync(long summonerId, long championId, PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<ChampionMastery>($"{GetChampionMasteryBaseUrl(platformId)}/champion-masteries/by-summoner/{summonerId}/by-champion/{championId}", token);
        }

        public Task<List<ChampionMastery>> GetChampionMasteriesAsync(long summonerId, PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<List<ChampionMastery>>($"{GetChampionMasteryBaseUrl(platformId)}/champion-masteries/by-summoner/{summonerId}", token);
        }

        public Task<int> GetChampionMasteryScoreAsync(long summonerId, PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<int>($"{GetChampionMasteryBaseUrl(platformId)}/scores/by-summoner/{summonerId}", token);
        }
    }
}
