using System;
using Better.Commons.EditorAddons.Drawers;
using UnityEngine.UIElements;

namespace Better.Commons.EditorAddons.Utility
{
    public static class ElementContainerExtensions
    {
        public static void AddNotSupportedBox(this ElementsContainer container, Type fieldType, Type attributeType)
        {
            var helpBox = VisualElementUtility.NotSupportedBox(container.Property, fieldType, attributeType);
            if (container.TryGetByTag(VisualElementUtility.NotSupportedTag, out var element))
            {
                element.Elements.Add(helpBox);
            }
            else
            {
                element = container.CreateElementFrom(helpBox);
                element.AddTag(VisualElementUtility.NotSupportedTag);
            }
        }

        public static FieldVisualElement GetOrAddHelpBox(this ElementsContainer container, string message, string tag, HelpBoxMessageType messageType)
        {
            if (!container.TryGetByTag(tag, out var element))
            {
                var helpBox = VisualElementUtility.HelpBox(message, messageType);
                element = container.CreateElementFrom(helpBox);
                element.AddTag(tag);
            }

            return element;
        }
    }
}