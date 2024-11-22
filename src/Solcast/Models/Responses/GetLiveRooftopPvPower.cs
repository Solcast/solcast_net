using System.Collections.Generic;
using Newtonsoft.Json;

namespace Solcast.Models
{
    public class GetLiveRooftopPvPower
    {
        [JsonProperty("start_date")]
        public string StartDate { get; set; }

        [JsonProperty("end_date")]
        public string EndDate { get; set; }

        /// <summary>
        /// The number of hours to return in the response.
        /// </summary>
        [JsonProperty("hours")]
        public int? Hours { get; set; }

        /// <summary>
        /// Length of the averaging period in ISO 8601 format.
        /// </summary>
        [JsonProperty("period")]
        public string Period { get; set; }

        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }

        /// <summary>
        /// The latitude of the location you request data for. Must be a decimal number between -90 and 90.
        /// </summary>
        [JsonProperty("latitude")]
        public double? Latitude { get; set; } // Required

        /// <summary>
        /// The longitude of the location you request data for. Must be a decimal number between -180 and 180.
        /// </summary>
        [JsonProperty("longitude")]
        public double? Longitude { get; set; } // Required

        /// <summary>
        /// The capacity of the inverter (AC) or the modules (DC), whichever is greater, in kilowatts (kW).
        /// </summary>
        [JsonProperty("capacity")]
        public float? Capacity { get; set; } // Required

        /// <summary>
        /// The angle (degrees) that the PV system is tilted off the horizontal. A tilt of 0 means the system faces directly upwards, and 90 means the system is vertical and facing the horizon. If you don't specify tilt, we use a default tilt angle based on the latitude you specify in your request. Must be between 0 and 90.
        /// </summary>
        [JsonProperty("tilt")]
        public float? Tilt { get; set; }

        /// <summary>
        /// The azimuth is defined as the angle (degrees) from true north that the PV system is facing. An azimuth of 0 means the system is facing true north. Positive values are anticlockwise, so azimuth is -90 for an east-facing system and 135 for a southwest-facing system. If you don't specify an azimuth, we use a default value of 0 (north facing) in the southern hemisphere and 180 (south-facing) in the northern hemisphere.
        /// </summary>
        [JsonProperty("azimuth")]
        public float? Azimuth { get; set; }

        /// <summary>
        /// The date (yyyy-MM-dd) of installation of the PV system. We use this to estimate your loss_factor based on the ageing of your system. If you provide us with a loss_factor directly, we will ignore this date.
        /// </summary>
        [JsonProperty("install_date")]
        public string InstallDate { get; set; }

        /// <summary>
        /// Default is 0.90 A factor to reduce your output forecast from the full capacity based on characteristics of the PV array or inverter. This is effectively the non-temperature loss effects on the nameplate rating of the PV system, including inefficiency and soiling. For a 1kW PV system anything that reduces 1000W/m2 solar radiation from producing 1000W of power output (assuming temperature is 25C). Valid values are between 0 and 1 (i.e. 0.6 equals 60%). If you specify 0.6 your returned power will be a maximum of 60% of AC capacity.
        /// </summary>
        [JsonProperty("loss_factor")]
        public float? LossFactor { get; set; }

        /// <summary>
        /// The output parameters to include in the response.
        /// </summary>
        [JsonProperty("output_parameters")]
        public List<string> OutputParameters { get; set; }

        /// <summary>
        /// If true, irradiance parameters are modified based on the surrounding terrain from a 90m-horizontal-resolution digital elevation model. The direct component of irradiance is set to zero when the beam from the sun is blocked by the terrain. The diffuse component of irradiance is reduced throughout the day if the sky view at the location is significantly reduced by the surrounding terrain. Global irradiance incorporates both effects.
        /// </summary>
        [JsonProperty("terrain_shading")]
        public bool? TerrainShading { get; set; }

        /// <summary>
        /// Response format
        /// </summary>
        [JsonProperty("format")]
        public string Format { get; set; }
    }
}
