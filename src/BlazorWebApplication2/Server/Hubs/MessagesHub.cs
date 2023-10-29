using Microsoft.AspNetCore.SignalR;

namespace BlazorWebAssemblySignalRApp.Server.Hubs;

public class MessagesHub : Hub
{
    public async Task SendMessage(Guid id, string text)
    {
        await Clients.All.SendAsync("ReceiveMessage", id, text);
    }
}
