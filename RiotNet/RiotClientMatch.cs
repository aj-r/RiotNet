using RestSharp;
using RiotNet.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotNet
{
    public partial class RiotClient
    {
        /// <summary>
        /// Gets the currently supported version of the Match API that the client communicates with.
        /// </summary>
        public string MatchApiVersion { get { return "v2.2"; } }

        private IRestRequest GetMatchRequest(long matchId, Boolean includeTimeline)
        {
            var request = Get("api/lol/{region}/v2.2/match/{matchId}");
            request.AddUrlSegment("matchId", matchId.ToString());
            if (includeTimeline)
                request.AddQueryParameter("includeTimeline", includeTimeline.ToString(CultureInfo.InvariantCulture).ToLowerInvariant());
            return request;
        }

        /// <summary>
        /// Gets the details of a match (also referred to as Game ID).
        /// </summary>
        /// <param name="matchId">The ID of the match.</param>
        /// <param name="includeTimeline">Whether or not to include the match timeline data.</param>
        /// <returns>The details of the match.</returns>
        public MatchDetail GetMatch(long matchId, Boolean includeTimeline = false)
        {
            return Execute<MatchDetail>(GetMatchRequest(matchId, includeTimeline));
        }

        /// <summary>
        /// Gets the details of a match (also referred to as Game ID).
        /// </summary>
        /// <param name="matchId">The ID of the match.</param>
        /// <param name="includeTimeline">Whether or not to include the match timeline data.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<MatchDetail> GetMatchAsync(long matchId, Boolean includeTimeline = false)
        {
            return ExecuteAsync<MatchDetail>(GetMatchRequest(matchId, includeTimeline));
        }
    }
}
