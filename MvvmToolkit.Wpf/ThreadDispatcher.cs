using System;
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
            dispatcher.BeginInvoke(action);
        }
    }
}
