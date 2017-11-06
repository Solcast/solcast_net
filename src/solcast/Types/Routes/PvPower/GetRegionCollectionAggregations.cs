using ServiceStack;

namespace solcast.types
{
    [Route("/pv_power/collections/{CollectionId}/aggregations", "GET")]
    public class GetRegionCollectionAggregations
        : IReturn<GetRegionCollectionAggregationsResponse>
    {
        public virtual string CollectionId { get; set; }
    }
}