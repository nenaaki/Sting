namespace Sting
{
    public static class ImmutableVectorExtensions
    {
        public static Immutable.Vector Normalize(in this Immutable.Vector vector) => vector / vector.Length;

        public static double DotProduct(in this Immutable.Vector vector1, in Immutable.Vector vector2) => vector1.X * vector2.X + vector1.Y * vector2.Y;

        public static double CrossProduct(in this Immutable.Vector vector1, in Immutable.Vector vector2) => vector1.X * vector2.Y - vector1.Y * vector2.X;

        public static Immutable.Vector Negate(in this Immutable.Vector vector) => new Immutable.Vector(-vector.X, -vector.Y);
    }
}