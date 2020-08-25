using System;
using System.Collections.Generic;

namespace Viking.Macross.Interface
{
    public readonly struct Identifier : IEquatable<Identifier>
    {
        public Identifier(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public string Name { get; }

        public override bool Equals(object obj) => obj is Identifier identifier && Equals(identifier);
        public bool Equals(Identifier other) => Name == other.Name;

        public override int GetHashCode() => EqualityComparer<string>.Default.GetHashCode(Name);

        public static bool operator ==(Identifier left, Identifier right) => left.Equals(right);
        public static bool operator !=(Identifier left, Identifier right) => !(left == right);

        public static implicit operator Identifier(string name)=> new Identifier(name);

        public override string ToString() => Name;
    }
}
