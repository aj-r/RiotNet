# RiotNet

A .NET/C# client for the Riot Games API.

It has the following features:
- **Synchronous and asynchronous** overloads for each method. Asynchronous methods are awaitable using the async/await keywords.
- **Flexible and configurable** - uses interfaces and allows inheritance.
- **Database Ready** - data structures have built-in database metadata, so you can easily persist results using Entity Framework 6 without having to re-define all of the models.
- [**Full Documentation**](http://aj-r.github.io/RiotNet/docs/interface_riot_net_1_1_i_riot_client.html) - documentation of every method and every property of every object. (Or at least as much as we can figure out from examining the JSON responses. Riot's API documentation is a bit lacking right now.)
- **Full API coverage** - methods for accessing to every endpoint in the Riot Games API.
- **Full Test Coverage** - so you can trust that it works.
  - However, if you think we missed something, or need to update something, please create an issue. Or better yet, create a pull request!
- **Compatible** with .NET Core and .NET 4.5.
- **Complies** with Riot's [rate limiting best practices](https://developer.riotgames.com/docs/rate-limiting)
- [**NuGet package**](https://www.nuget.org/packages/RiotNet/):

```
> Install-Package RiotNet
```

RiotNet is NOT endorsed by Riot Games and doesn't reflect the views or opinions of Riot Games or anyone officially involved in producing or managing League of Legends.

## Basic Usage

```
var client = new RiotClient(Region.NA, new RiotClientSettings
{
    ApiKey = "00000000-0000-0000-0000-000000000000" // Replace this with your API key, of course.
});
var championList = await client.GetChampionsAsync().ConfigureAwait(false);
```

## Changing the default settings

You can change the default settings that are applied to new `RiotClient` instances, so you don't need to pass the settings every time.

```
RiotClient.DefaultSettings = () => new RiotClientSettings
{
    ApiKey = "00000000-0000-0000-0000-000000000000" // Replace this with your API key, of course.
};

IRiotClient client = new RiotClient(Region.NA); // Now you don't need to pass the settings parameter.
```

## Interim Keys for the Tournament API

If you are using the Tournament API, you will probably get an interim key during development. The interim key uses slightly different routes, so you need to set `UseTournamentStub` to `true` in the settings:

```
RiotClient.DefaultSettings = () => new RiotClientSettings
{
    ApiKey = "00000000-0000-0000-0000-000000000000", // Replace this with your API key, of course.
	UseTournamentStub = true
};
```

Just don't forget to set it to `false` once you go into production!

## Rate limiting

The `RiotClient` will automatically handle rate limiting for you, so you don't need to worry about it.
If the client receives a rate limit error from the server, it will wait for the required amount of time before retrying the request.

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
