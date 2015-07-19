using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains information about a single mastery in a mastery page.
    /// </summary>
    public class Mastery
    {
        /// <summary>
        /// Gets or sets the ID of this mastery.
        /// For static information regarding masteries, please refer to the Static Data API.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the number of mastery points put into this mastery.
        /// </summary>
        public int Rank { get; set; }
    }
}
