using System;
using System.Collections.Generic;
using System.Linq;

namespace Better.Commons.EditorAddons.Drawers.Handlers
{
    public class AttributeHandlersFilter : FieldHandlersFilter
    {
        protected readonly Type _attributeType;

        public AttributeHandlersFilter(Type fieldType, Type attributeType) : base(fieldType)
        {
            _attributeType = attributeType;
        }

        protected override int GetBindingPriority(Binding bind)
        {
            return bind.GetBindingPriority(_attributeType, _fieldType);
        }

        protected override bool TryFilter(Binding binding)
        {
            return binding.Binds.Any(bind => bind.AttributeType.IsAssignableFrom(_attributeType))
                   && base.TryFilter(binding);
        }
    }
}