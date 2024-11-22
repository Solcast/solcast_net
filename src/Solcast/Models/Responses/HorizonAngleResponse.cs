using System.Collections.Generic;
using Newtonsoft.Json;

namespace Solcast.Models
{
    public class HorizonAngleResponse
    {
        [JsonProperty("horizon_angles")]
        public List<HorizonAngle> HorizonAngles { get; set; }

        [JsonProperty("response_status")]
        public string ResponseStatus { get; set; }
    }
}
