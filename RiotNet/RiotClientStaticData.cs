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
        /// Gets the details for all champions. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the tags parameter to specify which properties you want.
        /// </summary>
        /// <param name="locale">Locale code for returned data. If not specified, the default locale for the region is used. This should equal one of the <see cref="Locale"/> values, or one of the values returned by <see cref="IRiotClient.GetStaticLanguagesAsync(string, System.Threading.CancellationToken)"/>.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="dataById">If true, the returned data map will use the champions' IDs as the keys. If false, the returned data map will use the champions' keys instead.</param>
        /// <param name="tags">Tags to return additional data. Valid tags are any property of the <see cref="StaticChampion"/> or <see cref="StaticChampionList"/> objects. Only type, version, data, id, name, key, and title are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticChampionList> GetStaticChampionsAsync(string locale = null, string version = null, bool dataById = false, IEnumerable<string> tags = null, string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets champion details by ID. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the tags parameter to specify which properties you want.
        /// </summary>
        /// <param name="id">The champion ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used. This should equal one of the <see cref="Locale"/> values, or one of the values returned by <see cref="IRiotClient.GetStaticLanguagesAsync(string, System.Threading.CancellationToken)"/>.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="tags">Tags to return additional data. Valid tags are any property of the <see cref="StaticChampion"/> object. Only id, name, key, and title are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticChampion> GetStaticChampionByIdAsync(int id, string locale = null, string version = null, IEnumerable<string> tags = null, string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets a list of all available items. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the tags parameter to specify which properties you want.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used. This should equal one of the <see cref="Locale"/> values, or one of the values returned by <see cref="IRiotClient.GetStaticLanguagesAsync(string, System.Threading.CancellationToken)"/>.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="tags">Tags to return additional data. Valid tags are any property of the <see cref="StaticItem"/> or <see cref="StaticItemList"/> objects. Only id, name, type, version, basic, data, plaintext, group, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticItemList> GetStaticItemsAsync(string locale = null, string version = null, IEnumerable<string> tags = null, string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets an item by its ID. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the tags parameter to specify which properties you want.
        /// </summary>
        /// <param name="id">The item ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used. This should equal one of the <see cref="Locale"/> values, or one of the values returned by <see cref="IRiotClient.GetStaticLanguagesAsync(string, System.Threading.CancellationToken)"/>.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="tags">Tags to return additional data. Valid tags are any property of the <see cref="StaticItem"/> or <see cref="StaticItemList"/> objects. Only id, name, type, version, basic, data, plaintext, group, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticItem> GetStaticItemAsync(int id, string locale = null, string version = null, IEnumerable<string> tags = null, string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets a list of available languages. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<List<string>> GetStaticLanguagesAsync(string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets a list of available language strings. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used. This should equal one of the <see cref="Locale"/> values, or one of the values returned by <see cref="IRiotClient.GetStaticLanguagesAsync(string, System.Threading.CancellationToken)"/>.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticLanuageStrings> GetStaticLanguageStringsAsync(string locale = null, string version = null, string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets a list of all maps. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used. This should equal one of the <see cref="Locale"/> values, or one of the values returned by <see cref="IRiotClient.GetStaticLanguagesAsync(string, System.Threading.CancellationToken)"/>.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticMapList> GetStaticMapsAsync(string locale = null, string version = null, string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the details for all masteries. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the tags parameter to specify which properties you want.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used. This should equal one of the <see cref="Locale"/> values, or one of the values returned by <see cref="IRiotClient.GetStaticLanguagesAsync(string, System.Threading.CancellationToken)"/>.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="tags">Tags to return additional data. Valid tags are any property of the <see cref="StaticMastery"/> or <see cref="StaticMasteryList"/> objects. Only type, version, data, id, name, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticMasteryList> GetStaticMasteriesAsync(string locale = null, string version = null, IEnumerable<string> tags = null, string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets mastery details by ID. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the tags parameter to specify which properties you want.
        /// </summary>
        /// <param name="id">The mastery ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used. This should equal one of the <see cref="Locale"/> values, or one of the values returned by <see cref="IRiotClient.GetStaticLanguagesAsync(string, System.Threading.CancellationToken)"/>.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="tags">Tags to return additional data. Valid tags are any property of the <see cref="StaticMastery"/> object. Only id, name, description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticMastery> GetStaticMasteryByIdAsync(int id, string locale = null, string version = null, IEnumerable<string> tags = null, string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the profile icon data. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticProfileIconData> GetStaticProfileIconsAsync(string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the realm data. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticRealm> GetStaticRealmAsync(string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets a list of all available runes. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the tags parameter to specify which properties you want.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used. This should equal one of the <see cref="Locale"/> values, or one of the values returned by <see cref="IRiotClient.GetStaticLanguagesAsync(string, System.Threading.CancellationToken)"/>.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="tags">Tags to return additional data. Valid tags are any property of the <see cref="StaticRune"/> or <see cref="StaticRuneList"/> objects. Only type, version, data, id, name, rune, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticRuneList> GetStaticRunesAsync(string locale = null, string version = null, IEnumerable<string> tags = null, string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets a rune by ID. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the tags parameter to specify which properties you want.
        /// </summary>
        /// <param name="id">The rune ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used. This should equal one of the <see cref="Locale"/> values, or one of the values returned by <see cref="IRiotClient.GetStaticLanguagesAsync(string, System.Threading.CancellationToken)"/>.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="tags">Tags to return additional data. Valid tags are any property of the <see cref="StaticRune"/> object. Only id, name, rune, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticRune> GetStaticRuneByIdAsync(int id, string locale = null, string version = null, IEnumerable<string> tags = null, string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the details for all summoner spells. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the tags parameter to specify which properties you want.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used. This should equal one of the <see cref="Locale"/> values, or one of the values returned by <see cref="IRiotClient.GetStaticLanguagesAsync(string, System.Threading.CancellationToken)"/>.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="dataById">If true, the returned data map will use the spells' IDs as the keys. If false, the returned data map will use the spells' keys instead.</param>
        /// <param name="tags">Tags to return additional data. Valid tags are any property of the <see cref="StaticSummonerSpell"/> or <see cref="StaticSummonerSpellList"/> objects. Only type, version, data, id, key, name, description, and summonerLevel are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticSummonerSpellList> GetStaticSummonerSpellsAsync(string locale = null, string version = null, bool dataById = false, IEnumerable<string> tags = null, string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets summoner spell details by ID. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the tags parameter to specify which properties you want.
        /// </summary>
        /// <param name="id">The summoner spell ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used. This should equal one of the <see cref="Locale"/> values, or one of the values returned by <see cref="IRiotClient.GetStaticLanguagesAsync(string, System.Threading.CancellationToken)"/>.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="tags">Tags to return additional data. Valid tags are any property of the <see cref="StaticSummonerSpell"/> object. Only id, key, name, description, and summonerLevel are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<StaticSummonerSpell> GetStaticSummonerSpellByIdAsync(int id, string locale = null, string version = null, IEnumerable<string> tags = null, string platformId = null, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the list of available game versions. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        Task<List<string>> GetVersionsAsync(string platformId = null, CancellationToken token = default(CancellationToken));
    }

    public partial class RiotClient
    {
        private const string staticDataBasePath = "static-data/v3";

        /// <summary>
        /// Gets the details for all champions. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the tags parameter to specify which properties you want.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used. This should equal one of the <see cref="Locale"/> values, or one of the values returned by <see cref="IRiotClient.GetStaticLanguagesAsync(string, System.Threading.CancellationToken)"/>.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="dataById">If true, the returned data map will use the champions' IDs as the keys. If false, the returned data map will use the champions' keys instead.</param>
        /// <param name="tags">Tags to return additional data. Valid tags are any property of the <see cref="StaticChampion"/> or <see cref="StaticChampionList"/> objects. Only type, version, data, id, name, key, and title are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<StaticChampionList> GetStaticChampionsAsync(string locale = null, string version = null, bool dataById = false, IEnumerable<string> tags = null, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            var url = $"{staticDataBasePath}/champions?dataById={(dataById ? "true" : "false")}";
            var queryParameters = GetStandardQueryParameters(locale, version);
            if (tags != null)
                queryParameters["tags"] = CreateTagsParam(tags, typeof(StaticChampion), typeof(StaticChampionList));
            return GetAsync<StaticChampionList>(url, $"{staticDataBasePath}/champions", platformId, token, queryParameters);
        }

        /// <summary>
        /// Gets champion details by ID. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the tags parameter to specify which properties you want.
        /// </summary>
        /// <param name="id">The champion ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used. This should equal one of the <see cref="Locale"/> values, or one of the values returned by <see cref="IRiotClient.GetStaticLanguagesAsync(string, System.Threading.CancellationToken)"/>.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="tags">Tags to return additional data. Valid tags are any property of the <see cref="StaticChampion"/> object. Only id, name, key, and title are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<StaticChampion> GetStaticChampionByIdAsync(int id, string locale = null, string version = null, IEnumerable<string> tags = null, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            var url = $"{staticDataBasePath}/champions/{id}";
            var queryParameters = GetStandardQueryParameters(locale, version);
            if (tags != null)
                queryParameters["tags"] = CreateTagsParam(tags, typeof(StaticChampion));
            return GetAsync<StaticChampion>(url, $"{staticDataBasePath}/champions/{{id}}", platformId, token, queryParameters);
        }

        /// <summary>
        /// Gets a list of all available items. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the tags parameter to specify which properties you want.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used. This should equal one of the <see cref="Locale"/> values, or one of the values returned by <see cref="IRiotClient.GetStaticLanguagesAsync(string, System.Threading.CancellationToken)"/>.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="tags">Tags to return additional data. Valid tags are any property of the <see cref="StaticItem"/> or <see cref="StaticItemList"/> objects. Only id, name, type, version, basic, data, plaintext, group, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<StaticItemList> GetStaticItemsAsync(string locale = null, string version = null, IEnumerable<string> tags = null, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            var url = $"{staticDataBasePath}/items";
            var queryParameters = GetStandardQueryParameters(locale, version);
            if (tags != null)
                queryParameters["tags"] = CreateTagsParam(tags, typeof(StaticItem), typeof(StaticItemList));
            return GetAsync<StaticItemList>(url, $"{staticDataBasePath}/items", platformId, token, queryParameters);
        }

        /// <summary>
        /// Gets an item by its ID. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the tags parameter to specify which properties you want.
        /// </summary>
        /// <param name="id">The item ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used. This should equal one of the <see cref="Locale"/> values, or one of the values returned by <see cref="IRiotClient.GetStaticLanguagesAsync(string, System.Threading.CancellationToken)"/>.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="tags">Tags to return additional data. Valid tags are any property of the <see cref="StaticItem"/> or <see cref="StaticItemList"/> objects. Only id, name, type, version, basic, data, plaintext, group, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<StaticItem> GetStaticItemAsync(int id, string locale = null, string version = null, IEnumerable<string> tags = null, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            var url = $"{staticDataBasePath}/items/{id}";
            var queryParameters = GetStandardQueryParameters(locale, version);
            if (tags != null)
                queryParameters["tags"] = CreateTagsParam(tags, typeof(StaticItem));
            return GetAsync<StaticItem>(url, $"{staticDataBasePath}/items/{{id}}", platformId, token, queryParameters);
        }

        /// <summary>
        /// Gets a list of available languages. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<List<string>> GetStaticLanguagesAsync(string platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<List<string>>($"{staticDataBasePath}/languages", $"{staticDataBasePath}/languages", platformId, token);
        }

        /// <summary>
        /// Gets a list of available language strings. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used. This should equal one of the <see cref="Locale"/> values, or one of the values returned by <see cref="IRiotClient.GetStaticLanguagesAsync(string, System.Threading.CancellationToken)"/>.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<StaticLanuageStrings> GetStaticLanguageStringsAsync(string locale = null, string version = null, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            var queryParameters = GetStandardQueryParameters(locale, version);
            return GetAsync<StaticLanuageStrings>($"{staticDataBasePath}/language-strings", $"{staticDataBasePath}/language-strings", platformId, token, queryParameters);
        }

        /// <summary>
        /// Gets a list of all maps. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used. This should equal one of the <see cref="Locale"/> values, or one of the values returned by <see cref="IRiotClient.GetStaticLanguagesAsync(string, System.Threading.CancellationToken)"/>.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<StaticMapList> GetStaticMapsAsync(string locale = null, string version = null, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            var queryParameters = GetStandardQueryParameters(locale, version);
            return GetAsync<StaticMapList>($"{staticDataBasePath}/maps", $"{staticDataBasePath}/maps", platformId, token, queryParameters);
        }

        /// <summary>
        /// Gets the details for all masteries. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the tags parameter to specify which properties you want.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used. This should equal one of the <see cref="Locale"/> values, or one of the values returned by <see cref="IRiotClient.GetStaticLanguagesAsync(string, System.Threading.CancellationToken)"/>.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="tags">Tags to return additional data. Valid tags are any property of the <see cref="StaticMastery"/> or <see cref="StaticMasteryList"/> objects. Only type, version, data, id, name, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<StaticMasteryList> GetStaticMasteriesAsync(string locale = null, string version = null, IEnumerable<string> tags = null, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            var url = $"{staticDataBasePath}/masteries";
            var queryParameters = GetStandardQueryParameters(locale, version);
            if (tags != null)
                queryParameters["tags"] = CreateTagsParam(tags, typeof(StaticMastery), typeof(StaticMasteryList));
            return GetAsync<StaticMasteryList>(url, $"{staticDataBasePath}/masteries", platformId, token, queryParameters);
        }

        /// <summary>
        /// Gets mastery details by ID. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the tags parameter to specify which properties you want.
        /// </summary>
        /// <param name="id">The mastery ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used. This should equal one of the <see cref="Locale"/> values, or one of the values returned by <see cref="IRiotClient.GetStaticLanguagesAsync(string, System.Threading.CancellationToken)"/>.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="tags">Tags to return additional data. Valid tags are any property of the <see cref="StaticMastery"/> object. Only id, name, description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<StaticMastery> GetStaticMasteryByIdAsync(int id, string locale = null, string version = null, IEnumerable<string> tags = null, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            var url = $"{staticDataBasePath}/masteries/{id}";
            var queryParameters = GetStandardQueryParameters(locale, version);
            if (tags != null)
                queryParameters["tags"] = CreateTagsParam(tags, typeof(StaticMastery));
            return GetAsync<StaticMastery>(url, $"{staticDataBasePath}/masteries/{{id}}", platformId, token, queryParameters);
        }

        /// <summary>
        /// Gets the profile icon data. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Note that you can use avatar.leagueoflegends.com to get anyone's profile icon using the format http://avatar.leagueoflegends.com/region/name.png (e.g., http://avatar.leagueoflegends.com/NA/RiotSchmick.png).
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<StaticProfileIconData> GetStaticProfileIconsAsync(string platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<StaticProfileIconData>($"{staticDataBasePath}/profile-icons", $"{staticDataBasePath}/profile-icons", platformId, token);
        }

        /// <summary>
        /// Gets the realm data. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<StaticRealm> GetStaticRealmAsync(string platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<StaticRealm>($"{staticDataBasePath}/realms", $"{staticDataBasePath}/realms", platformId, token);
        }

        /// <summary>
        /// Gets a list of all available runes. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the tags parameter to specify which properties you want.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used. This should equal one of the <see cref="Locale"/> values, or one of the values returned by <see cref="IRiotClient.GetStaticLanguagesAsync(string, System.Threading.CancellationToken)"/>.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="tags">Tags to return additional data. Valid tags are any property of the <see cref="StaticRune"/> or <see cref="StaticRuneList"/> objects. Only type, version, data, id, name, rune, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<StaticRuneList> GetStaticRunesAsync(string locale = null, string version = null, IEnumerable<string> tags = null, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            var url = $"{staticDataBasePath}/runes";
            var queryParameters = GetStandardQueryParameters(locale, version);
            if (tags != null)
                queryParameters["tags"] = CreateTagsParam(tags, typeof(StaticRune), typeof(StaticRuneList));
            return GetAsync<StaticRuneList>(url, $"{staticDataBasePath}/runes", platformId, token, queryParameters);
        }

        /// <summary>
        /// Gets a rune by ID. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the tags parameter to specify which properties you want.
        /// </summary>
        /// <param name="id">The rune ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used. This should equal one of the <see cref="Locale"/> values, or one of the values returned by <see cref="IRiotClient.GetStaticLanguagesAsync(string, System.Threading.CancellationToken)"/>.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="tags">Tags to return additional data. Valid tags are any property of the <see cref="StaticRune"/> object. Only id, name, rune, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<StaticRune> GetStaticRuneByIdAsync(int id, string locale = null, string version = null, IEnumerable<string> tags = null, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            var url = $"{staticDataBasePath}/runes/{id}";
            var queryParameters = GetStandardQueryParameters(locale, version);
            if (tags != null)
                queryParameters["tags"] = CreateTagsParam(tags, typeof(StaticRune));
            return GetAsync<StaticRune>(url, $"{staticDataBasePath}/runes/{{id}}", platformId, token, queryParameters);
        }

        /// <summary>
        /// Gets the details for all summoner spells. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the tags parameter to specify which properties you want.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used. This should equal one of the <see cref="Locale"/> values, or one of the values returned by <see cref="IRiotClient.GetStaticLanguagesAsync(string, System.Threading.CancellationToken)"/>.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="dataById">If true, the returned data map will use the spells' IDs as the keys. If false, the returned data map will use the spells' keys instead.</param>
        /// <param name="tags">Tags to return additional data. Valid tags are any property of the <see cref="StaticSummonerSpell"/> or <see cref="StaticSummonerSpellList"/> objects. Only type, version, data, id, key, name, description, and summonerLevel are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<StaticSummonerSpellList> GetStaticSummonerSpellsAsync(string locale = null, string version = null, bool dataById = false, IEnumerable<string> tags = null, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            var url = $"{staticDataBasePath}/summoner-spells?dataById={(dataById ? "true" : "false")}";
            var queryParameters = GetStandardQueryParameters(locale, version);
            if (tags != null)
                queryParameters["tags"] = CreateTagsParam(tags, typeof(StaticSummonerSpell), typeof(StaticSummonerSpellList));
            return GetAsync<StaticSummonerSpellList>(url, $"{staticDataBasePath}/summoner-spells", platformId, token, queryParameters);
        }

        /// <summary>
        /// Gets summoner spell details by ID. This method uses the LoL Static Data API. NOTE: Most properties are not returned by default! Use the tags parameter to specify which properties you want.
        /// </summary>
        /// <param name="id">The summoner spell ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used. This should equal one of the <see cref="Locale"/> values, or one of the values returned by <see cref="IRiotClient.GetStaticLanguagesAsync(string, System.Threading.CancellationToken)"/>.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersionsAsync"/>.</param>
        /// <param name="tags">Tags to return additional data. Valid tags are any property of the <see cref="StaticSummonerSpell"/> object. Only id, key, name, description, and summonerLevel are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<StaticSummonerSpell> GetStaticSummonerSpellByIdAsync(int id, string locale = null, string version = null, IEnumerable<string> tags = null, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            var url = $"{staticDataBasePath}/summoner-spells/{id}";
            var queryParameters = GetStandardQueryParameters(locale, version);
            if (tags != null)
                queryParameters["tags"] = CreateTagsParam(tags, typeof(StaticSummonerSpell));
            return GetAsync<StaticSummonerSpell>(url, $"{staticDataBasePath}/summoner-spells/{{id}}", platformId, token, queryParameters);
        }

        /// <summary>
        /// Gets the list of available game versions. This method uses the LoL Static Data API.
        /// </summary>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<List<string>> GetVersionsAsync(string platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<List<string>>($"{staticDataBasePath}/versions", $"{staticDataBasePath}/versions", platformId, token);
        }

        #region Helper Methods

        private static IEnumerable<string> CreateTagsParam(IEnumerable<string> propertyNames, Type type, Type listType = null)
        {
            return propertyNames.Select(p => CorrectPropertyNameCase(p, type, listType)).Where(p => p != null);
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
