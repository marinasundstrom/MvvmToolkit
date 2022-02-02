using System;

using Microsoft.Extensions.DependencyInjection;

using MvvmToolkit;
using MvvmToolkit.Navigation;

namespace NavigationApp;

public class ShellViewModel : BindableObject
{
    private readonly IServiceProvider serviceProvider;

    public ShellViewModel(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public void Initialize()
    {
        serviceProvider
            .GetService<INavigationService>()
            .Navigate(new Uri("/MainPage", UriKind.Relative));
    }
}
