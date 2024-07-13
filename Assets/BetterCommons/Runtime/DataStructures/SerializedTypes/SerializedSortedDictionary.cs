using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Better.Commons.Runtime.Utility;
using UnityEngine;

namespace Better.Commons.Runtime.DataStructures.SerializedTypes
{
    [Serializable]
    public class SerializedSortedDictionary<TKey, TValue> : SortedDictionary<TKey, TValue>, ISerializationCallbackReceiver
    {
        // TODO: Add CustomDrawer for key-item table
        [SerializeField] private TKey[] _keys;
        [SerializeField] private TValue[] _values;

        public SerializedSortedDictionary()
        {
        }

        public SerializedSortedDictionary(IComparer<TKey> comparer) : base(comparer)
        {
        }

        public SerializedSortedDictionary(IDictionary<TKey, TValue> dictionary) : base(dictionary)
        {
        }

        public SerializedSortedDictionary(IDictionary<TKey, TValue> dictionary, IComparer<TKey> comparer) : base(dictionary, comparer)
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