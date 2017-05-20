using Newtonsoft.Json;
using RiotNet.Converters;
using System;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents the ascension event type. Used in <see cref="MatchEvent"/> for event type <see cref="EventType.ASCENDED_EVENT"/>.
    /// </summary>
    public enum AscendedType
    {
        /// <summary>
        /// Indicates that a player has become ascended.
        /// </summary>
        CHAMPION_ASCENDED,
        /// <summary>
        /// Inticates that a player has killed the ascended player.
        /// </summary>
        CLEAR_ASCENDED,
        /// <summary>
        /// Indicates that a minion has ascended.
        /// </summary>
        MINION_ASCENDED,
    }

    /// <summary>
    /// Represents the building type. Used in <see cref="MatchEvent"/> for event type <see cref="EventType.BUILDING_KILL"/>.
    /// </summary>
    public enum BuildingType
    {
        /// <summary>
        /// Inhibitor building
        /// </summary>
        INHIBITOR_BUILDING,
        /// <summary>
        /// Tower building
        /// </summary>
        TOWER_BUILDING,
    }

    /// <summary>
    /// Represents the event type. Used in <see cref="MatchEvent"/>.
    /// </summary>
    public enum EventType
    {
        /// <summary>
        /// Ascended event
        /// </summary>
        ASCENDED_EVENT,
        /// <summary>
        /// Building kill
        /// </summary>
        BUILDING_KILL,
        /// <summary>
        /// Capture point
        /// </summary>
        CAPTURE_POINT,
        /// <summary>
        /// Champion kill
        /// </summary>
        CHAMPION_KILL,
        /// <summary>
        /// Elite monster kill
        /// </summary>
        ELITE_MONSTER_KILL,
        /// <summary>
        /// Item destroyed. This usually indicates that an item was built into a higher tier item.
        /// </summary>
        ITEM_DESTROYED,
        /// <summary>
        /// Item purchased
        /// </summary>
        ITEM_PURCHASED,
        /// <summary>
        /// Item sold
        /// </summary>
        ITEM_SOLD,
        /// <summary>
        /// Item undo
        /// </summary>
        ITEM_UNDO,
        /// <summary>
        /// Poro king summon
        /// </summary>
        PORO_KING_SUMMON,
        /// <summary>
        /// Skill level up
        /// </summary>
        SKILL_LEVEL_UP,
        /// <summary>
        /// Ward kill
        /// </summary>
        WARD_KILL,
        /// <summary>
        /// Ward placed
        /// </summary>
        WARD_PLACED,
    }

    /// <summary>
    /// Represents the game mode.
    /// </summary>
    public enum GameMode
    {
        /// <summary>
        /// Classic, played on both Summoner's Rift and Twisted Treeline.
        /// </summary>
        CLASSIC,
        /// <summary>
        /// Dominion, played on The Crystal Scar.
        /// </summary>
        ODIN,
        /// <summary>
        /// All Random All Mid, played on both Howling Abyss and Butcher's Bridge.
        /// </summary>
        ARAM,
        /// <summary>
        /// Tutorial.
        /// </summary>
        TUTORIAL,
        /// <summary>
        ///  One for All, played on both Summoner's Rift and Howling Abyss.
        /// </summary>
        ONEFORALL,
        /// <summary>
        /// Ascension, played on The Crystal Scar.
        /// </summary>
        ASCENSION,
        /// <summary>
        /// Snowdown Showdown, played on the Howling Abyss.
        /// </summary>
        FIRSTBLOOD,
        /// <summary>
        /// Legend of the Poro King, played on the Howling Abyss.
        /// </summary>
        KINGPORO,
        /// <summary>
        /// Nexus Siege
        /// </summary>
        SIEGE,
        /// <summary>
        /// Blood Hunt Assassin
        /// </summary>
        ASSASSINATE,
        /// <summary>
        /// All Random Summoner's Rift
        /// </summary>
        ARSR,
        /// <summary>
        /// Darkstar
        /// </summary>
        DARKSTAR,
    }

    /// <summary>
    /// Represents the game sub-type.
    /// </summary>
    public enum GameSubType
    {
        /// <summary>
        /// None
        /// </summary>
        NONE,
        /// <summary>
        /// Normal
        /// </summary>
        NORMAL,
        /// <summary>
        /// Bot
        /// </summary>
        BOT,
        /// <summary>
        /// Ranked solo 5x5
        /// </summary>
        RANKED_SOLO_5x5,
        /// <summary>
        /// Ranked premade 3x3
        /// </summary>
        RANKED_PREMADE_3x3,
        /// <summary>
        /// Ranked premade 5x5
        /// </summary>
        RANKED_PREMADE_5x5,
        /// <summary>
        /// Dominion unranked
        /// </summary>
        ODIN_UNRANKED,
        /// <summary>
        /// Ranked team 3x3
        /// </summary>
        RANKED_TEAM_3x3,
        /// <summary>
        /// Ranked team 5x5
        /// </summary>
        RANKED_TEAM_5x5,
        /// <summary>
        /// Normal 3x3
        /// </summary>
        NORMAL_3x3,
        /// <summary>
        /// Bot 3x3
        /// </summary>
        BOT_3x3,
        /// <summary>
        /// Teambuilder 5x5
        /// </summary>
        CAP_5x5,
        /// <summary>
        /// ARAM unranked 5x5
        /// </summary>
        ARAM_UNRANKED_5x5,
        /// <summary>
        /// One for all 5x5
        /// </summary>
        ONEFORALL_5x5,
        /// <summary>
        /// Snowdown Showdown 1x1
        /// </summary>
        FIRSTBLOOD_1x1,
        /// <summary>
        /// Snowdown Showdown 2x2
        /// </summary>
        FIRSTBLOOD_2x2,
        /// <summary>
        /// Summoner's Rift Hexakill
        /// </summary>
        SR_6x6,
        /// <summary>
        /// URF
        /// </summary>
        URF,
        /// <summary>
        /// URF bot
        /// </summary>
        URF_BOT,
        /// <summary>
        /// Doom bots
        /// </summary>
        NIGHTMARE_BOT,
        /// <summary>
        /// Ascension
        /// </summary>
        ASCENSION,
        /// <summary>
        /// Twisted Treeline Hexakill
        /// </summary>
        HEXAKILL,
        /// <summary>
        /// Legend of the Poro King
        /// </summary>
        KING_PORO,
        /// <summary>
        /// Nemesis draft
        /// </summary>
        COUNTER_PICK,
        /// <summary>
        /// Black Market Brawlers
        /// </summary>
        BILGEWATER,
        /// <summary>
        /// Nexus Siege
        /// </summary>
        SIEGE,
        /// <summary>
        /// Ranked Flex Summoner's Rift
        /// </summary>
        RANKED_FLEX_SR,
        /// <summary>
        /// Ranked Flex Twisted Treeline
        /// </summary>
        RANKED_FLEX_TT,
    }

    /// <summary>
    /// Represents the game type.
    /// </summary>
    public enum GameType
    {
        /// <summary>
        /// Custom game
        /// </summary>
        CUSTOM_GAME,
        /// <summary>
        /// Matched game (any game that is queued up for)
        /// </summary>
        MATCHED_GAME,
        /// <summary>
        /// Tutorial
        /// </summary>
        TUTORIAL_GAME,
    }

    /// <summary>
    /// Represents the lane an event occured.  Used in <see cref="MatchEvent"/>.
    /// </summary>
    public enum LaneType
    {
        /// <summary>
        /// Bot lane
        /// </summary>
        BOT_LANE,
        /// <summary>
        /// Mid lane
        /// </summary>
        MID_LANE,
        /// <summary>
        /// Top lane
        /// </summary>
        TOP_LANE,
    }

    /// <summary>
    /// Represents the level up type. Used in <see cref="MatchEvent"/> for event type <see cref="EventType.SKILL_LEVEL_UP"/>.
    /// </summary>
    public enum LevelUpType
    {
        /// <summary>
        /// Evolve
        /// </summary>
        EVOLVE,
        /// <summary>
        /// Normal
        /// </summary>
        NORMAL,
    }

    /// <summary>
    /// Represents a map type for a tournament game.
    /// </summary>
    public enum MapType
    {
        /// <summary>
        /// Summoner's Rift
        /// </summary>
        SUMMONERS_RIFT,
        /// <summary>
        /// Twisted Treeline
        /// </summary>
        TWISTED_TREELINE,
        /// <summary>
        /// Crystal Scar (dominion)
        /// </summary>
        CRYSTAL_SCAR,
        /// <summary>
        /// Howling Abyss (ARAM)
        /// </summary>
        HOWLING_ABYSS
    }

    /// <summary>
    /// Represents a player's role. Very similar to <see cref="PlayerRole"/> but used in the Match API instead of Game API.
    /// </summary>
    public enum MatchRole
    {
        /// <summary>
        /// Duo
        /// </summary>
        DUO,
        /// <summary>
        /// None
        /// </summary>
        NONE,
        /// <summary>
        /// Solo
        /// </summary>
        SOLO,
        /// <summary>
        /// Duo carry
        /// </summary>
        DUO_CARRY,
        /// <summary>
        /// Duo support
        /// </summary>
        DUO_SUPPORT
    }

    /// <summary>
    /// Represents the type of monster that an event applies to. This is only valid for buff monsters and epic monsters.
    /// </summary>
    public enum MonsterType
    {
        /// <summary>
        /// Baron nashor
        /// </summary>
        BARON_NASHOR,
        /// <summary>
        /// Blue golem
        /// </summary>
        BLUE_GOLEM,
        /// <summary>
        /// Dragon
        /// </summary>
        DRAGON,
        /// <summary>
        /// Red lizard
        /// </summary>
        RED_LIZARD,
        /// <summary>
        /// Rift Herald
        /// </summary>
        RIFTHERALD,
        /// <summary>
        /// Vilemaw
        /// </summary>
        VILEMAW,
    }

    /// <summary>
    /// Indicates a type of mastery tree.
    /// </summary>
    public enum MastertyTreeType
    {
        /// <summary>
        /// Specifies the Ferocity mastery tree.
        /// </summary>
        Ferocity,
        /// <summary>
        /// Specifies the Cunning mastery tree.
        /// </summary>
        Cunning,
        /// <summary>
        /// Specifies the Resolve mastery tree.
        /// </summary>
        Resolve
    }

    /// <summary>
    /// The method used for picking champions.
    /// </summary>
    public enum PickType
    {
        /// <summary>
        /// Blind pick
        /// </summary>
        BLIND_PICK,
        /// <summary>
        /// Draft pick
        /// </summary>
        DRAFT_MODE,
        /// <summary>
        /// All randowm
        /// </summary>
        ALL_RANDOM,
        /// <summary>
        /// Tournament draft pick
        /// </summary>
        TOURNAMENT_DRAFT
    }

    /// <summary>
    /// Represents player's position, or lane.
    /// </summary>
    public enum PlayerPosition
    {
        /// <summary>
        /// Top
        /// </summary>
        TOP = 1,
        /// <summary>
        /// Mid
        /// </summary>
        MIDDLE = 2,
        /// <summary>
        /// Jungle
        /// </summary>
        JUNGLE = 3,
        /// <summary>
        /// Bot
        /// </summary>
        BOT = 4,
    }

    /// <summary>
    /// Represents a player's role. Very similar to <see cref="MatchRole"/> but used in the Game API instead of the Match API.
    /// </summary>
    public enum PlayerRole
    {
        /// <summary>
        /// None of the other roles
        /// </summary>
        NONE = 0,
        /// <summary>
        /// Duo lane
        /// </summary>
        DUO = 1,
        /// <summary>
        /// Support
        /// </summary>
        SUPPORT = 2,
        /// <summary>
        /// Carry
        /// </summary>
        CARRY = 3,
        /// <summary>
        /// Solo lane
        /// </summary>
        SOLO = 4,
    }

    /// <summary>
    /// Represents a capturable point in Dominion. Used in <see cref="MatchEvent"/> for event type <see cref="EventType.CAPTURE_POINT"/>.
    /// </summary>
    public enum Point
    {
        /// <summary>
        /// Point a
        /// </summary>
        POINT_A,
        /// <summary>
        /// Point b
        /// </summary>
        POINT_B,
        /// <summary>
        /// Point c
        /// </summary>
        POINT_C,
        /// <summary>
        /// Point d
        /// </summary>
        POINT_D,
        /// <summary>
        /// Point e
        /// </summary>
        POINT_E,
    }

    /// <summary>
    /// Respresents the queue type.
    /// </summary>
    public enum QueueType
    {
        /// <summary>
        /// Custom
        /// </summary>
        CUSTOM = 0,
        /// <summary>
        /// Normal 5v5 Blind Pick
        /// </summary>
        NORMAL_5x5_BLIND = 2,
        /// <summary>
        /// Ranked Solo 5v5
        /// </summary>
        RANKED_SOLO_5x5 = 4,
        /// <summary>
        /// Ranked Premade 5v5. This queue is deprecated.
        /// </summary>
        RANKED_PREMADE_5x5 = 6,
        /// <summary>
        /// Historical Summoner's Rift Coop vs AI. This queue is deprecated.
        /// </summary>
        BOT_5x5 = 7,
        /// <summary>
        /// Normal 3v3
        /// </summary>
        NORMAL_3x3 = 8,
        /// <summary>
        /// Ranked Premade 3v3. This queue is deprecated.
        /// </summary>
        RANKED_PREMADE_3x3 = 9,
        /// <summary>
        /// Normal 5v5 Draft Pick
        /// </summary>
        NORMAL_5x5_DRAFT = 14,
        /// <summary>
        /// Dominion 5v5 Blind Pick
        /// </summary>
        ODIN_5x5_BLIND = 16,
        /// <summary>
        /// Dominion 5v5 Draft Pick
        /// </summary>
        ODIN_5x5_DRAFT = 17,
        /// <summary>
        /// Dominion Coop vs AI
        /// </summary>
        BOT_ODIN_5x5 = 25,
        /// <summary>
        /// Summoner's Rift Coop vs AI Intro Bot
        /// </summary>
        BOT_5x5_INTRO = 31,
        /// <summary>
        /// Summoner's Rift Coop vs AI Beginner Bot
        /// </summary>
        BOT_5x5_BEGINNER = 32,
        /// <summary>
        /// Historical Summoner's Rift Coop vs AI Intermediate Bot
        /// </summary>
        BOT_5x5_INTERMEDIATE = 33,
        /// <summary>
        /// Ranked Team 3v3
        /// </summary>
        RANKED_TEAM_3x3 = 41,
        /// <summary>
        /// Ranked Team 5v5
        /// </summary>
        RANKED_TEAM_5x5 = 42,
        /// <summary>
        /// Twisted Treeline Coop vs AI
        /// </summary>
        BOT_TT_3x3 = 52,
        /// <summary>
        /// Team Builder
        /// </summary>
        GROUP_FINDER_5x5 = 61,
        /// <summary>
        /// All Random All Mid
        /// </summary>
        ARAM_5x5 = 65,
        /// <summary>
        /// One for All
        /// </summary>
        ONEFORALL_5x5 = 70,
        /// <summary>
        /// Snowdown Showdown 1v1
        /// </summary>
        FIRSTBLOOD_1x1 = 72,
        /// <summary>
        /// Snowdown Showdown 2v2
        /// </summary>
        FIRSTBLOOD_2x2 = 73,
        /// <summary>
        /// Summoner's Rift Hexakill
        /// </summary>
        SR_6x6 = 75,
        /// <summary>
        /// Ultra Rapid Fire
        /// </summary>
        URF_5x5 = 76,
        /// <summary>
        /// Ultra Rapid Fire games played against AI
        /// </summary>
        BOT_URF_5x5 = 83,
        /// <summary>
        /// Doom Bots Rank 1
        /// </summary>
        NIGHTMARE_BOT_5x5_RANK1 = 91,
        /// <summary>
        /// Doom Bots Rank 2
        /// </summary>
        NIGHTMARE_BOT_5x5_RANK2 = 92,
        /// <summary>
        /// Doom Bots Rank 5
        /// </summary>
        NIGHTMARE_BOT_5x5_RANK5 = 93,
        /// <summary>
        /// Ascension
        /// </summary>
        ASCENSION_5x5 = 96,
        /// <summary>
        /// Twisted Treeline Hexakill
        /// </summary>
        HEXAKILL = 98,
        /// <summary>
        /// Bilgewater version of All Random All Mid
        /// </summary>
        BILGEWATER_ARAM_5x5 = 100,
        /// <summary>
        /// King Poro
        /// </summary>
        KING_PORO_5x5 = 300,
        /// <summary>
        /// Nemesis draft
        /// </summary>
        COUNTER_PICK = 310,
        /// <summary>
        /// Black Market Brawlers
        /// </summary>
        BILGEWATER_5x5 = 313,
        /// <summary>
        /// Nexus Siege
        /// </summary>
        SIEGE = 315,
        /// <summary>
        /// Definitely Not Dominion
        /// </summary>
        DEFINITELY_NOT_DOMINION_5x5 = 317,
        /// <summary>
        /// All Random URF
        /// </summary>
        ARURF_5x5 = 318,
        /// <summary>
        /// All Random Summoner's Rift
        /// </summary>
        ARSR_5x5 = 325,
        /// <summary>
        /// Normal 5v5 Draft Pick
        /// </summary>
        TEAM_BUILDER_DRAFT_UNRANKED_5x5 = 400,
        /// <summary>
        /// Ranked Dynamic Queue. This queue is deprecated.
        /// </summary>
        TEAM_BUILDER_DRAFT_RANKED_5x5 = 410,
        /// <summary>
        /// Ranked Solo/Duo Queue
        /// </summary>
        TEAM_BUILDER_RANKED_SOLO = 420,
        /// <summary>
        /// Normal 5v5 Blind Pick
        /// </summary>
        TB_BLIND_SUMMONERS_RIFT_5x5 = 430,
        /// <summary>
        /// Ranked Flex Summoner's Rift
        /// </summary>
        RANKED_FLEX_SR = 440,
        /// <summary>
        /// Blood Hunt Assassin
        /// </summary>
        ASSASSINATE_5x5 = 600,
        /// <summary>
        /// Darkstar
        /// </summary>
        DARKSTAR_3x3 = 610,
    }

    /// <summary>
    /// Represents a ranked queue.
    /// </summary>
    public enum RankedQueue
    {
        /// <summary>
        /// Ranked Solo 5v5
        /// </summary>
        RANKED_SOLO_5x5,
        /// <summary>
        /// Ranked Team 3v3 (season 5 and earlier)
        /// </summary>
        [Obsolete("You should probably not use this value anymore because it is only for games from season 5 and earlier.")]
        RANKED_TEAM_3x3,
        /// <summary>
        /// Ranked Team 5v5 (season 5 and earlier)
        /// </summary>
        [Obsolete("You should probably not use this value anymore because it is only for games from season 5 and earlier.")]
        RANKED_TEAM_5x5,
        /// <summary>
        /// Ranked dynamic queue (season 6 only)
        /// </summary>
        [Obsolete("You should probably not use this value anymore because it is only for games from season 6.")]
        TEAM_BUILDER_DRAFT_RANKED_5x5,
        /// <summary>
        /// Ranked Flex Summoner's Rift
        /// </summary>
        RANKED_FLEX_SR,
        /// <summary>
        /// Ranked Flex Twisted Treeline. Note that this value is ONLY used in <see cref="LeagueList"/> objects.
        /// <see cref="MatchReference"/> objects will use the <see cref="RANKED_TEAM_3x3"/> value instead.
        /// </summary>
        RANKED_FLEX_TT,
    }

    /// <summary>
    /// Represents a platform (or server).
    /// </summary>
    [JsonConverter(typeof(PlatformIdConverter))]
    public enum PlatformId
    {
        /// <summary>
        /// Brazil
        /// </summary>
        BR1,
        /// <summary>
        /// Europe Nordic &amp; East
        /// </summary>
        EUN1,
        /// <summary>
        /// Europe West
        /// </summary>
        EUW1,
        /// <summary>
        /// Japan
        /// </summary>
        JP1,
        /// <summary>
        /// Korea
        /// </summary>
        KR,
        /// <summary>
        /// Latin America North
        /// </summary>
        LA1,
        /// <summary>
        /// Latin America South
        /// </summary>
        LA2,
        /// <summary>
        /// North America
        /// </summary>
        NA1,
        /// <summary>
        /// Oceania
        /// </summary>
        OC1,
        /// <summary>
        /// Turkey
        /// </summary>
        TR1,
        /// <summary>
        /// Russia
        /// </summary>
        RU,
        /// <summary>
        /// Public Beta Environment
        /// </summary>
        PBE1,
    }

    /// <summary>
    /// Represents the season.
    /// </summary>
    public enum Season
    {
        /// <summary>
        /// Pre-season 3, 2013
        /// </summary>
        PRESEASON3 = 0,
        /// <summary>
        /// Season 3, 2013
        /// </summary>
        SEASON3 = 1,
        /// <summary>
        /// Pre-season 4, 2014
        /// </summary>
        PRESEASON2014 = 2,
        /// <summary>
        /// Season 4, 2014
        /// </summary>
        SEASON2014 = 3,
        /// <summary>
        /// Pre-season 5, 2015
        /// </summary>
        PRESEASON2015 = 4,
        /// <summary>
        /// Season 5, 2015
        /// </summary>
        SEASON2015 = 5,
        /// <summary>
        /// Pre-season 6, 2016
        /// </summary>
        PRESEASON2016 = 6,
        /// <summary>
        /// Season 6, 2016
        /// </summary>
        SEASON2016 = 7,
        /// <summary>
        /// Pre-season 7 and season 7, 2017
        /// </summary>
        PRESEASON2017 = 8,
    }

    /// <summary>
    /// Represents the status of one of the services on the Riot servers.
    /// </summary>
    public enum ServerStatus
    {
        /// <summary>
        /// Online
        /// </summary>
        Online,
        /// <summary>
        /// Alert
        /// </summary>
        Alert,
        /// <summary>
        /// Offline
        /// </summary>
        Offline,
        /// <summary>
        /// Deploying
        /// </summary>
        Deploying,
    }

    /// <summary>
    /// Represents the server incident message severity.
    /// </summary>
    public enum Severity
    {
        /// <summary>
        /// Info
        /// </summary>
        Info,
        /// <summary>
        /// Alert
        /// </summary>
        Alert,
        /// <summary>
        /// Error
        /// </summary>
        Error,
    }

    /// <summary>
    /// The type of spectators allowed for a game.
    /// </summary>
    public enum SpectatorType
    {
        /// <summary>
        /// No spectators are allowed.
        /// </summary>
        NONE,
        /// <summary>
        /// Spectators are allowed only if they joined in the lobby.
        /// </summary>
        LOBBYONLY,
        /// <summary>
        /// Spectators can join at any point (in the lobby or after the game starts).
        /// </summary>
        ALL
    }

    /// <summary>
    /// Identifies which side/team the player was on.
    /// </summary>
    [JsonConverter(typeof(TolerantIntEnumConverter))]
    public enum TeamSide
    {
        /// <summary>
        /// Team 1 (blue).
        /// </summary>
        Team1 = 100,
        /// <summary>
        /// Team 2 (red).
        /// </summary>
        Team2 = 200,
    }

    /// <summary>
    /// Represents a ranked tier.
    /// </summary>
    public enum Tier
    {
        /// <summary>
        /// Challenger tier
        /// </summary>
        CHALLENGER,
        /// <summary>
        /// Master tier
        /// </summary>
        MASTER,
        /// <summary>
        /// Diamond tier
        /// </summary>
        DIAMOND,
        /// <summary>
        /// Platinum tier
        /// </summary>
        PLATINUM,
        /// <summary>
        /// Gold tier
        /// </summary>
        GOLD,
        /// <summary>
        /// Silver tier
        /// </summary>
        SILVER,
        /// <summary>
        /// Bronze tier
        /// </summary>
        BRONZE,
        /// <summary>
        /// Unranked
        /// </summary>
        UNRANKED,
    }

    /// <summary>
    /// Represents the tower type. Used in <see cref="MatchEvent"/> for event type <see cref="EventType.BUILDING_KILL"/>.
    /// </summary>
    public enum TowerType
    {
        /// <summary>
        /// Base turret
        /// </summary>
        BASE_TURRET,
        /// <summary>
        /// Fountain turret
        /// </summary>
        FOUNTAIN_TURRET,
        /// <summary>
        /// Inner turret
        /// </summary>
        INNER_TURRET,
        /// <summary>
        /// Nexus turret
        /// </summary>
        NEXUS_TURRET,
        /// <summary>
        /// Outer turret
        /// </summary>
        OUTER_TURRET,
        /// <summary>
        /// Undefined turret
        /// </summary>
        UNDEFINED_TURRET,
    }

    /// <summary>
    /// Represents the ward type. Used in <see cref="MatchEvent"/> for event types <see cref="EventType.WARD_KILL"/> and <see cref="EventType.WARD_PLACED"/>.
    /// </summary>
    public enum WardType
    {
        /// <summary>
        /// Sight ward
        /// </summary>
        SIGHT_WARD,
        /// <summary>
        /// Teemo mushroom
        /// </summary>
        TEEMO_MUSHROOM,
        /// <summary>
        /// Undefined
        /// </summary>
        UNDEFINED,
        /// <summary>
        /// Vision ward
        /// </summary>
        VISION_WARD,
        /// <summary>
        /// Yellow trinket
        /// </summary>
        YELLOW_TRINKET,
        /// <summary>
        /// Yellow trinket upgrade
        /// </summary>
        YELLOW_TRINKET_UPGRADE,
        /// <summary>
        /// Blue trinket
        /// </summary>
        BLUE_TRINKET,
    }
}
