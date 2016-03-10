using NUnit.Framework;
using RiotNet.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RiotNet.Tests
{
    [TestFixture]
    public class FeaturedGameTests : TestBase
    {
        [Test]
        public async Task GetFeaturedGamesAsyncTaskTest()
        {
            IRiotClient client = new RiotClient();
            var featuredGameList = await client.GetFeaturedGamesAsync();

            Assert.That(featuredGameList, Is.Not.Null);
            Assert.That(featuredGameList.ClientRefreshInterval, Is.GreaterThan(0));
            Assert.That(featuredGameList.GameList, Is.Not.Null.And.Not.Empty);
            var game = featuredGameList.GameList.First();
            Assert.That(game.BannedChampions, Is.Not.Null.And.Not.Empty);
            var bannedChampion = game.BannedChampions.First();
            Assert.That(bannedChampion.ChampionId, Is.GreaterThan(0));
            Assert.That(bannedChampion.PickTurn, Is.GreaterThan(0));
            Assert.That(game.BannedChampions.Any(c => c.TeamId == TeamSide.Team2));
            Assert.That(game.GameId, Is.GreaterThan(0));
            Assert.That(game.GameLength, Is.GreaterThan(TimeSpan.Zero));
            Assert.That(game.GameMode, Is.EqualTo(GameMode.CLASSIC).Or.EqualTo(GameMode.ARAM));
            Assert.That(game.GameQueueConfigId, Is.EqualTo(QueueType.RANKED_SOLO_5x5).Or.EqualTo(QueueType.NORMAL_5x5_DRAFT));
            Assert.That(game.GameStartTime.Kind, Is.EqualTo(DateTimeKind.Utc));
            Assert.That(game.GameStartTime, Is.LessThan(DateTime.UtcNow).And.GreaterThan(DateTime.UtcNow.AddHours(-2)));
            Assert.That(game.GameType, Is.EqualTo(GameType.MATCHED_GAME));
            Assert.That(game.MapId, Is.GreaterThan(0));
            Assert.That(game.Observers, Is.Not.Null);
            Assert.That(game.Observers.EncryptionKey, Is.Not.Null.And.Not.Empty);
            Assert.That(game.Participants, Is.Not.Null.And.Not.Empty);
            var participant = game.Participants.First();
            Assert.That(participant.Bot, Is.False);
            Assert.That(participant.ChampionId, Is.GreaterThan(0));
            Assert.That(participant.ProfileIconId, Is.GreaterThan(0));
            Assert.That(participant.Spell1Id, Is.GreaterThan(0));
            Assert.That(participant.Spell2Id, Is.GreaterThan(0));
            Assert.That(participant.SummonerName, Is.Not.Null.And.Not.Empty);
            Assert.That(game.Participants.Any(p => p.TeamId == TeamSide.Team2));
            Assert.That(game.PlatformId, Is.EqualTo(client.PlatformId));
        }
    }
}
