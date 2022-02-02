using System.Threading.Tasks;

using MvvmToolkit;
using MvvmToolkit.Windowing;

namespace WindowApp;

public class MainViewModel : BindableObject, IWindowAware
{
    private readonly IWindowManager windowManager;
    private Command openWindowCommand;

    public MainViewModel(IWindowManager windowManager)
    {
        this.windowManager = windowManager;
    }

    public Command OpenWindowCommand => openWindowCommand ?? (openWindowCommand = new Command(async () =>
    {
        await windowManager.ShowWindowAsync("FooWindow");
    }));

    public Task OnClosed()
    {
        return Task.CompletedTask;
    }

    public Task OnShown(params object[] args)
    {
        return Task.CompletedTask;
    }
}
