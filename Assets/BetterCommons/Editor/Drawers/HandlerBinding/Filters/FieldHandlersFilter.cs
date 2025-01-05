using System;
using Better.Commons.EditorAddons.Drawers.Handlers;

namespace Better.Commons.EditorAddons.Drawers.HandlerBinding.Filters
{
    public class FieldHandlersFilter : HandlersFilter
    {
        protected readonly Type _fieldType;

        public FieldHandlersFilter(Type fieldType)
        {
            _fieldType = fieldType;
        }
        
        protected override int GetBindingPriority(Binding bind)
        {
            return bind.GetBindingPriority(null, _fieldType);
        }

        protected override bool TryFilter(Binding binding)
        {
            return binding.IsFieldTypeSupported(_fieldType);
        }
    }
}