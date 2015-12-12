using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents an event that occurred in a game lobby.
    /// </summary>
    public class LobbyEvent
    {
        /// <summary>
        /// Gets or sets the type of event that occurred.
        /// </summary>
        public string EventType { get; set; }

        /// <summary>
        /// Gets or sets the ID of the summoner who triggered the event, if any.
        /// </summary>
        public long? SummonerId { get; set; }
        
        /// <summary>
        /// Gets or sets time at which the event occurred.
        /// </summary>
        public DateTime Timestamp { get; set; }

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the <see cref="LobbyEvent"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long DatabaseId { get; set; }
#endif
    }
}
