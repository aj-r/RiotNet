using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using RiotNet.Models;

namespace RiotNet.Tests
{
    [TestFixture]
    public class TournamentTests : TestBase
    {
        private long tournamentProviderId;
        private long tournamentId;

        [Test]
        public async Task A_CreateTournamentProviderAsyncTest()
        {
            IRiotClient client = new RiotClient(Region.NA);
            tournamentProviderId = await client.CreateTournamentProviderAsync("");
            
            Assert.That(tournamentProviderId, Is.GreaterThan(0));
        }

        [Test]
        public async Task B_CreateTournamentAsyncTest()
        {
            IRiotClient client = new RiotClient(Region.NA);
            if (tournamentProviderId == 0)
                tournamentProviderId = await client.CreateTournamentProviderAsync("");
            tournamentId = await client.CreateTournamentAsync(tournamentProviderId);

            Assert.That(tournamentId, Is.GreaterThan(0));
        }
        /*
        [Test]
        public async Task C_CreateTournamentGameAsyncTest()
        {
            IRiotClient client = new RiotClient(Region.NA);
            if (tournamentProviderId == null)
                tournamentProviderId = await client.CreateTournamentProviderAsync();
            tournamentId = await client.cre(tournamentProviderId);

            Assert.That(tournamentProviderId, Is.Not.Null.And.Not.Empty);
        }*/
    }
}
