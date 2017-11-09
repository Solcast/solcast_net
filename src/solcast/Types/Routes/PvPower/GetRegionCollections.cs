using ServiceStack;

namespace Solcast.ServiceModel
{
    [Route("/pv_power/collections", "GET")]
    public class GetRegionCollections
        : IReturn<GetRegionCollectionsResponse>
    {
    }
}