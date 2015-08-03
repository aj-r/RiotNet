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
        /// Gets or sets the number of assists by the player.
        /// </summary>
        public int Assists { get; set; }

        /// <summary>
        /// Gets or sets the number of enemy inhibitors killed by the player.
        /// </summary>
        public int BarracksKilled { get; set; }

        /// <summary>
        /// Gets or sets the number of champions killed by the player.
        /// </summary>
        public int ChampionsKilled { get; set; }

        /// <summary>
        /// Gets or sets the player's combat score (Dominion).
        /// </summary>
        public int CombatPlayerScore { get; set; }

        /// <summary>
        /// This stat appears to be unused. It may have been used for a special game mode.
        /// </summary>
        public int ConsumablesPurchased { get; set; }

        /// <summary>
        /// This stat appears to be unused. It may have been used for a special game mode.
        /// </summary>
        public int DamageDealtPlayer { get; set; }

        /// <summary>
        /// Gets or sets number of double kills by the player.
        /// </summary>
        public int DoubleKills { get; set; }

        /// <summary>
        /// This appears to be unused. It may have been used for Snowdown Showdown games.
        /// </summary>
        public int FirstBlood { get; set; }

        /// <summary>
        /// This stat appears to be unused. It may have been used for a special game mode.
        /// </summary>
        public int Gold { get; set; }

        /// <summary>
        /// Gets or sets the amount of gold earned by the player.
        /// </summary>
        public int GoldEarned { get; set; }

        /// <summary>
        /// Gets or sets the amount of gold spent by the player.
        /// </summary>
        public int GoldSpent { get; set; }

        /// <summary>
        /// Gets or sets the ID of the item in slot 0. This corresponds to a <see cref="StaticItem"/> ID.
        /// </summary>
        public int Item0 { get; set; }

        /// <summary>
        /// Gets or sets the ID of the item in slot 1. This corresponds to a <see cref="StaticItem"/> ID.
        /// </summary>
        public int Item1 { get; set; }

        /// <summary>
        /// Gets or sets the ID of the item in slot 2. This corresponds to a <see cref="StaticItem"/> ID.
        /// </summary>
        public int Item2 { get; set; }

        /// <summary>
        /// Gets or sets the ID of the item in slot 3. This corresponds to a <see cref="StaticItem"/> ID.
        /// </summary>
        public int Item3 { get; set; }

        /// <summary>
        /// Gets or sets the ID of the item in slot 4. This corresponds to a <see cref="StaticItem"/> ID.
        /// </summary>
        public int Item4 { get; set; }

        /// <summary>
        /// Gets or sets the ID of the item in slot 5. This corresponds to a <see cref="StaticItem"/> ID.
        /// </summary>
        public int Item5 { get; set; }

        /// <summary>
        /// Gets or sets the ID of the item in slot 6. This corresponds to a <see cref="StaticItem"/> ID.
        /// </summary>
        public int Item6 { get; set; }

        /// <summary>
        /// This stat appears to be unused. It may have been used for a special game mode.
        /// </summary>
        public int ItemsPurchased { get; set; }

        /// <summary>
        /// Gets or sets the number of killing sprees (number of times the player got three or more kills without dying).
        /// </summary>
        public int KillingSprees { get; set; }

        /// <summary>
        /// Gets or sets the amount of damage dealt by the player's most damaging critical strike.
        /// </summary>
        public int LargestCriticalStrike { get; set; }

        /// <summary>
        /// Gets or sets the player's largest killing spree.
        /// </summary>
        public int LargestKillingSpree { get; set; }

        /// <summary>
        /// Gets or sets the largest multikill by the player.
        /// </summary>
        public int LargestMultiKill { get; set; }

        /// <summary>
        /// Gets or sets the number of tier 3 items built by the player.
        /// </summary>
        public int LegendaryItemsCreated { get; set; }

        /// <summary>
        /// Gets or sets the player's champion level at the end of the game.
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Gets or sets the total amount of magic damage dealt by player.
        /// </summary>
        public int MagicDamageDealtPlayer { get; set; }

        /// <summary>
        /// Gets or sets the amount of magic damage dealt to champions by the player.
        /// </summary>
        public int MagicDamageDealtToChampions { get; set; }

        /// <summary>
        /// Gets or sets amount of magic damage takenby the player.
        /// </summary>
        public int MagicDamageTaken { get; set; }

        /// <summary>
        /// This stat appears to be unused. It may have been used for a special game mode.
        /// </summary>
        public int MinionsDenied { get; set; }

        /// <summary>
        /// Gets or sets the number of minions killed by the player.
        /// </summary>
        public int MinionsKilled { get; set; }

        /// <summary>
        /// Gets or sets the number of neutral monsters killed by the player.
        /// </summary>
        public int NeutralMinionsKilled { get; set; }

        /// <summary>
        /// Gets or sets the number of neutral monsters killed by the player in the enemy jungle.
        /// </summary>
        public int NeutralMinionsKilledEnemyJungle { get; set; }

        /// <summary>
        /// Gets or sets the number of neutral monsters killed by the player in their jungle.
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
        /// Gets or sets number of deaths by the player.
        /// </summary>
        public int NumDeaths { get; set; }

        /// <summary>
        /// This stat appears to be unused. It may have been used for a special game mode.
        /// </summary>
        public int NumItemsBought { get; set; }

        /// <summary>
        /// Gets or sets the player's objective score (Dominion).
        /// </summary>
        public int ObjectivePlayerScore { get; set; }

        /// <summary>
        /// Gets or sets the number of penta kills by the player.
        /// </summary>
        public int PentaKills { get; set; }

        /// <summary>
        /// Gets or sets total amount of physical damage dealt by the player.
        /// </summary>
        public int PhysicalDamageDealtPlayer { get; set; }

        /// <summary>
        /// Gets or sets amount of physical damage dealt to champions by the player.
        /// </summary>
        public int PhysicalDamageDealtToChampions { get; set; }

        /// <summary>
        /// Gets or sets amount of physical damage taken by player.
        /// </summary>
        public int PhysicalDamageTaken { get; set; }

        /// <summary>
        /// Gets or sets player's position (lane or jungle).
        /// </summary>
        public PlayerPosition? PlayerPosition { get; set; }

        /// <summary>
        /// Gets or sets player role.
        /// </summary>
        public PlayerRole? PlayerRole { get; set; }

        /// <summary>
        /// Gets or sets number of quadra kills by the player.
        /// </summary>
        public int QuadraKills { get; set; }

        /// <summary>
        /// Gets or sets the number of sight wards purchased by the player.
        /// </summary>
        public int SightWardsBought { get; set; }

        /// <summary>
        /// Gets or sets the number of times the player cast the first champion spell.
        /// </summary>
        public int Spell1Cast { get; set; }

        /// <summary>
        /// Gets or sets the number of times the player cast the second champion spell.
        /// </summary>
        public int Spell2Cast { get; set; }

        /// <summary>
        /// Gets or sets the number of times the player cast the third champion spell.
        /// </summary>
        public int Spell3Cast { get; set; }

        /// <summary>
        /// Gets or sets the number of times the player cast the fourth champion spell.
        /// </summary>
        public int Spell4Cast { get; set; }

        /// <summary>
        /// Gets or sets the number of times the player cast the first summoner spell.
        /// </summary>
        public int SummonSpell1Cast { get; set; }

        /// <summary>
        /// Gets or sets  the number of times the player cast the second summoner spell 2.
        /// </summary>
        public int SummonSpell2Cast { get; set; }

        /// <summary>
        /// This stat appears to be unused. It may have been used for a special game mode.
        /// </summary>
        public int SuperMonsterKilled { get; set; }

        /// <summary>
        /// Gets or sets which team player is on.
        /// </summary>
        public TeamSide Team { get; set; }

        /// <summary>
        /// Gets or sets the number of completed team objectives (Dominion).
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
        /// Gets or sets the total amount of damage dealt to champions by the player.
        /// </summary>
        public int TotalDamageDealtToChampions { get; set; }

        /// <summary>
        /// Gets or sets the total amount of damage taken by the player.
        /// </summary>
        public int TotalDamageTaken { get; set; }

        /// <summary>
        /// Gets or sets the total amount of healing done by the player.
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
        /// Gets or sets the total crowd control time dealt by the player.
        /// </summary>
        public int TotalTimeCrowdControlDealt { get; set; }

        /// <summary>
        /// Gets or sets the total number of units healed in the game by the player.
        /// </summary>
        public int TotalUnitsHealed { get; set; }

        /// <summary>
        /// Gets or sets the number of triple kills by the player.
        /// </summary>
        public int TripleKills { get; set; }

        /// <summary>
        /// Gets or sets the amount of total true damage dealt by the player.
        /// </summary>
        public int TrueDamageDealtPlayer { get; set; }

        /// <summary>
        /// Gets or sets the amount of true damage dealt to champions by the player.
        /// </summary>
        public int TrueDamageDealtToChampions { get; set; }

        /// <summary>
        /// Gets or sets the amount of true damage taken by the player.
        /// </summary>
        public int TrueDamageTaken { get; set; }

        /// <summary>
        /// Gets or sets the number of turrets killed by the player.
        /// </summary>
        public int TurretsKilled { get; set; }

        /// <summary>
        /// Gets or sets the number of unreal kills by the player. An "unreal" kill is bigger than a pentakill (so 6 or more kills).
        /// </summary>
        public int UnrealKills { get; set; }

        /// <summary>
        /// This stat appears to be unused. It may have been used for a special game mode.
        /// </summary>
        public int VictoryPointTotal { get; set; }

        /// <summary>
        /// Gets or sets the number of vision wards bought by the player.
        /// </summary>
        public int VisionWardsBought { get; set; }

        /// <summary>
        /// Gets or sets the number of wards killed by the player.
        /// </summary>
        public int WardKilled { get; set; }

        /// <summary>
        /// Gets or sets the number of wards placed by the player.
        /// </summary>
        public int WardPlaced { get; set; }

        /// <summary>
        /// Gets or sets flag specifying whether or not the player won the game.
        /// </summary>
        public bool Win { get; set; }
    }
}
