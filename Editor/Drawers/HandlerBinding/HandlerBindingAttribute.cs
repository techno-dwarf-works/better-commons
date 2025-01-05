using System;

namespace Better.Commons.EditorAddons.Drawers.HandlerBinding
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class HandlerBindingAttribute : Attribute
    {
        public BindingInfo BindingInfo { get; }

        public HandlerBindingAttribute(Type fieldType, Type attributeType)
        {
            BindingInfo = new BindingInfo(fieldType, attributeType, false);
        }

        public HandlerBindingAttribute(Type attributeType)
        {
            BindingInfo = new BindingInfo(null, attributeType, true);
        }
    }
}