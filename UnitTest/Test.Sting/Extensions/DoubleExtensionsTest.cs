using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sting
{
    [TestClass]
    public class DoubleExtensionsTest
    {
        [TestMethod]
        public void DoubleExtensionsMaxTest()
        {
            (0.0, 0.0).Max().Is(0.0);
            (0.0, 1.0).Max().Is(1.0);
            (1.0, 0.0).Max().Is(1.0);
            (double.NaN, 1.0).Max().Is(double.NaN);
            (1.0, double.NaN).Max().Is(double.NaN);
        }

        [TestMethod]
        public void DoubleExtensionsMinTest()
        {
            (0.0, 0.0).Min().Is(0.0);
            (0.0, 1.0).Min().Is(0.0);
            (1.0, 0.0).Min().Is(0.0);
            (double.NaN, 1.0).Min().Is(double.NaN);
            (1.0, double.NaN).Min().Is(double.NaN);
        }
    }
}