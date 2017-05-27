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
        /// Gets or sets participant ID (normally 1-10; this value appears to always be 0 when coming from the Match History API).
        /// </summary>
        public int ParticipantId { get; set; }

        /// <summary>
        /// Gets or sets player information.
        /// </summary>
        public MatchPlayer Player { get; set; } = new MatchPlayer();

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
