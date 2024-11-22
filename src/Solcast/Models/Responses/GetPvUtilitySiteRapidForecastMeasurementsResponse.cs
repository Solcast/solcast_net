using System.Collections.Generic;
using Newtonsoft.Json;

namespace Solcast.Models
{
    public class GetPvUtilitySiteRapidForecastMeasurementsResponse
    {
        [JsonProperty("measurements")]
        public List<PvUtilityMeasurement> Measurements { get; set; }

        [JsonProperty("response_status")]
        public string ResponseStatus { get; set; }
    }
}
