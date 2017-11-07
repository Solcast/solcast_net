using System.Collections.Generic;
using System.Runtime.Serialization;
using ServiceStack;

namespace Solcast.Types
{
    [DataContract]
    public class GetRadiationForecastsResponse
    {
        public GetRadiationForecastsResponse()
        {
            Forecasts = new List<ApiRadiationForecast>{};
        }

        [DataMember(Order=1)]
        public virtual List<ApiRadiationForecast> Forecasts { get; set; }

        [DataMember(Name="response_status", Order=2)]
        public virtual ResponseStatus ResponseStatus { get; set; }
    }
}