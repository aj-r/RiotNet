using System.Collections.Generic;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents detailed server information.
    /// </summary>
    public class ShardStatus : Shard
    {
        /// <summary>
        /// Gets or sets list of server services.
        /// </summary>
        public List<Service> Services { get; set; }
    }
}
