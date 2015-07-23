using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains information about a historical game, as well as stats associated with the player for which this game was requested.
    /// </summary>
    /// <remarks>
    /// This object comes from the Games API, which gets the 10 most recent games played by a player.
    /// For more detailed game information, use the <see cref="MatchDetail"/> object from the Match API instead.
    /// </remarks>
    public class Game
    {
        /// <summary>
        /// Creates a new <see cref="Game"/> instance.
        /// </summary>
        public Game()
        {
            Stats = new RawStats();
        }

        /// <summary>
        ///  Gets or sets the player's champion ID. This corresponds to a <see cref="StaticChampion"/> ID.
        /// </summary>
        public int ChampionId { get; set; }

        /// <summary>
        ///  Gets or sets the date and time (in UTC) that end game data was recorded.
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        ///  Gets or sets the other players in the game.
        /// </summary>
        public virtual List<Player> FellowPlayers { get; set; }

        /// <summary>
        ///  Gets or sets the game ID.
        /// </summary>
        [Key]
        public long GameId { get; set; }

        /// <summary>
        ///  Gets or sets the game mode.
        /// </summary>
        public GameMode GameMode { get; set; }

        /// <summary>
        ///  Gets or sets the game type.
        /// </summary>
        public GameType GameType { get; set; }

        /// <summary>
        ///  Gets or sets whether the game resulted in a loss prevented for either team.
        /// </summary>
        public bool Invalid { get; set; }

        /// <summary>
        ///  Gets or sets the amount IP earned by the summoner.
        /// </summary>
        public int IpEarned { get; set; }

        /// <summary>
        ///  Gets or sets the level of the player's champion at the end of the game.
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        ///  Gets or sets the map ID.
        /// </summary>
        public int MapId { get; set; }

        /// <summary>
        ///  Gets or sets the ID of first summoner spell. This corresponds to a <see cref="StaticSummonerSpell"/> ID.
        /// </summary>
        public int Spell1 { get; set; }

        /// <summary>
        ///  Gets or sets the ID of second summoner spell. This corresponds to a <see cref="StaticSummonerSpell"/> ID.
        /// </summary>
        public int Spell2 { get; set; }

        /// <summary>
        ///  Gets or sets the statistics associated with the game for this summoner.
        /// </summary>
        public RawStats Stats { get; set; }

        /// <summary>
        ///  Gets or sets the game sub-type.
        /// </summary>
        public GameSubType SubType { get; set; }

        /// <summary>
        ///  Gets or sets the team ID of the team that the player was on.
        /// </summary>
        public TeamSide TeamId { get; set; }
    }
}