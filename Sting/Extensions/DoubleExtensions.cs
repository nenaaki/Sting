using System;

namespace Sting
{
    public static class DoubleExtensions
    {
        public static double ZeroOrLess(this double value) => value < 0.0 ? value : 0.0;

        public static double ZeroOrMore(this double value) => value > 0.0 ? value : 0.0;

        public static double Max(in this ValueTuple<double, double> value)
        {
            return value.Item1 > value.Item2 || double.IsNaN(value.Item1) ? value.Item1 : value.Item2;
        }

        public static double Min(in this ValueTuple<double, double> value)
        {
            return value.Item1 < value.Item2 || double.IsNaN(value.Item1) ? value.Item1 : value.Item2;
        }
    }
}