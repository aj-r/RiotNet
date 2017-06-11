using Newtonsoft.Json;
using NUnit.Framework;
using RiotNet.Converters;
using RiotNet.Models;
using System.Collections.Generic;

namespace RiotNet.Tests.Converters
{
    [TestFixture]
    public class RangeConverterTests
    {
        private static JsonSerializerSettings jsonSettings = new JsonSerializerSettings
        {
            Converters = new List<JsonConverter> { new RangeConverter() },
        };

        [Test]
        public void ShouldDeserializeArray()
        {
            var value = JsonConvert.DeserializeObject<ListOfInt>("[1,2,5.6]", jsonSettings);

            Assert.That(value.Count, Is.EqualTo(3));
            Assert.That(value[0], Is.EqualTo(1));
            Assert.That(value[1], Is.EqualTo(2));
            Assert.That(value[2], Is.EqualTo(6));
        }

        [Test]
        public void ShouldDeserializeSelf()
        {
            var value = JsonConvert.DeserializeObject<ListOfInt>("\"self\"", jsonSettings);

            Assert.That(value.Count, Is.EqualTo(1));
            Assert.That(value[0], Is.EqualTo(0));
        }

        [Test]
        public void ShouldSerializeArray()
        {
            var value = JsonConvert.SerializeObject(new ListOfInt { 2, 11, 3 }, jsonSettings);

            Assert.That(value, Is.EqualTo("[2,11,3]"));
        }

        [Test]
        public void ShouldSerializeSelf()
        {
            var value = JsonConvert.SerializeObject(new ListOfInt { 0 }, jsonSettings);

            Assert.That(value, Is.EqualTo("\"self\""));
        }
    }
}
