using System;

namespace MvvmToolkit
{
    public interface IThreadDispatcher
    {
        void RunOnMainThread(Action action);
    }
}
