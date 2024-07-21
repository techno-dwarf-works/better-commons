using System;
using Better.Commons.EditorAddons.Enums;
using Better.Commons.EditorAddons.Utility;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Better.Commons.EditorAddons.Extensions
{
    public static class VisualElementExtension
    {
        public static void OnElementAppear<TElement>(this VisualElement self, Action<TElement> action) where TElement : VisualElement
        {
            self.OnElementAppear(self, action);
        }
        
        public static void AddClickedEvent(this VisualElement self, SerializedProperty property, EventCallback<ClickEvent, SerializedProperty> action)
        {
            self.RegisterCallback(action, property);
        }

        public static void AddIconClickedEvent(this VisualElement self, SerializedProperty property, EventCallback<ClickEvent, SerializedProperty> action)
        {
            var image = self.Q<Image>();
            AddClickedEvent(image, property, action);
        }

        public static void AddClickableIcon(this VisualElement self, IconType iconType, SerializedProperty property,
            EventCallback<ClickEvent, (SerializedProperty, Image)> action)
        {
            var image = AddIcon(self, iconType);
            image.RegisterCallback(action, (property, image));
        }

        public static Image AddIcon(this VisualElement self, IconType iconType)
        {
            var image = VisualElementUtility.CreateLabelIcon(iconType);
            self.Insert(0, image);
            return image;
        }
        
        public static Image AddIcon(this VisualElement self, Texture texture)
        {
            var image = VisualElementUtility.CreateLabelIcon(texture);
            self.Insert(0, image);
            return image;
        }
    }
}