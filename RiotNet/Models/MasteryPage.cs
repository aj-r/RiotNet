using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains information about a single mastery page.
    /// </summary>
    public class MasteryPage
    {
        /// <summary>
        /// Gets or sets if this mastery page is the summoner's currently selected mastery page.
        /// </summary>
        public bool Current { get; set; }

        /// <summary>
        /// Gets or sets the ID of this mastery page.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the collection of masteries in this mastery page.
        /// </summary>
        public virtual List<Mastery> Masteries { get; set; }

        /// <summary>
        /// Gets or sets the name of this mastery page.
        /// </summary>
        public String Name { get; set; }
    }
}
