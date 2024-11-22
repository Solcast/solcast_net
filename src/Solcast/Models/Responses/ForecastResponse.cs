using System.Collections.Generic;
using Newtonsoft.Json;

namespace Solcast.Models
{
    public class ForecastResponse
    {
        [JsonProperty("forecasts")]
        public List<Dictionary<string, object>> Forecasts { get; set; }

        [JsonProperty("response_status")]
        public string ResponseStatus { get; set; }
    }
}
