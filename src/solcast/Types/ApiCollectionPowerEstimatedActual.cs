namespace Solcast.ServiceModel
{
    public class ApiCollectionPowerEstimatedActual
        : ApiAggregationPowerEstimateActual
    {
        public virtual string AggregationName { get; set; }
        public virtual string AggregationId { get; set; }
    }
}