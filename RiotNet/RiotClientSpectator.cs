using RiotNet.Models;
using System.Threading;
using System.Threading.Tasks;

namespace RiotNet
{
    public partial interface IRiotClient
    {
        /// <summary>
        /// Gets information about the current game a summoner is playing. This method uses the Spectator API.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<CurrentGameInfo> GetActiveGameBySummonerIdAsync(long summonerId, PlatformId? platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the games currently featured in the League of Legends client. This method uses the Spectator API.
        /// </summary>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<FeaturedGames> GetFeaturedGamesAsync(PlatformId? platformId = null, CancellationToken token = default(CancellationToken));
    }

    public partial class RiotClient
    {
        /// <summary>
        /// Gets the base URL for spectator requests.
        /// </summary>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <returns>The base URL.</returns>
        protected string GetSpectatorBaseUrl(PlatformId? platformId)
        {
            return $"https://{GetServerName(platformId)}/lol/spectator/v3";
        }

        /// <summary>
        /// Gets information about the current game a summoner is playing. This method uses the Spectator API.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<CurrentGameInfo> GetActiveGameBySummonerIdAsync(long summonerId, PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<CurrentGameInfo>($"{GetSpectatorBaseUrl(platformId)}/active-games/by-summoner/{summonerId}", token);
        }

        /// <summary>
        /// Gets the games currently featured in the League of Legends client. This method uses the Spectator API.
        /// </summary>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<FeaturedGames> GetFeaturedGamesAsync(PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<FeaturedGames>($"{GetSpectatorBaseUrl(platformId)}/featured-games", token);
        }
    }
}
