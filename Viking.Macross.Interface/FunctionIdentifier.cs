using System;

namespace Viking.Macross.Interface
{
    public struct FunctionIdentifier<TParameter, TResult> : IEquatable<FunctionIdentifier<TParameter, TResult>>
    {
        public FunctionIdentifier(Identifier identifier)
        {
            Identifier = identifier;
        }

        public Identifier Identifier { get; }

        public override bool Equals(object obj) => obj is FunctionIdentifier<TParameter, TResult> identifier && Equals(identifier);
        public bool Equals(FunctionIdentifier<TParameter, TResult> other) => Identifier.Equals(other.Identifier);

        public override int GetHashCode() => Identifier.GetHashCode();

        public static bool operator ==(FunctionIdentifier<TParameter, TResult> left, FunctionIdentifier<TParameter, TResult> right) => left.Equals(right);
        public static bool operator !=(FunctionIdentifier<TParameter, TResult> left, FunctionIdentifier<TParameter, TResult> right) => !(left == right);

        public static implicit operator FunctionIdentifier<TParameter, TResult>(Identifier identifier) => new FunctionIdentifier<TParameter, TResult>(identifier);
        public static implicit operator Identifier(FunctionIdentifier<TParameter, TResult> identifier) => identifier.Identifier;

        public override string ToString() => $"Function ID '{Identifier}' ({typeof(TParameter).Name} => {typeof(TResult).Name})";
    }
}
