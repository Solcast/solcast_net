using ServiceStack;

namespace Solcast.ServiceModel
{
    [Route("/pv_power/collections/{CollectionId}/aggregations", "GET")]
    public class GetRegionCollectionAggregations
        : IReturn<GetRegionCollectionAggregationsResponse>
    {
        public virtual string CollectionId { get; set; }
    }
}