using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Better.Commons.EditorAddons.Drawers.Handlers;
using Better.Commons.Runtime.Extensions;

namespace Better.Commons.EditorAddons.Drawers
{
    public static class HandlerBinderRegistry
    {
        private static readonly Dictionary<Type,TypeHandlerBinder> _binders;

        static HandlerBinderRegistry()
        {
            var binderType = typeof(TypeHandlerBinder);
            _binders = binderType.GetAllInheritedTypes()
                .Select(value => (value.GetCustomAttribute<BinderAttribute>()?.HandlerType, Value: value))
                .Where(tuple => tuple.HandlerType != null && tuple.Value.HasParameterlessConstructor())
                .ToDictionary(key=>key.HandlerType, value => (TypeHandlerBinder)Activator.CreateInstance(value.Value));
        }
        
        public static TypeHandlerBinder<THandler> GetMap<THandler>() where THandler : SerializedPropertyHandler
        {
            var handlerType = typeof(THandler);
            if (_binders.TryGetValue(handlerType, out var binder) && binder is TypeHandlerBinder<THandler> typeHandlerBinder)
            {
                return typeHandlerBinder;
            }

            return null;
        }
    }
}