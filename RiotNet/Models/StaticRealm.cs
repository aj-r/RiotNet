using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains realm data. This is mainly version numbers related to Dragon Magic.
    /// </summary>
    public class StaticRealm
    {
        /// <summary>
        /// Gets or sets the base CDN URL.
        /// </summary>
        public string Cdn { get; set; }

        /// <summary>
        /// Gets or sets the latest changed version of Dragon Magic's css file.
        /// </summary>
        public string Css { get; set; }

        /// <summary>
        /// Gets or sets the latest changed version of Dragon Magic.
        /// </summary>
        public string Dd { get; set; }

        /// <summary>
        /// Gets or sets the default language for this realm.
        /// </summary>
        public string L { get; set; }

        /// <summary>
        /// Gets or sets the legacy script mode for IE6 or older.
        /// </summary>
        public string Lg { get; set; }

        /// <summary>
        /// Gets or sets the latest changed version for each data type listed.
        /// </summary>
        public DictionaryOfString N { get; set; } = new DictionaryOfString();

        /// <summary>
        /// Gets or sets the special behavior number identifying the largest profile icon id that can be used under 500. Any profileicon that is requested between this number and 500 should be mapped to 0.
        /// </summary>
        [JsonProperty("profileiconmax")]
        public int ProfileIconMax { get; set; }

        /// <summary>
        /// Gets or sets additional API data drawn from other sources that may be related to data dragon functionality.
        /// </summary>
        public string Store { get; set; }

        /// <summary>
        /// Gets or sets the current version of this realm.
        /// </summary>
        public string V { get; set; }

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the <see cref="StaticRealm"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long DatabaseId { get; set; }
#endif
    }
}
