using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains participant identity information.
    /// </summary>
    public class MatchParticipantIdentity
    {
        /// <summary>
        /// Gets or sets participant ID (1-10).
        /// </summary>
        public int ParticipantId { get; set; }

        /// <summary>
        /// Gets or sets player information.
        /// </summary>
        public MatchPlayer Player { get; set; }
    }
}
