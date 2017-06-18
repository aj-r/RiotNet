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

        [TestCase(Locale.cs_CZ, "cs-CZ", "Czech (Czech Republic)")]
        [TestCase(Locale.en_US, "en-US", "English (United States)")]
        [TestCase(Locale.vn_VN, "vi-VN", "Vietnamese (Vietnam)")]
        public void Locale_GetCultureInfoTest(string locale, string expectedName, string expectedEnglishName)
        {
            var culture = Locale.GetCultureInfo(locale);
            Assert.That(culture.Name, Is.EqualTo(expectedName));
            Assert.That(culture.EnglishName, Is.EqualTo(expectedEnglishName));
        }

        [Test]
        public void Locale_GetCultureInfoTest_Exceptions()
        {
            Assert.That(() => Locale.GetCultureInfo(null), Throws.ArgumentNullException);
        }
    }
}
