using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.ObjectModel;

namespace RiotNet.Tests.Converters
{
    [TestFixture]
    public class KeyedCollectionConverterTests
    {
        private static JsonSerializerSettings jsonSettings = RiotClient.JsonSettings;
        
        private class TestKeyedCollection : KeyedCollection<string, int>
        {
            protected override string GetKeyForItem(int item)
            {
                return item.ToString();
            }
        }

        [Test]
        public void ShouldDeserialize()
        {
            var value = JsonConvert.DeserializeObject<TestKeyedCollection>("{\"2\":2,\"5\":5}", jsonSettings);

            Assert.That(value.Count, Is.EqualTo(2), "Wrong count");
            Assert.That(value["2"], Is.EqualTo(2));
            Assert.That(value["5"], Is.EqualTo(5));
        }
        
        [Test]
        public void ShouldDeserializeNull()
        {
            var value = JsonConvert.DeserializeObject<TestKeyedCollection>("null", jsonSettings);

            Assert.That(value, Is.Null);
        }

        [Test]
        public void ShouldSerialize()
        {
            var collection = new TestKeyedCollection() { 11, 12, 13 };
            var value = JsonConvert.SerializeObject(collection, jsonSettings);

            Assert.That(value, Is.EqualTo("{\"11\":11,\"12\":12,\"13\":13}"));
        }
    }
}
