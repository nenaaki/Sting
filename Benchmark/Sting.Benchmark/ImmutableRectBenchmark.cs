using System;
using BenchmarkDotNet.Attributes;

namespace Sting
{
    public class RectBenchmark
    {
#if PARAM_BENCHMARK
        using System.Windows;

        private readonly Immutable.Rect[] _Immutable.Rects = new Immutable.Rect[10000];

        private readonly Rect[] _rects = new Rect[10000];

        private readonly ImmutablePoint[] _immutablePoints = new ImmutablePoint[10000];

        private readonly Point[] _points = new Point[10000];

        private class Rectangle
        {
            public Rect Rect { get; set; }
        }

        private readonly Rectangle _rect = new Rectangle();

        private class Immutable.Rectangle
        {
            public Immutable.Rect Rect { get; set; }
        }

        private readonly Rectangle _immRect = new Rectangle();

        [Benchmark]
        public void UseRect_In()
        {
            for (int idx = 0; idx < 10000; idx++)
            {
                _rect.Rect = new Rect(idx, idx, idx, idx);
                _rects[idx] = Process(_rect.Rect);
            }

            Rect Process(in Rect source)
            {
                return new Rect(source.X * 2, source.Y * 2, source.Width * 2, source.Height * 2);
            }
        }

        [Benchmark]
        public void UseRect_Copy()
        {
            for (int idx = 0; idx < 10000; idx++)
            {
                _rect.Rect = new Rect(idx, idx, idx, idx);
                _rects[idx] = Process(_rect.Rect);
            }

            Rect Process(Rect source)
            {
                return new Rect(source.X * 2, source.Y * 2, source.Width * 2, source.Height * 2);
            }
        }

        [Benchmark]
        public void UseRect_Cast_Copy()
        {
            for (int idx = 0; idx < 10000; idx++)
            {
                _rect.Rect = new Rect(idx, idx, idx, idx);
                _rects[idx] = Process(_rect.Rect);
            }

            Immutable.Rect Process(Immutable.Rect source)
            {
                return new Immutable.Rect(source.X * 2, source.Y * 2, source.Width * 2, source.Height * 2);
            }
        }

        [Benchmark]
        public void UseRect_Cast_In()
        {
            for (int idx = 0; idx < 10000; idx++)
            {
                _rect.Rect = new Rect(idx, idx, idx, idx);
                _rects[idx] = Process(_rect.Rect);
            }

            Immutable.Rect Process(in Immutable.Rect source)
            {
                return new Immutable.Rect(source.X * 2, source.Y * 2, source.Width * 2, source.Height * 2);
            }
        }

        [Benchmark]
        public void UseImmutable.Rect_In()
        {
            for (int idx = 0; idx < 10000; idx++)
            {
                _immRect.Rect = new Immutable.Rect(idx, idx, idx, idx);
                _Immutable.Rects[idx] = Process(_rect.Rect);
            }

            Immutable.Rect Process(in Immutable.Rect source)
            {
                return new Immutable.Rect(source.X * 2, source.Y * 2, source.Width * 2, source.Height * 2);
            }
        }

        [Benchmark]
        public void UseImmutable.Rect_Copy()
        {
            for (int idx = 0; idx < 10000; idx++)
            {
                _immRect.Rect = new Immutable.Rect(idx, idx, idx, idx);
                _Immutable.Rects[idx] = Process(_rect.Rect);
            }

            Immutable.Rect Process(Immutable.Rect source)
            {
                return new Immutable.Rect(source.X * 2, source.Y * 2, source.Width * 2, source.Height * 2);
            }
        }

        [Benchmark]
        public void UseRect_Direct_In()
        {
            for (int idx = 0; idx < 10000; idx++)
            {
                _rects[idx] = Process(new Rect(idx, idx, idx, idx));
            }

            Rect Process(in Rect source)
            {
                return new Rect(source.X * 2, source.Y * 2, source.Width * 2, source.Height * 2);
            }
        }

        [Benchmark]
        public void UseRect_Direct_Copy()
        {
            for (int idx = 0; idx < 10000; idx++)
            {
                _rects[idx] = Process(new Rect(idx, idx, idx, idx));
            }

            Rect Process(Rect source)
            {
                return new Rect(source.X * 2, source.Y * 2, source.Width * 2, source.Height * 2);
            }
        }

        [Benchmark]
        public void UseImmutable.Rect_Direct_In()
        {
            for (int idx = 0; idx < 10000; idx++)
            {
                _Immutable.Rects[idx] = Process(new Immutable.Rect(idx, idx, idx, idx));
            }

            Immutable.Rect Process(in Immutable.Rect source)
            {
                return new Immutable.Rect(source.X * 2, source.Y * 2, source.Width * 2, source.Height * 2);
            }
        }

        [Benchmark]
        public void UsePoint_Direct_Copy()
        {
            for (int idx = 0; idx < 10000; idx++)
            {
                _points[idx] = Process(new Point(idx, idx));
            }

            Point Process(Point source)
            {
                return new Point(source.X * 2, source.Y * 2);
            }
        }

        [Benchmark]
        public void UseImmutablePoint_Direct_In()
        {
            for (int idx = 0; idx < 10000; idx++)
            {
                _immutablePoints[idx] = Process(new ImmutablePoint(idx, idx));
            }

            ImmutablePoint Process(in ImmutablePoint source)
            {
                return new ImmutablePoint(source.X * 2, source.Y * 2);
            }
        }

        private bool[] _contains_results = new bool[10000];

        [Benchmark]
        public void Rect_Rect_Contains()
        {
            var rect1 = new Rect(0, 0, 5000, 5000);
            for (int idx = 0; idx < 10000; idx++)
            {
                _contains_results[idx] = rect1.Contains(new Rect(0, 0, idx, idx));
            }
        }

        [Benchmark]
        public void Immutable.Rect_Immutable.Rect_Contains()
        {
            var rect1 = new Immutable.Rect(0, 0, 5000, 5000);
            for (int idx = 0; idx < 10000; idx++)
            {
                _contains_results[idx] = rect1.Contains(new Immutable.Rect(0, 0, idx, idx));
            }
        }

        [Benchmark]
        public void Immutable.Rect_Rect_Contains()
        {
            var rect1 = new Immutable.Rect(0, 0, 5000, 5000);
            for (int idx = 0; idx < 10000; idx++)
            {
                _contains_results[idx] = rect1.Contains(new Rect(0, 0, idx, idx));
            }
        }

        [Benchmark]
        public void Immutable.Rect_Immutable.Rect_Intersects()
        {
            var rect1 = new Immutable.Rect(0, 0, 5000, 5000);
            for (int idx = 0; idx < 10000; idx++)
            {
                _contains_results[idx] = rect1.IntersectsWith(new Immutable.Rect(idx, idx, idx, idx));
            }
        }

        [Benchmark]
        public void Immutable.Rect_Infrate_Param()
        {
            var rect1 = new Immutable.Rect(0, 0, 5000, 5000);
            for (int idx = 0; idx < 10000; idx++)
            {
                _Immutable.Rects[idx] = new Immutable.Rect(idx, idx, idx, idx).Inflate(idx, idx);
            }
        }
#endif
        private int[] hashSets = new int[10000];
        private bool[] equals = new bool[10000];

        [Benchmark]
        public void SystemImmutableGuid_In()
        {
            var guid1 = new Immutable.Guid(Guid.NewGuid());
            var guid2 = new Immutable.Guid(Guid.NewGuid());

            for (int idx = 0; idx < 10000; idx++)
            {
                hashSets[idx] = guid2.GetHashCode();
                equals[idx] = guid1.Equals(in guid2);
            }
        }

        [Benchmark]
        public void SystemImmutableGuid()
        {
            var guid1 = new Immutable.Guid(Guid.NewGuid());
            var guid2 = new Immutable.Guid(Guid.NewGuid());

            for (int idx = 0; idx < 10000; idx++)
            {
                hashSets[idx] = guid2.GetHashCode();
                equals[idx] = guid1.Equals(guid2);
            }
        }

        [Benchmark]
        public void SystemGuid()
        {
            var guid1 = Guid.NewGuid();
            var guid2 = Guid.NewGuid();

            for (int idx = 0; idx < 10000; idx++)
            {
                hashSets[idx] = guid2.GetHashCode();
                equals[idx] = guid1.Equals(guid2);
            }
        }
    }
}