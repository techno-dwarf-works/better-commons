using System;
using System.Collections.Generic;

namespace Better.Commons.Runtime.Extensions
{
    public static class DictionaryExtensions
    {
        public static bool TryGetKey<TKey, TValue>(this Dictionary<TKey, TValue> self, TValue value, out TKey key)
        {
            if (self == null)
            {
                throw new ArgumentNullException(nameof(self));
            }

            foreach (var keyValuePair in self)
            {
                if (keyValuePair.Value.Equals(value))
                {
                    key = keyValuePair.Key;
                    return true;
                }
            }

            key = default;
            return false;
        }

        public static bool TryGetKeys<TKey, TValue>(this Dictionary<TKey, TValue> self, TValue value, out TKey[] keys)
        {
            if (self == null)
            {
                throw new ArgumentNullException(nameof(self));
            }

            var rawKeys = new List<TKey>();
            foreach (var keyValuePair in self)
            {
                if (keyValuePair.Value.Equals(value))
                {
                    rawKeys.Add(keyValuePair.Key);
                }
            }

            keys = rawKeys.ToArray();
            return !keys.IsEmpty();
        }

        public static bool Remove<TKey, TValue>(this Dictionary<TKey, TValue> self, IEnumerable<TKey> keys)
        {
            if (self == null)
            {
                throw new ArgumentNullException(nameof(self));
            }

            var removedAny = false;
            foreach (var key in keys)
            {
                if (self.Remove(key))
                {
                    removedAny = true;
                }
            }

            return removedAny;
        }

        public static bool Remove<TKey, TValue>(this Dictionary<TKey, TValue> self, TValue value, out TKey key)
        {
            if (self == null)
            {
                throw new ArgumentNullException(nameof(self));
            }

            return self.TryGetKey(value, out key) && self.Remove(key);
        }

        public static bool Remove<TKey, TValue>(this Dictionary<TKey, TValue> self, TValue value)
        {
            return self.Remove(value, out _);
        }

        public static bool RemoveAll<TKey, TValue>(this Dictionary<TKey, TValue> self, TValue value, out TKey[] keys)
        {
            if (self == null)
            {
                throw new ArgumentNullException(nameof(self));
            }

            return self.TryGetKeys(value, out keys) && self.Remove(keys);
        }

        public static TValue GetOrCreate<TKey, TValue>(this Dictionary<TKey, TValue> self, TKey key) 
            where TValue : new()
        {
            if (self == null)
            {
                throw new ArgumentNullException(nameof(self));
            }

            if (!self.TryGetValue(key, out var value))
            {
                value = new TValue();
                self.Add(key, value);
            }

            return value;
        }

        public static bool RemoveAll<TKey, TValue>(this Dictionary<TKey, TValue> self, TValue value)
        {
            return self.RemoveAll(value, out _);
        }
    }
}