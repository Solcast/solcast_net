using System.Collections.Generic;
using Newtonsoft.Json;

public class HorizonAngleResponse
{

    [JsonProperty("horizon_angles")]
    public List<HorizonAngle> HorizonAngles { get; set; }

    [JsonProperty("response_status")]
    public string ResponseStatus { get; set; }
}
