using System;
using System.IO;
using NUnit.Framework;

namespace RiotNet.Tests
{
    [SetUpFixture]
    public class Setup
    {
        // NOTE: running all tests WILL max out your rate limit (if you have a standard API key) and may take several minutes.

        [SetUp]
        public void GlobalSetUp()
        {
            // Load the API key from the text file.
            string apiKey;
            try
            {
                apiKey = File.ReadAllText("key.txt");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Please enter your API key in key.txt");
                throw;
            }
            RiotClientSettings.Default = () => new RiotClientSettings { ApiKey = apiKey };
        }
    }
}
