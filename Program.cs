using System;
using System.Threading.Tasks;

namespace FifthSense
{
    class Program
    {
        private static MashineDataHubClient client;
        static async Task Main(string[] args)
        {
            var hostUri = "https://fifthsense.gpio/MashineDataHub";
            var connString = "Host=localhost;Username=test;Password=test;Database=FifthSense";
            var receiver = new MashineDataReceiver(new MashineDataRepository(connString));
            Console.CancelKeyPress += delegate { StopClient().Wait();};
            
            client = new MashineDataHubClient(hostUri, receiver);
            await client.Start();

            /*
            var message = "{\"timestamp\":1545581650234," +
            "\"type\":\"SensorData\"," +
            "\"id\":\"7e8b93c3-44bb-425f-a8d8-f48bb8e58365\"," +
            "\"data\":{\"sensor1\":12.3,\"sensor2\":10.0,\"sensor3\":12.3,\"sensor4\":\"open\"}" +
            "}";
            receiver.ReceiveMessage(message);
            */
        }

        private static async Task StopClient()
        {
            await client?.Stop();
        }
    }
}
