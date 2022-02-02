using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace MvvmToolkit.Windowing.WPF;

public abstract class BaseDialog<TResult>
    : Window, IDialogWindow<TResult>
{
    public BaseDialog() { }

    public BaseDialog(INotifyPropertyChanged viewModel)
    {
        DataContext = viewModel;
    }

    public event EventHandler Shown;

    public new event EventHandler Closed;

    public async Task<TResult> OnClosed()
    {
        if (DataContext is IDialogAware<TResult> wa)
        {
            return await wa.OnClosed();
        }

        RaiseClosed();

        return default;
    }

    public virtual async Task OnShown(params object[] args)
    {
        base.Show();

        if (DataContext is IWindowAware<TResult> wa)
        {
            await wa.OnShown(null);
        }

        RaiseShown();
    }

    protected void RaiseShown()
    {
        Shown?.Invoke(this, EventArgs.Empty);
    }

    protected void RaiseClosed()
    {
        Closed?.Invoke(this, EventArgs.Empty);
    }

    public Task OnShown()
    {
        throw new NotImplementedException();
    }

    Task IWindow.OnClosed()
    {
        throw new NotImplementedException();
    }
}
