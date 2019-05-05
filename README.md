# RiotNet

[![NuGet](https://img.shields.io/nuget/v/RiotNet.svg)](https://www.nuget.org/packages/RiotNet/) [![build](https://travis-ci.org/aj-r/RiotNet.svg?branch=master)](https://travis-ci.org/aj-r/RiotNet)

A .NET/C# client for the Riot Games API.

It has the following features:
- Targets v4 of the Riot API
- Built-in rate limiting (per-method and per-endpoint)
- **Compatible** with .NET Core and .NET 4.5
- [**NuGet package**](https://www.nuget.org/packages/RiotNet/): `Install-Package RiotNet`
- [**Full Documentation**](http://aj-r.github.io/RiotNet/docs/interface_riot_net_1_1_i_riot_client.html) - documentation of every method and every property of every object. (Or at least as much as we can figure out from examining the JSON responses. Riot's API documentation is a bit lacking right now.)
- [**Full API coverage**](https://github.com/aj-r/RiotNet/wiki/API-Route-Mapping) - methods for accessing to every endpoint in the Riot Games API.
- **Flexible and configurable** - uses interfaces and allows inheritance
- **Database Ready** - data structures have built-in database metadata, so you can easily persist results using Entity Framework 6 without having to re-define all of the models
- **Complies** with Riot's [rate limiting best practices](https://developer.riotgames.com/rate-limiting.html), so you don't need to worry about getting soft banned
  - You may also want to follow the [Tips to Avoid Being Rate Limited](https://developer.riotgames.com/rate-limiting.html) to improve your application's performance
- **Thread-Safe**: Built for server applications that need to handle concurrent requests with high performance
- **Asynchronous methods** - methods are awaitable using the async/await keywords
- **Unit Test Coverage** - over 90%

RiotNet is NOT endorsed by Riot Games and doesn't reflect the views or opinions of Riot Games or anyone officially involved in producing or managing League of Legends.

## Versions

This library uses semantic versioning, so version numbers are **not** correlated with version numbers of the Riot API.

- **v4** of the Riot APIs are implemented in v7.X-v8.X of RiotNet
  - Note: Riot Games hasn't released v4 of every API yet, so for those APIs we support v3.
- **v3** of the Riot APIs is implemented in v4.X-v6.X of RiotNet.
  - If you're upgrading to v4.X/v6.X from a previous version, see the [Upgrade Path](https://github.com/aj-r/RiotNet/wiki/RiotNet-Upgrade-Path).
- **v1/v2** of the Riot APIs are implemented in v1.X-v3.X of RiotNet.

## Basic Usage

```
IRiotClient client = new RiotClient(new RiotClientSettings
{
    ApiKey = "00000000-0000-0000-0000-000000000000" // Replace this with your API key, of course.
});
Summoner summoner = await client.GetSummonerBySummonerNameAsync("<name>", PlatformId.NA1).ConfigureAwait(false);
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
RiotNet handles rate limiting in two ways:

### Proactive Rate Limiting

- Works by tracking the number of requests that the RiotClient has sent, and throttling requests if it thinks you're going to hit your limit.
- Prevents you from going over your rate limit at all, so you don't need to worry about getting soft banned by accident.
- Automatically re-sends your request after the required amount of time passes.
- Automatically detects your API key's rate limits using the HTTP headers returned from the Riot servers.
- Tracks requests separately for each method and for each endpoint.
- Throttled requests are placed in a queue, so they will be re-sent in the order you created them (to prevent starvation).
- Enabled by default. You can disable it, but it's strongly discouraged.
- Requests are counted separately from the server, so it's possible that the client's request count could get out of sync with the server. To deal with this, we use Reactive Rate Limiting as a backup.

### Reactive Rate Limiting (header-based)

If you go over your rate limit, and the client receives a rate limit error from the server, it will read the `Retry-After` header, and wait for that amount of time before retrying the request.

- Automatically re-sends your request after the required amount of time passes.
- Suspends future requests until that time passes, so you should never get soft banned by Riot (unless you try really hard).
- Throttled requests are placed in a queue, so they will be sent in the order you created them.
- It accounts for all types of rate limits.

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
