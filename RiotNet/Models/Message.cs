using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents a server incident message.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Gets or sets the message author.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the message content.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the created time (in UTC) for the message.
        /// </summary>
        [JsonProperty("created_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the message id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets server incident message severity. This should equal one of the <see cref="Models.Severity"/> values.
        /// </summary>
        public string Severity { get; set; }

        /// <summary>
        /// Gets or sets the list of translations of the message.
        /// </summary>
        public List<Translation> Translations { get; set; }

        /// <summary>
        /// Gets or sets the message updated time in UTC.
        /// </summary>
        [JsonProperty("updated_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime UpdatedAt { get; set; }
    }
}
