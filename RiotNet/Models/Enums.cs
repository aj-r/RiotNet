namespace RiotNet.Models
{
    /// <summary>
    /// Represents the ascension event type.  Used in <see cref="Event"/> for event type <see cref="EventType.ASCENDED_EVENT"/>.
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
    /// Represents the building type. Used in <see cref="Event"/> for event type <see cref="EventType.BUILDING_KILL"/>.
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
    /// Represents the event type. Used in <see cref="Event"/>.
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
        /// Item destroyed
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
        KINGPORO
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
    /// Represents the lane an event occured.  Used in <see cref="Event"/>.
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
    /// Represents the level up type. Used in <see cref="Event"/> for event type <see cref="EventType.SKILL_LEVEL_UP"/>.
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
        /// Jungle
        /// </summary>
        DUO_SUPPORT
    }

    /// <summary>
    /// Represents monster type.
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
    }

    /// <summary>
    /// Indicates a type of mastery tree.
    /// </summary>
    public enum MastertyTreeType
    {
        /// <summary>
        /// Specifies the Offense mastery tree.
        /// </summary>
        Offense,
        /// <summary>
        /// Specifies the Defense mastery tree.
        /// </summary>
        Defense,
        /// <summary>
        /// Specifies the Utility mastery tree.
        /// </summary>
        Utility
    }

    /// <summary>
    /// Represents player's position.
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
    /// Represents a capturable point in Dominion. Used in <see cref="Event"/> for event type <see cref="EventType.CAPTURE_POINT"/>.
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
        /// Custom games
        /// </summary>
        CUSTOM = 0,
        /// <summary>
        /// Normal 5v5 Blind Pick games
        /// </summary>
        NORMAL_5x5_BLIND = 2,
        /// <summary>
        /// Historical Summoner's Rift Coop vs AI games
        /// </summary>
        BOT_5x5 = 7,
        /// <summary>
        /// Summoner's Rift Coop vs AI Intro Bot games
        /// </summary>
        BOT_5x5_INTRO = 31,
        /// <summary>
        /// Summoner's Rift Coop vs AI Beginner Bot games
        /// </summary>
        BOT_5x5_BEGINNER = 32,
        /// <summary>
        /// Historical Summoner's Rift Coop vs AI Intermediate Bot games
        /// </summary>
        BOT_5x5_INTERMEDIATE = 33,
        /// <summary>
        /// Normal 3v3 games
        /// </summary>
        NORMAL_3x3 = 8,
        /// <summary>
        /// Normal 5v5 Draft Pick games
        /// </summary>
        NORMAL_5x5_DRAFT = 14,
        /// <summary>
        /// Dominion 5v5 Blind Pick games
        /// </summary>
        ODIN_5x5_BLIND = 16,
        /// <summary>
        /// Dominion 5v5 Draft Pick games
        /// </summary>
        ODIN_5x5_DRAFT = 17,
        /// <summary>
        /// Dominion Coop vs AI games
        /// </summary>
        BOT_ODIN_5x5 = 25,
        /// <summary>
        /// Ranked Solo 5v5 games
        /// </summary>
        RANKED_SOLO_5x5 = 4,
        /// <summary>
        /// Ranked Premade 3v3 games
        /// </summary>
        RANKED_PREMADE_3x3 = 9,
        /// <summary>
        /// Ranked Premade 5v5 games
        /// </summary>
        RANKED_PREMADE_5x5 = 6,
        /// <summary>
        /// Ranked Team 3v3 games
        /// </summary>
        RANKED_TEAM_3x3 = 41,
        /// <summary>
        /// Ranked Team 5v5 games
        /// </summary>
        RANKED_TEAM_5x5 = 42,
        /// <summary>
        /// Twisted Treeline Coop vs AI games
        /// </summary>
        BOT_TT_3x3 = 52,
        /// <summary>
        /// Team Builder games
        /// </summary>
        GROUP_FINDER_5x5 = 61,
        /// <summary>
        /// ARAM games
        /// </summary>
        ARAM_5x5 = 65,
        /// <summary>
        /// One for All games
        /// </summary>
        ONEFORALL_5x5 = 70,
        /// <summary>
        /// Snowdown Showdown 1v1 games
        /// </summary>
        FIRSTBLOOD_1x1 = 72,
        /// <summary>
        /// Snowdown Showdown 2v2 games
        /// </summary>
        FIRSTBLOOD_2x2 = 73,
        /// <summary>
        /// Summoner's Rift 6x6 Hexakill games
        /// </summary>
        SR_6x6 = 75,
        /// <summary>
        /// Ultra Rapid Fire games
        /// </summary>
        URF_5x5 = 76,
        /// <summary>
        /// Ultra Rapid Fire games played against AI games
        /// </summary>
        BOT_URF_5x5 = 83,
        /// <summary>
        /// Doom Bots Rank 1 games
        /// </summary>
        NIGHTMARE_BOT_5x5_RANK1 = 91,
        /// <summary>
        /// Doom Bots Rank 2 games
        /// </summary>
        NIGHTMARE_BOT_5x5_RANK2 = 92,
        /// <summary>
        /// Doom Bots Rank 5 games
        /// </summary>
        NIGHTMARE_BOT_5x5_RANK5 = 93,
        /// <summary>
        /// Ascension games
        /// </summary>
        ASCENSION_5x5 = 96,
        /// <summary>
        /// Twisted Treeline 6x6 Hexakill games
        /// </summary>
        HEXAKILL = 98,
        /// <summary>
        /// King Poro games
        /// </summary>
        KING_PORO_5x5 = 300,
        /// <summary>
        /// Nemesis games
        /// </summary>
        COUNTER_PICK = 310,
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
        /// Ranked Team 3v3
        /// </summary>
        RANKED_TEAM_3x3,
        /// <summary>
        /// Ranked Team 5v5
        /// </summary>
        RANKED_TEAM_5x5,
    }

    /// <summary>
    /// Represents a region (or server).
    /// </summary>
    public enum Region
    {
        /// <summary>
        /// Brazil
        /// </summary>
        BR,
        /// <summary>
        /// Europe Nordic &amp; East
        /// </summary>
        EUNE,
        /// <summary>
        /// Europe West
        /// </summary>
        EUW,
        /// <summary>
        /// Korea
        /// </summary>
        KR,
        /// <summary>
        /// Latin America North
        /// </summary>
        LAN,
        /// <summary>
        /// Latin America South
        /// </summary>
        LAS,
        /// <summary>
        /// North America
        /// </summary>
        NA,
        /// <summary>
        /// Oceania
        /// </summary>
        OCE,
        /// <summary>
        /// Public Beta Environment
        /// </summary>
        PBE,
        /// <summary>
        /// Russia
        /// </summary>
        RU,
        /// <summary>
        /// Turkey
        /// </summary>
        TR,
    }

    /// <summary>
    /// Represents the season.
    /// </summary>
    public enum Season
    {
        /// <summary>
        /// Pre-season 3, 2013
        /// </summary>
        PRESEASON3,
        /// <summary>
        /// Season 3, 2013
        /// </summary>
        SEASON3,
        /// <summary>
        /// Pre-season 4, 2014
        /// </summary>
        PRESEASON2014,
        /// <summary>
        /// Season 4, 2014
        /// </summary>
        SEASON2014,
        /// <summary>
        /// Pre-season 5, 2015
        /// </summary>
        PRESEASON2015,
        /// <summary>
        /// Season 5, 2015
        /// </summary>
        SEASON2015,
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
    /// Identifies which side/team the player was on.
    /// </summary>
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
    /// Represents the tower type. Used in <see cref="Event"/> for event type <see cref="EventType.BUILDING_KILL"/>.
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
    /// Represents the ward type. Used in <see cref="Event"/> for event types <see cref="EventType.WARD_KILL"/> and <see cref="EventType.WARD_PLACED"/>.
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
    }
}
