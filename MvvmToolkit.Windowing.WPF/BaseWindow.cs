using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace MvvmToolkit.Windowing.WPF;

public abstract class BaseWindow
    : Window, IWindow
{
    public BaseWindow() { }

    public BaseWindow(INotifyPropertyChanged viewModel)
    {
        DataContext = viewModel;
    }

    public event EventHandler Shown;

    public new event EventHandler Closed;

    public async Task OnClosed()
    {
        if (DataContext is IWindowAware wa)
        {
            await wa.OnClosed();
        }

        RaiseClosed();
    }

    public virtual async Task OnShown(params object[] args)
    {
        base.Show();

        if (DataContext is IWindowAware wa)
        {
            await wa.OnShown(args);
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
}

public class BaseWindow<A>
    : BaseWindow, IWindow<A>
{
    public BaseWindow() { }

    public BaseWindow(INotifyPropertyChanged viewModel)
        : base(viewModel)
    {

    }

    public override async Task OnShown(params object[] args)
    {
        base.Show();

        if (DataContext is IWindowAware<A> wa)
        {
            await wa.OnShown(args[0]);
        }

        RaiseShown();
    }

    public async Task OnShown(A arg)
    {
        base.Show();

        if (DataContext is IWindowAware<A> vm)
        {
            await vm.OnShown(arg);
        }

        RaiseShown();
    }
}

public class BaseWindow<A1, A2>
: BaseWindow, IWindow<A1, A2>
{
    public BaseWindow() { }

    public BaseWindow(INotifyPropertyChanged viewModel)
        : base(viewModel)
    {

    }

    public override async Task OnShown(params object[] args)
    {
        base.Show();

        if (DataContext is IWindowAware<A1, A2> wa)
        {
            await wa.OnShown(args[0], args[1]);
        }

        RaiseShown();
    }

    public async Task OnShown(A1 arg1, A2 arg2)
    {
        base.Show();

        if (DataContext is IWindowAware<A1, A2> vm)
        {
            await vm.OnShown(arg1, arg2);
        }

        RaiseShown();
    }
}

public class BaseWindow<A1, A2, A3>
    : BaseWindow, IWindow<A1, A2, A3>
{
    public BaseWindow() { }

    public BaseWindow(INotifyPropertyChanged viewModel)
        : base(viewModel)
    {

    }

    public override async Task OnShown(params object[] args)
    {
        base.Show();

        if (DataContext is IWindowAware<A1, A2, A3> wa)
        {
            await wa.OnShown(args[0], args[1], args[3]);
        }

        RaiseShown();
    }

    public async Task OnShown(A1 arg1, A2 arg2, A3 arg3)
    {
        base.Show();

        if (DataContext is IWindowAware<A1, A2, A3> vm)
        {
            await vm.OnShown(arg1, arg2, arg3);
        }

        RaiseShown();
    }
}

public class BaseDialog<A, TResult>
: BaseDialog<TResult>, IDialogWindow<A, TResult>
{
    public BaseDialog() { }

    public BaseDialog(INotifyPropertyChanged viewModel)
        : base(viewModel)
    {

    }

    public override async Task OnShown(params object[] args)
    {
        base.Show();

        if (DataContext is IWindowAware<A, TResult> wa)
        {
            await wa.OnShown(args[0]);
        }

        RaiseShown();
    }

    public async Task OnShown(A arg)
    {
        base.Show();

        if (DataContext is IWindowAware<A, TResult> wa)
        {
            await wa.OnShown(arg);
        }

        RaiseShown();
    }
}

public class BaseDialog<A1, A2, TResult>
    : BaseDialog<TResult>, IDialogWindow<A1, A2, TResult>
{
    public BaseDialog() { }

    public BaseDialog(INotifyPropertyChanged viewModel)
    {
        DataContext = viewModel;
    }

    public override async Task OnShown(params object[] args)
    {
        base.Show();

        if (DataContext is IWindowAware<A1, A2, TResult> wa)
        {
            await wa.OnShown(args[0], args[1]);
        }

        RaiseShown();
    }

    public async Task OnShown(A1 arg1, A2 arg2)
    {
        base.Show();

        if (DataContext is IDialogAware<A1, A2, TResult> wa)
        {
            await wa.OnShown(arg1, arg2);
        }

        RaiseShown();
    }
}

public class BaseDialog<A1, A2, A3, TResult>
    : BaseDialog<TResult>, IDialogWindow<A1, A2, A3, TResult>
{
    public BaseDialog() { }

    public BaseDialog(INotifyPropertyChanged viewModel)
    {
        DataContext = viewModel;
    }

    public override async Task OnShown(params object[] args)
    {
        base.Show();

        if (DataContext is IDialogAware<A1, A2, A3, TResult> wa)
        {
            await wa.OnShown(args[0], args[1], args[2]);
        }

        RaiseShown();
    }

    public async Task OnShown(A1 arg1, A2 arg2, A3 arg3)
    {
        base.Show();

        if (DataContext is IDialogAware<A1, A2, A3, TResult> wa)
        {
            await wa.OnShown(arg1, arg2, arg3);
        }

        RaiseShown();
    }
}
