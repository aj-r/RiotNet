using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RiotNet.Models
{
    class BannedChampion
    {
        /// <summary>
        /// Gets or sets the banned champion id (see StaticChampion Id).
        /// </summary>
        public long ChampionId { get; set; }

        /// <summary>
        /// Gets or sets the turn during which the champion was banned.
        /// </summary>
        public int PickTurn { get; set; }

        /// <summary>
        /// Gets or sets the ID of the team that banned the champion.
        /// </summary>
        public long TeamId { get; set; }
    }
}
