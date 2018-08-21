namespace Sting
{
    public static class ImmutableVectorExtensions
    {
        public static ImmutableVector Normalize(in this ImmutableVector vector) => vector / vector.Length;
    }
}