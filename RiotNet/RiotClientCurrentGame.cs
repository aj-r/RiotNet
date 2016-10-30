using RiotNet.Models;
using System.Threading.Tasks;

namespace RiotNet
{
    public partial class RiotClient
    {
        /// <summary>
        /// Gets the currently supported version of the Current Game API that the client communicates with.
        /// </summary>
        public string CurrentGameApiVersion { get { return "v1.0"; } }

        /// <summary>
        /// Gets information about the current game a summoner is playing. This method uses the Current Game API.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<CurrentGameInfo> GetCurrentGameBySummonerIdAsync(long summonerId)
        {
            return GetAsync<CurrentGameInfo>($"{mainBaseUrl}/observer-mode/rest/consumer/getSpectatorGameInfo/{platformId}/{summonerId}");
        }
    }
}
