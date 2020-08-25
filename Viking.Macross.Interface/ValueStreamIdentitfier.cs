using System;

namespace Viking.Macross.Interface
{
    public struct ValueStreamIdentitfier<TValue> : IEquatable<ValueStreamIdentitfier<TValue>>
    {
        public ValueStreamIdentitfier(Identifier identifier)
        {
            Identifier = identifier;
        }

        public Identifier Identifier { get; }

        public override bool Equals(object obj) => obj is ValueStreamIdentitfier<TValue> identitfier && Equals(identitfier);
        public bool Equals(ValueStreamIdentitfier<TValue> other) => Identifier.Equals(other.Identifier);

        public override int GetHashCode() => 1186239758 + Identifier.GetHashCode();

        public static bool operator ==(ValueStreamIdentitfier<TValue> left, ValueStreamIdentitfier<TValue> right) => left.Equals(right);
        public static bool operator !=(ValueStreamIdentitfier<TValue> left, ValueStreamIdentitfier<TValue> right) => !(left == right);

        public static implicit operator ValueStreamIdentitfier<TValue>(Identifier identifier) => new ValueStreamIdentitfier<TValue>(identifier);
        public static implicit operator Identifier(ValueStreamIdentitfier<TValue> identifier) => identifier.Identifier;

        public override string ToString() => $"Stream ID '{Identifier}' ({typeof(TValue).Name})";
    }
}
