using Newtonsoft.Json;
using RiotNet.Converters;

namespace RiotNet.Models
{
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
        /// Ranked Flex 3v3. This was formerly called <see cref="RANKED_PREMADE_3x3"/>.
        /// </summary>
        RANKED_FLEX_TT = 9,
        /// <summary>
        /// Ranked Flex 3v3. This is the old name for <see cref="RANKED_FLEX_TT"/>.
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
}
