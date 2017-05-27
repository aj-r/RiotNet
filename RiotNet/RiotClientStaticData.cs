using Newtonsoft.Json;
using RiotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace RiotNet
{
    public partial interface IRiotClient
    {
        /// <summary>
        /// Gets the details for all champions. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the champListData parameter to specify which properties you want.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="dataById">If true, the returned data map will use the champions' IDs as the keys. If false, the returned data map will use the champions' keys instead.</param>
        /// <param name="champListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticChampion"/> or <see cref="StaticChampionList"/> objects. Only type, version, data, id, name, key, and title are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticChampionList> GetStaticChampionsAsync(string locale = null, string version = null, bool dataById = false, IEnumerable<string> champListData = null, PlatformId? platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets champion details by ID. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the champData parameter to specify which properties you want.
        /// </summary>
        /// <param name="id">The champion ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="champData">Tags to return additional data. Valid tags are any property of the <see cref="StaticChampion"/> object. Only id, name, key, and title are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticChampion> GetStaticChampionByIdAsync(int id, string locale = null, string version = null, IEnumerable<string> champData = null, PlatformId? platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets a list of all available items. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the itemListData parameter to specify which properties you want.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="itemListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticItem"/> or <see cref="StaticItemList"/> objects. Only id, name, type, version, basic, data, plaintext, group, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticItemList> GetStaticItemsAsync(string locale = null, string version = null, IEnumerable<string> itemListData = null, PlatformId? platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets an item by its ID. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the itemData parameter to specify which properties you want.
        /// </summary>
        /// <param name="id">The item ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="itemData">Tags to return additional data. Valid tags are any property of the <see cref="StaticItem"/> or <see cref="StaticItemList"/> objects. Only id, name, type, version, basic, data, plaintext, group, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticItem> GetStaticItemAsync(int id, string locale = null, string version = null, IEnumerable<string> itemData = null, PlatformId? platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets a list of available languages. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<List<string>> GetStaticLanguagesAsync(PlatformId? platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets a list of available language strings. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticLanuageStrings> GetStaticLanguageStringsAsync(string locale = null, string version = null, PlatformId? platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets a list of all maps. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticMapList> GetStaticMapsAsync(string locale = null, string version = null, PlatformId? platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the details for all masteries. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the masteryListData parameter to specify which properties you want.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="masteryListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticMastery"/> or <see cref="StaticMasteryList"/> objects. Only type, version, data, id, name, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticMasteryList> GetStaticMasteriesAsync(string locale = null, string version = null, IEnumerable<string> masteryListData = null, PlatformId? platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets mastery details by ID. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the masteryData parameter to specify which properties you want.
        /// </summary>
        /// <param name="id">The mastery ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="masteryData">Tags to return additional data. Valid tags are any property of the <see cref="StaticMastery"/> object. Only id, name, description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticMastery> GetStaticMasteryByIdAsync(int id, string locale = null, string version = null, IEnumerable<string> masteryData = null, PlatformId? platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the profile icon data. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticProfileIconData> GetStaticProfileIconsAsync(PlatformId? platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the realm data. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticRealm> GetStaticRealmAsync(PlatformId? platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets a list of all available runes. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the runeListData parameter to specify which properties you want.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="runeListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticRune"/> or <see cref="StaticRuneList"/> objects. Only type, version, data, id, name, rune, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticRuneList> GetStaticRunesAsync(string locale = null, string version = null, IEnumerable<string> runeListData = null, PlatformId? platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets a rune by ID. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the runeData parameter to specify which properties you want.
        /// </summary>
        /// <param name="id">The rune ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="runeData">Tags to return additional data. Valid tags are any property of the <see cref="StaticRune"/> object. Only id, name, rune, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticRune> GetStaticRuneByIdAsync(int id, string locale = null, string version = null, IEnumerable<string> runeData = null, PlatformId? platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the details for all summoner spells. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the spellListData parameter to specify which properties you want.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="dataById">If true, the returned data map will use the spells' IDs as the keys. If false, the returned data map will use the spells' keys instead.</param>
        /// <param name="spellListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticSummonerSpell"/> or <see cref="StaticSummonerSpellList"/> objects. Only type, version, data, id, key, name, description, and summonerLevel are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticSummonerSpellList> GetStaticSummonerSpellsAsync(string locale = null, string version = null, bool dataById = false, IEnumerable<string> spellListData = null, PlatformId? platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets summoner spell details by ID. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the spellData parameter to specify which properties you want.
        /// </summary>
        /// <param name="id">The summoner spell ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="spellData">Tags to return additional data. Valid tags are any property of the <see cref="StaticSummonerSpell"/> object. Only id, key, name, description, and summonerLevel are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticSummonerSpell> GetStaticSummonerSpellByIdAsync(int id, string locale = null, string version = null, IEnumerable<string> spellData = null, PlatformId? platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the list of available game versions. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<List<string>> GetVersionsAsync(PlatformId? platformId = null, CancellationToken token = default(CancellationToken));
    }

    public partial class RiotClient
    {
        /// <summary>
        /// Gets the base URL for static data requests.
        /// </summary>
        /// <param name="platformId">The platform ID of the server to connect to. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <returns>The base URL.</returns>
        protected string GetStaticDataBaseUrl(PlatformId? platformId)
        {
            return $"https://{GetServerName(platformId)}/lol/static-data/v3";
        }

        public Task<StaticChampionList> GetStaticChampionsAsync(string locale = null, string version = null, bool dataById = false, IEnumerable<string> champListData = null, PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            var url = $"{GetStaticDataBaseUrl(platformId)}/champions";
            var queryParameters = GetStandardQueryParameters(locale, version);
            if (dataById)
                queryParameters["dataById"] = "true";

            var dataParam = CreateDataParam("champListData", champListData, typeof(StaticChampion), typeof(StaticChampionList));
            if (!string.IsNullOrEmpty(dataParam))
                url = AddQueryParam(url, dataParam);
            return GetAsync<StaticChampionList>(url, token, queryParameters);
        }

        public Task<StaticChampion> GetStaticChampionByIdAsync(int id, string locale = null, string version = null, IEnumerable<string> champData = null, PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            var url = $"{GetStaticDataBaseUrl(platformId)}/champions/{id}";
            var queryParameters = GetStandardQueryParameters(locale, version);

            var dataParam = CreateDataParam("champData", champData, typeof(StaticChampion));
            if (!string.IsNullOrEmpty(dataParam))
                url = AddQueryParam(url, dataParam);
            return GetAsync<StaticChampion>(url, token, queryParameters);
        }

        public async Task<StaticItemList> GetStaticItemsAsync(string locale = null, string version = null, IEnumerable<string> itemListData = null, PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            var url = $"{GetStaticDataBaseUrl(platformId)}/items";
            var queryParameters = GetStandardQueryParameters(locale, version);
            var dataParam = CreateDataParam("itemListData", itemListData, typeof(StaticItem), typeof(StaticItemList));
            if (!string.IsNullOrEmpty(dataParam))
                url = AddQueryParam(url, dataParam);
            var itemList = await GetAsync<StaticItemList>(url, token, queryParameters).ConfigureAwait(false);

            if (itemList == null)
                return null;

            // Add missing default values to the Maps dictionary.
            var defaultMaps = itemList.Basic.Maps;
            foreach (var item in itemList.Data.Values)
                foreach (var kvp in defaultMaps)
                    if (!item.Maps.ContainsKey(kvp.Key))
                        item.Maps.Add(kvp.Key, kvp.Value);

            return itemList;
        }

        public Task<StaticItem> GetStaticItemAsync(int id, string locale = null, string version = null, IEnumerable<string> itemData = null, PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            var url = $"{GetStaticDataBaseUrl(platformId)}/items/{id}";
            var queryParameters = GetStandardQueryParameters(locale, version);
            var dataParam = CreateDataParam("itemData", itemData, typeof(StaticItem));
            if (!string.IsNullOrEmpty(dataParam))
                url = AddQueryParam(url, dataParam);
            return GetAsync<StaticItem>(url, token, queryParameters);
        }

        public Task<List<string>> GetStaticLanguagesAsync(PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<List<string>>($"{GetStaticDataBaseUrl(platformId)}/languages", token);
        }

        public Task<StaticLanuageStrings> GetStaticLanguageStringsAsync(string locale = null, string version = null, PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            var queryParameters = GetStandardQueryParameters(locale, version);
            return GetAsync<StaticLanuageStrings>($"{GetStaticDataBaseUrl(platformId)}/language-strings", token, queryParameters);
        }

        public Task<StaticMapList> GetStaticMapsAsync(string locale = null, string version = null, PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            var queryParameters = GetStandardQueryParameters(locale, version);
            return GetAsync<StaticMapList>($"{GetStaticDataBaseUrl(platformId)}/maps", token, queryParameters);
        }

        public Task<StaticMasteryList> GetStaticMasteriesAsync(string locale = null, string version = null, IEnumerable<string> masteryListData = null, PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            var url = $"{GetStaticDataBaseUrl(platformId)}/masteries";
            var queryParameters = GetStandardQueryParameters(locale, version);
            var dataParam = CreateDataParam("masteryListData", masteryListData, typeof(StaticMastery), typeof(StaticMasteryList));
            if (!string.IsNullOrEmpty(dataParam))
                url = AddQueryParam(url, dataParam);
            return GetAsync<StaticMasteryList>(url, token, queryParameters);
        }

        public Task<StaticMastery> GetStaticMasteryByIdAsync(int id, string locale = null, string version = null, IEnumerable<string> masteryData = null, PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            var url = $"{GetStaticDataBaseUrl(platformId)}/masteries/{id}";
            var queryParameters = GetStandardQueryParameters(locale, version);
            var dataParam = CreateDataParam("masteryData", masteryData, typeof(StaticMastery));
            if (!string.IsNullOrEmpty(dataParam))
                url = AddQueryParam(url, dataParam);
            return GetAsync<StaticMastery>(url, token, queryParameters);
        }

        public Task<StaticProfileIconData> GetStaticProfileIconsAsync(PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<StaticProfileIconData>($"{GetStaticDataBaseUrl(platformId)}/profile-icons", token);
        }

        public Task<StaticRealm> GetStaticRealmAsync(PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<StaticRealm>($"{GetStaticDataBaseUrl(platformId)}/realms", token);
        }

        public async Task<StaticRuneList> GetStaticRunesAsync(string locale = null, string version = null, IEnumerable<string> runeListData = null, PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            var url = $"{GetStaticDataBaseUrl(platformId)}/runes";
            var queryParameters = GetStandardQueryParameters(locale, version);
            var dataParam = CreateDataParam("runeListData", runeListData, typeof(StaticRune), typeof(StaticRuneList));
            if (!string.IsNullOrEmpty(dataParam))
                url = AddQueryParam(url, dataParam);
            var runeList = await GetAsync<StaticRuneList>(url, token, queryParameters).ConfigureAwait(false);

            if (runeList == null)
                return null;

            // Add missing default values to the Maps dictionary.
            var defaultMaps = runeList.Basic.Maps;
            foreach (var item in runeList.Data.Values)
                foreach (var kvp in defaultMaps)
                    if (!item.Maps.ContainsKey(kvp.Key))
                        item.Maps.Add(kvp.Key, kvp.Value);

            return runeList;
        }

        public Task<StaticRune> GetStaticRuneByIdAsync(int id, string locale = null, string version = null, IEnumerable<string> runeData = null, PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            var url = $"{GetStaticDataBaseUrl(platformId)}/runes/{id}";
            var queryParameters = GetStandardQueryParameters(locale, version);
            var dataParam = CreateDataParam("runeData", runeData, typeof(StaticRune));
            if (!string.IsNullOrEmpty(dataParam))
                url = AddQueryParam(url, dataParam);
            return GetAsync<StaticRune>(url, token, queryParameters);
        }

        public Task<StaticSummonerSpellList> GetStaticSummonerSpellsAsync(string locale = null, string version = null, bool dataById = false, IEnumerable<string> spellListData = null, PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            var url = $"{GetStaticDataBaseUrl(platformId)}/summoner-spells";
            var queryParameters = GetStandardQueryParameters(locale, version);
            if (dataById)
                queryParameters["dataById"] = "true";
            var dataParam = CreateDataParam("spellListData", spellListData, typeof(StaticSummonerSpell), typeof(StaticSummonerSpellList));
            if (!string.IsNullOrEmpty(dataParam))
                url = AddQueryParam(url, dataParam);
            return GetAsync<StaticSummonerSpellList>(url, token, queryParameters);
        }

        public Task<StaticSummonerSpell> GetStaticSummonerSpellByIdAsync(int id, string locale = null, string version = null, IEnumerable<string> spellData = null, PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            var url = $"{GetStaticDataBaseUrl(platformId)}/summoner-spells/{id}";
            var queryParameters = GetStandardQueryParameters(locale, version);
            var dataParam = CreateDataParam("spellData", spellData, typeof(StaticSummonerSpell));
            if (!string.IsNullOrEmpty(dataParam))
                url = AddQueryParam(url, dataParam);
            return GetAsync<StaticSummonerSpell>(url, token, queryParameters);
        }

        public Task<List<string>> GetVersionsAsync(PlatformId? platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<List<string>>($"{GetStaticDataBaseUrl(platformId)}/versions", token);
        }

        #region Helper Methods

        private static string CreateDataParam(string name, IEnumerable<string> propertyNames, Type type, Type listType = null)
        {
            if (propertyNames == null)
                return "";
            return string.Join("&", propertyNames.Select(p => name + "=" + CorrectPropertyNameCase(p, type, listType)).Where(p => p != null));
        }

        private static string CorrectPropertyNameCase(string propertyName, Type type, Type listType = null)
        {
            if (string.IsNullOrEmpty(propertyName))
                return null;
            if (string.Equals(propertyName, "all", StringComparison.OrdinalIgnoreCase))
                return "all";

            var property = type.GetTypeInfo().GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            if (property == null && listType != null)
                property = listType.GetTypeInfo().GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            if (property != null)
            {
                // If there is a JsonProperty attribute, get the name from the attribute.
                var jsonPropertyAttribute = property.GetCustomAttribute<JsonPropertyAttribute>();
                if (jsonPropertyAttribute != null && !string.IsNullOrEmpty(jsonPropertyAttribute.PropertyName))
                    return jsonPropertyAttribute.PropertyName;
            }
            // Otherwise just convert the first letter to lowercase
            return propertyName.Remove(1).ToLowerInvariant() + propertyName.Substring(1);
        }

        private static Dictionary<string, object> GetStandardQueryParameters(string locale, string version)
        {
            var queryParameters = new Dictionary<string, object>();
            if (locale != null)
                queryParameters["locale"] = locale;
            if (version != null)
                queryParameters["version"] = version;
            return queryParameters;
        }

        #endregion
    }
}
