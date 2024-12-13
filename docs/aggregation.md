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
| 3226.6417 | 62.1 | 2024-12-13T03:00:00+00:00 | PT30M |
| 3191.3028 | 61.4 | 2024-12-13T02:30:00+00:00 | PT30M |
| ... | ... | ... | ... |
| 1578.3045 | 30.4 | 2024-12-06T04:00:00+00:00 | PT30M |
| 1630.0389 | 31.4 | 2024-12-06T03:30:00+00:00 | PT30M |

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

| Percentage | PvEstimate | PeriodEnd | Period |
| --- | --- | --- | --- |
| 61.8 | 3208.6597 | 2024-12-13T03:30:00+00:00 | PT30M |
| 60.1 | 3124.2148 | 2024-12-13T04:00:00+00:00 | PT30M |
| ... | ... | ... | ... |
| 61.5 | 3201.7168 | 2024-12-20T02:30:00+00:00 | PT30M |
| 61.6 | 3206.8292 | 2024-12-20T03:00:00+00:00 | PT30M |

---
