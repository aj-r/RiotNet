using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

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
        /// Gets or sets the created time for the message.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the message id.
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets server incident message severity.
        /// </summary>
        public Severity Severity { get; set; }

        /// <summary>
        /// Gets or sets the list of translations of the message.
        /// </summary>
        public List<Translation> Translations { get; set; }

        /// <summary>
        /// Gets or sets the message updated time.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
