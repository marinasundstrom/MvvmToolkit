using System;

using MvvmToolkit;
using MvvmToolkit.Navigation;

namespace NavigationApp;

public class MainViewModel : BindableObject
{
    private readonly INavigationService navigationService;
    private Command navigateToSubPageCommand;

    public MainViewModel(INavigationService navigationService)
    {
        this.navigationService = navigationService;
    }

    public Command NavigateToSubPageCommand => navigateToSubPageCommand ?? (navigateToSubPageCommand = new Command(async () =>
    {
        await navigationService.Navigate(new Uri("/SubSection/SubPage", UriKind.Relative));
    }));
}
