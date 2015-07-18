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

        private IRestRequest GetChampionsRequest(string locale, string version, bool dataById, IEnumerable<string> champListData)
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
        /// Gets a list of all available champions.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="dataById">If true, the returned data map will use the champions' IDs as the keys. If false, the returned data map will use the champions' keys instead.</param>
        /// <param name="champListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticChampion"/> or <see cref="StaticChampionList"/> objects. Only type, version, data, id, name, key, and title are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A <see cref="StaticChampionList"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public StaticChampionList GetChampions(string locale = null, string version = null, bool dataById = false, IEnumerable<string> champListData = null)
        {
            return Execute<StaticChampionList>(GetChampionsRequest(locale, version, dataById, champListData));
        }

        /// <summary>
        /// Gets a list of all available champions.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="dataById">If true, the returned data map will use the champions' IDs as the keys. If false, the returned data map will use the champions' keys instead.</param>
        /// <param name="champListData">Tags to return additional data. Valid tags are any property of the <see cref="StaticChampion"/> or <see cref="StaticChampionList"/> objects. Only type, version, data, id, name, key, and title are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<StaticChampionList> GetChampionsTaskAsync(string locale = null, string version = null, bool dataById = false, IEnumerable<string> champListData = null)
        {
            return ExecuteTaskAsync<StaticChampionList>(GetChampionsRequest(locale, version, dataById, champListData));
        }

        private IRestRequest GetChampionByIdRequest(int id, string locale, string version, IEnumerable<string> champData)
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
        /// Gets a champion by ID.
        /// </summary>
        /// <param name="id">The champion ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersions"/>.</param>
        /// <param name="champData">Tags to return additional data. Valid tags are any property of the <see cref="StaticChampion"/> object. Only id, name, key, and title are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A <see cref="StaticChampion"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public StaticChampion GetChampionById(int id, string locale = null, string version = null, IEnumerable<string> champData = null)
        {
            return Execute<StaticChampion>(GetChampionByIdRequest(id, locale, version, champData));
        }

        /// <summary>
        /// Gets a champion by ID.
        /// </summary>
        /// <param name="id">The champion ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="champData">Tags to return additional data. Valid tags are any property of the <see cref="StaticChampion"/> object. Only id, name, key, and title are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<StaticChampion> GetChampionByIdTaskAsync(int id, string locale = null, string version = null, IEnumerable<string> champData = null)
        {
            return ExecuteTaskAsync<StaticChampion>(GetChampionByIdRequest(id, locale, version, champData));
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
        public List<string> GetLanguages(string locale = null, string version = null)
        {
            return Execute<List<string>>(GetLanguageStringsRequest(locale, version));
        }

        /// <summary>
        /// Gets a list of available languages.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<List<string>> GetLanguagesTaskAsync(string locale = null, string version = null)
        {
            return ExecuteTaskAsync<List<string>>(GetLanguageStringsRequest(locale, version));
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
        /// <param name="runeListData">Tags to return additional data. Valid tags are any property of the <see cref="Rune"/> or <see cref="RuneList"/> objects. Only type, version, data, id, name, rune, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A dictionary of runes indexed by ID.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public RuneList GetRunes(string locale = null, string version = null, IEnumerable<string> runeListData = null)
        {
            return Execute<RuneList>(GetRunesRequest(locale, version, runeListData));
        }

        /// <summary>
        /// Gets a list of all available runes.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="runeListData">Tags to return additional data. Valid tags are any property of the <see cref="Rune"/> or <see cref="RuneList"/> objects. Only type, version, data, id, name, rune, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<RuneList> GetRunesTaskAsync(string locale = null, string version = null, IEnumerable<string> runeListData = null)
        {
            return ExecuteTaskAsync<RuneList>(GetRunesRequest(locale, version, runeListData));
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
        /// <param name="runeData">Tags to return additional data. Valid tags are any property of the <see cref="Rune"/> object. Only id, name, rune, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A <see cref="Rune"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Rune GetRuneById(int id, string locale = null, string version = null, IEnumerable<string> runeData = null)
        {
            return Execute<Rune>(GetRuneByIdRequest(id, locale, version, runeData));
        }

        /// <summary>
        /// Gets a rune by ID.
        /// </summary>
        /// <param name="id">The rune ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="runeData">Tags to return additional data. Valid tags are any property of the <see cref="Rune"/> object. Only id, name, rune, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<Rune> GetRuneByIdTaskAsync(int id, string locale = null, string version = null, IEnumerable<string> runeData = null)
        {
            return ExecuteTaskAsync<Rune>(GetRuneByIdRequest(id, locale, version, runeData));
        }

        #endregion

    }
}
