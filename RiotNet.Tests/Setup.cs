using NUnit.Framework;

namespace RiotNet.Tests
{
    [SetUpFixture]
    public class Setup
    {
        // IMPORTANT: in order for the tests to work, you must enter your API key here.
        private const string apiKey = "";

        // NOTE: running all tests WILL max out your rate limit (if you have a standard API key) and may take several minutes.

        [SetUp]
        public void GlobalSetUp()
        {
            RiotClientSettings.Default = () => new RiotClientSettings { ApiKey = apiKey };
        }
    }
}
