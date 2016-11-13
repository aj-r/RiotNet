using RiotNet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiotNet
{
    public partial class RiotClient
    {
        /// <summary>
        /// Gets the currently supported version of the Champion API that the client communicates with.
        /// </summary>
        public string ChampionApiVersion { get { return "v1.2"; } }
        
        /// <summary>
        /// Gets dynamic champion information for all champions. This method uses the Champion API.
        /// </summary>
        /// <param name="freeToPlay">True if only requesting free to play champion information. Default is false.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task<List<Champion>> GetChampionsAsync(bool freeToPlay = false)
        {
            var resource = $"{mainBaseUrl}/api/lol/{lowerRegion}/{ChampionApiVersion}/champion?freeToPlay={freeToPlay.ToString().ToLowerInvariant()}";
            var championList = await GetAsync<ChampionList>(resource).ConfigureAwait(false);
            return championList != null ? championList.Champions : null;
        }

        /// <summary>
        /// Gets dynamic champion information for the specified champion. This method uses the Champion API.
        /// </summary>
        /// <param name="id">The champion id.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Champion> GetChampionByIdAsync(long id)
        {
            return GetAsync<Champion>($"{mainBaseUrl}/api/lol/{lowerRegion}/{ChampionApiVersion}/champion/{id}");
        }
    }
}
