using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains detailed match information.
    /// </summary>
    public class MatchDetail
    {
        /// <summary>
        /// Gets or sets match map ID.
        /// </summary>
        public int MapId { get; set; }

        /// <summary>
        /// Gets or sets match creation time. Designates when the team select lobby is created and/or the match is made through match making, not when the game actually starts.
        /// </summary>
        public DateTime MatchCreation { get; set; }

        /// <summary>
        /// Gets or sets match duration.
        /// </summary>
        public long MatchDuration { get; set; }

        /// <summary>
        /// Gets or sets ID of the match.
        /// </summary>
        [Key]
        public long MatchId { get; set; }

        /// <summary>
        /// Gets or sets match mode.
        /// </summary>
        public GameMode MatchMode { get; set; }

        /// <summary>
        /// Gets or sets match type.
        /// </summary>
        public GameType MatchType { get; set; }

        /// <summary>
        /// Gets or sets match version (patch number).
        /// </summary>
        public string MatchVersion { get; set; }

        /// <summary>
        /// Gets or sets list of participants' identity information.
        /// </summary>
        public List<MatchParticipantIdentity> ParticipantIdentities { get; set; }

        /// <summary>
        /// Gets or sets list of participants' information.
        /// </summary>
        public List<MatchParticipant> Participants { get; set; }

        /// <summary>
        /// Gets or sets platform ID of the match.
        /// </summary>
        public string PlatformId { get; set; }

        /// <summary>
        /// Gets or sets match queue type.
        /// </summary>
        public QueueType QueueType { get; set; }

        /// <summary>
        /// Gets or sets region where the match was played.
        /// </summary>
        public Region Region { get; set; }

        /// <summary>
        /// Gets or sets season match was played.
        /// </summary>
        public Season Season { get; set; }

        /// <summary>
        /// Gets or sets team information.
        /// </summary>
        public List<MatchTeam> Teams { get; set; }

        /// <summary>
        /// Gets or sets match timeline data (not included by default)
        /// </summary>
        public Timeline Timeline { get; set; }
    }
}
