namespace RiotNet.Models
{
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
