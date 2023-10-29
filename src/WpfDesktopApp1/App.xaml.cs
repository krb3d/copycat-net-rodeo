using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;
using WpfDesktopApp1.Services;
using WpfDesktopApp1.ViewModel;

namespace WpfDesktopApp1;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly IHost _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
                    .ConfigureServices((hostContext, services) =>
                    {
                        services.AddScoped<IMainWindowViewModel, MainWindowViewModel>();
                        services.AddScoped<IHubClient, HubClient>();
                        
                        services.AddSingleton<MainWindow>();
                    })
                    .Build();

        using var serviceScope = _host.Services.CreateScope();
        var services = serviceScope.ServiceProvider;

        try
        {
            var mainWindow = services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR: {ex}");
        }
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        using (_host)
        {
            await _host.StopAsync();
        }

        base.OnExit(e);
    }
}

