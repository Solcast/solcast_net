using System.Collections.Generic;
using ServiceStack;

namespace Solcast.ServiceModel
{
    public class GetPvPowerForecastsResponse
    {
        public GetPvPowerForecastsResponse()
        {
            Forecasts = new List<PvPowerEstimate>{};
        }

        public virtual List<PvPowerEstimate> Forecasts { get; set; }
        public virtual ResponseStatus ResponseStatus { get; set; }
    }
}