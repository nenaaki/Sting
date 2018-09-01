using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sting
{
    [TestClass]
    public class CollectionTest
    {
        private class RectGenerator : IEnumerable<Immutable.Rect>
        {
            public IEnumerator<Immutable.Rect> GetEnumerator()
            {
                for (int idx = 0; idx < 1000; idx++)
                {
                    yield return new Immutable.Rect(idx, idx, idx, idx);
                }
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        private readonly ImmutablePoint[] _points = new ImmutablePoint[1000];

        [TestMethod]
        public void AddAndGetRectRefList()
        {
            var items = new RectGenerator().ToReferenceList().ToArray().AsRef();

            int idx = 0;
            foreach (ref var rect in items)
            {
                _points[idx++] = rect.Center + new ImmutableVector(100, 100);
            }
        }
    }
}