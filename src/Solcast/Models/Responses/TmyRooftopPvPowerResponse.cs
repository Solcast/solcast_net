using System.Collections.Generic;
using Newtonsoft.Json;

public class TmyRooftopPvPowerResponse
{

    [JsonProperty("estimated_actuals")]
    public List<Dictionary<string, object>> EstimatedActuals { get; set; }
}
