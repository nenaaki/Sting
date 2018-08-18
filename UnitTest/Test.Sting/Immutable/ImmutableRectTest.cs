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