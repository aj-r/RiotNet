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
        public int AltarsCaptured { get; set; }

        /// <summary>
        /// Gets or sets the number of alters neutralized.
        /// </summary>
        public int AltarsNeutralized { get; set; }

        /// <summary>
        /// Gets or sets the number of assists.
        /// </summary>
        public int Assists { get; set; }

        /// <summary>
        /// Gets or sets the champion level at the end of the game.
        /// </summary>
        public int ChampLevel { get; set; }

        /// <summary>
        /// Gets or sets the player's combat score if the game was a dominion game. This value is always 0 for non-dominion games.
        /// </summary>
        public int CombatPlayerScore { get; set; }

        /// <summary>
        /// Gets or sets the amount of damage dealt to objectives.
        /// </summary>
        public long DamageDealtToObjectives { get; set; }

        /// <summary>
        /// Gets or sets the amount of damage dealt to turrets.
        /// </summary>
        public long DamageDealtToTurrets { get; set; }

        /// <summary>
        /// Gets or sets the amount of self-mitigated damage.
        /// </summary>
        public long DamageSelfMitigated { get; set; }

        /// <summary>
        /// Gets or sets the number of deaths.
        /// </summary>
        public int Deaths { get; set; }

        /// <summary>
        /// Gets or sets the number of double kills.
        /// </summary>
        public int DoubleKills { get; set; }

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
        public int GoldSpent { get; set; }

        /// <summary>
        /// Gets or sets the number of inhibitor kills.
        /// </summary>
        public int InhibitorKills { get; set; }

        /// <summary>
        /// Gets or sets the ID of the item in slot 0 at the end of the game.
        /// </summary>
        public int Item0 { get; set; }

        /// <summary>
        /// Gets or sets the ID of the item in slot 1 at the end of the game.
        /// </summary>
        public int Item1 { get; set; }

        /// <summary>
        /// Gets or sets the ID of the item in slot 2 at the end of the game.
        /// </summary>
        public int Item2 { get; set; }

        /// <summary>
        /// Gets or sets the ID of the item in slot 3 at the end of the game.
        /// </summary>
        public int Item3 { get; set; }

        /// <summary>
        /// Gets or sets the ID of the item in slot 4 at the end of the game.
        /// </summary>
        public int Item4 { get; set; }

        /// <summary>
        /// Gets or sets the ID of the item in slot 5 at the end of the game.
        /// </summary>
        public int Item5 { get; set; }

        /// <summary>
        /// Gets or sets the ID of the item in slot 6 at the end of the game.
        /// </summary>
        public int Item6 { get; set; }

        /// <summary>
        /// Gets or sets the number of killing sprees.
        /// </summary>
        public int KillingSprees { get; set; }

        /// <summary>
        /// Gets or sets the number of kills.
        /// </summary>
        public int Kills { get; set; }

        /// <summary>
        /// Gets or sets the largest critical strike.
        /// </summary>
        public int LargestCriticalStrike { get; set; }

        /// <summary>
        /// Gets or sets the largest killing spree.
        /// </summary>
        public int LargestKillingSpree { get; set; }

        /// <summary>
        /// Gets or sets the largest multi kill.
        /// </summary>
        public int LargestMultiKill { get; set; }

        /// <summary>
        /// Gets or sets the longest amount of time spent living.
        /// </summary>
        public int LongestTimeSpentLiving { get; set; }

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
        public long MagicalDamageTaken { get; set; }

        /// <summary>
        /// Gets or sets the number of minions killed.
        /// </summary>
        public int TotalMinionsKilled { get; set; }

        /// <summary>
        /// Gets or sets the number of neutral minions killed.
        /// </summary>
        public int NeutralMinionsKilled { get; set; }

        /// <summary>
        /// Gets or sets the number of neutral jungle minions killed in the enemy team's jungle.
        /// </summary>
        public int NeutralMinionsKilledEnemyJungle { get; set; }

        /// <summary>
        /// Gets or sets nthe number of eutral jungle minions killed in your team's jungle.
        /// </summary>
        public int NeutralMinionsKilledTeamJungle { get; set; }

        /// <summary>
        /// Gets or sets the number of point captures if the game was a dominion game. This value is always 0 for non-dominion games.
        /// </summary>
        public int NodeCapture { get; set; }

        /// <summary>
        /// Gets or sets the number of point capture assists if the game was a dominion game. This value is always 0 for non-dominion games.
        /// </summary>
        public int NodeCaptureAssist { get; set; }

        /// <summary>
        /// Gets or sets the number of point neutralizations if game was a dominion game. This value is always 0 for non-dominion games.
        /// </summary>
        public int NodeNeutralize { get; set; }

        /// <summary>
        /// Gets or sets the number of point neutralization assists if the game was a dominion game. This value is always 0 for non-dominion games.
        /// </summary>
        public int NodeNeutralizeAssist { get; set; }

        /// <summary>
        /// Gets or sets the player's objectives score if the game was a dominion game. This value is always 0 for non-dominion games.
        /// </summary>
        public int ObjectivePlayerScore { get; set; }

        /// <summary>
        /// Gets or sets the participant ID.
        /// </summary>
        public int ParticipantId { get; set; }

        /// <summary>
        /// Gets or sets the number of penta kills.
        /// </summary>
        public int PentaKills { get; set; }

        /// <summary>
        /// Gets or sets the primary rune style used.
        /// </summary>
        public long PerkPrimaryStyle { get; set; }

        /// <summary>
        /// Gets or sets the secondary rune style used.
        /// </summary>
        public long PerkSubStyle { get; set; }

        /// <summary>
        /// Gets or sets the perk 0 ID.
        /// </summary>
        public long Perk0 { get; set; }

        /// <summary>
        /// Gets or sets the perk 0 var 1 value.
        /// </summary>
        public long Perk0Var1 { get; set; }

        /// <summary>
        /// Gets or sets the perk 0 var 2 value.
        /// </summary>
        public long Perk0Var2 { get; set; }

        /// <summary>
        /// Gets or sets the perk 0 var 3 value.
        /// </summary>
        public long Perk0Var3 { get; set; }

        /// <summary>
        /// Gets or sets the perk 1 ID.
        /// </summary>
        public long Perk1 { get; set; }

        /// <summary>
        /// Gets or sets the perk 1 var 1 value.
        /// </summary>
        public long Perk1Var1 { get; set; }

        /// <summary>
        /// Gets or sets the perk 1 var 2 value.
        /// </summary>
        public long Perk1Var2 { get; set; }

        /// <summary>
        /// Gets or sets the perk 1 var 3 value.
        /// </summary>
        public long Perk1Var3 { get; set; }

        /// <summary>
        /// Gets or sets the perk 2 ID.
        /// </summary>
        public long Perk2 { get; set; }

        /// <summary>
        /// Gets or sets the perk 2 var 1 value.
        /// </summary>
        public long Perk2Var1 { get; set; }

        /// <summary>
        /// Gets or sets the perk 2 var 2 value.
        /// </summary>
        public long Perk2Var2 { get; set; }

        /// <summary>
        /// Gets or sets the perk 2 var 3 value.
        /// </summary>
        public long Perk2Var3 { get; set; }

        /// <summary>
        /// Gets or sets the perk 3 ID.
        /// </summary>
        public long Perk3 { get; set; }

        /// <summary>
        /// Gets or sets the perk 3 var 1 value.
        /// </summary>
        public long Perk3Var1 { get; set; }

        /// <summary>
        /// Gets or sets the perk 3 var 2 value.
        /// </summary>
        public long Perk3Var2 { get; set; }

        /// <summary>
        /// Gets or sets the perk 3 var 3 value.
        /// </summary>
        public long Perk3Var3 { get; set; }

        /// <summary>
        /// Gets or sets the perk 4 ID.
        /// </summary>
        public long Perk4 { get; set; }

        /// <summary>
        /// Gets or sets the perk 4 var 1 value.
        /// </summary>
        public long Perk4Var1 { get; set; }

        /// <summary>
        /// Gets or sets the perk 4 var 2 value.
        /// </summary>
        public long Perk4Var2 { get; set; }

        /// <summary>
        /// Gets or sets the perk 4 var 3 value.
        /// </summary>
        public long Perk4Var3 { get; set; }

        /// <summary>
        /// Gets or sets the perk 5 ID.
        /// </summary>
        public long Perk5 { get; set; }

        /// <summary>
        /// Gets or sets the perk 5 var 1 value.
        /// </summary>
        public long Perk5Var1 { get; set; }

        /// <summary>
        /// Gets or sets the perk 5 var 2 value.
        /// </summary>
        public long Perk5Var2 { get; set; }

        /// <summary>
        /// Gets or sets the perk 5 var 3 value.
        /// </summary>
        public long Perk5Var3 { get; set; }

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
        public int QuadraKills { get; set; }

        /// <summary>
        /// Gets or sets the number of sight wards purchased.
        /// </summary>
        public int SightWardsBoughtInGame { get; set; }

        /// <summary>
        /// Gets or sets the number of completed team objectives (i.e., quests) if the game was a dominion game. This value is always 0 for non-dominion games.
        /// </summary>
        public int TeamObjective { get; set; }

        /// <summary>
        /// Gets or sets the time crowd controlling others.
        /// </summary>
        public long TimeCCingOthers { get; set; }

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
        public int TotalPlayerScore { get; set; }

        /// <summary>
        /// Gets or sets the team rank of the player's total score (e.g., 1-5) if the game was a dominion game. This value is always 0 for non-dominion games.
        /// </summary>
        public int TotalScoreRank { get; set; }

        /// <summary>
        /// Gets or sets the total dealt crowd control time.
        /// </summary>
        public int TotalTimeCrowdControlDealt { get; set; }

        /// <summary>
        /// Gets or sets the total units healed.
        /// </summary>
        public long TotalUnitsHealed { get; set; }

        /// <summary>
        /// Gets or sets the number of tower kills.
        /// </summary>
        public int TowerKills { get; set; }

        /// <summary>
        /// Gets or sets the number of triple kills.
        /// </summary>
        public int TripleKills { get; set; }

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
        public int TrueDamageTaken { get; set; }
        
        /// <summary>
        /// Gets or sets the number of turret kills.
        /// </summary>
        public int TurretKills { get; set; }

        /// <summary>
        /// Gets or sets the amount of number of unreal kills (beyond pentakill).
        /// </summary>
        public int UnrealKills { get; set; }

        /// <summary>
        /// Gets or sets the participant's vision score.
        /// </summary>
        public long VisionScore { get; set; }

        /// <summary>
        /// Gets or sets the number of vision wards purchased.
        /// </summary>
        public int VisionWardsBoughtInGame { get; set; }

        /// <summary>
        /// Gets or sets the number of wards killed.
        /// </summary>
        public int WardsKilled { get; set; }

        /// <summary>
        /// Gets or sets the number of wards placed.
        /// </summary>
        public int WardsPlaced { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether or not the participant won.
        /// </summary>
        public bool Win { get; set; }
    }
}
