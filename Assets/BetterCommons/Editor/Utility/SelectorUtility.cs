using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Better.Commons.Runtime.Extensions;
using Better.Commons.Runtime.Utility;
using UnityEngine;

namespace Better.Commons.EditorAddons.Utility
{
    public static class SelectorUtility
    {
        public static readonly char[] NameSeparator = new[] { '.', '/' };
        public const string SelectorDefinition = "r:";
        public const string Brackets = "()";
        public const string Dot = ".";

        private struct SelectorInfo
        {
            public object Instance { get; }
            public string MemberName { get; }
            public Type Type { get; }

            public SelectorInfo(object instance, string memberName, Type type)
            {
                Instance = instance;
                MemberName = memberName;
                Type = type;
            }
        }

        public static bool TryGetValue(string selector, object instance, out object value)
        {
            if (selector == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(selector));
                value = null;
                return false;
            }

            if (selector.StartsWith(SelectorDefinition))
            {
                selector = selector.Replace(SelectorDefinition, string.Empty);

                if (TryGetStaticInfo(selector, out var selectorInfo))
                {
                    value = ReflectionUtility.GetValueFromStaticMember(selectorInfo.Type, selectorInfo.MemberName);
                    return value != null;
                }

                if (TryGetInstanceInfo(selector, out selectorInfo))
                {
                    instance = selectorInfo.Instance;
                    selector = selectorInfo.MemberName;
                }
            }

            var memberName = selector.Replace(Brackets, string.Empty);

            if (!TryFindMethodParameters(instance, memberName, out var parameters))
            {
                value = null;
                return false;
            }

            value = ReflectionUtility.GetValueFromInstanceMember(memberName, instance, parameters);
            return value != null;
        }

        private static bool TryFindMethodParameters(object instance, string memberName, out object[] parameters)
        {
            var instanceType = instance.GetType();
            var member = ReflectionUtility.GetMemberByNameRecursive(instanceType, memberName);

            if (member is MethodInfo methodInfo)
            {
                return TryFindParameters(methodInfo.GetParameters(), instance, instanceType, out parameters);
            }

            parameters = Array.Empty<object>();
            return true;
        }

        private static bool TryFindParameters(ParameterInfo[] parameterInfos, object instance, Type instanceType, out object[] parameters)
        {
            if (parameterInfos.Length > 1)
            {
                parameters = Array.Empty<object>();
                return false;
            }

            if (parameterInfos.Length == 0)
            {
                parameters = Array.Empty<object>();
                return true;
            }

            return TryFindSingleParameter(instance, instanceType, parameterInfos[0], out parameters);
        }

        private static bool TryFindSingleParameter(object instance, Type instanceType, ParameterInfo parameter, out object[] parameters)
        {
            if (parameter.IsOut)
            {
                parameters = Array.Empty<object>();
                return false;
            }

            if (parameter.ParameterType == typeof(GameObject))
            {
                var foundGameObjectParameter = TryFindGameObjectParameter(instance, out parameters);
                return foundGameObjectParameter;
            }

            if (parameter.ParameterType.IsAssignableFrom(instanceType))
            {
                parameters = new object[] { instance };
                return true;
            }
            
            parameters = Array.Empty<object>();
            return false;
        }

        private static bool TryFindGameObjectParameter(object instance, out object[] parameters)
        {
            if (instance is GameObject)
            {
                parameters = new object[] { instance };
                return true;
            }

            if (instance is Component component)
            {
                parameters = new object[] { component.gameObject };
                return true;
            }

            parameters = Array.Empty<object>();
            return false;
        }


        private static bool TryGetStaticInfo(string selector, out SelectorInfo info)
        {
            if (selector.IsNullOrEmpty())
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(selector));
                info = default;
                return false;
            }

            var path = new Stack<string>(selector.Split(NameSeparator));
            var memberName = path.Pop().Replace(Brackets, string.Empty);
            if (TryFindTypeFromMemberPath(path, out var type))
            {
                info = new SelectorInfo(null, memberName, type);
                return true;
            }

            info = default;
            return false;
        }

        private static bool TryGetInstanceInfo(string selector, out SelectorInfo info)
        {
            if (selector.IsNullOrEmpty())
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(selector));
                info = default;
                return false;
            }

            var path = new Stack<string>(selector.Split(NameSeparator));
            var memberName = path.Pop().Replace(Brackets, string.Empty);
            var instanceName = path.Pop().Replace(Brackets, string.Empty);

            if (!TryFindTypeFromMemberPath(path, out var memberType))
            {
                DebugUtility.LogException<TypeAccessException>();
                info = default;
                return false;
            }

            var memberInfo = memberType.GetMemberByNameRecursive(instanceName);

            var instance = GetInstance(memberInfo);

            info = new SelectorInfo(instance, memberName, memberType);
            return true;
        }

        private static object GetInstance(MemberInfo memberInfo)
        {
            switch (memberInfo)
            {
                case PropertyInfo propertyInfo when propertyInfo.GetGetMethod().IsStatic:
                    return propertyInfo.GetValue(null);
                case FieldInfo { IsStatic: true } fieldInfo:
                    return fieldInfo.GetValue(null);
                case MethodInfo { IsStatic: true } methodInfo when methodInfo.GetParameters().Length <= 0:
                    return methodInfo.Invoke(null, Array.Empty<object>());
                default:
                    return null;
            }
        }

        private static bool TryFindTypeFromMemberPath(IEnumerable<string> path, out Type type)
        {
            var buffer = new Stack<string>(path);
            var typeString = buffer.Aggregate(buffer.Pop(), (input, item) => input + Dot + item);

            type = Type.GetType(typeString, false, true);
            if (type != null) return true;
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var bufferType = assembly.GetTypes().FirstOrDefault(t => t.Name == typeString);
                if (bufferType != null)
                {
                    type = bufferType;
                    return true;
                }
            }

            return type != null;
        }
    }
}