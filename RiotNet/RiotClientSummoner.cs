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
        /// Gets the currently supported version of the Summoner API that the client communicates with.
        /// </summary>
        public string SummonerApiVersion { get { return "v1.4"; } }

        private IRestRequest GetSummonersBySummonerNamesRequest(params String[] summonerNames)
        {
            var request = Get("api/lol/{region}/v1.4/summoner/by-name/{summonerNames}");
            request.AddUrlSegment("summonerNames", String.Join(",", summonerNames));
            return request;
        }

        /// <summary>
        /// Gets the summoner information for each summoner whose summoner name is in summonerNames.
        /// </summary>
        /// <param name="summonerNames">The summoner names. The maximum allowed at once is 40.</param>
        /// <returns>The mapping from standardized summoner name (all lowercase, spaces removed) to summoner information.</returns>
        public Dictionary<String, Summoner> GetSummonersBySummonerNames(params String[] summonerNames)
        {
            return Execute<Dictionary<String, Summoner>>(GetSummonersBySummonerNamesRequest(summonerNames));
        }

        /// <summary>
        /// Gets the summoner information for each summoner whose summoner name is in summonerNames.
        /// </summary>
        /// <param name="summonerNames">The summoner names. The maximum allowed at once is 40.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Dictionary<String, Summoner>> GetSummonersBySummonerNamesAsync(params String[] summonerNames)
        {
            return ExecuteAsync<Dictionary<String, Summoner>>(GetSummonersBySummonerNamesRequest(summonerNames));
        }

        /// <summary>
        /// Gets the summoner information for the specified summoner.
        /// </summary>
        /// <param name="summonerName">The summoner name.</param>
        /// <returns>A <see cref="Summoner"/>.</returns>
        public Summoner GetSummonerBySummonerName(String summonerName)
        {
            var summoners = GetSummonersBySummonerNames(summonerName);
            return summoners != null ? summoners.Values.FirstOrDefault() : null;
        }

        /// <summary>
        /// Gets the summoner information for the specified summoner.
        /// </summary>
        /// <param name="summonerName">The summoner name.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task<Summoner> GetSummonerBySummonerNameAsync(String summonerName)
        {
            var summoners = await GetSummonersBySummonerNamesAsync(summonerName).ConfigureAwait(false);
            return summoners != null ? summoners.Values.FirstOrDefault() : null;
        }

        private IRestRequest GetSummonersBySummonerIdsRequest(params long[] summonerIds)
        {
            var request = Get("api/lol/{region}/v1.4/summoner/{summonerIds}");
            request.AddUrlSegment("summonerIds", String.Join(",", summonerIds));
            return request;
        }

        /// <summary>
        /// Gets the summoner information for each summoner whose summoner ID is in summonerIds.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs. The maximum allowed at once is 40.</param>
        /// <returns>The mapping from summoner ID to summoner information.</returns>
        public Dictionary<String, Summoner> GetSummonersBySummonerIds(params long[] summonerIds)
        {
            return Execute<Dictionary<String, Summoner>>(GetSummonersBySummonerIdsRequest(summonerIds));
        }

        /// <summary>
        /// Gets the summoner information for each summoner whose summoner ID is in summonerIds.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs. The maximum allowed at once is 40.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Dictionary<String, Summoner>> GetSummonersBySummonerIdsAsync(params long[] summonerIds)
        {
            return ExecuteAsync<Dictionary<String, Summoner>>(GetSummonersBySummonerIdsRequest(summonerIds));
        }

        /// <summary>
        /// Gets the summoner information for the specified summoner.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <returns>A <see cref="Summoner"/>.</returns>
        public Summoner GetSummonerBySummonerId(long summonerId)
        {
            var summoners = GetSummonersBySummonerIds(summonerId);
            return summoners != null ? summoners.Values.FirstOrDefault() : null;
        }

        /// <summary>
        /// Gets the summoner information for the specified summoner.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task<Summoner> GetSummonerBySummonerIdAsync(long summonerId)
        {
            var summoners = await GetSummonersBySummonerIdsAsync(summonerId).ConfigureAwait(false);
            return summoners != null ? summoners.Values.FirstOrDefault() : null;
        }

        private IRestRequest GetSummonerMasteriesBySummonerIdsRequest(params long[] summonerIds)
        {
            var request = Get("api/lol/{region}/v1.4/summoner/{summonerIds}/masteries");
            request.AddUrlSegment("summonerIds", String.Join(",", summonerIds));
            return request;
        }

        /// <summary>
        /// Gets the mastery pages for each summoner whose summoner ID is in summonerIds.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs. The maximum allowed at once is 40.</param>
        /// <returns>The mapping from summoner ID to collection of mastery pages.</returns>
        public Dictionary<String, MasteryPages> GetSummonerMasteriesBySummonerIds(params long[] summonerIds)
        {
            return Execute<Dictionary<String, MasteryPages>>(GetSummonerMasteriesBySummonerIdsRequest(summonerIds));
        }

        /// <summary>
        /// Gets the mastery pages for each summoner whose summoner ID is in summonerIds.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs. The maximum allowed at once is 40.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Dictionary<String, MasteryPages>> GetSummonerMasteriesBySummonerIdsAsync(params long[] summonerIds)
        {
            return ExecuteAsync<Dictionary<String, MasteryPages>>(GetSummonerMasteriesBySummonerIdsRequest(summonerIds));
        }

        private IRestRequest GetSummonerNameBySummonerIdsRequest(params long[] summonerIds)
        {
            var request = Get("api/lol/{region}/v1.4/summoner/{summonerIds}/name");
            request.AddUrlSegment("summonerIds", String.Join(",", summonerIds));
            return request;
        }

        /// <summary>
        /// Gets the summoner name for each summoner whose summoner ID is in summonerIds.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs. The maximum allowed at once is 40.</param>
        /// <returns>The mapping from summoner ID to summoner name.</returns>
        public Dictionary<String, String> GetSummonerNamesBySummonerIds(params long[] summonerIds)
        {
            return Execute<Dictionary<String, String>>(GetSummonerNameBySummonerIdsRequest(summonerIds));
        }

        /// <summary>
        /// Gets the summoner name for each summoner whose summoner ID is in summonerIds.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs. The maximum allowed at once is 40.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Dictionary<String, String>> GetSummonerNamesBySummonerIdsAsync(params long[] summonerIds)
        {
            return ExecuteAsync<Dictionary<String, String>>(GetSummonerNameBySummonerIdsRequest(summonerIds));
        }

        private IRestRequest GetSummonerRunesBySummonerIdsRequest(params long[] summonerIds)
        {
            var request = Get("api/lol/{region}/v1.4/summoner/{summonerIds}/runes");
            request.AddUrlSegment("summonerIds", String.Join(",", summonerIds));
            return request;
        }

        /// <summary>
        /// Gets the rune pages for each summoner whose summoner ID is in summonerIds.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs. The maximum allowed at once is 40.</param>
        /// <returns>The mapping from summoner ID to collection of rune pages.</returns>
        public Dictionary<String, RunePages> GetSummonerRunesBySummonerIds(params long[] summonerIds)
        {
            return Execute<Dictionary<String, RunePages>>(GetSummonerRunesBySummonerIdsRequest(summonerIds));
        }

        /// <summary>
        /// Gets the rune pages for each summoner whose summoner ID is in summonerIds.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs. The maximum allowed at once is 40.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Dictionary<String, RunePages>> GetSummonerRunesBySummonerIdsAsync(params long[] summonerIds)
        {
            return ExecuteAsync<Dictionary<String, RunePages>>(GetSummonerRunesBySummonerIdsRequest(summonerIds));
        }
    }
}
