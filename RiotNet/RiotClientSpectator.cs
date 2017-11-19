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
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<CurrentGameInfo> GetActiveGameBySummonerIdAsync(long summonerId, string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the games currently featured in the League of Legends client. This method uses the Spectator API.
        /// </summary>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<FeaturedGames> GetFeaturedGamesAsync(string platformId = null, CancellationToken token = default(CancellationToken));
    }

    public partial class RiotClient
    {
        private const string spectatorBasePath = "spectator/v3";

        /// <summary>
        /// Gets information about the current game a summoner is playing. This method uses the Spectator API.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<CurrentGameInfo> GetActiveGameBySummonerIdAsync(long summonerId, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<CurrentGameInfo>($"{spectatorBasePath}/active-games/by-summoner/{summonerId}", $"{spectatorBasePath}/active-games/by-summoner/{{summonerId}}", platformId, token);
        }

        /// <summary>
        /// Gets the games currently featured in the League of Legends client. This method uses the Spectator API.
        /// </summary>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<FeaturedGames> GetFeaturedGamesAsync(string platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<FeaturedGames>($"{spectatorBasePath}/featured-games", $"{spectatorBasePath}/featured-games", platformId, token);
        }
    }
}
