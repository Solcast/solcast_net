using System.Collections.Generic;
using Newtonsoft.Json;

namespace Solcast.Models
{
    public class HistoricPvPowerResponse
    {
        [JsonProperty("estimated_actuals")]
        public List<Dictionary<string, object>> EstimatedActuals { get; set; }
    }
}
