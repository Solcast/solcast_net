using ServiceStack;

namespace Solcast.ServiceModel
{
    [Route("/pv_power/estimated_actuals", "GET")]
    public class GetPvPowerEstimatedActuals
        : GetPvPowerEstimatedActualsBase, IReturn<GetPvPowerEstimatedActualsResponse>
    {
    }
}