using System.Collections.Generic;
using Newtonsoft.Json;

public class GetForecastAggregation
{

    [JsonProperty("zone")]
    public ZoneType Zone { get; set; }

    /// <summary>
    /// The output parameters to include in the response.
    /// </summary>
    [JsonProperty("output_parameters")]
    public List<string> OutputParameters { get; set; }

    /// <summary>
    /// Unique identifier for your collection.
    /// </summary>
    [JsonProperty("collection_id")]
    public string CollectionId { get; set; }

    /// <summary>
    /// Unique identifier that belongs to the requested collection.
    /// </summary>
    [JsonProperty("aggregation_id")]
    public string AggregationId { get; set; }

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

    /// <summary>
    /// Response format
    /// </summary>
    [JsonProperty("format")]
    public string Format { get; set; }
}
