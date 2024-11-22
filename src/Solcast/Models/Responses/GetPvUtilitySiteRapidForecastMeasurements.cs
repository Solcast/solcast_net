using Newtonsoft.Json;

namespace Solcast.Models
{
    public class GetPvUtilitySiteRapidForecastMeasurements
    {
        [JsonProperty("resource_id")]
        public string ResourceId { get; set; }
    }
}
