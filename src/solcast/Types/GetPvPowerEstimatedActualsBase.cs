using System.Runtime.Serialization;
using ServiceStack;

namespace solcast.types
{
    [DataContract]
    public class GetPvPowerEstimatedActualsBase
    {
        [DataMember]
        [ApiMember(Name="latitude", IsRequired=true)]
        public virtual double Latitude { get; set; }

        [DataMember]
        [ApiMember(Name="longitude", IsRequired=true)]
        public virtual double Longitude { get; set; }

        [DataMember]
        [ApiMember(Name="capacity", IsRequired=true)]
        public virtual float Capacity { get; set; }

        [DataMember]
        [ApiMember(Name="tilt")]
        public virtual float? Tilt { get; set; }

        [DataMember]
        [ApiMember(Name="azimuth")]
        public virtual float? Azimuth { get; set; }

        [DataMember(Name="install_date")]
        [ApiMember(Name="install_date")]
        public virtual string InstallDate { get; set; }

        [DataMember(Name="loss_factor")]
        [ApiMember(Name="loss_factor")]
        public virtual float? LossFactor { get; set; }
    }
}