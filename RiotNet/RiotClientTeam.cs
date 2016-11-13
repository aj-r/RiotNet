using RiotNet.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiotNet
{
    public partial class RiotClient
    {
        /// <summary>
        /// Gets the currently supported version of the Team API that the client communicates with.
        /// </summary>
        public string TeamApiVersion { get { return "v2.4"; } }
        
        /// <summary>
        /// Gets, for every summoner in summonerIds, the teams that summoner is on. This method uses the Team API.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs. The maximum allowed at once is 10.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Dictionary<string, List<Team>>> GetTeamsBySummonerIdsAsync(params long[] summonerIds)
        {
            var summonerIdString = string.Join(",", summonerIds);
            return GetAsync<Dictionary<string, List<Team>>>($"{mainBaseUrl}/api/lol/{lowerRegion}/{TeamApiVersion}/team/by-summoner/{summonerIdString}");
        }

        /// <summary>
        /// Gets the team corresponding to each team ID. This method uses the Team API.
        /// </summary>
        /// <param name="teamIds">The team IDs. The maximum allowed at once is 10.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Dictionary<string, Team>> GetTeamsByTeamIdsAsync(params string[] teamIds)
        {
            var teamIdString = string.Join(",", teamIds);
            return GetAsync<Dictionary<string, Team>>($"{mainBaseUrl}/api/lol/{lowerRegion}/{TeamApiVersion}/team/{teamIdString}");
        }
    }
}
