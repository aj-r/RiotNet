using RestSharp;
using RiotNet.Models;
using System;
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

        private IRestRequest GetChampionsRequest(Boolean freeToPlay)
        {
            var request = Get("api/lol/{region}/v1.2/champion");
            request.AddQueryParameter("freeToPlay", freeToPlay.ToString().ToLower());
            return request;
        }

        /// <summary>
        /// Gets dynamic champion information for all champions. This method uses the Champion API.
        /// </summary>
        /// <param name="freeToPlay">True if only requesting free to play champion information. Default is false.</param>
        /// <returns>List of champion information.</returns>
        public List<Champion> GetChampions(Boolean freeToPlay = false)
        {
            var championList = Execute<ChampionList>(GetChampionsRequest(freeToPlay));
            return championList != null ? championList.Champions : null;
        }

        /// <summary>
        /// Gets dynamic champion information for all champions. This method uses the Champion API.
        /// </summary>
        /// <param name="freeToPlay">True if only requesting free to play champion information. Default is false.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task<List<Champion>> GetChampionsAsync(Boolean freeToPlay = false)
        {
            var championList = await ExecuteAsync<ChampionList>(GetChampionsRequest(freeToPlay)).ConfigureAwait(false);
            return championList != null ? championList.Champions : null;
        }

        private IRestRequest GetChampionByIdRequest(long id)
        {
            var request = Get("api/lol/{region}/v1.2/champion/{id}");
            request.AddUrlSegment("id", id.ToString());
            return request;
        }

        /// <summary>
        /// Gets dynamic champion information for the specified champion. This method uses the Champion API.
        /// </summary>
        /// <param name="id">The champion id.</param>
        /// <returns>Champion information.</returns>
        public Champion GetChampionById(long id)
        {
            return Execute<Champion>(GetChampionByIdRequest(id));
        }

        /// <summary>
        /// Gets dynamic champion information for the specified champion. This method uses the Champion API.
        /// </summary>
        /// <param name="id">The champion id.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Champion> GetChampionByIdAsync(long id)
        {
            return ExecuteAsync<Champion>(GetChampionByIdRequest(id));
        }
    }
}
