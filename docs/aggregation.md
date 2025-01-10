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
| 2926.6058 | 55.9 | 2025-01-10T02:30:00+00:00 | PT30M |
| 2876.7728 | 54.9 | 2025-01-10T02:00:00+00:00 | PT30M |
| ... | ... | ... | ... |
| 3312.2368 | 63.4 | 2025-01-03T03:30:00+00:00 | PT30M |
| 3380.2602 | 64.7 | 2025-01-03T03:00:00+00:00 | PT30M |

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
| 55.6 | 2912.6562 | 2025-01-10T03:00:00+00:00 | PT30M |
| 53.6 | 2804.7498 | 2025-01-10T03:30:00+00:00 | PT30M |
| ... | ... | ... | ... |
| 23.5 | 1233.5931 | 2025-01-17T02:00:00+00:00 | PT30M |
| 23.5 | 1230.2838 | 2025-01-17T02:30:00+00:00 | PT30M |

---
