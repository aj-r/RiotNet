using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// Base information for games (used in <see cref="FeaturedGameInfo"/> and <see cref="CurrentGameInfo"/>).
    /// </summary>
    public class GameInfoBase
    {
        /// <summary>
        /// Gets or sets the list of banned champion information.
        /// </summary>
        public List<BannedChampion> BannedChampions { get; set; }

        /// <summary>
        /// Gets or sets the game Id.
        /// </summary>
        public long GameId { get; set; }

        /// <summary>
        /// Gets or sets the amount of time in seconds that has passed since the game started.
        /// </summary>
        public TimeSpan GameLength { get; set; }

        /// <summary>
        /// Gets or sets the game mode.
        /// </summary>
        public GameMode GameMode { get; set; }

        /// <summary>
        /// Gets or sets the queue type.
        /// </summary>
        public QueueType GameQueueConfigId { get; set; }

        /// <summary>
        /// Gets or sets the game start time in UTC.
        /// </summary>
        public DateTime GameStartTime { get; set; }

        /// <summary>
        /// Gets of sets the game type.
        /// </summary>
        public GameType GameType { get; set; }

        /// <summary>
        /// Gets or sets the map id.
        /// </summary>
        public long MapId { get; set; }

        /// <summary>
        /// Gets or sets the observer information.
        /// </summary>
        public Observer Observers { get; set; }

        /// <summary>
        /// Gets or sets the participant information.
        /// </summary>
        public List<Participant> Participants { get; set; }

        /// <summary>
        /// Gets or sets the ID of the platform on which the game is being played.
        /// </summary>
        public string PlatformId { get; set; }
    }
}
