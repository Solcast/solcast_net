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
| 1973.5554 | 38.0 | 2024-12-10T23:30:00+00:00 | PT30M |
| 1778.0546 | 34.3 | 2024-12-10T23:00:00+00:00 | PT30M |
| ... | ... | ... | ... |
| 3176.0942 | 61.3 | 2024-12-04T00:30:00+00:00 | PT30M |
| 2976.8182 | 57.5 | 2024-12-04T00:00:00+00:00 | PT30M |

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
| 43.3 | 2247.4730 | 2024-12-11T00:00:00+00:00 | PT30M |
| 49.0 | 2542.7620 | 2024-12-11T00:30:00+00:00 | PT30M |
| ... | ... | ... | ... |
| 44.8 | 2327.9128 | 2024-12-17T23:00:00+00:00 | PT30M |
| 50.8 | 2642.4618 | 2024-12-17T23:30:00+00:00 | PT30M |

---
