using RiotNet.Models;
using System.Threading;
using System.Threading.Tasks;

namespace RiotNet
{
    public partial interface IRiotClient
    {
        /// <summary>
        /// Gets the summoner information by account ID. This method uses the Summoner API.
        /// </summary>
        /// <param name="accountId">The account ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Summoner> GetSummonerByAccountIdAsync(string accountId, string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the summoner information for the specified summoner name. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerName">The summoner name.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Summoner> GetSummonerBySummonerNameAsync(string summonerName, string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the summoner information for the specified summoner ID. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Summoner> GetSummonerBySummonerIdAsync(string summonerId, string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the summoner information for the specified summoner ID. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerPuuid">The summoner PUUID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Summoner> GetSummonerByPuuidAsync(string summonerPuuid, string platformId = null, CancellationToken token = default(CancellationToken));
    }

    public partial class RiotClient
    {
        private const string summonerBasePath = "summoner/v4";

        /// <summary>
        /// Gets the summoner information by account ID. This method uses the Summoner API.
        /// </summary>
        /// <param name="accountId">The account ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Summoner> GetSummonerByAccountIdAsync(string accountId, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<Summoner>($"{summonerBasePath}/summoners/by-account/{accountId}", $"{summonerBasePath}/summoners/by-account/{{accountId}}",
                platformId, token);
        }

        /// <summary>
        /// Gets the summoner information for the specified summoner name. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerName">The summoner name.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Summoner> GetSummonerBySummonerNameAsync(string summonerName, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<Summoner>($"{summonerBasePath}/summoners/by-name/{summonerName}", $"{summonerBasePath}/summoners/by-name/{{summonerName}}",
                platformId, token);
        }

        /// <summary>
        /// Gets the summoner information for the specified summoner ID. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Summoner> GetSummonerBySummonerIdAsync(string summonerId, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<Summoner>($"{summonerBasePath}/summoners/{summonerId}", $"{summonerBasePath}/summoners/{{summonerId}}",
                platformId, token);
        }

        /// <summary>
        /// Gets the summoner information for the specified summoner ID. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerPuuid">The summoner PUUID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Summoner> GetSummonerByPuuidAsync(string summonerPuuid, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<Summoner>($"{summonerBasePath}/summoners/by-puuid/{summonerPuuid}", $"{summonerBasePath}/summoners/by-puuid/{{summonerPuuid}}",
                platformId, token);
        }
    }
}
