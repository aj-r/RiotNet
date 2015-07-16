using System;
using System.Threading.Tasks;
using RiotNet.Models;

namespace RiotNet
{
    public partial class RiotClient
    {
        /// <summary>
        /// Gets the master league.
        /// </summary>
        /// <param name="type">The queue type.</param>
        /// <returns>The master league.</returns>
        public Task<League> GetMasterLeagueTaskAsync(RankedQueue type)
        {
            var request = Get("api/lol/{region}/v2.5/league/master");
            request.AddQueryParameter("type", type.ToString());
            return ExecuteTaskAsync<League>(request);
        }
    }
}
