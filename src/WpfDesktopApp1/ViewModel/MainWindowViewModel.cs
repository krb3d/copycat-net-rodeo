using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MassTransit;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfDesktopApp1.Model;

namespace WpfDesktopApp1.ViewModel;

public interface IMainWindowViewModel
{
    ObservableCollection<Message> Messages { get; set; }

    string NewMessageText { get; set; }

    IRelayCommand SendCommand { get; }
}

public partial class MainWindowViewModel : ObservableObject, IMainWindowViewModel
{
    [ObservableProperty]
    private string _newMessageText = string.Empty;

    [ObservableProperty]
    ObservableCollection<Message> _messages = new();

    [RelayCommand]
    public void Send()
    {
        if (string.IsNullOrEmpty(NewMessageText))
        {
            return;
        }

        var newMessage = new Message
        {
            Id = NewId.NextSequentialGuid(),
            Text = NewMessageText,
        };

        Messages.Add(newMessage);

        NewMessageText = string.Empty;
    }
}
