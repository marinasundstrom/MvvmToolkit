using System;
using System.Threading.Tasks;

namespace MvvmToolkit.Windowing
{
    public interface IWindow
    {
        Task OnShown(params object[] args);

        Task OnClosed();

        event EventHandler Shown;
        event EventHandler Closed;
    }

    public interface IWindow<A> : IWindow
    {
        Task OnShown(A arg1);
    }

    public interface IWindow<A1, A2> : IWindow
    {
        Task OnShown(A1 arg1, A2 arg2);
    }

    public interface IWindow<A1, A2, A3> : IWindow
    {
        Task OnShown(A1 arg1, A2 arg2, A3 arg3);
    }

    public interface IDialogWindow<TReturn> : IWindow
    {
        Task OnShown();

        new Task<TReturn> OnClosed();
    }

    public interface IDialogWindow<A, TReturn> : IWindow
    {
        Task OnShown(A arg1);

        new Task<TReturn> OnClosed();
    }

    public interface IDialogWindow<A1, A2, TReturn> : IWindow
    {
        Task OnShown(A1 arg1, A2 arg2);

        new Task<TReturn> OnClosed();
    }

    public interface IDialogWindow<A1, A2, A3, TReturn> : IWindow
    {
        Task OnShown(A1 arg1, A2 arg2, A3 arg3);

        new Task<TReturn> OnClosed();
    }
}
