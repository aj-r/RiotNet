using System.Collections.Generic;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains item tree data.
    /// </summary>
    public class ItemTree
    {
        /// <summary>
        /// Gets or sets the item tree header.
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Gets or sets the item tree tags.
        /// </summary>
        public List<string> Tags { get; set; }
    }
}
