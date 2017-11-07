using System;

namespace solcast.tests
{
    public static class Places
    {
        public static Location Sydney()
        {
            return new Location
            {
                Name = "Sydney, Australia",
                Latitude = -33.865143M,
                Longitude = 151.209900M,
                TimeZone = TimeZoneInfo.FindSystemTimeZoneById("AUS Eastern Standard Time")
            };
        }

        public static Location LosAngeles()
        {
            return new Location
            {
                Name = "Los Angeles, USA",
                Latitude = 34.052235M,
                Longitude = -118.243683M,
                TimeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time")
            };
        }          
    }
}