using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RiotNet.Converters;
using RiotNet.Models;

namespace RiotNet
{
    /// <summary>
    /// A client that interacts with the Riot Games API.
    /// </summary>
    public partial class RiotClient : IRiotClient
    {
        private readonly Region region;
        private readonly string platformId;
        private readonly RiotClientSettings settings;
        private readonly IRestClient client;
        private readonly IRestClient statusClient;
        private readonly RestSharpJsonNetSerializer serializer;

        static RiotClient()
        {
            DefaultRegion = Region.NA;
        }

        /// <summary>
        /// Creates a new <see cref="RiotClient"/> instance.
        /// </summary>
        public RiotClient()
            : this(DefaultRegion)
        { }

        /// <summary>
        /// Creates a new <see cref="RiotClient"/> instance.
        /// </summary>
        /// <param name="region">The region indicating which server to connect to.</param>
        public RiotClient(Region region)
            : this(region, DefaultSettings != null ? DefaultSettings() : new RiotClientSettings())
        { }

        /// <summary>
        /// Creates a new <see cref="RiotClient"/> instance.
        /// </summary>
        /// <param name="region">The region indicating which server to connect to.</param>
        /// <param name="settings">The settings to use.</param>
        public RiotClient(Region region, RiotClientSettings settings)
            : this(region, settings, new RestClient(), new RestClient())
        { }

        /// <summary>
        /// Creates a new <see cref="RiotClient"/> instance.
        /// </summary>
        /// <param name="region">The region indicating which server to connect to.</param>
        /// <param name="settings">The settings to use.</param>
        /// <param name="client">The IRestClient implementation to use.</param>
        /// <param name="statusClient">The IRestClient implementation to use for lol-status API calls.</param>
        public RiotClient(Region region, RiotClientSettings settings, IRestClient client, IRestClient statusClient)
        {
            if (client == null)
                throw new ArgumentNullException("client");
            if (statusClient == null)
                throw new ArgumentNullException("statusClient");
            if (settings == null)
                throw new ArgumentNullException("settings");
            this.region = region;
            this.platformId = GetPlatformId(region);
            this.settings = settings;
            serializer = new RestSharpJsonNetSerializer(settings);

            if (client.BaseUrl == null)
                client.BaseUrl = new Uri("https://" + GetServerName(region));
            if (statusClient.BaseUrl == null)
                statusClient.BaseUrl = new Uri("http://status.leagueoflegends.com");
            client.AddHandler("application/json", serializer);
            client.AddHandler("text/json", serializer);
            this.client = client;
            this.statusClient = statusClient;
        }

        private static readonly JsonSerializerSettings jsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new RiotNetContractResolver(),
            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            Converters = new List<JsonConverter>
            {
                new EpochDateTimeConverter(),
                new SecondsToTimeSpanConverter(),
                new PlayerPositionConverter(),
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
        /// Gets or sets the default region to use when creating a new <see cref="RiotClient"/>.
        /// </summary>
        public static Region DefaultRegion { get; set; }

        /// <summary>
        /// Gets or sets a function that defines the default <see cref="RiotClientSettings"/> to use when creating a new <see cref="RiotClient"/>.
        /// </summary>
        public static Func<RiotClientSettings> DefaultSettings { get; set; }

        /// <summary>
        /// Gets the platform ID for the specified region.
        /// </summary>
        /// <param name="region">The region corresponding to the platform ID.</param>
        /// <returns>The platform ID.</returns>
        public static string GetPlatformId(Region region)
        {
            switch (region)
            {
                case Region.BR:
                    return "BR1";
                case Region.EUNE:
                    return "EUN1";
                case Region.EUW:
                    return "EUW1";
                case Region.KR:
                    return "KR";
                case Region.LAN:
                    return "LA1";
                case Region.LAS:
                    return "LA2";
                case Region.NA:
                    return "NA1";
                case Region.OCE:
                    return "OC1";
                case Region.TR:
                    return "TR1";
                case Region.RU:
                    return "RU";
                case Region.PBE:
                    return "PBE1";
                default:
                    throw new NotSupportedException("The region '" + region + " is not supported.");
            }
        }

        /// <summary>
        /// Gets the server domain name for the specified region.
        /// </summary>
        /// <param name="region">The region corresponding to the server.</param>
        /// <returns>The server name.</returns>
        public static string GetServerName(Region region)
        {
            switch (region)
            {
                case Region.BR:
                    return "br.api.pvp.net";
                case Region.EUNE:
                    return "eune.api.pvp.net";
                case Region.EUW:
                    return "euw.api.pvp.net";
                case Region.KR:
                    return "kr.api.pvp.net";
                case Region.LAN:
                    return "lan.api.pvp.net";
                case Region.LAS:
                    return "las.api.pvp.net";
                case Region.NA:
                    return "na.api.pvp.net";
                case Region.OCE:
                    return "oce.api.pvp.net";
                case Region.TR:
                    return "tr.api.pvp.net";
                case Region.RU:
                    return "ru.api.pvp.net";
                case Region.PBE:
                    return "pbe.api.pvp.net";
                default:
                    throw new NotSupportedException("The region '" + region + " is not supported.");
            }
        }

        /// <summary>
        /// Gets the region that the current <see cref="RiotClient"/> connects to.
        /// </summary>
        public Region Region
        {
            get { return region; }
        }

        /// <summary>
        /// Gets the platform ID of the current region.
        /// </summary>
        public string PlatformId
        {
            get { return platformId; }
        }

        /// <summary>
        /// Occurs when the client executes a request when the API rate limit has been exceeded (status code 429).
        /// </summary>
        public event RetryEventHandler RateLimitExceeded;

        /// <summary>
        /// Occurs when a request times out.
        /// </summary>
        public event RetryEventHandler RequestTimedOut;

        /// <summary>
        /// Occurs when the client fails to connect to the server, or when an exception occurs while executing a request.
        /// </summary>
        public event RetryEventHandler ConnectionFailed;

        /// <summary>
        /// Occurs when a request fails because a resource was not found (status code 404).
        /// </summary>
        public event ResponseEventHandler ResourceNotFound;

        /// <summary>
        /// Gets the settings for the <see cref="RiotClient"/>.
        /// </summary>
        public RiotClientSettings Settings
        {
            get { return settings; }
        }

        /// <summary>
        /// Gets a reference to the underlying REST client.
        /// </summary>
        protected IRestClient Client
        {
            get { return client; }
        }
        
        /// <summary>
        /// Executes a REST request synchronously.
        /// </summary>
        /// <typeparam name="T">The type of data to expect in the response.</typeparam>
        /// <param name="request">The request to execute.</param>
        /// <returns>The deserialized response.</returns>
        protected T Execute<T>(IRestRequest request) where T : new()
        {
            return Execute<T>(request, client);
        }

        /// <summary>
        /// Executes a REST request synchronously.
        /// </summary>
        /// <typeparam name="T">The type of data to expect in the response.</typeparam>
        /// <param name="request">The request to execute.</param>
        /// <param name="client">The client to use when executing the request.</param>
        /// <returns>The deserialized response.</returns>
        protected virtual T Execute<T>(IRestRequest request, IRestClient client) where T : new()
        {
            var attemptCount = 0;
            do
            {
                var response = client.Execute<T>(request);
                ++attemptCount;
                var action = DetermineResponseAction(response, attemptCount);
                if (action == ResponseAction.Return)
                    return response.Data;
                if (action == ResponseAction.ReturnDefault)
                    break;
                if (action == ResponseAction.Retry)
                {
                    var retryAfterHeader = response.Headers.FirstOrDefault(h => string.Equals(h.Name, "Retry-After", StringComparison.InvariantCultureIgnoreCase));
                    if (retryAfterHeader != null)
                    {
                        int delaySeconds;
                        if (int.TryParse(retryAfterHeader.Value as string, out delaySeconds))
                            Thread.Sleep(delaySeconds * 1000);
                    }
                }
            } while (attemptCount < Settings.MaxRequestAttempts);

            return default(T);
        }
        
        /// <summary>
        /// Executes a REST request asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of data to expect in the response.</typeparam>
        /// <param name="request">The request to execute.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        protected Task<T> ExecuteTaskAsync<T>(IRestRequest request) where T : new()
        {
            return ExecuteTaskAsync<T>(request, client);
        }

        /// <summary>
        /// Executes a REST request asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of data to expect in the response.</typeparam>
        /// <param name="request">The request to execute.</param>
        /// <param name="client">The client to use when executing the request.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        protected virtual async Task<T> ExecuteTaskAsync<T>(IRestRequest request, IRestClient client) where T : new()
        {
            var attemptCount = 0;
            do
            {
                var response = await client.ExecuteTaskAsync<T>(request).ConfigureAwait(false);
                ++attemptCount;
                var action = DetermineResponseAction(response, attemptCount);
                if (action == ResponseAction.Return)
                    return response.Data;
                if (action == ResponseAction.ReturnDefault)
                    break;
                if (action == ResponseAction.Retry)
                {
                    var retryAfterHeader = response.Headers.FirstOrDefault(h => string.Equals(h.Name, "Retry-After", StringComparison.InvariantCultureIgnoreCase));
                    if (retryAfterHeader != null)
                    {
                        int delaySeconds;
                        if (int.TryParse(retryAfterHeader.Value as string, out delaySeconds))
                            await Task.Delay(delaySeconds * 1000);
                    }
                }
            } while (attemptCount < Settings.MaxRequestAttempts);

            return default(T);
        }

        /// <summary>
        /// Determines which action to take for the given response.
        /// </summary>
        /// <param name="response">A <see cref="IRestResponse"/>.</param>
        /// <param name="attemptCount">The number of times the request has been attempted so far.</param>
        /// <returns>A <see cref="ResponseAction"/>.</returns>
        protected virtual ResponseAction DetermineResponseAction(IRestResponse response, int attemptCount)
        {
            if (response.ResponseStatus == ResponseStatus.TimedOut)
            {
                var args = new RetryEventArgs(response, attemptCount);
                args.Retry = Settings.RetryOnTimeout;
                OnRequestTimedOut(args);
                if (args.Retry)
                    return ResponseAction.Retry;
                if (Settings.ThrowOnError)
                    throw new RestTimeoutException(response);
                else
                    return ResponseAction.ReturnDefault;
            }
            if (response.ResponseStatus == ResponseStatus.Error && response.StatusCode == 0)
            {
                var args = new RetryEventArgs(response, attemptCount);
                args.Retry = Settings.RetryOnConnectionFailure;
                OnConnectionFailed(args);
                if (args.Retry)
                    return ResponseAction.Retry;
                if (Settings.ThrowOnError)
                    throw new ConnectionFailedException(response, response.ErrorException);
                else
                    return ResponseAction.ReturnDefault;
            }
            var statusCode = (int)response.StatusCode;
            if (statusCode == 429)
            {
                var args = new RetryEventArgs(response, attemptCount);
                args.Retry = Settings.RetryOnRateLimitExceeded;
                OnRateLimitExceeded(args);
                if (args.Retry)
                    return ResponseAction.Retry;
                if (Settings.ThrowOnError)
                    throw new RateLimitExceededException(response);
                else
                    return ResponseAction.ReturnDefault;
            }
            if (statusCode == 404)
            {
                OnResourceNotFound(new ResponseEventArgs(response));
                if (Settings.ThrowOnNotFound)
                    throw new NotFoundException(response);
                else
                    return ResponseAction.ReturnDefault;
            }
            if (statusCode >= 400 || response.ResponseStatus != ResponseStatus.Completed)
            {
                if (Settings.ThrowOnError)
                    throw new RestException(response, response.ErrorException);
                else
                    return ResponseAction.ReturnDefault;
            }
            return ResponseAction.Return;
        }

        /// <summary>
        /// Creates a GET request for the specified resource.
        /// </summary>
        /// <param name="resource">The resource path, relative to the base URL.</param>
        /// <returns>A rest request.</returns>
        protected IRestRequest Get(string resource)
        {
            var request = new RestRequest(resource, Method.GET) { RequestFormat = DataFormat.Json, JsonSerializer = serializer };
            request.AddUrlSegment("region", Region.ToString().ToLowerInvariant());
            request.AddUrlSegment("platformId", platformId);
            request.AddQueryParameter("api_key", Settings.ApiKey);
            return request;
        }

        /// <summary>
        /// Occurs when a request times out.
        /// </summary>
        /// <param name="e">Arguments for the event.</param>
        protected virtual void OnRequestTimedOut(RetryEventArgs e)
        {
            if (RequestTimedOut != null)
                RequestTimedOut(this, e);
        }

        /// <summary>
        /// Occurs when the client fails to connect to the server while executing a request.
        /// </summary>
        /// <param name="e">Arguments for the event.</param>
        protected virtual void OnConnectionFailed(RetryEventArgs e)
        {
            if (ConnectionFailed != null)
                ConnectionFailed(this, e);
        }

        /// <summary>
        /// Occurs when a request fails because the rate limit has been exceeded (status code 429).
        /// </summary>
        /// <param name="e">Arguments for the event.</param>
        protected virtual void OnRateLimitExceeded(RetryEventArgs e)
        {
            if (RateLimitExceeded != null)
                RateLimitExceeded(this, e);
        }

        /// <summary>
        /// Occurs when a request fails because a resource was not found (status code 404).
        /// </summary>
        /// <param name="e">Arguments for the event.</param>
        protected virtual void OnResourceNotFound(ResponseEventArgs e)
        {
            if (ResourceNotFound != null)
                ResourceNotFound(this, e);
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
            /// Indicates that the response was NOT received successfully, and the default value of the return type should be returned (null in most cases).
            /// </summary>
            ReturnDefault,
            /// <summary>
            /// Indicates that the response was NOT received successfully, and the request should be re-sent (unless the maximum number of attempts has been exceeded).
            /// </summary>
            Retry
        }
    }
}
