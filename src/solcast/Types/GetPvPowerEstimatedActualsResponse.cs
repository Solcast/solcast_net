using System.Collections.Generic;
using ServiceStack;

namespace Solcast.ServiceModel
{
    public class GetPvPowerEstimatedActualsResponse
    {
        public GetPvPowerEstimatedActualsResponse()
        {
            EstimatedActuals = new List<PvPowerEstimate>{};
        }

        public virtual List<PvPowerEstimate> EstimatedActuals { get; set; }
        public virtual ResponseStatus ResponseStatus { get; set; }
    }
}