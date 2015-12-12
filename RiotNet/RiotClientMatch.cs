using RestSharp;
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

        private IRestRequest GetMatchIdsByTournamentCodeRequest(string tournamentCode)
        {
            var request = Get("api/lol/{region}/{version}/match/by-tournament/{tournamentCode}/ids");
            request.AddUrlSegment("version", MatchApiVersion);
            request.AddUrlSegment("tournamentCode", tournamentCode);
            return request;
        }

        /// <summary>
        /// Gets the list of match IDs for a tournament code. This method uses the Match API.
        /// </summary>
        /// <param name="tournamentCode">The tournament code.</param>
        /// <returns>The match IDs.</returns>
        public List<long> GetMatchIdsByTournamentCode(string tournamentCode)
        {
            return Execute<List<long>>(GetMatchIdsByTournamentCodeRequest(tournamentCode));
        }

        /// <summary>
        /// Gets the list of match IDs for a tournament code. This method uses the Match API.
        /// </summary>
        /// <param name="tournamentCode">The tournament code.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<List<long>> GetMatchIdsByTournamentCodeAsync(string tournamentCode)
        {
            return ExecuteAsync<List<long>>(GetMatchIdsByTournamentCodeRequest(tournamentCode));
        }

        private IRestRequest GetMatchForTournamentRequest(long matchId, string tournamentCode)
        {
            var request = Get("api/lol/{region}/{version}/match/for-tournament/{matchId}");
            request.AddUrlSegment("version", MatchApiVersion);
            request.AddUrlSegment("matchId", matchId.ToString());
            request.AddQueryParameter("tournamentCode", tournamentCode);
            return request;
        }

        /// <summary>
        /// Gets the details of a match. This method uses the Match API. This endpoint is only accessible if you have a tournament API key.
        /// </summary>
        /// <param name="matchId">The ID of the match.</param>
        /// <param name="tournamentCode">The tournament code.</param>
        /// <returns>The details of the match.</returns>
        public MatchDetail GetMatchForTournament(long matchId, string tournamentCode)
        {
            return Execute<MatchDetail>(GetMatchForTournamentRequest(matchId, tournamentCode));
        }

        /// <summary>
        /// Gets the details of a match. This method uses the Match API. This endpoint is only accessible if you have a tournament API key.
        /// </summary>
        /// <param name="matchId">The ID of the match.</param>
        /// <param name="tournamentCode">The tournament code.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<MatchDetail> GetMatchForTournamentAsync(long matchId, string tournamentCode)
        {
            return ExecuteAsync<MatchDetail>(GetMatchForTournamentRequest(matchId, tournamentCode));
        }

        private IRestRequest GetMatchRequest(long matchId, bool includeTimeline)
        {
            var request = Get("api/lol/{region}/{version}/match/{matchId}");
            request.AddUrlSegment("version", MatchApiVersion);
            request.AddUrlSegment("matchId", matchId.ToString());
            if (includeTimeline)
                request.AddQueryParameter("includeTimeline", includeTimeline.ToString(CultureInfo.InvariantCulture).ToLowerInvariant());
            return request;
        }

        /// <summary>
        /// Gets the details of a match. This method uses the Match API.
        /// </summary>
        /// <param name="matchId">The ID of the match.</param>
        /// <param name="includeTimeline">Whether or not to include the match timeline data.</param>
        /// <returns>The details of the match.</returns>
        public MatchDetail GetMatch(long matchId, bool includeTimeline = false)
        {
            return Execute<MatchDetail>(GetMatchRequest(matchId, includeTimeline));
        }

        /// <summary>
        /// Gets the details of a match. This method uses the Match API.
        /// </summary>
        /// <param name="matchId">The ID of the match.</param>
        /// <param name="includeTimeline">Whether or not to include the match timeline data.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<MatchDetail> GetMatchAsync(long matchId, bool includeTimeline = false)
        {
            return ExecuteAsync<MatchDetail>(GetMatchRequest(matchId, includeTimeline));
        }
    }
}
