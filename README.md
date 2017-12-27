### Live Glitch :sun_with_face:[Demo](https://solcast-demo.glitch.me/):sun_with_face:

[![NuGet](https://img.shields.io/nuget/v/FeatureToggle.svg)](https://www.nuget.org/packages/Solcast)
[![Build Status](https://travis-ci.org/Solcast/solcast_net.svg?branch=master)](https://travis-ci.org/Solcast/solcast_net)
[![Build status](https://ci.appveyor.com/api/projects/status/bavavf78vnrsr2i5/branch/master?svg=true)](https://ci.appveyor.com/project/Siliconrob/solcast-net/branch/master)
[![Join the chat at https://gitter.im/Solcast/Lobby](https://badges.gitter.im/Solcast/Lobby.svg)](https://gitter.im/Solcast/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

# Solcast .NET API Client library

.NET client library for querying the [Solcast API](https://api.solcast.com.au) async/sync

This module allows a registered users to query the Solcast API [https://api.solcast.com.au](https://api.solcast.com.au).  You will need to register your user account to obtain an API key [https://solcast.com.au/api/register](https://solcast.com.au/api/register/).  Without an API key you will not be able to successfully obtain valid API results.

### Windows setup Solcast API Key

Setup **System/User** `environment variable`.  Details on advanced editing [StackOverflow superuser walkthrough](https://superuser.com/questions/949560/how-do-i-set-system-environment-variables-in-windows-10)

```
WinKey + R
```

**Copy and Paste** the following text to the **Open:** input text box for the Run Dialog

```
%windir%\System32\rundll32.exe sysdm.cpl,EditEnvironmentVariables
```

That will present this screen

![Run Windows Environment Editor](/imgs/win_launch_environment_editor.png)

Add a `USER` or `SYSTEM` `environment variable` to hold the Solcast API key.  User environment variables will only be available to your particular user, system environment variables are shared for all users on the system

![Add Windows User Solcast API key](/imgs/win_env_user_variable.png)

After you have added the `environment variable` you will see the key listed in the current variables

![Added Windows User Solcast API key](/imgs/win_solcast_variable.png)

**NOTE**: To reference this key you will need to reopen your shell prompt to read these variables again from the system (cmd, command.com, powershell, etc)


### Linux / mac OS

Open a terminal prompt
- mac OS: Spotlight search for `terminal`
- Linux: Open `bash`

```
nano .bash_profile
```

If you do not have `nano` it is a simpler text editor than `vi`.  Use your package manager to download and install or use `vi`.  The preferred package manager for mac OS is [Homebrew](https://brew.sh/) and once installed on your system you can issue similar commands to Linux `apt-get` and `yum` with the `brew` package manager.

Add the **Solcast API Key** to your user profile variables.

![Added mac OS User Solcast API key](/imgs/mac_os_environment_variable.png)

### Latitude and Longitude

- First as stated above you will need an API key to make **valid** API requests to the Solcast system.
- Second for all current library calls you will need a **valid** Lat/Lng coordinate in the [EPSG:4326](http://spatialreference.org/ref/epsg/wgs-84/) format.  If you are familiar with modern web maps you most likely have used the expected format or a decimal point that expresses a position on the Earth.

Clarification as I often forget the coordinate planes of Latitude and Longitude along with bounds.
![Lat/Lng](/imgs/Lat_Long.gif)

[Credits - Learner.org](http://www.learner.org/jnorth/tm/LongitudeIntro.html)

The Solcast API expects **West** for Longitude and **South** for Latitude to be expressed as a negative numbers

Example Locations on the Globe

Name | Latitude | Longitude
--- | --- | ---
Sydney, Australia | -33.865143 | 151.209900
Mumbai, India |‎ 19.228825 | 72.854118
Tokyo, Japan | 35.6895 | 139.69171
Paris, France | 48.864716 | 2.349014
Los Angeles, USA | 34.052235 | -118.243683

### Need help?
* [Documentation](https://solcast.com.au/api/docs/)
* [Forums](https://forums.solcast.com.au)
* [Gitter](https://gitter.im/Solcast/Lobby?utm_source=share-link&utm_medium=link&utm_campaign=share-link)

### How to contribute
 * Fork the repository
 * Add something awesome
 * Create a pull request
 * :sun_with_face: Celebrate :sun_with_face:

### [Sample Program](example/cli/Program.cs) 

Example [CLI](https://en.wikipedia.org/wiki/Command-line_interface) provided for reference with multiple querying strategies

### Examples

#### NOTE: 
You can use standard environment variables to hold your API key and not need to pass the optional `apiKey` to the current methods

Environment variable name if you care to work with it directly
```
SOLCAST_API_KEY
```

Accessible through process environment variable directly or with helper API method.

**RECOMMENDED**
```csharp
var key = API.Key();
```

**OR IF YOU MUST**
```csharp
var key = Environment.GetEnvironmentVariable("SOLCAST_API_KEY");
```

#### C# sync Single request
```csharp
using (var client = new SolcastClient())
{
	return client.GetPvPowerForecasts(new Location
	{
		Latitude = 32,
		Longitude = -97
	});
}

```

#### C# async Single request
```csharp
using (var client = new SolcastClient())
{
	return await client.GetPvPowerForecastsAsync(new Location
	{
		Latitude = 32,
		Longitude = -97
	});
}
```

#### C# sync Single request with Wait and Retry
```csharp
// Set a policy on WebServiceExceptions with StatusCode of 429 to wait and retry the request again in 5 seconds
var policy = Policy
	.Handle<WebServiceException>(z => z.StatusCode == 429)
	.WaitAndRetry(new[] { TimeSpan.FromSeconds(5) });

return policy.Execute(() =>
{
	using (var client = new SolcastClient())
	{
		return client.GetPvPowerForecasts(new Location
		{
			Latitude = 32,
			Longitude = -97
		});
	}
});
```

#### C# sync Sequential requests as batch
```csharp
using (var client = new SolcastClient())
{
	return locations.Select(location => client.GetPvPowerForecasts(location)).ToList();
}
```

#### C# sync Parallel requests as batch
```csharp
var results = new List<GetPvPowerForecastsResponse>();
using (var client = new SolcastClient())
{
	Parallel.ForEach(locations, location =>
	{
		results.Add(client.GetPvPowerForecasts(location));
	});                
}
return results;
```


#### C# Change Client properties this is only a sample of a few of the available properties
```csharp
// Timeout is now set to 5 minutes
client.GetHttpClient().Timeout = TimeSpan.FromMinutes(5);
// Use a different API KEY
client.Key = "<DIFFERENT API KEY>";
client.RateLimitExceededFn = message =>
{
	// Custom Action<HttpResponseMessage> if RateLimit has been exceeded
};
```

License
-------
License can be found here: [LICENSE](LICENSE)
