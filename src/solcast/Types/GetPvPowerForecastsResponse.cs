using System.Collections.Generic;
using ServiceStack;

namespace solcast.types
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