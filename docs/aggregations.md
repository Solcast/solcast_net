# Aggregations

More information in the [API Docs](https://docs.solcast.com.au/#eacaa7d2-66d7-474f-82a2-eed6c77fae60).

The `AggregationClient` has 2 available methods:

| Endpoint            | API Docs                                                                                                |
|---------------------|---------------------------------------------------------------------------------------------------------|
| `GetLiveAggregation` | [details](https://docs.solcast.com.au/#3b09628d-0f9d-4a01-aa53-9af460d6c66a){.md-button}                |
| `GetForecastAggregation` | [details](https://docs.solcast.com.au/#feeb0565-ac06-473a-8cd1-b1493c5bcabb){.md-button}          |

### Example

```csharp
using Solcast.Clients;

var aggregationClient = new AggregationClient();
var response = await _aggregationClient.GetForecastAggregations(
    collectionId: "country_total",
    aggregationId: "it_total",
    outputParameters: ["percentage", "pv_estimate"],
    format: "csv"
);

Console.WriteLine(response);
```

### API Parameters

#### Example Output (CSV):
```csv
PvEstimate,Percentage,PeriodEnd,Period
5476.7425,16.3,2024-09-24T07:00:00+00:00,PT30M
7199.674,21.4,2024-09-24T07:30:00+00:00,PT30M
8884.749,26.4,2024-09-24T08:00:00+00:00,PT30M
...
1270.8386,3.8,2024-10-01T06:00:00+00:00,PT30M
3358.4472,10.0,2024-10-01T06:30:00+00:00,PT30M
```