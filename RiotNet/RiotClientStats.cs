using RestSharp;
using RiotNet.Models;
using System.Globalization;
using System.Threading.Tasks;

namespace RiotNet
{
    public partial class RiotClient
    {
        /// <summary>
        /// Gets the currently supported version of the Stats API that the client communicates with.
        /// </summary>
        public string StatsApiVersion { get { return "v1.3"; } }

        private IRestRequest GetRankedStatsRequest(long summonerId, Season? season)
        {
            var request = Get("api/lol/{region}/v1.3/stats/by-summoner/{summonerId}/ranked");
            request.AddUrlSegment("summonerId", summonerId.ToString(CultureInfo.InvariantCulture));
            if (season != null)
                request.AddQueryParameter("season", season.ToString());
            return request;
        }

        /// <summary>
        /// Gets the ranked stats for a summoner. Includes ranked stats for Summoner's Rift and Twisted Treeline. This method uses the Stats API.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner IDs.</param>
        /// <param name="season">The season to get ranked stats for. If unspecified, stats for the current season are returned.</param>
        /// <returns>The ranked stats for the summoner for the specified season.</returns>
        public RankedStats GetRankedStats(long summonerId, Season? season = null)
        {
            return Execute<RankedStats>(GetRankedStatsRequest(summonerId, season));
        }

        /// <summary>
        /// Gets the ranked stats for a summoner. Includes ranked stats for Summoner's Rift and Twisted Treeline. This method uses the Stats API.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner IDs.</param>
        /// <param name="season">The season to get ranked stats for. If unspecified, stats for the current season are returned.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<RankedStats> GetRankedStatsAsync(long summonerId, Season? season = null)
        {
            return ExecuteAsync<RankedStats>(GetRankedStatsRequest(summonerId, season));
        }

        private IRestRequest GetStatsSummaryRequest(long summonerId, Season? season)
        {
            var request = Get("api/lol/{region}/v1.3/stats/by-summoner/{summonerId}/summary");
            request.AddUrlSegment("summonerId", summonerId.ToString(CultureInfo.InvariantCulture));
            if (season != null)
                request.AddQueryParameter("season", season.ToString());
            return request;
        }

        /// <summary>
        /// Gets aggregated stats for a summoner. This method uses the Stats API.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner IDs.</param>
        /// <param name="season">The season to get stats for. If unspecified, stats for the current season are returned.</param>
        /// <returns>The aggregated stats for the summoner for the specified season. One summary is returned per queue type.</returns>
        public PlayerStatsSummaryList GetStatsSummary(long summonerId, Season? season = null)
        {
            return Execute<PlayerStatsSummaryList>(GetStatsSummaryRequest(summonerId, season));
        }

        /// <summary>
        /// Gets aggregated stats for a summoner. This method uses the Stats API.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner IDs.</param>
        /// <param name="season">The season to get stats for. If unspecified, stats for the current season are returned.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<PlayerStatsSummaryList> GetStatsSummaryAsync(long summonerId, Season? season = null)
        {
            return ExecuteAsync<PlayerStatsSummaryList>(GetStatsSummaryRequest(summonerId, season));
        }
    }
}
