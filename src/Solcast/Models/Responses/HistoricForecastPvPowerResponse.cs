using System.Collections.Generic;
using Newtonsoft.Json;

public class HistoricForecastPvPowerResponse
{

    [JsonProperty("historic_forecasts")]
    public List<Dictionary<string, object>> HistoricForecasts { get; set; } 
}
