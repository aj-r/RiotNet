using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains some information on a featured game.
    /// </summary>
    public class FeaturedGameInfo
    {
        /// <summary>
        ///  Gets or sets the list of banned champion information.
        /// </summary>
        public List<BannedChampion> BannedChampions { get; set; }

        /// <summary>
        ///  Gets or sets the id of the game.
        /// </summary>
        public long GameId { get; set; }

        /// <summary>
        ///  Gets or sets the amount of time in seconds that has passed since the game started.
        /// </summary>
        public long GameLength { get; set; }

        /// <summary>
        ///  Gets or sets the game mode.
        /// </summary>
        public GameMode GameMode { get; set; }

        /// <summary>
        ///  Gets or sets the queue type.
        /// </summary>
        public QueueType GameQueueConfigId { get; set; }

        /// <summary>
        ///  Gets or sets the game start time represented in epoch milliseconds.
        /// </summary>
        public DateTime GameStartTime { get; set; }

        /// <summary>
        ///  Gets or sets the game type.
        /// </summary>
        public GameType GameType { get; set; }

        /// <summary>
        ///  Gets or sets the id of the map.
        /// </summary>
        public long MapId { get; set; }

        /// <summary>
        ///  Gets or sets the observer information (for spectator).
        /// </summary>
        public Observer Observers { get; set; }

        /// <summary>
        ///  Gets or sets the game participant information.
        /// </summary>
        public List<Participant> Participants { get; set; }

        /// <summary>
        ///  Gets or sets the id of the platform on which the game is being played.
        /// </summary>
        public string PlatformId { get; set; }
    }
}
