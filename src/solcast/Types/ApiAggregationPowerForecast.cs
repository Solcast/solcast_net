using System;

namespace Solcast.Types
{
    public class ApiAggregationPowerForecast
    {
        public virtual double PvEstimate { get; set; }
        public virtual double PvEstimate10 { get; set; }
        public virtual double PvEstimate90 { get; set; }
        public virtual DateTime PeriodEnd { get; set; }
        public virtual TimeSpan Period { get; set; }
    }
}