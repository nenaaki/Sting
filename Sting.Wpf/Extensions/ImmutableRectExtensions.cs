using System;

namespace Sting
{
    public static class RectExtensions
    {
        public static Immutable.Rect Inflate(in this Immutable.Rect rect, double x, double y)
            => new Immutable.Rect(rect.X - x, rect.Y - y, rect.Width + x * 2, rect.Height + y * 2);

        public static Immutable.Rect Offset(in this Immutable.Rect rect, double x, double y)
            => new Immutable.Rect(rect.X + x, rect.Y + y, rect.Width, rect.Height);

        public static Immutable.Rect ToRect(in this ValueTuple<Immutable.Point, Immutable.Size> source)
            => new Immutable.Rect(source.Item1.X, source.Item1.Y, source.Item2.Width, source.Item2.Width);
    }
}