using RiotNet.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RiotNet
{
    public partial interface IRiotClient
    {
        /// <summary>
        /// Gets the currently supported version of the Champion API that the client communicates with.
        /// </summary>
        string ChampionApiVersion { get; }

        /// <summary>
        /// Gets dynamic champion information for all champions. This method uses the Champion API.
        /// </summary>
        /// <param name="freeToPlay">True to request only free-to-play champion information. Default is false.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<List<Champion>> GetChampionsAsync(bool freeToPlay = false, PlatformId? platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets dynamic champion information for the specified champion. This method uses the Champion API.
        /// </summary>
        /// <param name="id">The champion id.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Champion> GetChampionByIdAsync(long id, CancellationToken token = default(CancellationToken));
    }

    public partial class RiotClient
    {
        /// <summary>
        /// Gets the currently supported version of the Champion API that the client communicates with.
        /// </summary>
        public string ChampionApiVersion { get { return "v3"; } }

        protected string GetChampionBaseUrl(PlatformId? platformId)
        {
            return $"https://{GetServerName(platformId)}/lol/platform/{ChampionApiVersion}/champions";
        }

        /// <summary>
        /// Gets dynamic champion information for all champions. This method uses the Champion API.
        /// </summary>
        /// <param name="freeToPlay">True to request only free-to-play champion information. Default is false.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task<List<Champion>> GetChampionsAsync(bool freeToPlay = false, PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            var resource = $"{GetChampionBaseUrl(platformId)}?freeToPlay={freeToPlay.ToString().ToLowerInvariant()}";
            var championList = await GetAsync<ChampionList>(resource, token).ConfigureAwait(false);
            return championList?.Champions;
        }

        /// <summary>
        /// Gets dynamic champion information for the specified champion. This method uses the Champion API.
        /// </summary>
        /// <param name="id">The champion id.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Champion> GetChampionByIdAsync(long id, PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<Champion>($"{GetChampionBaseUrl(platformId)}/{id}", token);
        }
    }
}
