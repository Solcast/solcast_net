using ServiceStack;

namespace solcast.types
{
    [Route("/pv_power/collections/{CollectionId}/forecasts", "GET")]
    public class GetRegionCollectionForecasts
        : IReturn<GetRegionCollectionForecastsResponse>
    {
        public virtual string CollectionId { get; set; }
    }
}