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
        public DbSet<ChampionStats> ChampionStats { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<LeagueEntry> LeagueEntries { get; set; }
        public DbSet<MasteryPages> MasteryPages { get; set; }
        public DbSet<MatchHistorySummary> MatchHistorySummaries { get; set; }
        public DbSet<MatchDetail> MatchDetails { get; set; }
        public DbSet<MatchParticipant> MatchParticipants { get; set; }
        public DbSet<MatchParticipantFrame> MatchParticipantFrames { get; set; }
        public DbSet<MatchParticipantIdentity> MatchParticipantIdentities { get; set; }
        public DbSet<MatchReference> MatchReferences { get; set; }
        public DbSet<MatchTeam> MatchTeams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<RankedStats> RankedStats { get; set; }
        public DbSet<Recommended> RecommendedItemSets { get; set; }
        public DbSet<Roster> Rosters { get; set; }
        public DbSet<Rune> Runes { get; set; }
        public DbSet<RunePages> RunePages { get; set; }
        public DbSet<Skin> Skins { get; set; }
        public DbSet<SpellVars> SpellVars { get; set; }
        public DbSet<StaticChampion> StaticChampions { get; set; }
        public DbSet<StaticChampionSpell> StaticChampionSpells { get; set; }
        public DbSet<AltImage> StaticImages { get; set; }
        public DbSet<StaticItem> StaticItems { get; set; }
        public DbSet<StaticItemTree> StaticItemTrees { get; set; }
        public DbSet<StaticMapDetails> StaticMapDetails { get; set; }
        public DbSet<StaticMastery> StaticMasteries { get; set; }
        public DbSet<StaticMasteryTreeList> StaticMasteryTreeLists { get; set; }
        public DbSet<StaticMasteryTree> StaticMasteryTrees { get; set; }
        public DbSet<StaticRealm> StaticRealms { get; set; }
        public DbSet<StaticRune> StaticRunes { get; set; }
        public DbSet<StaticSummonerSpell> StaticSummonerSpells { get; set; }
        public DbSet<Summoner> Summoners { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMemberInfo> TeamMemberInfos { get; set; }
        public DbSet<TeamStatDetail> TeamStatDetails { get; set; }
        public DbSet<Timeline> Timelines { get; set; }
    }
}
