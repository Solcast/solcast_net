using System;

namespace solcast
{
    public static class LocationExtensions
    {
        public static class LatLngBounds
        {
            private static class Ranges
            {
                public const decimal LatRange = 90;
                public const decimal LngRange = 180;
            }

            public static decimal LatMin => Ranges.LatRange * -1;
            public static decimal LngMin => Ranges.LngRange * -1;
            public static decimal LatMax => Ranges.LatRange;
            public static decimal LngMax => Ranges.LngRange;
        }

        private static TimeZoneInfo CurrentTimeZoneInfo()
        {
            var timeZone = TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.Now)
                ? TimeZoneInfo.Local.DaylightName
                : TimeZoneInfo.Local.StandardName;
            return TimeZoneInfo.FindSystemTimeZoneById(timeZone);
        }

              
        
        public static Location Random()
        {
            var rnd = new Random((int) DateTime.Now.Ticks);
            var result = new Location
            {
                Name = "<RANDOM>",
                TimeZone = CurrentTimeZoneInfo(),                
                Latitude =
                    (decimal) (rnd.Next((int) LatLngBounds.LatMin, (int) LatLngBounds.LatMax) * rnd.NextDouble()),
                Longitude =
                    (decimal) (rnd.Next((int) LatLngBounds.LngMin, (int) LatLngBounds.LngMax) * rnd.NextDouble())
            };
            return result;
        }        
    }
}