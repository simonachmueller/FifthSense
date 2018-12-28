using System;

namespace FifthSense
{
    class Program
    {
        static void Main(string[] args)
        {
            var receiver = new MessageReceiver(new MashineDataRepository("bla"));
            var message = "{\"timestamp\":1545581650234," +
            "\"type\":\"SensorData\"," +
            "\"id\":\"7e8b93c3-44bb-425f-a8d8-f48bb8e58365\"," +
            "\"data\":{\"sensor1\":12.3,\"sensor2\":10.0,\"sensor3\":12.3,\"sensor4\":\"open\"}" +
            "}";
            receiver.ReceiveMessage(message);
        }
    }
}
