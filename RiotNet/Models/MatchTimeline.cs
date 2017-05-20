using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using RiotNet.Converters;

namespace RiotNet.Models
{
    /// <summary>
    /// This object contains game timeline information.
    /// </summary>
    public class MatchTimeline
    {
        /// <summary>
        /// Gets or sets time between each returned frame.
        /// </summary>
        [JsonConverter(typeof(MillisecondsToTimeSpanConverter))]
        public TimeSpan FrameInterval { get; set; }

        /// <summary>
        /// Gets or sets list of timeline frames for the game.
        /// </summary>
        public virtual List<MatchFrame> Frames { get; set; }

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the <see cref="MatchTimeline"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long DatabaseId { get; set; }
#endif
    }
}
