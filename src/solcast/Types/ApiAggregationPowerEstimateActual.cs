using System;

namespace solcast.types
{
    public class ApiAggregationPowerEstimateActual
    {
        public virtual float PvEstimate { get; set; }
        public virtual DateTime PeriodEnd { get; set; }
        public virtual TimeSpan Period { get; set; }
    }
}