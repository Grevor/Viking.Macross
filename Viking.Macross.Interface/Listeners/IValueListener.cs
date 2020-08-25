using System;
using System.Diagnostics;

namespace Viking.Macross.Interface
{
    public interface IValueListener<TValue>
    {
        void ValueChanged(TValue value);
        void StreamEnded();
        void ListenerRemoved();
    }

    internal sealed class SingleValueListener<TValue> : IValueStreamListener<TValue>
    {
        public SingleValueListener(IValueListener<TValue> listener)
        {
            Listener = listener ?? throw new ArgumentNullException(nameof(listener));
        }

        public IValueListener<TValue> Listener { get; }

        public void ListenerRemoved() => Listener.ListenerRemoved();

        public void StreamEnded() => Listener.StreamEnded();

        public void ValuesReceived(ReadOnlySpan<TValue> values)
        {
            foreach (var value in values)
                Listener.ValueChanged(value);
        }
    }
}
