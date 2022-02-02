using System.Windows;

using Microsoft.Extensions.DependencyInjection;

using MvvmToolkit;
using MvvmToolkit.Navigation;

using NavigationApp.SubSection;

namespace NavigationApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public App()
    {
        Startup += Application_Startup;
    }

    private void Application_Startup(object sender, StartupEventArgs e)
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddSingleton<IThreadDispatcher, ThreadDispatcher>();

        serviceCollection.AddSingleton<ShellWindow>();
        serviceCollection.AddSingleton<ShellViewModel>();

        serviceCollection.AddSingleton<MainPage>();
        serviceCollection.AddSingleton<MainViewModel>();

        serviceCollection.AddSingleton<SubPage>();
        serviceCollection.AddSingleton<SubViewModel>();

        serviceCollection.AddSingleton<INavigationService>(sp =>
        {
            return new NavigationService((App.Current.MainWindow as ShellWindow).NavigationFrame, sp);
        });

        ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

        serviceProvider
            .GetService<ShellWindow>()
            .Show();
    }
}
