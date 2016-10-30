using RiotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiotNet
{
    public partial class RiotClient
    {
        /// <summary>
        /// Gets the currently supported version of the Summoner API that the client communicates with.
        /// </summary>
        public string SummonerApiVersion { get { return "v1.4"; } }

        /// <summary>
        /// Gets the summoner information for each summoner whose summoner name is in summonerNames. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerNames">The summoner names. The maximum allowed at once is 40.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Dictionary<string, Summoner>> GetSummonersBySummonerNamesAsync(params string[] summonerNames)
        {
            var summonerNameString = string.Join(",", summonerNames);
            return GetAsync<Dictionary<string, Summoner>>($"{mainBaseUrl}/api/lol/{region}/{SummonerApiVersion}/summoner/by-name/{summonerNameString}");
        }
        
        /// <summary>
        /// Gets the summoner information for the specified summoner. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerName">The summoner name.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task<Summoner> GetSummonerBySummonerNameAsync(string summonerName)
        {
            var summoners = await GetSummonersBySummonerNamesAsync(summonerName).ConfigureAwait(false);
            return summoners?.Values.FirstOrDefault();
        }

        /// <summary>
        /// Gets the summoner information for each summoner whose summoner ID is in summonerIds. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs. The maximum allowed at once is 40.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Dictionary<string, Summoner>> GetSummonersBySummonerIdsAsync(params long[] summonerIds)
        {
            var summonerIdString = string.Join(",", summonerIds);
            return GetAsync<Dictionary<string, Summoner>>($"{mainBaseUrl}/api/lol/{region}/{SummonerApiVersion}/summoner/{summonerIdString}");
        }

        /// <summary>
        /// Gets the summoner information for the specified summoner. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task<Summoner> GetSummonerBySummonerIdAsync(long summonerId)
        {
            var summoners = await GetSummonersBySummonerIdsAsync(summonerId).ConfigureAwait(false);
            return summoners != null ? summoners.Values.FirstOrDefault() : null;
        }

        /// <summary>
        /// Gets the mastery pages for each summoner whose summoner ID is in summonerIds. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs. The maximum allowed at once is 40.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Dictionary<string, MasteryPages>> GetSummonerMasteriesBySummonerIdsAsync(params long[] summonerIds)
        {
            var summonerIdString = string.Join(",", summonerIds);
            return GetAsync<Dictionary<string, MasteryPages>>($"{mainBaseUrl}/api/lol/{region}/{SummonerApiVersion}/summoner/{summonerIdString}/masteries");
        }

        /// <summary>
        /// Gets the summoner name for each summoner whose summoner ID is in summonerIds. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs. The maximum allowed at once is 40.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Dictionary<String, String>> GetSummonerNamesBySummonerIdsAsync(params long[] summonerIds)
        {
            var summonerIdString = string.Join(",", summonerIds);
            return GetAsync<Dictionary<string, string>>($"{mainBaseUrl}/api/lol/{region}/{SummonerApiVersion}/summoner/{summonerIdString}/name");
        }
        
        /// <summary>
        /// Gets the rune pages for each summoner whose summoner ID is in summonerIds. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs. The maximum allowed at once is 40.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Dictionary<String, RunePages>> GetSummonerRunesBySummonerIdsAsync(params long[] summonerIds)
        {
            var summonerIdString = string.Join(",", summonerIds);
            return GetAsync<Dictionary<string, RunePages>>($"{mainBaseUrl}/api/lol/{region}/{SummonerApiVersion}/summoner/{summonerIdString}/runes");
        }
    }
}
