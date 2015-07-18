﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

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
        public ListOfString Tags { get; set; }

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the current <see cref="ItemTree"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int Id { get; set; }
#endif
    }
}
