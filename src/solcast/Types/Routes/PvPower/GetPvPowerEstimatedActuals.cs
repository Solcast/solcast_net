using ServiceStack;

namespace solcast.types
{
    [Route("/pv_power/estimated_actuals", "GET")]
    public class GetPvPowerEstimatedActuals
        : GetPvPowerEstimatedActualsBase, IReturn<GetPvPowerEstimatedActualsResponse>
    {
    }
}