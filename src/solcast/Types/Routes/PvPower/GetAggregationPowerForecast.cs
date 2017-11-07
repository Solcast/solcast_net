using ServiceStack;

namespace Solcast.Types
{
    [Route("/pv_power/collections/{CollectionId}/aggregations/{AggregationId}/forecasts", "GET")]
    public class GetAggregationPowerForecast
        : IReturn<GetAggregationPowerForecastResponse>
    {
        public virtual string CollectionId { get; set; }
        public virtual string AggregationId { get; set; }
    }
}