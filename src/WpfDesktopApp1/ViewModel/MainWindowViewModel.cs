using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MassTransit;
using Microsoft.Extensions.Options;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WpfDesktopApp1.Model;
using WpfDesktopApp1.Services;

namespace WpfDesktopApp1.ViewModel;

public interface IMainWindowViewModel
{
    string HubUrl { get; }

    string NewMessageText { get; set; }

    ObservableCollection<Message> Messages { get; set; }

    IAsyncRelayCommand SendCommand { get; }
}

public partial class MainWindowViewModel : ObservableObject, IMainWindowViewModel
{
    private readonly IHubClient _hubClient;
    private readonly AppSettings _settings;

    public MainWindowViewModel(
        IHubClient hubClient,
        IOptions<AppSettings> options)
    {
        _hubClient = hubClient ?? throw new ArgumentNullException(nameof(hubClient));
        _hubClient.OnReceivingMessage += OnReceivingMessage;

        _settings = options?.Value ?? throw new ArgumentNullException(nameof(options));
    }

    public string HubUrl => _settings.HubUrl;

    [ObservableProperty]
    string _newMessageText = string.Empty;

    [ObservableProperty]
    ObservableCollection<Message> _messages = new();

    [RelayCommand]
    public async Task Send()
    {
        if (string.IsNullOrEmpty(NewMessageText))
        {
            return;
        }

        if (!_hubClient.IsConnected)
        {
            return;
        }

        var newMessage = new Message
        {
            Id = NewId.NextSequentialGuid(),
            Text = NewMessageText,
        };

        await _hubClient.SendMessage(newMessage);

        NewMessageText = string.Empty;
    }

    private void OnReceivingMessage(Message receivedMessage)
    {
        // Can't do this directly because of UI thread resource ownership
        // Messages.Add(receivedMessage);

        App.Current.Dispatcher.Invoke(
            () => Messages.Add(receivedMessage));
    }
}
