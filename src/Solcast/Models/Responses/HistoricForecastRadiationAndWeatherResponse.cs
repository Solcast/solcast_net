using System.Collections.Generic;
using Newtonsoft.Json;

namespace Solcast.Models
{
    public class HistoricForecastRadiationAndWeatherResponse
    {
        [JsonProperty("historic_forecasts")]
        public List<Dictionary<string, object>> HistoricForecasts { get; set; }
    }
}
