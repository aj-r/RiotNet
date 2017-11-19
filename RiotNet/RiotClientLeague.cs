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
        /// Gets the full league information for all leagues that the summoners are in, including the leages for the teams they are on. Data is mapped by summoner ID. This method uses the League API.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Obsolete("Use GetLeagueByIdAsync and/or GetLeaguePositionsBySummonerIdAsync instead")]
        Task<List<LeagueList>> GetLeaguesBySummonerIdAsync(long summonerId, string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Get league positions in all queues for a given summoner ID. This method uses the League API.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<List<LeaguePosition>> GetLeaguePositionsBySummonerIdAsync(long summonerId, string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the challenger league. This method uses the League API.
        /// </summary>
        /// <param name="rankedQueueType">The queue type. This should equal one of the <see cref="RankedQueue"/> values.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<LeagueList> GetChallengerLeagueAsync(string rankedQueueType, string platformId = null, CancellationToken token = default(CancellationToken));

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
        private const string leagueBasePath = "league/v3";

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
        /// Gets the full league information for all leagues that the summoners are in, including the leages for the teams they are on. Data is mapped by summoner ID. This method uses the League API.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Obsolete("Use GetLeagueByIdAsync and/or GetLeaguePositionsBySummonerIdAsync instead")]
        public Task<List<LeagueList>> GetLeaguesBySummonerIdAsync(long summonerId, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<List<LeagueList>>($"{leagueBasePath}/leagues/by-summoner/{summonerId}", $"{leagueBasePath}/leagues/by-summoner/{{summonerId}}", platformId, token);
        }

        /// <summary>
        /// Get league positions in all queues for a given summoner ID. This method uses the League API.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<List<LeaguePosition>> GetLeaguePositionsBySummonerIdAsync(long summonerId, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<List<LeaguePosition>>($"{leagueBasePath}/positions/by-summoner/{summonerId}", $"{leagueBasePath}/positions/by-summoner/{{summonerId}}", platformId, token);
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
