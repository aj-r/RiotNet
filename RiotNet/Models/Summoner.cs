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
    /// Contains summoner information.
    /// </summary>
    public class Summoner
    {
        /// <summary>
        /// Gets or sets the summoner ID.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the summoner's name.
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Gets or sets the ID of the summoner's profile icon.
        /// </summary>
        public int ProfileIconId { get; set; }

        /// <summary>
        /// Gets or sets the date and time (int UTC) when the summoner was last modified.
        /// The summoner is modified by the following events: changing summoner icon,
        /// playing a tutorial, finishing a game, or changing summoner name.
        /// </summary>
        public DateTime RevisionDate { get; set; }

        /// <summary>
        /// Gets or sets the summoner's level.
        /// </summary>
        public long SummonerLevel { get; set; }
    }
}
