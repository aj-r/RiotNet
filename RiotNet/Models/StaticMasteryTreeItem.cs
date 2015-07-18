using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents a mastery
    /// </summary>
    public class StaticMasteryTreeItem
    {
        /// <summary>
        /// Gets or sets the mastery ID.
        /// </summary>
        [Key]
        public int MasteryId { get; set; }

        /// <summary>
        /// Gets or sets the mastery ID that must be filled before any points can be added to the current mastery.
        /// </summary>
        public int Prereq { get; set; }
    }
}
