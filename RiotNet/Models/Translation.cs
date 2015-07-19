using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents a message translation.
    /// </summary>
    public class Translation
    {
        /// <summary>
        /// Gets or sets the translation content.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the translation locale.
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// Gets or sets the translation update time.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
