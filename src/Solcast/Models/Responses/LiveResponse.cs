using System.Collections.Generic;
using Newtonsoft.Json;

public class LiveResponse
{

    [JsonProperty("estimated_actuals")]
    public List<Dictionary<string, object>> EstimatedActuals { get; set; }

    [JsonProperty("response_status")]
    public string ResponseStatus { get; set; }
}
