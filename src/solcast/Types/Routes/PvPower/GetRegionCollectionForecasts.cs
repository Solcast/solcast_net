using ServiceStack;

namespace Solcast.Types
{
    [Route("/pv_power/collections/{CollectionId}/forecasts", "GET")]
    public class GetRegionCollectionForecasts
        : IReturn<GetRegionCollectionForecastsResponse>
    {
        public virtual string CollectionId { get; set; }
    }
}