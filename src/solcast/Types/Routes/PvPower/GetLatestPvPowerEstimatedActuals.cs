using ServiceStack;

namespace Solcast.Types
{
    [Route("/pv_power/estimated_actuals/latest", "GET")]
    public class GetLatestPvPowerEstimatedActuals
        : GetPvPowerEstimatedActualsBase, IReturn<GetPvPowerEstimatedActualsResponse>
    {
    }
}