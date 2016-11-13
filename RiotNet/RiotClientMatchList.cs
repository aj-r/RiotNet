using RiotNet.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace RiotNet
{
    public partial class RiotClient
    {
        /// <summary>
        /// Gets the currently supported version of the Match List API that the client communicates with.
        /// </summary>
        public string MatchListApiVersion { get { return "v2.2"; } }

        /// <summary>
        /// Gets the match list for a summoner. This method uses the Match List API.
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
        public Task<MatchList> GetMatchListAsync(long summonerId, long[] championIds = null, RankedQueue[] rankedQueues = null, Season[] seasons = null, DateTime? beginTime = null, DateTime? endTime = null, int? beginIndex = null, int? endIndex = null)
        {
            var queryParameters = new Dictionary<string, object>();
            if (championIds != null && championIds.Length > 0)
                queryParameters["championIds"] = string.Join(",", championIds);
            if (rankedQueues != null && rankedQueues.Length > 0)
                queryParameters["rankedQueues"] = string.Join(",", rankedQueues);
            if (seasons != null && seasons.Length > 0)
                queryParameters["seasons"] = string.Join(",", seasons);
            if (beginTime != null)
                queryParameters["beginTime"] = Conversions.DateTimeToEpochMilliseconds(beginTime.Value).ToString(CultureInfo.InvariantCulture);
            if (endTime != null)
                queryParameters["endTime"] = Conversions.DateTimeToEpochMilliseconds(endTime.Value).ToString(CultureInfo.InvariantCulture);
            if (beginIndex != null)
                queryParameters["beginIndex"] = beginIndex.Value.ToString(CultureInfo.InvariantCulture);
            if (endIndex != null)
                queryParameters["endIndex"] = endIndex.Value.ToString(CultureInfo.InvariantCulture);

            return GetAsync<MatchList>($"{mainBaseUrl}/api/lol/{lowerRegion}/{MatchApiVersion}/matchlist/by-summoner/{summonerId}", queryParameters);
        }
    }
}
