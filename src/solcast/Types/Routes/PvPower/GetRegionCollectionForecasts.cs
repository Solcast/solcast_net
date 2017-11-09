using ServiceStack;

namespace Solcast.ServiceModel
{
    [Route("/pv_power/collections/{CollectionId}/forecasts", "GET")]
    public class GetRegionCollectionForecasts
        : IReturn<GetRegionCollectionForecastsResponse>
    {
        public virtual string CollectionId { get; set; }
    }
}