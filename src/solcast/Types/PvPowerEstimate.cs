using System;

namespace Solcast.Types
{
    public class PvPowerEstimate
    {
        public virtual DateTime PeriodEnd { get; set; }
        public virtual TimeSpan Period { get; set; }
        public virtual double PvEstimate { get; set; }
    }
}