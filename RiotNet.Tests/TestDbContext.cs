using System.Data.Entity;
using RiotNet.Models;

namespace RiotNet.Tests
{
    public class TestDbContext : DbContext
    {
        static TestDbContext()
        {
            // Always drop and recreate the database at the start of the test session.
            Database.SetInitializer(new DropCreateDatabaseAlways<TestDbContext>());
        }

        public TestDbContext()
            : base("TestDBConnection")
        { }

        public IDbSet<Block> Blocks { get; set; }
        public IDbSet<BlockItem> BlockItems { get; set; }
        public IDbSet<Champion> Champions { get; set; }
        public IDbSet<Game> Games { get; set; }
        public IDbSet<Group> Groups { get; set; }
        public IDbSet<StaticImage> Images { get; set; }
        public IDbSet<StaticItem> Items { get; set; }
        public IDbSet<StaticItemTree> ItemTrees { get; set; }
        public IDbSet<League> Leagues { get; set; }
        public IDbSet<LeagueEntry> LeagueEntries { get; set; }
        public IDbSet<StaticMapDetails> MapDetails { get; set; }
        public IDbSet<MatchHistorySummary> MatchHistorySummaries { get; set; }
        public IDbSet<Passive> Passives { get; set; }
        public IDbSet<Recommended> RecommendedItemSets { get; set; }
        public IDbSet<Roster> Rosters { get; set; }
        public IDbSet<StaticRune> Runes { get; set; }
        public IDbSet<Skin> Skins { get; set; }
        public IDbSet<SpellVars> SpellVars { get; set; }
        public IDbSet<StaticChampion> StaticChampions { get; set; }
        public IDbSet<StaticChampionSpell> StaticChampionSpells { get; set; }
        public IDbSet<Team> Teams { get; set; }
        public IDbSet<TeamMemberInfo> TeamMemberInfos { get; set; }
        public IDbSet<TeamStatDetail> TeamStatDetails { get; set; }
    }
}
