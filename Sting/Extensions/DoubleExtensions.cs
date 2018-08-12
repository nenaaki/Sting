namespace Sting
{
    public static class DoubleExtensions
    {
        public static double ZeroOrMore(this double value) => value > 0.0 ? value : 0.0;
    }
}