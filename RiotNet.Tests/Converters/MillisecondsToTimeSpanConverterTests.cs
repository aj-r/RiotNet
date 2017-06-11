using Newtonsoft.Json;
using NUnit.Framework;
using RiotNet.Converters;
using System;
using System.Collections.Generic;

namespace RiotNet.Tests.Converters
{
    [TestFixture]
    public class MillisecondsToTimeSpanConverterTests
    {
        private static JsonSerializerSettings jsonSettings = new JsonSerializerSettings
        {
            Converters = new List<JsonConverter> { new MillisecondsToTimeSpanConverter() },
        };

        [Test]
        public void ShouldDeserializeInt()
        {
            var value = JsonConvert.DeserializeObject<TimeSpan>("125123", jsonSettings);

            Assert.That(value, Is.EqualTo(TimeSpan.FromMilliseconds(125123)));
        }

        [Test]
        public void ShouldDeserializeInt_ForNullableType()
        {
            var value = JsonConvert.DeserializeObject<TimeSpan?>("125123", jsonSettings);

            Assert.That(value, Is.EqualTo(TimeSpan.FromMilliseconds(125123)));
        }

        [Test]
        public void ShouldDeserializeFloat()
        {
            var value = JsonConvert.DeserializeObject<TimeSpan>("125.123", jsonSettings);

            Assert.That(value, Is.EqualTo(TimeSpan.FromMilliseconds(125.123)));
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

            Assert.That(value, Is.EqualTo("150000"));
        }
    }
}
