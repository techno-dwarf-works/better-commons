using System;
using System.Collections.Generic;
using Better.Commons.EditorAddons.Drawers.HandlersTypeCollection;
using Better.Commons.Runtime.Utility;

namespace Better.Commons.EditorAddons.Drawers.Handlers
{
    public abstract class TypeHandlerBinder
    {
        protected HashSet<Type> _availableTypes;
        protected BaseHandlersTypeCollection _handlersCollection;

        protected TypeHandlerBinder()
        {
            Construct();
        }

        private void Construct()
        {
            _handlersCollection = GenerateCollection();
            _availableTypes = GenerateAvailable();
        }

        public virtual bool IsSupported(Type type)
        {
            if (type == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(type));
            }

            return _availableTypes.Contains(type);
        }


        protected abstract BaseHandlersTypeCollection GenerateCollection();

        protected abstract HashSet<Type> GenerateAvailable();
    }

    //TODO: Maybe make Locator<Locator<Type>>
    public abstract class TypeHandlerBinder<THandler> : TypeHandlerBinder where THandler : SerializedPropertyHandler
    {
        public THandler GetHandler(Type fieldType, Type attributeType)
        {
            if (fieldType == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(fieldType));
                return null;
            }

            if (attributeType == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(attributeType));
                return null;
            }

            if (!IsSupported(fieldType))
            {
                return null;
            }

            if (_handlersCollection.TryGetValue(attributeType, fieldType, out var type))
            {
                return (THandler)Activator.CreateInstance(type);
            }

            DebugUtility.LogException<KeyNotFoundException>($"Supported types not found for {fieldType}");
            return null;
        }
    }
}