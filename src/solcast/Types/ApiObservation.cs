using System;
using System.Runtime.Serialization;

namespace Solcast.ServiceModel
{
    [DataContract]
    public class ApiObservation
    {
        [DataMember]
        public virtual int Ghi { get; set; }

        [DataMember]
        public virtual int Ebh { get; set; }

        [DataMember]
        public virtual int Dni { get; set; }

        [DataMember]
        public virtual int Dhi { get; set; }

        [DataMember(Name="cloud_opacity")]
        public virtual int CloudOpacity { get; set; }

        [DataMember(Name="period_end")]
        public virtual DateTime PeriodEnd { get; set; }

        [DataMember]
        public virtual TimeSpan Period { get; set; }
    }
}