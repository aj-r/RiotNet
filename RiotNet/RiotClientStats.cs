using RiotNet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiotNet
{
    public partial class RiotClient
    {
        /// <summary>
        /// Gets the currently supported version of the Stats API that the client communicates with.
        /// </summary>
        public string StatsApiVersion { get { return "v1.3"; } }

        /// <summary>
        /// Gets the ranked stats for a summoner. Includes ranked stats for Summoner's Rift and Twisted Treeline. This method uses the Stats API.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner IDs.</param>
        /// <param name="season">The season to get ranked stats for. If unspecified, stats for the current season are returned.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<RankedStats> GetRankedStatsAsync(long summonerId, Season? season = null)
        {
            var queryParameters = new Dictionary<string, object>();
            if (season != null)
                queryParameters["season"] = season;
            return GetAsync<RankedStats>($"{mainBaseUrl}/api/lol/{region}/{StatsApiVersion}/stats/by-summoner/{summonerId}/ranked", queryParameters);
        }

        /// <summary>
        /// Gets aggregated stats for a summoner. This method uses the Stats API.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner IDs.</param>
        /// <param name="season">The season to get stats for. If unspecified, stats for the current season are returned.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<PlayerStatsSummaryList> GetStatsSummaryAsync(long summonerId, Season? season = null)
        {
            var queryParameters = new Dictionary<string, object>();
            if (season != null)
                queryParameters["season"] = season;
            return GetAsync<PlayerStatsSummaryList>($"{mainBaseUrl}/api/lol/{region}/{StatsApiVersion}/stats/by-summoner/{summonerId}/summary", queryParameters);
        }
    }
}
