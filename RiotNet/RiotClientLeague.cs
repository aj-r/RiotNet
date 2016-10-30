using RiotNet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiotNet
{
    public partial class RiotClient
    {
        /// <summary>
        /// Gets the currently supported version of the League API that the client communicates with.
        /// </summary>
        public string LeagueApiVersion { get { return "v2.5"; } }
        
        /// <summary>
        /// Gets the full league information for all leagues that the summoners are in, including the leages for the teams they are on. Data is mapped by summoner ID. This method uses the League API.
        /// </summary>
        /// <param name="summonerIds">The summoners' summoner IDs. The maximum allowed at once is 10.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Dictionary<string, List<League>>> GetLeaguesBySummonerIdsAsync(params long[] summonerIds)
        {
            var summonerIdString = string.Join(",", summonerIds);
            return GetAsync<Dictionary<string, List<League>>>($"{mainBaseUrl}/api/lol/{region}/{LeagueApiVersion}/league/by-summoner/{summonerIdString}");
        }

        /// <summary>
        /// Gets the full league information for all leagues that the summoners are in, including the leages for the teams they are on. Only includes the league entry for the specified summoner(s). Data is mapped by summoner ID. This method uses the League API.
        /// </summary>
        /// <param name="summonerIds">The summoners' summoner IDs. The maximum allowed at once is 10.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Dictionary<string, List<League>>> GetLeagueEntriesBySummonerIdsAsync(params long[] summonerIds)
        {
            var summonerIdString = string.Join(",", summonerIds);
            return GetAsync<Dictionary<string, List<League>>>($"{mainBaseUrl}/api/lol/{region}/{LeagueApiVersion}/league/by-summoner/{summonerIdString}/entry");
        }
        
        /// <summary>
        /// Gets the full league information for all leagues that the teams are in. Data is mapped by team ID. This method uses the League API.
        /// </summary>
        /// <param name="teamIds">The teams' team IDs. The maximum allowed at once is 10.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Dictionary<string, List<League>>> GetLeaguesByTeamIdsAsync(params string[] teamIds)
        {
            var teamIdString = string.Join(",", teamIds);
            return GetAsync<Dictionary<string, List<League>>>($"{mainBaseUrl}/api/lol/{region}/{LeagueApiVersion}/league/by-team/{teamIdString}");
        }
        
        /// <summary>
        /// Gets the league information for all leagues that the teams are in. Only includes the league entry for the specified team(s). Data is mapped by team ID. This method uses the League API.
        /// </summary>
        /// <param name="teamIds">The teams' team IDs. The maximum allowed at once is 10.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Dictionary<string, List<League>>> GetLeagueEntriesByTeamIdsAsync(params string[] teamIds)
        {
            var teamIdString = string.Join(",", teamIds);
            return GetAsync<Dictionary<string, List<League>>>($"{mainBaseUrl}/api/lol/{region}/{LeagueApiVersion}/league/by-team/{teamIdString}/entry");
        }

        /// <summary>
        /// Gets the challenger league. This method uses the League API.
        /// </summary>
        /// <param name="type">The queue type.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<League> GetChallengerLeagueAsync(RankedQueue type)
        {
            return GetAsync<League>($"{mainBaseUrl}/api/lol/{region}/{LeagueApiVersion}/league/challenger?type={type}");
        }

        /// <summary>
        /// Gets the master league. This method uses the League API.
        /// </summary>
        /// <param name="type">The queue type.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<League> GetMasterLeagueAsync(RankedQueue type)
        {
            return GetAsync<League>($"{mainBaseUrl}/api/lol/{region}/{LeagueApiVersion}/league/master?type={type}");
        }
    }
}
