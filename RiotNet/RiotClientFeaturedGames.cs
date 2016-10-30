using RiotNet.Models;
using System.Threading.Tasks;

namespace RiotNet
{
    public partial class RiotClient
    {
        /// <summary>
        /// Gets the currently supported version of the Featured Game API that the client communicates with.
        /// </summary>
        public string FeaturedGameApiVersion { get { return "v1.0"; } }
        
        /// <summary>
        /// Gets the games currently featured in the League of Legends client. This method uses the Featured Game API.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<FeaturedGames> GetFeaturedGamesAsync()
        {
            return GetAsync<FeaturedGames>($"{mainBaseUrl}/observer-mode/rest/featured");
        }
    }
}
