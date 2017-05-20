using Newtonsoft.Json;
using RiotNet.Converters;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// This object contains some basic match information. Used as a part of the Matchlist API in <see cref="MatchList"/>.
    /// </summary>
    public class MatchReference
    {
        /// <summary>
        /// Gets or sets the ID for the champion played.
        /// </summary>
        public int Champion { get; set; }

        /// <summary>
        /// Gets or sets the participant's lane for the match.
        /// </summary>
        public PlayerPosition Lane { get; set; }

        /// <summary>
        /// Gets or sets the match ID (also referred to as Game ID).
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long GameId { get; set; }

        /// <summary>
        /// Gets or sets the platform ID that the match was played on.
        /// </summary>
        public PlatformId PlatformId { get; set; }

        /// <summary>
        /// Gets or sets the queue type for the match.
        /// </summary>
        [JsonConverter(typeof(TolerantIntEnumConverter))]
        public QueueType Queue { get; set; }

        /// <summary>
        /// Gets or sets the participant's role.
        /// </summary>
        public MatchRole Role { get; set; }

        /// <summary>
        /// Gets or sets the season the match was played in.
        /// </summary>
        [JsonConverter(typeof(TolerantIntEnumConverter))]
        public Season Season { get; set; }

        /// <summary>
        /// Gets or sets the time the match was played, in UTC.
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}
