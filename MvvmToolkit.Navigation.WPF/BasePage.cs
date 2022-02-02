using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MvvmToolkit.Navigation.WPF;

public abstract class BasePage : Page, IPage
{
    public BasePage() { }

    public BasePage(INotifyPropertyChanged viewModel)
    {
        DataContext = viewModel;

        Loaded += OnLoaded;
        Unloaded += OnUnloaded;
    }

    public virtual async Task OnNavigatedTo(NavigationContext navigationContext)
    {
        if (DataContext is INavigationAware navigationAware)
        {
            await navigationAware.OnNavigatedTo(navigationContext);
        }
    }

    public virtual async Task OnNavigatedFrom(NavigationContext navigationContext)
    {
        if (DataContext is INavigationAware navigationAware)
        {
            await navigationAware.OnNavigatedFrom(navigationContext);
        }
    }

    protected virtual void OnLoaded(object sender, System.Windows.RoutedEventArgs e)
    {

    }

    protected virtual void OnUnloaded(object sender, System.Windows.RoutedEventArgs e)
    {

    }
}
