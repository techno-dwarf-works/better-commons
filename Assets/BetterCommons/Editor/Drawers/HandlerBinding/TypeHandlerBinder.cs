using System;
using System.Collections.Generic;
using System.Linq;
using Better.Commons.Runtime.Utility;

namespace Better.Commons.EditorAddons.Drawers.Handlers
{
    public abstract class TypeHandlerBinder
    {
        protected HashSet<Binding> _bindings;

        public TypeHandlerBinder(HashSet<Binding> bindings)
        {
            _bindings = bindings;
        }

        public virtual bool IsSupported(Type fieldType)
        {
            if (fieldType == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(fieldType));
            }

            return _bindings.Any(binding => binding.IsFieldTypeSupported(fieldType));
        }
    }

    public class TypeHandlerBinder<THandler> : TypeHandlerBinder where THandler : SerializedPropertyHandler
    {
        public TypeHandlerBinder(HashSet<Binding> bindings) : base(bindings)
        {
        }

        public bool TryFindByFilter(HandlersFilter filter, out THandler handler)
        {
            if (filter == null)
            {
                handler = null;
                return false;
            }

            if (filter.TryFilter(_bindings, out var filteredBinding) && typeof(THandler).IsAssignableFrom(filteredBinding.HandlerType))
            {
                handler = (THandler)Activator.CreateInstance(filteredBinding.HandlerType);
                return true;
            }

            handler = null;
            return false;
        }
    }
}