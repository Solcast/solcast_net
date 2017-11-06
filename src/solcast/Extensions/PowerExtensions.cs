using solcast.types;

namespace solcast
{
    public static class PowerExtensions
    {
        public static GetPvPowerForecasts ToPowerForecasts(this Location input)
        {
            input = input ?? new Location();
            return new GetPvPowerForecasts
            {
                Capacity = input.Capacity(),
                Latitude = (double) input.Latitude,
                Longitude = (double) input.Longitude                
            };
        }
        public static GetPvPowerEstimatedActuals ToPowerEstimatedActuals(this Location input)
        {
            input = input ?? new Location();
            return new GetPvPowerEstimatedActuals
            {
                Capacity = input.Capacity(),
                Latitude = (double) input.Latitude,
                Longitude = (double) input.Longitude                
            };
        }

        private static float Capacity(this Location input)
        {
            input = input ?? new Location();
            input.Options = input.Options.ToUpperKeys();

            float capacity = 5000;
            if (input.Options.TryGetValue("capacity".ToUpperInvariant(), out var result))
            {
                capacity = (float) result;
            }
            return capacity;
        }

        public static GetLatestPvPowerEstimatedActuals ToLatestPowerEstimatedActuals(this Location input)
        {
            input = input ?? new Location();
            return new GetLatestPvPowerEstimatedActuals
            {
                Capacity = input.Capacity(),
                Latitude = (double) input.Latitude,
                Longitude = (double) input.Longitude                
            };           
        }         
    }
}