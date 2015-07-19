using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        /// Gets or sets highest ranked tier achieved for the previous season, if any, otherwise null. Used to display border in game loading screen.
        /// </summary>
        public Tier HighestAchievedSeasonTier { get; set; }

        /// <summary>
        /// Gets or sets list of mastery information.
        /// </summary>
        public List<Mastery> Masteries { get; set; }

        /// <summary>
        /// Gets or sets match participant ID (1-10).
        /// </summary>
        public int ParticipantId { get; set; }

        /// <summary>
        /// Gets or sets list of rune information
        /// </summary>
        public List<Rune> Runes { get; set; }

        /// <summary>
        /// Gets or sets first summoner spell ID.
        /// </summary>
        public int Spell1Id { get; set; }

        /// <summary>
        /// Gets or sets second summoner spell ID.
        /// </summary>
        public int Spell2Id { get; set; }

        /// <summary>
        /// Gets or sets participant statistics
        /// </summary>
        public MatchParticipantStats Stats { get; set; }

        /// <summary>
        /// Gets or sets team ID
        /// </summary>
        public int TeamId { get; set; }

        /// <summary>
        /// Gets or sets timeline data. Delta fields refer to values for the specified period (e.g., the gold per minute over
        /// </summary>
        public MatchParticipantTimeline Timeline { get; set; }
    }
}
