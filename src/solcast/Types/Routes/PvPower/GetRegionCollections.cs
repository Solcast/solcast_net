using ServiceStack;

namespace Solcast.Types
{
    [Route("/pv_power/collections", "GET")]
    public class GetRegionCollections
        : IReturn<GetRegionCollectionsResponse>
    {
    }
}