using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// This object contains participant frame information.
    /// </summary>
    public class MatchParticipantFrame
    {
        /// <summary>
        /// Gets or sets participant's current gold.
        /// </summary>
        public int CurrentGold { get; set; }

        /// <summary>
        /// Gets or sets dominion score of the participant.
        /// </summary>
        public int DominionScore { get; set; }

        /// <summary>
        /// Gets or sets number of jungle minions killed by participant.
        /// </summary>
        public int JungleMinionsKilled { get; set; }

        /// <summary>
        /// Gets or sets participant's current level.
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Gets or sets number of minions killed by participant.
        /// </summary>
        public int MinionsKilled { get; set; }

        /// <summary>
        /// Gets or sets participant ID.
        /// </summary>
        public int ParticipantId { get; set; }

        /// <summary>
        /// Gets or sets participant's position.
        /// </summary>
        public Position Position { get; set; } = new Position();

        /// <summary>
        /// Gets or sets team score of the participant.
        /// </summary>
        public int TeamScore { get; set; }

        /// <summary>
        /// Gets or sets participant's total gold.
        /// </summary>
        public int TotalGold { get; set; }

        /// <summary>
        /// Gets or sets experience earned by participant.
        /// </summary>
        public int Xp { get; set; }

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the <see cref="MatchParticipantFrame"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long DatabaseId { get; set; }
#endif
    }
}
