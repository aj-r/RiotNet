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
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<ChampionMastery> GetChampionMasteryAsync(long summonerId, long championId, string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets information about a summoner's mastery of all champions they have played. This method uses the Champion Mastery API.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<List<ChampionMastery>> GetChampionMasteriesAsync(long summonerId, string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets a summoner's champion mastery score (the sum of the champion levels of all champions for that summoner). This method uses the Champion Mastery API.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<int> GetChampionMasteryScoreAsync(long summonerId, string platformId = null, CancellationToken token = default(CancellationToken));
    }

    public partial class RiotClient
    {
        private const string championMasteryBasePath = "champion-mastery/v3";

        /// <summary>
        /// Gets information about a summoner's mastery of a champion. This method uses the Champion Mastery API.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <param name="championId">The champion ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<ChampionMastery> GetChampionMasteryAsync(long summonerId, long championId, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<ChampionMastery>($"{championMasteryBasePath}/champion-masteries/by-summoner/{summonerId}/by-champion/{championId}", $"{championMasteryBasePath}/champion-masteries/by-summoner/{{summonerId}}/by-champion/{{championId}}", platformId, token);
        }

        /// <summary>
        /// Gets information about a summoner's mastery of all champions they have played. This method uses the Champion Mastery API.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<List<ChampionMastery>> GetChampionMasteriesAsync(long summonerId, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<List<ChampionMastery>>($"{championMasteryBasePath}/champion-masteries/by-summoner/{summonerId}", $"{championMasteryBasePath}/champion-masteries/by-summoner/{{summonerId}}", platformId, token);
        }

        /// <summary>
        /// Gets a summoner's champion mastery score (the sum of the champion levels of all champions for that summoner). This method uses the Champion Mastery API.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<int> GetChampionMasteryScoreAsync(long summonerId, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<int>($"{championMasteryBasePath}/scores/by-summoner/{summonerId}", $"{championMasteryBasePath}/scores/by-summoner/{{summonerId}}", platformId, token);
        }
    }
}
