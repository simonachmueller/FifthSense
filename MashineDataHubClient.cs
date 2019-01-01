using System;
using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;

public class MashineDataHubClient
{
    private HubConnection connection;
    private IMashineDataReceiver receiver;
    public MashineDataHubClient(string uri, IMashineDataReceiver receiver)
    {
        this.receiver = receiver;
        connection = new HubConnectionBuilder().WithUrl(uri).Build();
        connection.Closed += async (error) =>
        {
            await Task.Delay(1000);
            await connection.StartAsync();
        };
    }

    public async Task Start()
    {
        connection.On<string, string>("ReceiveMessage", (user, message) =>
        {
            receiver.ReceiveMessage(message);
        });
        await connection.StartAsync();
    }

    public async Task Stop()
    {
        await connection.StopAsync();
    }
}