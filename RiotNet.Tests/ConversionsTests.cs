using NUnit.Framework;
using System;

namespace RiotNet.Tests
{
    [TestFixture]
    public class ConversionsTests
    {
        [Test]
        public void DateTimeToEpochMillisecondsTest()
        {
            var result = Conversions.DateTimeToEpochMilliseconds(new DateTime(2017, 5, 27, 13, 12, 11, 500, DateTimeKind.Utc));

            Assert.That(result, Is.EqualTo(1495890731500));
        }

        [Test]
        public void EpochMillisecondsToDateTimeTest()
        {
            var result = Conversions.EpochMillisecondsToDateTime(1495890731500);

            Assert.That(result, Is.EqualTo(new DateTime(2017, 5, 27, 13, 12, 11, 500, DateTimeKind.Utc)));
        }
    }
}
