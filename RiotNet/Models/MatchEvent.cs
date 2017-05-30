using Newtonsoft.Json;
using RiotNet.Converters;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// This object contains game event information. Note that not all legal type values documented below are valid for all games. Event data evolves over time and certain values may be relevant only for older or newer games.
    /// </summary>
    public class MatchEvent
    {
        /// <summary>
        /// Gets or sets the ending item ID of the event. Used for undo events - if this is 0, the item was un-bought.
        /// </summary>
        public int? AfterId { get; set; }

        /// <summary>
        /// Gets or sets the ascended type of the event. Only present if relevant.
        /// </summary>
        public string AscendedType { get; set; }

        /// <summary>
        /// Gets or sets the assisting participant IDs of the event. Only present if relevant.
        /// </summary>
        public ListOfInt AssistingParticipantIds { get; set; } = new ListOfInt();

        /// <summary>
        /// Gets or sets the starting item ID of the event. Used for undo events - if this is 0, the item was un-sold.
        /// </summary>
        public int? BeforeId { get; set; }

        /// <summary>
        /// Gets or sets the building type of the event. Only present if relevant. This should equal one of the <see cref="Models.BuildingType"/> values.
        /// </summary>
        public string BuildingType { get; set; }

        /// <summary>
        /// Gets or sets the participant ID of the participant who created the object. Only present if relevant.
        /// </summary>
        public int? CreatorId { get; set; }

        /// <summary>
        /// Gets or sets event type.
        /// </summary>
        [Obsolete("It appears that this property is no longer used by the Riot API. Use Type instead.")]
        public string EventType { get; set; }

        /// <summary>
        /// Gets or sets the item ID of the event. Only present if relevant.
        /// </summary>
        public int? ItemId { get; set; }

        /// <summary>
        /// Gets or sets the participant ID of the killer. Only present if relevant. Killer ID 0 indicates a minion.
        /// </summary>
        public int? KillerId { get; set; }

        /// <summary>
        /// Gets or sets the lane type of the event. Only present if relevant. This should equal one of the <see cref="Models.LaneType"/> values.
        /// </summary>
        public string LaneType { get; set; }

        /// <summary>
        /// Gets or sets the level up type of the event. Only present if relevant. This should equal one of the <see cref="Models.LevelUpType"/> values.
        /// </summary>
        public string LevelUpType { get; set; }

        /// <summary>
        /// Gets or sets the monster type of the event. Only present if relevant. This should equal one of the <see cref="Models.MonsterType"/> values.
        /// </summary>
        public string MonsterType { get; set; }

        /// <summary>
        /// Gets or sets the monster sub-type of the event. Only present if relevant (i.e. for dragon kills). This should equal one of the <see cref="Models.MonsterSubType"/> values.
        /// </summary>
        public string MonsterSubType { get; set; }

        /// <summary>
        /// Gets or sets the participant ID (1-10) of the event. Only present if relevant.
        /// </summary>
        public int? ParticipantId { get; set; }

        /// <summary>
        /// Gets or sets the point captured in the event. Only present if relevant. This should equal one of the <see cref="Models.Point"/> values.
        /// </summary>
        public string PointCaptured { get; set; }

        /// <summary>
        /// Gets or sets the position of the event. Only present if relevant.
        /// </summary>
        public Position Position { get; set; } = new Position();

        /// <summary>
        /// Gets or sets the skill slot of the event. Only present if relevant.
        /// </summary>
        public int? SkillSlot { get; set; }

        /// <summary>
        /// Gets or sets the team ID of the event. Only present if relevant.
        /// </summary>
        public TeamSide? TeamId { get; set; }

        /// <summary>
        /// Gets or sets the game time at which the event occurred.
        /// </summary>
        [JsonConverter(typeof(MillisecondsToTimeSpanConverter))]
        public TimeSpan Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the tower type of the event. Only present if relevant. This should equal one of the <see cref="Models.TowerType"/> values.
        /// </summary>
        public string TowerType { get; set; }

        /// <summary>
        /// Gets or sets event type. This should equal one of the <see cref="Models.EventType"/> values.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the participant ID of the victiom of the event. Only present if relevant.
        /// </summary>
        public int? VictimId { get; set; }

        /// <summary>
        /// Gets or sets the ward type of the event. Only present if relevant. This should equal one of the <see cref="Models.WardType"/> values.
        /// </summary>
        public string WardType { get; set; }

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the <see cref="MatchEvent"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long DatabaseId { get; set; }
#endif
    }
}
