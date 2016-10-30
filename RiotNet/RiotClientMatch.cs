using RiotNet.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace RiotNet
{
    public partial class RiotClient
    {
        /// <summary>
        /// Gets the currently supported version of the Match API that the client communicates with.
        /// </summary>
        public string MatchApiVersion { get { return "v2.2"; } }

        /// <summary>
        /// Gets the list of match IDs for a tournament code. This method uses the Match API.
        /// </summary>
        /// <param name="tournamentCode">The tournament code.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<List<long>> GetMatchIdsByTournamentCodeAsync(string tournamentCode)
        {
            return GetAsync<List<long>>($"{mainBaseUrl}/api/lol/{region}/{MatchApiVersion}/match/by-tournament/{tournamentCode}/ids");
        }
        
        /// <summary>
        /// Gets the details of a match. This method uses the Match API. This endpoint is only accessible if you have a tournament API key.
        /// </summary>
        /// <param name="matchId">The ID of the match.</param>
        /// <param name="tournamentCode">The tournament code.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<MatchDetail> GetMatchForTournamentAsync(long matchId, string tournamentCode)
        {
            return GetAsync<MatchDetail>($"{mainBaseUrl}/api/lol/{region}/{MatchApiVersion}/match/for-tournament/{matchId}?tournamentCode={tournamentCode}");
        }
        
        /// <summary>
        /// Gets the details of a match. This method uses the Match API.
        /// </summary>
        /// <param name="matchId">The ID of the match.</param>
        /// <param name="includeTimeline">Whether or not to include the match timeline data.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<MatchDetail> GetMatchAsync(long matchId, bool includeTimeline = false)
        {
            var queryParameters = new Dictionary<string, object>();
            if (includeTimeline)
                queryParameters["includeTimeline"] = "true";
            return GetAsync<MatchDetail>($"{mainBaseUrl}/api/lol/{region}/{MatchApiVersion}/match/{matchId}", queryParameters);
        }
    }
}
