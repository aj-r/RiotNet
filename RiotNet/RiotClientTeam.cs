using System;
using System.Threading.Tasks;
using RestSharp;
using RiotNet.Models;
using System.Collections.Generic;

using TeamsBySummonerIdsDictionary = System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<RiotNet.Models.Team>>;
using TeamByTeamIdDictionary = System.Collections.Generic.Dictionary<string, RiotNet.Models.Team>;

namespace RiotNet
{
    public partial class RiotClient
    {
        /// <summary>
        /// Gets the currently supported version of the Team API that the client communicates with.
        /// </summary>
        public string TeamApiVersion { get { return "v2.4"; } }

        private IRestRequest GetTeamsBySummonerIdsRequest(params long[] summonerIds)
        {
            var request = Get("api/lol/{region}/v2.4/team/by-summoner/{summonerIds}");
            request.AddUrlSegment("summonerIds", String.Join(",", summonerIds));
            return request;
        }

        /// <summary>
        /// Gets, for every summoner in summonerIds, the teams that summoner is on.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs.</param>
        /// <returns>The mapping from summoner ID to the teams that summoner is on.</returns>
        public TeamsBySummonerIdsDictionary GetTeamsBySummonerIds(params long[] summonerIds)
        {
            return Execute<TeamsBySummonerIdsDictionary>(GetTeamsBySummonerIdsRequest(summonerIds));
        }

        /// <summary>
        /// Gets, for every summoner in summonerIds, the teams that summoner is on.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<TeamsBySummonerIdsDictionary> GetTeamsBySummonerIdsTaskAsync(params long[] summonerIds)
        {
            return ExecuteTaskAsync<TeamsBySummonerIdsDictionary>(GetTeamsBySummonerIdsRequest(summonerIds));
        }

        private IRestRequest GetTeamsByTeamIdsRequest(params String[] teamIds)
        {
            var request = Get("api/lol/{region}/v2.4/team/{teamIds}");
            request.AddUrlSegment("teamIds", String.Join(",", teamIds));
            return request;
        }

        /// <summary>
        /// Gets the team corresponding to each team ID.
        /// </summary>
        /// <param name="teamIds">The team IDs.</param>
        /// <returns>The mapping from team IDs to teams.</returns>
        public TeamByTeamIdDictionary GetTeamsByTeamIds(params String[] teamIds)
        {
            return Execute<TeamByTeamIdDictionary>(GetTeamsByTeamIdsRequest(teamIds));
        }

        /// <summary>
        /// Gets the team corresponding to each team ID.
        /// </summary>
        /// <param name="teamIds">The team IDs.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<TeamByTeamIdDictionary> GetTeamsByTeamIdsTaskAsync(params String[] teamIds)
        {
            return ExecuteTaskAsync<TeamByTeamIdDictionary>(GetTeamsByTeamIdsRequest(teamIds));
        }
    }
}
