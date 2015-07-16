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
        /// <param name="runeData">Tags to return additional data. Valid tags are any property of the <see cref="Rune"/> object. Only id, name, runeMetaData, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
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
        /// <param name="runeData">Tags to return additional data. Valid tags are any property of the <see cref="Rune"/> object. Only id, name, runeMetaData, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<Rune> GetRuneByIdTaskAsync(int id, string locale = null, string version = null, IEnumerable<string> runeData = null)
        {
            return ExecuteTaskAsync<Rune>(GetRuneByIdRequest(id, locale, version, runeData));
        }

        private IRestRequest GetItemsRequest(string locale, string version, IEnumerable<string> itemData)
        {
            var request = Get("api/lol/static-data/{region}/v1.2/item");
            if (locale != null)
                request.AddQueryParameter("locale", locale);
            if (version != null)
                request.AddQueryParameter("version", version);
            if (itemData != null)
            {
                // Force the first letter of each data point to be lower case since that is what the API is expecting.
                var runeDataParam = string.Join(",", itemData.Where(t => !string.IsNullOrEmpty(t)).Select(t => t.Remove(1).ToLowerInvariant() + t.Substring(1)));
                if (runeDataParam.Length > 0)
                    request.AddQueryParameter("runeData", runeDataParam);
            }
            return request;
        }

        /// <summary>
        /// Gets a list of all available items.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersions"/>.</param>
        /// <param name="itemData">Tags to return additional data. Valid tags are any property of the <see cref="Item"/> object. Only id, name, type, version, basic, data, plaintext, group, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A <see cref="ItemList"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public ItemList GetItems(string locale = null, string version = null, IEnumerable<string> itemData = null)
        {
            return Execute<ItemList>(GetItemsRequest(locale, version, itemData));
        }

        /// <summary>
        /// Gets a list of all available items.
        /// </summary>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. List of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="itemData">Tags to return additional data. Valid tags are any property of the <see cref="Item"/> object. Only id, name, type, version, basic, data, plaintext, group, and description are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<ItemList> GetItemsTaskAsync(string locale = null, string version = null, IEnumerable<string> itemData = null)
        {
            return ExecuteTaskAsync<ItemList>(GetItemsRequest(locale, version, itemData));
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
                var runeDataParam = string.Join(",", champData.Where(t => !string.IsNullOrEmpty(t)).Select(t => t.Remove(1).ToLowerInvariant() + t.Substring(1)));
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
        /// <param name="champData">Tags to return additional data. Valid tags are any property of the <see cref="Champion"/> object. Only id, name, key, and title are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A <see cref="Rune"/>.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Rune GetChampionById(int id, string locale = null, string version = null, IEnumerable<string> champData = null)
        {
            return Execute<Rune>(GetChampionByIdRequest(id, locale, version, champData));
        }

        /// <summary>
        /// Gets a rune by ID.
        /// </summary>
        /// <param name="id">The rune ID.</param>
        /// <param name="locale">Locale code for returned data (e.g., en_US, es_ES). If not specified, the default locale for the region is used.</param>
        /// <param name="version">The game version for returned data. If not specified, the latest version for the region is used. A list of valid versions can be obtained from <see cref="GetVersionsTaskAsync"/>.</param>
        /// <param name="champData">Tags to return additional data. Valid tags are any property of the <see cref="Champion"/> object. Only id, name, key, and title are returned by default if this parameter isn't specified. To return all additional data, use the tag 'all'.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Calls to this method will not count toward your API rate limit.
        /// </remarks>
        public Task<Rune> GetChampionByIdTaskAsync(int id, string locale = null, string version = null, IEnumerable<string> champData = null)
        {
            return ExecuteTaskAsync<Rune>(GetChampionByIdRequest(id, locale, version, champData));
        }

    }
}
