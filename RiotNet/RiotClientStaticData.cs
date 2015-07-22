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
        private const string staticBaseUrl = "api/lol/static-data/{region}/v1.2/";

        #region Champions

        private IRestRequest GetStaticChampionsRequest(string locale, string version, bool dataById, IEnumerable<string> champListData)
        {
            var request = Get(staticBaseUrl + "champion");
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
            var request = Get(staticBaseUrl + "champion/{id}");
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
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetStaticVersions"/>.</param>
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

        private IRestRequest GetStaticItemsRequest(string locale, string version, IEnumerable<string> itemListData)
        {
            var request = Get(staticBaseUrl + "item");
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
        /// Gets a list of all available items from the static API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetStaticVersions"/>.</param>
        /// <param name="itemListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticItem"/> or <see cref="StaticItemList"/> objects. Only id, name, type, version, basic, data, plaintext, group, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A <see cref="StaticItemList"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public StaticItemList GetStaticItems(string locale = null, string version = null, IEnumerable<string> itemListData = null)
        {
            var itemList = Execute<StaticItemList>(GetStaticItemsRequest(locale, version, itemListData));

            // Add missing default values to the Maps dictionary.
            var defaultMaps = itemList.Basic.Maps;
            foreach (var item in itemList.Data.Values)
                foreach (var kvp in defaultMaps)
                    if (!item.Maps.ContainsKey(kvp.Key))
                        item.Maps.Add(kvp.Key, kvp.Value);

            return itemList;
        }

        /// <summary>
        /// Gets a list of all available items from the static API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="itemListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticItem"/> or <see cref="StaticItemList"/> objects. Only id, name, type, version, basic, data, plaintext, group, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public async Task<StaticItemList> GetStaticItemsTaskAsync(string locale = null, string version = null, IEnumerable<string> itemListData = null)
        {
            var itemList = await ExecuteTaskAsync<StaticItemList>(GetStaticItemsRequest(locale, version, itemListData)).ConfigureAwait(false);

            // Add missing default values to the Maps dictionary.
            var defaultMaps = itemList.Basic.Maps;
            foreach (var item in itemList.Data.Values)
                foreach (var kvp in defaultMaps)
                    if (!item.Maps.ContainsKey(kvp.Key))
                        item.Maps.Add(kvp.Key, kvp.Value);

            return itemList;
        }

        private IRestRequest GetStaticItemByIdRequest(int id, string locale, string version, IEnumerable<string> itemData)
        {
            var request = Get(staticBaseUrl + "item/{id}");
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
        /// Gets an item by ID from the static API.
        /// </summary>
        /// <param name="id">The rune ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetStaticVersions"/>.</param>
        /// <param name="itemData">Tags to return additional data. Valid tags are any property of the <see cref="StaticItem"/> object. Only id, name, runeMetaData, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A <see cref="StaticItem"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public StaticItem GetStaticItemById(int id, string locale = null, string version = null, IEnumerable<string> itemData = null)
        {
            return Execute<StaticItem>(GetStaticItemByIdRequest(id, locale, version, itemData));
        }

        /// <summary>
        /// Gets an item by ID from the static API.
        /// </summary>
        /// <param name="id">The rune ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="itemData">Tags to return additional data. Valid tags are any property of the <see cref="StaticItem"/> object. Only id, name, runeMetaData, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<StaticItem> GetStaticItemByIdTaskAsync(int id, string locale = null, string version = null, IEnumerable<string> itemData = null)
        {
            return ExecuteTaskAsync<StaticItem>(GetStaticItemByIdRequest(id, locale, version, itemData));
        }

        #endregion

        #region Languages

        private IRestRequest GetStaticLanguagesRequest()
        {
            return Get(staticBaseUrl + "languages");
        }

        /// <summary>
        /// Gets a list of available languages from the static API.
        /// </summary>
        /// <returns>A list of strings that represent a language.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public List<string> GetStaticLanguages()
        {
            return Execute<List<string>>(GetStaticLanguagesRequest());
        }

        /// <summary>
        /// Gets a list of available languages from the static API.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<List<string>> GetStaticLanguagesTaskAsync()
        {
            return ExecuteTaskAsync<List<string>>(GetStaticLanguagesRequest());
        }

        private IRestRequest GetStaticLanguageStringsRequest(string locale, string version)
        {
            var request = Get(staticBaseUrl + "language-strings");
            if (locale != null)
                request.AddQueryParameter("locale", locale);
            if (version != null)
                request.AddQueryParameter("version", version);
            return request;
        }

        /// <summary>
        /// Gets a list of available language strings from the static API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetStaticVersions"/>.</param>
        /// <returns>A <see cref="StaticLanuageStrings"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public StaticLanuageStrings GetStaticLanguageStrings(string locale = null, string version = null)
        {
            return Execute<StaticLanuageStrings>(GetStaticLanguageStringsRequest(locale, version));
        }

        /// <summary>
        /// Gets a list of available language strings from the static API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<StaticLanuageStrings> GetStaticLanguageStringsTaskAsync(string locale = null, string version = null)
        {
            return ExecuteTaskAsync<StaticLanuageStrings>(GetStaticLanguageStringsRequest(locale, version));
        }

        #endregion

        #region Map

        private IRestRequest GetStaticMapsRequest(string locale, string version)
        {
            var request = Get(staticBaseUrl + "map");
            if (locale != null)
                request.AddQueryParameter("locale", locale);
            if (version != null)
                request.AddQueryParameter("version", version);
            return request;
        }

        /// <summary>
        /// Gets a list of all maps from the static API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetStaticVersions"/>.</param>
        /// <returns>A <see cref="StaticMapList"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public StaticMapList GetStaticMaps(string locale = null, string version = null)
        {
            return Execute<StaticMapList>(GetStaticMapsRequest(locale, version));
        }

        /// <summary>
        /// Gets a list of all maps from the static API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<StaticMapList> GetStaticMapsTaskAsync(string locale = null, string version = null)
        {
            return ExecuteTaskAsync<StaticMapList>(GetStaticMapsRequest(locale, version));
        }

        #endregion

        #region Masteries

        private IRestRequest GetStaticMasteriesRequest(string locale, string version, IEnumerable<string> masteryListData)
        {
            var request = Get(staticBaseUrl + "mastery");
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
        /// Gets the details for all masteries from the static API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="masteryListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticMastery"/> or <see cref="StaticMasteryList"/> objects. Only type, version, data, id, name, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A <see cref="StaticMasteryList"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public StaticMasteryList GetStaticMasteries(string locale = null, string version = null, IEnumerable<string> masteryListData = null)
        {
            return Execute<StaticMasteryList>(GetStaticMasteriesRequest(locale, version, masteryListData));
        }

        /// <summary>
        /// Gets the details for all masteries from the static API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="masteryListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticMastery"/> or <see cref="StaticMasteryList"/> objects. Only type, version, data, id, name, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<StaticMasteryList> GetStaticMasteriesTaskAsync(string locale = null, string version = null, IEnumerable<string> masteryListData = null)
        {
            return ExecuteTaskAsync<StaticMasteryList>(GetStaticMasteriesRequest(locale, version, masteryListData));
        }

        private IRestRequest GetStaticMasteryByIdRequest(int id, string locale, string version, IEnumerable<string> masteryData)
        {
            var request = Get(staticBaseUrl + "mastery/{id}");
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
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetStaticVersions"/>.</param>
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

        #region Realm

        private IRestRequest GetStaticRealmRequest()
        {
            return Get(staticBaseUrl + "realm");
        }

        /// <summary>
        /// Gets the realm data from the static API.
        /// </summary>
        /// <returns>The current realm data.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public StaticRealm GetStaticRealm()
        {
            return Execute<StaticRealm>(GetStaticRealmRequest());
        }

        /// <summary>
        /// Gets the realm data from the static API.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<StaticRealm> GetStaticRealmTaskAsync()
        {
            return ExecuteTaskAsync<StaticRealm>(GetStaticRealmRequest());
        }

        #endregion

        #region Runes

        private IRestRequest GetStaticRunesRequest(string locale, string version, IEnumerable<string> runeListData)
        {
            var request = Get(staticBaseUrl + "rune");
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
        /// Gets a list of all available runes from the static API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetStaticVersions"/>.</param>
        /// <param name="runeListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticRune"/> or <see cref="StaticRuneList"/> objects. Only type, version, data, id, name, rune, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A dictionary of runes indexed by ID.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public StaticRuneList GetStaticRunes(string locale = null, string version = null, IEnumerable<string> runeListData = null)
        {
            var runeList = Execute<StaticRuneList>(GetStaticRunesRequest(locale, version, runeListData));

            // Add missing default values to the Maps dictionary.
            var defaultMaps = runeList.Basic.Maps;
            foreach (var item in runeList.Data.Values)
                foreach (var kvp in defaultMaps)
                    if (!item.Maps.ContainsKey(kvp.Key))
                        item.Maps.Add(kvp.Key, kvp.Value);

            return runeList;
        }

        /// <summary>
        /// Gets a list of all available runes from the static API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="runeListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticRune"/> or <see cref="StaticRuneList"/> objects. Only type, version, data, id, name, rune, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public async Task<StaticRuneList> GetStaticRunesTaskAsync(string locale = null, string version = null, IEnumerable<string> runeListData = null)
        {
            var runeList = await ExecuteTaskAsync<StaticRuneList>(GetStaticRunesRequest(locale, version, runeListData)).ConfigureAwait(false);

            // Add missing default values to the Maps dictionary.
            var defaultMaps = runeList.Basic.Maps;
            foreach (var item in runeList.Data.Values)
                foreach (var kvp in defaultMaps)
                    if (!item.Maps.ContainsKey(kvp.Key))
                        item.Maps.Add(kvp.Key, kvp.Value);

            return runeList;
        }

        private IRestRequest GetStaticRuneByIdRequest(int id, string locale, string version, IEnumerable<string> runeData)
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
        /// Gets a rune by ID from the static API.
        /// </summary>
        /// <param name="id">The rune ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetStaticVersions"/>.</param>
        /// <param name="runeData">Tags to return additional data. Valid tags are any property of the <see cref="StaticRune"/> object. Only id, name, rune, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A <see cref="StaticRune"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public StaticRune GetStaticRuneById(int id, string locale = null, string version = null, IEnumerable<string> runeData = null)
        {
            return Execute<StaticRune>(GetStaticRuneByIdRequest(id, locale, version, runeData));
        }

        /// <summary>
        /// Gets a rune by ID from the static API.
        /// </summary>
        /// <param name="id">The rune ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="runeData">Tags to return additional data. Valid tags are any property of the <see cref="StaticRune"/> object. Only id, name, rune, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<StaticRune> GetStaticRuneByIdTaskAsync(int id, string locale = null, string version = null, IEnumerable<string> runeData = null)
        {
            return ExecuteTaskAsync<StaticRune>(GetStaticRuneByIdRequest(id, locale, version, runeData));
        }

        #endregion

        #region Summoner Spells

        private IRestRequest GetStaticSummonerSpellsRequest(string locale, string version, bool dataById, IEnumerable<string> spellListData)
        {
            var request = Get(staticBaseUrl + "summoner-spell");
            if (locale != null)
                request.AddQueryParameter("locale", locale);
            if (version != null)
                request.AddQueryParameter("version", version);
            if (dataById)
                request.AddQueryParameter("dataById", dataById.ToString(CultureInfo.InvariantCulture));
            if (spellListData != null)
            {
                // Force the first letter of each data point to be lower case since that is what the API is expecting.
                var spellListDataParam = string.Join(",", spellListData.Where(t => !string.IsNullOrEmpty(t)).Select(t => t.Remove(1).ToLowerInvariant() + t.Substring(1)));
                if (spellListDataParam.Length > 0)
                    request.AddQueryParameter("spellData", spellListDataParam);
            }
            return request;
        }

        /// <summary>
        /// Gets the details for all summoner spells from the static API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="dataById">If true, the returned data map will use the spells' IDs as the keys. If false, the returned data map will use the spells' keys instead.</param>
        /// <param name="spellListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticSummonerSpell"/> or <see cref="StaticSummonerSpellList"/> objects. Only type, version, data, id, key, name, description, and summonerLevel are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A <see cref="StaticSummonerSpellList"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public StaticSummonerSpellList GetStaticSummonerSpells(string locale = null, string version = null, bool dataById = false, IEnumerable<string> spellListData = null)
        {
            return Execute<StaticSummonerSpellList>(GetStaticSummonerSpellsRequest(locale, version, dataById, spellListData));
        }

        /// <summary>
        /// Gets the details for all summoner spells from the static API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="dataById">If true, the returned data map will use the spells' IDs as the keys. If false, the returned data map will use the spells' keys instead.</param>
        /// <param name="spellListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticSummonerSpell"/> or <see cref="StaticSummonerSpellList"/> objects. Only type, version, data, id, key, name, description, and summonerLevel are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<StaticSummonerSpellList> GetStaticSummonerSpellsTaskAsync(string locale = null, string version = null, bool dataById = false, IEnumerable<string> spellListData = null)
        {
            return ExecuteTaskAsync<StaticSummonerSpellList>(GetStaticSummonerSpellsRequest(locale, version, dataById, spellListData));
        }

        private IRestRequest GetStaticSummonerSpellByIdRequest(int id, string locale, string version, IEnumerable<string> spellData)
        {
            var request = Get(staticBaseUrl + "summoner-spell/{id}");
            request.AddUrlSegment("id", id.ToString(CultureInfo.InvariantCulture));
            if (locale != null)
                request.AddQueryParameter("locale", locale);
            if (version != null)
                request.AddQueryParameter("version", version);
            if (spellData != null)
            {
                // Force the first letter of each data point to be lower case since that is what the API is expecting.
                var spellDataParam = string.Join(",", spellData.Where(t => !string.IsNullOrEmpty(t)).Select(t => t.Remove(1).ToLowerInvariant() + t.Substring(1)));
                if (spellDataParam.Length > 0)
                    request.AddQueryParameter("spellData", spellDataParam);
            }
            return request;
        }

        /// <summary>
        /// Gets summoner spell details by ID.
        /// </summary>
        /// <param name="id">The summoner spell ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetStaticVersions"/>.</param>
        /// <param name="spellData">Tags to return additional data. Valid tags are any property of the <see cref="StaticSummonerSpell"/> object. Only id, key, name, description, and summonerLevel are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A <see cref="StaticSummonerSpell"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public StaticSummonerSpell GetStaticSummonerSpellById(int id, string locale = null, string version = null, IEnumerable<string> spellData = null)
        {
            return Execute<StaticSummonerSpell>(GetStaticSummonerSpellByIdRequest(id, locale, version, spellData));
        }

        /// <summary>
        /// Gets summoner spell details by ID.
        /// </summary>
        /// <param name="id">The summoner spell ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="spellData">Tags to return additional data. Valid tags are any property of the <see cref="StaticSummonerSpell"/> object. Only id, key, name, description, and summonerLevel are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<StaticSummonerSpell> GetStaticSummonerSpellByIdTaskAsync(int id, string locale = null, string version = null, IEnumerable<string> spellData = null)
        {
            return ExecuteTaskAsync<StaticSummonerSpell>(GetStaticSummonerSpellByIdRequest(id, locale, version, spellData));
        }

        #endregion

        #region Versions

        private IRestRequest GetStaticVersionsRequest()
        {
            return Get(staticBaseUrl + "versions");
        }

        /// <summary>
        /// Gets the list of available game versions from the static API.
        /// </summary>
        /// <returns>The list of versions.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public List<string> GetStaticVersions()
        {
            return Execute<List<string>>(GetStaticVersionsRequest());
        }

        /// <summary>
        /// Gets the list of available game versions from the static API.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<List<string>> GetVersionsTaskAsync()
        {
            return ExecuteTaskAsync<List<string>>(GetStaticVersionsRequest());
        }

        #endregion

    }
}
