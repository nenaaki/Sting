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
            where T : struct
        {
            return new Buffer<T>(items).ToArray().AsRef();
        }
    }

    internal struct Buffer<TElement>
    {
        private TElement[] _items;
        private int _count;

        internal Buffer(IEnumerable<TElement> source)
        {
            _items = null;
            _count = 0;
            if (source is ICollection<TElement> collection)
            {
                _count = collection.Count;
                if (_count > 0)
                {
                    _items = new TElement[_count];
                    collection.CopyTo(_items, 0);
                }
                else
                    _items = Array.Empty<TElement>();
            }
            else
            {
                _items = new TElement[64];
                foreach (TElement item in source)
                {
                    if (_items.Length == _count)
                    {
                        Array.Resize(ref _items, _count * 2);
                    }
                    _items[_count++] = item;
                }
                if (_count == 0)
                    _items = Array.Empty<TElement>();
                else if (_items.Length != _count)
                {
                    Array.Resize(ref _items, _count);
                }
            }
        }

        internal TElement[] ToArray()
        {
            return _items;
        }
    }
}