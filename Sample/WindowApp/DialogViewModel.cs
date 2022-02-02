using System.Threading.Tasks;

using MvvmToolkit;
using MvvmToolkit.Windowing;

namespace WindowApp;

public class DialogViewModel : BindableObject, IDialogAware<string, DialogResult>
{
    private string name;

    public Task OnShown(params object[] args)
    {
        return Task.CompletedTask;
    }
    public Task OnShown(string arg)
    {
        return Task.CompletedTask;
    }

    public string Name
    {
        get => name;
        set => SetProperty(ref name, value);
    }

    public Task<DialogResult> OnClosed()
    {
        return Task.FromResult(new DialogResult()
        {
            Name = name
        });
    }

    Task IWindowAware.OnClosed()
    {
        return Task.CompletedTask;
    }
}
