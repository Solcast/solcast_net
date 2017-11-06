using System.Collections.Generic;
using ServiceStack;

namespace solcast.types
{
    public class GetLatestRadiationEstimatedActualsResponse
    {
        public GetLatestRadiationEstimatedActualsResponse()
        {
            EstimatedActuals = new List<ApiObservation>{};
        }

        public virtual List<ApiObservation> EstimatedActuals { get; set; }
        public virtual ResponseStatus ResponseStatus { get; set; }
    }
}