using Newtonsoft.Json;
using NUnit.Framework;
using RiotNet.Converters;

namespace RiotNet.Tests.Converters
{
    [TestFixture]
    public class TolerantEnumConverterTests
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

            Assert.That(value, Is.EqualTo((TestEnum)10));
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
        public void ShouldDeserializeNull()
        {
            var value = JsonConvert.DeserializeObject<TestEnum?>("null", jsonSettings);

            Assert.That(value, Is.Null);
        }

        [Test]
        public void ShouldSerializeInt()
        {
            var value = JsonConvert.SerializeObject(TestEnum.FourthValue, new JsonSerializerSettings { Converters = { new TolerantIntEnumConverter() } });

            Assert.That(value, Is.EqualTo("3"));
        }

        [Test]
        public void ShouldSerializeInt_ForNullableType()
        {
            var value = JsonConvert.SerializeObject((TestEnum?)TestEnum.FourthValue, new JsonSerializerSettings { Converters = { new TolerantIntEnumConverter() } });

            Assert.That(value, Is.EqualTo("3"));
        }

        [Test]
        public void ShouldSerializeString()
        {
            var value = JsonConvert.SerializeObject(TestEnum.FourthValue, jsonSettings);

            Assert.That(value, Is.EqualTo("\"FourthValue\""));
        }

        [Test]
        public void ShouldSerializeString_ForNullableType()
        {
            var value = JsonConvert.SerializeObject((TestEnum?)TestEnum.FourthValue, jsonSettings);

            Assert.That(value, Is.EqualTo("\"FourthValue\""));
        }

        [Test]
        public void ShouldSerializeNull()
        {
            var value = JsonConvert.SerializeObject((TestEnum?)null);

            Assert.That(value, Is.EqualTo("null"));
        }
    }
}
