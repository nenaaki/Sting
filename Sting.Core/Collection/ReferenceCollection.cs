using System;
using System.Collections.Generic;

namespace Sting.Collection
{
    public class ReferenceCollection<T>
        where T : struct
    {
        #region Inner Classes

        /// <summary>
        /// <see cref="IEnumerator{T}"/>を実装しないEnumeratorです。
        /// 極力抽象化していないため callvirt は抑止されインライン展開を促進します。
        /// </summary>
        /// <remarks>
        /// <see cref="IDisposable"/>が無いとforeachの最後に型判定が入るため、実装しています。
        /// </remarks>
        public struct ReferenceCollectionEnumerator
        {
            private readonly T[][] _list;
            private readonly int _count;
            private int _index;
            private T[] _currentArray;
            private short _listIndex;
            private short _subIndex;

            public ReferenceCollectionEnumerator(ReferenceCollection<T> list)
            {
                _listIndex = 0;
                _index = _subIndex = -1;
                _count = list._count;
                _list = list._list;
                _currentArray = _list[0];
            }

            public ref T Current => ref _currentArray[_subIndex];

            public bool MoveNext()
            {
                if (++_index >= _count)
                    return false;

                if (++_subIndex >= _currentArray.Length)
                {
                    _currentArray = _list[++_listIndex];
                    _subIndex = 0;
                }
                return true;
            }
        }

        #endregion Inner Classes

        private T[][] _list = new T[4][];

        private T[] _currentArray;

        private int _capacity;

        private int _listIndex = -1;

        private int _subIndex = 8;

        private short _currentLength = 8;

        private int _count;
        public int Count => _count;

        public ReferenceCollection()
        {
        }

        public ReferenceCollection(IEnumerable<T> items) : this() => AddRange(items);

        public void Add(in T item)
        {
            if (_subIndex == _currentLength)
            {
                _listIndex++;
                if (_list.Length <= _listIndex)
                {
                    var newList = new T[_list.Length * 2][];
                    Array.Copy(_list, 0, newList, 0, _list.Length);
                    _list = newList;
                }
                _currentLength *= 2;
                _capacity += _currentLength;
                _list[_listIndex] = _currentArray = new T[_currentLength];
                _subIndex = 0;
            }
            _currentArray[_subIndex++] = item;
            _count++;
        }

        public void AddRange(IEnumerable<T> items)
        {
            using (var enumerator = items.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (_subIndex == _currentLength)
                    {
                        if (_list.Length <= ++_listIndex)
                        {
                            var newList = new T[_list.Length * 2][];
                            Array.Copy(_list, 0, newList, 0, _list.Length);
                            _list = newList;
                        }
                        _currentLength *= 2;
                        _capacity += _currentLength;
                        _list[_listIndex] = _currentArray = new T[_currentLength];
                        _subIndex = 0;
                    }
                    _currentArray[_subIndex++] = enumerator.Current;
                    _count++;
                }
            }
        }

        public ReferenceCollectionEnumerator GetEnumerator() => new ReferenceCollectionEnumerator(this);

        public T[] ToArray()
        {
            var result = new T[_count];
            int count = 0;
            foreach (var array in _list)
            {
                if (array == null)
                    break;

                Array.Copy(array, 0, result, count, Math.Min(array.Length, _count - count));
                count += array.Length;
            }
            return result;
        }
    }
}