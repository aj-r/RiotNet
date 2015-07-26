using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using RiotNet.Models;

namespace RiotNet.Tests
{
    /// <summary>
    /// Tests that the necessary objects can be easily saved in a database.
    /// </summary>
    [TestFixture]
    public class DbTests : TestBase
    {
        [Test]
        public void ChampionDbTest()
        {
            VerifyDbStorage<Champion>();
        }

        [Test]
        public void GameDbTest()
        {
            VerifyDbStorage<Game>();
        }

        [Test]
        public void GroupDbTest()
        {
            VerifyDbStorage<Group>();
        }

        [Test]
        public void LeagueDbTest()
        {
            VerifyDbStorage<League>();
        }

        [Test]
        public void MasteryPagesDbTest()
        {
            VerifyDbStorage<MasteryPages>();
        }

        [Test]
        public void MatchDetailDbTest()
        {
            VerifyDbStorage<MatchDetail>();
        }

        [Test]
        public void MatchReferenceDbTest()
        {
            VerifyDbStorage<MatchReference>();
        }

        [Test]
        public void MatchSummaryDbTest()
        {
            VerifyDbStorage<MatchSummary>();
        }

        [Test]
        public void RankedStatsDbTest()
        {
            VerifyDbStorage<RankedStats>();
        }

        [Test]
        public void RunePagesDbTest()
        {
            VerifyDbStorage<RunePages>();
        }

        [Test]
        public void StaticChampionDbTest()
        {
            VerifyDbStorage<StaticChampion>();
        }

        [Test]
        public void StaticItemDbTest()
        {
            VerifyDbStorage<StaticItem>();
        }

        [Test]
        public void StaticItemTreeDbTest()
        {
            VerifyDbStorage<StaticItemTree>();
        }

        [Test]
        public void StaticMapDetailsDbTest()
        {
            VerifyDbStorage<StaticMapDetails>();
        }

        [Test]
        public void StaticMasteryTreeDbTest()
        {
            VerifyDbStorage<StaticMasteryTree>();
        }

        [Test]
        public void StaticRealmDbTest()
        {
            VerifyDbStorage<StaticRealm>();
        }

        [Test]
        public void StaticRuneDbTest()
        {
            VerifyDbStorage<StaticRune>();
        }

        [Test]
        public void StaticSummonerSpellDbTest()
        {
            VerifyDbStorage<StaticSummonerSpell>();
        }

        [Test]
        public void SummonerDbTest()
        {
            VerifyDbStorage<Summoner>();
        }

        [Test]
        public void TeamDbTest()
        {
            VerifyDbStorage<Team>();
        }

        private static void VerifyDbStorage<T>() where T : class
        {
            ResetSampleValues();
            var value = Create<T>();
            var dbSetProperty = typeof(TestDbContext).GetProperties().First(p => p.PropertyType == typeof(IDbSet<T>));
            // Try to save the value to the database and make sure there are no errors.
            using (var context = new TestDbContext())
            {
                var dbSet = (IDbSet<T>)dbSetProperty.GetValue(context);
                dbSet.Add(value);
                context.SaveChanges();
            }

            // Re-create the object because 'value' may have been modified by Entity Framework during SaveChanges().
            ResetSampleValues();
            var expectedValue = Create<T>();

            // Use a new context to ensure that we aren't getting cached data.
            using (var context = new TestDbContext())
            {
                // Read the value from the database and make sure all properties are set.
                var dbSet = (IDbSet<T>)dbSetProperty.GetValue(context);
                var dbValue = dbSet.First();
                AssertObjectEqualityRecursive(dbValue, expectedValue, forDatabase: true);
            }
        }
    }
}
