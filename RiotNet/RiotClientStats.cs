using RestSharp;
using RiotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotNet
{
    public partial class RiotClient
    {
        private IRestRequest GetStatsRequest(long summonerId, Season season)
        {
            var request = Get("api/lol/{region}/v1.3/stats/by-summoner/{summonerId}/ranked");
            request.AddUrlSegment("summonerId", summonerId.ToString());
            request.AddQueryParameter("season", season.ToString());
            return request;
        }

        /// <summary>
        /// Gets the ranked stats for a summoner. Includes ranked stats for Summoner's Rift and Twisted Treeline.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner IDs.</param>
        /// <param name="season">The season to get ranked stats for.</param>
        /// <returns>The ranked stats for the summoner for the specified season.</returns>
        public RankedStats GetStats(long summonerId, Season season)
        {
            return Execute<RankedStats>(GetStatsRequest(summonerId, season));
        }

        /// <summary>
        /// Gets the ranked stats for a summoner. Includes ranked stats for Summoner's Rift and Twisted Treeline.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner IDs.</param>
        /// <param name="season">The season to get ranked stats for.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<RankedStats> GetStatsTaskAsync(long summonerId, Season season)
        {
            return ExecuteTaskAsync<RankedStats>(GetStatsRequest(summonerId, season));
        }

        private IRestRequest GetStatsSummaryRequest(long summonerId, Season season)
        {
            var request = Get("api/lol/{region}/v1.3/stats/by-summoner/{summonerId}/summary");
            request.AddUrlSegment("summonerId", summonerId.ToString());
            request.AddQueryParameter("season", season.ToString());
            return request;
        }

        /// <summary>
        /// Gets aggregated stats for a summoner.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner IDs.</param>
        /// <param name="season">The season to get stats for.</param>
        /// <returns>The aggregated stats for the summoner for the specified season. One summary is returned per queue type.</returns>
        public PlayerStatsSummaryList GetStatsSummary(long summonerId, Season season)
        {
            return Execute<PlayerStatsSummaryList>(GetStatsSummaryRequest(summonerId, season));
        }

        /// <summary>
        /// Gets aggregated stats for a summoner.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner IDs.</param>
        /// <param name="season">The season to get stats for.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<PlayerStatsSummaryList> GetStatsSummaryTaskAsync(long summonerId, Season season)
        {
            return ExecuteTaskAsync<PlayerStatsSummaryList>(GetStatsSummaryRequest(summonerId, season));
        }
    }
}
