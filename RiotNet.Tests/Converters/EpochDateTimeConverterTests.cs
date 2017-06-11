using Newtonsoft.Json;
using NUnit.Framework;
using System;

namespace RiotNet.Tests.Converters
{
    [TestFixture]
    public class EpochDateTimeConverterTests
    {
        private static JsonSerializerSettings jsonSettings = RiotClient.JsonSettings;

        [Test]
        public void ShouldDeserializeInt()
        {
            var value = JsonConvert.DeserializeObject<DateTime>("1497148612500", jsonSettings);

            Assert.That(value, Is.EqualTo(new DateTime(2017, 6, 11, 2, 36, 52, 500, DateTimeKind.Utc)));
            Assert.That(value.Kind, Is.EqualTo(DateTimeKind.Utc));
        }

        [Test]
        public void ShouldDeserializeInt_ForNullableType()
        {
            var value = JsonConvert.DeserializeObject<DateTime?>("1486256523789", jsonSettings);

            Assert.That(value.Value, Is.EqualTo(new DateTime(2017, 2, 5, 1, 2, 3, 789, DateTimeKind.Utc)));
            Assert.That(value.Value.Kind, Is.EqualTo(DateTimeKind.Utc));
        }
        
        [Test]
        public void ShouldDeserializeEpochString()
        {
            var value = JsonConvert.DeserializeObject<DateTime>("\"1497148612500\"", jsonSettings);

            Assert.That(value, Is.EqualTo(new DateTime(2017, 6, 11, 2, 36, 52, 500, DateTimeKind.Utc)));
            Assert.That(value.Kind, Is.EqualTo(DateTimeKind.Utc));
        }

        [Test]
        public void ShouldDeserializeEpochString_ForNullableType()
        {
            var value = JsonConvert.DeserializeObject<DateTime?>("\"1497148612500\"", jsonSettings);

            Assert.That(value.Value, Is.EqualTo(new DateTime(2017, 6, 11, 2, 36, 52, 500, DateTimeKind.Utc)));
            Assert.That(value.Value.Kind, Is.EqualTo(DateTimeKind.Utc));
        }

        [Test]
        public void ShouldDeserializeDate()
        {
            var value = JsonConvert.DeserializeObject<DateTime>("\"2017-07-30T08:45:30.500Z\"", jsonSettings);

            Assert.That(value, Is.EqualTo(new DateTime(2017, 7, 30, 8, 45, 30, 500, DateTimeKind.Utc)));
            Assert.That(value.Kind, Is.EqualTo(DateTimeKind.Utc));
        }

        [Test]
        public void ShouldDeserializeInt_ToDateTimeOffset()
        {
            var value = JsonConvert.DeserializeObject<DateTimeOffset>("1497148612500", jsonSettings);

            Assert.That(value, Is.EqualTo(new DateTimeOffset(2017, 6, 11, 2, 36, 52, 500, TimeSpan.FromHours(0))));
        }

        [Test]
        public void ShouldDeserializeNull()
        {
            var value = JsonConvert.DeserializeObject<DateTime?>("null", jsonSettings);

            Assert.That(value, Is.Null);
        }

        [Test]
        public void ShouldSerializeInt()
        {
            var value = JsonConvert.SerializeObject(new DateTime(2017, 6, 11, 2, 36, 52, 500, DateTimeKind.Utc), jsonSettings);

            Assert.That(value, Is.EqualTo("1497148612500"));
        }

        [Test]
        public void ShouldSerializeInt_ForNullableType()
        {
            var value = JsonConvert.SerializeObject((DateTime?)new DateTime(2017, 6, 11, 2, 36, 52, 500, DateTimeKind.Utc), jsonSettings);

            Assert.That(value, Is.EqualTo("1497148612500"));
        }
    }
}
