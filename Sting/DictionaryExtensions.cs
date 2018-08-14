using System;
using System.Collections.Generic;

namespace Sting
{
    public static class DictionaryExtensions
    {
        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey key, Func<TValue> adder)
        {
            if (dic.TryGetValue(key, out TValue value))
            {
                return value;
            }
            value = adder();
            dic.Add(key, value);
            return value;
        }
    }
}