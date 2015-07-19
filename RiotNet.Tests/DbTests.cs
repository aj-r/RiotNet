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
    public class DbTests
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
        public void ItemDbTest()
        {
            VerifyDbStorage<Item>();
        }

        [Test]
        public void ItemTreeDbTest()
        {
            VerifyDbStorage<ItemTree>();
        }

        [Test]
        public void LeagueDbTest()
        {
            VerifyDbStorage<League>();
        }

        [Test]
        public void MapDetailsDbTest()
        {
            VerifyDbStorage<MapDetails>();
        }

        [Test]
        public void RuneDbTest()
        {
            VerifyDbStorage<StaticRune>();
        }

        [Test]
        public void StaticChampionDbTest()
        {
            VerifyDbStorage<StaticChampion>();
        }

        [Test]
        public void TeamDbTest()
        {
            VerifyDbStorage<Team>();
        }

        private static void VerifyDbStorage<T>() where T : class
        {
            var value = TestHelper.Create<T>();
            var dbSetProperty = typeof(TestDbContext).GetProperties().First(p => p.PropertyType == typeof(IDbSet<T>));
            // Try to save the value to the database and make sure there are no errors.
            using (var context = new TestDbContext())
            {
                var dbSet = (IDbSet<T>)dbSetProperty.GetValue(context);
                dbSet.Add(value);
                context.SaveChanges();
            }
            // Use a new context to ensure that we aren't getting cached data.
            using (var context = new TestDbContext())
            {
                // Read the value from the database and make sure all properties are set.
                var dbSet = (IDbSet<T>)dbSetProperty.GetValue(context);
                var dbValue = dbSet.First();
                TestHelper.AssertObjectEqualityRecursive(dbValue, value);
            }
        }
    }
}
