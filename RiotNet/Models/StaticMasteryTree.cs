using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents a mastery tree.
    /// </summary>
    public class StaticMasteryTree
    {
        /// <summary>
        /// Gets or sets the defense mastery tree.
        /// </summary>
        public List<StaticMasteryTreeList> Defense { get; set; }

        /// <summary>
        /// Gets or sets the offense mastery tree.
        /// </summary>
        public List<StaticMasteryTreeList> Offense { get; set; }

        /// <summary>
        /// Gets or sets the utility mastery tree.
        /// </summary>
        public List<StaticMasteryTreeList> Utility { get; set; }
    }
}
