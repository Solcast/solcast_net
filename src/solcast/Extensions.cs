using System.Collections.Generic;
using System.Linq;
using solcast.types;

namespace solcast
{
    public static class Extensions
    {
        private static Dictionary<string, object> ToUpperKeys(this IDictionary<string, object> current)
        {
            return (current ?? new Dictionary<string, object>()).ToDictionary(item => item.Key.ToUpperInvariant(), item => item.Value);
        }

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
        
        public static GetPvPowerForecasts ToPvPowerForecasts(this Location input)
        {
            input = input ?? new Location();
            input.Options = input.Options.ToUpperKeys();

            float capacity = 5000;
            if (input.Options.TryGetValue("capacity".ToUpperInvariant(), out var result))
            {
                capacity = (float) result;
            }
            
            return new GetPvPowerForecasts
            {
                Capacity = capacity,
                Latitude = (double) input.Latitude,
                Longitude = (double) input.Longitude                
            };
        }
    }
}