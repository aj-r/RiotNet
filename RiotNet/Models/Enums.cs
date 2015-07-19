namespace RiotNet.Models
{
    /// <summary>
    /// Represents a game mode.
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
    /// Represents a game sub-type.
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
        /// Matched game (queued up for)
        /// </summary>
        MATCHED_GAME,
        /// <summary>
        /// Tutorial game
        /// </summary>
        TUTORIAL_GAME,
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
    /// Represents player's role.
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
        Challenger,
        /// <summary>
        /// Master tier
        /// </summary>
        Master,
        /// <summary>
        /// Diamond tier
        /// </summary>
        Diamond,
        /// <summary>
        /// Platinum tier
        /// </summary>
        Platinum,
        /// <summary>
        /// Gold tier
        /// </summary>
        Gold,
        /// <summary>
        /// Silver tier
        /// </summary>
        Silver,
        /// <summary>
        /// Bronze tier
        /// </summary>
        Bronze
    }
}
