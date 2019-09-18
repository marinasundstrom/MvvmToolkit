using System;

namespace MvvmToolkit
{
    public interface IMessageBus
    {
        void Dispose();
        void Publish<T>(T instance);
        IObservable<T> WhenPublished<T>();
    }
}
