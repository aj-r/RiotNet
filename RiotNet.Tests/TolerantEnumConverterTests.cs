using Newtonsoft.Json;
using NUnit.Framework;
using RiotNet.Converters;
using RiotNet.Models;

namespace RiotNet.Tests
{
    [TestFixture]
    public class TolerantEnumConverterTests : TestBase
    {
        private static JsonSerializerSettings jsonSettings = RiotClient.JsonSettings;
        
        public enum TestEnum
        {
            FirstValue,
            SecondValue,
            ThirdValue,
            FourthValue
        }

        public class TestWrapper
        {
            public TestEnum? TeamId { get; set; }
        }

        [Test]
        public void ShouldDeserializeString()
        {
            var value = JsonConvert.DeserializeObject<TestEnum>("'SecondValue'", jsonSettings);

            Assert.That(value, Is.EqualTo(TestEnum.SecondValue));
        }

        [Test]
        public void ShouldDeserializeString_ForNullableType()
        {
            var value = JsonConvert.DeserializeObject<TestEnum?>("'SecondValue'", jsonSettings);

            Assert.That(value, Is.EqualTo(TestEnum.SecondValue));
        }

        [Test]
        public void ShouldDeserializeNonExistentString()
        {
            var value = JsonConvert.DeserializeObject<TestEnum>("'Foo'", jsonSettings);

            Assert.That(value, Is.EqualTo((TestEnum)(-1)));
        }

        [Test]
        public void ShouldDeserializeNonExistentString_ForNullableType()
        {
            var value = JsonConvert.DeserializeObject<TestEnum?>("'Foo'", jsonSettings);

            Assert.That(value, Is.Null);
        }

        [Test]
        public void ShouldDeserializeInt()
        {
            var value = JsonConvert.DeserializeObject<TestEnum>("2", jsonSettings);

            Assert.That(value, Is.EqualTo(TestEnum.ThirdValue));
        }

        [Test]
        public void ShouldDeserializeInt_ForNullableType()
        {
            var value = JsonConvert.DeserializeObject<TestEnum?>("2", jsonSettings);
            
            Assert.That(value, Is.EqualTo(TestEnum.ThirdValue));
        }

        [Test]
        public void ShouldDeserializeNonExistentInt()
        {
            var value = JsonConvert.DeserializeObject<TestEnum>("10", jsonSettings);

            Assert.That(value, Is.EqualTo((TestEnum)10));
        }

        [Test]
        public void ShouldDeserializeNonExistentInt_ForNullableType()
        {
            var value = JsonConvert.DeserializeObject<TestEnum?>("10", jsonSettings);

            Assert.That(value, Is.Null);
        }
    }
}
