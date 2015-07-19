using System;
using System.Collections.Generic;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains information about a participant in a game that is in progress (or was in progress at the time the data was retrieved).
    /// </summary>
    public class Participant
    {
        /// <summary>
        ///  Gets or sets the flag indicating whether or not this participant is a bot.
        /// </summary>
        public bool Bot { get; set; }

        /// <summary>
        ///  Gets or sets the ID of the champion played by this participant.
        /// </summary>
        public long ChampionId { get; set; }

        /// <summary>
        ///  Gets or sets the list of masteries used by this participant. This property is not specified for featured games.
        /// </summary>
        public virtual List<Mastery> Masteries { get; set; }

        /// <summary>
        ///  Gets or sets the ID of the profile icon used by this participant.
        /// </summary>
        public long ProfileIconId { get; set; }

        /// <summary>
        ///  Gets or sets the list of runes used by this participant. This property is not specified for featured games.
        /// </summary>
        public virtual List<Rune> Runes { get; set; }

        /// <summary>
        ///  Gets or sets the ID of the first summoner spell used by this participant.
        /// </summary>
        public long Spell1Id { get; set; }

        /// <summary>
        ///  Gets or sets the ID of the second summoner spell used by this participant.
        /// </summary>
        public long Spell2Id { get; set; }

        /// <summary>
        ///  Gets or sets the summoner ID of this participant.
        /// </summary>
        public long SummonerId { get; set; }

        /// <summary>
        ///  Gets or sets the summoner name of this participant.
        /// </summary>
        public string SummonerName { get; set; }

        /// <summary>
        ///  Gets or sets the team ID of this participant.
        /// </summary>
        public TeamSide TeamId { get; set; }
    }
}