using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents the server information.
    /// </summary>
    public class Shard
    {
        /// <summary>
        /// Gets or sets the server hostname.
        /// </summary>
        public string Hostname { get; set; }

        /// <summary>
        /// Gets or sets the list of locales for the server.
        /// </summary>
        public List<string> Locales { get; set; }

        /// <summary>
        /// Gets or sets the name for the server.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the region tag for the server. This is similar to the platform ID, but it is not set for all regions.
        /// </summary>
        [JsonProperty("region_tag")]
        public string RegionTag { get; set; }

        /// <summary>
        /// Gets or sets the region name (ex. "na").
        /// </summary>
        public string Slug { get; set; }
    }
}
