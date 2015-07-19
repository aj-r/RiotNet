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
        private IRestRequest GetCurrentGameBySummonerId(long summonerId)
        {
            var request = Get("/observer-mode/rest/consumer/getSpectatorGameInfo/{platformId}/{summonerId}");
            request.AddUrlSegment("summonerId", summonerId.ToString());
            return request;
        }

        /// <summary>
        /// Gets information about the current game a summoner is playing.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner ID.</param>
        /// <returns>The current game information.</returns>
        public CurrentGameInfo CurrentGameBySummonerId(long summonerId)
        {
            return Execute<CurrentGameInfo>(GetCurrentGameBySummonerId(summonerId));
        }

        /// <summary>
        /// Gets information about the current game a summoner is playing.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner ID.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<CurrentGameInfo> CurrentGameBySummonerIdAsync(long summonerId)
        {
            return ExecuteTaskAsync<CurrentGameInfo>(GetCurrentGameBySummonerId(summonerId));
        }
    }
}
