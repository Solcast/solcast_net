# PV Power Sites

The **PV Power Sites** module allows the management of detailed PV power site metadata, which can be used by the advanced PV power functions. This includes creating, updating, listing, retrieving, and deleting PV power sites.

More information is available in the [API Docs](https://docs.solcast.com.au/#49090b36-66db-4d0f-89d5-87d19f00bec1).

The module `PvPowerSitesClient` has the following available methods:

| Endpoint                  | Purpose                                              | API Docs                                                                                                               |
|---------------------------|------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------|
| `ListPvPowerSites`         | List all available PV power sites.                   | [details](https://docs.solcast.com.au/#baee4c8b-83e8-43e6-886b-98671164df10){.md-button}                               |
| `GetPvPowerSite`           | Get an existing PV power site's specifications.      | [details](https://docs.solcast.com.au/#27a18021-eed0-4281-8b28-9bdf1ebb2a95){.md-button}                               |
| `CreatePvPowerSite`        | Create a new PV power site for advanced modeling.    | [details](https://docs.solcast.com.au/#d3a35494-15d8-4baa-b96f-7fd3353c9f06){.md-button}                               |
| `PatchPvPowerSite`         | Partially update a PV power site’s specifications.   | [details](https://docs.solcast.com.au/#ba412164-31c2-47a9-a965-c95bc9b632a6){.md-button}                               |
| `UpdatePvPowerSite`        | Overwrite an existing PV power site's specifications.| [details](https://docs.solcast.com.au/#181cf2be-f710-49c3-8050-07be858f25e1){.md-button}                               |
| `DeletePvPowerSite`        | Delete an existing PV power site.                    | [details](https://docs.solcast.com.au/#c2353692-36db-46b8-8508-a6d4fae65390){.md-button}                               |

---

### Example

#### Listing all available PV power sites:
```csharp
using Solcast.Clients;

var pvClient = new PvPowerSitesClient();
var response = await pvClient.ListPvPowerSites();

Console.WriteLine(response);
```

#### Getting metadata of a specific PV power site:
```csharp
using Solcast.Clients;

var pvClient = new PvPowerSitesClient();
var response = await pvClient.GetPvPowerSite("ba75-e17a-7374-95ed");

Console.WriteLine(response);
```

<!-- ##### Example Output (JSON):
```json
{
    "resource_id": "ba75-e17a-7374-95ed",
    "name": "Test Site: Sydney Opera House",
    "latitude": -33.856784,
    "longitude": 151.215297,
    "capacity": 10,
    "capacity_dc": 15,
    "azimuth": 0,
    "tilt": 30.22,
    "tracking_type": "horizontal_single_axis",
    "install_date": "2021-07-01T00:00:00.0000000Z",
    "module_type": "poly-si",
    "ground_coverage_ratio": 0.47,
    "derating_temp_module": 0.0039,
    "derating_age_system": 0.0059,
    "derating_other_system": 0.07,
    "inverter_peak_efficiency": 0.985,
    "tracker_axis_azimuth": 0,
    "tracker_max_rotation_angle": 60,
    "tracker_back_tracking": true,
    "tracker_smart_tracking": false,
    "terrain_slope": 0,
    "terrain_azimuth": 0,
    "dust_soiling_average": [
        0.015,
        0.015,
        0.015,
        0.015,
        0.015,
        0.015,
        0.015,
        0.015,
        0.015,
        0.015,
        0.015,
        0.015
    ],
    "bifacial_system": false,
    "site_ground_albedo": 0.25,
    "bifaciality_factor": 0.7,
    "pvrow_height": 1.5,
    "pvrow_width": 2,
    "confirmed_metadata": "2024-07-30T11:52:28.9964540Z"
}
``` -->