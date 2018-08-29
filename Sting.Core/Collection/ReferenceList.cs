using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Sting.Core.Collection
{
    internal class ReferenceList<T> : IList<T>
        where T : struct, IEnumerable<T>
    {
        #region Inner Classes

        public struct ReferenceListEnumerator : IEnumerator<T>
        {
            private int _index;
            private readonly ReferenceList<T> _list;

            public ReferenceListEnumerator(ReferenceList<T> list) => (_index, _list) = (-1, list);

            public T Current => _list._list[_index / _list._arrayLength][_index % _list._arrayLength];

            object IEnumerator.Current => Current;

            public bool MoveNext() => ++_index < _list.Count;

            public void Dispose() { }

            public void Reset()
            {
                _index = -1;
            }
        }

        #endregion

        private readonly int _arrayLength = Math.Max(64 / Marshal.SizeOf(new T()), 4);

        private readonly List<T[]> _list = new List<T[]>();

        private int _capacity = 0;

        public T this[int index]
        {
            get => _list[index / _arrayLength][index % _arrayLength];
            set => _list[index / _arrayLength][index % _arrayLength] = value;
        }

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            if (_capacity == Count)
            {
                _capacity += _arrayLength;
                _list.Add(new T[_arrayLength]);
            }
            this[Count++] = item;
        }

        public void Clear()
        {
            _list.Clear();
            _capacity = 0;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) >= 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int idx = 0; idx < Count; idx++)
                array[idx + arrayIndex] = this[idx];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ReferenceListEnumerator(this);
        }

        public int IndexOf(T item)
        {
            for (int idx = 0; idx < Count; idx++)
                if (this[idx].Equals(item)) return idx;

            return -1;
        }

        public void Insert(int index, T item)
        {
            for (int idx = Count - 1; idx >= 0; idx--)
            {
                this[idx+1] = this[idx];
            }
            this[index] = item;
            Count++;
        }


        public bool Remove(T item)
        {
            int index;
            if ((index = IndexOf(item)) >= 0)
            {
                for(int idx = index; idx<Count -1; idx++)
                {
                    this[idx] = this[idx + 1];
                }
                Count--;
            }
            Count==new 　;
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}