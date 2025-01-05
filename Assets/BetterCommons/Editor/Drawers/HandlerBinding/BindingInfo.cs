using System;

namespace Better.Commons.EditorAddons.Drawers.HandlerBinding
{
    public class BindingInfo
    {
        public BindingInfo(Type fieldType, Type attributeType, bool anyFieldType)
        {
            AttributeType = attributeType;
            FieldType = fieldType;
            AnyFieldType = anyFieldType;
        }

        public Type AttributeType { get; }
        public Type FieldType { get; }
        public bool AnyFieldType { get; }
    }
}