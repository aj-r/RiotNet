using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RiotNet.Models;

namespace RiotNet
{
    /// <summary>
    /// A client that interacts with the Riot Games API.
    /// </summary>
    public interface IRiotClient
    {
        #region General Members (not related to a specific API)

        /// <summary>
        /// Occurs when the client executes a request when the API rate limit has been exceeded.
        /// </summary>
        event RetryEventHandler RateLimitExceeded;

        /// <summary>
        /// Occurs when the a request times out.
        /// </summary>
        event RetryEventHandler RequestTimedOut;

        /// <summary>
        /// Occurs when the client fails to connect to the server while executing a request.
        /// </summary>
        event RetryEventHandler ConnectionFailed;

        /// <summary>
        /// Occurs when a request fails because a resource was not found.
        /// </summary>
        event ResponseEventHandler ResourceNotFound;

        /// <summary>
        /// Gets the region that the current <see cref="IRiotClient"/> connects to.
        /// </summary>
        Region Region { get; }

        /// <summary>
        /// Gets the platform ID of the current region.
        /// </summary>
        string PlatformId { get; }

        /// <summary>
        /// Gets the settings for the current <see cref="IRiotClient"/>.
        /// </summary>
        RiotClientSettings Settings { get; }

        #endregion

        #region Champion API

        /// <summary>
        /// Gets the currently supported version of the Champion API that the client communicates with.
        /// </summary>
        string ChampionApiVersion { get; }

        /// <summary>
        /// Gets all champion information (bot enabled, free to play, etc. Also see static champion data).
        /// </summary>
        /// <param name="freeToPlay">True if only requesting free to play champion information. Default is false.</param>
        /// <returns>List of champion information.</returns>
        List<Champion> GetChampions(Boolean freeToPlay = false);

        /// <summary>
        /// Gets all champion information (bot enabled, free to play, etc. Also see static champion data).
        /// </summary>
        /// <param name="freeToPlay">True if only requesting free to play champion information. Default is false.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<List<Champion>> GetChampionsTaskAsync(Boolean freeToPlay = false);

        /// <summary>
        /// Gets chosen champion information (bot enabled, free to play, etc. Also see static champion data).
        /// </summary>
        /// <param name="id">Champion id.</param>
        /// <returns>Champion information.</returns>
        Champion GetChampionById(long id);

        /// <summary>
        /// Gets chosen champion information (bot enabled, free to play, etc. Also see static champion data).
        /// </summary>
        /// <param name="id">Champion id.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Champion> GetChampionByIdTaskAsync(long id);

        #endregion

        #region Current Game API

        /// <summary>
        /// Gets the currently supported version of the Current Game API that the client communicates with.
        /// </summary>
        string CurrentGameApiVersion { get; }

        /// <summary>
        /// Gets information about the current game a summoner is playing.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner ID.</param>
        /// <returns>The current game information.</returns>
        CurrentGameInfo GetCurrentGameBySummonerId(long summonerId);

        /// <summary>
        /// Gets information about the current game a summoner is playing.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner ID.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<CurrentGameInfo> GetCurrentGameBySummonerIdTaskAsync(long summonerId);

        #endregion

        #region Featured Game API

        /// <summary>
        /// Gets the currently supported version of the Featured Game API that the client communicates with.
        /// </summary>
        string FeaturedGameApiVersion { get; }

        /// <summary>
        /// Gets the games currently featured in the League of Legends client.
        /// </summary>
        /// <returns>The featured games.</returns>
        FeaturedGames GetFeaturedGames();

        /// <summary>
        /// Gets the games currently featured in the League of Legends client.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<FeaturedGames> GetFeaturedGamesTaskAsync();

        #endregion

        #region Game API

        /// <summary>
        /// Gets the currently supported version of the Game API that the client communicates with.
        /// </summary>
        string GameApiVersion { get; }

        /// <summary>
        /// Gets the recent games for a summoner.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner ID.</param>
        /// <returns>The summoner's recent games.</returns>
        RecentGames GetGamesBySummonerId(long summonerId);

        /// <summary>
        /// Gets the recent games for a summoner.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner ID.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<RecentGames> GetGamesBySummonerIdTaskAsync(long summonerId);

        #endregion

        #region League API

        /// <summary>
        /// Gets the currently supported version of the League API that the client communicates with.
        /// </summary>
        string LeagueApiVersion { get; }

        /// <summary>
        /// Gets the full league information for all leagues that the summoners are in, including the leages for the teams they are on. Data is mapped by summoner ID.
        /// </summary>
        /// <param name="summonerIds">The summoners' summoner IDs.</param>
        /// <returns>The mapping from summoner IDs to the collection of leagues.</returns>
        Dictionary<String, List<League>> GetLeaguesBySummonerIds(params long[] summonerIds);

        /// <summary>
        /// Gets the full league information for all leagues that the summoners are in, including the leages for the teams they are on. Data is mapped by summoner ID.
        /// </summary>
        /// <param name="summonerIds">The summoners' summoner IDs.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Dictionary<String, List<League>>> GetLeaguesBySummonerIdsTaskAsync(params long[] summonerIds);

        /// <summary>
        /// Gets the full league information for all leagues that the summoners are in, including the leages for the teams they are on. Only includes the league entry for the specified summoner(s). Data is mapped by summoner ID.
        /// </summary>
        /// <param name="summonerIds">The summoners' summoner IDs.</param>
        /// <returns>The mapping from summoner IDs to the collection of league entries for the summoner.</returns>
        Dictionary<String, List<League>> GetLeagueEntriesBySummonerIds(params long[] summonerIds);

        /// <summary>
        /// Gets the full league information for all leagues that the summoners are in, including the leages for the teams they are on. Only includes the league entry for the specified summoner(s). Data is mapped by summoner ID.
        /// </summary>
        /// <param name="summonerIds">The summoners' summoner IDs.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Dictionary<String, List<League>>> GetLeagueEntriesBySummonerIdsTaskAsync(params long[] summonerIds);

        /// <summary>
        /// Gets the full league information for all leagues that the teams are in. Data is mapped by team ID.
        /// </summary>
        /// <param name="teamIds">The teams' team IDs.</param>
        /// <returns>The mapping from team IDs to the collection of leagues.</returns>
        Dictionary<String, List<League>> GetLeaguesByTeamIds(params string[] teamIds);

        /// <summary>
        /// Gets the full league information for all leagues that the teams are in. Data is mapped by team ID.
        /// </summary>
        /// <param name="teamIds">The teams' team IDs.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Dictionary<String, List<League>>> GetLeaguesByTeamIdsTaskAsync(params string[] teamIds);

        /// <summary>
        /// Gets the league information for all leagues that the teams are in. Only includes the league entry for the specified team(s). Data is mapped by team ID.
        /// </summary>
        /// <param name="teamIds">The teams' team IDs.</param>
        /// <returns>The mapping from team IDs to the collection of league entries for the team.</returns>
        Dictionary<String, List<League>> GetLeagueEntriesByTeamIds(params string[] teamIds);

        /// <summary>
        /// Gets the league information for all leagues that the teams are in. Only includes the league entry for the specified team(s). Data is mapped by team ID.
        /// </summary>
        /// <param name="teamIds">The teams' team IDs.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Dictionary<String, List<League>>> GetLeagueEntriesByTeamIdsTaskAsync(params string[] teamIds);

        /// <summary>
        /// Gets the challenger league.
        /// </summary>
        /// <param name="type">The queue type.</param>
        /// <returns>The challenger league.</returns>
        League GetChallengerLeague(RankedQueue type);

        /// <summary>
        /// Gets the challenger league.
        /// </summary>
        /// <param name="type">The queue type.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<League> GetChallengerLeagueTaskAsync(RankedQueue type);

        /// <summary>
        /// Gets the master league.
        /// </summary>
        /// <param name="type">The queue type.</param>
        /// <returns>The master league.</returns>
        League GetMasterLeague(RankedQueue type);

        /// <summary>
        /// Gets the master league.
        /// </summary>
        /// <param name="type">The queue type.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<League> GetMasterLeagueTaskAsync(RankedQueue type);

        #endregion

        #region LoL Static Data API

        /// <summary>
        /// Gets the currently supported version of the LoL Static Data API that the client communicates with.
        /// </summary>
        string LolStaticDataApiVersion { get; }

        /// <summary>
        /// Gets the details for all champions from the static data API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="dataById">If true, the returned data map will use the champions' IDs as the keys. If false, the returned data map will use the champions' keys instead.</param>
        /// <param name="champListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticChampion"/> or <see cref="StaticChampionList"/> objects. Only type, version, data, id, name, key, and title are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A <see cref="StaticChampionList"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        StaticChampionList GetStaticChampions(string locale = null, string version = null, bool dataById = false, IEnumerable<string> champListData = null);

        /// <summary>
        /// Gets the details for all champions from the static data API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="dataById">If true, the returned data map will use the champions' IDs as the keys. If false, the returned data map will use the champions' keys instead.</param>
        /// <param name="champListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticChampion"/> or <see cref="StaticChampionList"/> objects. Only type, version, data, id, name, key, and title are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticChampionList> GetStaticChampionsTaskAsync(string locale = null, string version = null, bool dataById = false, IEnumerable<string> champListData = null);

        /// <summary>
        /// Gets champion details by ID from the static data API.
        /// </summary>
        /// <param name="id">The champion ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetStaticVersions"/>.</param>
        /// <param name="champData">Tags to return additional data. Valid tags are any property of the <see cref="StaticChampion"/> object. Only id, name, key, and title are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A <see cref="StaticChampion"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        StaticChampion GetStaticChampionById(int id, string locale = null, string version = null, IEnumerable<string> champData = null);

        /// <summary>
        /// Gets champion details by ID from the static data API.
        /// </summary>
        /// <param name="id">The champion ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="champData">Tags to return additional data. Valid tags are any property of the <see cref="StaticChampion"/> object. Only id, name, key, and title are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticChampion> GetStaticChampionByIdTaskAsync(int id, string locale = null, string version = null, IEnumerable<string> champData = null);

        /// <summary>
        /// Gets a list of all available items from the static data API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetStaticVersions"/>.</param>
        /// <param name="itemListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticItem"/> or <see cref="StaticItemList"/> objects. Only id, name, type, version, basic, data, plaintext, group, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A <see cref="StaticItemList"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        StaticItemList GetStaticItems(string locale = null, string version = null, IEnumerable<string> itemListData = null);

        /// <summary>
        /// Gets a list of all available items from the static data API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="itemListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticItem"/> or <see cref="StaticItemList"/> objects. Only id, name, type, version, basic, data, plaintext, group, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticItemList> GetStaticItemsTaskAsync(string locale = null, string version = null, IEnumerable<string> itemListData = null);

        /// <summary>
        /// Gets an item by ID from the static data API.
        /// </summary>
        /// <param name="id">The rune ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetStaticVersions"/>.</param>
        /// <param name="itemData">Tags to return additional data. Valid tags are any property of the <see cref="StaticItem"/> object. Only id, name, runeMetaData, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A <see cref="StaticItem"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        StaticItem GetStaticItemById(int id, string locale = null, string version = null, IEnumerable<string> itemData = null);

        /// <summary>
        /// Gets an item by ID from the static data API.
        /// </summary>
        /// <param name="id">The rune ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="itemData">Tags to return additional data. Valid tags are any property of the <see cref="StaticItem"/> object. Only id, name, runeMetaData, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticItem> GetStaticItemByIdTaskAsync(int id, string locale = null, string version = null, IEnumerable<string> itemData = null);

        /// <summary>
        /// Gets a list of available languages from the static data API.
        /// </summary>
        /// <returns>A list of strings that represent a language.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        List<string> GetStaticLanguages();

        /// <summary>
        /// Gets a list of available languages from the static data API.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<List<string>> GetStaticLanguagesTaskAsync();

        /// <summary>
        /// Gets a list of available language strings from the static data API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetStaticVersions"/>.</param>
        /// <returns>A <see cref="StaticLanuageStrings"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        StaticLanuageStrings GetStaticLanguageStrings(string locale = null, string version = null);

        /// <summary>
        /// Gets a list of available language strings from the static data API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticLanuageStrings> GetStaticLanguageStringsTaskAsync(string locale = null, string version = null);

        /// <summary>
        /// Gets a list of all maps from the static data API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetStaticVersions"/>.</param>
        /// <returns>A <see cref="StaticMapList"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        StaticMapList GetStaticMaps(string locale = null, string version = null);

        /// <summary>
        /// Gets a list of all maps from the static data API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticMapList> GetStaticMapsTaskAsync(string locale = null, string version = null);

        /// <summary>
        /// Gets the details for all masteries from the static data API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="masteryListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticMastery"/> or <see cref="StaticMasteryList"/> objects. Only type, version, data, id, name, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A <see cref="StaticMasteryList"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        StaticMasteryList GetStaticMasteries(string locale = null, string version = null, IEnumerable<string> masteryListData = null);

        /// <summary>
        /// Gets the details for all masteries from the static data API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="masteryListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticMastery"/> or <see cref="StaticMasteryList"/> objects. Only type, version, data, id, name, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticMasteryList> GetStaticMasteriesTaskAsync(string locale = null, string version = null, IEnumerable<string> masteryListData = null);

        /// <summary>
        /// Gets mastery details by ID from the static data API.
        /// </summary>
        /// <param name="id">The mastery ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetStaticVersions"/>.</param>
        /// <param name="masteryData">Tags to return additional data. Valid tags are any property of the <see cref="StaticMastery"/> object. Only id, name, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A <see cref="StaticChampion"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        StaticChampion GetStaticMasteryById(int id, string locale = null, string version = null, IEnumerable<string> masteryData = null);

        /// <summary>
        /// Gets mastery details by ID from the static data API.
        /// </summary>
        /// <param name="id">The mastery ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="masteryData">Tags to return additional data. Valid tags are any property of the <see cref="StaticMastery"/> object. Only id, name, description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticChampion> GetStaticMasteryByIdTaskAsync(int id, string locale = null, string version = null, IEnumerable<string> masteryData = null);

        /// <summary>
        /// Gets the realm data from the static data API.
        /// </summary>
        /// <returns>The current realm data.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        StaticRealm GetStaticRealm();

        /// <summary>
        /// Gets the realm data from the static data API.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticRealm> GetStaticRealmTaskAsync();

        /// <summary>
        /// Gets a list of all available runes from the static data API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetStaticVersions"/>.</param>
        /// <param name="runeListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticRune"/> or <see cref="StaticRuneList"/> objects. Only type, version, data, id, name, rune, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A dictionary of runes indexed by ID.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        StaticRuneList GetStaticRunes(string locale = null, string version = null, IEnumerable<string> runeListData = null);

        /// <summary>
        /// Gets a list of all available runes from the static data API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="runeListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticRune"/> or <see cref="StaticRuneList"/> objects. Only type, version, data, id, name, rune, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticRuneList> GetStaticRunesTaskAsync(string locale = null, string version = null, IEnumerable<string> runeListData = null);

        /// <summary>
        /// Gets a rune by ID from the static data API.
        /// </summary>
        /// <param name="id">The rune ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetStaticVersions"/>.</param>
        /// <param name="runeData">Tags to return additional data. Valid tags are any property of the <see cref="StaticRune"/> object. Only id, name, rune, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A <see cref="StaticRune"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        StaticRune GetStaticRuneById(int id, string locale = null, string version = null, IEnumerable<string> runeData = null);

        /// <summary>
        /// Gets a rune by ID from the static data API.
        /// </summary>
        /// <param name="id">The rune ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="runeData">Tags to return additional data. Valid tags are any property of the <see cref="StaticRune"/> object. Only id, name, rune, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticRune> GetStaticRuneByIdTaskAsync(int id, string locale = null, string version = null, IEnumerable<string> runeData = null);

        /// <summary>
        /// Gets the details for all summoner spells from the static data API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="dataById">If true, the returned data map will use the spells' IDs as the keys. If false, the returned data map will use the spells' keys instead.</param>
        /// <param name="spellListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticSummonerSpell"/> or <see cref="StaticSummonerSpellList"/> objects. Only type, version, data, id, key, name, description, and summonerLevel are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A <see cref="StaticSummonerSpellList"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        StaticSummonerSpellList GetStaticSummonerSpells(string locale = null, string version = null, bool dataById = false, IEnumerable<string> spellListData = null);

        /// <summary>
        /// Gets the details for all summoner spells from the static data API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="dataById">If true, the returned data map will use the spells' IDs as the keys. If false, the returned data map will use the spells' keys instead.</param>
        /// <param name="spellListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticSummonerSpell"/> or <see cref="StaticSummonerSpellList"/> objects. Only type, version, data, id, key, name, description, and summonerLevel are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticSummonerSpellList> GetStaticSummonerSpellsTaskAsync(string locale = null, string version = null, bool dataById = false, IEnumerable<string> spellListData = null);

        /// <summary>
        /// Gets summoner spell details by ID from the static data API.
        /// </summary>
        /// <param name="id">The summoner spell ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetStaticVersions"/>.</param>
        /// <param name="spellData">Tags to return additional data. Valid tags are any property of the <see cref="StaticSummonerSpell"/> object. Only id, key, name, description, and summonerLevel are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A <see cref="StaticSummonerSpell"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        StaticSummonerSpell GetStaticSummonerSpellById(int id, string locale = null, string version = null, IEnumerable<string> spellData = null);

        /// <summary>
        /// Gets summoner spell details by ID from the static data API.
        /// </summary>
        /// <param name="id">The summoner spell ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="spellData">Tags to return additional data. Valid tags are any property of the <see cref="StaticSummonerSpell"/> object. Only id, key, name, description, and summonerLevel are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticSummonerSpell> GetStaticSummonerSpellByIdTaskAsync(int id, string locale = null, string version = null, IEnumerable<string> spellData = null);

        /// <summary>
        /// Gets the list of available game versions from the static data API. Each version represents a patch number.
        /// </summary>
        /// <returns>The list of versions.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        List<string> GetStaticVersions();

        /// <summary>
        /// Gets the list of available game versions from the static data API.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<List<string>> GetVersionsTaskAsync();

        #endregion

        #region LoL Status API

        /// <summary>
        /// Gets the currently supported version of the LoL Status API that the client communicates with.
        /// </summary>
        string LolStatusApiVersion { get; }

        /// <summary>
        /// Gets the list of shards for all reagions.
        /// </summary>
        /// <returns>The shards.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        List<Shard> GetShards();

        /// <summary>
        /// Gets the list of shards for all reagions.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<List<Shard>> GetShardsTaskAsync();

        /// <summary>
        /// Gets the status of the shard for the current region.
        /// </summary>
        /// <returns>The shard's status.</returns>
        ShardStatus GetShardStatus();

        /// <summary>
        /// Gets the status of the shard for the current region.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<ShardStatus> GetShardStatusTaskAsync();

        #endregion

        #region Match API

        /// <summary>
        /// Gets the currently supported version of the Match API that the client communicates with.
        /// </summary>
        string MatchApiVersion { get; }

        /// <summary>
        /// Gets the details of a match.
        /// </summary>
        /// <param name="matchId">The ID of the match (also referred to as Game ID).</param>
        /// <param name="includeTimeline">Whether or not to include the match timeline data.</param>
        /// <returns>The details of the match.</returns>
        MatchDetail GetMatch(long matchId, Boolean includeTimeline);

        /// <summary>
        /// Gets the details of a match.
        /// </summary>
        /// <param name="matchId">The ID of the match (also referred to as Game ID).</param>
        /// <param name="includeTimeline">Whether or not to include the match timeline data.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<MatchDetail> GetMatchTaskAsync(long matchId, Boolean includeTimeline);

        #endregion

        #region Match History API

        /// <summary>
        /// Gets the currently supported version of the Match History API that the client communicates with.
        /// </summary>
        string MatchHistoryApiVersion { get; }

        /// <summary>
        /// Gets the match history for a summoner.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner IDs.</param>
        /// <param name="championIds">Only get games where the summoner played one of these champions.</param>
        /// <param name="rankedQueues">Only get games from these ranked queues.</param>
        /// <param name="beginIndex">The begin index to use for fetching games.</param>
        /// <param name="endIndex">The end index to use for fetching games. The maximum allowed difference between beginIndex and endIndex; if it is larger than 15, endIndex will be modified to satisfy this restriction.</param>
        /// <returns>The match history for the summoner.</returns>
        PlayerHistory GetMatchHistory(long summonerId, long[] championIds = null, RankedQueue[] rankedQueues = null, int? beginIndex = null, int? endIndex = null);

        /// <summary>
        /// Gets the match history for a summoner.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner IDs.</param>
        /// <param name="championIds">Only get games where the summoner played one of these champions.</param>
        /// <param name="rankedQueues">Only get games from these ranked queues.</param>
        /// <param name="beginIndex">The begin index to use for fetching games.</param>
        /// <param name="endIndex">The end index to use for fetching games. The maximum allowed difference between beginIndex and endIndex; if it is larger than 15, endIndex will be modified to satisfy this restriction.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<PlayerHistory> GetMatchHistoryTaskAsync(long summonerId, long[] championIds = null, RankedQueue[] rankedQueues = null, int? beginIndex = null, int? endIndex = null);

        #endregion

        #region Match List API

        // TODO: implement

        #endregion

        #region Stats API

        /// <summary>
        /// Gets the currently supported version of the Stats API that the client communicates with.
        /// </summary>
        string StatsApiVersion { get; }

        /// <summary>
        /// Gets the ranked stats for a summoner. Includes ranked stats for Summoner's Rift and Twisted Treeline.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner IDs.</param>
        /// <param name="season">The season to get ranked stats for. If unspecified, stats for the current season are returned.</param>
        /// <returns>The ranked stats for the summoner for the specified season.</returns>
        RankedStats GetStats(long summonerId, Season? season = null);

        /// <summary>
        /// Gets the ranked stats for a summoner. Includes ranked stats for Summoner's Rift and Twisted Treeline.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner IDs.</param>
        /// <param name="season">The season to get ranked stats for. If unspecified, stats for the current season are returned.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<RankedStats> GetStatsTaskAsync(long summonerId, Season? season);

        /// <summary>
        /// Gets aggregated stats for a summoner.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner IDs.</param>
        /// <param name="season">The season to get stats for. If unspecified, stats for the current season are returned.</param>
        /// <returns>The aggregated stats for the summoner for the specified season. One summary is returned per queue type.</returns>
        PlayerStatsSummaryList GetStatsSummary(long summonerId, Season? season = null);

        /// <summary>
        /// Gets aggregated stats for a summoner.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner IDs.</param>
        /// <param name="season">The season to get stats for. If unspecified, stats for the current season are returned.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<PlayerStatsSummaryList> GetStatsSummaryTaskAsync(long summonerId, Season? season = null);

        #endregion

        #region Summoner API

        /// <summary>
        /// Gets the currently supported version of the Summoner API that the client communicates with.
        /// </summary>
        string SummonerApiVersion { get; }

        /// <summary>
        /// Gets the summoner information for each summoner whose summoner name is in summonerNames.
        /// </summary>
        /// <param name="summonerNames">The summoner names.</param>
        /// <returns>The mapping from standardized summoner name (all lowercase, spaces removed) to summoner information.</returns>
        Dictionary<String, Summoner> GetSummonersBySummonerNames(params String[] summonerNames);

        /// <summary>
        /// Gets the summoner information for each summoner whose summoner name is in summonerNames.
        /// </summary>
        /// <param name="summonerNames">The summoner names.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Dictionary<String, Summoner>> GetSummonersBySummonerNamesTaskAsync(params String[] summonerNames);

        /// <summary>
        /// Gets the summoner information for the specified summoner.
        /// </summary>
        /// <param name="summonerName">The summoner name.</param>
        /// <returns>A <see cref="Summoner"/>.</returns>
        Summoner GetSummonerBySummonerName(String summonerName);

        /// <summary>
        /// Gets the summoner information for the specified summoner.
        /// </summary>
        /// <param name="summonerName">The summoner name.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Summoner> GetSummonerBySummonerNameTaskAsync(String summonerName);

        /// <summary>
        /// Gets the summoner information for each summoner whose summoner ID is in summonerIds.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs.</param>
        /// <returns>The mapping from summoner ID to summoner information.</returns>
        Dictionary<String, Summoner> GetSummonersBySummonerIds(params long[] summonerIds);

        /// <summary>
        /// Gets the summoner information for each summoner whose summoner ID is in summonerIds.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Dictionary<String, Summoner>> GetSummonersBySummonerIdsTaskAsync(params long[] summonerIds);

        /// <summary>
        /// Gets the summoner information for the specified summoner.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <returns>A <see cref="Summoner"/>.</returns>
        Summoner GetSummonerById(long summonerId);

        /// <summary>
        /// Gets the summoner information for the specified summoner.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Summoner> GetSummonerByIdTaskAsync(long summonerId);

        /// <summary>
        /// Gets the mastery pages for each summoner whose summoner ID is in summonerIds.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs.</param>
        /// <returns>The mapping from summoner ID to collection of mastery pages.</returns>
        Dictionary<String, MasteryPages> GetSummonerMasteriesBySummonerIds(params long[] summonerIds);

        /// <summary>
        /// Gets the mastery pages for each summoner whose summoner ID is in summonerIds.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Dictionary<String, MasteryPages>> GetSummonerMasteriesBySummonerIdsTaskAsync(params long[] summonerIds);

        /// <summary>
        /// Gets the summoner name for each summoner whose summoner ID is in summonerIds.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs.</param>
        /// <returns>The mapping from summoner ID to summoner name.</returns>
        Dictionary<String, String> GetSummonerNameBySummonerIds(params long[] summonerIds);

        /// <summary>
        /// Gets the summoner name for each summoner whose summoner ID is in summonerIds.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Dictionary<String, String>> GetSummonerNameBySummonerIdsTaskAsync(params long[] summonerIds);

        /// <summary>
        /// Gets the rune pages for each summoner whose summoner ID is in summonerIds.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs.</param>
        /// <returns>The mapping from summoner ID to collection of rune pages.</returns>
        Dictionary<String, RunePages> GetSummonerRunesBySummonerIds(params long[] summonerIds);

        /// <summary>
        /// Gets the rune pages for each summoner whose summoner ID is in summonerIds.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Dictionary<String, RunePages>> GetSummonerRunesBySummonerIdsTaskAsync(params long[] summonerIds);

        #endregion

        #region Team API

        /// <summary>
        /// Gets the currently supported version of the Team API that the client communicates with.
        /// </summary>
        string TeamApiVersion { get; }

        /// <summary>
        /// Gets, for every summoner in summonerIds, the teams that summoner is on.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs.</param>
        /// <returns>The mapping from summoner ID to the teams that summoner is on.</returns>
        Dictionary<string, List<Team>> GetTeamsBySummonerIds(params long[] summonerIds);

        /// <summary>
        /// Gets, for every summoner in summonerIds, the teams that summoner is on.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Dictionary<string, List<Team>>> GetTeamsBySummonerIdsTaskAsync(params long[] summonerIds);

        /// <summary>
        /// Gets the team corresponding to each team ID.
        /// </summary>
        /// <param name="teamIds">The team IDs.</param>
        /// <returns>The mapping from team IDs to teams.</returns>
        Dictionary<string, Team> GetTeamsByTeamIds(params String[] teamIds);

        /// <summary>
        /// Gets the team corresponding to each team ID.
        /// </summary>
        /// <param name="teamIds">The team IDs.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Dictionary<string, Team>> GetTeamsByTeamIdsTaskAsync(params String[] teamIds);

        #endregion
    }
}
