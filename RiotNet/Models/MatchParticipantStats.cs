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
        /// Gets or sets the number of assists.
        /// </summary>
        public long Assists { get; set; }

        /// <summary>
        /// Gets or sets the champion level at the end of the game.
        /// </summary>
        public long ChampLevel { get; set; }

        /// <summary>
        /// Gets or sets the player's combat score if the game was a dominion game. This value is always 0 for non-dominion games.
        /// </summary>
        public long CombatPlayerScore { get; set; }

        /// <summary>
        /// Gets or sets the number of deaths.
        /// </summary>
        public long Deaths { get; set; }

        /// <summary>
        /// Gets or sets the number of double kills.
        /// </summary>
        public long DoubleKills { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if participant got an assist on first blood.
        /// </summary>
        public bool FirstBloodAssist { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if participant got first blood.
        /// </summary>
        public bool FirstBloodKill { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if participant got an assist on the first inhibitor.
        /// </summary>
        public bool FirstInhibitorAssist { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if participant destroyed the first inhibitor.
        /// </summary>
        public bool FirstInhibitorKill { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if participant got an assist on the first tower.
        /// </summary>
        public bool FirstTowerAssist { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if participant destroyed the first tower.
        /// </summary>
        public bool FirstTowerKill { get; set; }

        /// <summary>
        /// Gets or sets the gold earned by the participant.
        /// </summary>
        public long GoldEarned { get; set; }

        /// <summary>
        /// Gets or sets the gold spent by the participant.
        /// </summary>
        public long GoldSpent { get; set; }

        /// <summary>
        /// Gets or sets the number of inhibitor kills.
        /// </summary>
        public long InhibitorKills { get; set; }

        /// <summary>
        /// Gets or sets the ID of the item in slot 0 at the end of the game.
        /// </summary>
        public long Item0 { get; set; }

        /// <summary>
        /// Gets or sets the ID of the item in slot 1 at the end of the game.
        /// </summary>
        public long Item1 { get; set; }

        /// <summary>
        /// Gets or sets the ID of the item in slot 2 at the end of the game.
        /// </summary>
        public long Item2 { get; set; }

        /// <summary>
        /// Gets or sets the ID of the item in slot 3 at the end of the game.
        /// </summary>
        public long Item3 { get; set; }

        /// <summary>
        /// Gets or sets the ID of the item in slot 4 at the end of the game.
        /// </summary>
        public long Item4 { get; set; }

        /// <summary>
        /// Gets or sets the ID of the item in slot 5 at the end of the game.
        /// </summary>
        public long Item5 { get; set; }

        /// <summary>
        /// Gets or sets the ID of the item in slot 6 at the end of the game.
        /// </summary>
        public long Item6 { get; set; }

        /// <summary>
        /// Gets or sets the number of killing sprees.
        /// </summary>
        public long KillingSprees { get; set; }

        /// <summary>
        /// Gets or sets the number of kills.
        /// </summary>
        public long Kills { get; set; }

        /// <summary>
        /// Gets or sets the largest critical strike.
        /// </summary>
        public long LargestCriticalStrike { get; set; }

        /// <summary>
        /// Gets or sets the largest killing spree.
        /// </summary>
        public long LargestKillingSpree { get; set; }

        /// <summary>
        /// Gets or sets the largest multi kill.
        /// </summary>
        public long LargestMultiKill { get; set; }

        /// <summary>
        /// Gets or sets the amount of magical damage dealt.
        /// </summary>
        public long MagicDamageDealt { get; set; }

        /// <summary>
        /// Gets or setsthe amount of magical damage dealt to champions.
        /// </summary>
        public long MagicDamageDealtToChampions { get; set; }

        /// <summary>
        /// Gets or sets the amount of magic damage taken.
        /// </summary>
        public long MagicDamageTaken { get; set; }

        /// <summary>
        /// Gets or sets the number of minions killed.
        /// </summary>
        public long MinionsKilled { get; set; }

        /// <summary>
        /// Gets or sets the number of neutral minions killed.
        /// </summary>
        public long NeutralMinionsKilled { get; set; }

        /// <summary>
        /// Gets or sets the number of neutral jungle minions killed in the enemy team's jungle.
        /// </summary>
        public long NeutralMinionsKilledEnemyJungle { get; set; }

        /// <summary>
        /// Gets or sets nthe number of eutral jungle minions killed in your team's jungle.
        /// </summary>
        public long NeutralMinionsKilledTeamJungle { get; set; }

        /// <summary>
        /// Gets or sets the number of point captures if the game was a dominion game. This value is always 0 for non-dominion games.
        /// </summary>
        public long NodeCapture { get; set; }

        /// <summary>
        /// Gets or sets the number of point capture assists if the game was a dominion game. This value is always 0 for non-dominion games.
        /// </summary>
        public long NodeCaptureAssist { get; set; }

        /// <summary>
        /// Gets or sets the number of point neutralizations if game was a dominion game. This value is always 0 for non-dominion games.
        /// </summary>
        public long NodeNeutralize { get; set; }

        /// <summary>
        /// Gets or sets the number of point neutralization assists if the game was a dominion game. This value is always 0 for non-dominion games.
        /// </summary>
        public long NodeNeutralizeAssist { get; set; }

        /// <summary>
        /// Gets or sets the player's objectives score if the game was a dominion game. This value is always 0 for non-dominion games.
        /// </summary>
        public long ObjectivePlayerScore { get; set; }

        /// <summary>
        /// Gets or sets the number of penta kills.
        /// </summary>
        public long PentaKills { get; set; }

        /// <summary>
        /// Gets or sets the amount of physical damage dealt.
        /// </summary>
        public long PhysicalDamageDealt { get; set; }

        /// <summary>
        /// Gets or sets the amount of physical damage dealt to champions.
        /// </summary>
        public long PhysicalDamageDealtToChampions { get; set; }

        /// <summary>
        /// Gets or sets the amount of physical damage taken.
        /// </summary>
        public long PhysicalDamageTaken { get; set; }

        /// <summary>
        /// Gets or sets the number of quadra kills.
        /// </summary>
        public long QuadraKills { get; set; }

        /// <summary>
        /// Gets or sets the number of sight wards purchased.
        /// </summary>
        public long SightWardsBoughtInGame { get; set; }

        /// <summary>
        /// Gets or sets the number of completed team objectives (i.e., quests) if the game was a dominion game. This value is always 0 for non-dominion games.
        /// </summary>
        public long TeamObjective { get; set; }

        /// <summary>
        /// Gets or sets the total damage dealt.
        /// </summary>
        public long TotalDamageDealt { get; set; }

        /// <summary>
        /// Gets or sets the total damage dealt to champions.
        /// </summary>
        public long TotalDamageDealtToChampions { get; set; }

        /// <summary>
        /// Gets or sets the total damage taken.
        /// </summary>
        public long TotalDamageTaken { get; set; }

        /// <summary>
        /// Gets or sets the total heal amount.
        /// </summary>
        public long TotalHeal { get; set; }

        /// <summary>
        /// Gets or sets the player's total score if the game was a dominion game. This value is always 0 for non-dominion games.
        /// </summary>
        public long TotalPlayerScore { get; set; }

        /// <summary>
        /// Gets or sets the team rank of the player's total score (e.g., 1-5) if the game was a dominion game. This value is always 0 for non-dominion games.
        /// </summary>
        public long TotalScoreRank { get; set; }

        /// <summary>
        /// Gets or sets the total dealt crowd control time.
        /// </summary>
        public long TotalTimeCrowdControlDealt { get; set; }

        /// <summary>
        /// Gets or sets the total units healed.
        /// </summary>
        public long TotalUnitsHealed { get; set; }

        /// <summary>
        /// Gets or sets the number of tower kills.
        /// </summary>
        public long TowerKills { get; set; }

        /// <summary>
        /// Gets or sets the number of triple kills.
        /// </summary>
        public long TripleKills { get; set; }

        /// <summary>
        /// Gets or sets the amount of true damage dealt.
        /// </summary>
        public long TrueDamageDealt { get; set; }

        /// <summary>
        /// Gets or sets the amount of true damage dealt to champions.
        /// </summary>
        public long TrueDamageDealtToChampions { get; set; }

        /// <summary>
        /// Gets or sets the amount of true damage taken.
        /// </summary>
        public long TrueDamageTaken { get; set; }

        /// <summary>
        /// Gets or sets the amount of number of unreal kills (beyond pentakill).
        /// </summary>
        public long UnrealKills { get; set; }

        /// <summary>
        /// Gets or sets the number of vision wards purchased.
        /// </summary>
        public long VisionWardsBoughtInGame { get; set; }

        /// <summary>
        /// Gets or sets the number of wards killed.
        /// </summary>
        public long WardsKilled { get; set; }

        /// <summary>
        /// Gets or sets the number of wards placed.
        /// </summary>
        public long WardsPlaced { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether or not the participant won.
        /// </summary>
        public bool Winner { get; set; }
    }
}
