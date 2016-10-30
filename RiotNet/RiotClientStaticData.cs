using Newtonsoft.Json;
using RiotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace RiotNet
{
    public partial class RiotClient
    {
        private const string staticDataBaseUrl = globalBaseUrl + "/api/lol/static-data";
        private string itemListDataParam;

        /// <summary>
        /// Gets the currently supported version of the LoL Static Data API that the client communicates with.
        /// </summary>
        public string LolStaticDataApiVersion { get { return "v1.2"; } }

        #region Champions

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
        public Task<StaticChampionList> GetStaticChampionsAsync(string locale = null, string version = null, bool dataById = false, IEnumerable<string> champListData = null)
        {
            var request = $"{staticDataBaseUrl}/{region}/{LolStaticDataApiVersion}/champion";
            var queryParameters = GetStandardQueryParameters(locale, version);
            if (dataById)
                queryParameters["dataById"] = "true";
            var dataParam = CreateDataParam(champListData, typeof(StaticChampion), typeof(StaticChampionList));
            if (!string.IsNullOrEmpty(dataParam))
                queryParameters["champData"] = dataParam;
            return GetAsync<StaticChampionList>(request, queryParameters);
        }

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
        public Task<StaticChampion> GetStaticChampionByIdAsync(int id, string locale = null, string version = null, IEnumerable<string> champData = null)
        {
            var request = $"{staticDataBaseUrl}/{region}/{LolStaticDataApiVersion}/champion/{id}";
            var queryParameters = GetStandardQueryParameters(locale, version);
            if (champData != null)
            {
                var dataParam = CreateDataParam(champData, typeof(StaticChampion));
                if (!string.IsNullOrEmpty(dataParam))
                    queryParameters["champData"] = dataParam;
            }
            return GetAsync<StaticChampion>(request, queryParameters);
        }

        #endregion

        #region Items

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
        public async Task<StaticItemList> GetStaticItemsAsync(string locale = null, string version = null, IEnumerable<string> itemListData = null)
        {
            var request = $"{staticDataBaseUrl}/{region}/{LolStaticDataApiVersion}/item";
            var queryParameters = GetStandardQueryParameters(locale, version);
            var dataParam = CreateDataParam(itemListData, typeof(StaticItem), typeof(StaticItemList));
            if (!string.IsNullOrEmpty(itemListDataParam))
                queryParameters["itemListData"] = itemListDataParam;
            var itemList = await GetAsync<StaticItemList>(request, queryParameters).ConfigureAwait(false);

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
        public Task<StaticItem> GetStaticItemAsync(int id, string locale = null, string version = null, IEnumerable<string> itemData = null)
        {
            var request = $"{staticDataBaseUrl}/{region}/{LolStaticDataApiVersion}/item/{id}";
            var queryParameters = GetStandardQueryParameters(locale, version);
            var dataParam = CreateDataParam(itemData, typeof(StaticItem));
            if (!string.IsNullOrEmpty(dataParam))
                queryParameters["itemData"] = dataParam;
            return GetAsync<StaticItem>(request, queryParameters);
        }

        #endregion

        #region Languages
        
        /// <summary>
        /// Gets a list of available languages. This method uses the LoL Static Data API.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<List<string>> GetStaticLanguagesAsync()
        {
            return GetAsync<List<string>>($"{staticDataBaseUrl}/{region}/{LolStaticDataApiVersion}/languages");
        }
        
        /// <summary>
        /// Gets a list of available language strings. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<StaticLanuageStrings> GetStaticLanguageStringsAsync(string locale = null, string version = null)
        {
            var queryParameters = GetStandardQueryParameters(locale, version);
            return GetAsync<StaticLanuageStrings>($"{staticDataBaseUrl}/{region}/{LolStaticDataApiVersion}/language-strings", queryParameters);
        }

        #endregion

        #region Map
        
        /// <summary>
        /// Gets a list of all maps. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<StaticMapList> GetStaticMapsAsync(string locale = null, string version = null)
        {
            var queryParameters = GetStandardQueryParameters(locale, version);
            return GetAsync<StaticMapList>($"{staticDataBaseUrl}/{region}/{LolStaticDataApiVersion}/maps", queryParameters);
        }

        #endregion

        #region Masteries

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
        public Task<StaticMasteryList> GetStaticMasteriesAsync(string locale = null, string version = null, IEnumerable<string> masteryListData = null)
        {
            var request = $"{staticDataBaseUrl}/{region}/{LolStaticDataApiVersion}/mastery";
            var queryParameters = GetStandardQueryParameters(locale, version);
            var dataParam = CreateDataParam(masteryListData, typeof(StaticMastery), typeof(StaticMasteryList));
            if (!string.IsNullOrEmpty(dataParam))
                queryParameters["masteryListData"] = dataParam;
            return GetAsync<StaticMasteryList>(request, queryParameters);
        }

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
        public Task<StaticMastery> GetStaticMasteryByIdAsync(int id, string locale = null, string version = null, IEnumerable<string> masteryData = null)
        {
            var request = $"{staticDataBaseUrl}/{region}/{LolStaticDataApiVersion}/mastery/{id}";
            var queryParameters = GetStandardQueryParameters(locale, version);
            var dataParam = CreateDataParam(masteryData, typeof(StaticMastery));
            if (!string.IsNullOrEmpty(dataParam))
                queryParameters["masteryData"] = dataParam;
            return GetAsync<StaticMastery>(request, queryParameters);
        }

        #endregion

        #region Realm
        
        /// <summary>
        /// Gets the realm data. This method uses the LoL Static Data API.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<StaticRealm> GetStaticRealmAsync()
        {
            return GetAsync<StaticRealm>($"{staticDataBaseUrl}/{region}/{LolStaticDataApiVersion}/realm");
        }

        #endregion

        #region Runes
        
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
        public async Task<StaticRuneList> GetStaticRunesAsync(string locale = null, string version = null, IEnumerable<string> runeListData = null)
        {
            var request = $"{staticDataBaseUrl}/{region}/{LolStaticDataApiVersion}/rune";
            var queryParameters = GetStandardQueryParameters(locale, version);
            var dataParam = CreateDataParam(runeListData, typeof(StaticRune), typeof(StaticRuneList));
            if (!string.IsNullOrEmpty(dataParam))
                queryParameters["runeListData"] = dataParam;
            var runeList = await GetAsync<StaticRuneList>(request, queryParameters).ConfigureAwait(false);

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
        public Task<StaticRune> GetStaticRuneByIdAsync(int id, string locale = null, string version = null, IEnumerable<string> runeData = null)
        {
            var request = $"{staticDataBaseUrl}/{region}/{LolStaticDataApiVersion}/rune/{id}";
            var queryParameters = GetStandardQueryParameters(locale, version);
            var dataParam = CreateDataParam(runeData, typeof(StaticRune));
            if (!string.IsNullOrEmpty(dataParam))
                queryParameters["runeData"] = dataParam;
            return GetAsync<StaticRune>(request, queryParameters);
        }

        #endregion

        #region Summoner Spells

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
        public Task<StaticSummonerSpellList> GetStaticSummonerSpellsAsync(string locale = null, string version = null, bool dataById = false, IEnumerable<string> spellListData = null)
        {
            var request = $"{staticDataBaseUrl}/{region}/{LolStaticDataApiVersion}/summoner-spell";
            var queryParameters = GetStandardQueryParameters(locale, version);
            if (dataById)
                queryParameters["dataById"] = "true";
            var dataParam = CreateDataParam(spellListData, typeof(StaticSummonerSpell), typeof(StaticSummonerSpellList));
            if (!string.IsNullOrEmpty(dataParam))
                queryParameters["spellData"] = dataParam;
            return GetAsync<StaticSummonerSpellList>(request, queryParameters);
        }
        
        /// <summary>
        /// Gets summoner spell details by ID.
        /// </summary>
        /// <param name="id">The summoner spell ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="spellData">Tags to return additional data. Valid tags are any property of the <see cref="StaticSummonerSpell"/> object. Only id, key, name, description, and summonerLevel are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<StaticSummonerSpell> GetStaticSummonerSpellByIdAsync(int id, string locale = null, string version = null, IEnumerable<string> spellData = null)
        {
            var request = $"{staticDataBaseUrl}/{region}/{LolStaticDataApiVersion}/summoner-spell/{id}";
            var queryParameters = GetStandardQueryParameters(locale, version);
            var dataParam = CreateDataParam(spellData, typeof(StaticSummonerSpell));
            if (!string.IsNullOrEmpty(dataParam))
                queryParameters["spellData"] = dataParam;
            return GetAsync<StaticSummonerSpell>(request, queryParameters);
        }

        #endregion

        #region Versions
        
        /// <summary>
        /// Gets the list of available game versions. This method uses the LoL Static Data API.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<List<string>> GetVersionsAsync()
        {
            return GetAsync<List<string>>($"{staticDataBaseUrl}/{region}/{LolStaticDataApiVersion}/versions");
        }

        #endregion

        #region Helper Methods

        private static string CreateDataParam(IEnumerable<string> propertyNames, Type type, Type listType = null)
        {
            if (propertyNames == null)
                return "";
            return string.Join(",", propertyNames.Select(p => CorrectPropertyNameCase(p, type, listType)).Where(p => p != null));
        }

        private static string CorrectPropertyNameCase(string propertyName, Type type, Type listType = null)
        {
            if (string.IsNullOrEmpty(propertyName))
                return null;
            if (string.Equals(propertyName, "all", StringComparison.InvariantCultureIgnoreCase))
                return "all";

            var property = type.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            if (property == null && listType != null)
                property = listType.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
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
