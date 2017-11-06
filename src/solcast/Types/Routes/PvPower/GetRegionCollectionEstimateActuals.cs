using ServiceStack;

namespace solcast.types
{
    [Route("/pv_power/collections/{CollectionId}/estimated_actuals", "GET")]
    public class GetRegionCollectionEstimateActuals
        : IReturn<GetRegionCollectionEstimateActualsResponse>
    {
        public virtual string CollectionId { get; set; }
    }
}