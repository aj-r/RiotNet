using RiotNet.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace RiotNet
{
    public partial interface IRiotClient
    {
        /// <summary>
        /// Gets the details of a match. This method uses the Match API.
        /// </summary>
        /// <param name="matchId">The ID of the match.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Match> GetMatchAsync(long matchId, string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the timeline of a match. This method uses the Match API.
        /// </summary>
        /// <param name="matchId">The ID of the match.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<MatchTimeline> GetMatchTimelineAsync(long matchId, string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the match list for a summoner. This method uses the Match API.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner IDs.</param>
        /// <param name="championIds">Only get games where the summoner played one of these champions.</param>
        /// <param name="rankedQueues">Only get games from these queues. You should only use ranked queues for this (<see cref="QueueType.TEAM_BUILDER_RANKED_SOLO"/>, <see cref="QueueType.RANKED_FLEX_SR"/>, <see cref="QueueType.RANKED_FLEX_TT"/>).</param>
        /// <param name="seasons">Only get games from these seasons.</param>
        /// <param name="beginTime">Only get games played after this time.</param>
        /// <param name="endTime">Only get games played before this time.</param>
        /// <param name="beginIndex">The begin index to use for fetching games.</param>
        /// <param name="endIndex">The end index to use for fetching games. The maximum allowed difference between beginIndex and endIndex is 20; if it is larger than 20, endIndex will be modified to satisfy this restriction.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<MatchList> GetMatchListByAccountIdAsync(long summonerId, IEnumerable<long> championIds = null, IEnumerable<QueueType> rankedQueues = null, IEnumerable<Season> seasons = null, DateTime? beginTime = null, DateTime? endTime = null, int? beginIndex = null, int? endIndex = null, string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the recent match list for an account. This method uses the Match API.
        /// </summary>
        /// <param name="accountId">The account ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Obsolete("Use GetMatchListByAccountIdAsync instead")]
        Task<MatchList> GetRecentMatchListByAccountIdAsync(long accountId, string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the list of match IDs for a tournament code. This method uses the Match API. This endpoint is only accessible if you have a tournament API key.
        /// </summary>
        /// <param name="tournamentCode">The tournament code.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<List<long>> GetMatchIdsByTournamentCodeAsync(string tournamentCode, string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the details of a match. This method uses the Match API. This endpoint is only accessible if you have a tournament API key.
        /// </summary>
        /// <param name="matchId">The ID of the match.</param>
        /// <param name="tournamentCode">The tournament code.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Match> GetMatchForTournamentAsync(long matchId, string tournamentCode, string platformId = null, CancellationToken token = default(CancellationToken));
    }

    public partial class RiotClient
    {
        private const string matchBasePath = "match/v3";

        /// <summary>
        /// Gets the details of a match. This method uses the Match API.
        /// </summary>
        /// <param name="matchId">The ID of the match.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Match> GetMatchAsync(long matchId, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<Match>($"{matchBasePath}/matches/{matchId}", $"{matchBasePath}/matches/{{matchId}}", platformId, token);
        }

        /// <summary>
        /// Gets the timeline of a match. This method uses the Match API.
        /// </summary>
        /// <param name="matchId">The ID of the match.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<MatchTimeline> GetMatchTimelineAsync(long matchId, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<MatchTimeline>($"{matchBasePath}/timelines/by-match/{matchId}", $"{matchBasePath}/timelines/by-match/{{matchId}}", platformId, token);
        }

        /// <summary>
        /// Gets the match list for an account. This method uses the Match API.
        /// </summary>
        /// <param name="accountId">The account ID.</param>
        /// <param name="championIds">Only get games where the summoner played one of these champions.</param>
        /// <param name="rankedQueues">Only get games from these queues. You should only use ranked queues for this (<see cref="QueueType.TEAM_BUILDER_RANKED_SOLO"/>, <see cref="QueueType.RANKED_FLEX_SR"/>, <see cref="QueueType.RANKED_FLEX_TT"/>).</param>
        /// <param name="seasons">Only get games from these seasons.</param>
        /// <param name="beginTime">Only get games played after this time. If beginTime is specified, but not endTime, then these parameters are ignored. If endTime is specified, but not beginTime, then beginTime defaults to the start of the account's match history. If both are specified, then endTime should be greater than beginTime. The maximum time range allowed is one week, otherwise a 400 error code is returned.</param>
        /// <param name="endTime">Only get games played before this time. If beginTime is specified, but not endTime, then these parameters are ignored. If endTime is specified, but not beginTime, then beginTime defaults to the start of the account's match history. If both are specified, then endTime should be greater than beginTime. The maximum time range allowed is one week, otherwise a 400 error code is returned.</param>
        /// <param name="beginIndex">The begin index to use for fetching games. If beginIndex is specified, but not endIndex, then endIndex defaults to beginIndex+100. If endIndex is specified, but not beginIndex, then beginIndex defaults to 0. If both are specified, then endIndex must be greater than beginIndex. The maximum range allowed is 100, otherwise a 400 error code is returned.</param>
        /// <param name="endIndex">The end index to use for fetching games. If beginIndex is specified, but not endIndex, then endIndex defaults to beginIndex+100. If endIndex is specified, but not beginIndex, then beginIndex defaults to 0. If both are specified, then endIndex must be greater than beginIndex. The maximum range allowed is 100, otherwise a 400 error code is returned.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<MatchList> GetMatchListByAccountIdAsync(long accountId, IEnumerable<long> championIds = null, IEnumerable<QueueType> rankedQueues = null, IEnumerable<Season> seasons = null, DateTime? beginTime = null, DateTime? endTime = null, int? beginIndex = null, int? endIndex = null, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            var queryParameters = new Dictionary<string, object>();
            if (championIds != null)
                queryParameters["champion"] = championIds;
            if (rankedQueues != null)
                queryParameters["queue"] = rankedQueues;
            if (seasons != null)
                queryParameters["season"] = seasons;
            if (beginTime != null)
                queryParameters["beginTime"] = Conversions.DateTimeToEpochMilliseconds(beginTime.Value).ToString(CultureInfo.InvariantCulture);
            if (endTime != null)
                queryParameters["endTime"] = Conversions.DateTimeToEpochMilliseconds(endTime.Value).ToString(CultureInfo.InvariantCulture);
            if (beginIndex != null)
                queryParameters["beginIndex"] = beginIndex.Value.ToString(CultureInfo.InvariantCulture);
            if (endIndex != null)
                queryParameters["endIndex"] = endIndex.Value.ToString(CultureInfo.InvariantCulture);

            return GetAsync<MatchList>($"{matchBasePath}/matchlists/by-account/{accountId}", $"{matchBasePath}/matchlists/by-account/{{accountId}}", platformId, token, queryParameters);
        }

        /// <summary>
        /// Gets the recent match list for an account. This method uses the Match API.
        /// </summary>
        /// <param name="accountId">The account ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Obsolete("Use GetMatchListByAccountIdAsync instead")]
        public Task<MatchList> GetRecentMatchListByAccountIdAsync(long accountId, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<MatchList>($"{matchBasePath}/matchlists/by-account/{accountId}/recent", $"{matchBasePath}/matchlists/by-account/{{accountId}}/recent", platformId, token);
        }

        /// <summary>
        /// Gets the list of match IDs for a tournament code. This method uses the Match API.
        /// </summary>
        /// <param name="tournamentCode">The tournament code.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<List<long>> GetMatchIdsByTournamentCodeAsync(string tournamentCode, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<List<long>>($"{matchBasePath}/matches/by-tournament-code/{tournamentCode}/ids", $"{matchBasePath}/matches/by-tournament-code/{{tournamentCode}}/ids", platformId, token);
        }

        /// <summary>
        /// Gets the details of a match. This method uses the Match API. This endpoint is only accessible if you have a tournament API key.
        /// </summary>
        /// <param name="matchId">The ID of the match.</param>
        /// <param name="tournamentCode">The tournament code.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Match> GetMatchForTournamentAsync(long matchId, string tournamentCode, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<Match>($"{matchBasePath}/matches/{matchId}/by-tournament-code/{tournamentCode}", $"{matchBasePath}/matches/{{matchId}}/by-tournament-code/{{tournamentCode}}", platformId, token);
        }
    }
}
