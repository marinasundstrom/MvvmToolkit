using System;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MvvmToolkit
{
    public class ThreadDispatcher : IThreadDispatcher
    {
        private readonly Dispatcher dispatcher;

        public ThreadDispatcher()
        {
            dispatcher = Dispatcher.CurrentDispatcher;
        }

        public void RunOnMainThread(Action action)
        {
            dispatcher.Invoke(action);
        }

        public async Task RunOnMainThreadAsync(Func<Task> action)
        {
            await dispatcher.InvokeAsync(action);
        }
    }
}
