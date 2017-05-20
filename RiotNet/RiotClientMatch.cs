using RiotNet.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Match> GetMatchAsync(long matchId, PlatformId? platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the timeline of a match. This method uses the Match API.
        /// </summary>
        /// <param name="matchId">The ID of the match.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<MatchTimeline> GetMatchTimelineAsync(long matchId, PlatformId? platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the match list for a summoner. This method uses the Match API.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner IDs.</param>
        /// <param name="championIds">Only get games where the summoner played one of these champions.</param>
        /// <param name="rankedQueues">Only get games from these ranked queues.</param>
        /// <param name="seasons">Only get games from these seasons.</param>
        /// <param name="beginTime">Only get games played after this time.</param>
        /// <param name="endTime">Only get games played before this time.</param>
        /// <param name="beginIndex">The begin index to use for fetching games.</param>
        /// <param name="endIndex">The end index to use for fetching games. The maximum allowed difference between beginIndex and endIndex is 20; if it is larger than 20, endIndex will be modified to satisfy this restriction.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<MatchList> GetMatchListByAccountIdAsync(long summonerId, long[] championIds = null, QueueType[] rankedQueues = null, Season[] seasons = null, DateTime? beginTime = null, DateTime? endTime = null, int? beginIndex = null, int? endIndex = null, PlatformId? platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the recent match list for an account. This method uses the Match API.
        /// </summary>
        /// <param name="accountId">The account ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<MatchList> GetRecentMatchListByAccountIdAsync(long accountId, PlatformId? platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the list of match IDs for a tournament code. This method uses the Match API. This endpoint is only accessible if you have a tournament API key.
        /// </summary>
        /// <param name="tournamentCode">The tournament code.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<List<long>> GetMatchIdsByTournamentCodeAsync(string tournamentCode, PlatformId? platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the details of a match. This method uses the Match API. This endpoint is only accessible if you have a tournament API key.
        /// </summary>
        /// <param name="matchId">The ID of the match.</param>
        /// <param name="tournamentCode">The tournament code.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Match> GetMatchForTournamentAsync(long matchId, string tournamentCode, PlatformId? platformId = null, CancellationToken token = default(CancellationToken));
    }

    public partial class RiotClient
    {
        /// <summary>
        /// Gets the base URL for champion mastery requests
        /// </summary>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <returns>The base URL.</returns>
        protected string GetMatchBaseUrl(PlatformId? platformId)
        {
            return $"https://{GetServerName(platformId)}/lol/match/v3";
        }

        /// <summary>
        /// Gets the details of a match. This method uses the Match API.
        /// </summary>
        /// <param name="matchId">The ID of the match.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Match> GetMatchAsync(long matchId, PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<Match>($"{GetMatchBaseUrl(platformId)}/matches/{matchId}", token);
        }

        /// <summary>
        /// Gets the timeline of a match. This method uses the Match API.
        /// </summary>
        /// <param name="matchId">The ID of the match.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<MatchTimeline> GetMatchTimelineAsync(long matchId, PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<MatchTimeline>($"{GetMatchBaseUrl(platformId)}/timelines/by-match/{matchId}", token);
        }

        /// <summary>
        /// Gets the match list for an account. This method uses the Match API.
        /// </summary>
        /// <param name="accountId">The account ID.</param>
        /// <param name="championIds">Only get games where the summoner played one of these champions.</param>
        /// <param name="rankedQueues">Only get games from these ranked queues.</param>
        /// <param name="seasons">Only get games from these seasons.</param>
        /// <param name="beginTime">Only get games played after this time.</param>
        /// <param name="endTime">Only get games played before this time.</param>
        /// <param name="beginIndex">The begin index to use for fetching games.</param>
        /// <param name="endIndex">The end index to use for fetching games. The maximum allowed difference between beginIndex and endIndex is 20; if it is larger than 20, endIndex will be modified to satisfy this restriction.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<MatchList> GetMatchListByAccountIdAsync(long accountId, long[] championIds = null, QueueType[] rankedQueues = null, Season[] seasons = null, DateTime? beginTime = null, DateTime? endTime = null, int? beginIndex = null, int? endIndex = null, PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            var queryParameters = new Dictionary<string, object>();
            if (championIds != null && championIds.Length > 0)
                queryParameters["champion"] = string.Join(",", championIds);
            if (rankedQueues != null && rankedQueues.Length > 0)
                queryParameters["queue"] = string.Join(",", rankedQueues.Cast<int>());
            if (seasons != null && seasons.Length > 0)
                queryParameters["seasons"] = string.Join(",", seasons);
            if (beginTime != null)
                queryParameters["beginTime"] = Conversions.DateTimeToEpochMilliseconds(beginTime.Value).ToString(CultureInfo.InvariantCulture);
            if (endTime != null)
                queryParameters["endTime"] = Conversions.DateTimeToEpochMilliseconds(endTime.Value).ToString(CultureInfo.InvariantCulture);
            if (beginIndex != null)
                queryParameters["beginIndex"] = beginIndex.Value.ToString(CultureInfo.InvariantCulture);
            if (endIndex != null)
                queryParameters["endIndex"] = endIndex.Value.ToString(CultureInfo.InvariantCulture);

            return GetAsync<MatchList>($"{GetMatchBaseUrl(platformId)}/matchlists/by-account/{accountId}", token, queryParameters);
        }

        /// <summary>
        /// Gets the recent match list for an account. This method uses the Match API.
        /// </summary>
        /// <param name="accountId">The account ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<MatchList> GetRecentMatchListByAccountIdAsync(long accountId, PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<MatchList>($"{GetMatchBaseUrl(platformId)}/matchlists/by-account/{accountId}/recent", token);
        }

        /// <summary>
        /// Gets the list of match IDs for a tournament code. This method uses the Match API.
        /// </summary>
        /// <param name="tournamentCode">The tournament code.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<List<long>> GetMatchIdsByTournamentCodeAsync(string tournamentCode, PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<List<long>>($"{GetMatchBaseUrl(platformId)}/matches/by-tournament-code/{tournamentCode}/ids", token);
        }

        /// <summary>
        /// Gets the details of a match. This method uses the Match API. This endpoint is only accessible if you have a tournament API key.
        /// </summary>
        /// <param name="matchId">The ID of the match.</param>
        /// <param name="tournamentCode">The tournament code.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Match> GetMatchForTournamentAsync(long matchId, string tournamentCode, PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<Match>($"{GetMatchBaseUrl(platformId)}/matches/{matchId}/by-tournament-code/{tournamentCode}", token);
        }
    }
}
