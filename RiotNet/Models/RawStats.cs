using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace RiotNet.Models
{
    /// <summary>
    /// Statistics associated with the game for this summoner.
    /// </summary>
    [ComplexType]
    public class RawStats
    {
        /// <summary>
        /// Gets or sets the number of assists.
        /// </summary>
        public int Assists { get; set; }

        /// <summary>
        /// Gets or sets the number of enemy inhibitors killed.
        /// </summary>
        public int BarracksKilled { get; set; }

        /// <summary>
        /// Gets or sets the number of champions killed.
        /// </summary>
        public int ChampionsKilled { get; set; }

        /// <summary>
        /// Gets or sets the player's combat score (Dominion).
        /// </summary>
        public int CombatPlayerScore { get; set; }

        /// <summary>
        /// (TODO) Don't know, stat does not appear to be used.
        /// </summary>
        public int ConsumablesPurchased { get; set; }

        /// <summary>
        /// (TODO) Don't know, stat does not appear to be used.
        /// </summary>
        public int DamageDealtPlayer { get; set; }

        /// <summary>
        /// Gets or sets number of double kills.
        /// </summary>
        public int DoubleKills { get; set; }

        /// <summary>
        /// (TODO) Not sure how this is used yet. It does not appear to ever be set.
        /// </summary>
        public int FirstBlood { get; set; }

        /// <summary>
        /// (TODO) Don't know, stat does not appear to be used.
        /// </summary>
        public int Gold { get; set; }

        /// <summary>
        /// Gets or sets the amount of gold earned.
        /// </summary>
        public int GoldEarned { get; set; }

        /// <summary>
        /// Gets or sets the amount of gold spend.
        /// </summary>
        public int GoldSpent { get; set; }

        /// <summary>
        /// Gets or sets the ID of item 0.
        /// </summary>
        public int Item0 { get; set; }

        /// <summary>
        /// Gets or sets the ID of item 1.
        /// </summary>
        public int Item1 { get; set; }

        /// <summary>
        /// Gets or sets the ID of item 2.
        /// </summary>
        public int Item2 { get; set; }

        /// <summary>
        /// Gets or sets the ID of item 3.
        /// </summary>
        public int Item3 { get; set; }

        /// <summary>
        /// Gets or sets the ID of item 4.
        /// </summary>
        public int Item4 { get; set; }

        /// <summary>
        /// Gets or sets the ID of item 5.
        /// </summary>
        public int Item5 { get; set; }

        /// <summary>
        /// Gets or sets the ID of item 6.
        /// </summary>
        public int Item6 { get; set; }

        /// <summary>
        /// (TODO) Don't know, stat does not appear to be used.
        /// </summary>
        public int ItemsPurchased { get; set; }

        /// <summary>
        /// Gets or sets the number of killing sprees (number of times player got two (or three?) or more kills without dying).
        /// </summary>
        public int KillingSprees { get; set; }

        /// <summary>
        /// Gets or sets the largest critical strike values.
        /// </summary>
        public int LargestCriticalStrike { get; set; }

        /// <summary>
        /// Gets or sets the largest killing spree.
        /// </summary>
        public int LargestKillingSpree { get; set; }

        /// <summary>
        /// Gets or sets the largest multikill by the player.
        /// </summary>
        public int LargestMultiKill { get; set; }

        /// <summary>
        /// Gets or sets the number of tier 3 items built.
        /// </summary>
        public int LegendaryItemsCreated { get; set; }

        /// <summary>
        /// Gets or sets the player champion level.
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Gets or sets the total amount of magic damage dealt by player.
        /// </summary>
        public int MagicDamageDealtPlayer { get; set; }

        /// <summary>
        /// Gets or sets the amount of magic damage dealt to champions.
        /// </summary>
        public int MagicDamageDealtToChampions { get; set; }

        /// <summary>
        /// Gets or sets amount of magic damage taken.
        /// </summary>
        public int MagicDamageTaken { get; set; }

        /// <summary>
        /// (TODO) Don't know, stat does not appear to be used.
        /// </summary>
        public int MinionsDenied { get; set; }

        /// <summary>
        /// Gets or sets the number of minions killed.
        /// </summary>
        public int MinionsKilled { get; set; }

        /// <summary>
        /// Gets or sets the numner of neutral monsters killed.
        /// </summary>
        public int NeutralMinionsKilled { get; set; }

        /// <summary>
        /// Gets or sets the number of neutral monsters killed in the enemy jungle.
        /// </summary>
        public int NeutralMinionsKilledEnemyJungle { get; set; }

        /// <summary>
        /// Gets or sets the number of neutral monsters killed in your jungle.
        /// </summary>
        public int NeutralMinionsKilledYourJungle { get; set; }

        /// <summary>
        /// Gets or sets flag specifying if the summoner got the killing blow on the nexus.
        /// </summary>
        public bool NexusKilled { get; set; }

        /// <summary>
        /// Gets or sets the number of points captured by player (Dominion).
        /// </summary>
        public int NodeCapture { get; set; }

        /// <summary>
        /// Gets or sets the number of points the player assisted in capturing (Dominion).
        /// </summary>
        public int NodeCaptureAssist { get; set; }

        /// <summary>
        /// Gets or sets the number of points the player neutralized (Dominion).
        /// </summary>
        public int NodeNeutralize { get; set; }

        /// <summary>
        /// Gets or sets the number of points the player assisted in neutralizing (Dominion).
        /// </summary>
        public int NodeNeutralizeAssist { get; set; }

        /// <summary>
        /// Gets or sets number of deaths.
        /// </summary>
        public int NumDeaths { get; set; }

        /// <summary>
        /// (TODO) Don't know, stat does not appear to be used.
        /// </summary>
        public int NumItemsBought { get; set; }

        /// <summary>
        /// Gets or sets the player's objective score (Dominion).
        /// </summary>
        public int ObjectivePlayerScore { get; set; }

        /// <summary>
        /// Gets or sets the number of penta kills.
        /// </summary>
        public int PentaKills { get; set; }

        /// <summary>
        /// Gets or sets total amount of physical damage dealt.
        /// </summary>
        public int PhysicalDamageDealtPlayer { get; set; }

        /// <summary>
        /// Gets or sets amount of physical damage dealt to champions.
        /// </summary>
        public int PhysicalDamageDealtToChampions { get; set; }

        /// <summary>
        /// Gets or sets amount of physical damage taken by player.
        /// </summary>
        public int PhysicalDamageTaken { get; set; }

        /// <summary>
        /// Gets or sets player position.
        /// </summary>
        public PlayerPosition PlayerPosition { get; set; }

        /// <summary>
        /// Gets or sets player role.
        /// </summary>
        public PlayerRole PlayerRole { get; set; }

        /// <summary>
        /// Gets or sets number of quadra kills.
        /// </summary>
        public int QuadraKills { get; set; }

        /// <summary>
        /// Gets or sets the number of sight wards purchased.
        /// </summary>
        public int SightWardsBought { get; set; }

        /// <summary>
        /// Gets or sets the number of times the first champion spell was cast.
        /// </summary>
        public int Spell1Cast { get; set; }

        /// <summary>
        /// Gets or sets the number of times the second champion spell was cast.
        /// </summary>
        public int Spell2Cast { get; set; }

        /// <summary>
        /// Gets or sets the number of times the third champion spell was cast.
        /// </summary>
        public int Spell3Cast { get; set; }

        /// <summary>
        /// Gets or sets the number of times the fourth champion spell was cast.
        /// </summary>
        public int Spell4Cast { get; set; }

        /// <summary>
        /// Gets or sets the number of times summoner spell 1 was cast.
        /// </summary>
        public int SummonSpell1Cast { get; set; }

        /// <summary>
        /// Gets or sets  the number of times summoner spell 2 was cast.
        /// </summary>
        public int SummonSpell2Cast { get; set; }

        /// <summary>
        /// (TODO) Don't know, stat does not appear to be used.
        /// </summary>
        public int SuperMonsterKilled { get; set; }

        /// <summary>
        /// Gets or sets which team player is on.
        /// </summary>
        public TeamSide Team { get; set; }

        /// <summary>
        /// Gets or sets if game was a dominion game, number of completed team objectives (i.e., quests).
        /// </summary>
        public int TeamObjective { get; set; }

        /// <summary>
        /// Gets or sets the length of the game.
        /// </summary>
        public TimeSpan TimePlayed { get; set; }

        /// <summary>
        /// Gets or sets the total amount of damage dealt by player.
        /// </summary>
        public int TotalDamageDealt { get; set; }

        /// <summary>
        /// Gets or sets the total amount of damage dealt to champions.
        /// </summary>
        public int TotalDamageDealtToChampions { get; set; }

        /// <summary>
        /// Gets or sets the total amount of damage taken.
        /// </summary>
        public int TotalDamageTaken { get; set; }

        /// <summary>
        /// Gets or sets the total amount of healing done.
        /// </summary>
        public int TotalHeal { get; set; }

        /// <summary>
        /// Gets or sets the player's total score (Dominion).
        /// </summary>
        public int TotalPlayerScore { get; set; }

        /// <summary>
        /// Gets or sets the player's rank from score (Dominion).
        /// </summary>
        public int TotalScoreRank { get; set; }

        /// <summary>
        /// Gets or sets the total time of dealt crowd control.
        /// </summary>
        public int TotalTimeCrowdControlDealt { get; set; }

        /// <summary>
        /// Gets or sets the total number of units healed in the game.
        /// </summary>
        public int TotalUnitsHealed { get; set; }

        /// <summary>
        /// Gets or sets the number of triple kills.
        /// </summary>
        public int TripleKills { get; set; }

        /// <summary>
        /// Gets or sets the amount of total true damage dealt by the player.
        /// </summary>
        public int TrueDamageDealtPlayer { get; set; }

        /// <summary>
        /// Gets or sets the amount of true damage dealt to champions.
        /// </summary>
        public int TrueDamageDealtToChampions { get; set; }

        /// <summary>
        /// Gets or sets the amount of true damage taken.
        /// </summary>
        public int TrueDamageTaken { get; set; }

        /// <summary>
        /// Gets or sets the number of turrets killed by player.
        /// </summary>
        public int TurretsKilled { get; set; }

        /// <summary>
        /// Gets or sets the number of unreal kills (beyond pentakill, probably).
        /// </summary>
        public int UnrealKills { get; set; }

        /// <summary>
        /// (TODO) Don't know, stat does not appear to be used. Possibly in some special game modes.
        /// </summary>
        public int VictoryPointTotal { get; set; }

        /// <summary>
        /// Gets or sets the number of vision wards bought in the game.
        /// </summary>
        public int VisionWardsBought { get; set; }

        /// <summary>
        /// Gets or sets the number of wards killed.
        /// </summary>
        public int WardKilled { get; set; }

        /// <summary>
        /// Gets or sets the number of wards placed.
        /// </summary>
        public int WardPlaced { get; set; }

        /// <summary>
        /// Gets or sets flag specifying whether or not this game was won.
        /// </summary>
        public bool Win { get; set; }
    }
}
