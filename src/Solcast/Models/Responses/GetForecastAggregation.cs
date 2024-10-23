using System.Collections.Generic;
using Newtonsoft.Json;

public class GetForecastAggregation
{
    [JsonProperty("zone")]
    public ZoneType Zone { get; set; } 
    [JsonProperty("output_parameters")]
    public List<string> OutputParameters { get; set; } 
    [JsonProperty("collection_id")]
    public string CollectionId { get; set; } 
    [JsonProperty("aggregation_id")]
    public string AggregationId { get; set; } 
    [JsonProperty("hours")]
    public int? Hours { get; set; } 
    [JsonProperty("period")]
    public string Period { get; set; } 
    [JsonProperty("format")]
    public string Format { get; set; } 
}
