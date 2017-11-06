using ServiceStack;

namespace solcast.types
{
    [Route("/pv_power/collections", "GET")]
    public class GetRegionCollections
        : IReturn<GetRegionCollectionsResponse>
    {
    }
}