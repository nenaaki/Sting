using System;
using System.Collections.Generic;

namespace Sting
{
    public static class DictionaryExtensions
    {
        public static void AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey key, TValue value)
        {
            if (dic.ContainsKey(key))
            {
                dic[key] = value;
                return;
            }
            dic.Add(key, value);
        }

        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey key, Func<TValue> adder)
        {
            TValue value;
            if (dic.TryGetValue(key, out value))
            {
                return value;
            }
            value = adder();
            dic.Add(key, value);
            return value;
        }
    }
}