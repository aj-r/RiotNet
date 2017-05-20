using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains information about a single mastery in a mastery page.
    /// </summary>
    public class Mastery
    {
        private int id;

        /// <summary>
        /// Gets or sets the ID of this mastery. This corresponds to a <see cref="StaticMastery"/> ID. This is equal to <see cref="MasteryId"/>, but it is set by the Summoner API.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Gets or sets the ID of this mastery. This corresponds to a <see cref="StaticMastery"/> ID. This is equal to <see cref="Id"/>, but it is set by the Match and Spectator APIs.
        /// </summary>
        public int MasteryId
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Gets or sets the number of mastery points put into this mastery.
        /// </summary>
        public int Rank { get; set; }

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the <see cref="Mastery"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long DatabaseId { get; set; }
#endif
    }
}
