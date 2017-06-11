using Newtonsoft.Json;
using NUnit.Framework;
using System;

namespace RiotNet.Tests.Converters
{
    [TestFixture]
    public class SecondsToTimeSpanConverterTests
    {
        private static JsonSerializerSettings jsonSettings = RiotClient.JsonSettings;

        [Test]
        public void ShouldDeserializeInt()
        {
            var value = JsonConvert.DeserializeObject<TimeSpan>("125", jsonSettings);

            Assert.That(value, Is.EqualTo(TimeSpan.FromSeconds(125)));
        }

        [Test]
        public void ShouldDeserializeInt_ForNullableType()
        {
            var value = JsonConvert.DeserializeObject<TimeSpan?>("125", jsonSettings);

            Assert.That(value, Is.EqualTo(TimeSpan.FromSeconds(125)));
        }

        [Test]
        public void ShouldDeserializeFloat()
        {
            var value = JsonConvert.DeserializeObject<TimeSpan>("125.3", jsonSettings);

            Assert.That(value, Is.EqualTo(TimeSpan.FromSeconds(125.3)));
        }
        
        [Test]
        public void ShouldDeserializeNull()
        {
            var value = JsonConvert.DeserializeObject<TimeSpan?>("null", jsonSettings);

            Assert.That(value, Is.Null);
        }

        [Test]
        public void ShouldSerializeInt()
        {
            var value = JsonConvert.SerializeObject(TimeSpan.FromMinutes(2.5), jsonSettings);

            Assert.That(value, Is.EqualTo("150"));
        }
    }
}
