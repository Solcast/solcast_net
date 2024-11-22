using System.Collections.Generic;
using Newtonsoft.Json;

namespace Solcast.Models
{
    public class ResponseError
    {
        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }

        [JsonProperty("field_name")]
        public string FieldName { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("meta")]
        public IDictionary<string, object> Meta { get; set; }
    }
}
