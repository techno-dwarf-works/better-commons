using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Better.Commons.Runtime.DataStructures.SerializedTypes
{
    /// <summary>
    /// Enables the serialization of a System.Type reference within Unity, storing the type's assembly qualified name.
    /// </summary>
    [Serializable]
    public class SerializedType : ISerializationCallbackReceiver, IEquatable<SerializedType>
    {
        [FormerlySerializedAs("fullQualifiedName")]
        [SerializeField] private protected string _fullQualifiedName; // The full name of the type, used for serialization.

        private Type _type; // The actual Type object, not serialized.

        /// <summary>
        /// Gets the Type object associated with this SerializedType. Attempts to resolve the Type if not already cached.
        /// </summary>
        public Type Type
        {
            get
            {
                if (_type == null && !string.IsNullOrEmpty(_fullQualifiedName))
                {
                    if (!TryGetReferenceType(_fullQualifiedName, out _type))
                    {
                        _fullQualifiedName = string.Empty;
                    }
                }

                return _type;
            }
        }

        /// <summary>
        /// Default constructor for <see cref="SerializedType"/>.
        /// </summary>
        public SerializedType()
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="SerializedType"/> with the specified type name.
        /// </summary>
        /// <param name="qualifiedTypeName">The assembly qualified name of the type.</param>
        public SerializedType(string qualifiedTypeName)
        {
            ValidateStringType(qualifiedTypeName);
            _fullQualifiedName = qualifiedTypeName;
        }

        /// <summary>
        /// Validates the provided type name and initializes the Type object if it's valid.
        /// </summary>
        /// <param name="qualifiedTypeName">The assembly qualified name to validate.</param>
        private protected void ValidateStringType(string qualifiedTypeName)
        {
            if (!TryGetReferenceType(qualifiedTypeName, out _type))
            {
                Debug.LogWarning($"{qualifiedTypeName} not found");
            }
        }

        /// <summary>
        /// Initializes a new instance of <see cref="SerializedType"/> with the specified Type object.
        /// </summary>
        /// <param name="type">The Type object to serialize.</param>
        public SerializedType(Type type)
        {
            _type = type;
            _fullQualifiedName = type.AssemblyQualifiedName;
        }

        private static bool TryGetReferenceType(string value, out Type type)
        {
            type = !string.IsNullOrEmpty(value) ? Type.GetType(value) : null;
            return type != null;
        }

        /// <summary>
        /// Returns a string representation of the Type, or "(None)" if the type is not set.
        /// </summary>
        /// <returns>A string representing the Type.</returns>
        public override string ToString()
        {
            return _type != null ? _type.FullName : "(None)";
        }

        /// <summary>
        /// Called after Unity deserializes this object. Attempts to resolve the Type from its serialized name.
        /// </summary>
        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            if (!string.IsNullOrEmpty(_fullQualifiedName))
            {
                _type = Type.GetType(_fullQualifiedName);
                if (_type == null)
                {
#if UNITY_EDITOR
                    Debug.LogWarning($"'{_fullQualifiedName}' class type not found.");
#endif
                }
            }
            else
            {
                _type = null;
            }
        }

        /// <summary>
        /// Called before Unity serializes this object. No implementation needed for this class.
        /// </summary>
        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
        }

        // Implicit conversions to and from Type and string representations.
        public static implicit operator string(SerializedType typeReference) => typeReference._fullQualifiedName;
        public static implicit operator Type(SerializedType typeReference) => typeReference.Type;
        public static implicit operator SerializedType(Type type) => new SerializedType(type);

        public bool Equals(SerializedType other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Type == other.Type;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SerializedType)obj);
        }

        public override int GetHashCode()
        {
            if (Type == null)
            {
                return default;
            }

            return Type.GetHashCode();
        }
    }
}