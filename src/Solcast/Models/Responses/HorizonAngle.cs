using Newtonsoft.Json;

public class HorizonAngle
{

    [JsonProperty("azimuth")]
    public double? Azimuth { get; set; } 

    [JsonProperty("angle")]
    public double? Angle { get; set; } 
}
