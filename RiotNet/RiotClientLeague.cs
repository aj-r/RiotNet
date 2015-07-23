using System;
using System.Threading.Tasks;
using RestSharp;
using RiotNet.Models;
using System.Collections.Generic;

namespace RiotNet
{
    public partial class RiotClient
    {
        private IRestRequest GetLeaguesBySummonerIdsRequest(params long[] summonerIds)
        {
            var request = Get("api/lol/{region}/v2.5/league/by-summoner/{summonerIds}");
            request.AddUrlSegment("summonerIds", String.Join(",", summonerIds));
            return request;
        }

        /// <summary>
        /// Gets the full league information for all leagues that the summoners are in, including the leages for the teams they are on. Data is mapped by summoner ID.
        /// </summary>
        /// <param name="summonerIds">The summoners' summoner IDs.</param>
        /// <returns>The mapping from summoner IDs to the collection of leagues.</returns>
        public Dictionary<String, List<League>> GetLeaguesBySummonerIds(params long[] summonerIds)
        {
            return Execute<Dictionary<String, List<League>>>(GetLeaguesBySummonerIdsRequest(summonerIds));
        }

        /// <summary>
        /// Gets the full league information for all leagues that the summoners are in, including the leages for the teams they are on. Data is mapped by summoner ID.
        /// </summary>
        /// <param name="summonerIds">The summoners' summoner IDs.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Dictionary<String, List<League>>> GetLeaguesBySummonerIdsTaskAsync(params long[] summonerIds)
        {
            return ExecuteTaskAsync<Dictionary<String, List<League>>>(GetLeaguesBySummonerIdsRequest(summonerIds));
        }

        private IRestRequest GetLeagueEntriesBySummonerIdsRequest(params long[] summonerIds)
        {
            var request = Get("api/lol/{region}/v2.5/league/by-summoner/{summonerIds}/entry");
            request.AddUrlSegment("summonerIds", String.Join(",", summonerIds));
            return request;
        }

        /// <summary>
        /// Gets the full league information for all leagues that the summoners are in, including the leages for the teams they are on. Only includes the league entry for the specified summoner(s). Data is mapped by summoner ID.
        /// </summary>
        /// <param name="summonerIds">The summoners' summoner IDs.</param>
        /// <returns>The mapping from summoner IDs to the collection of league entries for the summoner.</returns>
        public Dictionary<String, List<League>> GetLeagueEntriesBySummonerIds(params long[] summonerIds)
        {
            return Execute<Dictionary<String, List<League>>>(GetLeagueEntriesBySummonerIdsRequest(summonerIds));
        }

        /// <summary>
        /// Gets the full league information for all leagues that the summoners are in, including the leages for the teams they are on. Only includes the league entry for the specified summoner(s). Data is mapped by summoner ID.
        /// </summary>
        /// <param name="summonerIds">The summoners' summoner IDs.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Dictionary<String, List<League>>> GetLeagueEntriesBySummonerIdsTaskAsync(params long[] summonerIds)
        {
            return ExecuteTaskAsync<Dictionary<String, List<League>>>(GetLeagueEntriesBySummonerIdsRequest(summonerIds));
        }

        private IRestRequest GetLeaguesByTeamIdsRequest(params string[] teamIds)
        {
            var request = Get("api/lol/{region}/v2.5/league/by-team/{teamIds}");
            request.AddUrlSegment("teamIds", String.Join(",", teamIds));
            return request;
        }

        /// <summary>
        /// Gets the full league information for all leagues that the teams are in. Data is mapped by team ID.
        /// </summary>
        /// <param name="teamIds">The teams' team IDs.</param>
        /// <returns>The mapping from team IDs to the collection of leagues.</returns>
        public Dictionary<String, List<League>> GetLeaguesByTeamIds(params string[] teamIds)
        {
            return Execute<Dictionary<String, List<League>>>(GetLeaguesByTeamIdsRequest(teamIds));
        }

        /// <summary>
        /// Gets the full league information for all leagues that the teams are in. Data is mapped by team ID.
        /// </summary>
        /// <param name="teamIds">The teams' team IDs.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Dictionary<String, List<League>>> GetLeaguesByTeamIdsTaskAsync(params string[] teamIds)
        {
            return ExecuteTaskAsync<Dictionary<String, List<League>>>(GetLeaguesByTeamIdsRequest(teamIds));
        }

        private IRestRequest GetLeagueEntriesByTeamIdsRequest(params string[] teamIds)
        {
            var request = Get("api/lol/{region}/v2.5/league/by-team/{teamIds}/entry");
            request.AddUrlSegment("teamIds", String.Join(",", teamIds));
            return request;
        }

        /// <summary>
        /// Gets the league information for all leagues that the teams are in. Only includes the league entry for the specified team(s). Data is mapped by team ID.
        /// </summary>
        /// <param name="teamIds">The teams' team IDs.</param>
        /// <returns>The mapping from team IDs to the collection of league entries for the team.</returns>
        public Dictionary<String, List<League>> GetLeagueEntriesByTeamIds(params string[] teamIds)
        {
            return Execute<Dictionary<String, List<League>>>(GetLeagueEntriesByTeamIdsRequest(teamIds));
        }

        /// <summary>
        /// Gets the league information for all leagues that the teams are in. Only includes the league entry for the specified team(s). Data is mapped by team ID.
        /// </summary>
        /// <param name="teamIds">The teams' team IDs.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Dictionary<String, List<League>>> GetLeagueEntriesByTeamIdsTaskAsync(params string[] teamIds)
        {
            return ExecuteTaskAsync<Dictionary<String, List<League>>>(GetLeagueEntriesByTeamIdsRequest(teamIds));
        }

        private IRestRequest GetChallengerLeagueRequest(RankedQueue type)
        {
            var request = Get("api/lol/{region}/v2.5/league/challenger");
            request.AddQueryParameter("type", type.ToString());
            return request;
        }

        /// <summary>
        /// Gets the challenger league.
        /// </summary>
        /// <param name="type">The queue type.</param>
        /// <returns>The challenger league.</returns>
        public League GetChallengerLeague(RankedQueue type)
        {
            return Execute<League>(GetChallengerLeagueRequest(type));
        }

        /// <summary>
        /// Gets the challenger league.
        /// </summary>
        /// <param name="type">The queue type.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<League> GetChallengerLeagueTaskAsync(RankedQueue type)
        {
            return ExecuteTaskAsync<League>(GetChallengerLeagueRequest(type));
        }

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
