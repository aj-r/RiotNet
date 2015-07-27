using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using RiotNet.Models;
using RiotNet.Tests.Properties;

namespace RiotNet.Tests
{
    [TestFixture]
    public class SummonerTests : TestBase
    {
        [Test]
        public async Task GetSummonersBySummonerIdsTaskAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var summonerIds = new[] { 34172230L, 35870943L };
            var summoners = await client.GetSummonersBySummonerIdsTaskAsync(summonerIds);

            AssertNonDefaultValuesRecursive(summoners);
            foreach (var summonerId in summonerIds)
                Assert.That(summoners.ContainsKey(summonerId.ToString(CultureInfo.InvariantCulture)), "Summoner was not included in results: " + summonerId);
        }

        [Test]
        public async Task GetSummonerBySummonerIdTaskAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var summoner = await client.GetSummonerBySummonerIdTaskAsync(34172230L);

            AssertNonDefaultValuesRecursive(summoner);
        }

        [Test]
        public async Task GetSummonersBySummonerNamesTaskAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var summonerNames = new[] { "KirkBerkley", "RndmInternetMan" };
            var summoners = await client.GetSummonersBySummonerNamesTaskAsync(summonerNames);

            AssertNonDefaultValuesRecursive(summoners);
            foreach (var summonerName in summonerNames)
                Assert.That(summoners.ContainsKey(summonerName), "Summoner was not included in results: " + summonerName);
        }

        [Test]
        public async Task GetSummonerBySummonerNameTaskAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var summoner = await client.GetSummonerBySummonerNameTaskAsync("KirkBerkley");

            AssertNonDefaultValuesRecursive(summoner);
        }

        [Test]
        public async Task GetSummonerMasteriesBySummonerIdsTaskAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var summonerIds = new[] { 34172230L, 35870943L };
            var masteryPages = await client.GetSummonerMasteriesBySummonerIdsTaskAsync(summonerIds);

            AssertNonDefaultValuesRecursive(masteryPages);
            foreach (var summonerId in summonerIds)
                Assert.That(masteryPages.ContainsKey(summonerId.ToString(CultureInfo.InvariantCulture)), "Summoner was not included in results: " + summonerId);
        }

        [Test]
        public async Task GetSummonerNamesBySummonerIdsTaskAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var summonerIds = new[] { 34172230L, 35870943L };
            var names = await client.GetSummonerNamesBySummonerIdsTaskAsync(summonerIds);

            AssertNonDefaultValuesRecursive(names);
            foreach (var summonerId in summonerIds)
                Assert.That(names.ContainsKey(summonerId.ToString(CultureInfo.InvariantCulture)), "Summoner was not included in results: " + summonerId);
        }

        [Test]
        public async Task GetSummonerRunesBySummonerIdsTaskAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var summonerIds = new[] { 34172230L, 35870943L };
            var runes = await client.GetSummonerRunesBySummonerIdsTaskAsync(summonerIds);

            AssertNonDefaultValuesRecursive(runes);
            foreach (var summonerId in summonerIds)
                Assert.That(runes.ContainsKey(summonerId.ToString(CultureInfo.InvariantCulture)), "Summoner was not included in results: " + summonerId);
        }
    }
}
