using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;
using WpfDesktopApp1.Model;

namespace WpfDesktopApp1.Services
{
    public interface IHubClient
    {
        event Action<Message> OnReceivingMessage;

        bool IsConnected { get; }

        Task SendMessage(Message message);
    }

    public class HubClient : IHubClient, IAsyncDisposable
    {
        private readonly HubConnection _hub;

        public HubClient()
        {
            _hub = new HubConnectionBuilder()
                .WithUrl(@"https://localhost:7257/messages-hub")
                .WithAutomaticReconnect()
                .Build();

            _hub.On<string, string>(
                "ReceiveMessage",
                (id, text) =>
                {
                    var receivedMessage = new Message
                    {
                        Id = Guid.Parse(id),
                        Text = text,
                    };

                    OnReceivingMessage?.Invoke(receivedMessage);
                });

            _hub.StartAsync();
        }

        public bool IsConnected => _hub?.State == HubConnectionState.Connected;

        public event Action<Message>? OnReceivingMessage;

        public async Task SendMessage(Message message)
        {
            if (_hub is null)
            {
                return;
            }

            if (!IsConnected)
            {
                return;
            }

            await _hub.SendAsync(
                            "SendMessage",
                            message.Id,
                            message.Text);
        }

        public async ValueTask DisposeAsync()
        {
            if (_hub is not null)
            {
                await _hub.DisposeAsync();
            }
        }

    }
}
