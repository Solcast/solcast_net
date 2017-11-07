using System;
using System.Runtime.Serialization;

namespace Solcast.Types
{
    [DataContract]
    public class ApiRadiationForecast
    {
        [DataMember]
        public virtual int Ghi { get; set; }

        [DataMember]
        public virtual int Ghi90 { get; set; }

        [DataMember]
        public virtual int Ghi10 { get; set; }

        [DataMember]
        public virtual int Ebh { get; set; }

        [DataMember]
        public virtual int Dni { get; set; }

        [DataMember]
        public virtual int Dni10 { get; set; }

        [DataMember]
        public virtual int Dni90 { get; set; }

        [DataMember]
        public virtual int Dhi { get; set; }

        [DataMember(Name="air_temp")]
        public virtual int AirTemp { get; set; }

        [DataMember]
        public virtual int Zenith { get; set; }

        [DataMember]
        public virtual float Azimuth { get; set; }

        [DataMember(Name="cloud_opacity")]
        public virtual int CloudOpacity { get; set; }

        [DataMember(Name="period_end")]
        public virtual DateTime PeriodEnd { get; set; }

        [DataMember]
        public virtual TimeSpan Period { get; set; }
    }
}