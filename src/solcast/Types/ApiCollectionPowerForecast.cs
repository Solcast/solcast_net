namespace Solcast.ServiceModel
{
    public class ApiCollectionPowerForecast
        : ApiAggregationPowerForecast
    {
        public virtual string AggregationName { get; set; }
        public virtual string AggregationId { get; set; }
    }
}