﻿using NUnit.Framework;
using RiotNet.Models;
using System.Threading.Tasks;

namespace RiotNet.Tests
{
    [TestFixture]
    [Explicit("These tests are desgned to max out the rate limit, and can only be run if explicitly selected.")]
    public class RequestTests : TestBase
    {
        [Test]
        public async Task RateLimitTest_Async_ShouldRetry()
        {
            IRiotClient client = new RiotClient();
            client.Settings.MaxRequestAttempts = 2;
            client.Settings.RetryOnRateLimitExceeded = true;
            client.Settings.ThrowOnError = true;
            for (var i = 0; i < 11; ++i)
            {
                var league = await client.GetMasterLeagueAsync(RankedQueue.RANKED_SOLO_5x5);
                Assert.That(league, Is.Not.Null);
            }
        }

        [Test]
        public void RateLimitTest_Sync_ShouldRetry()
        {
            IRiotClient client = new RiotClient();
            client.Settings.MaxRequestAttempts = 2;
            client.Settings.RetryOnRateLimitExceeded = true;
            client.Settings.ThrowOnError = true;
            for (var i = 0; i < 11; ++i)
            {
                var league = client.GetMasterLeague(RankedQueue.RANKED_SOLO_5x5);
                Assert.That(league, Is.Not.Null);
            }
        }

        [Test]
        [ExpectedException(typeof(RateLimitExceededException))]
        public async Task RateLimitTest_Async_ShouldThrow()
        {
            IRiotClient client = new RiotClient();
            client.Settings.RetryOnRateLimitExceeded = false;
            client.Settings.ThrowOnError = true;
            for (var i = 0; i < 11; ++i)
                await client.GetMasterLeagueAsync(RankedQueue.RANKED_SOLO_5x5);
        }

        [Test]
        [ExpectedException(typeof(RateLimitExceededException))]
        public void RateLimitTest_Sync_ShouldThrow()
        {
            IRiotClient client = new RiotClient();
            client.Settings.RetryOnRateLimitExceeded = false;
            client.Settings.ThrowOnError = true;
            for (var i = 0; i < 11; ++i)
                client.GetMasterLeague(RankedQueue.RANKED_SOLO_5x5);
        }

        [Test]
        public async Task RateLimitTest_Async_ShouldReturnNull()
        {
            IRiotClient client = new RiotClient();
            client.Settings.RetryOnRateLimitExceeded = false;
            client.Settings.ThrowOnError = false;
            for (var i = 0; i < 11; ++i)
                await client.GetMasterLeagueAsync(RankedQueue.RANKED_SOLO_5x5);

            var league = await client.GetMasterLeagueAsync(RankedQueue.RANKED_SOLO_5x5);

            Assert.That(league, Is.Null);
        }

        [Test]
        public void RateLimitTest_Sync_ShouldReturnNull()
        {
            IRiotClient client = new RiotClient();
            client.Settings.RetryOnRateLimitExceeded = false;
            client.Settings.ThrowOnError = false;
            for (var i = 0; i < 11; ++i)
                client.GetMasterLeague(RankedQueue.RANKED_SOLO_5x5);

            var league = client.GetMasterLeague(RankedQueue.RANKED_SOLO_5x5);

            Assert.That(league, Is.Null);
        }
    }
}