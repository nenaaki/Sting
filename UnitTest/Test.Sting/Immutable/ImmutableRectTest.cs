using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sting
{
    [TestClass]
    public class ImmutableRectTest
    {
        [TestMethod]
        public void ImmutableRectBasicTest()
        {
            var rect = new ImmutableRect(1, 2, 3, 4);
            rect.X.Is(1);
            rect.Y.Is(2);
            rect.Width.Is(3);
            rect.Height.Is(4);

            ImmutableRect.Create(100, 200, double.NaN, double.NaN).Is(new ImmutableRect(100, 200, 0, 0));
            ImmutableRect.Create(101, 201, 10, 20).Is(new ImmutableRect(101, 201, 10, 20));

            var rect2 = new Rect(1000, 2000, 3000, 4000);
            ImmutableRect rect3 = rect2;
            rect3.X.Is(1000);
            rect3.Y.Is(2000);
            rect3.Width.Is(3000);
            rect3.Height.Is(4000);

            Rect rect4 = rect3;
            rect4.Is(rect2);
        }

        [TestMethod]
        public void ImmutableRectContainsTest()
        {
            var rect = new ImmutableRect(100, 200, 300, 400);

            rect.Contains(new ImmutablePoint(0, 0)).IsFalse();
            rect.Contains(new ImmutablePoint(99, 199)).IsFalse();
            rect.Contains(new ImmutablePoint(100, 200)).IsTrue();
            rect.Contains(new ImmutablePoint(300, 300)).IsTrue();
            rect.Contains(new ImmutablePoint(400, 600)).IsTrue();
            rect.Contains(new ImmutablePoint(401, 601)).IsFalse();

            rect.Contains(ImmutablePoint.Empty).IsFalse();
            rect.Contains(ImmutableRect.Empty).IsFalse();

            rect.Contains(new ImmutableRect(100, 200, 300, 400)).IsTrue();
            rect.Contains(new ImmutableRect(99, 200, 300, 400)).IsFalse();
        }
    }
}