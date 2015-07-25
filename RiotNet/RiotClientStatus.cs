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
        private IRestRequest GetShardsRequest()
        {
            var request = Get("shards");
            // API key is not required.
            var apiKeyParam = request.Parameters.FirstOrDefault(p => p.Name == "api_key");
            if (apiKeyParam != null)
                request.Parameters.Remove(apiKeyParam);
            return request;
        }

        /// <summary>
        /// Gets the list of shards for all reagions.
        /// </summary>
        /// <returns>The shards.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public List<Shard> GetShards()
        {
            return Execute<List<Shard>>(GetShardsRequest());
        }

        /// <summary>
        /// Gets the list of shards for all reagions.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<List<Shard>> GetShardsTaskAsync()
        {
            return ExecuteTaskAsync<List<Shard>>(GetShardsRequest(), statusClient);
        }

        private IRestRequest GetShardStatusRequest()
        {
            var request = Get("shards/{region}");
            // API key is not required.
            var apiKeyParam = request.Parameters.FirstOrDefault(p => p.Name == "api_key");
            if (apiKeyParam != null)
                request.Parameters.Remove(apiKeyParam);
            return request;
        }

        /// <summary>
        /// Gets the status of the shard for the current region.
        /// </summary>
        /// <returns>The shard's status.</returns>
        public ShardStatus GetShardStatus()
        {
            return Execute<ShardStatus>(GetShardStatusRequest());
        }

        /// <summary>
        /// Gets the status of the shard for the current region.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<ShardStatus> GetShardStatusTaskAsync()
        {
            return ExecuteTaskAsync<ShardStatus>(GetShardStatusRequest(), statusClient);
        }
    }
}
