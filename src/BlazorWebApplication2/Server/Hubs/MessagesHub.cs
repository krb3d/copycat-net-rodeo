using Microsoft.AspNetCore.SignalR;

namespace BlazorWebAssemblySignalRApp.Server.Hubs;

public class MessagesHub : Hub
{
    public async Task SendMessage(Guid id, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", id, message);
    }
}
