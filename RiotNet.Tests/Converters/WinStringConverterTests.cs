using Newtonsoft.Json;
using NUnit.Framework;
using RiotNet.Converters;

namespace RiotNet.Tests.Converters
{
    [TestFixture]
    public class WinStringConverterTests
    {
        private static JsonSerializerSettings jsonSettings = RiotClient.JsonSettings;

        public class TestWrapper
        {
            [JsonConverter(typeof(WinStringConverter))]
            public bool win { get; set; }
        }

        [Test]
        public void ShouldDeserializeWin()
        {
            var value = JsonConvert.DeserializeObject<TestWrapper>("{\"win\":\"Win\"}");

            Assert.That(value.win, Is.True);
        }

        [Test]
        public void ShouldDeserializeFail()
        {
            var value = JsonConvert.DeserializeObject<TestWrapper>("{\"win\":\"Fail\"}");

            Assert.That(value.win, Is.False);
        }

        [Test]
        public void ShouldSerializeWin()
        {
            var value = JsonConvert.SerializeObject(new TestWrapper { win = true });

            Assert.That(value, Is.EqualTo("{\"win\":\"Win\"}"));
        }

        [Test]
        public void ShouldSerializeFail()
        {
            var value = JsonConvert.SerializeObject(new TestWrapper { win = false });

            Assert.That(value, Is.EqualTo("{\"win\":\"Fail\"}"));
        }
    }
}
