using System.Collections.Generic;
using Newtonsoft.Json;

public class ForecastAggregationResponse
{
    [JsonProperty("forecasts")]
    public List<Dictionary<string, object>> Forecasts { get; set; } 
}
