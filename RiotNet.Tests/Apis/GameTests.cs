using Newtonsoft.Json;
using NUnit.Framework;
using RiotNet.Models;
using RiotNet.Tests.Properties;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RiotNet.Tests
{
    [TestFixture]
    public class GameTests : TestBase
    {
        [Test]
        public async Task GetGamesBySummonerIdAsyncTests()
        {
            IRiotClient client = new RiotClient();
            var summonerId = 35870943;
            var games = await client.GetGamesBySummonerIdAsync(summonerId);

            Assert.That(games, Is.Not.Null);
            Assert.That(games.Games, Is.Not.Null.And.Not.Empty);
            Assert.That(games.SummonerId, Is.EqualTo(summonerId));
            var game = games.Games.First();
            Assert.That(game, Is.Not.Null);
            Assert.That(game.ChampionId, Is.GreaterThan(0));
            Assert.That(game.CreateDate.Kind, Is.EqualTo(DateTimeKind.Utc));
            Assert.That(game.CreateDate, Is.GreaterThan(default(DateTime)).And.LessThan(DateTime.UtcNow));
            var fellowPlayers = games.Games.Where(g => g.FellowPlayers != null).SelectMany(g => g.FellowPlayers).ToList();
            Assert.That(fellowPlayers, Is.Not.Empty);
            var player = fellowPlayers.First();
            Assert.That(player.ChampionId, Is.GreaterThan(0));
            Assert.That(player.SummonerId, Is.GreaterThan(0));
            Assert.That(fellowPlayers.Any(p => p.TeamId == TeamSide.Team1));
            Assert.That(fellowPlayers.Any(p => p.TeamId == TeamSide.Team2));
            Assert.That(game.GameId, Is.GreaterThan(0));
            Assert.That(game.Level, Is.GreaterThan(0));
            Assert.That(game.MapId, Is.GreaterThan(0));
            Assert.That(game.Spell1, Is.GreaterThan(0));
            Assert.That(game.Spell2, Is.GreaterThan(0));
            Assert.That(game.Stats, Is.Not.Null);
            Assert.That(game.Stats, Is.Not.Null);
            Assert.That(games.Games.Any(g => g.TeamId == TeamSide.Team1));
            Assert.That(games.Games.Any(g => g.TeamId == TeamSide.Team2));
        }

        [Test]
        public void DeserializeGameTest()
        {
            // Unfortunately, we cannot rely on a game in someone's match history to consistently contain all stats.
            // As a wrokaround, we try deserializing some pre-canned data instead.

            var game = JsonConvert.DeserializeObject<Game>(Resources.SampleGame, RiotClient.JsonSettings);

            AssertNonDefaultValuesRecursive(game);
        }
    }
}
