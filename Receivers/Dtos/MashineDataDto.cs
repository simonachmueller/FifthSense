using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class MashineDataDto
{
    [JsonProperty("timestamp")]
    public long Timestamp { get; set; }
    
    [JsonProperty("type")]
    public string Type { get; set; }
    
    [JsonProperty("id")]
    public Guid Id { get; set; }
    
    [JsonProperty("data")]
    public Dictionary<string, string> Data { get; set; }
}
