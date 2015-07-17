# RiotNet

A .NET/C# API for the Riot Games API

This project is still in development! It will have the following features:
- **Compatible** with .NET 4.5 and later.
- **Full API coverage** - methods for accessing to every endpoint in the Riot Games API.
- **Synchronous and asynchronous** overloads for each method. Asynchronous methods are awaitable using the async/await model.
- **Flexible and configurable** - uses interfaces and allows inheritance.
- **Database Ready** - data structures have built-in database metadata, so you can easily persist results using Entity Framework without having to re-define all of the models.
- **Full Documentation** - documentation of every method and every property of every object. (Or at least as much as we can figure out from examining the JSON responses. Riot's API documentation is a bit lacking right now.)
- **Full Test Coverage** - so you can trust that it works.
  - However, if you think we missed something, or need to update something, please create an issue! Or better yet, create a pull request!

## Usage

```
IRiotClient client = new RiotClient(Region.NA, new RiotClientSettings
{
   ApiKey = "00000000-0000-0000-0000-000000000000" // Replace this with your API key, of course.
});
var championList = await client.GetChampionsTaskAsync();
```

See the tests for more extensive examples.