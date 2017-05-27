using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

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
        /// Gets or sets the last translation update time in UTC.
        /// </summary>
        [JsonProperty("updated_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime UpdatedAt { get; set; }
    }
}
