using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sting
{
    [TestClass]
    public class ImmutableVectorTest
    {
        [TestMethod]
        public void ImmutableVectorLengthTest()
        {
            var vector = new ImmutableVector(3, 4);

            vector.X.Is(3);
            vector.Y.Is(4);
            vector.Length.Is(5);
            vector.LengthSquared.Is(25);
        }
    }
}