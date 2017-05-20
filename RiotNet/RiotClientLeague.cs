using RiotNet.Models;
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
        /// <param name="summonerId">The summoner ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<List<LeagueList>> GetLeaguesBySummonerIdAsync(long summonerId, PlatformId? platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Get league positions in all queues for a given summoner ID. This method uses the League API.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<List<LeaguePosition>> GetPositionsBySummonerIdAsync(long summonerId, PlatformId? platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the challenger league. This method uses the League API.
        /// </summary>
        /// <param name="type">The queue type.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<LeagueList> GetChallengerLeagueAsync(RankedQueue type, PlatformId? platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the master league. This method uses the League API.
        /// </summary>
        /// <param name="type">The queue type.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<LeagueList> GetMasterLeagueAsync(RankedQueue type, PlatformId? platformId = null, CancellationToken token = default(CancellationToken));
    }

    public partial class RiotClient
    {
        /// <summary>
        /// Gets the base URL for league requests.
        /// </summary>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <returns>The base URL.</returns>
        protected string GetLeagueBaseUrl(PlatformId? platformId)
        {
            return $"https://{GetServerName(platformId)}/lol/league/v3";
        }

        public Task<List<LeagueList>> GetLeaguesBySummonerIdAsync(long summonerId, PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<List<LeagueList>>($"{GetLeagueBaseUrl(platformId)}/leagues/by-summoner/{summonerId}", token);
        }

        public Task<List<LeaguePosition>> GetPositionsBySummonerIdAsync(long summonerId, PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<List<LeaguePosition>>($"{GetLeagueBaseUrl(platformId)}/positions/by-summoner/{summonerId}", token);
        }

        public Task<LeagueList> GetChallengerLeagueAsync(RankedQueue type, PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<LeagueList>($"{GetLeagueBaseUrl(platformId)}/challengerleagues/by-queue/{type}", token);
        }

        public Task<LeagueList> GetMasterLeagueAsync(RankedQueue type, PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<LeagueList>($"{GetLeagueBaseUrl(platformId)}/masterleagues/by-queue/{type}", token);
        }
    }
}
