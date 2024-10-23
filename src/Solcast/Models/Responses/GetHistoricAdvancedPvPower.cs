using System.Collections.Generic;
using Newtonsoft.Json;

public class GetHistoricAdvancedPvPower
{
    [JsonProperty("start")]
    public string Start { get; set; } // Required
    [JsonProperty("end")]
    public string End { get; set; } 
    [JsonProperty("duration")]
    public string Duration { get; set; } 
    [JsonProperty("time_zone")]
    public string TimeZone { get; set; } 
    [JsonProperty("output_parameters")]
    public List<string> OutputParameters { get; set; } 
    [JsonProperty("resource_id")]
    public string ResourceId { get; set; } // Required
    [JsonProperty("period")]
    public string Period { get; set; } 
    [JsonProperty("hours")]
    public int? Hours { get; set; } 
    [JsonProperty("apply_availability")]
    public double? ApplyAvailability { get; set; } 
    [JsonProperty("apply_constraint")]
    public double? ApplyConstraint { get; set; } 
    [JsonProperty("apply_dust_soiling")]
    public double? ApplyDustSoiling { get; set; } 
    [JsonProperty("apply_snow_soiling")]
    public double? ApplySnowSoiling { get; set; } 
    [JsonProperty("apply_tracker_inactive")]
    public bool? ApplyTrackerInactive { get; set; } 
    [JsonProperty("terrain_shading")]
    public bool? TerrainShading { get; set; } 
    [JsonProperty("format")]
    public string Format { get; set; } 
}
