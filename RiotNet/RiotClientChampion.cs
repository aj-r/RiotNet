using RiotNet.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RiotNet
{
    public partial interface IRiotClient
    {
        /// <summary>
        /// Gets dynamic champion information for all champions. This method uses the Champion API.
        /// </summary>
        /// <param name="freeToPlay">True to request only free-to-play champion information. Default is false.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<List<Champion>> GetChampionsAsync(bool freeToPlay = false, string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets dynamic champion information for the specified champion. This method uses the Champion API.
        /// </summary>
        /// <param name="id">The champion id.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Champion> GetChampionByIdAsync(long id, string platformId = null, CancellationToken token = default(CancellationToken));
    }

    public partial class RiotClient
    {
        private const string championBasePath = "platform/v3";

        /// <summary>
        /// Gets dynamic champion information for all champions. This method uses the Champion API.
        /// </summary>
        /// <param name="freeToPlay">True to request only free-to-play champion information. Default is false.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task<List<Champion>> GetChampionsAsync(bool freeToPlay = false, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            var resource = $"{championBasePath}/champions?freeToPlay={(freeToPlay ? "true" : "false")}";
            var championList = await GetAsync<ChampionList>(resource, $"{championBasePath}/champions", platformId, token).ConfigureAwait(false);
            return championList?.Champions;
        }

        /// <summary>
        /// Gets dynamic champion information for the specified champion. This method uses the Champion API.
        /// </summary>
        /// <param name="id">The champion id.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Champion> GetChampionByIdAsync(long id, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<Champion>($"{championBasePath}/champions/{id}", $"{championBasePath}/champions/{{id}}", platformId, token);
        }
    }
}
