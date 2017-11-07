using System.Collections.Generic;
using ServiceStack;

namespace Solcast.Types
{
    public class GetRegionCollectionEstimateActualsResponse
    {
        public GetRegionCollectionEstimateActualsResponse()
        {
            EstimatedActuals = new List<ApiCollectionPowerEstimatedActual>{};
        }

        public virtual List<ApiCollectionPowerEstimatedActual> EstimatedActuals { get; set; }
        public virtual ResponseStatus ResponseStatus { get; set; }
    }
}