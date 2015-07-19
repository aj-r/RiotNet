using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
