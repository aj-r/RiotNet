using NUnit.Framework;
using RiotNet.Models;

namespace RiotNet.Tests
{
    [TestFixture]
    public class ConstantsTests
    {
        [TestCase(PlayerPosition.BOTTOM, ExpectedResult = false)]
        [TestCase(PlayerPosition.TOP, ExpectedResult = false)]
        [TestCase(PlayerPosition.MID, ExpectedResult = true)]
        [TestCase(PlayerPosition.MIDDLE, ExpectedResult = true)]
        public bool PlayerPosition_IsMidLaneTest(string position)
        {
            return PlayerPosition.IsMidLane(position);
        }

        [TestCase(PlatformId.NA1, ExpectedResult = true)]
        [TestCase("NA", ExpectedResult = true)]
        [TestCase(PlatformId.LA1, ExpectedResult = false)]
        [TestCase("FOO", ExpectedResult = false)]
        public bool PlatformId_IsNorthAmericaTest(string platformId)
        {
            return PlatformId.IsNorthAmerica(platformId);
        }
    }
}
