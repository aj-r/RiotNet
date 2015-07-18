using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains game information (unlike *GameInfo, this is from the perspective of one of the participants).
    /// </summary>
    public class Game
    {
        /// <summary>
        ///  Gets or sets champion ID associated with game.
        /// </summary>
        public int ChampionId { get; set; }

        /// <summary>
        ///  Gets or sets date that end game data was recorded, specified as epoch milliseconds.
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        ///  Gets or sets other players associated with the game.
        /// </summary>
        public List<Player> FellowPlayers { get; set; }

        /// <summary>
        ///  Gets or sets game ID.
        /// </summary>
        [Key]
        public long GameId { get; set; }

        /// <summary>
        ///  Gets or sets game mode.
        /// </summary>
        public GameMode GameMode { get; set; }

        /// <summary>
        ///  Gets or sets game type.
        /// </summary>
        public GameType GameType { get; set; }

        /// <summary>
        ///  Gets or sets invalid flag.
        /// </summary>
        public bool Invalid { get; set; }

        /// <summary>
        ///  Gets or sets IP Earned.
        /// </summary>
        public int IpEarned { get; set; }

        /// <summary>
        ///  Gets or sets level (presumably of the player's champion at end of game).
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        ///  Gets or sets map ID.
        /// </summary>
        public int MapId { get; set; }

        /// <summary>
        ///  Gets or sets ID of first summoner spell.
        /// </summary>
        public int Spell1 { get; set; }

        /// <summary>
        ///  Gets or sets ID of second summoner spell.
        /// </summary>
        public int Spell2 { get; set; }

        /// <summary>
        ///  Gets or sets statistics associated with the game for this summoner.
        /// </summary>
        public RawStats Stats { get; set; }

        /// <summary>
        ///  Gets or sets game sub-type.
        /// </summary>
        public GameSubType SubType { get; set; }

        /// <summary>
        ///  Gets or sets team ID associated with game. Team ID 100 is blue team. Team ID 200 is purple team.
        /// </summary>
        public int TeamId { get; set; }
    }
}