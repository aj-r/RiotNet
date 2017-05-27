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
            IRiotClient client = new RiotClient(GetTournamentSettings());
            long tournamentProviderId = await client.CreateTournamentProviderAsync("http://example.com", PlatformId.NA1);

            Assert.That(tournamentProviderId, Is.GreaterThan(0));
        }

        [Test]
        public async Task CreateTournamentAsyncTest()
        {
            IRiotClient client = new RiotClient(GetTournamentSettings());
            long tournamentId = await client.CreateTournamentAsync(206, "test");

            Assert.That(tournamentId, Is.GreaterThan(0));
        }

        [Test]
        public async Task CreateTournamentCodeAsyncTest()
        {
            IRiotClient client = new RiotClient(GetTournamentSettings());
            List<string> codes = await client.CreateTournamentCodeAsync(3092);

            Assert.That(codes, Is.Not.Null.And.Not.Empty);
            Assert.That(codes.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task CreateTournamentCodeAsyncTest_WithArguments()
        {
            IRiotClient client = new RiotClient(GetTournamentSettings());
            List<string> codes = await client.CreateTournamentCodeAsync(3092, 1,
                new List<long> { 35870943L, 32153637L, 31220286L, 37431081L, 20934656L, 30545906L, 32550537L, 38722060L },
                MapType.HOWLING_ABYSS, PickType.ALL_RANDOM, SpectatorType.LOBBYONLY, 4, "test");

            Assert.That(codes, Is.Not.Null.And.Not.Empty);
            Assert.That(codes.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task GetTournamentCodeAsyncTest()
        {
            IRiotClient client = new RiotClient(GetTournamentSettings());
            TournamentCode tournamentCode = await client.GetTournamentCodeAsync("NA042f7-b6923650-58bd-4a39-a5f5-9bd398016913");

            Assert.That(tournamentCode, Is.Not.Null);
            Assert.That(tournamentCode.Id, Is.GreaterThan(0));
            Assert.That(tournamentCode.LobbyName, Is.Not.Null.And.Not.Empty);
            Assert.That(tournamentCode.Map, Is.EqualTo(MapType.HOWLING_ABYSS));
            Assert.That(tournamentCode.MetaData, Is.Not.Null.And.Not.Empty);
            Assert.That(tournamentCode.Participants, Is.Not.Null.And.Not.Empty);
            Assert.That(tournamentCode.Password, Is.Not.Null.And.Not.Empty);
            Assert.That(tournamentCode.PickType, Is.EqualTo(PickType.ALL_RANDOM));
            Assert.That(tournamentCode.ProviderId, Is.GreaterThan(0));
            Assert.That(tournamentCode.Region, Is.EqualTo("NA"));
            Assert.That(tournamentCode.Spectators, Is.EqualTo(SpectatorType.LOBBYONLY));
            Assert.That(tournamentCode.TeamSize, Is.GreaterThan(0));
            Assert.That(tournamentCode.TournamentId, Is.GreaterThan(0));
        }

        [Test]
        public async Task UpdateTournamentCodeAsyncTest()
        {
            const string code = "NA042f7-b6923650-58bd-4a39-a5f5-9bd398016913";
            IRiotClient client = new RiotClient(GetTournamentSettings());

            await client.UpdateTournamentCodeAsync(code,
                new List<long> { 35870943L, 32153637L, 31220286L, 37431081L, 20934656L, 30545906L, 32550537L, 38722060L, 21204597L, 20028460L }, 
                MapType.SUMMONERS_RIFT, PickType.BLIND_PICK, SpectatorType.ALL);

            TournamentCode tournamentCode = await client.GetTournamentCodeAsync(code);
            Assert.That(tournamentCode.Map, Is.EqualTo(MapType.SUMMONERS_RIFT));
            Assert.That(tournamentCode.Participants, Contains.Item(35870943L));
            Assert.That(tournamentCode.PickType, Is.EqualTo(PickType.BLIND_PICK));
            Assert.That(tournamentCode.Spectators, Is.EqualTo(SpectatorType.ALL));

            await client.UpdateTournamentCodeAsync(code,
                new List<long> { 22811529L, 32153637L, 31220286L, 37431081L, 20934656L, 30545906L, 32550537L, 38722060L, 21204597L, 20028460L },
                MapType.HOWLING_ABYSS, PickType.ALL_RANDOM, SpectatorType.LOBBYONLY);

            tournamentCode = await client.GetTournamentCodeAsync(code);
            Assert.That(tournamentCode.Map, Is.EqualTo(MapType.HOWLING_ABYSS));
            Assert.That(tournamentCode.Participants, Contains.Item(22811529L));
            Assert.That(tournamentCode.PickType, Is.EqualTo(PickType.ALL_RANDOM));
            Assert.That(tournamentCode.Spectators, Is.EqualTo(SpectatorType.LOBBYONLY));
        }

        [Test]
        public async Task UpdateTournamentCodeAsyncTest_WithObject()
        {
            const string code = "NA042f7-b6923650-58bd-4a39-a5f5-9bd398016913";
            IRiotClient client = new RiotClient(GetTournamentSettings());

            await client.UpdateTournamentCodeAsync(new TournamentCode
            {
                Code = code,
                Participants = new ListOfLong { 35870943L, 32153637L, 31220286L, 37431081L, 20934656L, 30545906L, 32550537L, 38722060L, 21204597L, 20028460L },
                Map = MapType.TWISTED_TREELINE,
                PickType = PickType.TOURNAMENT_DRAFT,
                Spectators = SpectatorType.NONE,
            });

            TournamentCode tournamentCode = await client.GetTournamentCodeAsync(code);
            Assert.That(tournamentCode.Map, Is.EqualTo(MapType.TWISTED_TREELINE));
            Assert.That(tournamentCode.Participants, Contains.Item(35870943L));
            Assert.That(tournamentCode.PickType, Is.EqualTo(PickType.TOURNAMENT_DRAFT));
            Assert.That(tournamentCode.Spectators, Is.EqualTo(SpectatorType.NONE));

            await client.UpdateTournamentCodeAsync(new TournamentCode
            {
                Code = code,
                Participants = new ListOfLong { 22811529L, 32153637L, 31220286L, 37431081L, 20934656L, 30545906L, 32550537L, 38722060L, 21204597L, 20028460L },
                Map = MapType.HOWLING_ABYSS,
                PickType = PickType.ALL_RANDOM,
                Spectators = SpectatorType.LOBBYONLY,
            });

            tournamentCode = await client.GetTournamentCodeAsync(code);
            Assert.That(tournamentCode.Map, Is.EqualTo(MapType.HOWLING_ABYSS));
            Assert.That(tournamentCode.Participants, Contains.Item(22811529L));
            Assert.That(tournamentCode.PickType, Is.EqualTo(PickType.ALL_RANDOM));
            Assert.That(tournamentCode.Spectators, Is.EqualTo(SpectatorType.LOBBYONLY));
        }

        [Test]
        public async Task GetTournamentCodeLobbyEventsAsyncTest()
        {
            IRiotClient client = new RiotClient(GetTournamentSettings());
            List<LobbyEvent> events = await client.GetTournamentCodeLobbyEventsAsync("NA042f7-b6923650-58bd-4a39-a5f5-9bd398016913");

            Assert.That(events, Is.Not.Null);
        }

        [Test]
        public void DeserializeLobbyEventsTest()
        {
            List<LobbyEvent> events = JsonConvert.DeserializeObject<List<LobbyEvent>>(Resources.SampleLobbyEvents, RiotClient.JsonSettings);
            
            Assert.That(events, Is.Not.Null.And.Not.Empty);
            LobbyEvent @event = events.First();
            Assert.That(@event.EventType, Is.Not.Null.And.Not.Empty);
            Assert.That(@event.SummonerId, Is.Not.Null);
            Assert.That(@event.SummonerId.Value, Is.GreaterThan(0));
            Assert.That(@event.Timestamp, Is.Not.EqualTo(default(DateTime)));
        }

        private RiotClientSettings GetTournamentSettings()
        {
            return new RiotClientSettings
            {
                ApiKey = TournamentApiKey,
                UseTournamentStub = true,
            };
        }
    }
}
