using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace MvvmToolkit.Windowing
{
    public class WindowManager : IWindowManager
    {
        private readonly IServiceProvider serviceProvider;

        public WindowManager(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task<TResult> ShowDialogAsync<TResult>(string window, params object[] args)
        {
            var taskCompletionSource = new TaskCompletionSource<TResult>();

            Type windowType = Assembly.GetEntryAssembly()
                    .GetTypes()
                    .Single(t => t.Name.Contains(window));

            var windowInstance = (IDialogWindow<TResult>)serviceProvider.GetService(windowType);

            (windowInstance as Window).Closed += async (s, e) =>
            {
                TResult result = await windowInstance.OnClosed();
                taskCompletionSource.SetResult(result);
            };
            await windowInstance.OnShown(args);

            return await taskCompletionSource.Task;
        }

        public Task<TResult> ShowDialogAsync<A, TResult>(string window, A arg)
        {
            return ShowDialogAsync<TResult>(window, new[] { arg });
        }

        public Task<TResult> ShowDialogAsync<A1, A2, TResult>(string window, A1 arg1, A2 arg2)
        {
            return ShowDialogAsync<TResult>(window, arg1, arg2);
        }

        public Task<TResult> ShowDialogAsync<A1, A2, A3, TResult>(string window, A1 arg1, A2 arg2, A3 arg3)
        {
            return ShowDialogAsync<TResult>(window, arg1, arg2, arg3);
        }

        public async Task ShowWindowAsync(string window, params object[] args)
        {
            var taskCompletionSource = new TaskCompletionSource<object>();

            Type windowType = Assembly.GetEntryAssembly()
                    .GetTypes()
                    .Single(t => t.Name.Contains(window));

            var windowInstance = (IWindow)serviceProvider.GetService(windowType);

            (windowInstance as Window).Closed += async (s, e) =>
            {
                await windowInstance.OnClosed();
                taskCompletionSource.SetResult(null);
            };
            await windowInstance.OnShown(args);

            await taskCompletionSource.Task;
        }

        public Task ShowWindowAsync<A>(string window, A arg)
        {
            return ShowWindowAsync(window, new object[] { arg });
        }

        public Task ShowWindowAsync<A1, A2>(string window, A1 arg1, A2 arg2)
        {
            return ShowWindowAsync(window, arg1, arg2);
        }

        public Task ShowWindowAsync<A1, A2, A3>(string window, A1 arg1, A2 arg2, A3 arg3)
        {
            return ShowWindowAsync(window, arg1, arg2, arg3);
        }
    }
}
