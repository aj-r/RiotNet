using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains information about a single rune page.
    /// </summary>
    public class RunePage
    {
        /// <summary>
        /// Gets or sets if this rune page is the summoner's currently selected rune page.
        /// </summary>
        public bool Current { get; set; }

        /// <summary>
        /// Gets or sets the ID of this rune page.
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the name of this rune page.
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Gets or sets the collection of rune slots (and their runes) in this rune page.
        /// </summary>
        public virtual List<RuneSlot> Slots { get; set; }
    }
}
