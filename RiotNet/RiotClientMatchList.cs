using RestSharp;
using RiotNet.Models;
using System;
using System.Threading.Tasks;
using System.Globalization;

namespace RiotNet
{
    public partial class RiotClient
    {
        /// <summary>
        /// Gets the currently supported version of the Match List API that the client communicates with.
        /// </summary>
        public string MatchListApiVersion { get { return "v2.2"; } }

        private IRestRequest GetMatchListRequest(long summonerId, long[] championIds, RankedQueue[] rankedQueues, Season[] seasons, DateTime? beginTime, DateTime? endTime, int? beginIndex, int? endIndex)
        {
            var request = Get("api/lol/{region}/v2.2/matchhistory/{summonerId}");
            request.AddUrlSegment("summonerId", summonerId.ToString());
            if (championIds != null && championIds.Length > 0)
                request.AddQueryParameter("championIds", String.Join(",", championIds));
            if (rankedQueues != null && rankedQueues.Length > 0)
                request.AddQueryParameter("rankedQueues", String.Join(",", rankedQueues));
            if (seasons != null && seasons.Length > 0)
                request.AddQueryParameter("seasons", String.Join(",", seasons));
            if (beginTime != null)
                request.AddQueryParameter("beginTime", Conversions.DateTimeToEpochMilliseconds(beginTime.Value).ToString(CultureInfo.InvariantCulture));
            if (endTime != null)
                request.AddQueryParameter("endTime", Conversions.DateTimeToEpochMilliseconds(endTime.Value).ToString(CultureInfo.InvariantCulture));
            if (beginIndex != null)
                request.AddQueryParameter("beginIndex", beginIndex.Value.ToString(CultureInfo.InvariantCulture));
            if (endIndex != null)
                request.AddQueryParameter("endIndex", endIndex.Value.ToString(CultureInfo.InvariantCulture));
            return request;
        }
        
        /// <summary>
        /// Gets the match list for a summoner.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner IDs.</param>
        /// <param name="championIds">Only get games where the summoner played one of these champions.</param>
        /// <param name="rankedQueues">Only get games from these ranked queues.</param>
        /// <param name="seasons">Only get games from these seasons.</param>
        /// <param name="beginTime">Only get games played after this time.</param>
        /// <param name="endTime">Only get games played before this time.</param>
        /// <param name="beginIndex">The begin index to use for fetching games.</param>
        /// <param name="endIndex">The end index to use for fetching games. The maximum allowed difference between beginIndex and endIndex is 20; if it is larger than 20, endIndex will be modified to satisfy this restriction.</param>
        /// <returns>The match list for the summoner.</returns>
        public MatchList GetMatchList(long summonerId, long[] championIds = null, RankedQueue[] rankedQueues = null, Season[] seasons = null, DateTime? beginTime = null, DateTime? endTime = null, int? beginIndex = null, int? endIndex = null)
        {
            return Execute<MatchList>(GetMatchListRequest(summonerId, championIds, rankedQueues, seasons, beginTime, endTime, beginIndex, endIndex));
        }
        
        /// <summary>
        /// Gets the match list for a summoner.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner IDs.</param>
        /// <param name="championIds">Only get games where the summoner played one of these champions.</param>
        /// <param name="rankedQueues">Only get games from these ranked queues.</param>
        /// <param name="seasons">Only get games from these seasons.</param>
        /// <param name="beginTime">Only get games played after this time.</param>
        /// <param name="endTime">Only get games played before this time.</param>
        /// <param name="beginIndex">The begin index to use for fetching games.</param>
        /// <param name="endIndex">The end index to use for fetching games. The maximum allowed difference between beginIndex and endIndex is 20; if it is larger than 20, endIndex will be modified to satisfy this restriction.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<MatchList> GetMatchListTaskAsync(long summonerId, long[] championIds = null, RankedQueue[] rankedQueues = null, Season[] seasons = null, DateTime? beginTime = null, DateTime? endTime = null, int? beginIndex = null, int? endIndex = null)
        {
            return ExecuteTaskAsync<MatchList>(GetMatchListRequest(summonerId, championIds, rankedQueues, seasons, beginTime, endTime, beginIndex, endIndex));
        }
    }
}
