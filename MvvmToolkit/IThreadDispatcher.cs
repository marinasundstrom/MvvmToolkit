using System;
using System.Threading.Tasks;

namespace MvvmToolkit
{
    public interface IThreadDispatcher
    {
        void RunOnMainThread(Action action);

        Task RunOnMainThreadAsync(Func<Task> action);
    }
}
