using System;
using System.Windows;

namespace Sting
{
    /// <summary>
    /// ImmutablePoint構造体です。
    /// </summary>
    /// <seealso cref="System.IEquatable{Sting.ImmutablePoint}" />
    public readonly struct ImmutablePoint : IEquatable<ImmutablePoint>
    {
        /// <summary>
        /// Emptyを保持します。
        /// </summary>
        public static readonly ImmutablePoint Empty = new ImmutablePoint(double.NaN, double.NaN);

        /// <summary>
        /// デフォルト値を保持します。
        /// </summary>
        /// <remarks>
        /// <see langword="default"/>より速いときが稀にあるため。
        /// </remarks>
        public static readonly ImmutablePoint Zero;

        /// <summary>
        /// Xを保持します。
        /// </summary>
        public readonly double X;

        /// <summary>
        /// Yを保持します。
        /// </summary>
        public readonly double Y;

        public ImmutablePoint(double x, double y) => (X, Y) = (x, y);

        public bool Equals(ImmutablePoint other) => X == other.X && Y == other.Y;

        public bool IsEmpty() => double.IsNaN(X) || double.IsNaN(Y);

        public override bool Equals(object obj)
        {
            if (obj is ImmutablePoint other)
            {
                return this == other;
            }
            return false;
        }

        public override int GetHashCode() => X.GetHashCode() ^ ~Y.GetHashCode();

        public static implicit operator Point(in ImmutablePoint source) => new Point(source.X, source.Y);

        public static implicit operator ImmutablePoint(Point source) => new ImmutablePoint(source.X, source.Y);

        public static explicit operator ImmutableVector(in ImmutablePoint source) => new ImmutableVector(source.X, source.Y);

        public static bool operator ==(in ImmutablePoint source1, in ImmutablePoint source2) => source1.X == source2.X && source1.Y == source2.Y;

        public static bool operator !=(in ImmutablePoint source1, in ImmutablePoint source2) => !(source1 == source2);

        public static ImmutableVector operator -(in ImmutablePoint source, in ImmutablePoint other) => new ImmutableVector(source.X - other.X, source.Y - other.Y);

        public static ImmutablePoint operator +(in ImmutablePoint source, in ImmutableVector other) => new ImmutablePoint(source.X + other.X, source.Y + other.Y);

        /// <summary>
        /// 2点間の距離を計算します。
        /// </summary>
        public static double CalcDistance(ImmutablePoint p1, ImmutablePoint p2)
        {
            return (p1 - p2).Length;
        }

        /// <summary>
        /// 2点間の距離の2乗を計算します。
        /// </summary>
        /// <remarks>単純な距離の比較はCalcDistanceよりもこちらが高速です。</remarks>
        public static double CalcDistanceSquare(ImmutablePoint p1, ImmutablePoint p2)
        {
            return (p1 - p2).LengthSquared;
        }
    }
}