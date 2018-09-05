using System;

namespace Sting.Immutable
{
    public readonly struct Vector : IEquatable<Vector>
    {
        public static readonly Vector Empty = new Vector(double.NaN, double.NaN);

        public readonly double X;

        public readonly double Y;

        public Vector(double x, double y) => (X, Y) = (x, y);

        public bool Equals(Vector other) => X == other.X && Y == other.Y;

        public bool IsEmpty() => Empty == this;

        public override bool Equals(object obj)
        {
            if (obj is Vector other)
            {
                return this == other;
            }
            return false;
        }

        public override int GetHashCode() => X.GetHashCode() ^ ~Y.GetHashCode();

        public static implicit operator System.Windows.Vector(in Vector source) => new System.Windows.Vector(source.X, source.Y);

        public static implicit operator Vector(System.Windows.Vector source) => new Vector(source.X, source.Y);

        public static explicit operator Point(Vector source) => new Point(source.X, source.Y);

        public static explicit operator Vector(Point source) => new Vector(source.X, source.Y);

        public static bool operator ==(in Vector source1, in Vector source2) => source1.X == source2.X && source1.Y == source2.Y;

        public static bool operator !=(in Vector source1, in Vector source2) => !(source1 == source2);

        public static Vector operator +(in Vector source1, in Vector source2) => new Vector(source1.X + source2.X, source1.Y + source2.Y);

        public static Vector operator -(in Vector source1, in Vector source2) => new Vector(source1.X - source2.X, source1.Y - source2.Y);

        public static Vector operator *(in Vector source1, double source2) => new Vector(source1.X * source2, source1.Y * source2);

        public static Vector operator /(in Vector source1, double source2) => new Vector(source1.X / source2, source1.Y / source2);

        public double Length => Math.Sqrt(X * X + Y * Y);

        public double LengthSquared => X * X + Y * Y;
    }
}