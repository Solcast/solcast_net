using System;
using System.Collections.Generic;

namespace solcast
{
    public class Location
    {
        public decimal Latitude { get; set;  }
        public decimal Longitude { get; set; }
        public TimeZoneInfo TimeZone { get; set; }
        public Dictionary<string, object> Options { get; set; }
        public object Tag { get; set; }
        public string Name { get; set; }
    }
}