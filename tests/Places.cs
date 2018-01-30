using System;
using System.Collections.Generic;
using System.Linq;

namespace Solcast.Tests
{    
    public static class Places
    {
        public static IEnumerable<TimeZoneInfo> TimeZones => TimeZoneInfo.GetSystemTimeZones();

        public static Location Sydney()
        {
            return new Location
            {
                Name = "Sydney, Australia",
                Latitude = -33.865143M,
                Longitude = 151.209900M,
                TimeZone = TimeZones.SingleOrDefault(z => z.StandardName == "AUS Eastern Standard Time") ?? TimeZoneInfo.Utc
            };
        }

        public static Location LosAngeles()
        {
            return new Location
            {
                Name = "Los Angeles, USA",
                Latitude = 34.052235M,
                Longitude = -118.243683M,
                TimeZone = TimeZones.SingleOrDefault(z => z.StandardName == "Pacific Standard Time") ?? TimeZoneInfo.Utc
            };
        }          
    }
}