using RestSharp;
using RiotNet.Models;
using System;
using System.Threading.Tasks;
using System.Globalization;

namespace RiotNet
{
    public partial class RiotClient
    {
        // TODO: the Match History API will be removed on September 22. We should probably just remove it from this client.

        /// <summary>
        /// Gets the currently supported version of the Match History API that the client communicates with.
        /// </summary>
        public string MatchHistoryApiVersion { get { return "v2.2"; } }

        private IRestRequest GetMatchHistoryRequest(long summonerId, long[] championIds, RankedQueue[] rankedQueues, int? beginIndex, int? endIndex)
        {
            var request = Get("api/lol/{region}/v2.2/matchhistory/{summonerId}");
            request.AddUrlSegment("summonerId", summonerId.ToString(CultureInfo.InvariantCulture));
            if (championIds != null && championIds.Length > 0)
                request.AddQueryParameter("championIds", String.Join(",", championIds));
            if (rankedQueues != null && rankedQueues.Length > 0)
                request.AddQueryParameter("rankedQueues", String.Join(",", rankedQueues));
            if (beginIndex != null)
                request.AddQueryParameter("beginIndex", beginIndex.Value.ToString(CultureInfo.InvariantCulture));
            if (endIndex != null)
                request.AddQueryParameter("endIndex", endIndex.Value.ToString(CultureInfo.InvariantCulture));
            return request;
        }
        
        /// <summary>
        /// Gets the match history for a summoner.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner IDs.</param>
        /// <param name="championIds">Only get games where the summoner played one of these champions.</param>
        /// <param name="rankedQueues">Only get games from these ranked queues.</param>
        /// <param name="beginIndex">The begin index to use for fetching games.</param>
        /// <param name="endIndex">The end index to use for fetching games. The maximum allowed difference between beginIndex and endIndex; if it is larger than 15, endIndex will be modified to satisfy this restriction.</param>
        /// <returns>The match history for the summoner.</returns>
        public PlayerHistory GetMatchHistory(long summonerId, long[] championIds = null, RankedQueue[] rankedQueues = null, int? beginIndex = null, int? endIndex = null)
        {
            return Execute<PlayerHistory>(GetMatchHistoryRequest(summonerId, championIds, rankedQueues, beginIndex, endIndex));
        }
        
        /// <summary>
        /// Gets the match history for a summoner.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner IDs.</param>
        /// <param name="championIds">Only get games where the summoner played one of these champions.</param>
        /// <param name="rankedQueues">Only get games from these ranked queues.</param>
        /// <param name="beginIndex">The begin index to use for fetching games.</param>
        /// <param name="endIndex">The end index to use for fetching games. The maximum allowed difference between beginIndex and endIndex; if it is larger than 15, endIndex will be modified to satisfy this restriction.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<PlayerHistory> GetMatchHistoryTaskAsync(long summonerId, long[] championIds = null, RankedQueue[] rankedQueues = null, int? beginIndex = null, int? endIndex = null)
        {
            return ExecuteTaskAsync<PlayerHistory>(GetMatchHistoryRequest(summonerId, championIds, rankedQueues, beginIndex, endIndex));
        }
    }
}
