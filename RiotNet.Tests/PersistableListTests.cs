using NUnit.Framework;
using RiotNet.Models;

namespace RiotNet.Tests
{
    [TestFixture]
    public class PersistableListTests
    {
        [Test]
        public void PersistableList_ShouldSerializeValue()
        {
            var list = new PersistableList<int> { -3, 6, 0 };

            Assert.That(list.Value, Is.EqualTo("[-3,6,0]"));
        }

        [Test]
        public void PersistableList_ShouldDeserializeValue()
        {
            var list = new PersistableList<double> { 0.5 };
            list.Capacity = 3;
            list.Value = "[-3.6,5.11,0]";

            Assert.That(list.Count, Is.EqualTo(3));
            Assert.That(list[0], Is.EqualTo(-3.6));
            Assert.That(list[1], Is.EqualTo(5.11));
            Assert.That(list[2], Is.EqualTo(0));
            Assert.That(list.Capacity, Is.GreaterThan(0));
            Assert.That(list.Capacity, Is.EqualTo(3));
        }

        [Test]
        public void PersistableList_ShouldDeserializeEmptyValue()
        {
            var list = new PersistableList<double> { 0.5 };
            list.Value = "";

            Assert.That(list.Count, Is.EqualTo(0));
        }
    }
}
