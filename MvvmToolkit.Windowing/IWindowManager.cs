using System.Threading.Tasks;

namespace MvvmToolkit.Windowing
{
    public interface IWindowManager
    {
        Task<TResult> ShowDialogAsync<TResult>(string window, params object[] args);

        Task<TResult> ShowDialogAsync<A, TResult>(string window, A arg);

        Task<TResult> ShowDialogAsync<A1, A2, TResult>(string window, A1 arg1, A2 arg2);

        Task<TResult> ShowDialogAsync<A1, A2, A3, TResult>(string window, A1 arg1, A2 arg2, A3 arg3);

        Task ShowWindowAsync(string window, params object[] args);

        Task ShowWindowAsync<A>(string window, A arg);

        Task ShowWindowAsync<A1, A2>(string window, A1 arg1, A2 arg2);

        Task ShowWindowAsync<A1, A2, A3>(string window, A1 arg1, A2 arg2, A3 arg3);
    }
}
