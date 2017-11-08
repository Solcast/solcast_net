using System;

namespace Solcast
{
    public class Location
    {
        public decimal Latitude { get; set;  }
        public decimal Longitude { get; set; }
        public TimeZoneInfo TimeZone { get; set; }
        public object Tag { get; set; }
        public string Name { get; set; }
    }
    
    public class Options
    {
        public PvSystem PowerOptions { get; set; }
        public RadiationSystem RadiationOptions { get; set; }
    }

    public class RadiationSystem
    {
    }    

    public class PvSystem
    {
        public decimal Capacity { get; set; }
        public decimal? Tilt { get; set; }
        public decimal? LossFactor { get; set; }
        /// <summary>
        /// Needs to be converted to yyyMMdd on request
        /// </summary>
        public DateTime? InstallDate { get; set; } 
    }
}