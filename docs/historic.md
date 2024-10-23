# Historic Data API

The **HistoricClient** in the Solcast SDK allows you to retrieve historical solar radiation and weather data. This data is available from 2007 to 7 days ago.

## Example Usage

To retrieve historical data, use the `HistoricClient` class.

```csharp
using Solcast.Clients;

var historicClient = new HistoricClient();

var response = await historicClient.GetRadiationAndWeather(
    latitude: -33.856784,
    longitude: 151.215297,
    start: "2022-06-01T06:00",
    duration: "P1D",
    format: "csv"
);

Console.WriteLine(response);
```

### Example Response (CSV)
```csv
air_temp,dni,ghi,period_end,period
13,441,78,2022-06-01T06:30:00+00:00,PT30M
13,62,12,2022-06-01T07:00:00+00:00,PT30M
13,0,0,2022-06-01T07:30:00+00:00,PT30M
...
16,699,242,2022-06-02T05:30:00+00:00,PT30M
16,602,159,2022-06-02T06:00:00+00:00,PT30M
```

## API Parameters
- **latitude**: Latitude of the location in decimal degrees (north is positive).
- **longitude**: Longitude of the location in decimal degrees (east is positive).
- **start**: Start date of the requested period (ISO 8601 format).
end: Optional end date (ISO 8601 format).
- **duration**: Optional duration in ISO 8601 format.
- **format**: Optional response format.

For more information about the historic data API, visit the [Solcast API Docs](https://docs.solcast.com.au/#d2d99600-cd3b-4b33-96b3-02cabb25cd3d).

