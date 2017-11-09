using ServiceStack;

namespace Solcast.ServiceModel
{
    [Route("/radiation/forecasts", "GET")]
    public class GetRadiationForecasts
        : IReturn<GetRadiationForecastsResponse>
    {
        [ApiMember(Name="latitude", IsRequired=true)]
        public virtual double Latitude { get; set; }

        [ApiMember(Name="longitude", IsRequired=true)]
        public virtual double Longitude { get; set; }
    }
}