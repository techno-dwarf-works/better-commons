using System;
using Better.Commons.Runtime.Extensions;

namespace Better.Commons.EditorAddons.Drawers.Proxies
{
    public class SimpleProxy : InfoProxy
    {
        protected object Data { get; set; }

        public override object GetData()
        {
            return Data;
        }

        public override void SetData(object newData)
        {
            Data = newData;
        }

        public SimpleProxy(Type type, string name, object data)
            : base(type, name)
        {
            Data = data;
        }

        public SimpleProxy(Type type)
            : this(type, type.Name, type.GetDefault())
        {
        }
    }
}