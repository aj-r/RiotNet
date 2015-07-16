using System;
using System.Collections.Generic;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains item list data.
    /// </summary>
    public class ItemList
    {
        /// <summary>
        /// Gets or sets the basic item data.
        /// </summary>
        public BasicData Basic { get; set; }

        /// <summary>
        /// Gets or sets the set of items indexed by name.
        /// </summary>
        public Dictionary<string, Item> Data { get; set; }

        /// <summary>
        /// Gets or sets the list of groups.
        /// </summary>
        public List<Group> Groups { get; set; }

        /// <summary>
        /// Gets or sets the item tree data.
        /// </summary>
        public List<ItemTree> Tree { get; set; }

        /// <summary>
        /// Gets or sets the item type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the game version to which the item list applies.
        /// </summary>
        public string Version { get; set; }
    }
}
