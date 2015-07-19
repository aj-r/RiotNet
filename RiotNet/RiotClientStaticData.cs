using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RiotNet.Models;

namespace RiotNet
{
    public partial class RiotClient
    {
        #region Versions

        private IRestRequest GetVersionsRequest()
        {
            return Get("api/lol/static-data/{region}/v1.2/versions");
        }

        /// <summary>
        /// Gets the list of available game versions.
        /// </summary>
        /// <returns>The list of versions.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public List<string> GetVersions()
        {
            return Execute<List<string>>(GetVersionsRequest());
        }

        /// <summary>
        /// Gets the list of available game versions.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<List<string>> GetVersionsTaskAsync()
        {
            return ExecuteTaskAsync<List<string>>(GetVersionsRequest());
        }

        #endregion

        #region Champions

        private IRestRequest GetStaticChampionsRequest(string locale, string version, bool dataById, IEnumerable<string> champListData)
        {
            var request = Get("api/lol/static-data/{region}/v1.2/champion");
            if (locale != null)
                request.AddQueryParameter("locale", locale);
            if (version != null)
                request.AddQueryParameter("version", version);
            if (dataById)
                request.AddQueryParameter("dataById", dataById.ToString(CultureInfo.InvariantCulture));
            if (champListData != null)
            {
                // Force the first letter of each data point to be lower case since that is what the API is expecting.
                var champListDataParam = string.Join(",", champListData.Where(t => !string.IsNullOrEmpty(t)).Select(t => t.Remove(1).ToLowerInvariant() + t.Substring(1)));
                if (champListDataParam.Length > 0)
                    request.AddQueryParameter("champData", champListDataParam);
            }
            return request;
        }

        /// <summary>
        /// Gets the details for all champions.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="dataById">If true, the returned data map will use the champions' IDs as the keys. If false, the returned data map will use the champions' keys instead.</param>
        /// <param name="champListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticChampion"/> or <see cref="StaticChampionList"/> objects. Only type, version, data, id, name, key, and title are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A <see cref="StaticChampionList"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public StaticChampionList GetStaticChampions(string locale = null, string version = null, bool dataById = false, IEnumerable<string> champListData = null)
        {
            return Execute<StaticChampionList>(GetStaticChampionsRequest(locale, version, dataById, champListData));
        }

        /// <summary>
        /// Gets the details for all champions.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="dataById">If true, the returned data map will use the champions' IDs as the keys. If false, the returned data map will use the champions' keys instead.</param>
        /// <param name="champListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticChampion"/> or <see cref="StaticChampionList"/> objects. Only type, version, data, id, name, key, and title are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<StaticChampionList> GetStaticChampionsTaskAsync(string locale = null, string version = null, bool dataById = false, IEnumerable<string> champListData = null)
        {
            return ExecuteTaskAsync<StaticChampionList>(GetStaticChampionsRequest(locale, version, dataById, champListData));
        }

        private IRestRequest GetStaticChampionByIdRequest(int id, string locale, string version, IEnumerable<string> champData)
        {
            var request = Get("api/lol/static-data/{region}/v1.2/champion/{id}");
            request.AddUrlSegment("id", id.ToString(CultureInfo.InvariantCulture));
            if (locale != null)
                request.AddQueryParameter("locale", locale);
            if (version != null)
                request.AddQueryParameter("version", version);
            if (champData != null)
            {
                // Force the first letter of each data point to be lower case since that is what the API is expecting.
                var champDataParam = string.Join(",", champData.Where(t => !string.IsNullOrEmpty(t)).Select(t => t.Remove(1).ToLowerInvariant() + t.Substring(1)));
                if (champDataParam.Length > 0)
                    request.AddQueryParameter("champData", champDataParam);
            }
            return request;
        }

        /// <summary>
        /// Gets champion details by ID.
        /// </summary>
        /// <param name="id">The champion ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersions"/>.</param>
        /// <param name="champData">Tags to return additional data. Valid tags are any property of the <see cref="StaticChampion"/> object. Only id, name, key, and title are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A <see cref="StaticChampion"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public StaticChampion GetStaticChampionById(int id, string locale = null, string version = null, IEnumerable<string> champData = null)
        {
            return Execute<StaticChampion>(GetStaticChampionByIdRequest(id, locale, version, champData));
        }

        /// <summary>
        /// Gets champion details by ID.
        /// </summary>
        /// <param name="id">The champion ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="champData">Tags to return additional data. Valid tags are any property of the <see cref="StaticChampion"/> object. Only id, name, key, and title are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<StaticChampion> GetStaticChampionByIdTaskAsync(int id, string locale = null, string version = null, IEnumerable<string> champData = null)
        {
            return ExecuteTaskAsync<StaticChampion>(GetStaticChampionByIdRequest(id, locale, version, champData));
        }

        #endregion

        #region Items

        private IRestRequest GetItemsRequest(string locale, string version, IEnumerable<string> itemListData)
        {
            var request = Get("api/lol/static-data/{region}/v1.2/item");
            if (locale != null)
                request.AddQueryParameter("locale", locale);
            if (version != null)
                request.AddQueryParameter("version", version);
            if (itemListData != null)
            {
                // Force the first letter of each data point to be lower case since that is what the API is expecting.
                var itemListDataParam = string.Join(",", itemListData.Where(t => !string.IsNullOrEmpty(t)).Select(t => t.Remove(1).ToLowerInvariant() + t.Substring(1)));
                if (itemListDataParam.Length > 0)
                    request.AddQueryParameter("itemListData", itemListDataParam);
            }
            return request;
        }

        /// <summary>
        /// Gets a list of all available items.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersions"/>.</param>
        /// <param name="itemListData">Tags to return additional data. Valid tags are any property of the <see cref="Item"/> or <see cref="ItemList"/> objects. Only id, name, type, version, basic, data, plaintext, group, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A <see cref="ItemList"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public ItemList GetItems(string locale = null, string version = null, IEnumerable<string> itemListData = null)
        {
            var itemList = Execute<ItemList>(GetItemsRequest(locale, version, itemListData));

            // Add missing default values to the Maps dictionary.
            var defaultMaps = itemList.Basic.Maps;
            foreach (var item in itemList.Data.Values)
                foreach (var kvp in defaultMaps)
                    if (!item.Maps.ContainsKey(kvp.Key))
                        item.Maps.Add(kvp.Key, kvp.Value);

            return itemList;
        }

        /// <summary>
        /// Gets a list of all available items.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="itemListData">Tags to return additional data. Valid tags are any property of the <see cref="Item"/> or <see cref="ItemList"/> objects. Only id, name, type, version, basic, data, plaintext, group, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public async Task<ItemList> GetItemsTaskAsync(string locale = null, string version = null, IEnumerable<string> itemListData = null)
        {
            var itemList = await ExecuteTaskAsync<ItemList>(GetItemsRequest(locale, version, itemListData)).ConfigureAwait(false);

            // Add missing default values to the Maps dictionary.
            var defaultMaps = itemList.Basic.Maps;
            foreach (var item in itemList.Data.Values)
                foreach (var kvp in defaultMaps)
                    if (!item.Maps.ContainsKey(kvp.Key))
                        item.Maps.Add(kvp.Key, kvp.Value);

            return itemList;
        }

        private IRestRequest GetItemByIdRequest(int id, string locale, string version, IEnumerable<string> itemData)
        {
            var request = Get("api/lol/static-data/{region}/v1.2/item/{id}");
            request.AddUrlSegment("id", id.ToString(CultureInfo.InvariantCulture));
            if (locale != null)
                request.AddQueryParameter("locale", locale);
            if (version != null)
                request.AddQueryParameter("version", version);
            if (itemData != null)
            {
                // Force the first letter of each data point to be lower case since that is what the API is expecting.
                var itemDataParam = string.Join(",", itemData.Where(t => !string.IsNullOrEmpty(t)).Select(t => t.Remove(1).ToLowerInvariant() + t.Substring(1)));
                if (itemDataParam.Length > 0)
                    request.AddQueryParameter("itemData", itemDataParam);
            }
            return request;
        }

        /// <summary>
        /// Gets an item by ID.
        /// </summary>
        /// <param name="id">The rune ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersions"/>.</param>
        /// <param name="itemData">Tags to return additional data. Valid tags are any property of the <see cref="Item"/> object. Only id, name, runeMetaData, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A <see cref="Item"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Item GetItemById(int id, string locale = null, string version = null, IEnumerable<string> itemData = null)
        {
            return Execute<Item>(GetItemByIdRequest(id, locale, version, itemData));
        }

        /// <summary>
        /// Gets an item by ID.
        /// </summary>
        /// <param name="id">The rune ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="itemData">Tags to return additional data. Valid tags are any property of the <see cref="Item"/> object. Only id, name, runeMetaData, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<Item> GetItemByIdTaskAsync(int id, string locale = null, string version = null, IEnumerable<string> itemData = null)
        {
            return ExecuteTaskAsync<Item>(GetItemByIdRequest(id, locale, version, itemData));
        }

        #endregion

        #region Languages

        private IRestRequest GetLanguagesRequest()
        {
            return Get("api/lol/static-data/{region}/v1.2/languages");
        }

        /// <summary>
        /// Gets a list of available languages.
        /// </summary>
        /// <returns>A list of strings that represent a language.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public List<string> GetLanguages()
        {
            return Execute<List<string>>(GetLanguagesRequest());
        }

        /// <summary>
        /// Gets a list of available languages.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<List<string>> GetLanguagesTaskAsync()
        {
            return ExecuteTaskAsync<List<string>>(GetLanguagesRequest());
        }

        private IRestRequest GetLanguageStringsRequest(string locale, string version)
        {
            var request = Get("api/lol/static-data/{region}/v1.2/language-strings");
            if (locale != null)
                request.AddQueryParameter("locale", locale);
            if (version != null)
                request.AddQueryParameter("version", version);
            return request;
        }

        /// <summary>
        /// Gets a list of available language strings.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersions"/>.</param>
        /// <returns>A <see cref="LanuageStrings"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public LanuageStrings GetLanguageStrings(string locale = null, string version = null)
        {
            return Execute<LanuageStrings>(GetLanguageStringsRequest(locale, version));
        }

        /// <summary>
        /// Gets a list of available language strings.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<LanuageStrings> GetLanguageStringsTaskAsync(string locale = null, string version = null)
        {
            return ExecuteTaskAsync<LanuageStrings>(GetLanguageStringsRequest(locale, version));
        }

        #endregion

        #region Map

        private IRestRequest GetMapsRequest(string locale, string version)
        {
            var request = Get("api/lol/static-data/{region}/v1.2/map");
            if (locale != null)
                request.AddQueryParameter("locale", locale);
            if (version != null)
                request.AddQueryParameter("version", version);
            return request;
        }

        /// <summary>
        /// Gets a list of all maps.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersions"/>.</param>
        /// <returns>A <see cref="MapList"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public MapList GetMaps(string locale = null, string version = null)
        {
            return Execute<MapList>(GetMapsRequest(locale, version));
        }

        /// <summary>
        /// Gets a list of all maps.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<MapList> GetMapsTaskAsync(string locale = null, string version = null)
        {
            return ExecuteTaskAsync<MapList>(GetMapsRequest(locale, version));
        }

        #endregion

        #region Masteries

        private IRestRequest GetStaticMasteriesRequest(string locale, string version, IEnumerable<string> masteryListData)
        {
            var request = Get("api/lol/static-data/{region}/v1.2/mastery");
            if (locale != null)
                request.AddQueryParameter("locale", locale);
            if (version != null)
                request.AddQueryParameter("version", version);
            if (masteryListData != null)
            {
                // Force the first letter of each data point to be lower case since that is what the API is expecting.
                var masteryListDataParam = string.Join(",", masteryListData.Where(t => !string.IsNullOrEmpty(t)).Select(t => t.Remove(1).ToLowerInvariant() + t.Substring(1)));
                if (masteryListDataParam.Length > 0)
                    request.AddQueryParameter("masteryListData", masteryListDataParam);
            }
            return request;
        }

        /// <summary>
        /// Gets the details for all masteries.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="dataById">If true, the returned data map will use the champions' IDs as the keys. If false, the returned data map will use the champions' keys instead.</param>
        /// <param name="masteryListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticMastery"/> or <see cref="StaticMasteryList"/> objects. Only type, version, data, id, name, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A <see cref="StaticMasteryList"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public StaticMasteryList GetStaticMasteries(string locale = null, string version = null, bool dataById = false, IEnumerable<string> masteryListData = null)
        {
            return Execute<StaticMasteryList>(GetStaticChampionsRequest(locale, version, dataById, masteryListData));
        }

        /// <summary>
        /// Gets the details for all masteries.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="dataById">If true, the returned data map will use the champions' IDs as the keys. If false, the returned data map will use the champions' keys instead.</param>
        /// <param name="masteryListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticMastery"/> or <see cref="StaticMasteryList"/> objects. Only type, version, data, id, name, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<StaticMasteryList> GetStaticMasteriesTaskAsync(string locale = null, string version = null, bool dataById = false, IEnumerable<string> masteryListData = null)
        {
            return ExecuteTaskAsync<StaticMasteryList>(GetStaticChampionsRequest(locale, version, dataById, masteryListData));
        }

        private IRestRequest GetStaticMasteryByIdRequest(int id, string locale, string version, IEnumerable<string> masteryData)
        {
            var request = Get("api/lol/static-data/{region}/v1.2/champion/{id}");
            request.AddUrlSegment("id", id.ToString(CultureInfo.InvariantCulture));
            if (locale != null)
                request.AddQueryParameter("locale", locale);
            if (version != null)
                request.AddQueryParameter("version", version);
            if (masteryData != null)
            {
                // Force the first letter of each data point to be lower case since that is what the API is expecting.
                var masteryDataParam = string.Join(",", masteryData.Where(t => !string.IsNullOrEmpty(t)).Select(t => t.Remove(1).ToLowerInvariant() + t.Substring(1)));
                if (masteryDataParam.Length > 0)
                    request.AddQueryParameter("masteryData", masteryDataParam);
            }
            return request;
        }

        /// <summary>
        /// Gets mastery details by ID.
        /// </summary>
        /// <param name="id">The mastery ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersions"/>.</param>
        /// <param name="masteryData">Tags to return additional data. Valid tags are any property of the <see cref="StaticMastery"/> object. Only id, name, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A <see cref="StaticChampion"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public StaticChampion GetStaticMasteryById(int id, string locale = null, string version = null, IEnumerable<string> masteryData = null)
        {
            return Execute<StaticChampion>(GetStaticMasteryByIdRequest(id, locale, version, masteryData));
        }

        /// <summary>
        /// Gets mastery details by ID.
        /// </summary>
        /// <param name="id">The mastery ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="masteryData">Tags to return additional data. Valid tags are any property of the <see cref="StaticMastery"/> object. Only id, name, description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<StaticChampion> GetStaticMasteryByIdTaskAsync(int id, string locale = null, string version = null, IEnumerable<string> masteryData = null)
        {
            return ExecuteTaskAsync<StaticChampion>(GetStaticMasteryByIdRequest(id, locale, version, masteryData));
        }


        #endregion

        #region Runes

        private IRestRequest GetRunesRequest(string locale, string version, IEnumerable<string> runeListData)
        {
            var request = Get("api/lol/static-data/{region}/v1.2/rune");
            if (locale != null)
                request.AddQueryParameter("locale", locale);
            if (version != null)
                request.AddQueryParameter("version", version);
            if (runeListData != null)
            {
                // Force the first letter of each data point to be lower case since that is what the API is expecting.
                var itemDataParam = string.Join(",", runeListData.Where(t => !string.IsNullOrEmpty(t)).Select(t => t.Remove(1).ToLowerInvariant() + t.Substring(1)));
                if (itemDataParam.Length > 0)
                    request.AddQueryParameter("runeListData", itemDataParam);
            }
            return request;
        }

        /// <summary>
        /// Gets a list of all available runes.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersions"/>.</param>
        /// <param name="runeListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticRune"/> or <see cref="StaticRuneList"/> objects. Only type, version, data, id, name, rune, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A dictionary of runes indexed by ID.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public StaticRuneList GetRunes(string locale = null, string version = null, IEnumerable<string> runeListData = null)
        {
            var runeList = Execute<StaticRuneList>(GetRunesRequest(locale, version, runeListData));

            // Add missing default values to the Maps dictionary.
            var defaultMaps = runeList.Basic.Maps;
            foreach (var item in runeList.Data.Values)
                foreach (var kvp in defaultMaps)
                    if (!item.Maps.ContainsKey(kvp.Key))
                        item.Maps.Add(kvp.Key, kvp.Value);

            return runeList;
        }

        /// <summary>
        /// Gets a list of all available runes.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="runeListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticRune"/> or <see cref="StaticRuneList"/> objects. Only type, version, data, id, name, rune, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public async Task<StaticRuneList> GetRunesTaskAsync(string locale = null, string version = null, IEnumerable<string> runeListData = null)
        {
            var runeList = await ExecuteTaskAsync<StaticRuneList>(GetRunesRequest(locale, version, runeListData));

            // Add missing default values to the Maps dictionary.
            var defaultMaps = runeList.Basic.Maps;
            foreach (var item in runeList.Data.Values)
                foreach (var kvp in defaultMaps)
                    if (!item.Maps.ContainsKey(kvp.Key))
                        item.Maps.Add(kvp.Key, kvp.Value);

            return runeList;
        }

        private IRestRequest GetRuneByIdRequest(int id, string locale, string version, IEnumerable<string> runeData)
        {
            var request = Get("api/lol/static-data/{region}/v1.2/rune/{id}");
            request.AddUrlSegment("id", id.ToString(CultureInfo.InvariantCulture));
            if (locale != null)
                request.AddQueryParameter("locale", locale);
            if (version != null)
                request.AddQueryParameter("version", version);
            if (runeData != null)
            {
                // Force the first letter of each data point to be lower case since that is what the API is expecting.
                var runeDataParam = string.Join(",", runeData.Where(t => !string.IsNullOrEmpty(t)).Select(t => t.Remove(1).ToLowerInvariant() + t.Substring(1)));
                if (runeDataParam.Length > 0)
                    request.AddQueryParameter("runeData", runeDataParam);
            }
            return request;
        }

        /// <summary>
        /// Gets a rune by ID.
        /// </summary>
        /// <param name="id">The rune ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersions"/>.</param>
        /// <param name="runeData">Tags to return additional data. Valid tags are any property of the <see cref="StaticRune"/> object. Only id, name, rune, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A <see cref="StaticRune"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public StaticRune GetRuneById(int id, string locale = null, string version = null, IEnumerable<string> runeData = null)
        {
            return Execute<StaticRune>(GetRuneByIdRequest(id, locale, version, runeData));
        }

        /// <summary>
        /// Gets a rune by ID.
        /// </summary>
        /// <param name="id">The rune ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="runeData">Tags to return additional data. Valid tags are any property of the <see cref="StaticRune"/> object. Only id, name, rune, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<StaticRune> GetRuneByIdTaskAsync(int id, string locale = null, string version = null, IEnumerable<string> runeData = null)
        {
            return ExecuteTaskAsync<StaticRune>(GetRuneByIdRequest(id, locale, version, runeData));
        }

        #endregion

    }
}
