using ServiceStack;

namespace Solcast.ServiceModel
{
    [Route("/pv_power/collections/{CollectionId}/aggregations/{AggregationId}/estimated_actuals", "GET")]
    public class GetAggregationPowerEstimatedActuals
        : IReturn<GetAggregationPowerEstimatedActualsResponse>
    {
        public virtual string CollectionId { get; set; }
        public virtual string AggregationId { get; set; }
    }
}