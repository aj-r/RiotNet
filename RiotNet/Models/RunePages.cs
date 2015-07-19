using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains information about a single summoner's rune pages.
    /// </summary>
    public class RunePages
    {
        /// <summary>
        /// Gets or sets the collection of rune pages of this summoner.
        /// </summary>
        public List<RunePage> Pages { get; set; }

        /// <summary>
        /// Gets or sets the summoner ID of this summoner.
        /// </summary>
        public long SummonerId { get; set; }
    }
}
