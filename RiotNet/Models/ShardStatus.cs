using Newtonsoft.Json;
using System.Collections.Generic;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents detailed server information.
    /// </summary>
    public class ShardStatus
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
        /// Gets or sets list of server services.
        /// </summary>
        public List<Service> Services { get; set; }

        /// <summary>
        /// Gets or sets the region name (ex. "na").
        /// </summary>
        public string Slug { get; set; }
    }
}
