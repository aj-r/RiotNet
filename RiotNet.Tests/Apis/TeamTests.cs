using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using RiotNet.Models;

namespace RiotNet.Tests
{
    [TestFixture]
    public class TeamTests : TestBase
    {
        [Test]
        public async Task GetTeamsBySummonerIdsAsyncTest()
        {
            IRiotClient client = new RiotClient(Region.NA);
            var teams = await client.GetTeamsBySummonerIdsAsync(35870943, 34317083);

            Assert.That(teams, Is.Not.Null);
            Assert.That(teams.Keys.Count, Is.GreaterThan(0));
            Assert.That(teams.Count, Is.GreaterThan(0));

            var summonerTeams = teams["35870943"];
            Assert.That(summonerTeams, Is.Not.Null.And.Not.Empty);

            var team = summonerTeams[0];
            Assert.That(team.CreateDate, Is.GreaterThan(default(DateTime)));
            Assert.That(team.FullId, Is.Not.Null.And.Not.Empty);
            Assert.That(team.LastGameDate, Is.GreaterThan(default(DateTime)));
            Assert.That(team.LastJoinDate, Is.GreaterThan(default(DateTime)));
            Assert.That(team.LastJoinedRankedTeamQueueDate, Is.GreaterThan(default(DateTime)));
            Assert.That(team.MatchHistory, Is.Not.Null.And.Not.Empty);
            Assert.That(team.ModifyDate, Is.GreaterThan(default(DateTime)));
            Assert.That(team.Name, Is.Not.Null.And.Not.Empty);
            Assert.That(team.Roster, Is.Not.Null);
            Assert.That(team.SecondLastJoinDate, Is.GreaterThan(default(DateTime)));
            Assert.That(team.Status, Is.Not.Null.And.Not.Empty);
            Assert.That(team.Tag, Is.Not.Null.And.Not.Empty);
            Assert.That(team.TeamStatDetails, Is.Not.Null.And.Not.Empty);
            Assert.That(team.ThirdLastJoinDate, Is.GreaterThan(default(DateTime)));

            var matchHistory = team.MatchHistory[0];
            Assert.That(team.MatchHistory.Any((x) => x.Assists > 0));
            Assert.That(matchHistory.Date, Is.GreaterThan(default(DateTime)));
            Assert.That(team.MatchHistory.Any((x) => x.Deaths > 0));
            Assert.That(matchHistory.GameId, Is.GreaterThan(0));
            Assert.That(matchHistory.GameMode, Is.EqualTo(GameMode.CLASSIC));
            // Loss prevented is pretty rare these days so Invalid is hard to test
            //Assert.That(summonerTeams.Any((x) => x.MatchHistory?.Any((y) => y.Invalid) == true));
            Assert.That(team.MatchHistory.Any((x) => x.Kills > 0));
            Assert.That(matchHistory.MapId, Is.GreaterThan(0));
            Assert.That(team.MatchHistory.Any((x) => x.OpposingTeamKills > 0));
            Assert.That(matchHistory.OpposingTeamName, Is.Not.Null.And.Not.Empty);
            Assert.That(team.MatchHistory.Any((x) => x.Win));

            var roster = team.Roster;
            Assert.That(roster.MemberList, Is.Not.Null.And.Not.Empty);
            Assert.That(roster.OwnerId, Is.GreaterThan(0));

            var teamMember = roster.MemberList[0];
            Assert.That(teamMember.InviteDate, Is.GreaterThan(default(DateTime)));
            Assert.That(teamMember.JoinDate, Is.GreaterThan(default(DateTime)));
            Assert.That(teamMember.PlayerId, Is.GreaterThan(0));
            Assert.That(teamMember.Status, Is.Not.Null.And.Not.Empty);

            var teamStatDetails = team.TeamStatDetails[0];
            Assert.That(team.TeamStatDetails.Any((x) => x.Losses > 0));
            Assert.That(teamStatDetails.AverageGamesPlayed, Is.EqualTo(0));
            Assert.That(team.TeamStatDetails.Any((x) => x.Wins > 0));
            Assert.That(team.TeamStatDetails.Any((x) => x.TeamStatType == RankedQueue.RANKED_TEAM_3x3));
        }

        [Test]
        public async Task GetTeamsByTeamIdsAsyncTest()
        {
            IRiotClient client = new RiotClient(Region.NA);
            var teams = await client.GetTeamsByTeamIdsAsync("TEAM-3503e740-b492-11e3-809d-782bcb4d0bb2", "TEAM-2a88df50-da0d-11e3-b43f-782bcb4d1861");

            Assert.That(teams.Keys.Count, Is.GreaterThan(0));
            Assert.That(teams.Count, Is.GreaterThan(0));

            var team1 = teams["TEAM-3503e740-b492-11e3-809d-782bcb4d0bb2"];
            Assert.That(team1, Is.Not.Null);

            var team2 = teams["TEAM-2a88df50-da0d-11e3-b43f-782bcb4d1861"];
            Assert.That(team2, Is.Not.Null);
        }
    }
}
