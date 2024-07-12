using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Better.Commons.Runtime.Utility;
using UnityEngine;

namespace Better.Commons.Runtime.DataStructures.SerializedTypes
{
    [Serializable]
    public class SerializedDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
    {
        // TODO: Add CustomDrawer for key-item table
        [SerializeField] private TKey[] _keys;
        [SerializeField] private TValue[] _values;

        public SerializedDictionary()
        {
        }

        public SerializedDictionary(IDictionary<TKey, TValue> dictionary) : base(dictionary)
        {
        }

        public SerializedDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer) : base(dictionary, comparer)
        {
        }

        public SerializedDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection) : base(collection)
        {
        }

        public SerializedDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection, IEqualityComparer<TKey> comparer) : base(collection, comparer)
        {
        }

        public SerializedDictionary(IEqualityComparer<TKey> comparer) : base(comparer)
        {
        }

        public SerializedDictionary(int capacity) : base(capacity)
        {
        }

        public SerializedDictionary(int capacity, IEqualityComparer<TKey> comparer) : base(capacity, comparer)
        {
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
            _keys = Keys.ToArray();
            _values = Values.ToArray();
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            if (_keys == null || _values == null || _keys.Length != _values.Length)
            {
                DebugUtility.LogException<SerializationException>();
                return;
            }

            Clear();
            for (var i = 0; i < _keys.Length; ++i)
            {
                Add(_keys[i], _values[i]);
            }
        }
    }
}