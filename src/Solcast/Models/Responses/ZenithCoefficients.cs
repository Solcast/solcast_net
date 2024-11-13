using System.Collections.Generic;
using Newtonsoft.Json;

public class ZenithCoefficients
{

    [JsonProperty("day_of_year")]
    public int? DayOfYear { get; set; } 

    [JsonProperty("signed_zenith_coefficients")]
    public IDictionary<string, object> SignedZenithCoefficients { get; set; } 
}
