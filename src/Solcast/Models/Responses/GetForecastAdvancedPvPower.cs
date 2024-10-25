using System.Collections.Generic;
using Newtonsoft.Json;

public class GetForecastAdvancedPvPower
{

    /// <summary>
    /// The output parameters to include in the response.
    /// </summary>
    [JsonProperty("output_parameters")]
    public List<string> OutputParameters { get; set; } 

    /// <summary>
    /// The resource id of the resource.
    /// </summary>
    [JsonProperty("resource_id")]
    public string ResourceId { get; set; } // Required

    /// <summary>
    /// Length of the averaging period in ISO 8601 format.
    /// </summary>
    [JsonProperty("period")]
    public string Period { get; set; } 

    /// <summary>
    /// The number of hours to return in the response.
    /// </summary>
    [JsonProperty("hours")]
    public int? Hours { get; set; } 

    /// <summary>
    /// Percentage of the site’s total AC (inverter) capacity that is currently generating or expected to be generating during the forecast request period. E.g. if you specify a 50% availability, your returned power will be half of what it otherwise would be.
    /// </summary>
    [JsonProperty("apply_availability")]
    public double? ApplyAvailability { get; set; } 

    /// <summary>
    /// Constraint on site’s total AC production, applied as a cap in the same way as the metadata parameter Site Export Limit. This will constrain all Solcast power values to be no higher than the apply_constraint value you specify. If you need an unconstrained forecast, you should not use this parameter.
    /// </summary>
    [JsonProperty("apply_constraint")]
    public double? ApplyConstraint { get; set; } 

    /// <summary>
    /// A user-override for dust_soiling_average. If you specify this parameter in your API call, we will replace the site's annual or monthly average dust soiling values with the value you specify in your API call.E.g. if you specify a 0.7 dust soiling, your returned power will be reduced by 70%.
    /// </summary>
    [JsonProperty("apply_dust_soiling")]
    public double? ApplyDustSoiling { get; set; } 

    /// <summary>
    /// A user-override for Solcast’s dynamic snow soiling, which is based on global snow cover and weather forecast data, and changes from hour to hour. If you specify this parameter in your API call (e.g. if snow clearing has just been performed), we will replace the Solcast dynamic hour to hour value with the single value you specify. E.g. if you specify a 0.7 snow soiling, your returned power will be reduced by 70%.
    /// </summary>
    [JsonProperty("apply_snow_soiling")]
    public double? ApplySnowSoiling { get; set; } 

    /// <summary>
    /// Indicating if trackers are inactive. If True, panels are assumed all facing up (i.e. zero rotation). Only has effect if your site has a tracking_type that is not “fixed”.
    /// </summary>
    [JsonProperty("apply_tracker_inactive")]
    public bool? ApplyTrackerInactive { get; set; } 

    /// <summary>
    /// If true, irradiance parameters are modified based on the surrounding terrain from a 90m-horizontal-resolution digital elevation model. The direct component of irradiance is set to zero when the beam from the sun is blocked by the terrain. The diffuse component of irradiance is reduced throughout the day if the sky view at the location is significantly reduced by the surrounding terrain. Global irradiance incorporates both effects.
    /// </summary>
    [JsonProperty("terrain_shading")]
    public bool? TerrainShading { get; set; } 

    /// <summary>
    /// Response format
    /// </summary>
    [JsonProperty("format")]
    public string Format { get; set; } 
}
