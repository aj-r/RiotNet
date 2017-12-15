using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// This object contains match participant information.
    /// </summary>
    public class MatchParticipant
    {
        /// <summary>
        /// Gets or sets champion ID.
        /// </summary>
        public int ChampionId { get; set; }

        /// <summary>
        /// Gets or sets highest ranked tier achieved for the previous season, if any; otherwise null. Used to display border in game loading screen. This should equal one of the <see cref="Tier"/> values.
        /// </summary>
        public string HighestAchievedSeasonTier { get; set; }

        /// <summary>
        /// Gets or sets list of mastery information.
        /// </summary>
        [Obsolete("This propery no longer exists. Use perk data (in the Stats object) instead.")]
        public virtual List<Mastery> Masteries { get; set; }

        /// <summary>
        /// Gets or sets the match participant ID (normally 1-10).
        /// </summary>
        public int ParticipantId { get; set; }

        /// <summary>
        /// Gets or sets the list of rune information.
        /// </summary>
        [Obsolete("This propery no longer exists. Use perk data (in the Stats object) instead.")]
        public virtual List<Rune> Runes { get; set; }

        /// <summary>
        /// Gets or sets the first summoner spell ID.
        /// </summary>
        public int Spell1Id { get; set; }

        /// <summary>
        /// Gets or sets the second summoner spell ID.
        /// </summary>
        public int Spell2Id { get; set; }

        /// <summary>
        /// Gets or sets the participant statistics.
        /// </summary>
        public MatchParticipantStats Stats { get; set; } = new MatchParticipantStats();

        /// <summary>
        /// Gets or sets the team ID.
        /// </summary>
        public TeamSide TeamId { get; set; }

        /// <summary>
        /// Gets or sets timeline data. Delta fields refer to values for the specified period. Diff fields refer to the deltas versus the calculated lane opponent(s).
        /// </summary>
        /// <remarks>
        /// Delta fields refer to values for the specified period
        /// (e.g. the gold per minute over the first 10 minutes of the game versus the second 20 minutes of the game).
        /// Diff fields refer to the deltas versus the calculated lane opponent(s).
        /// </remarks>
        public MatchParticipantTimeline Timeline { get; set; } = new MatchParticipantTimeline();

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the current <see cref="MatchParticipant"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long DatabaseId { get; set; }
#endif
    }
}
