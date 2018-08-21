using System;

namespace Sting.Extensions
{
    public static class ImmutablePointExtensions
    {
        public static ImmutablePoint Offset(in this ImmutablePoint point, double x, double y)
            => new ImmutablePoint(point.X + x, point.Y + y);

        public static ImmutablePoint Round(in this ImmutablePoint point)
            => new ImmutablePoint(Math.Round(point.X), Math.Round(point.Y));
    }
}