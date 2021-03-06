﻿using System;

namespace Sting.Immutable
{
    public readonly struct Rect : IEquatable<Rect>
    {
        private const int PRIME_NUMBER = 357;

        public static readonly Rect Empty = new Rect(double.NaN, double.NaN, double.NegativeInfinity, double.NegativeInfinity);

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

        public Point Location => new Point(X, Y);

        public Size Size => new Size(Width, Height);

        public double Left => X;

        public double Top => Y;

        public double Right => X + Width;

        public double Bottom => Y + Height;

        public Point LeftTop => Location;

        public Point Center => new Point(X + Width / 2, Y + Height / 2);

        public Point RightTop => new Point(Right, Y);

        public Point LeftBottom => new Point(X, Bottom);

        public Point RightBottom => new Point(Right, Bottom);

        public bool IsEmpty => Width < 0 || Height < 0;

        public Rect(double x, double y, double width, double height) => (X, Y, Width, Height) = (x, y, width, height);

        public Rect(in Point point, in Size size) => (X, Y, Width, Height) = (point.X, point.Y, size.Width, size.Height);

        public static implicit operator Rect(System.Windows.Rect source) => new Rect(source.X, source.Y, source.Width, source.Height);

        public static implicit operator System.Windows.Rect(in Rect source) => new System.Windows.Rect(source.X, source.Y, source.Width, source.Height);

        public static bool operator ==(in Rect source1, in Rect source2) => source1.X == source2.X && source1.Y == source2.Y && source1.Width == source2.Width && source1.Height == source2.Height;

        public static bool operator !=(in Rect source1, in Rect source2) => !(source1 == source2);

        public bool Equals(Rect other) => this == other;

        public override bool Equals(object obj) => obj is Rect other && this == other;

        public override int GetHashCode() => X.GetHashCode() ^ ~Y.GetHashCode() ^ Width.GetHashCode() * PRIME_NUMBER ^ ~Height.GetHashCode() * PRIME_NUMBER;

        /// <summary>
        /// 点が内包されるかを確認します
        /// </summary>
        /// <param name="point">Pointの値</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified point]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(in Point point)
        {
            if (IsEmpty)
            {
                return false;
            }

            double x = point.X - X;
            double y = point.Y - Y;

            return 0 <= x && x <= Width && 0 <= y && y <= Height;
        }

        /// <summary>
        /// 対象の矩形が内包されているかを確認します。
        /// </summary>
        /// <param name="rect">Rectの値</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified rect]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(in Rect rect)
        {
            return Width >= 0 && Height >= 0 // !IsEmpty
                && rect.Width >= 0 && rect.Height >= 0 // !rect.IsEmpty
                && X <= rect.X
                && Y <= rect.Y
                && X + Width >= rect.X + rect.Width
                && Y + Height >= rect.Y + rect.Height;
        }

        /// <summary>
        /// 交差しているかを確認します。
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <param name="rect">交差判定を行う<see cref="Rect"/></param>
        /// <returns>交差している場合 true を返します。</returns>
        public bool IntersectsWith(in Rect rect)
        {
            return Width >= 0 && Height >= 0 // !IsEmpty
                && rect.Width >= 0 && rect.Height >= 0 // !rect.IsEmpty
                && rect.X <= X + Width
                && rect.X + rect.Width >= X
                && rect.Y <= Y + Height
                && rect.Y + rect.Height >= Y;
        }

        /// <summary>
        /// 空ではない<see cref="Rect"/>を作成します。
        /// </summary>
        /// <param name="x">xの値</param>
        /// <param name="y">yの値</param>
        /// <param name="width">Widthの値</param>
        /// <param name="height">Heightの値</param>
        /// <returns>新しい<see cref="Rect"/></returns>
        public static Rect Create(double x, double y, double width, double height) => new Rect(x, y, width.ZeroOrMore(), height.ZeroOrMore());
    }
}