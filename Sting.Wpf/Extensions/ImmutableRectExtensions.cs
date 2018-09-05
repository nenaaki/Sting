using System;

namespace Sting.Immutable
{
    public static class RectExtensions
    {
        public static Rect Inflate(in this Rect rect, double x, double y)
            => new Rect(rect.X - x, rect.Y - y, rect.Width + x * 2, rect.Height + y * 2);

        public static Rect Offset(in this Rect rect, double x, double y)
            => new Rect(rect.X + x, rect.Y + y, rect.Width, rect.Height);

        public static Rect ToRect(in this ValueTuple<Point, ImmutableSize> source)
            => new Rect(source.Item1.X, source.Item1.Y, source.Item2.Width, source.Item2.Width);
    }
}