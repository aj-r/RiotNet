using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains detailed match information.
    /// </summary>
    public class MatchDetail
    {
        /// <summary>
        /// Gets or sets the map ID of the map where the match was played.
        /// </summary>
        public int MapId { get; set; }

        /// <summary>
        /// Gets or sets the match creation time in UTC. Designates when the team select lobby is created and/or the match is made through match making; not when the game actually starts.
        /// </summary>
        public DateTime MatchCreation { get; set; }

        /// <summary>
        /// Gets or sets the match duration.
        /// </summary>
        /// <remarks>
        /// The match duration is serialized as an integer representing the duration of the match in seconds.
        /// </remarks>
        public TimeSpan MatchDuration { get; set; }

        /// <summary>
        /// Gets or sets the ID of the match (also referred to as Game ID).
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long MatchId { get; set; }

        /// <summary>
        /// Gets or sets the match mode.
        /// </summary>
        public GameMode MatchMode { get; set; }

        /// <summary>
        /// Gets or sets the match type.
        /// </summary>
        public GameType MatchType { get; set; }

        /// <summary>
        /// Gets or sets the match version (patch number).
        /// </summary>
        public string MatchVersion { get; set; }

        /// <summary>
        /// Gets or sets the list of participants' identity information.
        /// </summary>
        public virtual List<MatchParticipantIdentity> ParticipantIdentities { get; set; }

        /// <summary>
        /// Gets or sets the list of participants' information.
        /// </summary>
        public virtual List<MatchParticipant> Participants { get; set; }

        /// <summary>
        /// Gets or sets the platform ID of the match.
        /// </summary>
        public string PlatformId { get; set; }

        /// <summary>
        /// Gets or sets the match queue type.
        /// </summary>
        public QueueType QueueType { get; set; }

        /// <summary>
        /// Gets or sets the region where the match was played.
        /// </summary>
        public Region Region { get; set; }

        /// <summary>
        /// Gets or sets season when the match was played.
        /// </summary>
        public Season Season { get; set; }

        /// <summary>
        /// Gets or sets team information.
        /// </summary>
        public virtual List<MatchTeam> Teams { get; set; }

        /// <summary>
        /// Gets or sets match timeline data (not included by default)
        /// </summary>
        public virtual Timeline Timeline { get; set; }
    }
}
