using RestSharp;
using RiotNet.Models;
using System.Threading.Tasks;
using System.Globalization;

namespace RiotNet
{
    public partial class RiotClient
    {
        /// <summary>
        /// Gets the currently supported version of the Current Game API that the client communicates with.
        /// </summary>
        public string CurrentGameApiVersion { get { return "v1.0"; } }

        private IRestRequest GetCurrentGameBySummonerIdRequest(long summonerId)
        {
            var request = Get("observer-mode/rest/consumer/getSpectatorGameInfo/{platformId}/{summonerId}");
            request.AddUrlSegment("summonerId", summonerId.ToString(CultureInfo.InvariantCulture));
            return request;
        }

        /// <summary>
        /// Gets information about the current game a summoner is playing. This method uses the Current Game API.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner ID.</param>
        /// <returns>The current game information.</returns>
        public CurrentGameInfo GetCurrentGameBySummonerId(long summonerId)
        {
            return Execute<CurrentGameInfo>(GetCurrentGameBySummonerIdRequest(summonerId));
        }

        /// <summary>
        /// Gets information about the current game a summoner is playing. This method uses the Current Game API.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner ID.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<CurrentGameInfo> GetCurrentGameBySummonerIdAsync(long summonerId)
        {
            return ExecuteAsync<CurrentGameInfo>(GetCurrentGameBySummonerIdRequest(summonerId));
        }
    }
}
