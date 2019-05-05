using RiotNet.Models;
#if NET_CORE
using Microsoft.EntityFrameworkCore;
#else
using System.Data.Entity;
#endif

namespace RiotNet.Tests
{
    public class TestDbContext : DbContext
    {
#if NET_CORE
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("TestDBConnection");
            base.OnConfiguring(optionsBuilder);
        }
#else
        static TestDbContext()
        {
            // For testing purposes, always drop and re-create the database at the start of the test session.
            //Database.SetInitializer(new DropCreateDatabaseAlways<TestDbContext>());
            Microsoft.EntityFrameworkCore.D
        }

        public TestDbContext()
            : base("TestDBConnection")
        { }
#endif

        public DbSet<BannedChampion> BannedChampions { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<BlockItem> BlockItems { get; set; }
        public DbSet<Champion> Champions { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<LeagueList> LeagueLists { get; set; }
        public DbSet<LeagueItem> LeagueItems { get; set; }
        public DbSet<LeaguePosition> LeaguePositions { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchEvent> MatchEvents { get; set; }
        public DbSet<MatchParticipant> MatchParticipants { get; set; }
        public DbSet<MatchParticipantFrame> MatchParticipantFrames { get; set; }
        public DbSet<MatchParticipantIdentity> MatchParticipantIdentities { get; set; }
        public DbSet<MatchReference> MatchReferences { get; set; }
        public DbSet<MatchTeam> MatchTeams { get; set; }
        public DbSet<MatchTimeline> MatchTimelines { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Recommended> RecommendedItemSets { get; set; }
        public DbSet<Rune> Runes { get; set; }
        public DbSet<Skin> Skins { get; set; }
        public DbSet<SpellVars> SpellVars { get; set; }
        public DbSet<AltImage> StaticImages { get; set; }
        public DbSet<Summoner> Summoners { get; set; }
    }
}
