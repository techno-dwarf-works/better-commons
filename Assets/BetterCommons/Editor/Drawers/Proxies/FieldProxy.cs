using System.Reflection;

namespace Better.Commons.EditorAddons.Drawers.Proxies
{
    public class FieldProxy : InfoProxy
    {
        private readonly FieldInfo _info;
        private readonly object _instance;

        public FieldProxy(FieldInfo info, object instance = null) 
            : base(info.FieldType, info.Name)
        {
            _info = info;
            _instance = instance;
        }

        public override object GetData()
        {
            return _info.GetValue(_instance);
        }

        public override void SetData(object newData)
        {
            _info.SetValue(_instance, newData);
        }
    }
}