using RiotNet.Models;
using System.Threading.Tasks;

namespace RiotNet
{
    public partial class RiotClient
    {
        /// <summary>
        /// Gets the currently supported version of the Game API that the client communicates with.
        /// </summary>
        public string GameApiVersion { get { return "v1.3"; } }
        
        /// <summary>
        /// Gets the recent games for a summoner. This method uses the Game API.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner ID.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<RecentGames> GetGamesBySummonerIdAsync(long summonerId)
        {
            return GetAsync<RecentGames>($"{mainBaseUrl}/api/lol/{lowerRegion}/{GameApiVersion}/game/by-summoner/{summonerId}/recent");
        }
    }
}
