using System;
using System.Net.Http.Headers;

namespace Viking.Macross.Interface
{
    public interface IValueStream<TValue>
    {
        ValueStreamIdentitfier<TValue> Identifiers { get; }

        IValueStreamListenerToken AddListener(IValueStreamListener<TValue> listener);
        void RemoveListener(IValueStreamListenerToken listenerToken);
    }

    public interface IValueStreamListenerToken : IDisposable { }

    public interface IValueStreamListener<TValue>
    {
        void ValuesReceived(ReadOnlySpan<TValue> values);
        void StreamEnded();
        void ListenerRemoved();
    }

    public static class ValueStreamExtensions
    {
        public static TValue ReadCurrentValueFromStream<TValue>(this IValueStream<TValue> stream)
        {
            var listener = new ConstantValueStreamListener<TValue>();
            using var token = stream.AddListener(listener);
            return listener.Value;
        }

        public static IValueStreamListenerToken AddListener<TValue>(this IValueStream<TValue> stream, IValueListener<TValue> listener)
        {
            return stream.AddListener(new SingleValueListener<TValue>(listener));
        }
    }
}
