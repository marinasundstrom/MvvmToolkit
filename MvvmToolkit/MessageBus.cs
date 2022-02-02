using System;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace MvvmToolkit
{
    public sealed class MessageBus : IMessageBus
    {
        private readonly Subject<object> _subject;
        private static IMessageBus _instance;

        public MessageBus()
        {
            _subject = new Subject<object>();
        }

        public void Publish<T>(T instance)
        {
            _subject.OnNext(instance);
        }

        public IObservable<T> WhenPublished<T>()
        {
            return _subject.OfType<T>().AsObservable();
        }

        public void Dispose()
        {
            _subject.Dispose();
        }

        public static IMessageBus Instance => _instance ?? (_instance = new MessageBus());
    }
}