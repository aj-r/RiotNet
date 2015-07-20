using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// This object contains aggregated stat information (can be for a specific champion, or for a specific game mode, or overall).
    /// Only some of these stats are used at a time, depending on what was requested.
    /// </summary>
    [ComplexType]
    public class AggregatedStats
    {
        /// <summary>
        /// Gets or sets the average number of assists (Dominion only).
        /// </summary>
        public int AverageAssists { get; set; }

        /// <summary>
        /// Gets or sets the average number of kills (Dominion only).
        /// </summary>
        public int AverageChampionsKilled { get; set; }

        /// <summary>
        /// Gets or sets the average combat score (Dominion only).
        /// </summary>
        public int AverageCombatPlayerScore { get; set; }

        /// <summary>
        /// Gets or sets the average number of points captured (Dominion only).
        /// </summary>
        public int AverageNodeCapture { get; set; }

        /// <summary>
        /// Gets or sets the average number of point capture assists (Dominion only).
        /// </summary>
        public int AverageNodeCaptureAssist { get; set; }

        /// <summary>
        /// Gets or sets the average number of points neutralized (Dominion only).
        /// </summary>
        public int AverageNodeNeutralize { get; set; }

        /// <summary>
        /// Gets or sets the average number of point-neutralized assists (Dominion only).
        /// </summary>
        public int AverageNodeNeutralizeAssist { get; set; }

        /// <summary>
        /// Gets or sets the average number of deaths (Dominion only).
        /// </summary>
        public int AverageNumDeaths { get; set; }

        /// <summary>
        /// Gets or sets the average objective player score (Dominion only).
        /// </summary>
        public int AverageObjectivePlayerScore { get; set; }

        /// <summary>
        /// Gets or sets the average number of objectives (quests) completed (Dominion only).
        /// </summary>
        public int AverageTeamObjective { get; set; }

        /// <summary>
        /// Gets or sets the average total player score (Dominion only).
        /// </summary>
        public int AverageTotalPlayerScore { get; set; }

        /// <summary>
        /// Gets or sets the number of bot games played.
        /// </summary>
        public int BotGamesPlayed { get; set; }

        /// <summary>
        /// Gets or sets the number of killing sprees achieved.
        /// </summary>
        public int KillingSpree { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of assists (Dominion only).
        /// </summary>
        public int MaxAssists { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of champions killed in the game.
        /// </summary>
        public int MaxChampionsKilled { get; set; }

        /// <summary>
        /// Gets or sets the maximum conbat player score (Dominion only).
        /// </summary>
        public int MaxCombatPlayerScore { get; set; }

        /// <summary>
        /// Gets or sets the largest critical strike achieved.
        /// </summary>
        public int MaxLargestCriticalStrike { get; set; }

        /// <summary>
        /// Gets or sets the largest killing spree achieved.
        /// </summary>
        public int MaxLargestKillingSpree { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of points captured (Dominion only).
        /// </summary>
        public int MaxNodeCapture { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of point capture assists (Dominion only).
        /// </summary>
        public int MaxNodeCaptureAssist { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of points neutralized (Dominion only).
        /// </summary>
        public int MaxNodeNeutralize { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of point-neutralize assists (Dominion only).
        /// </summary>
        public int MaxNodeNeutralizeAssist { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of deaths (only returned for ranked statistics).
        /// </summary>
        public int MaxNumDeaths { get; set; }

        /// <summary>
        /// Gets or sets the maximum objective player score (Dominion only).
        /// </summary>
        public int MaxObjectivePlayerScore { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of team objectives achieved (Dominion only).
        /// </summary>
        public int MaxTeamObjective { get; set; }

        /// <summary>
        /// Gets or sets the longest game played.
        /// </summary>
        public int MaxTimePlayed { get; set; }

        /// <summary>
        /// Gets or sets the maximum time spent living.
        /// </summary>
        public int MaxTimeSpentLiving { get; set; }

        /// <summary>
        /// Gets or sets the largest total player score (Dominion only).
        /// </summary>
        public int MaxTotalPlayerScore { get; set; }

        /// <summary>
        /// Gets or sets the most champion kills per session.
        /// </summary>
        public int MostChampionKillsPerSession { get; set; }

        /// <summary>
        /// Gets or sets the most spells cast in a game.
        /// </summary>
        public int MostSpellsCast { get; set; }

        /// <summary>
        /// Gets or sets the number of normal games played.
        /// </summary>
        public int NormalGamesPlayed { get; set; }

        /// <summary>
        /// Gets or sets the number of ranked premade games played.
        /// </summary>
        public int RankedPremadeGamesPlayed { get; set; }

        /// <summary>
        /// Gets or sets the number of ranked solo games played.
        /// </summary>
        public int RankedSoloGamesPlayed { get; set; }

        /// <summary>
        /// Gets or sets the total number of assists.
        /// </summary>
        public int TotalAssists { get; set; }

        /// <summary>
        /// Gets or sets the total number of champion kills.
        /// </summary>
        public int TotalChampionKills { get; set; }

        /// <summary>
        /// Gets or sets the total amount of damage dealt.
        /// </summary>
        public int TotalDamageDealt { get; set; }

        /// <summary>
        /// Gets or sets the total amount of damage taken.
        /// </summary>
        public int TotalDamageTaken { get; set; }

        /// <summary>
        /// Gets or sets the total number of deaths per session (only returned for ranked statistics).
        /// </summary>
        public int TotalDeathsPerSession { get; set; }

        /// <summary>
        /// Gets or sets the total number of double kills.
        /// </summary>
        public int TotalDoubleKills { get; set; }

        /// <summary>
        /// Gets or sets the number of firstbloods achieved.
        /// </summary>
        public int TotalFirstBlood { get; set; }

        /// <summary>
        /// Gets or sets the total amount of gold earned.
        /// </summary>
        public int TotalGoldEarned { get; set; }

        /// <summary>
        /// Gets or sets the total amount of healing done.
        /// </summary>
        public int TotalHeal { get; set; }

        /// <summary>
        /// Gets or sets the total amount of magic damage dealt.
        /// </summary>
        public int TotalMagicDamageDealt { get; set; }

        /// <summary>
        /// Gets or sets the total number of minion kills.
        /// </summary>
        public int TotalMinionKills { get; set; }

        /// <summary>
        /// Gets or sets the total number of neutral minions killed.
        /// </summary>
        public int TotalNeutralMinionsKilled { get; set; }

        /// <summary>
        /// Gets or sets the number of points captured (Dominion only).
        /// </summary>
        public int TotalNodeCapture { get; set; }

        /// <summary>
        /// Gets or sets the number of points neutralized (Dominion only).
        /// </summary>
        public int TotalNodeNeutralize { get; set; }

        /// <summary>
        /// Gets or sets the number of pentakills achieved.
        /// </summary>
        public int TotalPentaKills { get; set; }

        /// <summary>
        /// Gets or sets the total amount of physical damage dealt.
        /// </summary>
        public int TotalPhysicalDamageDealt { get; set; }

        /// <summary>
        /// Gets or sets the number of quadrakills achieved.
        /// </summary>
        public int TotalQuadraKills { get; set; }

        /// <summary>
        /// Gets or sets the number of sessions lost.
        /// </summary>
        public int TotalSessionsLost { get; set; }

        /// <summary>
        /// Gets or sets the number of sessions played.
        /// </summary>
        public int TotalSessionsPlayed { get; set; }

        /// <summary>
        /// Gets or sets the number of sessions won.
        /// </summary>
        public int TotalSessionsWon { get; set; }

        /// <summary>
        /// Gets or sets the number of triple kills.
        /// </summary>
        public int TotalTripleKills { get; set; }

        /// <summary>
        /// Gets or sets the number of turrets killed.
        /// </summary>
        public int TotalTurretsKilled { get; set; }

        /// <summary>
        /// Gets or sets the number of unreal kills (beyond pentakill).
        /// </summary>
        public int TotalUnrealKills { get; set; }
    }
}
