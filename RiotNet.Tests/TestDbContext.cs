using System.Data.Entity;
using RiotNet.Models;

namespace RiotNet.Tests
{
    public class TestDbContext : DbContext
    {
        static TestDbContext()
        {
            // For testing purposes, always drop and re-create the database at the start of the test session.
            Database.SetInitializer(new DropCreateDatabaseAlways<TestDbContext>());
        }

        public TestDbContext()
            : base("TestDBConnection")
        { }

        public IDbSet<BannedChampion> BannedChampions { get; set; }
        public IDbSet<Block> Blocks { get; set; }
        public IDbSet<BlockItem> BlockItems { get; set; }
        public IDbSet<Champion> Champions { get; set; }
        public IDbSet<ChampionStats> ChampionStats { get; set; }
        public IDbSet<Event> Events { get; set; }
        public IDbSet<Game> Games { get; set; }
        public IDbSet<Group> Groups { get; set; }
        public IDbSet<League> Leagues { get; set; }
        public IDbSet<LeagueEntry> LeagueEntries { get; set; }
        public IDbSet<Mastery> Masteries { get; set; }
        public IDbSet<MatchHistorySummary> MatchHistorySummaries { get; set; }
        public IDbSet<MatchDetail> MatchDetails { get; set; }
        public IDbSet<MatchParticipant> MatchParticipants { get; set; }
        public IDbSet<MatchParticipantFrame> MatchParticipantFrames { get; set; }
        public IDbSet<MatchParticipantIdentity> MatchParticipantIdentities { get; set; }
        public IDbSet<MatchTeam> MatchTeams { get; set; }
        public IDbSet<Passive> Passives { get; set; }
        public IDbSet<Player> Players { get; set; }
        public IDbSet<RankedStats> RankedStats { get; set; }
        public IDbSet<Recommended> RecommendedItemSets { get; set; }
        public IDbSet<Roster> Rosters { get; set; }
        public IDbSet<Rune> Runes { get; set; }
        public IDbSet<Skin> Skins { get; set; }
        public IDbSet<SpellVars> SpellVars { get; set; }
        public IDbSet<StaticChampion> StaticChampions { get; set; }
        public IDbSet<StaticChampionSpell> StaticChampionSpells { get; set; }
        public IDbSet<StaticImage> StaticImages { get; set; }
        public IDbSet<StaticItem> StaticItems { get; set; }
        public IDbSet<StaticItemTree> StaticItemTrees { get; set; }
        public IDbSet<StaticMapDetails> StaticMapDetails { get; set; }
        public IDbSet<StaticMastery> StaticMasteries { get; set; }
        public IDbSet<StaticMasteryTreeList> StaticMasteryTreeLists { get; set; }
        public IDbSet<StaticMasteryTree> StaticMasteryTrees { get; set; }
        public IDbSet<StaticRealm> StaticRealms { get; set; }
        public IDbSet<StaticRune> StaticRunes { get; set; }
        public IDbSet<StaticSummonerSpell> StaticSummonerSpells { get; set; }
        public IDbSet<Team> Teams { get; set; }
        public IDbSet<TeamMemberInfo> TeamMemberInfos { get; set; }
        public IDbSet<TeamStatDetail> TeamStatDetails { get; set; }
        public IDbSet<Timeline> Timelines { get; set; }
    }
}
