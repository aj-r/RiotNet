﻿using RiotNet.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiotNet
{
    public partial interface IRiotClient
    {
        #region LoL Static Data API

        /// <summary>
        /// Gets the currently supported version of the LoL Static Data API that the client communicates with.
        /// </summary>
        string LolStaticDataApiVersion { get; }

        /// <summary>
        /// Gets the details for all champions. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the champListData parameter to specify which properties you want.
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
        /// Gets champion details by ID. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the champData parameter to specify which properties you want.
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
        /// Gets a list of all available items. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the itemListData parameter to specify which properties you want.
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
        /// Gets an item by its ID. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the itemData parameter to specify which properties you want.
        /// </summary>
        /// <param name="id">The item ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="itemListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticItem"/> or <see cref="StaticItemList"/> objects. Only id, name, type, version, basic, data, plaintext, group, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticItem> GetStaticItemAsync(int id, string locale = null, string version = null, IEnumerable<string> itemData = null);

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
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticMapList> GetStaticMapsAsync(string locale = null, string version = null);

        /// <summary>
        /// Gets the details for all masteries. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the masteryListData parameter to specify which properties you want.
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
        /// Gets mastery details by ID. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the masteryData parameter to specify which properties you want.
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
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticRealm> GetStaticRealmAsync();

        /// <summary>
        /// Gets a list of all available runes. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the runeListData parameter to specify which properties you want.
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
        /// Gets a rune by ID. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the runeData parameter to specify which properties you want.
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
        /// Gets the details for all summoner spells. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the spellListData parameter to specify which properties you want.
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
        /// Gets summoner spell details by ID. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the spellData parameter to specify which properties you want.
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
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<List<Shard>> GetShardsAsync();
        
        /// <summary>
        /// Gets the status of the shard for the current region. This method uses the LoL Status API.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<ShardStatus> GetShardStatusAsync();

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
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<RankedStats> GetRankedStatsAsync(long summonerId, Season? season = null);
        
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
        /// <param name="summonerNames">The summoner names. The maximum allowed at once is 40.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Dictionary<string, Summoner>> GetSummonersBySummonerNamesAsync(params string[] summonerNames);
        
        /// <summary>
        /// Gets the summoner information for the specified summoner. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerName">The summoner name.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Summoner> GetSummonerBySummonerNameAsync(string summonerName);
        
        /// <summary>
        /// Gets the summoner information for each summoner whose summoner ID is in summonerIds. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs. The maximum allowed at once is 40.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Dictionary<string, Summoner>> GetSummonersBySummonerIdsAsync(params long[] summonerIds);
        
        /// <summary>
        /// Gets the summoner information for the specified summoner. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Summoner> GetSummonerBySummonerIdAsync(long summonerId);
        
        /// <summary>
        /// Gets the summoner name for each summoner whose summoner ID is in summonerIds. This method uses the Summoner API.
        /// </summary>
        /// <param name="summonerIds">The summoner IDs. The maximum allowed at once is 40.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Dictionary<string, string>> GetSummonerNamesBySummonerIdsAsync(params long[] summonerIds);

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
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<Dictionary<string, List<Team>>> GetTeamsBySummonerIdsAsync(params long[] summonerIds);
        
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
        /// Registers the current client as a tournament provider. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// </summary>
        /// <param name="url">The provider's callback URL to which tournament game results in this region should be posted.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<long> CreateTournamentProviderAsync(string url);
        
        /// <summary>
        /// Creates a tournament. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// </summary>
        /// <param name="providerID">The providerID obtained from <see cref="CreateTournamentProviderAsync"/>.</param>
        /// <param name="name">The optional name of the tournament.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<long> CreateTournamentAsync(long providerID, string name = null);
        
        /// <summary>
        /// Creates one or more tournament codes. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// </summary>
        /// <param name="tournamentId">The tournament ID obtained from <see cref="CreateTournamentAsync"/>.</param>
        /// <param name="count">The number of codes to create (max 1000).</param>
        /// <param name="allowedSummonerIds">Optional list of participants in order to validate the players eligible to join the lobby.</param>
        /// <param name="mapType">The map type of the game. Note that <see cref="MapType.CRYSTAL_SCAR"/> is not allowed.</param>
        /// <param name="pickType">The pick type of the game.</param>
        /// <param name="spectatorType">The spectator type of the game.</param>
        /// <param name="teamSize">The team size of the game. Valid values are 1-5.</param>
        /// <param name="metadata">Optional string that may contain any data in any format, if specified at all. Used to denote any custom information about the game.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<List<string>> CreateTournamentCodeAsync(long tournamentId, int? count = null, List<long> allowedSummonerIds = null, MapType mapType = MapType.SUMMONERS_RIFT,
            PickType pickType = PickType.TOURNAMENT_DRAFT, SpectatorType spectatorType = SpectatorType.ALL, int teamSize = 5, string metadata = null);
        
        /// <summary>
        /// Gets the details of a tournament code. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// </summary>
        /// <param name="tournamentCode">The tournament code obtained from <see cref="CreateTournamentCodeAsync"/>.</param>
        /// <returns>The tournament code details.</returns>
        Task<TournamentCode> GetTournamentCodeAsync(string tournamentCode);
        
        /// <summary>
        /// Saves changes to a tournament code. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// </summary>
        /// <param name="tournamentCode">The tournament code obtained from <see cref="CreateTournamentCodeAsync"/>.</param>
        /// <param name="allowedSummonerIds">Optional list of participants in order to validate the players eligible to join the lobby.</param>
        /// <param name="mapType">The map type of the game.</param>
        /// <param name="pickType">The pick type of the game.</param>
        /// <param name="spectatorType">The spectator type of the game.</param>
        Task UpdateTournamentCodeAsync(string tournamentCode, List<long> allowedSummonerIds = null, MapType mapType = MapType.SUMMONERS_RIFT,
            PickType pickType = PickType.TOURNAMENT_DRAFT, SpectatorType spectatorType = SpectatorType.ALL);
        
        /// <summary>
        /// Saves changes to a tournament code. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// </summary>
        /// <param name="tournamentCode">The tournament code to update. Only the Code, Participants, MapType, PickType, and SpectatorType proerties are used.</param>
        Task UpdateTournamentCodeAsync(TournamentCode tournamentCode);
        
        /// <summary>
        /// Gets the events that happened in the lobby of atournament code game. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// </summary>
        /// <param name="tournamentCode">The tournament code obtained from <see cref="CreateTournamentCodeAsync"/>.</param>
        /// <returns>The tournament code details.</returns>
        Task<List<LobbyEvent>> GetTournamentCodeLobbyEventsAsync(string tournamentCode);

        #endregion
    }
}
