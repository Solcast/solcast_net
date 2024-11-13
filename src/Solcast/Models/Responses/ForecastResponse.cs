using System.Collections.Generic;
using Newtonsoft.Json;

public class ForecastResponse
{

    [JsonProperty("forecasts")]
    public List<Dictionary<string, object>> Forecasts { get; set; } 

    [JsonProperty("response_status")]
    public string ResponseStatus { get; set; } 
}
