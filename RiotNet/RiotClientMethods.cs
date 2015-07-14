using System;
using System.Threading.Tasks;
using RiotNet.Models;

namespace RiotNet
{
    public partial class RiotClient
    {
        public Task<League> GetMasterLeaguesTaskAsync(RankedQueue type)
        {
            var request = Get("api/lol/{region}/v2.5/league/master");
            request.AddQueryParameter("type", type.ToString());
            return ExecuteTaskAsync<League>(request);
        }
    }
}
