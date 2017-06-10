using NUnit.Framework;
using RiotNet.Models;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace RiotNet.Tests
{
    /// <summary>
    /// Tests non-request-related functionality of the <see cref="RiotClient"/>.
    /// </summary>
    [TestFixture]
    public class RiotClientErrorHandlingTests
    {
        [Test]
        public async Task ErrorHandler_ShouldReturnNull_For404()
        {
            RiotClientSettings settings = RiotClient.DefaultSettings();
            settings.ThrowOnNotFound = false;
            settings.ThrowOnError = true;

            var eventCount = 0;
            TestRiotClient client = new TestRiotClient(settings);
            await client.WaitForRetryAfterDelay(); // in case a previous test maxed out the limit

            client.MessageHandler.RespondWithStatus(HttpStatusCode.NotFound);
            client.ConnectionFailed += (s, e) => { Assert.Fail("Connection failed"); };
            client.RateLimitExceeded += (s, e) => { Assert.Fail("Rate Limit exceeded"); };
            client.RequestTimedOut += (s, e) => { Assert.Fail("Request timed out"); };
            client.ResourceNotFound += (s, e) => { ++eventCount; };
            client.ResponseError += (s, e) => { Assert.Fail("Response contained an error"); };
            client.ServerError += (s, e) => { Assert.Fail("Response contained a server error"); };

            ShardStatus result = await client.GetShardDataAsync();

            Assert.That(result, Is.Null);
            Assert.That(eventCount, Is.EqualTo(1), "Event was raised wrong number of times.");
        }

        [Test]
        public async Task ErrorHandler_ShouldThrowError_For404()
        {
            RiotClientSettings settings = RiotClient.DefaultSettings();
            settings.ThrowOnNotFound = true;
            settings.ThrowOnError = false;

            var eventCount = 0;
            TestRiotClient client = new TestRiotClient(settings);
            await client.WaitForRetryAfterDelay(); // in case a previous test maxed out the limit

            client.MessageHandler.RespondWithStatus(HttpStatusCode.NotFound);
            client.ConnectionFailed += (s, e) => { Assert.Fail("Connection failed"); };
            client.RateLimitExceeded += (s, e) => { Assert.Fail("Rate Limit exceeded"); };
            client.RequestTimedOut += (s, e) => { Assert.Fail("Request timed out"); };
            client.ResourceNotFound += (s, e) => { ++eventCount; };
            client.ResponseError += (s, e) => { Assert.Fail("Response contained an error"); };
            client.ServerError += (s, e) => { Assert.Fail("Response contained a server error"); };

            Task<ShardStatus> task = client.GetShardDataAsync();
            Assert.That((AsyncTestDelegate)(() => task), Throws.InstanceOf<NotFoundException>());
            try
            {
                ShardStatus result = await task;
            }
            catch { }
            Assert.That(eventCount, Is.EqualTo(1), "Event was raised wrong number of times.");
        }

        [Test]
        public async Task ErrorHandler_ShouldReturnNull_For429()
        {
            RiotClientSettings settings = RiotClient.DefaultSettings();
            settings.ThrowOnError = false;
            settings.RetryOnRateLimitExceeded = false;

            var eventCount = 0;
            TestRiotClient client = new TestRiotClient(settings);
            await client.WaitForRetryAfterDelay(); // in case a previous test maxed out the limit

            client.MessageHandler.RespondWithStatus((HttpStatusCode)429);
            client.ConnectionFailed += (s, e) => { Assert.Fail("Connection failed"); };
            client.RateLimitExceeded += (s, e) => { ++eventCount; };
            client.RequestTimedOut += (s, e) => { Assert.Fail("Request timed out"); };
            client.ResourceNotFound += (s, e) => { Assert.Fail("Not found"); };
            client.ResponseError += (s, e) => { Assert.Fail("Response contained an error"); };
            client.ServerError += (s, e) => { Assert.Fail("Response contained a server error"); };

            ShardStatus result = await client.GetShardDataAsync();

            Assert.That(result, Is.Null);
            Assert.That(eventCount, Is.EqualTo(1), "Event was raised wrong number of times.");
        }

        [Test]
        public async Task ErrorHandler_ShouldThrowError_For429()
        {
            RiotClientSettings settings = RiotClient.DefaultSettings();
            settings.ThrowOnError = true;
            settings.RetryOnRateLimitExceeded = false;

            var eventCount = 0;
            TestRiotClient client = new TestRiotClient(settings);
            await client.WaitForRetryAfterDelay(); // in case a previous test maxed out the limit

            client.MessageHandler.RespondWithStatus((HttpStatusCode)429);
            client.ConnectionFailed += (s, e) => { Assert.Fail("Connection failed"); };
            client.RateLimitExceeded += (s, e) => { ++eventCount; };
            client.RequestTimedOut += (s, e) => { Assert.Fail("Request timed out"); };
            client.ResourceNotFound += (s, e) => { Assert.Fail("Not found"); };
            client.ResponseError += (s, e) => { Assert.Fail("Response contained an error"); };
            client.ServerError += (s, e) => { Assert.Fail("Response contained a server error"); };

            Task<ShardStatus> task = client.GetShardDataAsync();
            Assert.That((AsyncTestDelegate)(() => task), Throws.InstanceOf<RateLimitExceededException>());
            try
            {
                ShardStatus result = await task;
            }
            catch { }
            Assert.That(eventCount, Is.EqualTo(1), "Event was raised wrong number of times.");
        }

        [Test]
        public async Task ErrorHandler_ShouldRetry_For429()
        {
            RiotClientSettings settings = RiotClient.DefaultSettings();
            settings.ThrowOnError = true;
            settings.RetryOnRateLimitExceeded = true;
            settings.MaxRequestAttempts = 4;

            var eventCount = 0;
            TestRiotClient client = new TestRiotClient(settings);
            await client.WaitForRetryAfterDelay(); // in case a previous test maxed out the limit

            client.MessageHandler.RespondWithStatus((HttpStatusCode)429)
                .ThenWithStatus((HttpStatusCode)429)
                .ThenWithStatus((HttpStatusCode)429)
                .ThenWithStatus(HttpStatusCode.OK);
            client.ConnectionFailed += (s, e) => { Assert.Fail("Connection failed"); };
            client.RateLimitExceeded += (s, e) => { ++eventCount; };
            client.RequestTimedOut += (s, e) => { Assert.Fail("Request timed out"); };
            client.ResourceNotFound += (s, e) => { Assert.Fail("Not found"); };
            client.ResponseError += (s, e) => { Assert.Fail("Response contained an error"); };
            client.ServerError += (s, e) => { Assert.Fail("Response contained a server error"); };

            try
            {
                ShardStatus result = await client.GetShardDataAsync();
            }
            catch { }
            Assert.That(eventCount, Is.EqualTo(3), "Event was raised wrong number of times.");
        }

        [Test]
        public async Task ErrorHandler_ShouldSuppressRetry_For429()
        {
            RiotClientSettings settings = RiotClient.DefaultSettings();
            settings.ThrowOnError = true;
            settings.RetryOnRateLimitExceeded = true;
            settings.MaxRequestAttempts = 4;

            var eventCount = 0;
            TestRiotClient client = new TestRiotClient(settings);
            await client.WaitForRetryAfterDelay(); // in case a previous test maxed out the limit

            client.MessageHandler.RespondWithStatus((HttpStatusCode)429);
            client.ConnectionFailed += (s, e) => { Assert.Fail("Connection failed"); };
            client.RateLimitExceeded += (s, e) =>
            {
                ++eventCount;
                e.Retry = false;
            };
            client.RequestTimedOut += (s, e) => { Assert.Fail("Request timed out"); };
            client.ResourceNotFound += (s, e) => { Assert.Fail("Not found"); };
            client.ResponseError += (s, e) => { Assert.Fail("Response contained an error"); };
            client.ServerError += (s, e) => { Assert.Fail("Response contained a server error"); };

            try
            {
                ShardStatus result = await client.GetShardDataAsync();
            }
            catch { }
            Assert.That(eventCount, Is.EqualTo(1), "Event was raised wrong number of times.");
        }

        [Test]
        public async Task ErrorHandler_ShouldReturnNull_For400()
        {
            RiotClientSettings settings = RiotClient.DefaultSettings();
            settings.ThrowOnError = false;

            var eventCount = 0;
            TestRiotClient client = new TestRiotClient(settings);
            await client.WaitForRetryAfterDelay(); // in case a previous test maxed out the limit

            client.MessageHandler.RespondWithStatus(HttpStatusCode.BadRequest);
            client.ConnectionFailed += (s, e) => { Assert.Fail("Connection failed"); };
            client.RateLimitExceeded += (s, e) => { Assert.Fail("Rate limit exceeded"); };
            client.RequestTimedOut += (s, e) => { Assert.Fail("Request timed out"); };
            client.ResourceNotFound += (s, e) => { Assert.Fail("Not found"); };
            client.ResponseError += (s, e) => { ++eventCount; };
            client.ServerError += (s, e) => { Assert.Fail("Response contained a server error"); };

            ShardStatus result = await client.GetShardDataAsync();

            Assert.That(result, Is.Null);
            Assert.That(eventCount, Is.EqualTo(1), "Event was raised wrong number of times.");
        }

        [Test]
        public async Task ErrorHandler_ShouldThrowError_For400()
        {
            RiotClientSettings settings = RiotClient.DefaultSettings();
            settings.ThrowOnError = true;

            var eventCount = 0;
            TestRiotClient client = new TestRiotClient(settings);
            await client.WaitForRetryAfterDelay(); // in case a previous test maxed out the limit

            client.MessageHandler.RespondWithStatus(HttpStatusCode.BadRequest);
            client.ConnectionFailed += (s, e) => { Assert.Fail("Connection failed"); };
            client.RateLimitExceeded += (s, e) => { Assert.Fail("Rate limit exceeded"); };
            client.RequestTimedOut += (s, e) => { Assert.Fail("Request timed out"); };
            client.ResourceNotFound += (s, e) => { Assert.Fail("Not found"); };
            client.ResponseError += (s, e) => { ++eventCount; };
            client.ServerError += (s, e) => { Assert.Fail("Response contained a server error"); };

            Task<ShardStatus> task = client.GetShardDataAsync();
            Assert.That((AsyncTestDelegate)(() => task), Throws.InstanceOf<RestException>());
            try
            {
                ShardStatus result = await task;
            }
            catch { }
            Assert.That(eventCount, Is.EqualTo(1), "Event was raised wrong number of times.");
        }

        [Test]
        public async Task ErrorHandler_ShouldReturnNull_For503()
        {
            RiotClientSettings settings = RiotClient.DefaultSettings();
            settings.ThrowOnError = false;
            settings.RetryOnServerError = false;

            var eventCount = 0;
            TestRiotClient client = new TestRiotClient(settings);
            await client.WaitForRetryAfterDelay(); // in case a previous test maxed out the limit

            client.MessageHandler.RespondWithStatus(HttpStatusCode.ServiceUnavailable);
            client.ConnectionFailed += (s, e) => { Assert.Fail("Connection failed"); };
            client.RateLimitExceeded += (s, e) => { Assert.Fail("Rate limit exceeded"); };
            client.RequestTimedOut += (s, e) => { Assert.Fail("Request timed out"); };
            client.ResourceNotFound += (s, e) => { Assert.Fail("Not found"); };
            client.ResponseError += (s, e) => { Assert.Fail("Response contained an error"); };
            client.ServerError += (s, e) => { ++eventCount; };

            ShardStatus result = await client.GetShardDataAsync();

            Assert.That(result, Is.Null);
            Assert.That(eventCount, Is.EqualTo(1), "Event was raised wrong number of times.");
        }

        [Test]
        public async Task ErrorHandler_ShouldThrowError_For503()
        {
            RiotClientSettings settings = RiotClient.DefaultSettings();
            settings.ThrowOnError = true;
            settings.RetryOnServerError = false;

            var eventCount = 0;
            TestRiotClient client = new TestRiotClient(settings);
            await client.WaitForRetryAfterDelay(); // in case a previous test maxed out the limit

            client.MessageHandler.RespondWithStatus(HttpStatusCode.ServiceUnavailable);
            client.ConnectionFailed += (s, e) => { Assert.Fail("Connection failed"); };
            client.RateLimitExceeded += (s, e) => { Assert.Fail("Rate limit exceeded"); };
            client.RequestTimedOut += (s, e) => { Assert.Fail("Request timed out"); };
            client.ResourceNotFound += (s, e) => { Assert.Fail("Not found"); };
            client.ResponseError += (s, e) => { Assert.Fail("Response contained an error"); };
            client.ServerError += (s, e) => { ++eventCount; };

            Task<ShardStatus> task = client.GetShardDataAsync();
            Assert.That((AsyncTestDelegate)(() => task), Throws.InstanceOf<RestException>());
            try
            {
                ShardStatus result = await task;
            }
            catch { }
            Assert.That(eventCount, Is.EqualTo(1), "Event was raised wrong number of times.");
        }

        [Test]
        public async Task ErrorHandler_ShouldRetry_For503()
        {
            RiotClientSettings settings = RiotClient.DefaultSettings();
            settings.ThrowOnError = true;
            settings.RetryOnServerError = true;
            settings.MaxRequestAttempts = 2;

            var eventCount = 0;
            TestRiotClient client = new TestRiotClient(settings);
            await client.WaitForRetryAfterDelay(); // in case a previous test maxed out the limit

            client.MessageHandler.RespondWithStatus(HttpStatusCode.ServiceUnavailable);
            client.ConnectionFailed += (s, e) => { Assert.Fail("Connection failed"); };
            client.RateLimitExceeded += (s, e) => { Assert.Fail("Rate limit exceeded"); };
            client.RequestTimedOut += (s, e) => { Assert.Fail("Request timed out"); };
            client.ResourceNotFound += (s, e) => { Assert.Fail("Not found"); };
            client.ResponseError += (s, e) => { Assert.Fail("Response contained an error"); };
            client.ServerError += (s, e) => { ++eventCount; };

            try
            {
                ShardStatus result = await client.GetShardDataAsync();
            }
            catch { }
            Assert.That(eventCount, Is.EqualTo(2), "Event was raised wrong number of times.");
        }

        [Test]
        public async Task ErrorHandler_ShouldSuppressRetry_For503()
        {
            RiotClientSettings settings = RiotClient.DefaultSettings();
            settings.ThrowOnError = true;
            settings.RetryOnServerError = true;
            settings.MaxRequestAttempts = 2;

            var eventCount = 0;
            TestRiotClient client = new TestRiotClient(settings);
            await client.WaitForRetryAfterDelay(); // in case a previous test maxed out the limit

            client.MessageHandler.RespondWithStatus(HttpStatusCode.ServiceUnavailable);
            client.ConnectionFailed += (s, e) => { Assert.Fail("Connection failed"); };
            client.RateLimitExceeded += (s, e) => { Assert.Fail("Rate limit exceeded"); };
            client.RequestTimedOut += (s, e) => { Assert.Fail("Request timed out"); };
            client.ResourceNotFound += (s, e) => { Assert.Fail("Not found"); };
            client.ResponseError += (s, e) => { Assert.Fail("Response contained an error"); };
            client.ServerError += (s, e) =>
            {
                ++eventCount;
                e.Retry = false;
            };

            try
            {
                ShardStatus result = await client.GetShardDataAsync();
            }
            catch { }
            Assert.That(eventCount, Is.EqualTo(1), "Event was raised wrong number of times.");
        }

        [Test]
        public async Task ErrorHandler_ShouldReturnNull_ForConnectionFailure()
        {
            RiotClientSettings settings = RiotClient.DefaultSettings();
            settings.ThrowOnError = false;
            settings.RetryOnConnectionFailure = false;

            var eventCount = 0;
            TestRiotClient client = new TestRiotClient(settings);
            await client.WaitForRetryAfterDelay(); // in case a previous test maxed out the limit

            client.MessageHandler.FailConnection();
            client.ConnectionFailed += (s, e) => { ++eventCount; };
            client.RequestTimedOut += (s, e) => { Assert.Fail("Request timed out"); };
            client.ResourceNotFound += (s, e) => { Assert.Fail("Not found"); };
            client.ResponseError += (s, e) => { Assert.Fail("Response contained an error"); };
            client.ServerError += (s, e) => { Assert.Fail("Response contained a server error"); };

            ShardStatus result = await client.GetShardDataAsync();

            Assert.That(result, Is.Null);
            Assert.That(eventCount, Is.EqualTo(1), "Event was raised wrong number of times.");
        }

        [Test]
        public async Task ErrorHandler_ShouldThrowError_ForConnectionFailure()
        {
            RiotClientSettings settings = RiotClient.DefaultSettings();
            settings.ThrowOnError = true;
            settings.RetryOnConnectionFailure = false;

            var eventCount = 0;
            TestRiotClient client = new TestRiotClient(settings);
            await client.WaitForRetryAfterDelay(); // in case a previous test maxed out the limit

            client.MessageHandler.FailConnection();
            client.ConnectionFailed += (s, e) => { ++eventCount; };
            client.RequestTimedOut += (s, e) => { Assert.Fail("Request timed out"); };
            client.ResourceNotFound += (s, e) => { Assert.Fail("Not found"); };
            client.ResponseError += (s, e) => { Assert.Fail("Response contained an error"); };
            client.ServerError += (s, e) => { Assert.Fail("Response contained a server error"); };

            Task<ShardStatus> task = client.GetShardDataAsync();
            Assert.That((AsyncTestDelegate)(() => task), Throws.InstanceOf<ConnectionFailedException>());
            try
            {
                ShardStatus result = await task;
            }
            catch { }
            Assert.That(eventCount, Is.EqualTo(1), "Event was raised wrong number of times.");
        }

        [Test]
        public async Task ErrorHandler_ShouldRetry_ForConnectionFailure()
        {
            RiotClientSettings settings = RiotClient.DefaultSettings();
            settings.ThrowOnError = true;
            settings.RetryOnConnectionFailure = true;
            settings.MaxRequestAttempts = 2;

            var eventCount = 0;
            TestRiotClient client = new TestRiotClient(settings);
            await client.WaitForRetryAfterDelay(); // in case a previous test maxed out the limit

            client.MessageHandler.FailConnection();
            client.ConnectionFailed += (s, e) => { ++eventCount; };
            client.RequestTimedOut += (s, e) => { Assert.Fail("Request timed out"); };
            client.ResourceNotFound += (s, e) => { Assert.Fail("Not found"); };
            client.ResponseError += (s, e) => { Assert.Fail("Response contained an error"); };
            client.ServerError += (s, e) => { Assert.Fail("Response contained a server error"); };

            try
            {
                ShardStatus result = await client.GetShardDataAsync();
            }
            catch { }
            Assert.That(eventCount, Is.EqualTo(2), "Event was raised wrong number of times.");
        }

        [Test]
        public async Task ErrorHandler_ShouldSuppressRetry_ForConnectionFailure()
        {
            RiotClientSettings settings = RiotClient.DefaultSettings();
            settings.ThrowOnError = true;
            settings.RetryOnConnectionFailure = true;
            settings.MaxRequestAttempts = 2;

            var eventCount = 0;
            TestRiotClient client = new TestRiotClient(settings);
            await client.WaitForRetryAfterDelay(); // in case a previous test maxed out the limit

            client.MessageHandler.FailConnection();
            client.ConnectionFailed += (s, e) =>
            {
                ++eventCount;
                e.Retry = false;
            };
            client.RequestTimedOut += (s, e) => { Assert.Fail("Request timed out"); };
            client.ResourceNotFound += (s, e) => { Assert.Fail("Not found"); };
            client.ResponseError += (s, e) => { Assert.Fail("Response contained an error"); };
            client.ServerError += (s, e) => { Assert.Fail("Response contained a server error"); };

            try
            {
                ShardStatus result = await client.GetShardDataAsync();
            }
            catch { }
            Assert.That(eventCount, Is.EqualTo(1), "Event was raised wrong number of times.");
        }

        [Test]
        public async Task ErrorHandler_ShouldReturnNull_ForTimeout()
        {
            RiotClientSettings settings = RiotClient.DefaultSettings();
            settings.RetryOnTimeout = false;
            settings.ThrowOnError = false;

            var eventCount = 0;
            IRiotClient client = new RiotClient(settings, PlatformId.NA1);
            client.ConnectionFailed += (s, e) => { Assert.Fail("Connection failed"); };
            client.RequestTimedOut += (s, e) => { ++eventCount; };
            client.ResourceNotFound += (s, e) => { Assert.Fail("Not found"); };
            client.ResponseError += (s, e) => { Assert.Fail("Response contained an error"); };
            client.ServerError += (s, e) => { Assert.Fail("Response contained a server error"); };

            var cts = new CancellationTokenSource();
            Task<ShardStatus> task = client.GetShardDataAsync(token: cts.Token);
            cts.Cancel();

            ShardStatus result = await task;

            Assert.That(result, Is.Null);
            Assert.That(eventCount, Is.EqualTo(1), "Event was raised wrong number of times.");
        }

        [Test]
        public async Task ErrorHandler_ShouldThrowError_ForTimeout()
        {
            RiotClientSettings settings = RiotClient.DefaultSettings();
            settings.RetryOnTimeout = false;
            settings.ThrowOnError = true;

            var eventCount = 0;
            IRiotClient client = new RiotClient(settings, PlatformId.NA1);
            client.ConnectionFailed += (s, e) => { Assert.Fail("Connection failed"); };
            client.RequestTimedOut += (s, e) => { ++eventCount; };
            client.ResourceNotFound += (s, e) => { Assert.Fail("Not found"); };
            client.ResponseError += (s, e) => { Assert.Fail("Response contained an error"); };
            client.ServerError += (s, e) => { Assert.Fail("Response contained a server error"); };

            var cts = new CancellationTokenSource();
            Task<ShardStatus> task = client.GetShardDataAsync(token: cts.Token);
            cts.Cancel();

            Assert.That((AsyncTestDelegate)(() => task), Throws.InstanceOf<RestTimeoutException>());
            try
            {
                ShardStatus result = await task;
            }
            catch { }
            Assert.That(eventCount, Is.EqualTo(1), "Event was raised wrong number of times.");
        }

        [Test]
        public async Task ErrorHandler_ShouldRetry_ForTimeout()
        {
            RiotClientSettings settings = RiotClient.DefaultSettings();
            settings.ThrowOnError = true;
            settings.RetryOnTimeout = true;
            settings.MaxRequestAttempts = 2;

            var eventCount = 0;
            TestRiotClient client = new TestRiotClient(settings);
            client.Client.Timeout = TimeSpan.FromMilliseconds(1);

            client.MessageHandler.Delay(500);
            client.ConnectionFailed += (s, e) => { Assert.Fail("Connection failed"); };
            client.RequestTimedOut += (s, e) => { ++eventCount; };
            client.ResourceNotFound += (s, e) => { Assert.Fail("Not found"); };
            client.ResponseError += (s, e) => { Assert.Fail("Response contained an error"); };
            client.ServerError += (s, e) => { Assert.Fail("Response contained a server error"); };

            try
            {
                ShardStatus result = await client.GetShardDataAsync();
            }
            catch { }
            Assert.That(eventCount, Is.EqualTo(2), "Event was raised wrong number of times.");
        }

        [Test]
        public async Task ErrorHandler_ShouldRetry_ForTimeout_IfCancelled()
        {
            RiotClientSettings settings = RiotClient.DefaultSettings();
            settings.ThrowOnError = true;
            settings.RetryOnTimeout = true;
            settings.MaxRequestAttempts = 2;

            var eventCount = 0;
            IRiotClient client = new RiotClient(settings, PlatformId.NA1);
            client.ConnectionFailed += (s, e) => { Assert.Fail("Connection failed"); };
            client.RequestTimedOut += (s, e) => { ++eventCount; };
            client.ResourceNotFound += (s, e) => { Assert.Fail("Not found"); };
            client.ResponseError += (s, e) => { Assert.Fail("Response contained an error"); };
            client.ServerError += (s, e) => { Assert.Fail("Response contained a server error"); };

            var cts = new CancellationTokenSource();
            Task<ShardStatus> task = client.GetShardDataAsync(token: cts.Token);
            cts.Cancel();

            try
            {
                ShardStatus result = await task;
            }
            catch { }
            Assert.That(eventCount, Is.EqualTo(1), "Event was raised wrong number of times.");
        }

        [Test]
        public async Task ErrorHandler_ShouldSuppressRetry_ForTimeout_WithEventHandler()
        {
            RiotClientSettings settings = RiotClient.DefaultSettings();
            settings.ThrowOnError = true;
            settings.RetryOnTimeout = true;
            settings.MaxRequestAttempts = 2;

            var eventCount = 0;
            TestRiotClient client = new TestRiotClient(settings);
            client.Client.Timeout = TimeSpan.FromMilliseconds(1);

            client.MessageHandler.Delay(500);
            client.ConnectionFailed += (s, e) => { Assert.Fail("Connection failed"); };
            client.RequestTimedOut += (s, e) =>
            {
                ++eventCount;
                e.Retry = false;
            };
            client.ResourceNotFound += (s, e) => { Assert.Fail("Not found"); };
            client.ResponseError += (s, e) => { Assert.Fail("Response contained an error"); };
            client.ServerError += (s, e) => { Assert.Fail("Response contained a server error"); };

            try
            {
                ShardStatus result = await client.GetShardDataAsync();
            }
            catch { }
            Assert.That(eventCount, Is.EqualTo(1), "Event was raised wrong number of times.");
        }
    }
}
