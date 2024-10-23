# TMY

TMY (Typical Meteorological Year) is a collation of historical weather data for a specified location for a one-year period. The dataset is derived from a multi-year time series specifically selected so that it presents the unique weather  phenomena for the location and provides annual averages that are consistent with long-term averages.

See the [API docs](https://docs.solcast.com.au/#a4fced31-90e5-4173-a96b-96f5a46dd374).

The `TmyClient` has the following methods:

| Endpoint                | API Docs                                                                                                       |
|-------------------------|----------------------------------------------------------------------------------------------------------------|
| `GetRadiationAndWeather` | [details](https://docs.solcast.com.au/#3e4b42f5-c6b2-44e5-8b0e-8710acec8b2e){.md-button}                      |
| `GetRooftopPvPower`      | [details](https://docs.solcast.com.au/#d4ec6726-9300-46ff-b3de-e6e06c4768df){.md-button}                      |

### Examples

#### Get Rooftop PV Power Example
```csharp
using Solcast.Clients;

var tmyClient = new TmyClient();

var response = await tmyClient.GetRooftopPvPower(
    latitude: -33.856784,
    longitude: 151.215297,
    format: "csv",
    capacity: 3
);

Console.WriteLine(response);
```

##### Example Output (CSV):
```csv
pv_power_rooftop,period_end,period
1.461,2059-01-01T01:00:00Z,PT1H
0.974,2059-01-01T02:00:00Z,PT1H
0.731,2059-01-01T03:00:00Z,PT1H
...
1.509,2059-12-31T23:00:00Z,PT1H
1.922,2060-01-01,PT1H
```

<!-- #### Get Irradiance and Weather Example
```csharp
using Solcast.Clients;

var tmyClient = new TmyClient();
var response = await tmyClient.GetRooftopPvPower(-33.856784, 151.215297);

Console.WriteLine(response);
```

##### Example Output (CSV):
```csv
ghi,dni,dhi,azimuth,zenith,air_temp,relative_humidity,wind_speed_10m,albedo,period_end,period
608,150,470,-66,22,24,84.1,3.6,0.08,2059-01-01T01:00:00Z,PT60M
404,0,404,-30,13,24,83.3,3.7,0.08,2059-01-01T02:00:00Z,PT60M
303,0,303,33,13,24,83.6,3.6,0.08,2059-01-01T03:00:00Z,PT60M
...
722,925,84,-91,46,23,81.5,4.2,0.09,2059-12-31T23:00:00Z,PT60M
893,971,89,-81,34,24,76,4.3,0.09,2060-01-01T00:00:00Z,PT60M
``` -->