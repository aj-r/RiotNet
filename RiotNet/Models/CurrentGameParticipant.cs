using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains information about a participant in a game (a summoner).
    /// </summary>
    public class CurrentGameParticipant
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
        ///  Gets or sets the list of masteries used by this participant.
        /// </summary>
        public List<StaticMastery> Masteries { get; set; }

        /// <summary>
        ///  Gets or sets the ID of the profile icon used by this participant.
        /// </summary>
        public long ProfileIconId { get; set; }

        /// <summary>
        ///  Gets or sets the list of runes used by this participant.
        /// </summary>
        public List<StaticRune> Runes { get; set; }

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
        public long TeamId { get; set; }
    }
}