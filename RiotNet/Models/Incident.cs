using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Converters;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents a server incident report.
    /// </summary>
    public class Incident
    {
        /// <summary>
        /// Gets or sets flag stating if incident is active.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets incident created time in UTC.
        /// </summary>
        [JsonProperty("created_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets incident id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets list of update messages for the incident.
        /// </summary>
        public List<Message> Updates { get; set; }
    }
}
