using System.Threading.Tasks;

using MvvmToolkit;
using MvvmToolkit.Windowing;

namespace WindowApp;

public class FooViewModel : BindableObject, IWindowAware
{
    private readonly IWindowManager windowManager;
    private Command openDialogCommand;
    private string name;

    public FooViewModel(IWindowManager windowManager)
    {
        this.windowManager = windowManager;
    }

    public string Name
    {
        get => name;
        set => SetProperty(ref name, value);
    }

    public Command OpenDialogCommand => openDialogCommand ?? (openDialogCommand = new Command(async () =>
    {
        DialogResult result = await windowManager.ShowDialogAsync();
        Name = result.Name;
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
