using System;

namespace Sting
{
    public static class MathExtensions
    {
        public static double ZeroOrLess(this double value) => value < 0.0 ? value : 0.0;

        public static double ZeroOrMore(this double value) => value > 0.0 ? value : 0.0;

        public static double Max(in this ValueTuple<double, double> value) => value.Item1 > value.Item2 || double.IsNaN(value.Item1) ? value.Item1 : value.Item2;

        public static double Min(in this ValueTuple<double, double> value) => value.Item1 < value.Item2 || double.IsNaN(value.Item1) ? value.Item1 : value.Item2;

        public static float ZeroOrLess(this float value) => value < 0.0f ? value : 0.0f;

        public static float ZeroOrMore(this float value) => value > 0.0f ? value : 0.0f;

        public static float Max(in this ValueTuple<float, float> value) => value.Item1 > value.Item2 || float.IsNaN(value.Item1) ? value.Item1 : value.Item2;

        public static float Min(in this ValueTuple<float, float> value) => value.Item1 < value.Item2 || float.IsNaN(value.Item1) ? value.Item1 : value.Item2;
    }
}