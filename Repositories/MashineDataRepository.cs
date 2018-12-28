using System;

public class MashineDataRepository : IMashineDataRepository
{
    public MashineDataRepository(string connection)
    {
        
    }
    public void InsertMashineData(long timestamp, string dataType, Guid id, (string sensorName, string sensorValue)[] data)
    {
        throw new NotImplementedException();
    }
}