using System;
using System.Collections.Generic;

namespace Sting
{
    public static class DictionaryExtensions
    {
        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey key, Func<TValue> processToAdd)
        {
            if (dic.TryGetValue(key, out TValue value))
            {
                return value;
            }
            value = processToAdd();
            dic.Add(key, value);
            return value;
        }
    }
}