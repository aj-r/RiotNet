using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains information about a single summoner's mastery pages.
    /// </summary>
    public class MasteryPages
    {
        /// <summary>
        /// Gets or sets the collection of mastery pages of this summoner.
        /// </summary>
        public List<MasteryPage> Pages { get; set; }

        /// <summary>
        /// Gets or sets the summoner ID of this summoner.
        /// </summary>
        public long SummonerId { get; set; }
    }
}
