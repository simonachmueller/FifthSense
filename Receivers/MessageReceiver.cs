using System.Linq;
using Newtonsoft.Json;

public class MessageReceiver
{
    private readonly IMashineDataRepository repository;
    public MessageReceiver(IMashineDataRepository repository)
    {
        this.repository = repository;
    }

    public void ReceiveMessage(string json)
    {
        var data = JsonConvert.DeserializeObject<MashineDataDto>(json);
        repository.InsertMashineData(data.Timestamp, data.Type, data.Id, data.Data.Select(d => (d.Key, d.Value)).ToArray());
    }
}