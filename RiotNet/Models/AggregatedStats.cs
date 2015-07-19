using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RiotNet.Models
{
    /// <summary>
    /// This object contains aggregated stat information.
    /// </summary>
    public class AggregatedStats
    {
        /// <summary>
        /// Gets or sets average number of assists on champion (Dominion only).
        /// </summary>
        public int AverageAssists { get; set; }

        /// <summary>
        /// Gets or sets average number of kills on champion (Dominion only).
        /// </summary>
        public int AverageChampionsKilled { get; set; }

        /// <summary>
        /// Gets or sets average combat score on champion (Dominion only).
        /// </summary>
        public int AverageCombatPlayerScore { get; set; }

        /// <summary>
        /// Gets or sets average number of points captured on champion (Dominion only).
        /// </summary>
        public int AverageNodeCapture { get; set; }

        /// <summary>
        /// Gets or sets average number of point capture assists on champion (Dominion only).
        /// </summary>
        public int AverageNodeCaptureAssist { get; set; }

        /// <summary>
        /// Gets or sets average number of points neutralized on champion (Dominion only).
        /// </summary>
        public int AverageNodeNeutralize { get; set; }

        /// <summary>
        /// Gets or sets average number of point neutralized assists on champion (Dominion only).
        /// </summary>
        public int AverageNodeNeutralizeAssist { get; set; }

        /// <summary>
        /// Gets or sets average number of deaths on champion (Dominion only).
        /// </summary>
        public int AverageNumDeaths { get; set; }

        /// <summary>
        /// Gets or sets average objective player score on champion (Dominion only).
        /// </summary>
        public int AverageObjectivePlayerScore { get; set; }

        /// <summary>
        /// Gets or sets average team objective on champion (Dominion only).
        /// </summary>
        public int AverageTeamObjective { get; set; }

        /// <summary>
        /// Gets or sets average total player score on champion (Dominion only).
        /// </summary>
        public int AverageTotalPlayerScore { get; set; }

        /// <summary>
        /// Gets or sets bot games played on champion.
        /// </summary>
        public int BotGamesPlayed { get; set; }

        /// <summary>
        /// Gets or sets number of killing sprees on champion.
        /// </summary>
        public int KillingSpree { get; set; }

        /// <summary>
        /// Gets or sets maximum number of assists on champion (Dominion only).
        /// </summary>
        public int MaxAssists { get; set; }

        /// <summary>
        /// Gets or sets maximum number of champions killed on champion.
        /// </summary>
        public int MaxChampionsKilled { get; set; }

        /// <summary>
        /// Gets or sets maximum conbat player score on champion (Dominion only).
        /// </summary>
        public int MaxCombatPlayerScore { get; set; }

        /// <summary>
        /// Gets or sets largest critical strike on champion.
        /// </summary>
        public int MaxLargestCriticalStrike { get; set; }

        /// <summary>
        /// Gets or sets largest killing spree on champion.
        /// </summary>
        public int MaxLargestKillingSpree { get; set; }

        /// <summary>
        /// Gets or sets maximum number of points captured on champion (Dominion only).
        /// </summary>
        public int MaxNodeCapture { get; set; }

        /// <summary>
        /// Gets or sets maximum number of point capture assists on champion (Dominion only).
        /// </summary>
        public int MaxNodeCaptureAssist { get; set; }

        /// <summary>
        /// Gets or sets maximum number of points neutralized on champion (Dominion only).
        /// </summary>
        public int MaxNodeNeutralize { get; set; }

        /// <summary>
        /// Gets or sets maximum number of point neutralize assists on champion (Dominion only).
        /// </summary>
        public int MaxNodeNeutralizeAssist { get; set; }

        /// <summary>
        /// Gets or sets maximum number of deaths (only returned for ranked statistics).
        /// </summary>
        public int MaxNumDeaths { get; set; }

        /// <summary>
        /// Gets or sets maximum objective player score on champion (Dominion only).
        /// </summary>
        public int MaxObjectivePlayerScore { get; set; }

        /// <summary>
        /// Gets or sets maximum number of team objectives achieved on champion (Dominion only).
        /// </summary>
        public int MaxTeamObjective { get; set; }

        /// <summary>
        /// Gets or sets longest game played on champion.
        /// </summary>
        public int MaxTimePlayed { get; set; }

        /// <summary>
        /// Gets or sets maximum time spent living on champion.
        /// </summary>
        public int MaxTimeSpentLiving { get; set; }

        /// <summary>
        /// Gets or sets largest total player score on champion (Dominion only).
        /// </summary>
        public int MaxTotalPlayerScore { get; set; }

        /// <summary>
        /// Gets or sets most champion kills per session on champion.
        /// </summary>
        public int MostChampionKillsPerSession { get; set; }

        /// <summary>
        /// Gets or sets most spells cast on champion.
        /// </summary>
        public int MostSpellsCast { get; set; }

        /// <summary>
        /// Gets or sets number of normal games played on champion.
        /// </summary>
        public int NormalGamesPlayed { get; set; }

        /// <summary>
        /// Gets or sets number of ranked premade games played on champion.
        /// </summary>
        public int RankedPremadeGamesPlayed { get; set; }

        /// <summary>
        /// Gets or sets number of ranked solo games played on champion.
        /// </summary>
        public int RankedSoloGamesPlayed { get; set; }

        /// <summary>
        /// Gets or sets total assists on champion.
        /// </summary>
        public int TotalAssists { get; set; }

        /// <summary>
        /// Gets or sets total champion kills on champion.
        /// </summary>
        public int TotalChampionKills { get; set; }

        /// <summary>
        /// Gets or sets total damage dealt on champion.
        /// </summary>
        public int TotalDamageDealt { get; set; }

        /// <summary>
        /// Gets or sets total damage taken on champion.
        /// </summary>
        public int TotalDamageTaken { get; set; }

        /// <summary>
        /// Gets or sets total deaths per session on champion (only returned for ranked statistics).
        /// </summary>
        public int TotalDeathsPerSession { get; set; }

        /// <summary>
        /// Gets or sets total double kills on champion.
        /// </summary>
        public int TotalDoubleKills { get; set; }

        /// <summary>
        /// Gets or sets number of firstbloods on champion.
        /// </summary>
        public int TotalFirstBlood { get; set; }

        /// <summary>
        /// Gets or sets total gold earned on champion.
        /// </summary>
        public int TotalGoldEarned { get; set; }

        /// <summary>
        /// Gets or sets total amount healed on champion.
        /// </summary>
        public int TotalHeal { get; set; }

        /// <summary>
        /// Gets or sets total magic damage dealt on champion.
        /// </summary>
        public int TotalMagicDamageDealt { get; set; }

        /// <summary>
        /// Gets or sets total minion kills on champion.
        /// </summary>
        public int TotalMinionKills { get; set; }

        /// <summary>
        /// Gets or sets total neutral minions killed on champion.
        /// </summary>
        public int TotalNeutralMinionsKilled { get; set; }

        /// <summary>
        /// Gets or sets number of points captured on champion (Dominion only).
        /// </summary>
        public int TotalNodeCapture { get; set; }

        /// <summary>
        /// Gets or sets number of points neutralized on champion (Dominion only).
        /// </summary>
        public int TotalNodeNeutralize { get; set; }

        /// <summary>
        /// Gets or sets numebr of pentakills on champion.
        /// </summary>
        public int TotalPentaKills { get; set; }

        /// <summary>
        /// Gets or sets total physical damage dealt on champion.
        /// </summary>
        public int TotalPhysicalDamageDealt { get; set; }

        /// <summary>
        /// Gets or sets number of quadrakills on champion.
        /// </summary>
        public int TotalQuadraKills { get; set; }

        /// <summary>
        /// Gets or sets number of sessions lost on champion.
        /// </summary>
        public int TotalSessionsLost { get; set; }

        /// <summary>
        /// Gets or sets number of sessions played on champion.
        /// </summary>
        public int TotalSessionsPlayed { get; set; }

        /// <summary>
        /// Gets or sets number of sessions won on champion.
        /// </summary>
        public int TotalSessionsWon { get; set; }

        /// <summary>
        /// Gets or sets number of triple kills on champion.
        /// </summary>
        public int TotalTripleKills { get; set; }

        /// <summary>
        /// Gets or sets number of turrets killed on champion.
        /// </summary>
        public int TotalTurretsKilled { get; set; }

        /// <summary>
        /// Gets or sets number of unreal kills (beyond pentakill) on champion.
        /// </summary>
        public int TotalUnrealKills { get; set; }
    }
}
