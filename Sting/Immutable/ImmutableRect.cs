using System;
using System.Windows;

namespace Sting
{
    public readonly struct ImmutableRect : IEquatable<ImmutableRect>
    {
        private const int PRIME_NUMBER = 357;

        public static readonly ImmutableRect Empty = new ImmutableRect(double.NaN, double.NaN, double.NegativeInfinity, double.NegativeInfinity);

        /// <summary>
        /// Xを保持します。
        /// </summary>
        public readonly double X;

        /// <summary>
        /// Yを保持します。
        /// </summary>
        public readonly double Y;

        /// <summary>
        /// Widthを保持します。
        /// </summary>
        public readonly double Width;

        /// <summary>
        /// Heightを保持します。
        /// </summary>
        public readonly double Height;

        public ImmutablePoint Location => new ImmutablePoint(X, Y);

        public ImmutableSize Size => new ImmutableSize(Width, Height);

        public double Left => X;

        public double Top => Y;

        public double Right => X + Width;

        public double Bottom => Y + Height;

        public ImmutablePoint LeftTop => Location;

        public ImmutablePoint Center => new ImmutablePoint(X + Width / 2, Y + Height / 2);

        public ImmutablePoint RightTop => new ImmutablePoint(Right, Y);

        public ImmutablePoint LeftBottom => new ImmutablePoint(X, Bottom);

        public ImmutablePoint RightBottom => new ImmutablePoint(Right, Bottom);

        public bool IsEmpty() => Width < 0 || Height < 0;

        public ImmutableRect(double x, double y, double width, double height) => (X, Y, Width, Height) = (x, y, width, height);

        public static implicit operator ImmutableRect(Rect source) => new ImmutableRect(source.X, source.Y, source.Width, source.Height);

        public static implicit operator Rect(in ImmutableRect source) => new Rect(source.X, source.Y, source.Width, source.Height);

        public static bool operator ==(in ImmutableRect source1, in ImmutableRect source2) => source1.X == source2.X && source1.Y == source2.Y && source1.Width == source2.Width && source1.Height == source2.Height;

        public static bool operator !=(in ImmutableRect source1, in ImmutableRect source2) => !(source1 == source2);

        public bool Equals(ImmutableRect other) => this == other;

        public override bool Equals(object obj)
        {
            if (obj is ImmutableRect other)
            {
                return this == other;
            }
            return false;
        }

        public override int GetHashCode() => X.GetHashCode() ^ ~Y.GetHashCode() ^ Width.GetHashCode() * PRIME_NUMBER ^ ~Height.GetHashCode() * PRIME_NUMBER;

        /// <summary>
        /// 点が内包されるかを確認します
        /// </summary>
        /// <param name="point">Pointの値</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified point]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(in ImmutablePoint point)
        {
            var x = point.X - X;
            var y = point.Y - Y;

            return 0 <= x && x <= Width && 0 <= y && y <= Height;
        }

        /// <summary>
        /// 対象の矩形が内包されているかを確認します。
        /// </summary>
        /// <param name="rect">Rectの値</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified rect]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(in ImmutableRect rect) => Contains(rect.Location) && Contains(rect.RightBottom);

        /// <summary>
        /// 空ではない<see cref="ImmutableRect"/>を作成します。
        /// </summary>
        /// <param name="x">xの値</param>
        /// <param name="y">yの値</param>
        /// <param name="width">Widthの値</param>
        /// <param name="height">Heightの値</param>
        /// <returns>新しい<see cref="ImmutableRect"/></returns>
        public ImmutableRect Create(double x, double y, double width, Double height) => new ImmutableRect(x, y, width.ZeroOrMore(), height.ZeroOrMore());
    }
}