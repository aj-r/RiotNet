using NUnit.Framework;
using RiotNet.Models;
using System.Linq;
using System.Reflection;
#if NET_CORE
using Microsoft.EntityFrameworkCore;
#else
using System.Data.Entity;
#endif

namespace RiotNet.Tests
{
    /// <summary>
    /// Tests that the necessary objects can be easily saved in a database.
    /// </summary>
    [TestFixture]
#if NET_CORE
    [Ignore("EF Core does not support ComplexType yet, so it does not work with our models.")]
#endif
    public class DbTests : TestBase
    {
        [Test]
        public void ChampionDbTest()
        {
            VerifyDbStorage<Champion>();
        }

        [Test]
        public void GroupDbTest()
        {
            VerifyDbStorage<Group>();
        }

        [Test]
        public void LeagueListDbTest()
        {
            VerifyDbStorage<LeagueList>();
        }

        [Test]
        public void LeaguePositionDbTest()
        {
            VerifyDbStorage<LeaguePosition>();
        }

        [Test]
        public void MatchDbTest()
        {
            VerifyDbStorage<Match>();
        }

        [Test]
        public void MatchReferenceDbTest()
        {
            VerifyDbStorage<MatchReference>();
        }
        
        [Test]
        public void SummonerDbTest()
        {
            VerifyDbStorage<Summoner>();
        }

        private static void VerifyDbStorage<T>() where T : class
        {
            ResetSampleValues();
            var value = Create<T>();
            var dbSetProperty = typeof(TestDbContext).GetProperties().First(p => p.PropertyType == typeof(DbSet<T>));
            // Try to save the value to the database and make sure there are no errors.
            using (var context = new TestDbContext())
            {
                var dbSet = (DbSet<T>)dbSetProperty.GetValue(context);
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
                var dbSet = (DbSet<T>)dbSetProperty.GetValue(context);
                var dbValue = dbSet.First();
                AssertObjectEqualityRecursive(dbValue, expectedValue, forDatabase: true);
            }
        }
    }
}
