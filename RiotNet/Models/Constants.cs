using System;
using System.Globalization;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents the ascension event type. Used in <see cref="MatchEvent"/> for type <see cref="EventType.ASCENDED_EVENT"/>.
    /// </summary>
    public static class AscendedType
    {
        /// <summary>
        /// Indicates that a player has become ascended.
        /// </summary>
        public const string CHAMPION_ASCENDED = "CHAMPION_ASCENDED";
        /// <summary>
        /// Inticates that a player has killed the ascended player.
        /// </summary>
        public const string CLEAR_ASCENDED = "CLEAR_ASCENDED";
        /// <summary>
        /// Indicates that a minion has ascended.
        /// </summary>
        public const string MINION_ASCENDED = "MINION_ASCENDED";
    }

    /// <summary>
    /// Represents the building type. Used in <see cref="MatchEvent"/> for type <see cref="EventType.BUILDING_KILL"/>.
    /// </summary>
    public static class BuildingType
    {
        /// <summary>
        /// Inhibitor building
        /// </summary>
        public const string INHIBITOR_BUILDING = "INHIBITOR_BUILDING";
        /// <summary>
        /// Tower building
        /// </summary>
        public const string TOWER_BUILDING = "TOWER_BUILDING";
    }

    /// <summary>
    /// Represents the event type. Used in <see cref="MatchEvent"/>.
    /// </summary>
    public static class EventType
    {
        /// <summary>
        /// Ascended event
        /// </summary>
        public const string ASCENDED_EVENT = "ASCENDED_EVENT";
        /// <summary>
        /// Building kill
        /// </summary>
        public const string BUILDING_KILL = "BUILDING_KILL";
        /// <summary>
        /// Capture point
        /// </summary>
        public const string CAPTURE_POINT = "CAPTURE_POINT";
        /// <summary>
        /// Champion kill
        /// </summary>
        public const string CHAMPION_KILL = "CHAMPION_KILL";
        /// <summary>
        /// Elite monster kill
        /// </summary>
        public const string ELITE_MONSTER_KILL = "ELITE_MONSTER_KILL";
        /// <summary>
        /// Item destroyed. This usually indicates that an item was built into a higher tier item.
        /// </summary>
        public const string ITEM_DESTROYED = "ITEM_DESTROYED";
        /// <summary>
        /// Item purchased
        /// </summary>
        public const string ITEM_PURCHASED = "ITEM_PURCHASED";
        /// <summary>
        /// Item sold
        /// </summary>
        public const string ITEM_SOLD = "ITEM_SOLD";
        /// <summary>
        /// Item undo
        /// </summary>
        public const string ITEM_UNDO = "ITEM_UNDO";
        /// <summary>
        /// Poro king summon
        /// </summary>
        public const string PORO_KING_SUMMON = "PORO_KING_SUMMON";
        /// <summary>
        /// Skill level up
        /// </summary>
        public const string SKILL_LEVEL_UP = "SKILL_LEVEL_UP";
        /// <summary>
        /// Ward kill
        /// </summary>
        public const string WARD_KILL = "WARD_KILL";
        /// <summary>
        /// Ward placed
        /// </summary>
        public const string WARD_PLACED = "WARD_PLACED";
    }

    /// <summary>
    /// Represents the game mode.
    /// </summary>
    public static class GameMode
    {
        /// <summary>
        /// Classic, played on both Summoner's Rift and Twisted Treeline.
        /// </summary>
        public const string CLASSIC = "CLASSIC";
        /// <summary>
        /// Dominion, played on The Crystal Scar.
        /// </summary>
        public const string ODIN = "ODIN";
        /// <summary>
        /// All Random All Mid, played on both Howling Abyss and Butcher's Bridge.
        /// </summary>
        public const string ARAM = "ARAM";
        /// <summary>
        /// Tutorial.
        /// </summary>
        public const string TUTORIAL = "TUTORIAL";
        /// <summary>
        /// Ultra-Rapid-Fire
        /// </summary>
        public const string URF = "URF";
        /// <summary>
        /// Boom Bots
        /// </summary>
        public const string DOOMBOTSTEEMO = "DOOMBOTSTEEMO";
        /// <summary>
        /// One for All, played on both Summoner's Rift and Howling Abyss.
        /// </summary>
        public const string ONEFORALL = "ONEFORALL";
        /// <summary>
        /// Ascension, played on The Crystal Scar.
        /// </summary>
        public const string ASCENSION = "ASCENSION";
        /// <summary>
        /// Snowdown Showdown, played on the Howling Abyss.
        /// </summary>
        public const string FIRSTBLOOD = "FIRSTBLOOD";
        /// <summary>
        /// Legend of the Poro King, played on the Howling Abyss.
        /// </summary>
        public const string KINGPORO = "KINGPORO";
        /// <summary>
        /// Nexus Siege
        /// </summary>
        public const string SIEGE = "SIEGE";
        /// <summary>
        /// Blood Hunt Assassin
        /// </summary>
        public const string ASSASSINATE = "ASSASSINATE";
        /// <summary>
        /// All Random Summoner's Rift
        /// </summary>
        public const string ARSR = "ARSR";
        /// <summary>
        /// Darkstar
        /// </summary>
        public const string DARKSTAR = "DARKSTAR";
        /// <summary>
        /// Star Guardian Invasion
        /// </summary>
        public const string STARGUARDIAN = "STARGUARDIAN";
        /// <summary>
        /// PROJECT: Hunters
        /// </summary>
        public const string PROJECT = "PROJECT";
    }

    /// <summary>
    /// Represents the game type.
    /// </summary>
    public static class GameType
    {
        /// <summary>
        /// Custom game
        /// </summary>
        public const string CUSTOM_GAME = "CUSTOM_GAME";
        /// <summary>
        /// Matched game (any game that is queued up for)
        /// </summary>
        public const string MATCHED_GAME = "MATCHED_GAME";
        /// <summary>
        /// Tutorial
        /// </summary>
        public const string TUTORIAL_GAME = "TUTORIAL_GAME";
    }

    /// <summary>
    /// Represents the lane an event occured. Used in <see cref="MatchEvent"/>.
    /// </summary>
    public static class LaneType
    {
        /// <summary>
        /// Bot lane
        /// </summary>
        public const string BOT_LANE = "BOT_LANE";
        /// <summary>
        /// Mid lane
        /// </summary>
        public const string MID_LANE = "MID_LANE";
        /// <summary>
        /// Top lane
        /// </summary>
        public const string TOP_LANE = "TOP_LANE";
    }

    /// <summary>
    /// Represents the level up type. Used in <see cref="MatchEvent"/> for event type <see cref="EventType.SKILL_LEVEL_UP"/>.
    /// </summary>
    public static class LevelUpType
    {
        /// <summary>
        /// Evolve
        /// </summary>
        public const string EVOLVE = "EVOLVE";
        /// <summary>
        /// Normal
        /// </summary>
        public const string NORMAL = "NORMAL";
    }

    /// <summary>
    /// Locale codes (language codes) for requesting data from the Static Data API.
    /// </summary>
    /// <remarks>
    /// This list contains all supported locales at the time of the RiotNet release.
    /// If you want to iteralte over all currently supported locales, use <see cref="IRiotClient.GetStaticLanguagesAsync(string, System.Threading.CancellationToken)"/>
    /// </remarks>
    public static class Locale
    {
        /// <summary>
        /// Czech (Czech Republic)
        /// </summary>
        public const string cs_CZ = "cs_CZ";
        /// <summary>
        /// German (Germany)
        /// </summary>
        public const string de_DE = "de_DE";
        /// <summary>
        /// Greek (Greece)
        /// </summary>
        public const string el_GR = "el_GR";
        /// <summary>
        /// English (Australia)
        /// </summary>
        public const string en_AU = "en_AU";
        /// <summary>
        /// English (United Kingdom)
        /// </summary>
        public const string en_GB = "en_GB";
        /// <summary>
        /// English (Philippines)
        /// </summary>
        public const string en_PH = "en_PH";
        /// <summary>
        /// English (Singapore)
        /// </summary>
        public const string en_SG = "en_SG";
        /// <summary>
        /// English (United States)
        /// </summary>
        public const string en_US = "en_US";
        /// <summary>
        /// Spanish (Argentina)
        /// </summary>
        public const string es_AR = "es_AR";
        /// <summary>
        /// Spanish (Spain, International Sort)
        /// </summary>
        public const string es_ES = "es_ES";
        /// <summary>
        /// Spanish (Mexico)
        /// </summary>
        public const string es_MX = "es_MX";
        /// <summary>
        /// French (France)
        /// </summary>
        public const string fr_FR = "fr_FR";
        /// <summary>
        /// Hungarian (Hungary)
        /// </summary>
        public const string hu_HU = "hu_HU";
        /// <summary>
        /// Indonesian (Indonesia)
        /// </summary>
        public const string id_ID = "id_ID";
        /// <summary>
        /// Italian (Italy)
        /// </summary>
        public const string it_IT = "it_IT";
        /// <summary>
        /// Japanese (Japan)
        /// </summary>
        public const string ja_JP = "ja_JP";
        /// <summary>
        /// Korean (Korea)
        /// </summary>
        public const string ko_KR = "ko_KR";
        /// <summary>
        /// Malay (Malaysia)
        /// </summary>
        public const string ms_MY = "ms_MY";
        /// <summary>
        /// Polish (Poland)
        /// </summary>
        public const string pl_PL = "pl_PL";
        /// <summary>
        /// Portuguese (Brazil)
        /// </summary>
        public const string pt_BR = "pt_BR";
        /// <summary>
        /// Romanian (Romania)
        /// </summary>
        public const string ro_RO = "ro_RO";
        /// <summary>
        /// Russian (Russia)
        /// </summary>
        public const string ru_RU = "ru_RU";
        /// <summary>
        /// Thai (Thailand)
        /// </summary>
        public const string th_TH = "th_TH";
        /// <summary>
        /// Turkish (Turkey)
        /// </summary>
        public const string tr_TR = "tr_TR";
        /// <summary>
        /// Vietnamese (Vietnam)
        /// </summary>
        public const string vn_VN = "vn_VN";
        /// <summary>
        /// Chinese (Simplified, China)
        /// </summary>
        public const string zh_CN = "zh_CN";
        /// <summary>
        /// Chinese (Malaysia)
        /// </summary>
        public const string zh_MY = "zh_MY";
        /// <summary>
        /// Chinese (Traditional, Taiwan)
        /// </summary>
        public const string zh_TW = "zh_TW";

        /// <summary>
        /// Gets the culture info for a locale.
        /// </summary>
        /// <param name="locale">The locale (or language tag). This should equal one of the <see cref="Locale"/> values, or one of the values returned by <see cref="IRiotClient.GetStaticLanguagesAsync(string, System.Threading.CancellationToken)"/>.</param>
        /// <returns>The culture info.</returns>
        public static CultureInfo GetCultureInfo(string locale)
        {
            if (locale == null)
                throw new ArgumentNullException(nameof(locale));

            // Riot calls vietnamese "vn_VN" but it should be "vi_VN"
            var tag = locale.Replace('_', '-').Replace("vn", "vi");
            return new CultureInfo(tag);
        }
    }

    /// <summary>
    /// Represents a map type for a tournament game.
    /// </summary>
    public static class MapType
    {
        /// <summary>
        /// Summoner's Rift
        /// </summary>
        public const string SUMMONERS_RIFT = "SUMMONERS_RIFT";
        /// <summary>
        /// Twisted Treeline
        /// </summary>
        public const string TWISTED_TREELINE = "TWISTED_TREELINE";
        /// <summary>
        /// Crystal Scar (dominion)
        /// </summary>
        public const string CRYSTAL_SCAR = "CRYSTAL_SCAR";
        /// <summary>
        /// Howling Abyss (ARAM)
        /// </summary>
        public const string HOWLING_ABYSS = "HOWLING_ABYSS";
    }

    /// <summary>
    /// Represents a map ID for a match.
    /// </summary>
    public static class MapId
    {
        /// <summary>
        /// Summoner's Rift (original version - summer)
        /// </summary>
        public const int SUMMONERS_RIFT_V1_SUMMER = 1;
        /// <summary>
        /// Summoner's Rift (original version - autumn)
        /// </summary>
        public const int SUMMONERS_RIFT_V1_AUTUMN = 2;
        /// <summary>
        /// Proving Grounds (tutorial)
        /// </summary>
        public const int PROVING_GROUNDS = 3;
        /// <summary>
        /// Twisted Treeline (original version)
        /// </summary>
        public const int TWISTED_TREELINE_V1 = 4;
        /// <summary>
        /// Crystal Scar (dominion)
        /// </summary>
        public const int CRYSTAL_SCAR = 8;
        /// <summary>
        /// Twisted Treeline (current version)
        /// </summary>
        public const int TWISTED_TREELINE_V2 = 10;
        /// <summary>
        /// Summoner's Rift (current version)
        /// </summary>
        public const int SUMMONERS_RIFT_V2 = 11;
        /// <summary>
        /// Howling Abyss (ARAM)
        /// </summary>
        public const int HOWLING_ABYSS = 12;
        /// <summary>
        /// Butcher's Bridge (ARAM)
        /// </summary>
        public const int BUTCHERS_BRIDGE = 14;
        /// <summary>
        /// Cosmic Ruins (Dark Star: Singularity)
        /// </summary>
        public const int COSMIC_RUINS = 16;
        /// <summary>
        /// Valoran City (Star Guardian Invasion)
        /// </summary>
        public const int VALORAN_CITY = 18;
        /// <summary>
        /// Substructure 43 (PROJECT: Hunters)
        /// </summary>
        public const int SUBSTRUCTURE_43 = 19;
    }

    /// <summary>
    /// Represents a player's role.
    /// </summary>
    public static class MatchRole
    {
        /// <summary>
        /// Duo
        /// </summary>
        public const string DUO = "DUO";
        /// <summary>
        /// None
        /// </summary>
        public const string NONE = "NONE";
        /// <summary>
        /// Solo
        /// </summary>
        public const string SOLO = "SOLO";
        /// <summary>
        /// Duo carry
        /// </summary>
        public const string DUO_CARRY = "DUO_CARRY";
        /// <summary>
        /// Duo support
        /// </summary>
        public const string DUO_SUPPORT = "DUO_SUPPORT";
    }

    /// <summary>
    /// Represents the type of monster that an event applies to. This is only valid for buff monsters and epic monsters.
    /// </summary>
    public static class MonsterType
    {
        /// <summary>
        /// Baron nashor
        /// </summary>
        public const string BARON_NASHOR = "BARON_NASHOR";
        /// <summary>
        /// Blue golem
        /// </summary>
        public const string BLUE_GOLEM = "BLUE_GOLEM";
        /// <summary>
        /// Dragon
        /// </summary>
        public const string DRAGON = "DRAGON";
        /// <summary>
        /// Red lizard
        /// </summary>
        public const string RED_LIZARD = "RED_LIZARD";
        /// <summary>
        /// Rift Herald
        /// </summary>
        public const string RIFTHERALD = "RIFTHERALD";
        /// <summary>
        /// Vilemaw
        /// </summary>
        public const string VILEMAW = "VILEMAW";
    }

    /// <summary>
    /// Represents a monster sub-type in a <see cref="MatchEvent"/>.
    /// </summary>
    public static class MonsterSubType
    {
        /// <summary>
        /// Cloud dragon
        /// </summary>
        public const string AIR_DRAGON = "AIR_DRAGON";
        /// <summary>
        /// Mountain dragon
        /// </summary>
        public const string EARTH_DRAGON = "EARTH_DRAGON";
        /// <summary>
        /// Infernal dragon
        /// </summary>
        public const string FIRE_DRAGON = "FIRE_DRAGON";
        /// <summary>
        /// Ocean dragon
        /// </summary>
        public const string WATER_DRAGON = "WATER_DRAGON";
    }

    /// <summary>
    /// Indicates a type of mastery tree.
    /// </summary>
    public static class MastertyTreeType
    {
        /// <summary>
        /// Specifies the Ferocity mastery tree.
        /// </summary>
        public const string Ferocity = "Ferocity";
        /// <summary>
        /// Specifies the Cunning mastery tree.
        /// </summary>
        public const string Cunning = "Cunning";
        /// <summary>
        /// Specifies the Resolve mastery tree.
        /// </summary>
        public const string Resolve = "Resolve";
    }

    /// <summary>
    /// The method used for picking champions.
    /// </summary>
    public static class PickType
    {
        /// <summary>
        /// Blind pick
        /// </summary>
        public const string BLIND_PICK = "BLIND_PICK";
        /// <summary>
        /// Draft pick
        /// </summary>
        public const string DRAFT_MODE = "DRAFT_MODE";
        /// <summary>
        /// All randowm
        /// </summary>
        public const string ALL_RANDOM = "ALL_RANDOM";
        /// <summary>
        /// Tournament draft pick
        /// </summary>
        public const string TOURNAMENT_DRAFT = "TOURNAMENT_DRAFT";
    }

    /// <summary>
    /// Represents player's position, or lane.
    /// </summary>
    public static class PlayerPosition
    {
        /// <summary>
        /// Top lane
        /// </summary>
        public const string TOP = "TOP";
        /// <summary>
        /// Mid lane (used by <see cref="MatchParticipantTimeline"/> objects)
        /// </summary>
        public const string MIDDLE = "MIDDLE";
        /// <summary>
        /// Mid lane (used by <see cref="MatchReference"/> objects)
        /// </summary>
        public const string MID = "MID";
        /// <summary>
        /// Jungle
        /// </summary>
        public const string JUNGLE = "JUNGLE";
        /// <summary>
        /// Bot lane
        /// </summary>
        public const string BOTTOM = "BOTTOM";

        /// <summary>
        /// Gets whether the specified lane value is MID or MIDDLE.
        /// </summary>
        /// <param name="lane">The lane.</param>
        /// <returns>True if the value is mid lane, otherwise false.</returns>
        public static bool IsMidLane(string lane)
        {
            return lane == MIDDLE || lane == MID;
        }
    }

    /// <summary>
    /// Represents a capturable point in Dominion. Used in <see cref="MatchEvent"/> for event type <see cref="EventType.CAPTURE_POINT"/>.
    /// </summary>
    public static class Point
    {
        /// <summary>
        /// Point a
        /// </summary>
        public const string POINT_A = "POINT_A";
        /// <summary>
        /// Point b
        /// </summary>
        public const string POINT_B = "POINT_B";
        /// <summary>
        /// Point c
        /// </summary>
        public const string POINT_C = "POINT_C";
        /// <summary>
        /// Point d
        /// </summary>
        public const string POINT_D = "POINT_D";
        /// <summary>
        /// Point e
        /// </summary>
        public const string POINT_E = "POINT_E";
    }

    /// <summary>
    /// Represents a ranked queue type.
    /// </summary>
    public static class RankedQueue
    {
        /// <summary>
        /// Ranked Solo 5v5
        /// </summary>
        public const string RANKED_SOLO_5x5 = "RANKED_SOLO_5x5";
        /// <summary>
        /// Ranked Flex Summoner's Rift
        /// </summary>
        public const string RANKED_FLEX_SR = "RANKED_FLEX_SR";
        /// <summary>
        /// Ranked Flex Twisted Treeline.
        /// </summary>
        public const string RANKED_FLEX_TT = "RANKED_FLEX_TT";
    }

    /// <summary>
    /// Represents a platform (or server).
    /// </summary>
    public static class PlatformId
    {
        /// <summary>
        /// Brazil
        /// </summary>
        public const string BR1 = "BR1";
        /// <summary>
        /// Europe Nordic &amp; East
        /// </summary>
        public const string EUN1 = "EUN1";
        /// <summary>
        /// Europe West
        /// </summary>
        public const string EUW1 = "EUW1";
        /// <summary>
        /// Japan
        /// </summary>
        public const string JP1 = "JP1";
        /// <summary>
        /// Korea
        /// </summary>
        public const string KR = "KR";
        /// <summary>
        /// Latin America North
        /// </summary>
        public const string LA1 = "LA1";
        /// <summary>
        /// Latin America South
        /// </summary>
        public const string LA2 = "LA2";
        /// <summary>
        /// North America
        /// </summary>
        public const string NA1 = "NA1";
        /// <summary>
        /// Oceania
        /// </summary>
        public const string OC1 = "OC1";
        /// <summary>
        /// Turkey
        /// </summary>
        public const string TR1 = "TR1";
        /// <summary>
        /// Russia
        /// </summary>
        public const string RU = "RU";
        /// <summary>
        /// Public Beta Environment
        /// </summary>
        public const string PBE1 = "PBE1";

        /// <summary>
        /// The list of all known platform IDs.
        /// </summary>
        public static readonly string[] All = new[] { BR1, EUN1, EUW1, JP1, KR, LA1, LA2, NA1, OC1, TR1, RU, PBE1 };

        /// <summary>
        /// Gets whether the platform ID represents North America. (For old North America accounts, platform ID may equal "NA" instead of "NA1".)
        /// </summary>
        /// <param name="platformId">The platform ID.</param>
        /// <returns>true if the platform ID represents North America; otherwise false.</returns>
        public static bool IsNorthAmerica(string platformId)
        {
            return platformId == NA1 || platformId == "NA";
        }
    }

    /// <summary>
    /// Represents a Regional Proxy service name.
    /// </summary>
    /// <remarks>
    /// Some services are regional, rather than globally deployed, and thus use a regional endpoint for all requests, even if a platform is specified in the request.
    /// </remarks>
    public static class RegionalProxy
    {
        /// <summary>
        /// Americas
        /// </summary>
        public const string Americas = "americas";
        /// <summary>
        /// Europe
        /// </summary>
        public const string Europe = "europe";
        /// <summary>
        /// Asia
        /// </summary>
        public const string Asia = "asia";
    }

    /// <summary>
    /// Represents the status of one of the services on the Riot servers.
    /// </summary>
    public static class ServerStatus
    {
        /// <summary>
        /// Online
        /// </summary>
        public const string Online = "online";
        /// <summary>
        /// Alert
        /// </summary>
        public const string Alert = "alert";
        /// <summary>
        /// Offline
        /// </summary>
        public const string Offline = "offline";
        /// <summary>
        /// Deploying
        /// </summary>
        public const string Deploying = "deploying";
    }

    /// <summary>
    /// Represents the server incident message severity.
    /// </summary>
    public static class Severity
    {
        /// <summary>
        /// Info
        /// </summary>
        public const string Info = "info";
        /// <summary>
        /// Alert
        /// </summary>
        public const string Alert = "alert";
        /// <summary>
        /// Error
        /// </summary>
        public const string Error = "error";
    }

    /// <summary>
    /// The type of spectators allowed for a game.
    /// </summary>
    public static class SpectatorType
    {
        /// <summary>
        /// No spectators are allowed.
        /// </summary>
        public const string NONE = "NONE";
        /// <summary>
        /// Spectators are allowed only if they joined in the lobby.
        /// </summary>
        public const string LOBBYONLY = "LOBBYONLY";
        /// <summary>
        /// Spectators can join at any point (in the lobby or after the game starts).
        /// </summary>
        public const string ALL = "ALL";
    }

    /// <summary>
    /// Represents a ranked tier.
    /// </summary>
    public static class Tier
    {
        /// <summary>
        /// Challenger tier
        /// </summary>
        public const string CHALLENGER = "CHALLENGER";
        /// <summary>
        /// Master tier
        /// </summary>
        public const string MASTER = "MASTER";
        /// <summary>
        /// Diamond tier
        /// </summary>
        public const string DIAMOND = "DIAMOND";
        /// <summary>
        /// Platinum tier
        /// </summary>
        public const string PLATINUM = "PLATINUM";
        /// <summary>
        /// Gold tier
        /// </summary>
        public const string GOLD = "GOLD";
        /// <summary>
        /// Silver tier
        /// </summary>
        public const string SILVER = "SILVER";
        /// <summary>
        /// Bronze tier
        /// </summary>
        public const string BRONZE = "BRONZE";
    }

    /// <summary>
    /// Represents the tower type. Used in <see cref="MatchEvent"/> for event type <see cref="EventType.BUILDING_KILL"/>.
    /// </summary>
    public static class TowerType
    {
        /// <summary>
        /// Inhibitor turret
        /// </summary>
        public const string BASE_TURRET = "BASE_TURRET";
        /// <summary>
        /// Fountain turret
        /// </summary>
        public const string FOUNTAIN_TURRET = "FOUNTAIN_TURRET";
        /// <summary>
        /// Inner turret
        /// </summary>
        public const string INNER_TURRET = "INNER_TURRET";
        /// <summary>
        /// Nexus turret
        /// </summary>
        public const string NEXUS_TURRET = "NEXUS_TURRET";
        /// <summary>
        /// Outer turret
        /// </summary>
        public const string OUTER_TURRET = "OUTER_TURRET";
        /// <summary>
        /// Undefined turret (this represents an inhibitor, not a turret)
        /// </summary>
        public const string UNDEFINED_TURRET = "UNDEFINED_TURRET";
    }

    /// <summary>
    /// Represents the ward type. Used in <see cref="MatchEvent"/> for event types <see cref="EventType.WARD_KILL"/> and <see cref="EventType.WARD_PLACED"/>.
    /// </summary>
    public static class WardType
    {
        /// <summary>
        /// Sight ward
        /// </summary>
        public const string SIGHT_WARD = "SIGHT_WARD";
        /// <summary>
        /// Teemo mushroom
        /// </summary>
        public const string TEEMO_MUSHROOM = "TEEMO_MUSHROOM";
        /// <summary>
        /// Undefined
        /// </summary>
        public const string UNDEFINED = "UNDEFINED";
        /// <summary>
        /// Vision ward
        /// </summary>
        public const string VISION_WARD = "VISION_WARD";
        /// <summary>
        /// Yellow trinket
        /// </summary>
        public const string YELLOW_TRINKET = "YELLOW_TRINKET";
        /// <summary>
        /// Yellow trinket upgrade (probably not used since season 6)
        /// </summary>
        public const string YELLOW_TRINKET_UPGRADE = "YELLOW_TRINKET_UPGRADE";
        /// <summary>
        /// Blue trinket
        /// </summary>
        public const string BLUE_TRINKET = "BLUE_TRINKET";
        /// <summary>
        /// Control ward
        /// </summary>
        public const string CONTROL_WARD = "CONTROL_WARD";
    }
}
