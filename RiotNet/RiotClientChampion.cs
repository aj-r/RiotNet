using System;
using System.Threading.Tasks;
using RestSharp;
using RiotNet.Models;
using System.Collections.Generic;

namespace RiotNet
{
    public partial class RiotClient
    {
        private IRestRequest GetChampionsRequest()
        {
            var request = Get("api/lol/{region}/v1.2/champion");
            return request;
        }

        /// <summary>
        /// Gets all champion information (bot enabled, free to play, etc. Also see static champion data).
        /// </summary>
        /// <returns>List of champion information.</returns>
        public List<Champion> GetChampions()
        {
            return Execute<ChampionList>(GetChampionsRequest()).Champions;
        }

        /// <summary>
        /// Gets all champion information (bot enabled, free to play, etc. Also see static champion data).
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task<List<Champion>> GetChampionsTaskAsync()
        {
            var champions = await ExecuteTaskAsync<ChampionList>(GetChampionsRequest()).ConfigureAwait(false);
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
