using System;
using System.Threading.Tasks;
using RestSharp;
using RiotNet.Models;
using System.Collections.Generic;

namespace RiotNet
{
    public partial class RiotClient
    {
        /// <summary>
        /// Gets the currently supported version of the League API that the client communicates with.
        /// </summary>
        public string LeagueApiVersion { get { return "v2.5"; } }

        private IRestRequest GetLeaguesBySummonerIdsRequest(params long[] summonerIds)
        {
            var request = Get("api/lol/{region}/v2.5/league/by-summoner/{summonerIds}");
            request.AddUrlSegment("summonerIds", String.Join(",", summonerIds));
            return request;
        }

        /// <summary>
        /// Gets the full league information for all leagues that the summoners are in, including the leages for the teams they are on. Data is mapped by summoner ID. This method uses the League API.
        /// </summary>
        /// <param name="summonerIds">The summoners' summoner IDs. The maximum allowed at once is 10.</param>
        /// <returns>The mapping from summoner IDs to the collection of leagues.</returns>
        public Dictionary<String, List<League>> GetLeaguesBySummonerIds(params long[] summonerIds)
        {
            return Execute<Dictionary<String, List<League>>>(GetLeaguesBySummonerIdsRequest(summonerIds));
        }

        /// <summary>
        /// Gets the full league information for all leagues that the summoners are in, including the leages for the teams they are on. Data is mapped by summoner ID. This method uses the League API.
        /// </summary>
        /// <param name="summonerIds">The summoners' summoner IDs. The maximum allowed at once is 10.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Dictionary<String, List<League>>> GetLeaguesBySummonerIdsAsync(params long[] summonerIds)
        {
            return ExecuteAsync<Dictionary<String, List<League>>>(GetLeaguesBySummonerIdsRequest(summonerIds));
        }

        private IRestRequest GetLeagueEntriesBySummonerIdsRequest(params long[] summonerIds)
        {
            var request = Get("api/lol/{region}/v2.5/league/by-summoner/{summonerIds}/entry");
            request.AddUrlSegment("summonerIds", String.Join(",", summonerIds));
            return request;
        }

        /// <summary>
        /// Gets the full league information for all leagues that the summoners are in, including the leages for the teams they are on. Only includes the league entry for the specified summoner(s). Data is mapped by summoner ID. This method uses the League API.
        /// </summary>
        /// <param name="summonerIds">The summoners' summoner IDs. The maximum allowed at once is 10.</param>
        /// <returns>The mapping from summoner IDs to the collection of league entries for the summoner.</returns>
        public Dictionary<String, List<League>> GetLeagueEntriesBySummonerIds(params long[] summonerIds)
        {
            return Execute<Dictionary<String, List<League>>>(GetLeagueEntriesBySummonerIdsRequest(summonerIds));
        }

        /// <summary>
        /// Gets the full league information for all leagues that the summoners are in, including the leages for the teams they are on. Only includes the league entry for the specified summoner(s). Data is mapped by summoner ID. This method uses the League API.
        /// </summary>
        /// <param name="summonerIds">The summoners' summoner IDs. The maximum allowed at once is 10.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Dictionary<String, List<League>>> GetLeagueEntriesBySummonerIdsAsync(params long[] summonerIds)
        {
            return ExecuteAsync<Dictionary<String, List<League>>>(GetLeagueEntriesBySummonerIdsRequest(summonerIds));
        }

        private IRestRequest GetLeaguesByTeamIdsRequest(params string[] teamIds)
        {
            var request = Get("api/lol/{region}/v2.5/league/by-team/{teamIds}");
            request.AddUrlSegment("teamIds", String.Join(",", teamIds));
            return request;
        }

        /// <summary>
        /// Gets the full league information for all leagues that the teams are in. Data is mapped by team ID. This method uses the League API.
        /// </summary>
        /// <param name="teamIds">The teams' team IDs. The maximum allowed at once is 10.</param>
        /// <returns>The mapping from team IDs to the collection of leagues.</returns>
        public Dictionary<String, List<League>> GetLeaguesByTeamIds(params string[] teamIds)
        {
            return Execute<Dictionary<String, List<League>>>(GetLeaguesByTeamIdsRequest(teamIds));
        }

        /// <summary>
        /// Gets the full league information for all leagues that the teams are in. Data is mapped by team ID. This method uses the League API.
        /// </summary>
        /// <param name="teamIds">The teams' team IDs. The maximum allowed at once is 10.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Dictionary<String, List<League>>> GetLeaguesByTeamIdsAsync(params string[] teamIds)
        {
            return ExecuteAsync<Dictionary<String, List<League>>>(GetLeaguesByTeamIdsRequest(teamIds));
        }

        private IRestRequest GetLeagueEntriesByTeamIdsRequest(params string[] teamIds)
        {
            var request = Get("api/lol/{region}/v2.5/league/by-team/{teamIds}/entry");
            request.AddUrlSegment("teamIds", String.Join(",", teamIds));
            return request;
        }

        /// <summary>
        /// Gets the league information for all leagues that the teams are in. Only includes the league entry for the specified team(s). Data is mapped by team ID. This method uses the League API.
        /// </summary>
        /// <param name="teamIds">The teams' team IDs. The maximum allowed at once is 10.</param>
        /// <returns>The mapping from team IDs to the collection of league entries for the team.</returns>
        public Dictionary<String, List<League>> GetLeagueEntriesByTeamIds(params string[] teamIds)
        {
            return Execute<Dictionary<String, List<League>>>(GetLeagueEntriesByTeamIdsRequest(teamIds));
        }

        /// <summary>
        /// Gets the league information for all leagues that the teams are in. Only includes the league entry for the specified team(s). Data is mapped by team ID. This method uses the League API.
        /// </summary>
        /// <param name="teamIds">The teams' team IDs. The maximum allowed at once is 10.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Dictionary<String, List<League>>> GetLeagueEntriesByTeamIdsAsync(params string[] teamIds)
        {
            return ExecuteAsync<Dictionary<String, List<League>>>(GetLeagueEntriesByTeamIdsRequest(teamIds));
        }

        private IRestRequest GetChallengerLeagueRequest(RankedQueue type)
        {
            var request = Get("api/lol/{region}/v2.5/league/challenger");
            request.AddQueryParameter("type", type.ToString());
            return request;
        }

        /// <summary>
        /// Gets the challenger league. This method uses the League API.
        /// </summary>
        /// <param name="type">The queue type.</param>
        /// <returns>The challenger league.</returns>
        public League GetChallengerLeague(RankedQueue type)
        {
            return Execute<League>(GetChallengerLeagueRequest(type));
        }

        /// <summary>
        /// Gets the challenger league. This method uses the League API.
        /// </summary>
        /// <param name="type">The queue type.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<League> GetChallengerLeagueAsync(RankedQueue type)
        {
            return ExecuteAsync<League>(GetChallengerLeagueRequest(type));
        }

        private IRestRequest GetMasterLeagueRequest(RankedQueue type)
        {
            var request = Get("api/lol/{region}/v2.5/league/master");
            request.AddQueryParameter("type", type.ToString());
            return request;
        }

        /// <summary>
        /// Gets the master league. This method uses the League API.
        /// </summary>
        /// <param name="type">The queue type.</param>
        /// <returns>The master league.</returns>
        public League GetMasterLeague(RankedQueue type)
        {
            return Execute<League>(GetMasterLeagueRequest(type));
        }

        /// <summary>
        /// Gets the master league. This method uses the League API.
        /// </summary>
        /// <param name="type">The queue type.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<League> GetMasterLeagueAsync(RankedQueue type)
        {
            return ExecuteAsync<League>(GetMasterLeagueRequest(type));
        }
    }
}
