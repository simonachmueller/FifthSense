using System;

public interface IMashineDataRepository
{
    void InsertMashineData(long timestamp, string dataType, Guid id, (string sensorName, string sensorValue)[] data);
}