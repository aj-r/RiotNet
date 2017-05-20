using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains champion mastery data.
    /// </summary>
    public class ChampionMastery
    {
        /// <summary>
        /// Gets or sets the ID of the champion to which this data applies.
        /// </summary>
        public long ChampionId { get; set; }

        /// <summary>
        /// Gets or sets the champion mastery level for the champion.
        /// </summary>
        public int ChampionLevel { get; set; }

        /// <summary>
        /// Gets or sets the number of champion points that the player has accumulated for the current champion.
        /// </summary>
        public int ChampionPoints { get; set; }

        /// <summary>
        /// Gets or sets the number of champion points that the player has accumulated for the current champion since reaching the last champion level.
        /// Zero if the player reached maximum champion level for this champion.
        /// </summary>
        /// <remarks>
        /// Don't ask me why this is stored as a long but ChampionPoints is stored as an int. Ask Rito.
        /// </remarks>
        public long ChampionPointsSinceLastLevel { get; set; }

        /// <summary>
        /// Gets or sets the number of champion points until the player reaches the next champion level for this champion.
        /// Zero if the player reached maximum champion level for this champion.
        /// </summary>
        public long ChampionPointsUntilNextLevel { get; set; }

        /// <summary>
        /// Gets or sets whether a chest has been granted for this champion in the current season.
        /// </summary>
        public bool ChestGranted { get; set; }

        /// <summary>
        /// Gets or sets the time when the player last played this champion.
        /// </summary>
        public DateTime LastPlayTime { get; set; }

        /// <summary>
        /// Gets or sets the summoner ID of the player to which this data applies.
        /// </summary>
        public long PlayerId { get; set; }

        /// <summary>
        /// Gets or sets the number of mastery level 6 or 7 tokens earned.
        /// </summary>
        public int TokensEarned { get; set; }

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the current <see cref="ChampionMastery"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long DatabaseId { get; set; }
#endif
    }
}
