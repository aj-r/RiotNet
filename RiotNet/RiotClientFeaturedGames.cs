using RestSharp;
using RiotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotNet
{
    public partial class RiotClient
    {
        /// <summary>
        /// Gets the currently supported version of the Featured Game API that the client communicates with.
        /// </summary>
        public string FeaturedGameApiVersion { get { return "v1.0"; } }

        private IRestRequest GetFeaturedGamesRequest()
        {
            return Get("observer-mode/rest/featured");
        }

        /// <summary>
        /// Gets the games currently featured in the League of Legends client. This method uses the Featured Game API.
        /// </summary>
        /// <returns>The featured games.</returns>
        public FeaturedGames GetFeaturedGames()
        {
            return Execute<FeaturedGames>(GetFeaturedGamesRequest());
        }

        /// <summary>
        /// Gets the games currently featured in the League of Legends client. This method uses the Featured Game API.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<FeaturedGames> GetFeaturedGamesAsync()
        {
            return ExecuteAsync<FeaturedGames>(GetFeaturedGamesRequest());
        }
    }
}
