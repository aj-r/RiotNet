using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RiotNet.Converters;
using RiotNet.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RiotNet
{
    /// <summary>
    /// A client that interacts with the Riot Games API.
    /// </summary>
    public partial interface IRiotClient
    {
        /// <summary>
        /// Gets the platform ID of the default server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values.
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
    }

    /// <summary>
    /// A client that interacts with the Riot Games API.
    /// </summary>
    public partial class RiotClient : IRiotClient
    {
        private readonly string platformId;
        private readonly RiotClientSettings settings;
        private readonly HttpClient client = new HttpClient();

        static RiotClient()
        {
            DefaultPlatformId = Models.PlatformId.NA1;
        }

        /// <summary>
        /// Creates a new <see cref="RiotClient"/> instance.
        /// </summary>
        public RiotClient()
            : this(DefaultSettings())
        { }

        /// <summary>
        /// Creates a new <see cref="RiotClient"/> instance.
        /// </summary>
        /// <param name="apiKey">The API key to use. NOTE: If you are using a public repository, do NOT check you API key in to the repository.
        /// It is recommended to load your API key from a separate file (e.g. key.txt) that is ignored by your repository.</param>
        public RiotClient(string apiKey)
            : this(GetSettingsForApiKey(apiKey), DefaultPlatformId)
        { }

        /// <summary>
        /// Creates a new <see cref="RiotClient"/> instance.
        /// </summary>
        /// <param name="settings">The settings to use.</param>
        public RiotClient(RiotClientSettings settings)
            : this(settings, DefaultPlatformId)
        { }

        /// <summary>
        /// Creates a new <see cref="RiotClient"/> instance.
        /// </summary>
        /// <param name="apiKey">The API key to use. NOTE: If you are using a public repository, do NOT check you API key in to the repository.
        /// <param name="platformId">The platform ID of the default server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values.</param>
        /// It is recommended to load your API key from a separate file (e.g. key.txt) that is ignored by your repository.</param>
        public RiotClient(string apiKey, string platformId)
            : this(GetSettingsForApiKey(apiKey), platformId)
        { }

        /// <summary>
        /// Creates a new <see cref="RiotClient"/> instance.
        /// </summary>
        /// <param name="platformId">The platform ID of the default server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values.</param>
        /// <param name="settings">The settings to use.</param>
        public RiotClient(RiotClientSettings settings, string platformId)
        {
            this.settings = settings;
            this.platformId = platformId;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Creates a new <see cref="RiotClient"/> instance for the specified platform ID.
        /// </summary>
        /// <param name="platformId">The platform ID of the default server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values.</param>
        /// <returns>A RiotClient.</returns>
        public static RiotClient ForPlatform(string platformId)
        {
            return new RiotClient(DefaultSettings(), platformId);
        }

        private static RiotClientSettings GetSettingsForApiKey(string apiKey)
        {
            var settings = DefaultSettings();
            settings.ApiKey = apiKey;
            return settings;
        }

        private static readonly JsonSerializerSettings jsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new RiotNetContractResolver(),
            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            Converters = new List<JsonConverter>
            {
                new EpochDateTimeConverter(),
                new KeyedCollectionConverter(),
                new TolerantIntEnumConverter(),
                new SecondsToTimeSpanConverter(),
            }
        };

        /// <summary>
        /// Gets the JsonSerializerSettings that are used to deserialize responses from the Riot API. 
        /// </summary>
        public static JsonSerializerSettings JsonSettings
        {
            get { return jsonSettings; }
        }

        /// <summary>
        /// Gets or sets the default platform ID to use when creating a new <see cref="RiotClient"/>. This should equal one of the <see cref="Models.PlatformId"/> values.
        /// </summary>
        public static string DefaultPlatformId { get; set; }

        private static Func<RiotClientSettings> defaultSettings = () => new RiotClientSettings();

        /// <summary>
        /// Gets or sets a function that defines the default <see cref="RiotClientSettings"/> to use when creating a new <see cref="RiotClient"/>.
        /// </summary>
        public static Func<RiotClientSettings> DefaultSettings
        {
            get { return defaultSettings; }
            set { defaultSettings = value ?? (() => new RiotClientSettings()); }
        }

        /// <summary>
        /// Gets the server domain name for the specified platform ID.
        /// </summary>
        /// <param name="platformId">The platform ID corresponding to the server. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <returns>The server host name.</returns>
        public string GetServerName(string platformId = null)
        {
            return (platformId ?? PlatformId) + ".api.riotgames.com";
        }

        /// <summary>
        /// Gets the platform ID of the default server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values.
        /// </summary>
        public string PlatformId
        {
            get { return platformId; }
        }

        /// <summary>
        /// Occurs when a request times out.
        /// </summary>
        public event RetryEventHandler RequestTimedOut;

        /// <summary>
        /// Occurs when the client fails to connect to the server, or when an exception occurs while executing a request.
        /// </summary>
        public event RetryEventHandler ConnectionFailed;

        /// <summary>
        /// Occurs when the client executes a request when the API rate limit has been exceeded (status code 429).
        /// </summary>
        public event RetryEventHandler RateLimitExceeded;

        /// <summary>
        /// Occurs when the server returns an error code of 500 or higher.
        /// </summary>
        public event RetryEventHandler ServerError;

        /// <summary>
        /// Occurs when a request fails because a resource was not found (status code 404).
        /// </summary>
        public event ResponseEventHandler ResourceNotFound;

        /// <summary>
        /// Occurs when a response returns an error code that does not fit into any other category, or an exception occurs during the response.
        /// </summary>
        public event ResponseEventHandler ResponseError;

        /// <summary>
        /// Gets the settings for the <see cref="RiotClient"/>.
        /// </summary>
        public RiotClientSettings Settings
        {
            get { return settings; }
        }

        /// <summary>
        /// Gets a reference to the underlying HTTP client.
        /// </summary>
        protected HttpClient Client
        {
            get { return client; }
        }

        /// <summary>
        /// Adds a query string parameters to a URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="queryParam">The query string parameter.</param>
        /// <returns>The new URL.</returns>
        protected string AddQueryParam(string url, string queryParam)
        {
            if (string.IsNullOrEmpty(queryParam))
                return url;
            return url + (url.Contains("?") ? "&" : "?") + queryParam;
        }

        /// <summary>
        /// Sends a GET request for the specified resource.
        /// </summary>
        /// <param name="resource">The resource path, relative to the base URL. Note: this method will automatically add the api_key parameter to the resource.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <param name="queryParameters">Query string parameters to append to the resource.</param>
        /// <returns>A rest request.</returns>
        protected Task<T> GetAsync<T>(string resource, CancellationToken token, IDictionary<string, object> queryParameters = null)
        {
            return ExecuteAsync<T>(HttpMethod.Get, resource, null, token, queryParameters);
        }

        /// <summary>
        /// Creates a POST request for the specified resource. The region, platformId, and api_key parameters are automatically added to the request.
        /// </summary>
        /// <param name="resource">The resource path, relative to the base URL. Note: this method will automatically add the api_key parameter to the resource.</param>
        /// <param name="body">The body of the request. This object will be serialized as a JSON string.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <param name="queryParameters">Query string parameters to append to the resource.</param>
        /// <returns>A rest request.</returns>
        protected Task<T> PostAsync<T>(string resource, object body, CancellationToken token, IDictionary<string, object> queryParameters = null)
        {
            return ExecuteAsync<T>(HttpMethod.Post, resource, body, token, queryParameters);
        }

        /// <summary>
        /// Creates a PUT request for the specified resource. The region, platformId, and api_key parameters are automatically added to the request.
        /// </summary>
        /// <param name="resource">The resource path, relative to the base URL. Note: this method will automatically add the api_key parameter to the resource.</param>
        /// <param name="body">The body of the request. This object will be serialized as a JSON string.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <param name="queryParameters">Query string parameters to append to the resource.</param>
        /// <returns>A rest request.</returns>
        protected Task<T> PutAsync<T>(string resource, object body, CancellationToken token, IDictionary<string, object> queryParameters = null)
        {
            return ExecuteAsync<T>(HttpMethod.Put, resource, body, token, queryParameters);
        }

        /// <summary>
        /// Executes a REST request asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of data to expect in the response.</typeparam>
        /// <param name="method">The HTTP method to use.</param>
        /// <param name="resource">The URL of the resource to use.</param>
        /// <param name="body">The request body. This object will be serialized as a JSON string. Pass null if the request sohuld not have a body.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <param name="queryParameters">Query string parameters to append to the resource.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        protected virtual Task<T> ExecuteAsync<T>(HttpMethod method, string resource, object body, CancellationToken token, IDictionary<string, object> queryParameters = null)
        {
            var resourceBuilder = new StringBuilder(resource);
            var querySeparator = resource.Contains("?") ? "&" : "?";
            if (queryParameters != null)
            {
                foreach (var kvp in queryParameters)
                {
                    resourceBuilder
                        .Append(querySeparator)
                        .Append(kvp.Key)
                        .Append("=")
                        .Append(kvp.Value);
                    querySeparator = "&";
                }
            }
            Func<HttpRequestMessage> buildRequest = () =>
            {
                var request = new HttpRequestMessage(method, resourceBuilder.ToString());
                request.Headers.Add("X-Riot-Token", Settings.ApiKey);
                if (body != null)
                    request.Content = new JsonContent(body);
                return request;
            };
            return ExecuteAsync<T>(buildRequest, token);
        }

        /// <summary>
        /// Executes a REST request asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of data to expect in the response.</typeparam>
        /// <param name="buildRequest">A function that builds the request to execute.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        protected virtual async Task<T> ExecuteAsync<T>(Func<HttpRequestMessage> buildRequest, CancellationToken token)
        {
            var attemptCount = 0;
            do
            {
                var request = buildRequest();
                var response = await SendAsync(request, token).ConfigureAwait(false);
                ++attemptCount;
                var action = await DetermineResponseAction(response, attemptCount, token).ConfigureAwait(false);
                if (action == ResponseAction.Return)
                    return await response.Response.Content.ReadAsAsync<T>().ConfigureAwait(false);
                if (action == ResponseAction.ReturnDefault)
                    break;
                if (action == ResponseAction.Retry)
                {
                    IEnumerable<string> retryAfterValues = null;
                    if (response.Response?.Headers.TryGetValues("Retry-After", out retryAfterValues) == true)
                    {
                        var retryAfter = retryAfterValues.First();
                        int delaySeconds;
                        if (int.TryParse(retryAfter, out delaySeconds))
                            await Task.Delay((delaySeconds + 1) * 1000).ConfigureAwait(false);
                   }
                }
            } while (attemptCount < Settings.MaxRequestAttempts);

            return default(T);
        }

        /// <summary>
        /// Sends a request.
        /// </summary>
        /// <param name="request">The request to send.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        protected async Task<RiotResponse> SendAsync(HttpRequestMessage request, CancellationToken token)
        {
            try
            {
                var response = await client.SendAsync(request, token).ConfigureAwait(false);
                return new RiotResponse(response);
            }
            catch (TaskCanceledException ex)
            {
                return new RiotResponse(null, ex, true);
            }
            catch (Exception ex)
            {
                return new RiotResponse(null, ex);
            }
        }

        /// <summary>
        /// Determines which action to take for the given response.
        /// </summary>
        /// <param name="response">An <see cref="HttpResponseMessage"/>.</param>
        /// <param name="attemptCount">The number of times the request has been attempted so far.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A <see cref="ResponseAction"/>.</returns>
        protected virtual async Task<ResponseAction> DetermineResponseAction(RiotResponse response, int attemptCount, CancellationToken token)
        {
            if (response.TimedOut)
            {
                var args = new RetryEventArgs(response, attemptCount);
                args.Retry = Settings.RetryOnTimeout;
                OnRequestTimedOut(args);
                // Note: never retry if the token is cancelled. It will certainly fail the next time, too.
                if (args.Retry && !token.IsCancellationRequested)
                    return ResponseAction.Retry;
                if (Settings.ThrowOnError)
                    throw new RestTimeoutException(response, response.Exception);
                
                return ResponseAction.ReturnDefault;
            }
            if (response.Response == null)
            {
                var args = new RetryEventArgs(response, attemptCount);
                args.Retry = Settings.RetryOnConnectionFailure;
                OnConnectionFailed(args);
                if (args.Retry)
                    return ResponseAction.Retry;
                if (Settings.ThrowOnError)
                    throw new ConnectionFailedException(response, response.Exception);
                
                return ResponseAction.ReturnDefault;
            }
            var statusCode = (int)response.Response.StatusCode;
            if (statusCode == 429)
            {
                var args = new RetryEventArgs(response, attemptCount);
                args.Retry = Settings.RetryOnRateLimitExceeded;
                OnRateLimitExceeded(args);
                if (args.Retry)
                    return ResponseAction.Retry;
                if (Settings.ThrowOnError)
                    throw new RateLimitExceededException(response);
                
                return ResponseAction.ReturnDefault;
            }
            if (statusCode == 404)
            {
                OnResourceNotFound(new ResponseEventArgs(response));
                if (Settings.ThrowOnNotFound)
                    throw new NotFoundException(response);
                
                return ResponseAction.ReturnDefault;
            }
            if (statusCode >= 500)
            {
                var args = new RetryEventArgs(response, attemptCount);
                args.Retry = Settings.RetryOnServerError;
                OnServerError(args);
                if (args.Retry)
                    return ResponseAction.Retry;
                if (Settings.ThrowOnError)
                {
                    var message = await GetServerErrorMessage(response).ConfigureAwait(false);
                    if (message != null)
                        throw new RestException(response, message);
                    else
                        throw new RestException(response);
                }

                return ResponseAction.ReturnDefault;
            }
            if (statusCode >= 400)
            {
                var message = await GetServerErrorMessage(response).ConfigureAwait(false);
                OnResponseError(new ResponseEventArgs(response, message));
                if (Settings.ThrowOnError)
                {
                    if (message != null)
                        throw new RestException(response, message, response.Exception);
                    else
                        throw new RestException(response, response.Exception);
                }
                
                return ResponseAction.ReturnDefault;
            }
            return ResponseAction.Return;
        }

        /// <summary>
        /// Gets the error message from the response body if it exists.
        /// </summary>
        /// <param name="response">The response from the server.</param>
        /// <returns>The error messsage, or null if no error message was found.</returns>
        protected static async Task<string> GetServerErrorMessage(RiotResponse response)
        {
            // Try to get the error message from the server if it exists.
            if (response?.Response?.Content == null)
                return null;

            try
            {
                JToken token;
                using (var stream = await response.Response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                using (var reader = new StreamReader(stream))
                using (var jsonReader = new JsonTextReader(reader))
                {
                    token = JToken.ReadFrom(jsonReader);
                }
                if (token["status"] is JObject)
                    token = token["status"];
                var message = token.Value<string>("message");
                return message;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Occurs when a request times out.
        /// </summary>
        /// <param name="e">Arguments for the event.</param>
        protected virtual void OnRequestTimedOut(RetryEventArgs e)
        {
            RequestTimedOut?.Invoke(this, e);
        }

        /// <summary>
        /// Occurs when the client fails to connect to the server while executing a request.
        /// </summary>
        /// <param name="e">Arguments for the event.</param>
        protected virtual void OnConnectionFailed(RetryEventArgs e)
        {
            ConnectionFailed?.Invoke(this, e);
        }

        /// <summary>
        /// Occurs when a request fails because the rate limit has been exceeded (status code 429).
        /// </summary>
        /// <param name="e">Arguments for the event.</param>
        protected virtual void OnRateLimitExceeded(RetryEventArgs e)
        {
            RateLimitExceeded?.Invoke(this, e);
        }

        /// <summary>
        /// Occurs when the server returns an error code of 500 or higher.
        /// </summary>
        /// <param name="e">Arguments for the event.</param>
        protected virtual void OnServerError(RetryEventArgs e)
        {
            ServerError?.Invoke(this, e);
        }

        /// <summary>
        /// Occurs when a request fails because a resource was not found (status code 404).
        /// </summary>
        /// <param name="e">Arguments for the event.</param>
        protected virtual void OnResourceNotFound(ResponseEventArgs e)
        {
            ResourceNotFound?.Invoke(this, e);
        }

        /// <summary>
        /// Occurs when a response returns an error code that does not fit into any other category, or an exception occurs during the response.
        /// </summary>
        /// <param name="e">Arguments for the event.</param>
        protected virtual void OnResponseError(ResponseEventArgs e)
        {
            ResponseError?.Invoke(this, e);
        }

        /// <summary>
        /// Specifies the action to take after processing a request.
        /// </summary>
        protected enum ResponseAction
        {
            /// <summary>
            /// Indicates that the response was received successfully, and its data should be returned.
            /// </summary>
            Return,
            /// <summary>
            /// Indicates that the response was NOT received successfully, and the default value of the type (null in most cases) should be returned.
            /// </summary>
            ReturnDefault,
            /// <summary>
            /// Indicates that the response was NOT received successfully, and the request should be re-sent (unless the maximum number of attempts has been exceeded).
            /// </summary>
            Retry
        }
    }
}
