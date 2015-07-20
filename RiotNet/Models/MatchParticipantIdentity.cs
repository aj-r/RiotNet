using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains participant identity information.
    /// </summary>
    public class MatchParticipantIdentity
    {
        /// <summary>
        /// Creates a new <see cref="MatchParticipantIdentity"/> instance.
        /// </summary>
        public MatchParticipantIdentity()
        {
            Player = new MatchPlayer();
        }

        /// <summary>
        /// Gets or sets participant ID (1-10).
        /// </summary>
        public int ParticipantId { get; set; }

        /// <summary>
        /// Gets or sets player information.
        /// </summary>
        public MatchPlayer Player { get; set; }

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the <see cref="MatchParticipantIdentity"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long DatabaseId { get; set; }
#endif
    }
}
