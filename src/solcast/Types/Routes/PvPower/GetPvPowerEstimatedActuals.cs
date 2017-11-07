using ServiceStack;

namespace Solcast.Types
{
    [Route("/pv_power/estimated_actuals", "GET")]
    public class GetPvPowerEstimatedActuals
        : GetPvPowerEstimatedActualsBase, IReturn<GetPvPowerEstimatedActualsResponse>
    {
    }
}