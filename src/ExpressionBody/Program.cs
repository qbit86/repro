using System;

namespace Repro
{
    internal readonly struct Empty : IEquatable<Empty>
    {
        public bool Equals(Empty other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            return obj is Empty other && Equals(other);
        }

        public override int GetHashCode()
        {
            return 1729;
        }

        public static bool operator ==(Empty left, Empty right) => left.Equals(right);

        public static bool operator !=(Empty left, Empty right)
        {
            return !left.Equals(right);
        }
    }

    internal static class Program
    {
        private static void Main()
        {
        }
    }
}
