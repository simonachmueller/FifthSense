using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

public class MessageReceiver
{
    private readonly IMashineDataRepository repository;

    public class MashineDataDTO
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
    public MessageReceiver(IMashineDataRepository repository)
    {
        this.repository = repository;
    }

    public void ReceiveMessage(string json)
    {
        var data = JsonConvert.DeserializeObject<MashineDataDTO>(json);
        repository.InsertMashineData(data.Timestamp, data.Type, data.Id, data.Data.Select(d => (d.Key, d.Value)).ToArray());
    }
}