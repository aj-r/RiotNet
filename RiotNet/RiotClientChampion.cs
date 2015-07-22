using System;
using System.Threading.Tasks;
using RestSharp;
using RiotNet.Models;
using System.Collections.Generic;

namespace RiotNet
{
    public partial class RiotClient
    {
        private IRestRequest GetChampionsRequest(Boolean freeToPlay)
        {
            var request = Get("api/lol/{region}/v1.2/champion");
            request.AddQueryParameter("freeToPlay", freeToPlay.ToString().ToLower());
            return request;
        }

        /// <summary>
        /// Gets all champion information (bot enabled, free to play, etc. Also see static champion data).
        /// </summary>
        /// <param name="freeToPlay">True if only requesting free to play champion information. Default is false.</param>
        /// <returns>List of champion information.</returns>
        public List<Champion> GetChampions(Boolean freeToPlay = false)
        {
            return Execute<ChampionList>(GetChampionsRequest(freeToPlay)).Champions;
        }

        /// <summary>
        /// Gets all champion information (bot enabled, free to play, etc. Also see static champion data).
        /// </summary>
        /// <param name="freeToPlay">True if only requesting free to play champion information. Default is false.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task<List<Champion>> GetChampionsTaskAsync(Boolean freeToPlay = false)
        {
            var champions = await ExecuteTaskAsync<ChampionList>(GetChampionsRequest(freeToPlay));
            return champions.Champions;
        }

        private IRestRequest GetChampionByIdRequest(long id)
        {
            var request = Get("api/lol/{region}/v1.2/champion/{id}");
            request.AddUrlSegment("id", id.ToString());
            return request;
        }

        /// <summary>
        /// Gets chosen champion information (bot enabled, free to play, etc. Also see static champion data).
        /// </summary>
        /// <param name="id">Champion id.</param>
        /// <returns>Champion information.</returns>
        public Champion GetChampionById(long id)
        {
            return Execute<Champion>(GetChampionByIdRequest(id));
        }

        /// <summary>
        /// Gets chosen champion information (bot enabled, free to play, etc. Also see static champion data).
        /// </summary>
        /// <param name="id">Champion id.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Champion> GetChampionByIdTaskAsync(long id)
        {
            return ExecuteTaskAsync<Champion>(GetChampionByIdRequest(id));
        }
    }
}
