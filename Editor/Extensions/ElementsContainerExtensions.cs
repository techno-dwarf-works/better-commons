using System;
using Better.Commons.EditorAddons.Drawers.Container;
using Better.Commons.EditorAddons.Enums;
using Better.Commons.EditorAddons.Utility;
using Better.Commons.Runtime.Extensions;
using UnityEditor;
using UnityEngine.UIElements;

namespace Better.Commons.EditorAddons.Extensions
{
    public static class ElementsContainerExtensions
    {
        //TODO: Add validation
        public static void AddClickableIcon(this ElementsContainer self, IconType iconType, SerializedProperty property,
            EventCallback<ClickEvent, (SerializedProperty, Image)> action)
        {
            var image = self.AddIcon(iconType);
            image.RegisterCallback(action, (property, image));
        }

        public static Image AddIcon(this ElementsContainer self, IconType iconType)
        {
            var image = VisualElementUtility.CreateLabelIcon(iconType);

            var element = self.CoreElement;
            element.style.FlexDirection(new StyleEnum<FlexDirection>(FlexDirection.Row));
            element.Insert(0, image);
            return image;
        }

        public static void AddNotSupportedBox(this ElementsContainer self, Type fieldType, Type attributeType)
        {
            var helpBox = VisualElementUtility.NotSupportedBox(self.SerializedProperty, fieldType, attributeType);
            if (self.TryGetByTag(VisualElementUtility.NotSupportedTag, out var element))
            {
                element.Add(helpBox);
            }
            else
            {
                element = self.CreateElementFrom(helpBox);
                element.AddTag(VisualElementUtility.NotSupportedTag);
            }
        }

        public static SubPrewarmElement GetOrAddHelpBox(this ElementsContainer self, string message, object tag, HelpBoxMessageType messageType)
        {
            if (!self.TryGetByTag(tag, out var element))
            {
                var helpBox = VisualElementUtility.HelpBox(message, messageType);
                element = self.CreateElementFrom(helpBox);
                element.AddTag(tag);
            }

            return element;
        }
    }
}