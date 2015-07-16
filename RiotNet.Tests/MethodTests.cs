using System;
using System.Threading.Tasks;
using NUnit.Framework;
using RiotNet.Models;

namespace RiotNet.Tests
{
    [TestFixture]
    public class MethodTests
    {
        [Test]
        public async Task GetMasterLeaguesTest()
        {
            var client = new RiotClient(Region.NA);
            var leagues = await client.GetMasterLeagueTaskAsync(RankedQueue.RANKED_SOLO_5x5);
        }
    }
}
