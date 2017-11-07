using Solcast.Types;

namespace Solcast
{
    public static class RadiationExtensions
    {
        public static GetRadiationForecasts ToRadiationForecasts(this Location input)
        {
            input = input ?? new Location();
            input.Options = input.Options.ToUpperKeys();            
            return new GetRadiationForecasts
            {
                Latitude = (double) input.Latitude,
                Longitude = (double) input.Longitude                
            };            
        }        
        public static GetRadiationEstimatedActuals ToRadiationEstimatedActuals(this Location input)
        {
            input = input ?? new Location();
            input.Options = input.Options.ToUpperKeys();            
            return new GetRadiationEstimatedActuals
            {
                Latitude = (double) input.Latitude,
                Longitude = (double) input.Longitude                
            };            
        }        
        public static GetLatestRadiationEstimatedActuals ToLatestRadiationEstimatedActuals(this Location input)
        {
            input = input ?? new Location();
            input.Options = input.Options.ToUpperKeys();            
            return new GetLatestRadiationEstimatedActuals
            {
                Latitude = (double) input.Latitude,
                Longitude = (double) input.Longitude                
            };            
        }        
    }
}