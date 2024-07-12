using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Better.Commons.Runtime.Comparers;
using Better.Commons.Runtime.Utility;
using Better.Internal.Core.Runtime;
using UnityObject = UnityEngine.Object;

namespace Better.Commons.Runtime.Extensions
{
    //TODO: Create Reflection Utility
    public static class TypeExtensions
    {
        public static bool HasParameterlessConstructor(this Type self)
        {
            return ReflectionUtility.HasParameterlessConstructor(self);
        }

        public static bool IsArrayOrList(this Type self)
        {
            return ReflectionUtility.IsArrayOrList(self);
        }

        public static bool IsEnumerable(this Type self)
        {
            return ReflectionUtility.IsEnumerable(self);
        }

        public static bool IsAssignableFromRawGeneric(this Type self, Type type)
        {
            return ReflectionUtility.IsAssignableFromRawGeneric(self, type);
        }

        public static bool IsGeneric(this Type self, Type type)
        {
            return ReflectionUtility.IsGeneric(self, type);
        }

        public static bool IsGeneric<T>(this Type self)
        {
            return ReflectionUtility.IsGeneric<T>(self);
        }

        public static bool IsEnum(this Type self, bool checkFlagAttribute = false)
        {
            return ReflectionUtility.IsEnum(self, checkFlagAttribute);
        }

        public static object GetDefault(this Type self)
        {
            return ReflectionUtility.GetDefault(self);
        }

        public static IEnumerable<Type> GetAllInheritedTypes(this Type self)
        {
            return ReflectionUtility.GetAllInheritedTypes(self);
        }

        public static IEnumerable<Type> GetAllInheritedTypes(this Type self, params Type[] excludes)
        {
            return ReflectionUtility.GetAllInheritedTypes(self, excludes);
        }

        public static IEnumerable<Type> GetAllInheritedTypesWithoutUnityObject(this Type self)
        {
            return ReflectionUtility.GetAllInheritedTypesWithoutUnityObject(self);
        }

        public static bool IsAnonymous(this Type self)
        {
            return ReflectionUtility.IsAnonymous(self);
        }

        public static IEnumerable<Type> GetAllInheritedTypesOfRawGeneric(this Type self)
        {
            return ReflectionUtility.GetAllInheritedTypesOfRawGeneric(self);
        }

        public static IEnumerable<Type> GetAllInheritedTypesOfRawGeneric(this Type self, params Type[] excludes)
        {
            return ReflectionUtility.GetAllInheritedTypesOfRawGeneric(self, excludes);
        }

        public static bool IsSubclassOf<T>(this Type self)
        {
            return ReflectionUtility.IsSubclassOf<T>(self);
        }

        public static bool IsSubclassOfAny(this Type self, IEnumerable<Type> anyTypes)
        {
            return ReflectionUtility.IsSubclassOfAny(self, anyTypes);
        }

        public static bool IsSubclassOfRawGeneric(this Type self, Type genericType)
        {
            return ReflectionUtility.IsSubclassOfRawGeneric(self, genericType);
        }

        public static bool IsSubclassOfAnyRawGeneric(this Type self, IEnumerable<Type> genericTypes)
        {
            return ReflectionUtility.IsSubclassOfAnyRawGeneric(self, genericTypes);
        }

        public static Type GetCollectionElementType(this Type self)
        {
            return ReflectionUtility.GetCollectionElementType(self);
        }

        public static bool IsNullable(this Type self)
        {
            return ReflectionUtility.IsNullable(self);
        }

        public static IEnumerable<MemberInfo> GetMembersRecursive(this Type type)
        {
            return ReflectionUtility.GetMembersRecursive(type);
        }

        public static MemberInfo GetMemberByNameRecursive(this Type type, string memberName)
        {
            return ReflectionUtility.GetMemberByNameRecursive(type, memberName);
        }
    }
}