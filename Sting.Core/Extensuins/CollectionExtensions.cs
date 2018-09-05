using System;
using System.Collections.Generic;
using Sting.Collection;

namespace Sting
{
    public static class CollectionExtensions
    {
        public static ReferenceArray<T> AsRef<T>(this T[] array) where T : struct => new ReferenceArray<T>(array);

        public static ReferenceCollection<T> ToReferenceList<T>(this IEnumerable<T> items) where T : struct => new ReferenceCollection<T>(items);

        public static ReferenceArray<T> ToRefArray<T>(this IEnumerable<T> items)
            where T : struct => new Buffer<T>(items).ToArray().AsRef();

        public static T[] ToArrayFast<T>(this IEnumerable<T> items)
            where T : struct => new Buffer<T>(items).ToArray();

        public static T[] ToArraySimple<T>(this IEnumerable<T> items)
            where T : struct
        {
            using (var enumerator = items.GetEnumerator())
            {
                int count = 0;
                while (enumerator.MoveNext())
                    count++;

                enumerator.Reset();
                var array = new T[count];

                int idx = 0;
                while (enumerator.MoveNext())
                    array[idx++] = enumerator.Current;

                return array;
            }
        }
    }

    internal struct Buffer<TElement>
    {
        private const int InitialBufferSize = 64;
        private const int ExpandRatio = 4;
        private readonly int _count;
        private readonly TElement[] _items;

        public Buffer(IEnumerable<TElement> source)
        {
            if (source is ICollection<TElement> collection)
            {
                _count = collection.Count;
                if (_count == 0)
                {
                    _items = Array.Empty<TElement>();
                }
                else
                {
                    _items = new TElement[_count];
                    collection.CopyTo(_items, 0);
                }
            }
            else
            {
                _count = 0;
                _items = new TElement[InitialBufferSize];
                foreach (var item in source)
                {
                    if (_items.Length == _count)
                        Array.Resize(ref _items, _count * ExpandRatio);

                    _items[_count++] = item;
                }
                if (_count == 0)
                    _items = Array.Empty<TElement>();
                else if (_items.Length != _count)
                    Array.Resize(ref _items, _count);
            }
        }

        public TElement[] ToArray() => _items;
    }
}