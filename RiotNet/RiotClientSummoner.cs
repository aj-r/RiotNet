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
        private IRestRequest GetSummonersBySummonerNames(params String[] summonerNames)
        {
            var request = Get("/api/lol/{region}/v1.4/summoner/by-name/{summonerNames}");
            request.AddUrlSegment("summonerNames", String.Join(",", summonerNames));
            return request;
        }

        /// <summary>
        /// Gets the summoner information for each summoner whose summoner name is in summonerNames.
        /// </summary>
        /// <param name="summonerNames">The summoner names.</param>
        /// <returns>The mapping from standardized summoner name (all lowercase, spaces removed) to summoner information.</returns>
        public Dictionary<String, Summoner> SummonersBySummonerNames(params String[] summonerNames)
        {
            return Execute<Dictionary<String, Summoner>>(GetSummonersBySummonerNames(summonerNames));
        }

        /// <summary>
        /// Gets the summoner information for each summoner whose summoner name is in summonerNames.
        /// </summary>
        /// <param name="summonerNames">The summoner names.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Dictionary<String, Summoner>> SummonersBySummonerNamesAsync(params String[] summonerNames)
        {
            return ExecuteTaskAsync<Dictionary<String, Summoner>>(GetSummonersBySummonerNames(summonerNames));
        }

        private IRestRequest GetSummonersBySummonerIds(params long[] summonerIds)
        {
            var request = Get("/api/lol/{region}/v1.4/summoner/by-name/{summonerIds}");
            request.AddUrlSegment("summonerIds", String.Join(",", summonerIds));
            return request;
        }

        /// <summary>
        /// Gets the summoner information for each summoner whose summoner ID is in summonerIds.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs.</param>
        /// <returns>The mapping from summoner ID to summoner information.</returns>
        public Dictionary<String, Summoner> SummonersBySummonerIds(params long[] summonerIds)
        {
            return Execute<Dictionary<String, Summoner>>(GetSummonersBySummonerIds(summonerIds));
        }

        /// <summary>
        /// Gets the summoner information for each summoner whose summoner ID is in summonerIds.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Dictionary<String, Summoner>> SummonersBySummonerIdsAsync(params long[] summonerIds)
        {
            return ExecuteTaskAsync<Dictionary<String, Summoner>>(GetSummonersBySummonerIds(summonerIds));
        }

        private IRestRequest GetSummonerMasteriesBySummonerIds(params long[] summonerIds)
        {
            var request = Get("/api/lol/{region}/v1.4/summoner/{summonerIds}/masteries");
            request.AddUrlSegment("summonerIds", String.Join(",", summonerIds));
            return request;
        }

        /// <summary>
        /// Gets the mastery pages for each summoner whose summoner ID is in summonerIds.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs.</param>
        /// <returns>The mapping from summoner ID to collection of mastery pages.</returns>
        public Dictionary<String, MasteryPages> SummonerMasteriesBySummonerIds(params long[] summonerIds)
        {
            return Execute<Dictionary<String, MasteryPages>>(GetSummonerMasteriesBySummonerIds(summonerIds));
        }

        /// <summary>
        /// Gets the mastery pages for each summoner whose summoner ID is in summonerIds.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Dictionary<String, MasteryPages>> SummonerMasteriesBySummonerIdsAsync(params long[] summonerIds)
        {
            return ExecuteTaskAsync<Dictionary<String, MasteryPages>>(GetSummonerMasteriesBySummonerIds(summonerIds));
        }

        private IRestRequest GetSummonerNameBySummonerIds(params long[] summonerIds)
        {
            var request = Get("/api/lol/{region}/v1.4/summoner/{summonerIds}/name");
            request.AddUrlSegment("summonerIds", String.Join(",", summonerIds));
            return request;
        }

        /// <summary>
        /// Gets the summoner name for each summoner whose summoner ID is in summonerIds.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs.</param>
        /// <returns>The mapping from summoner ID to summoner name.</returns>
        public Dictionary<String, String> SummonerNameBySummonerIds(params long[] summonerIds)
        {
            return Execute<Dictionary<String, String>>(GetSummonerNameBySummonerIds(summonerIds));
        }

        /// <summary>
        /// Gets the summoner name for each summoner whose summoner ID is in summonerIds.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Dictionary<String, String>> SummonerNameBySummonerIdsAsync(params long[] summonerIds)
        {
            return ExecuteTaskAsync<Dictionary<String, String>>(GetSummonerNameBySummonerIds(summonerIds));
        }

        private IRestRequest GetSummonerRunesBySummonerIds(params long[] summonerIds)
        {
            var request = Get("/api/lol/{region}/v1.4/summoner/{summonerIds}/runes");
            request.AddUrlSegment("summonerIds", String.Join(",", summonerIds));
            return request;
        }

        /// <summary>
        /// Gets the rune pages for each summoner whose summoner ID is in summonerIds.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs.</param>
        /// <returns>The mapping from summoner ID to collection of rune pages.</returns>
        public Dictionary<String, RunePages> SummonerRunesBySummonerIds(params long[] summonerIds)
        {
            return Execute<Dictionary<String, RunePages>>(GetSummonerRunesBySummonerIds(summonerIds));
        }

        /// <summary>
        /// Gets the rune pages for each summoner whose summoner ID is in summonerIds.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<Dictionary<String, RunePages>> SummonerRunesBySummonerIdsAsync(params long[] summonerIds)
        {
            return ExecuteTaskAsync<Dictionary<String, RunePages>>(GetSummonerRunesBySummonerIds(summonerIds));
        }
    }
}
