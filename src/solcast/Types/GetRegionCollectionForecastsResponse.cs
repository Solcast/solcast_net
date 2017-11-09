using System.Collections.Generic;
using ServiceStack;

namespace Solcast.ServiceModel
{
    public class GetRegionCollectionForecastsResponse
    {
        public GetRegionCollectionForecastsResponse()
        {
            Forecasts = new List<ApiCollectionPowerForecast>{};
        }

        public virtual List<ApiCollectionPowerForecast> Forecasts { get; set; }
        public virtual ResponseStatus ResponseStatus { get; set; }
    }
}