using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using RiotNet.Models;
using RiotNet.Tests.Properties;

namespace RiotNet.Tests
{
    [TestFixture]
    public class GameTests : TestBase
    {
        [Test]
        public async Task GetGamesBySummonerIdTaskAsyncTests()
        {
            var client = new RiotClient();
            var summonerId = 35870943;
            var games = await client.GetGamesBySummonerIdTaskAsync(summonerId);

            Assert.That(games, Is.Not.Null);
            Assert.That(games.Games, Is.Not.Null.And.Not.Empty);
            Assert.That(games.SummonerId, Is.EqualTo(summonerId));
            var game = games.Games.First();
            Assert.That(game, Is.Not.Null);
            Assert.That(game.ChampionId, Is.GreaterThan(0));
            Assert.That(game.CreateDate.Kind, Is.EqualTo(DateTimeKind.Utc));
            Assert.That(game.CreateDate, Is.GreaterThan(default(DateTime)).And.LessThan(DateTime.UtcNow));
            Assert.That(game.FellowPlayers, Is.Not.Null.And.Not.Empty);
            var player = game.FellowPlayers.First();
            Assert.That(player.ChampionId, Is.GreaterThan(0));
            Assert.That(player.SummonerId, Is.GreaterThan(0));
            Assert.That(game.FellowPlayers.Any(p => p.TeamId == TeamSide.Team1));
            Assert.That(game.FellowPlayers.Any(p => p.TeamId == TeamSide.Team2));
            Assert.That(game.GameId, Is.GreaterThan(0));
            // TODO: GameMode, GameType, Invalid, IpEarned
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
