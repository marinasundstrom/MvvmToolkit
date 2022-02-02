using System;
using System.Threading.Tasks;

namespace MvvmToolkit.Navigation;

public interface INavigationService
{
    Task Navigate(Uri navigationUri);

    Task Navigate(string navigationUri);

    Task GoBack();

    void ClearAllBackEntries();
}
