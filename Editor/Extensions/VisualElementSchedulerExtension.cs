using System;
using Better.Commons.Runtime.Utility;
using UnityEngine.UIElements;

namespace Better.Commons.EditorAddons.Extensions
{
    public static class VisualElementSchedulerExtension
    {
        public static void OnElementAppear<TElement>(this IVisualElementScheduler self, VisualElement element, Action<TElement> action) 
            where TElement : VisualElement
        {
            if (self == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return;
            }

            if (action == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(action));
                return;
            }

            self.Execute(OnExecute).Until(() => element.Q<TElement>() != null);
            return;

            void OnExecute()
            {
                var queriedElement = element.Q<TElement>();
                if(queriedElement == null) return;
                action.Invoke(queriedElement);
            }
        }
    }
}