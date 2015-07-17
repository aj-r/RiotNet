using System;
using System.Threading.Tasks;
using RestSharp;
using RiotNet.Models;

namespace RiotNet
{
    public partial class RiotClient
    {
        private IRestRequest GetMasterLeagueRequest(RankedQueue type)
        {
            var request = Get("api/lol/{region}/v2.5/league/master");
            request.AddQueryParameter("type", type.ToString());
            return request;
        }

        /// <summary>
        /// Gets the master league.
        /// </summary>
        /// <param name="type">The queue type.</param>
        /// <returns>The master league.</returns>
        public League GetMasterLeague(RankedQueue type)
        {
            return Execute<League>(GetMasterLeagueRequest(type));
        }

        /// <summary>
        /// Gets the master league.
        /// </summary>
        /// <param name="type">The queue type.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<League> GetMasterLeagueTaskAsync(RankedQueue type)
        {
            return ExecuteTaskAsync<League>(GetMasterLeagueRequest(type));
        }
    }
}
