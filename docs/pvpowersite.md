# PvPowerSite Data API

Allows management of detailed PV power site metadata used by the advanced_pv_power functions.

---


The module PvPowerSiteClient has the following available methods:

| Endpoint                  | Purpose                                              | API Docs                                                                                                               |
|---------------------------|------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------|
| [GetPvPowerSites](#getpvpowersites) | No description available. | [details](https://docs.solcast.com.au/#317dbf7c-e33e-479a-b708-01f001c36020){.md-button} |
| [GetPvPowerSite](#getpvpowersite) | No description available. | [details](https://docs.solcast.com.au/#101c6f51-b039-47c3-80b4-2285b560afe6){.md-button} |
| PostPvPowerSite | No description available. | [details](https://docs.solcast.com.au/#20007e83-78a2-4daa-b38a-4766f6344859){.md-button} |
| PutPvPowerSite | No description available. | [details](https://docs.solcast.com.au/#5c585e3f-3367-4932-a4bd-f0f4880996ca){.md-button} |
| PatchPvPowerSite | No description available. | [details](https://docs.solcast.com.au/#692cd116-890a-4b2c-84a3-70c1e4dd30c9){.md-button} |
| DeletePvPowerSite | No description available. | [details](https://docs.solcast.com.au/#9692eaa6-9f45-4062-89d2-304dded3ca3a){.md-button} |

---

### GetPvPowerSites
**Parameters:**


**Example Usage:**
```csharp
using Solcast.Clients;

var pvPowerSiteClient = new PvPowerSiteClient();
var response = await pvPowerSiteClient.GetPvPowerSites(
    
);
Console.WriteLine(response.RawResponse);

```

### GetPvPowerSite
**Parameters:**
[resourceId](https://docs.solcast.com.au/#101c6f51-b039-47c3-80b4-2285b560afe6 "(string): The unique identifier of the resource. (Required)")

**Example Usage:**
```csharp
using Solcast.Clients;

var pvPowerSiteClient = new PvPowerSiteClient();
var response = await pvPowerSiteClient.GetPvPowerSite(
    resourceId: "ba75-e17a-7374-95ed"
);
Console.WriteLine(response.RawResponse);

```
