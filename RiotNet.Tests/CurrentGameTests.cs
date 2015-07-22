using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using RiotNet.Models;

namespace RiotNet.Tests
{
    [TestFixture]
    public class CurrentGameTests
    {
        [Test]
        public async Task GetCurrentGameBySummonerIdTest()
        {
            var client = new RiotClient();
            // In order to get a summoner ID that is guaranteed to be in a game, we need to get a featured game.
            var featuredGameList = await client.GetFeaturedGamesTaskAsync();
            var featuredGame = featuredGameList.GameList.First();
            var summonerName = featuredGame.Participants.First().SummonerName;
            var summoner = await client.GetSummonerBySummonerNameTaskAsync(summonerName);

            var game = await client.GetCurrentGameBySummonerIdTaskAsync(summoner.Id);

            Assert.That(game, Is.Not.Null);
            Assert.That(game.BannedChampions, Is.Not.Null.And.Not.Empty);
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
            Assert.That(participant.Masteries, Is.Not.Null.And.Not.Empty);
            var mastery = participant.Masteries.First();
            Assert.That(mastery.MasteryId, Is.GreaterThan(0));
            Assert.That(mastery.Rank, Is.GreaterThan(0));
            Assert.That(participant.ProfileIconId, Is.GreaterThan(0));
            Assert.That(participant.Runes, Is.Not.Null.And.Not.Empty);
            var rune = participant.Runes.First();
            Assert.That(rune.Count, Is.GreaterThan(0));
            Assert.That(rune.Rank, Is.GreaterThan(0));
            Assert.That(rune.RuneId, Is.GreaterThan(0));
            Assert.That(participant.Spell1Id, Is.GreaterThan(0));
            Assert.That(participant.Spell2Id, Is.GreaterThan(0));
            Assert.That(participant.SummonerId, Is.GreaterThan(0));
            Assert.That(participant.SummonerName, Is.Not.Null.And.Not.Empty);
            Assert.That(game.Participants.Any(p => p.TeamId == TeamSide.Team2));
            Assert.That(game.PlatformId, Is.EqualTo("NA1"));
        }
    }
}
