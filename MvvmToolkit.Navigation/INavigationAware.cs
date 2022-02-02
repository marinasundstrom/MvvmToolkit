using System.Threading.Tasks;

namespace MvvmToolkit.Navigation;

public interface INavigationAware
{
    Task OnNavigatedTo(NavigationContext navigationContext);
    Task OnNavigatedFrom(NavigationContext navigationContext);
}
