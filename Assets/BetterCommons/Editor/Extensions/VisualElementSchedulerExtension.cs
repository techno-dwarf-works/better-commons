using System;
using Better.Commons.Runtime.Utility;
using UnityEngine.UIElements;

namespace Better.Commons.EditorAddons.Extensions
{
    public static class VisualElementSchedulerExtension
    {
        public static IVisualElementScheduledItem OnElementAppear<TElement>(this IVisualElementScheduler self, VisualElement element, Action<TElement> action)
            where TElement : VisualElement
        {
            if (self == null)
            {
                throw new ArgumentNullException(nameof(self));
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }


            return self.Execute(OnExecute).Until(() => element.Q<TElement>() != null);

            void OnExecute()
            {
                var queriedElement = element.Q<TElement>();
                if (queriedElement == null)
                {
                    return;
                }

                action.Invoke(queriedElement);
            }
        }
    }
}