using System.Collections.Generic;
using Newtonsoft.Json;

public class GetForecastRadiationAndWeather
{
    [JsonProperty("period")]
    public string Period { get; set; } 
    [JsonProperty("tilt")]
    public float? Tilt { get; set; } 
    [JsonProperty("azimuth")]
    public float? Azimuth { get; set; } 
    [JsonProperty("array_type")]
    public string ArrayType { get; set; } 
    [JsonProperty("output_parameters")]
    public List<string> OutputParameters { get; set; } 
    [JsonProperty("terrain_shading")]
    public bool? TerrainShading { get; set; } 
    [JsonProperty("latitude")]
    public double? Latitude { get; set; } // Required
    [JsonProperty("longitude")]
    public double? Longitude { get; set; } // Required
    [JsonProperty("hours")]
    public int? Hours { get; set; } 
    [JsonProperty("format")]
    public string Format { get; set; } 
}
