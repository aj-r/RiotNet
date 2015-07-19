using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotNet.Models
{
    /// <summary>
    /// This object contains ranked stats information.
    /// </summary>
    public class RankedStats
    {
        /// <summary>
        /// Gets or sets collection of aggregated stats summarized by champion.
        /// </summary>
        public List<ChampionStats> Champions { get; set; }

        /// <summary>
        /// Gets or sets date stats were last modified specified as epoch milliseconds.
        /// </summary>
        public DateTime ModifyDate { get; set; }

        /// <summary>
        /// Gets or sets summoner ID.
        /// </summary>
        public long SummonerId { get; set; }
    }
}
