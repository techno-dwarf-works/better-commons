using System;
using Better.Commons.Runtime.Extensions;

namespace Better.Commons.EditorAddons.Drawers.Proxies
{
    public class ValueProxy : SimpleProxy
    {
        public ValueProxy(Type type, object value) : base(type, type.Name, value)
        {
        }
        
        public ValueProxy(Type type) : base(type, type.Name, type.GetDefault())
        {
        }
        
        public ValueProxy(object value) : this(value.GetType(), value)
        {
        }
    }
}