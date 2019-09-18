using System.Threading.Tasks;

namespace MvvmToolkit.Navigation
{
    public interface IPage
    {
        Task OnNavigatedTo(NavigationContext navigationContext);
        Task OnNavigatedFrom(NavigationContext navigationContext);
    }
}
