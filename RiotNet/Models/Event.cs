using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RiotNet.Models
{
    /// <summary>
    /// This object contains game event information. Note that not all legal type values documented below are valid for all games. Event data evolves over time and certain values may be relevant only for older or newer games.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Gets or sets the ascended type of the event. Only present if relevant. Note that CLEAR_ASCENDED refers to when a participants kills the ascended player. (Legal values: CHAMPION_ASCENDED, CLEAR_ASCENDED, MINION_ASCENDED).
        /// </summary>
        public AscendedType AscendedType { get; set; }

        /// <summary>
        /// Gets or sets the assisting participant IDs of the event. Only present if relevant.
        /// </summary>
        public List<int> AssistingParticipantIds { get; set; }

        /// <summary>
        /// Gets or sets the building type of the event. Only present if relevant. (Legal values: INHIBITOR_BUILDING, TOWER_BUILDING).
        /// </summary>
        public BuildingType BuildingType { get; set; }

        /// <summary>
        /// Gets or sets the creator ID of the event. Only present if relevant.
        /// </summary>
        public int CreatorId { get; set; }

        /// <summary>
        /// Gets or sets event type. (Legal values: ASCENDED_EVENT, BUILDING_KILL, CAPTURE_POINT, CHAMPION_KILL, ELITE_MONSTER_KILL, ITEM_DESTROYED, ITEM_PURCHASED, ITEM_SOLD, ITEM_UNDO, PORO_KING_SUMMON, SKILL_LEVEL_UP, WARD_KILL, WARD_PLACED).
        /// </summary>
        public EventType EventType { get; set; }

        /// <summary>
        /// Gets or sets the ending item ID of the event. Only present if relevant.
        /// </summary>
        public int ItemAfter { get; set; }

        /// <summary>
        /// Gets or sets the starting item ID of the event. Only present if relevant.
        /// </summary>
        public int ItemBefore { get; set; }

        /// <summary>
        /// Gets or sets the item ID of the event. Only present if relevant.
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// Gets or sets the killer ID of the event. Only present if relevant. Killer ID 0 indicates a minion.
        /// </summary>
        public int KillerId { get; set; }

        /// <summary>
        /// Gets or sets the lane type of the event. Only present if relevant. (Legal values: BOT_LANE, MID_LANE, TOP_LANE).
        /// </summary>
        public LaneType LaneType { get; set; }

        /// <summary>
        /// Gets or sets the level up type of the event. Only present if relevant. (Legal values: EVOLVE, NORMAL).
        /// </summary>
        public LevelUpType LevelUpType { get; set; }

        /// <summary>
        /// Gets or sets the monster type of the event. Only present if relevant. (Legal values: BARON_NASHOR, BLUE_GOLEM, DRAGON, RED_LIZARD, VILEMAW).
        /// </summary>
        public MonsterType MonsterType { get; set; }

        /// <summary>
        /// Gets or sets the participant ID of the event. Only present if relevant.
        /// </summary>
        public int ParticipantId { get; set; }

        /// <summary>
        /// Gets or sets the point captured in the event. Only present if relevant. (Legal values: POINT_A, POINT_B, POINT_C, POINT_D, POINT_E).
        /// </summary>
        public Point PointCaptured { get; set; }

        /// <summary>
        /// Gets or sets the position of the event. Only present if relevant.
        /// </summary>
        public Position Position { get; set; }

        /// <summary>
        /// Gets or sets the skill slot of the event. Only present if relevant.
        /// </summary>
        public int SkillSlot { get; set; }

        /// <summary>
        /// Gets or sets the team ID of the event. Only present if relevant.
        /// </summary>
        public int TeamId { get; set; }

        /// <summary>
        /// Gets or sets represents how many milliseconds into the game the event occurred.
        /// </summary>
        public long Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the tower type of the event. Only present if relevant. (Legal values: BASE_TURRET, FOUNTAIN_TURRET, INNER_TURRET, NEXUS_TURRET, OUTER_TURRET, UNDEFINED_TURRET).
        /// </summary>
        public TowerType TowerType { get; set; }

        /// <summary>
        /// Gets or sets the victim ID of the event. Only present if relevant.
        /// </summary>
        public int VictimId { get; set; }

        /// <summary>
        /// Gets or sets the ward type of the event. Only present if relevant. (Legal values: SIGHT_WARD, TEEMO_MUSHROOM, UNDEFINED, VISION_WARD, YELLOW_TRINKET, YELLOW_TRINKET_UPGRADE).
        /// </summary>
        public WardType WardType { get; set; }
    }
}
