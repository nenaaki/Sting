using System.Collections;
using System.Collections.Generic;
using Sting.Immutable;

namespace Sting.Collection
{
    public class GuidKeyDictionary<TValue> : IDictionary<Guid, TValue>
    {
        public TValue this[Guid key] { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public ICollection<Guid> Keys => throw new System.NotImplementedException();

        public ICollection<TValue> Values => throw new System.NotImplementedException();

        public int Count => throw new System.NotImplementedException();

        public bool IsReadOnly => throw new System.NotImplementedException();

        public void Add(Guid key, TValue value)
        {
            throw new System.NotImplementedException();
        }

        public void Add(KeyValuePair<Guid, TValue> item)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(KeyValuePair<Guid, TValue> item)
        {
            throw new System.NotImplementedException();
        }

        public bool ContainsKey(Guid key)
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(KeyValuePair<Guid, TValue>[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<KeyValuePair<Guid, TValue>> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(Guid key)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(KeyValuePair<Guid, TValue> item)
        {
            throw new System.NotImplementedException();
        }

        public bool TryGetValue(Guid key, out TValue value)
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}