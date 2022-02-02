using MvvmToolkit;
using MvvmToolkit.Navigation;

namespace NavigationApp.SubSection;

public class SubViewModel : BindableObject
{
    private readonly INavigationService navigationService;
    private Command goBackCommand;

    public SubViewModel(INavigationService navigationService)
    {
        this.navigationService = navigationService;
    }

    public Command GoBackCommand => goBackCommand ?? (goBackCommand = new Command(async () =>
    {
        await navigationService.GoBack();
    }));
}
