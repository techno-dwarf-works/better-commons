using System;

namespace Better.Commons.EditorAddons.Drawers.Handlers
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