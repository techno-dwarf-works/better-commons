using System;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace Better.Commons.EditorAddons.Drawers.Proxies
{
    public static class ProxyFactoryExtensions
    {
        public static void Add(this List<ProxyViewFactory> self, Func<Type, bool> supportedFunc, Func<InfoProxy, VisualElement> createFunc)
        {
            var fieldFactory = new ProxyViewFactory(supportedFunc, createFunc);
            self.Add(fieldFactory);
        }
    }
}