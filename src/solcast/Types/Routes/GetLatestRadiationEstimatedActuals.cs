using ServiceStack;

namespace solcast.types
{
    [Route("/radiation/estimated_actuals/latest", "GET")]
    public class GetLatestRadiationEstimatedActuals
        : IReturn<GetLatestRadiationEstimatedActualsResponse>
    {
        [ApiMember(Name="latitude", IsRequired=true)]
        public virtual double Latitude { get; set; }

        [ApiMember(Name="longitude", IsRequired=true)]
        public virtual double Longitude { get; set; }
    }
}