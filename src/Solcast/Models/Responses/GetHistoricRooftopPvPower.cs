using System.Collections.Generic;
using Newtonsoft.Json;

public class GetHistoricRooftopPvPower
{
    [JsonProperty("start")]
    public string Start { get; set; } // Required
    [JsonProperty("end")]
    public string End { get; set; } 
    [JsonProperty("duration")]
    public string Duration { get; set; } 
    [JsonProperty("time_zone")]
    public string TimeZone { get; set; } 
    [JsonProperty("period")]
    public string Period { get; set; } 
    [JsonProperty("latitude")]
    public double? Latitude { get; set; } // Required
    [JsonProperty("longitude")]
    public double? Longitude { get; set; } // Required
    [JsonProperty("capacity")]
    public float? Capacity { get; set; } // Required
    [JsonProperty("tilt")]
    public float? Tilt { get; set; } 
    [JsonProperty("azimuth")]
    public float? Azimuth { get; set; } 
    [JsonProperty("install_date")]
    public string InstallDate { get; set; } 
    [JsonProperty("loss_factor")]
    public float? LossFactor { get; set; } 
    [JsonProperty("hours")]
    public int? Hours { get; set; } 
    [JsonProperty("output_parameters")]
    public List<string> OutputParameters { get; set; } 
    [JsonProperty("terrain_shading")]
    public bool? TerrainShading { get; set; } 
    [JsonProperty("format")]
    public string Format { get; set; } 
}
