using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using RiotNet.Models;

namespace RiotNet.Tests
{
    [TestFixture]
    public class SpectatorTests : TestBase
    {
        [Test]
        public async Task GetActiveGameBySummonerIdAsyncTest()
        {
            IRiotClient client = new RiotClient();
            // In order to get a summoner ID that is guaranteed to be in a game, we need to get a featured game.
            var featuredGameList = await client.GetFeaturedGamesAsync();
            var featuredGame = featuredGameList.GameList.First();
            var summonerName = featuredGame.Participants.First().SummonerName;
            var summoner = await client.GetSummonerBySummonerNameAsync(summonerName);

            var game = await client.GetActiveGameBySummonerIdAsync(summoner.Id);

            Assert.That(game, Is.Not.Null);
            //Assert.That(game.BannedChampions, Is.Not.Null.And.Not.Empty);
            var bannedChampion = game.BannedChampions.FirstOrDefault();
            if (bannedChampion != null)
            {
                Assert.That(bannedChampion.ChampionId, Is.GreaterThan(0));
                Assert.That(bannedChampion.PickTurn, Is.GreaterThan(0));
                Assert.That(game.BannedChampions.Any(c => c.TeamId == TeamSide.Team2));
            }
            Assert.That(game.GameId, Is.GreaterThan(0));
            Assert.That(game.GameLength, Is.GreaterThan(TimeSpan.Zero));
            Assert.That(game.GameMode, Is.EqualTo(GameMode.CLASSIC).Or.EqualTo(GameMode.ARAM));
            Assert.That(game.GameQueueConfigId, Is.EqualTo(QueueType.RANKED_FLEX_SR)
                .Or.EqualTo(QueueType.TEAM_BUILDER_DRAFT_UNRANKED_5x5)
                .Or.EqualTo(QueueType.TEAM_BUILDER_RANKED_SOLO)
                .Or.EqualTo(QueueType.NORMAL_5x5_BLIND)
                .Or.EqualTo(QueueType.ARAM_5x5));
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
            Assert.That(participant.Perks, Is.Not.Null);
            Assert.That(participant.Perks.PerkStyle, Is.GreaterThan(0));
            Assert.That(participant.Perks.PerkSubStyle, Is.GreaterThan(0));
            Assert.That(participant.Perks.PerkIds, Is.Not.Null.And.Not.Empty);
            Assert.That(participant.Spell1Id, Is.GreaterThan(0));
            Assert.That(participant.Spell2Id, Is.GreaterThan(0));
            Assert.That(participant.SummonerId, Is.EqualTo(summoner.Id));
            Assert.That(participant.SummonerName, Is.Not.Null.And.Not.Empty);
            Assert.That(game.Participants.Any(p => p.TeamId == TeamSide.Team2));
            Assert.That(game.PlatformId, Is.EqualTo(client.PlatformId));
        }

        [Test]
        public async Task GetCurrentGameBySummonerIdAsyncTest()
        {
            // This is just an alias for GetActiveGameBySummonerIdAsync(), so just test that the alias works
            IRiotClient client = new RiotClient();
            // In order to get a summoner ID that is guaranteed to be in a game, we need to get a featured game.
            var featuredGameList = await client.GetFeaturedGamesAsync();
            var featuredGame = featuredGameList.GameList.First();
            var summonerName = featuredGame.Participants.First().SummonerName;
            var summoner = await client.GetSummonerBySummonerNameAsync(summonerName);

            var game = await client.GetCurrentGameBySummonerIdAsync(summoner.Id);

            Assert.That(game, Is.Not.Null);
            Assert.That(game.GameId, Is.GreaterThan(0));
        }

        [Test]
        public async Task GetFeaturedGamesAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var featuredGameList = await client.GetFeaturedGamesAsync();

            Assert.That(featuredGameList, Is.Not.Null);
            Assert.That(featuredGameList.ClientRefreshInterval, Is.GreaterThan(0));
            Assert.That(featuredGameList.GameList, Is.Not.Null.And.Not.Empty);
            var game = featuredGameList.GameList.First();
            //Assert.That(game.BannedChampions, Is.Not.Null.And.Not.Empty);
            var bannedChampion = game.BannedChampions.FirstOrDefault();
            if (bannedChampion != null)
            {
                Assert.That(bannedChampion.ChampionId, Is.GreaterThan(0));
                Assert.That(bannedChampion.PickTurn, Is.GreaterThan(0));
                Assert.That(game.BannedChampions.Any(c => c.TeamId == TeamSide.Team2));
            }
            Assert.That(game.GameId, Is.GreaterThan(0));
            Assert.That(game.GameLength, Is.GreaterThan(TimeSpan.Zero));
            Assert.That(game.GameMode, Is.EqualTo(GameMode.CLASSIC).Or.EqualTo(GameMode.ARAM));
            Assert.That(game.GameQueueConfigId, Is.EqualTo(QueueType.RANKED_FLEX_SR)
                .Or.EqualTo(QueueType.TEAM_BUILDER_DRAFT_UNRANKED_5x5)
                .Or.EqualTo(QueueType.TEAM_BUILDER_RANKED_SOLO)
                .Or.EqualTo(QueueType.NORMAL_5x5_BLIND)
                .Or.EqualTo(QueueType.ARAM_5x5));
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
