# Tmy Data API

TMY (Typical Meteorological Year) is a collation of historical weather data for a specified location for a one year period. The dataset is derived from a multi-year time series specifically selected so that it presents the unique weather phenomena for the location, and provides annual averages that are consistent with long term averages.

---


The module TmyClient has the following available methods:

| Endpoint                  | Purpose                                              | API Docs                                                                                                               |
|---------------------------|------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------|
| [GetRadiationAndWeather](#getradiationandweather) | Get the irradiance and weather for a Typical Meteorological Year (TMY) at a requested location, derived from satellite (clouds and irradiance over non-polar continental areas) and numerical weather models (other data). The TMY is calculated with data from 2007 to 2023. | [details](https://docs.solcast.com.au/#3e4b42f5-c6b2-44e5-8b0e-8710acec8b2e){.md-button} |
| [GetRooftopPvPower](#getrooftoppvpower) | Get the basic rooftop PV power estimated actuals for a Typical Meteorological Year (TMY) at a requested location, derived from satellite (clouds and irradiance over non-polar continental areas) and numerical weather models (other data). The TMY is calculated with data from 2007 to 2023. | [details](https://docs.solcast.com.au/#d4ec6726-9300-46ff-b3de-e6e06c4768df){.md-button} |
| [GetAdvancedPvPower](#getadvancedpvpower) | Get the irradiance and weather for a Typical Meteorological Year (TMY) at a requested location, derived from satellite (clouds and irradiance over non-polar continental areas) and numerical weather models (other data). The TMY is calculated with data from 2007 to 2023. | [details](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113){.md-button} |

---

### GetRadiationAndWeather
**Parameters:**
[latitude](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(double?): The latitude of the location you request data for. Must be a decimal number between -90 and 90. (Required)"), [longitude](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(double?): The longitude of the location you request data for. Must be a decimal number between -180 and 180. (Required)"), [timeZone](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(string): Timezone to return in data set. Accepted values are utc, longitudinal, or a range from -13 to 13 in 0.25 hour increments for utc offset. (Optional)"), [period](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(string): Length of the averaging period in ISO 8601 format. (Optional)"), [ghiWeight](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(double?): When creating the TMY, the weighting of GHI to use in the target parameter. Note that ghi_weight + dni_weight must equal 1. (Optional)"), [dniWeight](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(double?): When creating the TMY, the weighting of DNI to use in the target parameter. Note that ghi_weight + dni_weight must equal 1. (Optional)"), [probability](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(string): The probability percentile for the TMY. Allowed values are p50, p75, p90, p95. (Optional)"), [tilt](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(float?): The angle (degrees) that the PV system is tilted off the horizontal. A tilt of 0 means the system faces directly upwards, and 90 means the system is vertical and facing the horizon. If you don't specify tilt, we use a default tilt angle based on the latitude you specify in your request. Must be between 0 and 90. (Optional)"), [azimuth](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(float?): The azimuth is defined as the angle (degrees) from true north that the PV system is facing. An azimuth of 0 means the system is facing true north. Positive values are anticlockwise, so azimuth is -90 for an east-facing system and 135 for a southwest-facing system. If you don't specify an azimuth, we use a default value of 0 (north facing) in the southern hemisphere and 180 (south-facing) in the northern hemisphere. (Optional)"), [arrayType](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(string): The type of sun-tracking or geometry configuration of your site's modules. (Optional)"), [outputParameters](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(List<string>): The output parameters to include in the response. (Optional)"), [terrainShading](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(bool?): If true, irradiance parameters are modified based on the surrounding terrain from a 90m-horizontal-resolution digital elevation model. The direct component of irradiance is set to zero when the beam from the sun is blocked by the terrain. The diffuse component of irradiance is reduced throughout the day if the sky view at the location is significantly reduced by the surrounding terrain. Global irradiance incorporates both effects. (Optional)"), [format](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(string): Response format (Optional)")

**Example Usage:**
```csharp
using Solcast.Clients;

var tmyClient = new TmyClient();
var response = await tmyClient.GetRadiationAndWeather(
    latitude: -33.856784,
    longitude: 151.215297,
    period: "PT30M",
    tilt: 30.0f,
    azimuth: 180.0f,
    format: "csv"
);
Console.WriteLine(response.RawResponse);

```
No output generated for this example.
---

### GetRooftopPvPower
**Parameters:**
[latitude](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(double?): The latitude of the location you request data for. Must be a decimal number between -90 and 90. (Required)"), [longitude](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(double?): The longitude of the location you request data for. Must be a decimal number between -180 and 180. (Required)"), [capacity](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(float?): The capacity of the inverter (AC) or the modules (DC), whichever is greater, in kilowatts (kW). (Required)"), [timeZone](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(string): Timezone to return in data set. Accepted values are utc, longitudinal, or a range from -13 to 13 in 0.25 hour increments for utc offset. (Optional)"), [period](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(string): Length of the averaging period in ISO 8601 format. (Optional)"), [ghiWeight](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(double?): When creating the TMY, the weighting of GHI to use in the target parameter. Note that ghi_weight + dni_weight must equal 1. (Optional)"), [dniWeight](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(double?): When creating the TMY, the weighting of DNI to use in the target parameter. Note that ghi_weight + dni_weight must equal 1. (Optional)"), [probability](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(string): The probability percentile for the TMY. Allowed values are p50, p75, p90, p95. (Optional)"), [tilt](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(float?): The angle (degrees) that the PV system is tilted off the horizontal. A tilt of 0 means the system faces directly upwards, and 90 means the system is vertical and facing the horizon. If you don't specify tilt, we use a default tilt angle based on the latitude you specify in your request. Must be between 0 and 90. (Optional)"), [azimuth](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(float?): The azimuth is defined as the angle (degrees) from true north that the PV system is facing. An azimuth of 0 means the system is facing true north. Positive values are anticlockwise, so azimuth is -90 for an east-facing system and 135 for a southwest-facing system. If you don't specify an azimuth, we use a default value of 0 (north facing) in the southern hemisphere and 180 (south-facing) in the northern hemisphere. (Optional)"), [installDate](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(string): The date (yyyy-MM-dd) of installation of the PV system. We use this to estimate your loss_factor based on the ageing of your system. If you provide us with a loss_factor directly, we will ignore this date. (Optional)"), [lossFactor](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(float?): Default is 0.90 A factor to reduce your output forecast from the full capacity based on characteristics of the PV array or inverter. This is effectively the non-temperature loss effects on the nameplate rating of the PV system, including inefficiency and soiling. For a 1kW PV system anything that reduces 1000W/m2 solar radiation from producing 1000W of power output (assuming temperature is 25C). Valid values are between 0 and 1 (i.e. 0.6 equals 60%). If you specify 0.6 your returned power will be a maximum of 60% of AC capacity. (Optional)"), [outputParameters](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(List<string>): The output parameters to include in the response. (Optional)"), [terrainShading](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(bool?): If true, irradiance parameters are modified based on the surrounding terrain from a 90m-horizontal-resolution digital elevation model. The direct component of irradiance is set to zero when the beam from the sun is blocked by the terrain. The diffuse component of irradiance is reduced throughout the day if the sky view at the location is significantly reduced by the surrounding terrain. Global irradiance incorporates both effects. (Optional)"), [format](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(string): Response format (Optional)")

**Example Usage:**
```csharp
using Solcast.Clients;

var tmyClient = new TmyClient();
var response = await tmyClient.GetRooftopPvPower(
    latitude: -33.856784,
    longitude: 151.215297,
    capacity: 5.0f,
    format: "csv"
);
Console.WriteLine(response.RawResponse);

```
No output generated for this example.
---

### GetAdvancedPvPower
**Parameters:**
[resourceId](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(string): The resource id of the resource. (Required)"), [timeZone](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(string): Timezone to return in data set. Accepted values are utc, longitudinal, or a range from -13 to 13 in 0.25 hour increments for utc offset. (Optional)"), [period](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(string): Length of the averaging period in ISO 8601 format. (Optional)"), [ghiWeight](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(double?): When creating the TMY, the weighting of GHI to use in the target parameter. Note that ghi_weight + dni_weight must equal 1. (Optional)"), [dniWeight](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(double?): When creating the TMY, the weighting of DNI to use in the target parameter. Note that ghi_weight + dni_weight must equal 1. (Optional)"), [probability](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(string): The probability percentile for the TMY. Allowed values are p50, p75, p90, p95. (Optional)"), [outputParameters](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(List<string>): The output parameters to include in the response. (Optional)"), [applyAvailability](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(double?): Percentage of the site’s total AC (inverter) capacity that is currently generating or expected to be generating during the forecast request period. E.g. if you specify a 50% availability, your returned power will be half of what it otherwise would be. (Optional)"), [applyConstraint](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(double?): Constraint on site’s total AC production, applied as a cap in the same way as the metadata parameter Site Export Limit. This will constrain all Solcast power values to be no higher than the apply_constraint value you specify. If you need an unconstrained forecast, you should not use this parameter. (Optional)"), [applyDustSoiling](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(double?): A user-override for dust_soiling_average. If you specify this parameter in your API call, we will replace the site's annual or monthly average dust soiling values with the value you specify in your API call.E.g. if you specify a 0.7 dust soiling, your returned power will be reduced by 70%. (Optional)"), [applySnowSoiling](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(double?): A user-override for Solcast’s dynamic snow soiling, which is based on global snow cover and weather forecast data, and changes from hour to hour. If you specify this parameter in your API call (e.g. if snow clearing has just been performed), we will replace the Solcast dynamic hour to hour value with the single value you specify. E.g. if you specify a 0.7 snow soiling, your returned power will be reduced by 70%. (Optional)"), [applyTrackerInactive](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(bool?): Indicating if trackers are inactive. If True, panels are assumed all facing up (i.e. zero rotation). Only has effect if your site has a tracking_type that is not “fixed”. (Optional)"), [terrainShading](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(bool?): If true, irradiance parameters are modified based on the surrounding terrain from a 90m-horizontal-resolution digital elevation model. The direct component of irradiance is set to zero when the beam from the sun is blocked by the terrain. The diffuse component of irradiance is reduced throughout the day if the sky view at the location is significantly reduced by the surrounding terrain. Global irradiance incorporates both effects. (Optional)"), [format](https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113 "(string): Response format (Optional)")

**Example Usage:**
```csharp
using Solcast.Clients;

var tmyClient = new TmyClient();
var response = await tmyClient.GetAdvancedPvPower(
    resourceId: "ba75-e17a-7374-95ed",
    format: "csv"
);
Console.WriteLine(response.RawResponse);

```
No output generated for this example.
---
