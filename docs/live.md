# Live Data API

The **LiveClient** in the Solcast SDK allows you to retrieve live solar radiation and weather data. The data is derived from satellite observations and numerical weather models.

## Example Usage

To retrieve live data, use the `LiveClient` class.

```csharp
using Solcast.Clients;

var liveClient = new LiveClient();
var response = await liveClient.GetRadiationAndWeather(
    latitude: -33.856784,
    longitude: 151.215297, 
    outputParameters: ["dni", "ghi", "air_temp"],
    format: "csv"
);

Console.WriteLine(response);
```

### Example Output (CSV)
```csv
dni,ghi,air_temp,period_end,period
193,372,20,2024-09-24T05:00:00Z,PT30M
700,621,21,2024-09-24T04:30:00Z,PT30M
748,694,21,2024-09-24T04:00:00Z,PT30M
...
786,485,23,2024-09-22T05:30:00Z,PT30M
826,579,23,2024-09-22T05:00:00Z,PT30M
```

## API Parameters
- **latitude**: Latitude of the location in decimal degrees (north is positive).
- **longitude**: Longitude of the location in decimal degrees (east is positive).
- **outputParameters**: An array of parameters to return, such as `dni`, `ghi`, `air_temp`.
- **format**: The format of the output (e.g., "json", "csv").

---
For more information about the live data API, visit the [Solcast API Docs](https://docs.solcast.com.au/?#a20936b9-a41c-4ff3-b169-5ad8c5f4960b).
