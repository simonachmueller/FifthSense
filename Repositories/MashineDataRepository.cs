using System;
using Npgsql;
using System.Linq;

public class MashineDataRepository : IMashineDataRepository
{
    private readonly string connectionString;
    public MashineDataRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }
    public void InsertMashineData(long timestamp, string dataType, Guid id, (string sensorName, string sensorValue)[] data)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;
                var dataColumnsCommaSeparated = string.Join(",", new[]{"timestamp", "id"}.Concat(data.Select(x => x.sensorName)));
                var dataValueNamesCommaSeparated = string.Join(",", new[]{"@timestamp", "@id"}.Concat(data.Select(x => "@" + x.sensorName)));
                cmd.CommandText = @"INSERT INTO {dataType} ({dataColumnsCommaSeparated}) VALUES ({dataValueNamesCommaSeparated})";
                cmd.Parameters.AddWithValue("timestamp", timestamp);
                cmd.Parameters.AddWithValue("id", id);
                foreach(var sensorData in data)
                {
                    cmd.Parameters.AddWithValue(sensorData.sensorName, sensorData.sensorValue);
                }
                cmd.ExecuteNonQuery();
            }
        }

    }
}