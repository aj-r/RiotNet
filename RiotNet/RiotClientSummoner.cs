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
        private IRestRequest GetSummonersBySummonerNamesRequest(params String[] summonerNames)
        {
            var request = Get("api/lol/{region}/v1.4/summoner/by-name/{summonerNames}");
            request.AddUrlSegment("summonerNames", String.Join(",", summonerNames));
            return request;
        }

        /// <summary>
        /// Gets the summoner information for each summoner whose summoner name is in summonerNames.
        /// </summary>
        /// <param name="summonerNames">The summoner names.</param>
        /// <returns>The mapping from standardized summoner name (all lowercase, spaces removed) to summoner information.</returns>
        public Dictionary<String, Summoner> GetSummonersBySummonerNames(params String[] summonerNames)
        {
            return Execute<Dictionary<String, Summoner>>(GetSummonersBySummonerNamesRequest(summonerNames));
        }

        /// <summary>
        /// Gets the summoner information for each summoner whose summoner name is in summonerNames.
        /// </summary>
        /// <param name="summonerNames">The summoner names.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Dictionary<String, Summoner>> GetSummonersBySummonerNamesTaskAsync(params String[] summonerNames)
        {
            return ExecuteTaskAsync<Dictionary<String, Summoner>>(GetSummonersBySummonerNamesRequest(summonerNames));
        }

        private IRestRequest GetSummonersBySummonerIdsRequest(params long[] summonerIds)
        {
            var request = Get("api/lol/{region}/v1.4/summoner/by-name/{summonerIds}");
            request.AddUrlSegment("summonerIds", String.Join(",", summonerIds));
            return request;
        }

        /// <summary>
        /// Gets the summoner information for each summoner whose summoner ID is in summonerIds.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs.</param>
        /// <returns>The mapping from summoner ID to summoner information.</returns>
        public Dictionary<String, Summoner> GetSummonersBySummonerIds(params long[] summonerIds)
        {
            return Execute<Dictionary<String, Summoner>>(GetSummonersBySummonerIdsRequest(summonerIds));
        }

        /// <summary>
        /// Gets the summoner information for each summoner whose summoner ID is in summonerIds.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Dictionary<String, Summoner>> GetSummonersBySummonerIdsTaskAsync(params long[] summonerIds)
        {
            return ExecuteTaskAsync<Dictionary<String, Summoner>>(GetSummonersBySummonerIdsRequest(summonerIds));
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
        /// <param name="summonerIds">The summoner IDs.</param>
        /// <returns>The mapping from summoner ID to collection of mastery pages.</returns>
        public Dictionary<String, MasteryPages> GetSummonerMasteriesBySummonerIds(params long[] summonerIds)
        {
            return Execute<Dictionary<String, MasteryPages>>(GetSummonerMasteriesBySummonerIdsRequest(summonerIds));
        }

        /// <summary>
        /// Gets the mastery pages for each summoner whose summoner ID is in summonerIds.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Dictionary<String, MasteryPages>> GetSummonerMasteriesBySummonerIdsTaskAsync(params long[] summonerIds)
        {
            return ExecuteTaskAsync<Dictionary<String, MasteryPages>>(GetSummonerMasteriesBySummonerIdsRequest(summonerIds));
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
        /// <param name="summonerIds">The summoner IDs.</param>
        /// <returns>The mapping from summoner ID to summoner name.</returns>
        public Dictionary<String, String> GetSummonerNameBySummonerIds(params long[] summonerIds)
        {
            return Execute<Dictionary<String, String>>(GetSummonerNameBySummonerIdsRequest(summonerIds));
        }

        /// <summary>
        /// Gets the summoner name for each summoner whose summoner ID is in summonerIds.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Dictionary<String, String>> GetSummonerNameBySummonerIdsTaskAsync(params long[] summonerIds)
        {
            return ExecuteTaskAsync<Dictionary<String, String>>(GetSummonerNameBySummonerIdsRequest(summonerIds));
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
        /// <param name="summonerIds">The summoner IDs.</param>
        /// <returns>The mapping from summoner ID to collection of rune pages.</returns>
        public Dictionary<String, RunePages> GetSummonerRunesBySummonerIds(params long[] summonerIds)
        {
            return Execute<Dictionary<String, RunePages>>(GetSummonerRunesBySummonerIdsRequest(summonerIds));
        }

        /// <summary>
        /// Gets the rune pages for each summoner whose summoner ID is in summonerIds.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Dictionary<String, RunePages>> GetSummonerRunesBySummonerIdsTaskAsync(params long[] summonerIds)
        {
            return ExecuteTaskAsync<Dictionary<String, RunePages>>(GetSummonerRunesBySummonerIdsRequest(summonerIds));
        }
    }
}
