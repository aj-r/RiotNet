using NUnit.Framework;
using RiotNet.Models;

namespace RiotNet.Tests
{
    [TestFixture]
    public class PersistableDictionaryTests
    {
        [Test]
        public void PersistableDictionary_ShouldSerializeValue()
        {
            var dictionary = new PersistableDictionary<string, double>
            {
                { "a", -12.4 },
                { "b", 6.01 },
            };

            Assert.That(dictionary.Value, Is.EqualTo("{\"a\":-12.4,\"b\":6.01}"));
        }

        [Test]
        public void PersistableDictionary_ShouldDeserializeValue()
        {
            var dictionary = new PersistableDictionary<string, string> { { "x", "y" } };
            dictionary.Value = "{\"a\":\"A\",\"b\":\"B\"}";

            Assert.That(dictionary.Count, Is.EqualTo(2));
            Assert.That(dictionary["a"], Is.EqualTo("A"));
            Assert.That(dictionary["b"], Is.EqualTo("B"));
        }

        [Test]
        public void PersistableDictionary_ShouldDeserializeEmptyValue()
        {
            var dictionary = new PersistableDictionary<string, double> { { "x", 0 } };
            dictionary.Value = "";

            Assert.That(dictionary.Count, Is.EqualTo(0));
        }
    }
}
