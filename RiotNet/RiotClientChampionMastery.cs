using RiotNet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiotNet
{
    public partial class RiotClient
    {
        /// <summary>
        /// Gets information about a summoner's mastery of a champion. This method uses the Champion Mastery API.
        /// </summary>
        /// <param name="playerId">The summoner ID.</param>
        /// <param name="championId">The champion ID.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<ChampionMastery> GetChampionMasteryAsync(long playerId, long championId)
        {
            return GetAsync<ChampionMastery>($"{mainBaseUrl}/championmastery/location/{platformId}/player/{playerId}/champion/{championId}");
        }

        /// <summary>
        /// Gets information about a summoner's mastery of all champions they have played. This method uses the Champion Mastery API.
        /// </summary>
        /// <param name="playerId">The summoner ID.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<List<ChampionMastery>> GetChampionMasteriesAsync(long playerId)
        {
            return GetAsync<List<ChampionMastery>>($"{mainBaseUrl}/championmastery/location/{platformId}/player/{playerId}/champion");
        }

        /// <summary>
        /// Gets a summoner's champion mastery score (the sum of the champion levels of all champions for that summoner). This method uses the Champion Mastery API.
        /// </summary>
        /// <param name="playerId">The summoner ID.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<int> GetChampionMasteryScoreAsync(long playerId)
        {
            return GetAsync<int>($"{mainBaseUrl}/championmastery/location/{platformId}/player/{playerId}/score");
        }
        
        /// <summary>
        /// Gets information about a summoner's mastery of their most mastered champions. This method uses the Champion Mastery API.
        /// </summary>
        /// <param name="playerId">The summoner ID.</param>
        /// <param name="count">The number of entries to retrieve. Defaults to 3.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<List<ChampionMastery>> GetChampionMasteryTopChampionsAsync(long playerId, int? count = null)
        {
            return GetAsync<List<ChampionMastery>>($"{mainBaseUrl}/championmastery/location/{platformId}/player/{playerId}/topchampions");
        }
    }
}
