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
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Summoner> GetSummonerByAccountIdAsync(long accountId, PlatformId? platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the summoner information for the specified summoner name. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerName">The summoner name.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Summoner> GetSummonerBySummonerNameAsync(string summonerName, PlatformId? platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the summoner information for the specified summoner ID. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Summoner> GetSummonerBySummonerIdAsync(long summonerId, PlatformId? platformId = null, CancellationToken token = default(CancellationToken));
    }

    public partial class RiotClient
    {
        /// <summary>
        /// Gets the base URL for summoner requests.
        /// </summary>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <returns>The base URL.</returns>
        protected string GetSummonerBaseUrl(PlatformId? platformId)
        {
            return $"https://{GetServerName(platformId)}/lol/summoner/v3";
        }

        /// <summary>
        /// Gets the summoner information by account ID. This method uses the Summoner API.
        /// </summary>
        /// <param name="accountId">The account ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Summoner> GetSummonerByAccountIdAsync(long accountId, PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<Summoner>($"{GetSummonerBaseUrl(platformId)}/summoners/by-account/{accountId}", token);
        }

        /// <summary>
        /// Gets the summoner information for the specified summoner name. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerName">The summoner name.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Summoner> GetSummonerBySummonerNameAsync(string summonerName, PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<Summoner>($"{GetSummonerBaseUrl(platformId)}/summoners/by-name/{summonerName}", token);
        }

        /// <summary>
        /// Gets the summoner information for the specified summoner ID. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Summoner> GetSummonerBySummonerIdAsync(long summonerId, PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<Summoner>($"{GetSummonerBaseUrl(platformId)}/summoners/{summonerId}", token);
        }
    }
}
