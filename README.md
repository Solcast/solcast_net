# WORK IN PROGRESS - Currently undergoing changes and updates and once ready for use will be available via NuGet

## Solcast .NET API Client library

.NET client library for querying the Solcast API async/sync

This module allows a registered users to query the Solcast API [https://api.solcast.com.au](https://api.solcast.com.au).  You will need to register your user account to obtain an API key [https://solcast.com.au/api/register](https://solcast.com.au/api/register/).  Without an API key you will not be able to successfully obtain valid API results.

### Need help?
* [Documentation](https://solcast.com.au/api/docs/)
* [Forums](https://forums.solcast.com.au)
* [Gitter]()

### How to contribute
 * Fork the repository
 * Add something awesome
 * Create a pull request

### Examples

#### NOTE: 
You can use standard environment variables to hold your API key and not need to pass the optional `apiKey` to the current methods

Environment variable names
```
SOLCAST_API_KEY
```

Accessible through process environment variable directly or with helper API method.
```
Environment.GetEnvironmentVariable("SOLCAST_API_KEY")
API.Key()
```


#### C# Async
```csharp
using solcast;

var getForecast = Power.Forecast( new Location
{
	Latitude = 32,
	Longitude = -97
});
getForecast.Wait();
var response = getForecast.Result;
```

#### C# sync
```csharp
using solcast;

var response = sync.Power.Forecast( new Location
{
	Latitude = 32,
	Longitude = -97
});
```

### Need help?
* [Documentation](https://solcast.com.au/api/docs/)
* [Forums](https://forums.solcast.com.au)
* [Gitter]()


License
-------
License can be found here: [LICENSE](LICENSE)
