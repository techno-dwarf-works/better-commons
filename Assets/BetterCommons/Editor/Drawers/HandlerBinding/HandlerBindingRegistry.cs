using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Better.Commons.EditorAddons.Drawers.Handlers;
using Better.Commons.Runtime.Extensions;

namespace Better.Commons.EditorAddons.Drawers.HandlerBinding
{
    public static class BindingRegistry
    {
        private static readonly HashSet<Binding> _bindings;

        static BindingRegistry()
        {
            _bindings = GetBindings();
        }

        private static HashSet<Binding> GetBindings()
        {
            var handlerTypes = typeof(SerializedPropertyHandler).GetAllInheritedTypes().Where(type => !type.IsAbstract);
            var boundHandlers = handlerTypes.Where(type => type.IsDefined(typeof(HandlerBindingAttribute)));
            var bindings = boundHandlers.Select(type => new Binding(type));
            return bindings.ToHashSet();
        }

        public static TypeHandlerBinder<THandler> GetBinder<THandler>() where THandler : SerializedPropertyHandler
        {
            var bindings = _bindings.Where(binding => typeof(THandler).IsAssignableFrom(binding.HandlerType)).ToHashSet();
            var binder = new TypeHandlerBinder<THandler>(bindings);
            return binder;
        }
    }
}