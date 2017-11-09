using System.Collections.Generic;
using ServiceStack;

namespace Solcast.ServiceModel
{
    public class GetRegionCollectionAggregationsResponse
    {
        public GetRegionCollectionAggregationsResponse()
        {
            Aggregations = new List<RegionAggregation>{};
        }

        public virtual List<RegionAggregation> Aggregations { get; set; }
        public virtual ResponseStatus ResponseStatus { get; set; }
    }
}