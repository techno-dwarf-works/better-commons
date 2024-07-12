using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Better.Commons.Runtime.Comparers;
using Better.Commons.Runtime.Extensions;
using Better.Internal.Core.Runtime;
using UnityObject = UnityEngine.Object;

namespace Better.Commons.Runtime.Utility
{
    public static class ReflectionUtility
    {
        public static bool HasParameterlessConstructor(Type type)
        {
            if (type == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(type));
                return false;
            }

            if (type.IsValueType)
            {
                return true;
            }

            var constructor = type.GetConstructor(
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                null, Type.EmptyTypes, null);

            return constructor != null;
        }

        public static bool IsArrayOrList(Type type)
        {
            if (type == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(type));
                return false;
            }

            if (type.IsArray)
            {
                return true;
            }

            var listType = typeof(List<>);
            return IsAssignableFromRawGeneric(listType, type);
        }

        public static bool IsEnumerable(Type type)
        {
            if (type == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(type));
                return false;
            }

            if (type.IsArray)
            {
                return true;
            }

            var enumerableType = typeof(IEnumerable<>);
            return IsAssignableFromRawGeneric(enumerableType, type);
        }

        public static bool IsAssignableFromRawGeneric(Type type, Type assignableType)
        {
            if (type == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(type));
                return false;
            }

            if (assignableType == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(assignableType));
                return false;
            }

            var bufferType = assignableType;
            while (bufferType.BaseType != null)
            {
                if (IsGeneric(bufferType, type))
                {
                    return true;
                }

                foreach (var subType in bufferType.GetInterfaces())
                {
                    if (!IsGeneric(subType, type)) continue;
                    return true;
                }

                bufferType = bufferType.BaseType;
            }

            return false;
        }

        public static bool IsGeneric(Type type, Type genericType)
        {
            if (type == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(type));
                return false;
            }

            if (type.IsGenericType && type.GetGenericTypeDefinition() == genericType)
            {
                return true;
            }

            return false;
        }

        public static bool IsGeneric<T>(Type self)
        {
            var type = typeof(T);
            return IsGeneric(self, type);
        }

        public static bool IsEnum(Type type, bool checkFlagAttribute = false)
        {
            if (type == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(type));
                return false;
            }

            if (type.IsEnum)
            {
                return !checkFlagAttribute || type.GetCustomAttribute<FlagsAttribute>() != null;
            }

            return false;
        }

        public static object GetDefault(Type type)
        {
            if (type == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(type));
                return null;
            }

            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }

            if (type == typeof(string))
            {
                return string.Empty;
            }

            return null;
        }

        public static IEnumerable<Type> GetAllInheritedTypes(Type type)
        {
            if (type == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(type));
                return null;
            }

            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(iterationType => type.IsAssignableFrom(iterationType) && (iterationType.IsClass || iterationType.IsValueType) && !iterationType.IsAbstract);
        }

        public static IEnumerable<Type> GetAllInheritedTypes(Type type, params Type[] excludes)
        {
            return GetAllInheritedTypes(type).Except(excludes, IsSubClassComparer.Instance);
        }

        public static IEnumerable<Type> GetAllInheritedTypesWithoutUnityObject(Type type)
        {
            if (type == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(type));
                return null;
            }

            var unityObjectType = typeof(UnityObject);
            if (type.IsSubclassOf(unityObjectType))
            {
                return Enumerable.Empty<Type>();
            }

            return GetAllInheritedTypes(type, unityObjectType);
        }

        public static bool IsAnonymous(Type type)
        {
            if (type.IsClass && type.IsSealed && type.Attributes.HasFlag(TypeAttributes.NotPublic))
            {
                var attributes = type.GetCustomAttribute<CompilerGeneratedAttribute>(false);
                if (attributes != null)
                {
                    return true;
                }
            }

            return false;
        }

        public static IEnumerable<Type> GetAllInheritedTypesOfRawGeneric(Type type)
        {
            if (type == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(type));
                return null;
            }

            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(iterationType => IsSubclassOfRawGeneric(iterationType, type));
        }

        public static IEnumerable<Type> GetAllInheritedTypesOfRawGeneric(Type type, params Type[] excludes)
        {
            return GetAllInheritedTypesOfRawGeneric(type).Except(excludes);
        }

        public static bool IsSubclassOf<T>(Type type)
        {
            if (type == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(type));
                return false;
            }

            var genericType = typeof(T);
            return type.IsSubclassOf(genericType);
        }

        public static bool IsSubclassOfAny(Type type, IEnumerable<Type> anyTypes)
        {
            if (type == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(type));
                return false;
            }

            if (anyTypes == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(anyTypes));
                return false;
            }

            foreach (var anyType in anyTypes)
            {
                if (anyType != null && type.IsSubclassOf(anyType))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsSubclassOfRawGeneric(Type type, Type genericType)
        {
            if (type == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(type));
                return false;
            }

            if (genericType == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(genericType));
                return false;
            }

            while (type != null && type != typeof(object))
            {
                var definition = type.IsGenericType ? type.GetGenericTypeDefinition() : type;
                if (genericType == definition && type != genericType)
                {
                    return true;
                }

                type = type.BaseType;
            }

            return false;
        }

        public static bool IsSubclassOfAnyRawGeneric(Type type, IEnumerable<Type> genericTypes)
        {
            if (type == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(type));
                return false;
            }

            if (genericTypes == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(genericTypes));
                return false;
            }

            foreach (var anyType in genericTypes)
            {
                if (anyType != null && IsSubclassOfRawGeneric(type, anyType))
                {
                    return true;
                }
            }

            return false;
        }

        public static Type GetCollectionElementType(Type type)
        {
            if (type == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(type));
                return null;
            }

            if (type.IsArray)
            {
                return type.GetElementType();
            }

            if (IsEnumerable(type))
            {
                return type.GetGenericArguments()[0];
            }

            return null;
        }

        public static bool IsNullable(Type type)
        {
            if (type == null || !type.IsValueType)
            {
                return true;
            }

            return Nullable.GetUnderlyingType(type) != null;
        }

        public static IEnumerable<MemberInfo> GetMembersRecursive(Type type)
        {
            if (type == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(type));
                return Enumerable.Empty<MemberInfo>();
            }

            var members = new HashSet<MemberInfo>(MemberInfoComparer.Instance);

            const BindingFlags methodFlags = Defines.MethodFlags & ~BindingFlags.DeclaredOnly;
            do
            {
                // If the type is a constructed generic type, get the members of the generic type definition
                var typeToReflect = type.IsGenericType && !type.IsGenericTypeDefinition ? type.GetGenericTypeDefinition() : type;

                foreach (var member in typeToReflect.GetMembers(methodFlags))
                {
                    // For generic classes, convert members back to the constructed type
                    MemberInfo memberToAdd;
                    if (type.IsGenericType && !type.IsGenericTypeDefinition)
                    {
                        memberToAdd = ConvertToConstructedGenericType(member, type);
                    }
                    else
                    {
                        memberToAdd = member;
                    }

                    if (memberToAdd != null)
                    {
                        members.Add(memberToAdd);
                    }
                }

                type = type.BaseType;
            } while (type != null); // Continue until you reach the top of the inheritance hierarchy

            return members;
        }

        private static MemberInfo ConvertToConstructedGenericType(MemberInfo memberInfo, Type constructedType)
        {
            // Ensure the member's declaring type is a generic type definition
            if (memberInfo.DeclaringType != null && memberInfo.DeclaringType.IsGenericTypeDefinition)
            {
                var members = constructedType.GetMember(memberInfo.Name);
                return members.FirstOrDefault();
            }

            // Return the original memberInfo if it's not a property of a generic type definition or doesn't need to be constructed
            return memberInfo;
        }

        public static MemberInfo GetMemberByNameRecursive(Type type, string memberName)
        {
            if (type == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(type));
                return null;
            }

            if (string.IsNullOrEmpty(memberName))
            {
                DebugUtility.LogException<ArgumentException>(nameof(memberName));
                return null;
            }

            var allMembers = GetMembersRecursive(type);

            // Use LINQ to find the member by name. This assumes you want the first match if there are multiple members with the same name (overloads).
            // If you expect overloads and want to handle them differently, you might need a more complex approach.
            return allMembers.FirstOrDefault(m => m.Name == memberName);
        }

        public static object GetValueFromInstanceMember(object instance, string memberName)
        {
            if (instance == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(instance));
                return null;
            }

            if (memberName.IsNullOrEmpty())
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(memberName));
                return null;
            }

            var type = instance.GetType();
            var member = GetMemberByNameRecursive(type, memberName);
            if (TryGetValue(member, instance, out var value))
            {
                return value;
            }

            return null;
        }

        public static object GetValueFromStaticMember(Type type, string memberName)
        {
            if (type == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(type));
                return null;
            }

            if (memberName.IsNullOrEmpty())
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(memberName));
                return null;
            }

            var member = GetMemberByNameRecursive(type, memberName);
            if (TryGetValue(member, null, out var value))
            {
                return value;
            }

            return null;
        }

        private static bool TryGetValue(MemberInfo memberInfo, object instance, out object value)
        {
            if (memberInfo is PropertyInfo propertyInfo)
            {
                value = propertyInfo.GetValue(instance);
                return true;
            }

            if (memberInfo is FieldInfo fieldInfo)
            {
                value = fieldInfo.GetValue(instance);
                return true;
            }

            if (memberInfo is MethodInfo methodInfo)
            {
                value = methodInfo.Invoke(instance, Array.Empty<object>());
                return true;
            }

            value = null;
            return false;
        }
    }
}