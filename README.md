# RiotNet

[![NuGet](https://img.shields.io/nuget/v/RiotNet.svg)](https://www.nuget.org/packages/RiotNet/) [![build](https://travis-ci.org/aj-r/RiotNet.svg?branch=master)](https://travis-ci.org/aj-r/RiotNet)

A .NET/C# client for the Riot Games API.

It has the following features:
- **Compatible** with .NET Core and .NET 4.5.
- [**NuGet package**](https://www.nuget.org/packages/RiotNet/): `Install-Package RiotNet`
- [**Full Documentation**](http://aj-r.github.io/RiotNet/docs/interface_riot_net_1_1_i_riot_client.html) - documentation of every method and every property of every object. (Or at least as much as we can figure out from examining the JSON responses. Riot's API documentation is a bit lacking right now.)
- [**Full API coverage**](https://github.com/aj-r/RiotNet/wiki/API-Route-Mapping) - methods for accessing to every endpoint in the Riot Games API.
- **Flexible and configurable** - uses interfaces and allows inheritance.
- **Database Ready** - data structures have built-in database metadata, so you can easily persist results using Entity Framework 6 without having to re-define all of the models.
- **Complies** with Riot's [rate limiting best practices](https://developer.riotgames.com/rate-limiting.html), so you don't need to worry about getting soft banned.
  - You may also want to follow the [Tips to Avoid Being Rate Limited](https://developer.riotgames.com/rate-limiting.html) to improve your application's performance.
- **Thread-Safe**: Built for server applications that need to handle concurrent requests with high performance.
- **Asynchronous methods** - methods are awaitable using the async/await keywords.
- **Unit Test Coverage** - over 90%

RiotNet is NOT endorsed by Riot Games and doesn't reflect the views or opinions of Riot Games or anyone officially involved in producing or managing League of Legends.

## Versions

This library uses symantic versioning, so version numbers are **not** correlated with version numbers of the Riot API.

- v4 of RiotNet is compatible with v3 of the Riot APIs. If you're upgrading to v4 from a previous version, see the [Upgrade Path](https://github.com/aj-r/RiotNet/wiki/RiotNet-Upgrade-Path).
- v1-v3 of RiotNet are compatible with the old versions of the Riot APIs (v1/v2, depending on which API you're looking at)

## Basic Usage

```
IRiotClient client = new RiotClient(new RiotClientSettings
{
    ApiKey = "00000000-0000-0000-0000-000000000000" // Replace this with your API key, of course.
});
Summoner summoner = await client.GetSummonerBySummonerNameAsync(PlatformId.NA1).ConfigureAwait(false);
```

## Changing the default settings

You can change the default settings that are applied to new `RiotClient` instances, so you don't need to pass the settings every time.

```
RiotClient.DefaultPlatformId = PlatformId.EUW1;
RiotClient.DefaultSettings = () => new RiotClientSettings
{
    ApiKey = "00000000-0000-0000-0000-000000000000" // Replace this with your API key, of course.
};
IRiotClient client = new RiotClient(); // Now you don't need to pass the settings or platform ID parameters.
```

## Rate limiting

RiotNet will automatically handle rate limiting for you, so you don't need to worry about building your own rate limiting system.
RiotNet handles rate limiting in two ways: reactively and proactively. Neither system is perfect on its own, but together they should cover almost all scenarios.

### Reactive Rate Limiting

If you go over your rate limit, and the client receives a rate limit error from the server, it will read the `Retry-After` header, and wait for that amount of time before retrying the request.

Pros:

- Automatically re-sends your request after the required amount of time passes.
- Suspends future requests until that time passes, so you don't need to worry about getting soft banned by accident.
- Throttled requests are placed in a queue, so they will be sent in the order you created them.
- It accounts for all types of rate limits.

Cons:

- Requests aren't throttled until a 429 error response is received from the server. So if you send 10,000 requests at once before you receive a response, you could
  end up going way over your rate limit. If you're worried about that happening, enable proactive rate limiting.

### Proactive Rate Limiting

Proactive rate limiting works by tracking the number of requests that the RiotClient has sent, and throttling requests if it thinks you're going to hit your limit.
Proactive rate limiting is optional and disabled by default. You can enable it by creating a `RateLimiter` object that tells the `RiotClient` what your rate limit is.

```
// 10 requests per 10 seconds, 500 requests per 10 minutes (developer key)
// NOTE: you should replace these numbers with your production key rates
RiotClient.RateLimiter = new RateLimiter(10, 500);
IRiotClient client = new RiotClient();
```

Pros:

- Prevents you from going over your rate limit at all, 
- Throttled requests are placed in a queue, so they will be sent in the order you created them.

Cons:

- It doesn't account for per-method rate limits (only per-platform rate limits)
- Requests are counted separately from the server, so it's possible that the client's request count could get out of sync with the server (especially right after you restart your application).
- It has a (very small) performance impact on each request. But if you're staying under your rate limit, this performance impact is so small that it should be unnoticeable.

## Interim Keys for the Tournament API

If you are using the Tournament API, you will probably get an interim key during development. The interim key uses slightly different routes, so you need to set `UseTournamentStub` to `true` in the settings:

```
RiotClient.DefaultSettings = () => new RiotClientSettings
{
    ApiKey = "00000000-0000-0000-0000-000000000000", // Replace this with your API key, of course.
    UseTournamentStub = true,
};
```

Just don't forget to set it to `false` once you go into production!

## Error Handling

You can customize how the `RiotClient` handles errors from the server.
By default, it will retry the request up to 3 times if there is a server error or rate limit error. If the error still occurs on the third try, it will throw an exception.

You can change that behaviour by using the following settings:

- `MaxRequestAttempts` - the maximum number of times that the client will send or re-send a single request. Minimum 1. It is recommended to set this to at least 2 because the API seems to occasionally respond with 500-level errors.
- `ThrowOnError` - whether the client should throw an exception if the response contains an error (even after all retry attempts). If you set this to false, the client will return `null` instead.
- `ThrowOnNotFound` - whether the client should throw an exception if the server responds with a 404 (Not Found) error. This could happen if you request a resource that does not exist. For example, if you request the current game for a summoner, but that summoner is not in game, the server will send a 404. Default value is false.
- `RetryOnServerError` - Retry the request if the server reponds with an error code of 500 or higher. Default value is true.
- `RetryOnRateLimitExceeded` - Retry the request if the server reponds with a 429 (Rate Limit Exceeded) error. Default value is true.
- `RetryOnTimeout` - Retry the request if the request times out. Default value is false.
- `RetryOnConnectionFailure` - Retry the request if the connection to the server fails. Default value is false.
- `UseTournamentStub` - Set this to true if you have an interim API key. If you do, the client will use special tournament stub endpoints when using the Tournament API.

## More examples

See the tests for more extensive examples.

## Contributions

- If you think something is missing or needs to be updated, create an issue to open discussion.
- If you see an issue that isn't assigned yet, and you want to work on it, assign it to yourself!
- Make sure your PR contains relevant unit tests for the code you changed.

## Dependencies

- Newtonsoft.Json 9.0.1
