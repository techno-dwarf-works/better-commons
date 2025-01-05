using System;
using UnityEngine.UIElements;

namespace Better.Commons.EditorAddons.Drawers.Proxies
{
    public class ProxyViewFactory
    {
        public Func<Type, bool> SupportedFunc { get; }
        public Func<InfoProxy, VisualElement> CreateFunc { get; }

        public ProxyViewFactory(Func<Type, bool> supportedFunc, Func<InfoProxy, VisualElement> createFunc)
        {
            SupportedFunc = supportedFunc;
            CreateFunc = createFunc;
        }
    }
}