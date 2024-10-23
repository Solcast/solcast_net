using Newtonsoft.Json;

public class GetHorizonAngle
{
    [JsonProperty("latitude")]
    public double? Latitude { get; set; } // Required
    [JsonProperty("longitude")]
    public double? Longitude { get; set; } // Required
    [JsonProperty("azimuth_intervals")]
    public int? AzimuthIntervals { get; set; } // Required
    [JsonProperty("format")]
    public string Format { get; set; } 
}
