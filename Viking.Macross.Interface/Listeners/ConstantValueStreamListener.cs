using System;
using System.Diagnostics;

namespace Viking.Macross.Interface
{
    internal class ConstantValueStreamListener<TValue> : IValueStreamListener<TValue>
    {
        private TValue _value;
        public TValue Value => HasReading ? throw new InvalidOperationException("No value in stream") : _value;
        private bool HasReading { get; set; }

        public void ListenerRemoved() { }
        public void StreamEnded() { }
        public void ValuesReceived(ReadOnlySpan<TValue> values)
        {
            Debug.Assert(values.Length == 1);
            Debug.Assert(!HasReading);

            _value = values[0];
            HasReading = true;
        }
    }
}
