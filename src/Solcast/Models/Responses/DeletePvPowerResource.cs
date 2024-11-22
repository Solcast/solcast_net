using Newtonsoft.Json;

namespace Solcast.Models
{
    public class DeletePvPowerResource
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        [JsonProperty("resource_id")]
        public string ResourceId { get; set; } // Required
    }
}
