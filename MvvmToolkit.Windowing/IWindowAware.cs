using System.Threading.Tasks;

namespace MvvmToolkit.Windowing
{
    public interface IWindowAware
    {
        Task OnShown(params object[] args);

        Task OnClosed();
    }

    public interface IWindowAware<A> : IWindowAware
    {
        Task OnShown(A arg);
    }

    public interface IWindowAware<A1, A2> : IWindowAware
    {
        Task OnShown(A1 arg1, A1 arg2);
    }

    public interface IDialogAware<TResult> : IWindowAware
    {
        new Task<TResult> OnClosed();
    }

    public interface IDialogAware<A, TResult> : IWindowAware
    {
        Task OnShown(A arg);
    }

    public interface IDialogAware<A1, A2, TResult> : IWindowAware
    {
        Task OnShown(A1 arg1, A1 arg2);
    }

    public interface IWindowAware<A1, A2, A3> : IWindowAware
    {
        Task OnShown(A1 arg1, A1 arg2, A3 arg3);
    }

    public interface IDialogAware<A1, A2, A3, TResult> : IWindowAware
    {
        Task OnShown(A1 arg1, A1 arg2, A3 arg3);

        new Task<TResult> OnClosed();
    }


}
