namespace Sting
{
    public static class ImmutableVectorExtensions
    {
        public static ImmutableVector Normalize(in this ImmutableVector vector) => vector / vector.Length;

        public static double DotProduct(in this ImmutableVector vector1, in ImmutableVector vector2) => vector1.X * vector2.X + vector1.Y * vector2.Y;

        public static double CrossProduct(in this ImmutableVector vector1, in ImmutableVector vector2) => vector1.X * vector2.Y - vector1.Y * vector2.X;

        public static ImmutableVector Negate(in this ImmutableVector vector) => new ImmutableVector(-vector.X, -vector.Y);
    }
}