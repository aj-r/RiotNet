using RiotNet.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RiotNet
{
    public partial interface IRiotClient
    {
        /// <summary>
        /// Gets the full league information for all leagues that the summoners are in, including the leages for the teams they are on. Data is mapped by summoner ID. This method uses the League API.
        /// </summary>
        /// <param name="leagueId">The UIID of the league.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<LeagueList> GetLeagueByIdAsync(string leagueId, string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Get league positions in all queues for a given summoner ID. This method uses the League API.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Obsolete("Use GetLeagueEntriesBySummonerIdAsync instead")]
        Task<List<LeaguePosition>> GetLeaguePositionsBySummonerIdAsync(string summonerId, string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets league entries in all queues for a given summoner ID. This method uses the League API.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<List<LeagueEntry>> GetLeagueEntriesBySummonerIdAsync(string summonerId, string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets league entries for all summoners in a particular divison. This method uses the League API.
        /// </summary>
        /// <param name="rankedQueueType">The queue to search. This should equal one of the <see cref="RankedQueue"/> values.</param>
        /// <param name="tier">The ranked tier. This should equal one of the <see cref="Tier"/> values. NOTE: must be diamond league or lower. Master+ is not supported.</param>
        /// <param name="division">The ranked division. This should equal one of the <see cref="Division"/> values.</param>
        /// <param name="page">The page number to retrieve. The default value is 1 (the first page).</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<List<LeagueEntry>> GetLeagueEntriesAsync(string rankedQueueType, string tier, string division, long page = 1, string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the challenger league. This method uses the League API.
        /// </summary>
        /// <param name="rankedQueueType">The queue type. This should equal one of the <see cref="RankedQueue"/> values.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<LeagueList> GetChallengerLeagueAsync(string rankedQueueType, string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the grandmaster league. This method uses the League API.
        /// </summary>
        /// <param name="rankedQueueType">The queue type. This should equal one of the <see cref="RankedQueue"/> values.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<LeagueList> GetGrandmasterLeagueAsync(string rankedQueueType, string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the master league. This method uses the League API.
        /// </summary>
        /// <param name="rankedQueueType">The queue type. This should equal one of the <see cref="RankedQueue"/> values.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<LeagueList> GetMasterLeagueAsync(string rankedQueueType, string platformId = null, CancellationToken token = default(CancellationToken));
    }

    public partial class RiotClient
    {
        private const string leagueBasePath = "league/v4";

        /// <summary>
        /// Gets the full league information for all leagues that the summoners are in, including the leages for the teams they are on. Data is mapped by summoner ID. This method uses the League API.
        /// </summary>
        /// <param name="leagueId">The UIID of the league.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<LeagueList> GetLeagueByIdAsync(string leagueId, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<LeagueList>($"{leagueBasePath}/leagues/{leagueId}", $"{leagueBasePath}/leagues/{{leagueId}}", platformId, token);
        }

        /// <summary>
        /// Get league positions in all queues for a given summoner ID. This method uses the League API.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Obsolete("Use GetLeagueEntriesBySummonerIdAsync instead")]
        public Task<List<LeaguePosition>> GetLeaguePositionsBySummonerIdAsync(string summonerId, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<List<LeaguePosition>>($"{leagueBasePath}/positions/by-summoner/{summonerId}", $"{leagueBasePath}/positions/by-summoner/{{summonerId}}", platformId, token);
        }

        /// <summary>
        /// Get league entries in all queues for a given summoner ID. This method uses the League API.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<List<LeagueEntry>> GetLeagueEntriesBySummonerIdAsync(string summonerId, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<List<LeagueEntry>>($"{leagueBasePath}/entries/by-summoner/{summonerId}", $"{leagueBasePath}/entries/by-summoner/{{summonerId}}", platformId, token);
        }

        /// <summary>
        /// Gets league entries for all summoners in a particular divison. This method uses the League API.
        /// </summary>
        /// <param name="rankedQueueType">The queue to search. This should equal one of the <see cref="RankedQueue"/> values.</param>
        /// <param name="tier">The ranked tier. This should equal one of the <see cref="Tier"/> values.</param>
        /// <param name="division">The ranked division. This should equal one of the <see cref="Division"/> values.</param>
        /// <param name="page">The page number to retrieve. The default value is 1 (the first page).</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<List<LeagueEntry>> GetLeagueEntriesAsync(string rankedQueueType, string tier, string division, long page = 1, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            var queryParameters = new Dictionary<string, object>();
            if (page != 1)
                queryParameters["page"] = page;
            return GetAsync<List<LeagueEntry>>($"{leagueBasePath}/entries/{rankedQueueType}/{tier}/{division}", $"{leagueBasePath}/entries/{{queue}}/{{tier}}/{{division}}", platformId, token, queryParameters);
        }

        /// <summary>
        /// Gets the challenger league. This method uses the League API.
        /// </summary>
        /// <param name="rankedQueueType">The queue type. This should equal one of the <see cref="RankedQueue"/> values.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<LeagueList> GetChallengerLeagueAsync(string rankedQueueType, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<LeagueList>($"{leagueBasePath}/challengerleagues/by-queue/{rankedQueueType}", $"{leagueBasePath}/challengerleagues/by-queue/{{rankedQueueType}}", platformId, token);
        }

        /// <summary>
        /// Gets the grandmaster league. This method uses the League API.
        /// </summary>
        /// <param name="rankedQueueType">The queue type. This should equal one of the <see cref="RankedQueue"/> values.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<LeagueList> GetGrandmasterLeagueAsync(string rankedQueueType, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<LeagueList>($"{leagueBasePath}/grandmasterleagues/by-queue/{rankedQueueType}", $"{leagueBasePath}/grandmasterleagues/by-queue/{{rankedQueueType}}", platformId, token);
        }

        /// <summary>
        /// Gets the master league. This method uses the League API.
        /// </summary>
        /// <param name="rankedQueueType">The queue type. This should equal one of the <see cref="RankedQueue"/> values.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<LeagueList> GetMasterLeagueAsync(string rankedQueueType, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<LeagueList>($"{leagueBasePath}/masterleagues/by-queue/{rankedQueueType}", $"{leagueBasePath}/masterleagues/by-queue/{{rankedQueueType}}", platformId, token);
        }
    }
}
