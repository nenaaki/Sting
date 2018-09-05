using System;

namespace Sting.Extensions
{
    public static class ImmutablePointExtensions
    {
        public static Immutable.Point Offset(in this Immutable.Point point, double x, double y)
            => new Immutable.Point(point.X + x, point.Y + y);

        public static Immutable.Point Round(in this Immutable.Point point)
            => new Immutable.Point(Math.Round(point.X), Math.Round(point.Y));
    }
}