using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace RiotNet.Tests
{
    public class TestRiotClient : RiotClient
    {
        /// <summary>
        /// Creates a new <see cref="TestRiotClient"/> instance.
        /// </summary>
        public TestRiotClient()
        { }

        /// <summary>
        /// Creates a new <see cref="TestRiotClient"/> instance.
        /// </summary>
        /// <param name="settings">The settings to use.</param>
        public TestRiotClient(RiotClientSettings settings)
            : base(settings, Models.PlatformId.NA1)
        { }

        protected override HttpClient CreateHttpClient()
        {
            return new HttpClient(MessageHandler);
        }

        public new HttpClient Client => base.Client;

        public FakeHttpMessageHandler MessageHandler { get; } = new FakeHttpMessageHandler();

        public async Task WaitForRetryAfterDelay()
        {
            MessageHandler.RespondWithStatus(HttpStatusCode.OK);
            try
            {
                await SendAsync(new HttpRequestMessage(), Models.PlatformId.NA1, default(CancellationToken));
            }
            catch { }
        }

        public class FakeHttpMessageHandler : DelegatingHandler
        {
            private int responseCount = 0;
            private List<HttpStatusCode> statusCodes = new List<HttpStatusCode>();
            private int delay;

            public FakeHttpMessageHandler()
            {
                InnerHandler = new HttpClientHandler();
            }

            public FakeHttpMessageHandler RespondWithStatus(HttpStatusCode statusCode)
            {
                statusCodes.Clear();
                statusCodes.Add(statusCode);
                return this;
            }

            public FakeHttpMessageHandler ThenWithStatus(HttpStatusCode statusCode)
            {
                statusCodes.Add(statusCode);
                return this;
            }

            public FakeHttpMessageHandler FailConnection()
            {
                return RespondWithStatus((HttpStatusCode)(-1));
            }

            public FakeHttpMessageHandler ThenFailConnection()
            {
                return ThenWithStatus((HttpStatusCode)(-1));
            }

            public FakeHttpMessageHandler Delay(int milliseconds)
            {
                delay = milliseconds;
                return this;
            }

            public FakeHttpMessageHandler PassThrough()
            {
                statusCodes.Clear();
                return this;
            }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                if (delay > 0)
                    await Task.Delay(delay);

                if (!statusCodes.Any())
                    return await base.SendAsync(request, cancellationToken);

                cancellationToken.ThrowIfCancellationRequested();

                var statusCode = statusCodes[responseCount % statusCodes.Count];
                ++responseCount;
                if ((int)statusCode != -1)
                    return new HttpResponseMessage(statusCode);
                else
                    return null;
            }
        }
    }
}
