using System.Collections.Generic;
using Newtonsoft.Json;

public class ResponseStatus
{
    [JsonProperty("error_code")]
    public string ErrorCode { get; set; } 
    [JsonProperty("message")]
    public string Message { get; set; } 
    [JsonProperty("stack_trace")]
    public string StackTrace { get; set; } 
    [JsonProperty("errors")]
    public List<ResponseError> Errors { get; set; } 
    [JsonProperty("meta")]
    public IDictionary<string, object> Meta { get; set; } 
}
