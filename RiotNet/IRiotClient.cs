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

        /// <summary>
        /// Occurs when the a request times out.
        /// </summary>
        event RetryEventHandler RequestTimedOut;

        /// <summary>
        /// Occurs when the client fails to connect to the server while executing a request.
        /// </summary>
        event RetryEventHandler ConnectionFailed;

        /// <summary>
        /// Occurs when the client executes a request when the API rate limit has been exceeded.
        /// </summary>
        event RetryEventHandler RateLimitExceeded;

        /// <summary>
        /// Occurs when the server returns an error code of 500 or higher.
        /// </summary>
        event RetryEventHandler ServerError;

        /// <summary>
        /// Occurs when a request fails because a resource was not found.
        /// </summary>
        event ResponseEventHandler ResourceNotFound;

        /// <summary>
        /// Occurs when a response returns an error code that does not fit into any other category, or an exception occurs during the response.
        /// </summary>
        event ResponseEventHandler ResponseError;

        #endregion

        #region Champion API

        /// <summary>
        /// Gets the currently supported version of the Champion API that the client communicates with.
        /// </summary>
        string ChampionApiVersion { get; }

        /// <summary>
        /// Gets dynamic champion information for all champions. This method uses the Champion API.
        /// </summary>
        /// <param name="freeToPlay">True if only requesting free to play champion information. Default is false.</param>
        /// <returns>List of champion information.</returns>
        List<Champion> GetChampions(Boolean freeToPlay = false);

        /// <summary>
        /// Gets dynamic champion information for all champions. This method uses the Champion API.
        /// </summary>
        /// <param name="freeToPlay">True if only requesting free to play champion information. Default is false.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<List<Champion>> GetChampionsAsync(Boolean freeToPlay = false);

        /// <summary>
        /// Gets dynamic champion information for the specified champion. This method uses the Champion API.
        /// </summary>
        /// <param name="id">The champion id.</param>
        /// <returns>Champion information.</returns>
        Champion GetChampionById(long id);

        /// <summary>
        /// Gets dynamic champion information for the specified champion. This method uses the Champion API.
        /// </summary>
        /// <param name="id">The champion id.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Champion> GetChampionByIdAsync(long id);

        #endregion

        #region Current Game API

        /// <summary>
        /// Gets the currently supported version of the Current Game API that the client communicates with.
        /// </summary>
        string CurrentGameApiVersion { get; }

        /// <summary>
        /// Gets information about the current game a summoner is playing. This method uses the Current Game API.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner ID.</param>
        /// <returns>The current game information.</returns>
        CurrentGameInfo GetCurrentGameBySummonerId(long summonerId);

        /// <summary>
        /// Gets information about the current game a summoner is playing. This method uses the Current Game API.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner ID.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<CurrentGameInfo> GetCurrentGameBySummonerIdAsync(long summonerId);

        #endregion

        #region Featured Game API

        /// <summary>
        /// Gets the currently supported version of the Featured Game API that the client communicates with.
        /// </summary>
        string FeaturedGameApiVersion { get; }

        /// <summary>
        /// Gets the games currently featured in the League of Legends client. This method uses the Featured Game API.
        /// </summary>
        /// <returns>The featured games.</returns>
        FeaturedGames GetFeaturedGames();

        /// <summary>
        /// Gets the games currently featured in the League of Legends client. This method uses the Featured Game API.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<FeaturedGames> GetFeaturedGamesAsync();

        #endregion

        #region Game API

        /// <summary>
        /// Gets the currently supported version of the Game API that the client communicates with.
        /// </summary>
        string GameApiVersion { get; }

        /// <summary>
        /// Gets the recent games for a summoner. This method uses the Game API.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner ID.</param>
        /// <returns>The summoner's recent games.</returns>
        RecentGames GetGamesBySummonerId(long summonerId);

        /// <summary>
        /// Gets the recent games for a summoner. This method uses the Game API.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner ID.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<RecentGames> GetGamesBySummonerIdAsync(long summonerId);

        #endregion

        #region League API

        /// <summary>
        /// Gets the currently supported version of the League API that the client communicates with.
        /// </summary>
        string LeagueApiVersion { get; }

        /// <summary>
        /// Gets the full league information for all leagues that the summoners are in, including the leages for the teams they are on. Data is mapped by summoner ID. This method uses the League API.
        /// </summary>
        /// <param name="summonerIds">The summoners' summoner IDs. The maximum allowed at once is 10.</param>
        /// <returns>The mapping from summoner IDs to the collection of leagues.</returns>
        Dictionary<String, List<League>> GetLeaguesBySummonerIds(params long[] summonerIds);

        /// <summary>
        /// Gets the full league information for all leagues that the summoners are in, including the leages for the teams they are on. Data is mapped by summoner ID. This method uses the League API.
        /// </summary>
        /// <param name="summonerIds">The summoners' summoner IDs. The maximum allowed at once is 10.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Dictionary<String, List<League>>> GetLeaguesBySummonerIdsAsync(params long[] summonerIds);

        /// <summary>
        /// Gets the full league information for all leagues that the summoners are in, including the leages for the teams they are on. Only includes the league entry for the specified summoner(s). Data is mapped by summoner ID. This method uses the League API.
        /// </summary>
        /// <param name="summonerIds">The summoners' summoner IDs. The maximum allowed at once is 10.</param>
        /// <returns>The mapping from summoner IDs to the collection of league entries for the summoner.</returns>
        Dictionary<String, List<League>> GetLeagueEntriesBySummonerIds(params long[] summonerIds);

        /// <summary>
        /// Gets the full league information for all leagues that the summoners are in, including the leages for the teams they are on. Only includes the league entry for the specified summoner(s). Data is mapped by summoner ID. This method uses the League API.
        /// </summary>
        /// <param name="summonerIds">The summoners' summoner IDs. The maximum allowed at once is 10.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Dictionary<String, List<League>>> GetLeagueEntriesBySummonerIdsAsync(params long[] summonerIds);

        /// <summary>
        /// Gets the full league information for all leagues that the teams are in. Data is mapped by team ID. This method uses the League API.
        /// </summary>
        /// <param name="teamIds">The teams' team IDs. The maximum allowed at once is 10.</param>
        /// <returns>The mapping from team IDs to the collection of leagues.</returns>
        Dictionary<String, List<League>> GetLeaguesByTeamIds(params string[] teamIds);

        /// <summary>
        /// Gets the full league information for all leagues that the teams are in. Data is mapped by team ID. This method uses the League API.
        /// </summary>
        /// <param name="teamIds">The teams' team IDs. The maximum allowed at once is 10.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Dictionary<String, List<League>>> GetLeaguesByTeamIdsAsync(params string[] teamIds);

        /// <summary>
        /// Gets the league information for all leagues that the teams are in. Only includes the league entry for the specified team(s). Data is mapped by team ID. This method uses the League API.
        /// </summary>
        /// <param name="teamIds">The teams' team IDs. The maximum allowed at once is 10.</param>
        /// <returns>The mapping from team IDs to the collection of league entries for the team.</returns>
        Dictionary<String, List<League>> GetLeagueEntriesByTeamIds(params string[] teamIds);

        /// <summary>
        /// Gets the league information for all leagues that the teams are in. Only includes the league entry for the specified team(s). Data is mapped by team ID. This method uses the League API.
        /// </summary>
        /// <param name="teamIds">The teams' team IDs. The maximum allowed at once is 10.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Dictionary<String, List<League>>> GetLeagueEntriesByTeamIdsAsync(params string[] teamIds);

        /// <summary>
        /// Gets the challenger league. This method uses the League API.
        /// </summary>
        /// <param name="type">The queue type.</param>
        /// <returns>The challenger league.</returns>
        League GetChallengerLeague(RankedQueue type);

        /// <summary>
        /// Gets the challenger league. This method uses the League API.
        /// </summary>
        /// <param name="type">The queue type.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<League> GetChallengerLeagueAsync(RankedQueue type);

        /// <summary>
        /// Gets the master league. This method uses the League API.
        /// </summary>
        /// <param name="type">The queue type.</param>
        /// <returns>The master league.</returns>
        League GetMasterLeague(RankedQueue type);

        /// <summary>
        /// Gets the master league. This method uses the League API.
        /// </summary>
        /// <param name="type">The queue type.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<League> GetMasterLeagueAsync(RankedQueue type);

        #endregion

        #region LoL Static Data API

        /// <summary>
        /// Gets the currently supported version of the LoL Static Data API that the client communicates with.
        /// </summary>
        string LolStaticDataApiVersion { get; }

        /// <summary>
        /// Gets the details for all champions.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="dataById">If true, the returned data map will use the champions' IDs as the keys. If false, the returned data map will use the champions' keys instead.</param>
        /// <param name="champListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticChampion"/> or <see cref="StaticChampionList"/> objects. Only type, version, data, id, name, key, and title are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A <see cref="StaticChampionList"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        StaticChampionList GetStaticChampions(string locale = null, string version = null, bool dataById = false, IEnumerable<string> champListData = null);

        /// <summary>
        /// Gets the details for all champions. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="dataById">If true, the returned data map will use the champions' IDs as the keys. If false, the returned data map will use the champions' keys instead.</param>
        /// <param name="champListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticChampion"/> or <see cref="StaticChampionList"/> objects. Only type, version, data, id, name, key, and title are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticChampionList> GetStaticChampionsAsync(string locale = null, string version = null, bool dataById = false, IEnumerable<string> champListData = null);

        /// <summary>
        /// Gets champion details by ID. This method uses the LoL Static Data API.
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
        /// Gets champion details by ID. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="id">The champion ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="champData">Tags to return additional data. Valid tags are any property of the <see cref="StaticChampion"/> object. Only id, name, key, and title are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticChampion> GetStaticChampionByIdAsync(int id, string locale = null, string version = null, IEnumerable<string> champData = null);

        /// <summary>
        /// Gets a list of all available items. This method uses the LoL Static Data API.
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
        /// Gets a list of all available items. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="itemListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticItem"/> or <see cref="StaticItemList"/> objects. Only id, name, type, version, basic, data, plaintext, group, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticItemList> GetStaticItemsAsync(string locale = null, string version = null, IEnumerable<string> itemListData = null);
        
        /// <summary>
        /// Gets a list of available languages. This method uses the LoL Static Data API.
        /// </summary>
        /// <returns>A list of strings that represent a language.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        List<string> GetStaticLanguages();

        /// <summary>
        /// Gets a list of available languages. This method uses the LoL Static Data API.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<List<string>> GetStaticLanguagesAsync();

        /// <summary>
        /// Gets a list of available language strings. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetStaticVersions"/>.</param>
        /// <returns>A <see cref="StaticLanuageStrings"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        StaticLanuageStrings GetStaticLanguageStrings(string locale = null, string version = null);

        /// <summary>
        /// Gets a list of available language strings. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticLanuageStrings> GetStaticLanguageStringsAsync(string locale = null, string version = null);

        /// <summary>
        /// Gets a list of all maps. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetStaticVersions"/>.</param>
        /// <returns>A <see cref="StaticMapList"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        StaticMapList GetStaticMaps(string locale = null, string version = null);

        /// <summary>
        /// Gets a list of all maps. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticMapList> GetStaticMapsAsync(string locale = null, string version = null);

        /// <summary>
        /// Gets the details for all masteries. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="masteryListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticMastery"/> or <see cref="StaticMasteryList"/> objects. Only type, version, data, id, name, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A <see cref="StaticMasteryList"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        StaticMasteryList GetStaticMasteries(string locale = null, string version = null, IEnumerable<string> masteryListData = null);

        /// <summary>
        /// Gets the details for all masteries. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="masteryListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticMastery"/> or <see cref="StaticMasteryList"/> objects. Only type, version, data, id, name, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticMasteryList> GetStaticMasteriesAsync(string locale = null, string version = null, IEnumerable<string> masteryListData = null);

        /// <summary>
        /// Gets mastery details by ID. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="id">The mastery ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetStaticVersions"/>.</param>
        /// <param name="masteryData">Tags to return additional data. Valid tags are any property of the <see cref="StaticMastery"/> object. Only id, name, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A <see cref="StaticChampion"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        StaticMastery GetStaticMasteryById(int id, string locale = null, string version = null, IEnumerable<string> masteryData = null);

        /// <summary>
        /// Gets mastery details by ID. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="id">The mastery ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="masteryData">Tags to return additional data. Valid tags are any property of the <see cref="StaticMastery"/> object. Only id, name, description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticMastery> GetStaticMasteryByIdAsync(int id, string locale = null, string version = null, IEnumerable<string> masteryData = null);

        /// <summary>
        /// Gets the realm data. This method uses the LoL Static Data API.
        /// </summary>
        /// <returns>The current realm data.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        StaticRealm GetStaticRealm();

        /// <summary>
        /// Gets the realm data. This method uses the LoL Static Data API.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticRealm> GetStaticRealmAsync();

        /// <summary>
        /// Gets a list of all available runes. This method uses the LoL Static Data API.
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
        /// Gets a list of all available runes. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="runeListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticRune"/> or <see cref="StaticRuneList"/> objects. Only type, version, data, id, name, rune, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticRuneList> GetStaticRunesAsync(string locale = null, string version = null, IEnumerable<string> runeListData = null);

        /// <summary>
        /// Gets a rune by ID. This method uses the LoL Static Data API.
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
        /// Gets a rune by ID. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="id">The rune ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="runeData">Tags to return additional data. Valid tags are any property of the <see cref="StaticRune"/> object. Only id, name, rune, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticRune> GetStaticRuneByIdAsync(int id, string locale = null, string version = null, IEnumerable<string> runeData = null);

        /// <summary>
        /// Gets the details for all summoner spells. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="dataById">If true, the returned data map will use the spells' IDs as the keys. If false, the returned data map will use the spells' keys instead.</param>
        /// <param name="spellListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticSummonerSpell"/> or <see cref="StaticSummonerSpellList"/> objects. Only type, version, data, id, key, name, description, and summonerLevel are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A <see cref="StaticSummonerSpellList"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        StaticSummonerSpellList GetStaticSummonerSpells(string locale = null, string version = null, bool dataById = false, IEnumerable<string> spellListData = null);

        /// <summary>
        /// Gets the details for all summoner spells. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="dataById">If true, the returned data map will use the spells' IDs as the keys. If false, the returned data map will use the spells' keys instead.</param>
        /// <param name="spellListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticSummonerSpell"/> or <see cref="StaticSummonerSpellList"/> objects. Only type, version, data, id, key, name, description, and summonerLevel are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticSummonerSpellList> GetStaticSummonerSpellsAsync(string locale = null, string version = null, bool dataById = false, IEnumerable<string> spellListData = null);

        /// <summary>
        /// Gets summoner spell details by ID. This method uses the LoL Static Data API.
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
        /// Gets summoner spell details by ID. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="id">The summoner spell ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="spellData">Tags to return additional data. Valid tags are any property of the <see cref="StaticSummonerSpell"/> object. Only id, key, name, description, and summonerLevel are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticSummonerSpell> GetStaticSummonerSpellByIdAsync(int id, string locale = null, string version = null, IEnumerable<string> spellData = null);

        /// <summary>
        /// Gets the list of available game versions. This method uses the LoL Static Data API. Each version represents a patch number.
        /// </summary>
        /// <returns>The list of versions.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        List<string> GetStaticVersions();

        /// <summary>
        /// Gets the list of available game versions. This method uses the LoL Static Data API.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<List<string>> GetVersionsAsync();

        #endregion

        #region LoL Status API

        /// <summary>
        /// Gets the currently supported version of the LoL Status API that the client communicates with.
        /// </summary>
        string LolStatusApiVersion { get; }

        /// <summary>
        /// Gets the list of shards for all reagions. This method uses the LoL Status API.
        /// </summary>
        /// <returns>The shards.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        List<Shard> GetShards();

        /// <summary>
        /// Gets the list of shards for all reagions. This method uses the LoL Status API.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<List<Shard>> GetShardsAsync();

        /// <summary>
        /// Gets the status of the shard for the current region. This method uses the LoL Status API.
        /// </summary>
        /// <returns>The shard's status.</returns>
        ShardStatus GetShardStatus();

        /// <summary>
        /// Gets the status of the shard for the current region. This method uses the LoL Status API.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<ShardStatus> GetShardStatusAsync();

        #endregion

        #region Match API

        /// <summary>
        /// Gets the currently supported version of the Match API that the client communicates with.
        /// </summary>
        string MatchApiVersion { get; }

        /// <summary>
        /// Gets the details of a match. This method uses the Match API.
        /// </summary>
        /// <param name="matchId">The ID of the match (also referred to as Game ID).</param>
        /// <param name="includeTimeline">Whether or not to include the match timeline data.</param>
        /// <returns>The details of the match.</returns>
        MatchDetail GetMatch(long matchId, Boolean includeTimeline = false);

        /// <summary>
        /// Gets the details of a match. This method uses the Match API.
        /// </summary>
        /// <param name="matchId">The ID of the match (also referred to as Game ID).</param>
        /// <param name="includeTimeline">Whether or not to include the match timeline data.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<MatchDetail> GetMatchAsync(long matchId, Boolean includeTimeline = false);

        #endregion

        #region Match List API

        /// <summary>
        /// Gets the currently supported version of the Match List API that the client communicates with.
        /// </summary>
        string MatchListApiVersion { get; }

        /// <summary>
        /// Gets the match list for a summoner. This method uses the Match List API.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner IDs.</param>
        /// <param name="championIds">Only get games where the summoner played one of these champions.</param>
        /// <param name="rankedQueues">Only get games from these ranked queues.</param>
        /// <param name="seasons">Only get games from these seasons.</param>
        /// <param name="beginTime">Only get games played after this time.</param>
        /// <param name="endTime">Only get games played before this time.</param>
        /// <param name="beginIndex">The begin index to use for fetching games.</param>
        /// <param name="endIndex">The end index to use for fetching games. The maximum allowed difference between beginIndex and endIndex is 20; if it is larger than 20, endIndex will be modified to satisfy this restriction.</param>
        /// <returns>The match list for the summoner.</returns>
        MatchList GetMatchList(long summonerId, long[] championIds = null, RankedQueue[] rankedQueues = null, Season[] seasons = null, DateTime? beginTime = null, DateTime? endTime = null, int? beginIndex = null, int? endIndex = null);

        /// <summary>
        /// Gets the match list for a summoner. This method uses the Match List API.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner IDs.</param>
        /// <param name="championIds">Only get games where the summoner played one of these champions.</param>
        /// <param name="rankedQueues">Only get games from these ranked queues.</param>
        /// <param name="seasons">Only get games from these seasons.</param>
        /// <param name="beginTime">Only get games played after this time.</param>
        /// <param name="endTime">Only get games played before this time.</param>
        /// <param name="beginIndex">The begin index to use for fetching games.</param>
        /// <param name="endIndex">The end index to use for fetching games. The maximum allowed difference between beginIndex and endIndex is 20; if it is larger than 20, endIndex will be modified to satisfy this restriction.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<MatchList> GetMatchListAsync(long summonerId, long[] championIds = null, RankedQueue[] rankedQueues = null, Season[] seasons = null, DateTime? beginTime = null, DateTime? endTime = null, int? beginIndex = null, int? endIndex = null);

        #endregion

        #region Stats API

        /// <summary>
        /// Gets the currently supported version of the Stats API that the client communicates with.
        /// </summary>
        string StatsApiVersion { get; }

        /// <summary>
        /// Gets the ranked stats for a summoner. Includes ranked stats for Summoner's Rift and Twisted Treeline. This method uses the Stats API.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner IDs.</param>
        /// <param name="season">The season to get ranked stats for. If unspecified, stats for the current season are returned.</param>
        /// <returns>The ranked stats for the summoner for the specified season.</returns>
        RankedStats GetRankedStats(long summonerId, Season? season = null);

        /// <summary>
        /// Gets the ranked stats for a summoner. Includes ranked stats for Summoner's Rift and Twisted Treeline. This method uses the Stats API.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner IDs.</param>
        /// <param name="season">The season to get ranked stats for. If unspecified, stats for the current season are returned.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<RankedStats> GetRankedStatsAsync(long summonerId, Season? season = null);

        /// <summary>
        /// Gets aggregated stats for a summoner. This method uses the Stats API.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner IDs.</param>
        /// <param name="season">The season to get stats for. If unspecified, stats for the current season are returned.</param>
        /// <returns>The aggregated stats for the summoner for the specified season. One summary is returned per queue type.</returns>
        PlayerStatsSummaryList GetStatsSummary(long summonerId, Season? season = null);

        /// <summary>
        /// Gets aggregated stats for a summoner. This method uses the Stats API.
        /// </summary>
        /// <param name="summonerId">The summoner's summoner IDs.</param>
        /// <param name="season">The season to get stats for. If unspecified, stats for the current season are returned.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<PlayerStatsSummaryList> GetStatsSummaryAsync(long summonerId, Season? season = null);

        #endregion

        #region Summoner API

        /// <summary>
        /// Gets the currently supported version of the Summoner API that the client communicates with.
        /// </summary>
        string SummonerApiVersion { get; }

        /// <summary>
        /// Gets the summoner information for each summoner whose summoner name is in summonerNames. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerNames">The summoner names The maximum allowed at once is 40..</param>
        /// <returns>The mapping from standardized summoner name (all lowercase, spaces removed) to summoner information.</returns>
        Dictionary<String, Summoner> GetSummonersBySummonerNames(params String[] summonerNames);

        /// <summary>
        /// Gets the summoner information for each summoner whose summoner name is in summonerNames. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerNames">The summoner names. The maximum allowed at once is 40.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Dictionary<String, Summoner>> GetSummonersBySummonerNamesAsync(params String[] summonerNames);

        /// <summary>
        /// Gets the summoner information for the specified summoner. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerName">The summoner name.</param>
        /// <returns>A <see cref="Summoner"/>.</returns>
        Summoner GetSummonerBySummonerName(String summonerName);

        /// <summary>
        /// Gets the summoner information for the specified summoner. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerName">The summoner name.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Summoner> GetSummonerBySummonerNameAsync(String summonerName);

        /// <summary>
        /// Gets the summoner information for each summoner whose summoner ID is in summonerIds. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs. The maximum allowed at once is 40.</param>
        /// <returns>The mapping from summoner ID to summoner information.</returns>
        Dictionary<String, Summoner> GetSummonersBySummonerIds(params long[] summonerIds);

        /// <summary>
        /// Gets the summoner information for each summoner whose summoner ID is in summonerIds. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs. The maximum allowed at once is 40.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Dictionary<String, Summoner>> GetSummonersBySummonerIdsAsync(params long[] summonerIds);

        /// <summary>
        /// Gets the summoner information for the specified summoner. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <returns>A <see cref="Summoner"/>.</returns>
        Summoner GetSummonerBySummonerId(long summonerId);

        /// <summary>
        /// Gets the summoner information for the specified summoner. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Summoner> GetSummonerBySummonerIdAsync(long summonerId);

        /// <summary>
        /// Gets the mastery pages for each summoner whose summoner ID is in summonerIds. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs. The maximum allowed at once is 40.</param>
        /// <returns>The mapping from summoner ID to collection of mastery pages.</returns>
        Dictionary<String, MasteryPages> GetSummonerMasteriesBySummonerIds(params long[] summonerIds);

        /// <summary>
        /// Gets the mastery pages for each summoner whose summoner ID is in summonerIds. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs. The maximum allowed at once is 40.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Dictionary<String, MasteryPages>> GetSummonerMasteriesBySummonerIdsAsync(params long[] summonerIds);

        /// <summary>
        /// Gets the summoner name for each summoner whose summoner ID is in summonerIds. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs.</param>
        /// <returns>The mapping from summoner ID to summoner name.</returns>
        Dictionary<String, String> GetSummonerNamesBySummonerIds(params long[] summonerIds);

        /// <summary>
        /// Gets the summoner name for each summoner whose summoner ID is in summonerIds. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs. The maximum allowed at once is 40.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Dictionary<String, String>> GetSummonerNamesBySummonerIdsAsync(params long[] summonerIds);

        /// <summary>
        /// Gets the rune pages for each summoner whose summoner ID is in summonerIds. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs. The maximum allowed at once is 40.</param>
        /// <returns>The mapping from summoner ID to collection of rune pages.</returns>
        Dictionary<String, RunePages> GetSummonerRunesBySummonerIds(params long[] summonerIds);

        /// <summary>
        /// Gets the rune pages for each summoner whose summoner ID is in summonerIds. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs. The maximum allowed at once is 40.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Dictionary<String, RunePages>> GetSummonerRunesBySummonerIdsAsync(params long[] summonerIds);

        #endregion

        #region Team API

        /// <summary>
        /// Gets the currently supported version of the Team API that the client communicates with.
        /// </summary>
        string TeamApiVersion { get; }

        /// <summary>
        /// Gets, for every summoner in summonerIds, the teams that summoner is on. This method uses the Team API.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs. The maximum allowed at once is 10.</param>
        /// <returns>The mapping from summoner ID to the teams that summoner is on.</returns>
        Dictionary<string, List<Team>> GetTeamsBySummonerIds(params long[] summonerIds);

        /// <summary>
        /// Gets, for every summoner in summonerIds, the teams that summoner is on. This method uses the Team API.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs. The maximum allowed at once is 10.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Dictionary<string, List<Team>>> GetTeamsBySummonerIdsAsync(params long[] summonerIds);

        /// <summary>
        /// Gets the team corresponding to each team ID. This method uses the Team API.
        /// </summary>
        /// <param name="teamIds">The team IDs. The maximum allowed at once is 10.</param>
        /// <returns>The mapping from team IDs to teams.</returns>
        Dictionary<string, Team> GetTeamsByTeamIds(params String[] teamIds);

        /// <summary>
        /// Gets the team corresponding to each team ID. This method uses the Team API.
        /// </summary>
        /// <param name="teamIds">The team IDs. The maximum allowed at once is 10.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Dictionary<string, Team>> GetTeamsByTeamIdsAsync(params String[] teamIds);

        #endregion

        #region Tournament API

        /// <summary>
        /// Gets the currently supported version of the Tournament API that the client communicates with.
        /// </summary>
        string TournamentApiVersion { get; }

        /// <summary>
        /// Registers the current client as a tournament provider.
        /// </summary>
        /// <param name="url">The provider's callback URL to which tournament game results in this region should be posted.</param>
        /// <returns>The registered providerID.</returns>
        long CreateTournamentProvider(string url);

        /// <summary>
        /// Registers the current client as a tournament provider.
        /// </summary>
        /// <param name="url">The provider's callback URL to which tournament game results in this region should be posted.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<long> CreateTournamentProviderAsync(string url);

        /// <summary>
        /// Creates a tournament.
        /// </summary>
        /// <param name="providerID">The providerID obtained from <see cref="CreateTournamentProvider"/>.</param>
        /// <param name="name">The optional name of the tournament.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        long CreateTournament(long providerID, string name = null);

        /// <summary>
        /// Creates a tournament.
        /// </summary>
        /// <param name="providerID">The providerID obtained from <see cref="CreateTournamentProviderAsync"/>.</param>
        /// <param name="name">The optional name of the tournament.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<long> CreateTournamentAsync(long providerID, string name = null);

        #endregion
    }
}
