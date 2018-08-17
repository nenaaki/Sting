using System;
using System.Windows;
using Sting;
using Sting.Collection;
using BenchmarkDotNet.Attributes;

namespace Sting.Benchmark
{
    public class RefereneArrayBenchmark
    {
        private Rect[] _rects = new Rect[100];

        private double[] result = new double[10000];

        [Benchmark]
        public void UpdateRectRefArray()
        {
            for (int idx = 0; idx < _rects.Length; idx++)
            {
                _rects[idx] = new Rect(idx, idx, idx, idx);
            }

            foreach (ref var rect in _rects.AsRef())
            {
                rect.Offset(100, 100);
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
                _rects[idx].Offset(100, 100);
            }
        }

        [Benchmark]
        public void DoubleMaxLegacy()
        {
            for(int idx=0 ; idx<10000;idx++)
                result[idx] = Math.Max((double)(10000 - idx), (double)idx);
        }

        [Benchmark]
        public void DoubleMaxNew()
        {
            for(int idx=0 ; idx<10000;idx++)
                result[idx] = ((double)(10000 - idx), (double)idx).Max();
        }
    }
}