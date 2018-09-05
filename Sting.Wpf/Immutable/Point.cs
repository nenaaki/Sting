using System;

namespace Sting.Immutable
{
    /// <summary>
    /// ImmutablePoint構造体です。
    /// </summary>
    /// <seealso cref="System.IEquatable{Sting.ImmutablePoint}" />
    public readonly struct Point : IEquatable<Point>
    {
        /// <summary>
        /// Emptyを保持します。
        /// </summary>
        public static readonly Point Empty = new Point(double.NaN, double.NaN);

        /// <summary>
        /// デフォルト値を保持します。
        /// </summary>
        /// <remarks>
        /// <see langword="default"/>より速いときが稀にあるため。
        /// </remarks>
        public static readonly Point Zero;

        /// <summary>
        /// Xを保持します。
        /// </summary>
        public readonly double X;

        /// <summary>
        /// Yを保持します。
        /// </summary>
        public readonly double Y;

        public Point(double x, double y) => (X, Y) = (x, y);

        public bool Equals(Point other) => X == other.X && Y == other.Y;

        public bool IsEmpty() => double.IsNaN(X) || double.IsNaN(Y);

        public override bool Equals(object obj)
        {
            if (obj is Point other)
            {
                return this == other;
            }
            return false;
        }

        public override int GetHashCode() => X.GetHashCode() ^ ~Y.GetHashCode();

        public static implicit operator System.Windows.Point(in Point source) => new System.Windows.Point(source.X, source.Y);

        public static implicit operator Point(System.Windows.Point source) => new Point(source.X, source.Y);

        public static explicit operator Vector(in Point source) => new Vector(source.X, source.Y);

        public static bool operator ==(in Point source1, in Point source2) => source1.X == source2.X && source1.Y == source2.Y;

        public static bool operator !=(in Point source1, in Point source2) => !(source1 == source2);

        public static Vector operator -(in Point source, in Point other) => new Vector(source.X - other.X, source.Y - other.Y);

        public static Point operator +(in Point source, in Vector other) => new Point(source.X + other.X, source.Y + other.Y);

        /// <summary>
        /// 2点間の距離を計算します。
        /// </summary>
        public static double CalcDistance(Point p1, Point p2)
        {
            return (p1 - p2).Length;
        }

        /// <summary>
        /// 2点間の距離の2乗を計算します。
        /// </summary>
        /// <remarks>単純な距離の比較はCalcDistanceよりもこちらが高速です。</remarks>
        public static double CalcDistanceSquare(Point p1, Point p2)
        {
            return (p1 - p2).LengthSquared;
        }
    }
}