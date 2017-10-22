using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents a ranked league.
    /// </summary>
    public class LeagueList
    {
        /// <summary>
        /// Gets or sets the UIID of the league.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string LeagueId { get; set; }

        /// <summary>
        /// Gets or sets the entries for all participants in the league.
        /// </summary>
        public virtual List<LeagueItem> Entries { get; set; }

        /// <summary>
        /// Gets or sets the name of the league.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the league's ranked queue type. This should equal one of the <see cref="RankedQueue"/> values.
        /// </summary>
        public string Queue { get; set; }

        /// <summary>
        /// Gets or sets the league's tier. This should equal one of the <see cref="Models.Tier"/> values.
        /// </summary>
        public string Tier { get; set; }
    }
}
