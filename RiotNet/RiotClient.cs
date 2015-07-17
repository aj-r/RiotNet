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
        private readonly RestSharpJsonNetSerializer serializer;

        private static readonly JsonSerializerSettings jsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new RiotNetContractResolver(),
            MissingMemberHandling = MissingMemberHandling.Ignore,
            Converters = new List<JsonConverter>
            {
                new EpochDateTimeConverter(),
                new SecondsToTimespanConverter(),
            }
        };

        /// <summary>
        /// Gets the JsonSerializerSettings that are used for requests to the Riot API. 
        /// </summary>
        public static JsonSerializerSettings JsonSettings
        {
            get { return jsonSettings; }
        }

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
        /// Gets the server name for the specified region.
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
        /// Creates a new <see cref="RiotClient"/> instance.
        /// </summary>
        public RiotClient()
            : this(Region.NA)
        { }

        /// <summary>
        /// Creates a new <see cref="RiotClient"/> instance.
        /// </summary>
        /// <param name="region">The region indicating which server to connect to.</param>
        public RiotClient(Region region)
            : this(region, RiotClientSettings.Default != null ? RiotClientSettings.Default() : new RiotClientSettings())
        { }

        /// <summary>
        /// Creates a new <see cref="RiotClient"/> instance.
        /// </summary>
        /// <param name="region">The region indicating which server to connect to.</param>
        /// <param name="settings">The settings to use.</param>
        public RiotClient(Region region, RiotClientSettings settings)
            : this(region, settings, new RestClient())
        { }

        /// <summary>
        /// Creates a new <see cref="RiotClient"/> instance.
        /// </summary>
        /// <param name="region">The region indicating which server to connect to.</param>
        /// <param name="settings">The settings to use.</param>
        /// <param name="client">The IRestClient implementation to use.</param>
        public RiotClient(Region region, RiotClientSettings settings, IRestClient client)
        {
            if (client == null)
                throw new ArgumentNullException("client");
            if (settings == null)
                throw new ArgumentNullException("settings");
            this.region = region;
            this.platformId = GetPlatformId(region);
            this.settings = settings;
            serializer = new RestSharpJsonNetSerializer(settings);

            if (client.BaseUrl == null)
                client.BaseUrl = new Uri("https://" + GetServerName(region));
            client.AddHandler("application/json", serializer);
            client.AddHandler("text/json", serializer);
            this.client = client;
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
        /// Occurs when the client executes a request when the API rate limit has been exceeded.
        /// </summary>
        public event EventHandler<RetryEventArgs> RateLimitExceeded;

        /// <summary>
        /// Occurs when the a request times out.
        /// </summary>
        public event EventHandler<RetryEventArgs> RequestTimedOut;

        /// <summary>
        /// Occurs when the client fails to connect to the server while executing a request.
        /// </summary>
        public event EventHandler<RetryEventArgs> ConnectionFailed;

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
        protected virtual T Execute<T>(IRestRequest request) where T : new()
        {
            var retry = false;
            var attemptCount = 0;
            do
            {
                var response = client.Execute<T>(request);
                ++attemptCount;
                if (response.ResponseStatus == ResponseStatus.TimedOut)
                {
                    var args = new RetryEventArgs(attemptCount);
                    OnRequestTimedOut(args);
                    if (args.Retry || Settings.RetryOnTimeout)
                    {
                        retry = true;
                        continue;
                    }
                    if (Settings.ThrowOnError)
                        throw new RestTimeoutException(response);
                    else
                        break;
                }
                if (response.ResponseStatus == ResponseStatus.Error)
                {
                    var args = new RetryEventArgs(attemptCount);
                    OnConnectionFailed(args);
                    if (args.Retry || Settings.RetryOnConnectionFailure)
                    {
                        retry = true;
                        continue;
                    }
                    if (Settings.ThrowOnError)
                        throw new ConnectionFailedException(response);
                    else
                        break;
                }
                if (response.ResponseStatus != ResponseStatus.Completed)
                    break;
                if ((int)response.StatusCode == 429)
                {
                    var args = new RetryEventArgs(attemptCount);
                    OnRateLimitExceeded(args);
                    if (args.Retry || Settings.RetryOnRateLimitExceeded)
                    {
                        retry = true;
                        Thread.Sleep(10000);
                        continue;
                    }
                    if (Settings.ThrowOnError)
                        throw new RateLimitExceededException(response);
                    else
                        break;
                }
                if (Settings.ThrowOnError && (int)response.StatusCode >= 400)
                    throw new RestException(response);
                return response.Data;
            } while (retry && attemptCount < Settings.MaxRequestAttempts);

            return default(T);
        }

        /// <summary>
        /// Executes a REST request asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of data to expect in the response.</typeparam>
        /// <param name="request">The request to execute.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        protected virtual async Task<T> ExecuteTaskAsync<T>(IRestRequest request)
        {
            var retry = false;
            var attemptCount = 0;
            do
            {
                var response = await client.ExecuteTaskAsync<T>(request).ConfigureAwait(false);
                ++attemptCount;
                if (response.ResponseStatus == ResponseStatus.TimedOut)
                {
                    var args = new RetryEventArgs(attemptCount);
                    OnRequestTimedOut(args);
                    if (args.Retry || Settings.RetryOnTimeout)
                    {
                        retry = true;
                        continue;
                    }
                    if (Settings.ThrowOnError)
                        throw new RestTimeoutException(response);
                    else
                        break;
                }
                if (response.ResponseStatus == ResponseStatus.Error)
                {
                    if (response.StatusCode == 0)
                    {
                        var args = new RetryEventArgs(attemptCount);
                        OnConnectionFailed(args);
                        if (args.Retry || Settings.RetryOnConnectionFailure)
                        {
                            retry = true;
                            continue;
                        }
                        if (Settings.ThrowOnError)
                            throw new ConnectionFailedException(response);
                        else
                            break;
                    }

                    if (Settings.ThrowOnError)
                        throw new RestException(response, response.ErrorMessage, response.ErrorException);
                    else
                        break;
                }
                if (response.ResponseStatus != ResponseStatus.Completed)
                    break;
                if ((int)response.StatusCode == 429)
                {
                    var args = new RetryEventArgs(attemptCount);
                    OnRateLimitExceeded(args);
                    if (args.Retry || Settings.RetryOnRateLimitExceeded)
                    {
                        retry = true;
                        await Task.Delay(10000).ConfigureAwait(false);
                        continue;
                    }
                    if (Settings.ThrowOnError)
                        throw new RateLimitExceededException(response);
                    else
                        break;
                }
                if (Settings.ThrowOnError && (int)response.StatusCode >= 400)
                    throw new RestException(response);
                return response.Data;
            } while (retry && attemptCount < Settings.MaxRequestAttempts);

            return default(T);
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
        /// Occurs when a request fails because the rate limit has been exceeded.
        /// </summary>
        /// <param name="e">Arguments for the event.</param>
        protected virtual void OnRateLimitExceeded(RetryEventArgs e)
        {
            if (RateLimitExceeded != null)
                RateLimitExceeded(this, e);
        }
    }
}
