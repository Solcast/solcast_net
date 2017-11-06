using System;

namespace solcast.types
{
    public class PvPowerEstimate
    {
        public virtual DateTime PeriodEnd { get; set; }
        public virtual TimeSpan Period { get; set; }
        public virtual double PvEstimate { get; set; }
    }
}