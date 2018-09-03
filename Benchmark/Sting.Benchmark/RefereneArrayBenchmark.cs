using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using BenchmarkDotNet.Attributes;

namespace Sting.Benchmark
{
    public class RefereneArrayBenchmark
    {
        private readonly Rect[] _rects = new Rect[1000];
#if false

        private readonly double[] result = new double[10000];

        [Benchmark]
        public void UpdateRectRefArray()
        {
            for (int idx = 0; idx < _rects.Length; idx++)
            {
                _rects[idx] = new Rect(idx, idx, idx, idx);
            }

            foreach (ref var rect in _rects.AsRef())
            {
                rect.Offset(1000, 1000);
            }
        }

        [Benchmark]
        public void UpdateRectArray()
        {
            for (int idx = 0; idx < _rects.Length; idx++)
            {
                _rects[idx] = new Rect(idx, idx, idx, idx);
            }

            for (int idx = 0; idx < _rects.Length; idx++)
            {
                _rects[idx].Offset(1000, 1000);
            }
        }

        [Benchmark]
        public void DoubleMaxLegacy()
        {
            for (int idx = 0; idx < 10000; idx++)
                result[idx] = Math.Max(10000 - idx, (double)idx);
        }

        [Benchmark]
        public void DoubleMaxNew()
        {
            for (int idx = 0; idx < 10000; idx++)
                result[idx] = ((double)(10000 - idx), (double)idx).Max();
        }

#endif

#if true

        private class GuidGenerator : IEnumerable<Immutable.Guid>
        {
            private readonly System.Guid[] _guids = new System.Guid[10000];

            public GuidGenerator()
            {
                for (int idx = 0; idx < _guids.Length; idx++)
                {
                    _guids[idx] = System.Guid.NewGuid();
                }
            }

            public IEnumerator<Immutable.Guid> GetEnumerator()
            {
                for (int idx = 0; idx < _guids.Length; idx++)
                {
                    yield return new Immutable.Guid(_guids[idx]);
                }
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        private readonly GuidGenerator _guids = new GuidGenerator();

        private readonly int[] _hashcodes = new int[10000];

        [Benchmark]
        public void ToRefArray()
        {
            var items = _guids.ToRefArray();

            int idx = 0;
            foreach (ref var guid in items)
            {
                _hashcodes[idx++] = guid.GetHashCode();
            }
        }

        [Benchmark]
        public void ToRefList()
        {
            var items = _guids.ToReferenceList();

            int idx = 0;
            foreach (ref var guid in items)
            {
                _hashcodes[idx++] = guid.GetHashCode();
            }
        }

        [Benchmark]
        public void ToArray()
        {
            var items = _guids.ToArray();

            int idx = 0;
            foreach (var guid in items)
            {
                _hashcodes[idx++] = guid.GetHashCode();
            }
        }

        [Benchmark]
        public void ToList()
        {
            var items = _guids.ToList();

            int idx = 0;
            foreach (var guid in items)
            {
                _hashcodes[idx++] = guid.GetHashCode();
            }
        }

#endif
    }
}