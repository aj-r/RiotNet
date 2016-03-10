using RestSharp;
using RiotNet.Models;
using System.Threading.Tasks;
using System.Globalization;
using System.Collections.Generic;

namespace RiotNet
{
    public partial class RiotClient
    {
        private IRestRequest GetChampionMasteryRequest(long playerId, long championId)
        {
            var request = Get("championmastery/location/{platformId}/player/{playerId}/champion/{championId}");
            request.AddUrlSegment("playerId", playerId.ToString(CultureInfo.InvariantCulture));
            request.AddUrlSegment("championId", championId.ToString(CultureInfo.InvariantCulture));
            return request;
        }

        /// <summary>
        /// Gets information about a summoner's mastery of a champion. This method uses the Champion Mastery API.
        /// </summary>
        /// <param name="playerId">The summoner ID.</param>
        /// <param name="championId">The champion ID.</param>
        /// <returns>The champion mastery information.</returns>
        public ChampionMastery GetChampionMastery(long playerId, long championId)
        {
            return Execute<ChampionMastery>(GetChampionMasteryRequest(playerId, championId));
        }

        /// <summary>
        /// Gets information about a summoner's mastery of a champion. This method uses the Champion Mastery API.
        /// </summary>
        /// <param name="playerId">The summoner ID.</param>
        /// <param name="championId">The champion ID.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<ChampionMastery> GetChampionMasteryAsync(long playerId, long championId)
        {
            return ExecuteAsync<ChampionMastery>(GetChampionMasteryRequest(playerId, championId));
        }

        private IRestRequest GetChampionMasteriesRequest(long playerId)
        {
            var request = Get("championmastery/location/{platformId}/player/{playerId}/champions");
            request.AddUrlSegment("playerId", playerId.ToString(CultureInfo.InvariantCulture));
            return request;
        }

        /// <summary>
        /// Gets information about a summoner's mastery of all champions they have played. This method uses the Champion Mastery API.
        /// </summary>
        /// <param name="playerId">The summoner ID.</param>
        /// <returns>The champion mastery information.</returns>
        public List<ChampionMastery> GetChampionMasteries(long playerId)
        {
            return Execute<List<ChampionMastery>>(GetChampionMasteriesRequest(playerId));
        }

        /// <summary>
        /// Gets information about a summoner's mastery of all champions they have played. This method uses the Champion Mastery API.
        /// </summary>
        /// <param name="playerId">The summoner ID.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<List<ChampionMastery>> GetChampionMasteriesAsync(long playerId)
        {
            return ExecuteAsync<List<ChampionMastery>>(GetChampionMasteriesRequest(playerId));
        }

        private IRestRequest GetChampionMasteryScoreRequest(long playerId)
        {
            var request = Get("championmastery/location/{platformId}/player/{playerId}/score");
            request.AddUrlSegment("playerId", playerId.ToString(CultureInfo.InvariantCulture));
            return request;
        }

        /// <summary>
        /// Gets a summoner's champion mastery score (the sum of the champion levels of all champions for that summoner). This method uses the Champion Mastery API.
        /// </summary>
        /// <param name="playerId">The summoner ID.</param>
        /// <returns>The champion mastery information.</returns>
        public int GetChampionMasteryScore(long playerId)
        {
            return Execute<int>(GetChampionMasteryScoreRequest(playerId));
        }

        /// <summary>
        /// Gets a summoner's champion mastery score (the sum of the champion levels of all champions for that summoner). This method uses the Champion Mastery API.
        /// </summary>
        /// <param name="playerId">The summoner ID.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<int> GetChampionMasteryScoreAsync(long playerId)
        {
            return ExecuteAsync<int>(GetChampionMasteryScoreRequest(playerId));
        }

        private IRestRequest GetChampionMasteryTopChampionsRequest(long playerId, int? count)
        {
            var request = Get("championmastery/location/{platformId}/player/{playerId}/topchampions");
            request.AddUrlSegment("playerId", playerId.ToString(CultureInfo.InvariantCulture));
            if (count != null)
                request.AddQueryParameter("count", count.Value.ToString(CultureInfo.InvariantCulture));
            return request;
        }

        /// <summary>
        /// Gets information about a summoner's mastery of their most mastered champions. This method uses the Champion Mastery API.
        /// </summary>
        /// <param name="playerId">The summoner ID.</param>
        /// <param name="count">The number of entries to retrieve. Defaults to 3.</param>
        /// <returns>The champion mastery information.</returns>
        public List<ChampionMastery> GetChampionMasteryTopChampions(long playerId, int? count = null)
        {
            return Execute<List<ChampionMastery>>(GetChampionMasteryTopChampionsRequest(playerId, count));
        }

        /// <summary>
        /// Gets information about a summoner's mastery of their most mastered champions. This method uses the Champion Mastery API.
        /// </summary>
        /// <param name="playerId">The summoner ID.</param>
        /// <param name="count">The number of entries to retrieve. Defaults to 3.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<List<ChampionMastery>> GetChampionMasteryTopChampionsAsync(long playerId, int? count = null)
        {
            return ExecuteAsync<List<ChampionMastery>>(GetChampionMasteryTopChampionsRequest(playerId, count));
        }
    }
}
