using System;
using Better.Commons.EditorAddons.Extensions;
using UnityEditor;

namespace Better.Commons.EditorAddons.Drawers.Base
{
    public class CachedSerializedProperty : IEquatable<CachedSerializedProperty>
    {
        private readonly int _hashCode;
        private readonly SerializedProperty _serializedProperty;

        public SerializedProperty SerializedProperty => _serializedProperty;

        public CachedSerializedProperty(SerializedProperty serializedProperty)
        {
            _hashCode = serializedProperty.GetHashCode();
            _serializedProperty = serializedProperty;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_hashCode, _serializedProperty);
        }

        public bool IsValid()
        {
            try
            {
                if (_serializedProperty == null)
                {
                    return false;
                }
                
                if (!_serializedProperty.Verify())
                {
                    return false;
                }

                if (_serializedProperty.IsDisposed())
                {
                    return false;
                }

                return _serializedProperty.serializedObject.targetObject != null;
            }
            catch
            {
                return false;
            }
        }

        public bool Equals(CachedSerializedProperty other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _hashCode == other._hashCode;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((CachedSerializedProperty)obj);
        }
        
        public static implicit operator SerializedProperty(CachedSerializedProperty property)
        {
            return property.SerializedProperty;
        }

        public static explicit operator CachedSerializedProperty(SerializedProperty property)
        {
            return new CachedSerializedProperty(property);
        }

        public static bool operator ==(CachedSerializedProperty left, CachedSerializedProperty right)
        {
            return !ReferenceEquals(left, null) && left.Equals(right);
        }

        public static bool operator !=(CachedSerializedProperty left, CachedSerializedProperty right)
        {
            return !ReferenceEquals(left, null) && !left.Equals(right);
        }
    }
}