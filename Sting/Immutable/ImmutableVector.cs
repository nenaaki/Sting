using System;
using System.Windows;

namespace Sting
{
    public readonly struct ImmutableVector : IEquatable<ImmutableVector>
    {
        public static readonly ImmutableVector Empty = new ImmutableVector(double.NaN, double.NaN);

        public readonly double X;

        public readonly double Y;

        public ImmutableVector(double x, double y) => (X, Y) = (x, y);

        public bool Equals(ImmutableVector other) => X == other.X && Y == other.Y;

        public bool IsEmpty() => Empty == this;

        public override bool Equals(object obj)
        {
            if (obj is ImmutableVector other)
            {
                return this == other;
            }
            return false;
        }

        public override int GetHashCode() => X.GetHashCode() ^ ~Y.GetHashCode();

        public static implicit operator Vector(in ImmutableVector source) => new Vector(source.X, source.Y);

        public static implicit operator ImmutableVector(Vector source) => new ImmutableVector(source.X, source.Y);

        public static bool operator ==(in ImmutableVector source1, in ImmutableVector source2) => source1.X == source2.X && source1.Y == source2.Y;

        public static bool operator !=(in ImmutableVector source1, in ImmutableVector source2) => !(source1 == source2);

        public double Length => Math.Sqrt(LengthSquared);

        public double LengthSquared => X * X + Y * Y;
    }
}