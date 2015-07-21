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
        private IRestRequest GetGamesBySummonerIdRequest(long summonerId)
        {
            var request = Get("api/lol/{region}/v1.3/game/by-summoner/{summonerId}/recent");
            request.AddUrlSegment("summonerId", summonerId.ToString());
            return request;
        }

        /// <summary>
        /// Gets the recent games for a summoner.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner ID.</param>
        /// <returns>The summoner's recent games.</returns>
        public RecentGames GetGamesBySummonerId(long summonerId)
        {
            return Execute<RecentGames>(GetGamesBySummonerIdRequest(summonerId));
        }

        /// <summary>
        /// Gets the recent games for a summoner.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner ID.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<RecentGames> GetGamesBySummonerIdTaskAsync(long summonerId)
        {
            return ExecuteTaskAsync<RecentGames>(GetGamesBySummonerIdRequest(summonerId));
        }
    }
}
