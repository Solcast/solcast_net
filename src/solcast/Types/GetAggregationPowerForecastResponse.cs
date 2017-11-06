using System.Collections.Generic;
using ServiceStack;

namespace solcast.types
{
    public class GetAggregationPowerForecastResponse
    {
        public GetAggregationPowerForecastResponse()
        {
            Forecasts = new List<ApiAggregationPowerForecast>{};
        }

        public virtual string AggregationName { get; set; }
        public virtual List<ApiAggregationPowerForecast> Forecasts { get; set; }
        public virtual ResponseStatus ResponseStatus { get; set; }
    }
}