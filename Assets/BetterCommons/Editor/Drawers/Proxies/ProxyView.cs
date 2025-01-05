using System;
using System.Collections.Generic;
using System.Linq;
using Better.Commons.Runtime.Extensions;
using UnityEngine.UIElements;

namespace Better.Commons.EditorAddons.Drawers.Proxies
{
    public abstract class ProxyView : VisualElement
    {
    }

    public abstract class ProxyView<TData> : ProxyView, INotifyValueChanged<TData> where TData : class
    {
        private TData _data;

        public TData value
        {
            get { return _data; }
            set
            {
                if (EqualityComparer<TData>.Default.Equals(_data, value))
                {
                    return;
                }

                if (panel != null)
                {
                    using (var pooled = ChangeEvent<TData>.GetPooled(_data, value))
                    {
                        pooled.target = this;
                        SetValueWithoutNotify(value);
                        SendEvent(pooled);
                    }
                }
                else
                {
                    SetValueWithoutNotify(value);
                }
            }
        }

        protected abstract TData GetData();

        public virtual void SetValueWithoutNotify(TData newValue)
        {
            _data = newValue;
        }

        protected virtual void OnDataChanged()
        {
            value = GetData();
        }
    }

    public class ProxyView<TProxy, TData> : ProxyView<TData> where TProxy : InfoProxy where TData : class
    {
        private readonly TProxy _info;

        public ProxyView(TProxy info)
        {
            _info = info;
            _info.DataChanged += OnDataChanged;
            var element = ProxyProvider.CreateDrawer(_info);
            Add(element);

            style.PaddingRight(5f);
        }

        protected override TData GetData()
        {
            return _info.GetData() as TData;
        }

        public override void SetValueWithoutNotify(TData newValue)
        {
            base.SetValueWithoutNotify(newValue);

            _info.SetData(newValue);
        }
    }
}