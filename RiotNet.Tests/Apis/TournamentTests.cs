using Newtonsoft.Json;
using NUnit.Framework;
using RiotNet.Models;
using RiotNet.Tests.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiotNet.Tests
{
    [TestFixture]
    public class TournamentTests : TestBase
    {
        [Test]
        public async Task CreateTournamentProviderAsyncTest()
        {
            IRiotClient client = new RiotClient(Region.NA, TournamentApiKey);
            var tournamentProviderId = await client.CreateTournamentProviderAsync("http://example.com");

            Assert.That(tournamentProviderId, Is.GreaterThan(0));
        }

        [Test]
        public async Task CreateTournamentAsyncTest()
        {
            IRiotClient client = new RiotClient(Region.NA, TournamentApiKey);
            var tournamentId = await client.CreateTournamentAsync(206, "test");

            Assert.That(tournamentId, Is.GreaterThan(0));
        }

        [Test]
        public async Task CreateTournamentCodeAsyncTest()
        {
            IRiotClient client = new RiotClient(Region.NA, TournamentApiKey);
            var codes = await client.CreateTournamentCodeAsync(3092);

            Assert.That(codes, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task CreateTournamentCodeAsyncTest_WithArguments()
        {
            IRiotClient client = new RiotClient(Region.NA, TournamentApiKey);
            var codes = await client.CreateTournamentCodeAsync(3092, 8,
                new List<long> { 35870943L, 32153637L, 31220286L, 37431081L, 20934656L, 30545906L, 32550537L, 38722060L },
                MapType.CRYSTAL_SCAR, PickType.ALL_RANDOM, SpectatorType.LOBBYONLY, 4, "test");

            Assert.That(codes, Is.Not.Null.And.Not.Empty);
            Assert.That(codes.Count, Is.EqualTo(8));
        }

        [Test]
        public async Task GetTournamentCodeAsyncTest()
        {
            IRiotClient client = new RiotClient(Region.NA, TournamentApiKey);
            var tournamentCode = await client.GetTournamentCodeAsync("NA0418d-ecef63c4-ec4e-4925-9c4b-e9941f8d0547");

            Assert.That(tournamentCode, Is.Not.Null);
            Assert.That(tournamentCode.Id, Is.GreaterThan(0));
            Assert.That(tournamentCode.LobbyName, Is.Not.Null.And.Not.Empty);
            Assert.That(tournamentCode.Map, Is.EqualTo(MapType.TWISTED_TREELINE));
            Assert.That(tournamentCode.MetaData, Is.Not.Null.And.Not.Empty);
            Assert.That(tournamentCode.Participants, Is.Not.Null.And.Not.Empty);
            Assert.That(tournamentCode.Password, Is.Not.Null.And.Not.Empty);
            Assert.That(tournamentCode.PickType, Is.EqualTo(PickType.BLIND_PICK));
            Assert.That(tournamentCode.ProviderId, Is.GreaterThan(0));
            Assert.That(tournamentCode.Region, Is.EqualTo(Region.NA));
            Assert.That(tournamentCode.Spectators, Is.EqualTo(SpectatorType.LOBBYONLY));
            Assert.That(tournamentCode.TeamSize, Is.GreaterThan(0));
            Assert.That(tournamentCode.TournamentId, Is.GreaterThan(0));
        }

        [Test]
        public async Task UpdateTournamentCodeAsyncTest()
        {
            IRiotClient client = new RiotClient(Region.NA, TournamentApiKey);
            await client.UpdateTournamentCodeAsync("NA0418c-d541d70b-2865-4489-89bd-1d26b72b2edf",
                new List<long> { 35870943L, 32153637L, 31220286L, 37431081L, 20934656L, 30545906L, 32550537L, 38722060L, 21204597L, 20028460L }, 
                MapType.HOWLING_ABYSS, PickType.ALL_RANDOM, SpectatorType.ALL);

            var tournamentCode = await client.GetTournamentCodeAsync("NA0418c-d541d70b-2865-4489-89bd-1d26b72b2edf");
            Assert.That(tournamentCode.Map, Is.EqualTo(MapType.HOWLING_ABYSS));
            Assert.That(tournamentCode.Participants, Contains.Item(35870943L));
            Assert.That(tournamentCode.PickType, Is.EqualTo(PickType.ALL_RANDOM));
            Assert.That(tournamentCode.Spectators, Is.EqualTo(SpectatorType.ALL));

            await client.UpdateTournamentCodeAsync("NA0418c-d541d70b-2865-4489-89bd-1d26b72b2edf",
                new List<long> { 22811529L, 32153637L, 31220286L, 37431081L, 20934656L, 30545906L, 32550537L, 38722060L, 21204597L, 20028460L },
                MapType.CRYSTAL_SCAR, PickType.TOURNAMENT_DRAFT, SpectatorType.NONE);

            tournamentCode = await client.GetTournamentCodeAsync("NA0418c-d541d70b-2865-4489-89bd-1d26b72b2edf");
            Assert.That(tournamentCode.Map, Is.EqualTo(MapType.CRYSTAL_SCAR));
            Assert.That(tournamentCode.Participants, Contains.Item(22811529L));
            Assert.That(tournamentCode.PickType, Is.EqualTo(PickType.TOURNAMENT_DRAFT));
            Assert.That(tournamentCode.Spectators, Is.EqualTo(SpectatorType.NONE));
        }

        [Test]
        public async Task UpdateTournamentCodeAsyncTest_WithObject()
        {
            IRiotClient client = new RiotClient(Region.NA, TournamentApiKey);
            await client.UpdateTournamentCodeAsync(new TournamentCode
            {
                Code = "NA0418c-d541d70b-2865-4489-89bd-1d26b72b2edf",
                Participants = new ListOfLong { 35870943L, 32153637L, 31220286L, 37431081L, 20934656L, 30545906L, 32550537L, 38722060L, 21204597L, 20028460L },
                Map = MapType.HOWLING_ABYSS,
                PickType = PickType.ALL_RANDOM,
                Spectators = SpectatorType.ALL
            });

            var tournamentCode = await client.GetTournamentCodeAsync("NA0418c-d541d70b-2865-4489-89bd-1d26b72b2edf");
            Assert.That(tournamentCode.Map, Is.EqualTo(MapType.HOWLING_ABYSS));
            Assert.That(tournamentCode.Participants, Contains.Item(35870943L));
            Assert.That(tournamentCode.PickType, Is.EqualTo(PickType.ALL_RANDOM));
            Assert.That(tournamentCode.Spectators, Is.EqualTo(SpectatorType.ALL));
            
            await client.UpdateTournamentCodeAsync(new TournamentCode
            {
                Code = "NA0418c-d541d70b-2865-4489-89bd-1d26b72b2edf",
                Participants = new ListOfLong { 22811529L, 32153637L, 31220286L, 37431081L, 20934656L, 30545906L, 32550537L, 38722060L, 21204597L, 20028460L },
                Map = MapType.CRYSTAL_SCAR,
                PickType = PickType.TOURNAMENT_DRAFT,
                Spectators = SpectatorType.NONE
            });

            tournamentCode = await client.GetTournamentCodeAsync("NA0418c-d541d70b-2865-4489-89bd-1d26b72b2edf");
            Assert.That(tournamentCode.Map, Is.EqualTo(MapType.CRYSTAL_SCAR));
            Assert.That(tournamentCode.Participants, Contains.Item(22811529L));
            Assert.That(tournamentCode.PickType, Is.EqualTo(PickType.TOURNAMENT_DRAFT));
            Assert.That(tournamentCode.Spectators, Is.EqualTo(SpectatorType.NONE));
        }

        [Test]
        public async Task GetTournamentCodeLobbyEventsAsyncTest()
        {
            IRiotClient client = new RiotClient(Region.NA, TournamentApiKey);
            var events = await client.GetTournamentCodeLobbyEventsAsync("NA0418d-8899c00a-45a9-4898-9b8a-75370a67b9a0");

            Assert.That(events, Is.Not.Null);
        }

        [Test]
        public void DeserializeLobbyEventsTest()
        {
            var events = JsonConvert.DeserializeObject<List<LobbyEvent>>(Resources.SampleLobbyEvents, RiotClient.JsonSettings);
            
            Assert.That(events, Is.Not.Null.And.Not.Empty);
            var @event = events.First();
            Assert.That(@event.EventType, Is.Not.Null.And.Not.Empty);
            Assert.That(@event.SummonerId, Is.Not.Null);
            Assert.That(@event.SummonerId.Value, Is.GreaterThan(0));
            Assert.That(@event.Timestamp, Is.Not.EqualTo(default(DateTime)));
        }
    }
}
