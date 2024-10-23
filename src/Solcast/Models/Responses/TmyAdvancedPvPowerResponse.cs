using System.Collections.Generic;
using Newtonsoft.Json;

public class TmyAdvancedPvPowerResponse
{
    [JsonProperty("estimated_actuals")]
    public List<Dictionary<string, object>> EstimatedActuals { get; set; } 
}
