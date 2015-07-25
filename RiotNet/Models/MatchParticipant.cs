using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// This object contains match participant information.
    /// </summary>
    public class MatchParticipant
    {
        /// <summary>
        /// Creates a new <see cref="MatchParticipant"/> instance.
        /// </summary>
        public MatchParticipant()
        {
            Stats = new MatchParticipantStats();
            Timeline = new MatchParticipantTimeline();
        }

        /// <summary>
        /// Gets or sets champion ID.
        /// </summary>
        public int ChampionId { get; set; }

        /// <summary>
        /// Gets or sets highest ranked tier achieved for the previous season, if any; otherwise null. Used to display border in game loading screen.
        /// </summary>
        public Tier? HighestAchievedSeasonTier { get; set; }

        /// <summary>
        /// Gets or sets list of mastery information.
        /// </summary>
        public virtual List<Mastery> Masteries { get; set; }

        /// <summary>
        /// Gets or sets the match participant ID (normally 1-10; this value appears to always be 0 when coming from the Match History API).
        /// </summary>
        public int ParticipantId { get; set; }

        /// <summary>
        /// Gets or sets the list of rune information.
        /// </summary>
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
        public MatchParticipantStats Stats { get; set; }

        /// <summary>
        /// Gets or sets the team ID.
        /// </summary>
        public TeamSide TeamId { get; set; }

        /// <summary>
        /// Gets or sets timeline data. Delta fields refer to values for the specified period.
        /// </summary>
        /// <remarks>
        /// Delta fields refer to values for the specified period
        /// (e.g. the gold per minute over the first 10 minutes of the game versus the second 20 minutes of the game).
        /// Diffs fields refer to the deltas versus the calculated lane opponent(s).
        /// </remarks>
        public MatchParticipantTimeline Timeline { get; set; }

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
