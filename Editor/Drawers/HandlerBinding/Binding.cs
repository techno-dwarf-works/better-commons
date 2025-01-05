using System;
using System.Linq;
using System.Reflection;

namespace Better.Commons.EditorAddons.Drawers.HandlerBinding
{
    public class Binding
    {
        public BindingInfo[] Binds { get; }
        public Type HandlerType { get; }

        public Binding(Type handlerType)
        {
            HandlerType = handlerType;
            var handlerBindings = HandlerType.GetCustomAttributes<HandlerBindingAttribute>(true).Select(attribute => attribute.BindingInfo);

            Binds = handlerBindings.ToArray();
        }

        public int GetBindingPriority(Type attributeType, Type fieldType)
        {
            var value = GetFieldPriority(fieldType);
            if (value < 0)
            {
                return value;
            }

            var buffer = GetAttributePriority(attributeType);
            if (buffer < 0)
            {
                return buffer;
            }

            return value + buffer;
        }

        private int GetFieldPriority(Type fieldType)
        {
            if (!IsFieldTypeSupported(fieldType))
            {
                return -1;
            }

            if (Binds.Any(bind => bind.FieldType != null && bind.FieldType == fieldType))
            {
                return 2;
            }

            if (Binds.Any(bind => bind.FieldType != null && bind.FieldType.IsAssignableFrom(fieldType)))
            {
                return 1;
            }

            if (Binds.Any(bind => bind.AnyFieldType))
            {
                return 0;
            }

            return 0;
        }

        private int GetAttributePriority(Type attributeType)
        {
            if (attributeType == null)
            {
                return 0;
            }

            if (Binds.All(bind => bind.AttributeType == null))
            {
                return -1;
            }

            if (Binds.Any(bind => bind.AttributeType != null && bind.AttributeType == attributeType))
            {
                return 2;
            }

            if (Binds.Any(bind => bind.AttributeType != null && bind.AttributeType.IsAssignableFrom(attributeType)))
            {
                return 1;
            }

            return 0;
        }

        public bool IsFieldTypeSupported(Type fieldType)
        {
            var fieldSupported = Binds.Select(bind => bind.FieldType)
                .Where(bindFieldType => bindFieldType != null && fieldType != null)
                .Any(bindFieldType => bindFieldType.IsAssignableFrom(fieldType));

            if (fieldSupported)
            {
                return true;
            }

            var anyFieldSupported = Binds.Any(bind => bind.AnyFieldType);
            return anyFieldSupported;
        }
    }
}