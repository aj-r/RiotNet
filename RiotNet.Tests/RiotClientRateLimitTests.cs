using NUnit.Framework;
using RiotNet.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiotNet.Tests
{
    // Note: these tests assume you have a development API key with a limit of 10 requests per second.
    [TestFixture]
    public class RateLimitTests : TestBase
    {
        [Test]
        public async Task RateLimitTest_ShouldRetry()
        {
            IRiotClient client = new RiotClient();
            client.Settings.MaxRequestAttempts = 2;
            client.Settings.RetryOnRateLimitExceeded = true;
            client.Settings.ThrowOnError = true;
            for (var i = 0; i < 11; ++i)
            {
                var league = await client.GetMasterLeagueAsync(RankedQueue.RANKED_SOLO_5x5);
                Assert.That(league, Is.Not.Null, "Failed to get league: " + i);
            }
        }

        [Test]
        public void RateLimitTest_ShouldThrow()
        {
            IRiotClient client = new RiotClient();
            client.Settings.RetryOnRateLimitExceeded = false;
            client.Settings.ThrowOnError = true;
            Assert.ThrowsAsync<RateLimitExceededException>(() => MaxOutRateLimit(client));
        }

        [Test]
        public async Task RateLimitTest_ShouldReturnNull()
        {
            IRiotClient client = new RiotClient();
            client.Settings.RetryOnRateLimitExceeded = false;
            client.Settings.ThrowOnError = false;
            await MaxOutRateLimit(client);

            var league = await client.GetMasterLeagueAsync(RankedQueue.RANKED_SOLO_5x5);

            Assert.That(league, Is.Null);
        }

        [Test]
        public async Task RateLimitTest_ShouldDelayFutureRequests()
        {
            await Task.Delay(10000); // in case a previous test maxed out the limit

            IRiotClient client = new RiotClient();
            client.Settings.MaxRequestAttempts = 2;
            client.Settings.RetryOnRateLimitExceeded = false;
            client.Settings.ThrowOnError = false;

            var tasks = new List<Task<LeagueList>>();
            for (var i = 0; i < 11; ++i)
            {
                tasks.Add(client.GetMasterLeagueAsync(RankedQueue.RANKED_SOLO_5x5));
            }
            var leagues = await Task.WhenAll(tasks);

            IRiotClient client2 = new RiotClient(client.Settings);
            client2.RateLimitExceeded += (o, e) => Assert.Fail("Rate limit was exceeded! Reactive rate limit guard failed.");
            var league = client2.GetMasterLeagueAsync(RankedQueue.RANKED_SOLO_5x5);

            Assert.That(league, Is.Not.Null, "Failed to get league");
        }

        [Test]
        public async Task RateLimitTest_ShouldApplyRateLimiter_FromStaticProperty()
        {
            await Task.Delay(10000); // in case a previous test maxed out the limit

            RiotClient.RateLimiter = new RateLimiter(10, 600);
            IRiotClient client = new RiotClient();
            client.Settings.RetryOnRateLimitExceeded = true;

            client.RateLimitExceeded += (o, e) =>
            {
                if (e.Response != null)
                    Assert.Fail("Rate limit was exceeded! Proactive rate limiting failed.");
            };

            for (var i = 0; i < 12; ++i)
            {
                var league = await client.GetMasterLeagueAsync(RankedQueue.RANKED_SOLO_5x5);
                Assert.That(league, Is.Not.Null, "Failed to get league: " + i);
            }
        }

        [Test]
        public async Task RateLimitTest_ShouldApplyRateLimiter_WithConcurrentRequests()
        {
            await Task.Delay(10000); // in case a previous test maxed out the limit

            RiotClient.RateLimiter = new RateLimiter(10, 600);
            RetryEventHandler onRateLimitExceeded = (o, e) =>
            {
                if (e.Response != null)
                    Assert.Fail("Rate limit was exceeded! Proactive rate limiting failed.");
            };

            var tasks = new List<Task<LeagueList>>();
            for (var i = 0; i < 30; ++i)
            {
                tasks.Add(Task.Run(() =>
                {
                    IRiotClient client = new RiotClient();
                    client.Settings.RetryOnRateLimitExceeded = true;
                    client.RateLimitExceeded += onRateLimitExceeded;

                    return client.GetMasterLeagueAsync(RankedQueue.RANKED_SOLO_5x5);
                }));
            }

            var allTask = Task.WhenAll(tasks);
            var finishedTask = await Task.WhenAny(allTask, Task.Delay(25000));

            if (finishedTask == allTask)
            {
                var failedTask = tasks.FirstOrDefault(t => t.IsFaulted);
                if (failedTask != null)
                    Assert.Fail(failedTask.Exception?.ToString());
                var leagues = allTask.Result;
                for (var i = 0; i < 20; ++i)
                    Assert.That(leagues[i], Is.Not.Null, "Failed to get league: " + i);
            }
            else
            {
                var completedCount = tasks.Count(t => t.IsCompleted);
                Assert.Fail($"Timed out waiting for tasks ({completedCount}/{tasks.Count} tasks completed)");
            }
        }

        [Test]
        public async Task RateLimitTest_ShouldApplyRateLimiter_FromConstructor()
        {
            await Task.Delay(10000); // in case a previous test maxed out the limit

            IRiotClient client = new RiotClient(new RateLimiter(10, 600));
            client.Settings.RetryOnRateLimitExceeded = true;

            client.RateLimitExceeded += (o, e) =>
            {
                if (e.Response != null)
                    Assert.Fail("Rate limit was exceeded! Proactive rate limiting failed.");
            };

            for (var i = 0; i < 12; ++i)
            {
                var league = await client.GetMasterLeagueAsync(RankedQueue.RANKED_SOLO_5x5);
                Assert.That(league, Is.Not.Null, "Failed to get league: " + i);
            }
        }

        [Test]
        public async Task RateLimitTest_ShouldProcessRequestsInOrder()
        {
            await Task.Delay(10000); // in case a previous test maxed out the limit

            IRiotClient client = new RiotClient(new RateLimiter(10, 600));
            client.Settings.RetryOnRateLimitExceeded = true;
            client.RateLimitExceeded += (o, e) =>
            {
                if (e.Response != null)
                    Assert.Fail("Rate limit was exceeded! Proactive rate limiting failed.");
            };
            var tasks = new List<Task<LeagueList>>();
            for (var i = 0; i < 30; ++i)
                tasks.Add(client.GetMasterLeagueAsync(RankedQueue.RANKED_SOLO_5x5));

            await Task.Delay(2000);
            var failedTask = tasks.FirstOrDefault(t => t.IsFaulted);
            if (failedTask != null)
                Assert.Fail(failedTask.Exception?.ToString());
            var expectedCompletedCount = tasks.Take(10).Count(t => t.IsCompleted);
            var unexpectedCompletedCount = tasks.Skip(10).Count(t => t.IsCompleted);
            Assert.That(expectedCompletedCount, Is.EqualTo(10), $"Tasks were completed out of order - {expectedCompletedCount} of the first 10 were completed. ({unexpectedCompletedCount} of the last 20)");
            Assert.That(unexpectedCompletedCount, Is.EqualTo(0), $"Extra tasks were completed - {unexpectedCompletedCount}/20.");

            await Task.Delay(11000);
            failedTask = tasks.FirstOrDefault(t => t.IsFaulted);
            if (failedTask != null)
                Assert.Fail(failedTask.Exception?.ToString());
            expectedCompletedCount = tasks.Take(20).Count(t => t.IsCompleted);
            unexpectedCompletedCount = tasks.Skip(20).Count(t => t.IsCompleted);
            Assert.That(expectedCompletedCount, Is.EqualTo(20), $"Tasks were completed out of order - {expectedCompletedCount} of the first 20 were completed. ({unexpectedCompletedCount} of the last 10)");
            Assert.That(unexpectedCompletedCount, Is.EqualTo(0), $"Extra tasks were completed - {unexpectedCompletedCount}/10.");
        }

        private async Task MaxOutRateLimit(IRiotClient client)
        {
            for (var i = 0; i < 11; ++i)
                await client.GetMasterLeagueAsync(RankedQueue.RANKED_SOLO_5x5);
        }
    }
}
