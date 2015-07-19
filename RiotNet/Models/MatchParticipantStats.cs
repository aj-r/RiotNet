using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// This object contains participant statistics information.
    /// </summary>
    [ComplexType]
    public class MatchParticipantStats
    {
        /// <summary>
        /// Gets or sets number of assists.
        /// </summary>
        public long Assists { get; set; }

        /// <summary>
        /// Gets or sets champion level achieved.
        /// </summary>
        public long ChampLevel { get; set; }

        /// <summary>
        /// Gets or sets if game was a dominion game, player's combat score, otherwise 0.
        /// </summary>
        public long CombatPlayerScore { get; set; }

        /// <summary>
        /// Gets or sets number of deaths.
        /// </summary>
        public long Deaths { get; set; }

        /// <summary>
        /// Gets or sets number of double kills.
        /// </summary>
        public long DoubleKills { get; set; }

        /// <summary>
        /// Gets or sets flag indicating if participant got an assist on first blood.
        /// </summary>
        public bool FirstBloodAssist { get; set; }

        /// <summary>
        /// Gets or sets flag indicating if participant got first blood.
        /// </summary>
        public bool FirstBloodKill { get; set; }

        /// <summary>
        /// Gets or sets flag indicating if participant got an assist on the first inhibitor.
        /// </summary>
        public bool FirstInhibitorAssist { get; set; }

        /// <summary>
        /// Gets or sets flag indicating if participant destroyed the first inhibitor.
        /// </summary>
        public bool FirstInhibitorKill { get; set; }

        /// <summary>
        /// Gets or sets flag indicating if participant got an assist on the first tower.
        /// </summary>
        public bool FirstTowerAssist { get; set; }

        /// <summary>
        /// Gets or sets flag indicating if participant destroyed the first tower.
        /// </summary>
        public bool FirstTowerKill { get; set; }

        /// <summary>
        /// Gets or sets gold earned.
        /// </summary>
        public long GoldEarned { get; set; }

        /// <summary>
        /// Gets or sets gold spent.
        /// </summary>
        public long GoldSpent { get; set; }

        /// <summary>
        /// Gets or sets number of inhibitor kills.
        /// </summary>
        public long InhibitorKills { get; set; }

        /// <summary>
        /// Gets or sets first item ID.
        /// </summary>
        public long Item0 { get; set; }

        /// <summary>
        /// Gets or sets second item ID.
        /// </summary>
        public long Item1 { get; set; }

        /// <summary>
        /// Gets or sets third item ID.
        /// </summary>
        public long Item2 { get; set; }

        /// <summary>
        /// Gets or sets fourth item ID.
        /// </summary>
        public long Item3 { get; set; }

        /// <summary>
        /// Gets or sets fifth item ID.
        /// </summary>
        public long Item4 { get; set; }

        /// <summary>
        /// Gets or sets sixth item ID.
        /// </summary>
        public long Item5 { get; set; }

        /// <summary>
        /// Gets or sets seventh item ID.
        /// </summary>
        public long Item6 { get; set; }

        /// <summary>
        /// Gets or sets number of killing sprees.
        /// </summary>
        public long KillingSprees { get; set; }

        /// <summary>
        /// Gets or sets number of kills.
        /// </summary>
        public long Kills { get; set; }

        /// <summary>
        /// Gets or sets largest critical strike.
        /// </summary>
        public long LargestCriticalStrike { get; set; }

        /// <summary>
        /// Gets or sets largest killing spree.
        /// </summary>
        public long LargestKillingSpree { get; set; }

        /// <summary>
        /// Gets or sets largest multi kill.
        /// </summary>
        public long LargestMultiKill { get; set; }

        /// <summary>
        /// Gets or sets magical damage dealt.
        /// </summary>
        public long MagicDamageDealt { get; set; }

        /// <summary>
        /// Gets or sets magical damage dealt to champions.
        /// </summary>
        public long MagicDamageDealtToChampions { get; set; }

        /// <summary>
        /// Gets or sets magic damage taken.
        /// </summary>
        public long MagicDamageTaken { get; set; }

        /// <summary>
        /// Gets or sets minions killed.
        /// </summary>
        public long MinionsKilled { get; set; }

        /// <summary>
        /// Gets or sets neutral minions killed.
        /// </summary>
        public long NeutralMinionsKilled { get; set; }

        /// <summary>
        /// Gets or sets neutral jungle minions killed in the enemy team's jungle.
        /// </summary>
        public long NeutralMinionsKilledEnemyJungle { get; set; }

        /// <summary>
        /// Gets or sets neutral jungle minions killed in your team's jungle.
        /// </summary>
        public long NeutralMinionsKilledTeamJungle { get; set; }

        /// <summary>
        /// Gets or sets if game was a dominion game, number of point captures.
        /// </summary>
        public long NodeCapture { get; set; }

        /// <summary>
        /// Gets or sets if game was a dominion game, number of point capture assists.
        /// </summary>
        public long NodeCaptureAssist { get; set; }

        /// <summary>
        /// Gets or sets if game was a dominion game, number of point neutralizations.
        /// </summary>
        public long NodeNeutralize { get; set; }

        /// <summary>
        /// Gets or sets if game was a dominion game, number of point neutralization assists.
        /// </summary>
        public long NodeNeutralizeAssist { get; set; }

        /// <summary>
        /// Gets or sets if game was a dominion game, player's objectives score, otherwise 0.
        /// </summary>
        public long ObjectivePlayerScore { get; set; }

        /// <summary>
        /// Gets or sets number of penta kills.
        /// </summary>
        public long PentaKills { get; set; }

        /// <summary>
        /// Gets or sets physical damage dealt.
        /// </summary>
        public long PhysicalDamageDealt { get; set; }

        /// <summary>
        /// Gets or sets physical damage dealt to champions.
        /// </summary>
        public long PhysicalDamageDealtToChampions { get; set; }

        /// <summary>
        /// Gets or sets physical damage taken.
        /// </summary>
        public long PhysicalDamageTaken { get; set; }

        /// <summary>
        /// Gets or sets number of quadra kills.
        /// </summary>
        public long QuadraKills { get; set; }

        /// <summary>
        /// Gets or sets sight wards purchased.
        /// </summary>
        public long SightWardsBoughtInGame { get; set; }

        /// <summary>
        /// Gets or sets if game was a dominion game, number of completed team objectives (i.e., quests).
        /// </summary>
        public long TeamObjective { get; set; }

        /// <summary>
        /// Gets or sets total damage dealt.
        /// </summary>
        public long TotalDamageDealt { get; set; }

        /// <summary>
        /// Gets or sets total damage dealt to champions.
        /// </summary>
        public long TotalDamageDealtToChampions { get; set; }

        /// <summary>
        /// Gets or sets total damage taken.
        /// </summary>
        public long TotalDamageTaken { get; set; }

        /// <summary>
        /// Gets or sets total heal amount.
        /// </summary>
        public long TotalHeal { get; set; }

        /// <summary>
        /// Gets or sets if game was a dominion game, player's total score, otherwise 0.
        /// </summary>
        public long TotalPlayerScore { get; set; }

        /// <summary>
        /// Gets or sets if game was a dominion game, team rank of the player's total score (e.g., 1-5).
        /// </summary>
        public long TotalScoreRank { get; set; }

        /// <summary>
        /// Gets or sets total dealt crowd control time.
        /// </summary>
        public long TotalTimeCrowdControlDealt { get; set; }

        /// <summary>
        /// Gets or sets total units healed.
        /// </summary>
        public long TotalUnitsHealed { get; set; }

        /// <summary>
        /// Gets or sets number of tower kills.
        /// </summary>
        public long TowerKills { get; set; }

        /// <summary>
        /// Gets or sets number of triple kills.
        /// </summary>
        public long TripleKills { get; set; }

        /// <summary>
        /// Gets or sets true damage dealt.
        /// </summary>
        public long TrueDamageDealt { get; set; }

        /// <summary>
        /// Gets or sets true damage dealt to champions.
        /// </summary>
        public long TrueDamageDealtToChampions { get; set; }

        /// <summary>
        /// Gets or sets true damage taken.
        /// </summary>
        public long TrueDamageTaken { get; set; }

        /// <summary>
        /// Gets or sets number of unreal kills (beyond pentakill).
        /// </summary>
        public long UnrealKills { get; set; }

        /// <summary>
        /// Gets or sets vision wards purchased.
        /// </summary>
        public long VisionWardsBoughtInGame { get; set; }

        /// <summary>
        /// Gets or sets number of wards killed.
        /// </summary>
        public long WardsKilled { get; set; }

        /// <summary>
        /// Gets or sets number of wards placed.
        /// </summary>
        public long WardsPlaced { get; set; }

        /// <summary>
        /// Gets or sets flag indicating whether or not the participant won.
        /// </summary>
        public bool Winner { get; set; }
    }
}
