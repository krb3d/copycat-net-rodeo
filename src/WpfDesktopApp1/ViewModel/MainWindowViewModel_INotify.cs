using System;
using System.ComponentModel;

namespace WpfDesktopApp1.ViewModel;

[Obsolete("replaced with code generators from nuget CommunityToolkit.Mvvm")]
internal class MainWindowViewModel_INotify : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private string _newMessage = string.Empty;

    public string NewMessageText {
        get => _newMessage;
        set {
            _newMessage = value;
            OnPropertyChanged(nameof(NewMessageText));
        }
    }

    private void OnPropertyChanged(string name)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
