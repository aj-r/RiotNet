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
            return Get("shards");
        }

        /// <summary>
        /// Gets the list of shards.
        /// </summary>
        /// <returns>The shards.</returns>
        public List<Shard> GetShards()
        {
            return Execute<List<Shard>>(GetShardsRequest());
        }

        /// <summary>
        /// Gets the list of shards.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<List<Shard>> GetShardsTaskAsync()
        {
            return ExecuteTaskAsync<List<Shard>>(GetShardsRequest());
        }

        private IRestRequest GetShardStatusRequest()
        {
            return Get("shards/{region}");
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
            return ExecuteTaskAsync<ShardStatus>(GetShardStatusRequest());
        }
    }
}
