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
        private IRestRequest GetMatchRequest(long matchId)
        {
            var request = Get("api/lol/{region}/v2.2/match/{matchId}");
            request.AddUrlSegment("matchId", matchId.ToString());
            return request;
        }

        /// <summary>
        /// Gets the details of a match.
        /// </summary>
        /// <param name="matchId">The ID of the match.</param>
        /// <returns>The details of the match.</returns>
        public MatchDetail GetMatch(long matchId)
        {
            return Execute<MatchDetail>(GetMatchRequest(matchId));
        }

        /// <summary>
        /// Gets the details of a match.
        /// </summary>
        /// <param name="matchId">The ID of the match.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<MatchDetail> GetMatchTaskAsync(long matchId)
        {
            return ExecuteTaskAsync<MatchDetail>(GetMatchRequest(matchId));
        }
    }
}
