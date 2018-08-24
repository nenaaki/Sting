using System;

namespace Sting
{
    public static class ImmutableRectExtensions
    {
        public static ImmutableRect Inflate(in this ImmutableRect rect, double x, double y)
            => new ImmutableRect(rect.X - x, rect.Y - y, rect.Width + x * 2, rect.Height + y * 2);

        public static ImmutableRect Offset(in this ImmutableRect rect, double x, double y)
            => new ImmutableRect(rect.X + x, rect.Y + y, rect.Width, rect.Height);

        public static ImmutableRect ToRect(in this ValueTuple<ImmutablePoint, ImmutableSize> source)
            => new ImmutableRect(source.Item1.X, source.Item1.Y, source.Item2.Width, source.Item2.Width);
    }
}