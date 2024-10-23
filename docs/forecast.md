# Forecast Data API

The **ForecastClient** in the Solcast SDK allows you to retrieve solar radiation and weather forecasts for up to 14 days ahead. The forecasts are based on satellite observations and numerical weather models.

## Example Usage

To retrieve forecast data, use the `ForecastClient` class.

```csharp
using Solcast.Clients;

var forecastClient = new ForecastClient();

var response = await forecastClient.GetRadiationAndWeather(
    latitude: -33.856784,
    longitude: 151.215297,
    outputParameters: ["dni", "ghi", "air_temp"],
    format: "csv"
);

Console.WriteLine(response);
```

### Example Response (CSV)
```
dni,ghi,air_temp,period_end,period
193,372,20,2024-09-24T05:00:00Z,PT30M
0,172,20,2024-09-24T05:30:00Z,PT30M
145,246,20,2024-09-24T06:00:00Z,PT30M
...
0,143,12,2024-09-26T04:30:00Z,PT30M
0,77,12,2024-09-26T05:00:00Z,PT30M
```

## API Parameters
- **latitude**: Latitude of the location in decimal degrees (north is positive).
- **longitude**: Longitude of the location in decimal degrees (east is positive).
- **output_parameters**: An array of parameters to return, such as `dni`, `ghi`, `air_temp`.
- **format**: The format of the output (e.g., "json", "csv").

For more information about the forecast data API, visit the [Solcast API Docs](https://docs.solcast.com.au/#80627973-4183-4ebc-8a3d-1b2324fd1ed1).

