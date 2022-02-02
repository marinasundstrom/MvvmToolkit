using System;
using System.Windows;

using Microsoft.Extensions.DependencyInjection;

using MvvmToolkit;
using MvvmToolkit.Windowing;

namespace WindowApp;

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

        serviceCollection.AddSingleton<MainWindow>();
        serviceCollection.AddSingleton<MainViewModel>();

        serviceCollection.AddSingleton<FooWindow>();
        serviceCollection.AddSingleton<FooViewModel>();

        serviceCollection.AddTransient<DialogWindow>();
        serviceCollection.AddTransient<DialogViewModel>();

        serviceCollection.AddSingleton<IWindowManager, WindowManager>();

        ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

        serviceProvider
            .GetService<MainWindow>()
            .Show();
    }
}
