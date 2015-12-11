using NUnit.Framework;
using RiotNet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            IRiotClient client = new RiotClient(Region.NA, TournamentApiKey);
            tournamentProviderId = await CreateTournamentProvider(client);
            
            Assert.That(tournamentProviderId, Is.GreaterThan(0));
        }

        [Test]
        public async Task B_CreateTournamentAsyncTest()
        {
            IRiotClient client = new RiotClient(Region.NA, TournamentApiKey);
            tournamentId = await CreateTournament(client);

            Assert.That(tournamentId, Is.GreaterThan(0));
        }

        [Test]
        public async Task C_CreateTournamentCodeAsyncTest()
        {
            tournamentId = 3092;

            IRiotClient client = new RiotClient(Region.NA, TournamentApiKey);
            var codes = await CreateTournamentCode(client);

            Assert.That(codes, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task C_CreateTournamentCodeAsyncTest_WithArguments()
        {
            tournamentId = 3092;

            IRiotClient client = new RiotClient(Region.NA, TournamentApiKey);
            if (tournamentId == 0)
                tournamentId = await CreateTournament(client);
            var codes = await client.CreateTournamentCodeAsync(tournamentId, 8,
                new List<long> { 35870943L, 32153637L, 31220286L, 37431081L, 20934656L, 30545906L, 32550537L, 38722060L },
                MapType.CRYSTAL_SCAR, PickType.ALL_RANDOM, SpectatorType.LOBBYONLY, 4, "test");

            Assert.That(codes, Is.Not.Null.And.Not.Empty);
            Assert.That(codes.Count, Is.EqualTo(8));
        }

        private Task<long> CreateTournamentProvider(IRiotClient client)
        {
            return client.CreateTournamentProviderAsync("http://example.com");
        }

        private async Task<long> CreateTournament(IRiotClient client)
        {
            if (tournamentProviderId == 0)
                tournamentProviderId = await CreateTournamentProvider(client);
            return await client.CreateTournamentAsync(tournamentProviderId, "test");
        }

        private async Task<List<string>> CreateTournamentCode(IRiotClient client)
        {
            if (tournamentId == 0)
                tournamentId = await CreateTournament(client);
            return await client.CreateTournamentCodeAsync(tournamentId);
        }
    }
}
