using ServiceStack;

namespace Solcast.ServiceModel
{
    [Route("/pv_power/estimated_actuals/latest", "GET")]
    public class GetLatestPvPowerEstimatedActuals
        : GetPvPowerEstimatedActualsBase, IReturn<GetPvPowerEstimatedActualsResponse>
    {
    }
}