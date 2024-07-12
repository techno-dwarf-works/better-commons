using System;

namespace Better.Commons.EditorAddons.Drawers.Handlers
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class BinderAttribute : Attribute
    {
        public Type HandlerType { get; }

        public BinderAttribute(Type handlerType)
        {
            HandlerType = handlerType;
        }
    }
}