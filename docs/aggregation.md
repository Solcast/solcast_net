# Aggregation Data API

Get live or forecast aggregation data for up to 7 days of data at a time for a requested collection or aggregation.

---


The module AggregationClient has the following available methods:

| Endpoint                  | Purpose                                              | API Docs                                                                                                               |
|---------------------------|------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------|
| [GetLiveAggregations](#getliveaggregations) | Get live aggregation data for up to 7 days of data at a time for a requested collection or aggregation. | [details](https://docs.solcast.com.au/#3b09628d-0f9d-4a01-aa53-9af460d6c66a){.md-button} |
| [GetForecastAggregations](#getforecastaggregations) | Get forecast aggregation data for up to 7 days of data at a time for a requested collection or aggregation. | [details](https://docs.solcast.com.au/#feeb0565-ac06-473a-8cd1-b1493c5bcabb){.md-button} |

---

### GetLiveAggregations
**Parameters:**
[outputParameters](https://docs.solcast.com.au/#3b09628d-0f9d-4a01-aa53-9af460d6c66a "(List<string>): The output parameters to include in the response. (Optional)"), [collectionId](https://docs.solcast.com.au/#3b09628d-0f9d-4a01-aa53-9af460d6c66a "(string): Unique identifier for your collection. (Optional)"), [aggregationId](https://docs.solcast.com.au/#3b09628d-0f9d-4a01-aa53-9af460d6c66a "(string): Unique identifier that belongs to the requested collection. (Optional)"), [hours](https://docs.solcast.com.au/#3b09628d-0f9d-4a01-aa53-9af460d6c66a "(int?): The number of hours to return in the response. (Optional)"), [period](https://docs.solcast.com.au/#3b09628d-0f9d-4a01-aa53-9af460d6c66a "(string): Length of the averaging period in ISO 8601 format. (Optional)"), [format](https://docs.solcast.com.au/#3b09628d-0f9d-4a01-aa53-9af460d6c66a "(string): Response format (Optional)")

**Example Usage:**
```csharp
using Solcast.Clients;

var aggregationClient = new AggregationClient();
var response = await aggregationClient.GetLiveAggregations(
    outputParameters: ["percentage", "pv_estimate"],
    collectionId: "aust_state_total",
    aggregationId: "vic",
    format: "csv"
);
Console.WriteLine(response.RawResponse);

```
**Sample Output:**

| PvEstimate | Percentage | PeriodEnd | Period |
| --- | --- | --- | --- |
| 2564.842 | 49.7 | 2024-11-22T04:00:00+00:00 | PT30M |
| 2699.1642 | 52.3 | 2024-11-22T03:30:00+00:00 | PT30M |
| ... | ... | ... | ... |
| 2740.0478 | 53.2 | 2024-11-15T05:00:00+00:00 | PT30M |
| 2976.3018 | 57.8 | 2024-11-15T04:30:00+00:00 | PT30M |

---

### GetForecastAggregations
**Parameters:**
[outputParameters](https://docs.solcast.com.au/#feeb0565-ac06-473a-8cd1-b1493c5bcabb "(List<string>): The output parameters to include in the response. (Optional)"), [collectionId](https://docs.solcast.com.au/#feeb0565-ac06-473a-8cd1-b1493c5bcabb "(string): Unique identifier for your collection. (Optional)"), [aggregationId](https://docs.solcast.com.au/#feeb0565-ac06-473a-8cd1-b1493c5bcabb "(string): Unique identifier that belongs to the requested collection. (Optional)"), [hours](https://docs.solcast.com.au/#feeb0565-ac06-473a-8cd1-b1493c5bcabb "(int?): The number of hours to return in the response. (Optional)"), [period](https://docs.solcast.com.au/#feeb0565-ac06-473a-8cd1-b1493c5bcabb "(string): Length of the averaging period in ISO 8601 format. (Optional)"), [format](https://docs.solcast.com.au/#feeb0565-ac06-473a-8cd1-b1493c5bcabb "(string): Response format (Optional)")

**Example Usage:**
```csharp
using Solcast.Clients;

var aggregationClient = new AggregationClient();
var response = await aggregationClient.GetForecastAggregations(
    outputParameters: ["percentage", "pv_estimate"],
    collectionId: "aust_state_total",
    aggregationId: "vic",
    format: "csv"
);
Console.WriteLine(response.RawResponse);

```
**Sample Output:**

| PvEstimate | Percentage | PeriodEnd | Period |
| --- | --- | --- | --- |
| 2422.7618 | 46.9 | 2024-11-22T04:30:00+00:00 | PT30M |
| 2198.769 | 42.6 | 2024-11-22T05:00:00+00:00 | PT30M |
| ... | ... | ... | ... |
| 2610.3832 | 50.5 | 2024-11-29T03:30:00+00:00 | PT30M |
| 2487.7748 | 48.1 | 2024-11-29T04:00:00+00:00 | PT30M |

---
