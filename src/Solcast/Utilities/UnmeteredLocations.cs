
using System.Collections.Generic;

namespace Solcast
{
    public static class UnmeteredLocations
    {
        public static readonly Dictionary<string, Location> Locations = new Dictionary<string, Location>
        {
            {
                "Sydney Opera House", new Location
                {
                    Latitude = -33.856784,
                    Longitude = 151.215297,
                    ResourceId = "ba75-e17a-7374-95ed"
                }
            },
            {
                "Grand Canyon", new Location
                {
                    Latitude = 36.099763,
                    Longitude = -112.112485,
                    ResourceId = "375f-eb3e-71c0-ef5e"
                }
            },
            {
                "Stonehenge", new Location
                {
                    Latitude = 51.178882,
                    Longitude = -1.826215,
                    ResourceId = "1a57-6b1f-ec18-c5c8"
                }
            },
            {
                "The Colosseum", new Location
                {
                    Latitude = 41.89021,
                    Longitude = 12.492231,
                    ResourceId = "5f86-4c8f-2cb3-0215"
                }
            },
            {
                "Giza Pyramid Complex", new Location
                {
                    Latitude = 29.977296,
                    Longitude = 31.132496,
                    ResourceId = "8d10-f530-af85-5cbb"
                }
            },
            {
                "Taj Mahal", new Location
                {
                    Latitude = 27.175145,
                    Longitude = 78.042142,
                    ResourceId = "b926-8fd2-ad3f-e4f5"
                }
            },
            {
                "Fort Peck", new Location
                {
                    Latitude = 48.30783,
                    Longitude = -105.1017,
                    ResourceId = "3ae7-2456-492c-9aba"
                }
            },
            {
                "Goodwin Creek", new Location
                {
                    Latitude = 34.2547,
                    Longitude = -89.8729,
                    ResourceId = "b787-cf17-e429-ef1d"
                }
            },

        };

        public static List<string> LoadTestLocationNames()
        {
            return new List<string>(Locations.Keys);
        }

        public static (List<double> Latitudes, List<double> Longitudes) LoadTestLocationCoordinates()
        {
            var latitudes = new List<double>();
            var longitudes = new List<double>();

            foreach (var location in Locations.Values)
            {
                latitudes.Add(location.Latitude);
                longitudes.Add(location.Longitude);
            }

            return (latitudes, longitudes);
        }
    }

    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string ResourceId { get; set; }
    }
}
