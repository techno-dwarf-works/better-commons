using System;

namespace Better.Commons.EditorAddons.Drawers.Proxies
{
    public abstract class InfoProxy
    {
        public Type Type { get; }
        public string Name { get; }

        public event Action DataChanged;

        public InfoProxy(Type type, string name)
        {
            Type = type;
            Name = name;
        }

        //TODO: Add extension for GetData<> and TryGetData<>
        public abstract object GetData();

        //TODO: Add extension for SetData<> and TrySetData<>
        public abstract void SetData(object newData);

        public void SetDirty()
        {
            DataChanged?.Invoke();
        }
    }
}