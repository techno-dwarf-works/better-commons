using System;
using Better.Commons.EditorAddons.Enums;
using Better.Commons.EditorAddons.Extensions;
using Better.Commons.Runtime.Extensions;
using Better.Commons.Runtime.Utility;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Better.Commons.EditorAddons.Utility
{
    public static class VisualElementUtility
    {
        private const int MouseButtonLeft = 0;
        private const int MouseButtonRight = 1;
        private const int MouseButtonMiddle = 2;

        private static readonly HelpBox EmptyHelpBox = new HelpBox();

        public const string NotSupportedTag = nameof(NotSupportedTag);

        private static string NotSupportedMessage(string fieldName, Type fieldType, Type attributeType)
        {
            return $"Field {fieldName.FormatBold()} of type {fieldType.Name.FormatBold()} not supported for {attributeType.Name.FormatBold()}";
        }

        public static HelpBox NotSupportedBox(SerializedProperty property, Type fieldType, Type attributeType)
        {
            if (property == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(property));
                return EmptyHelpBox;
            }

            if (fieldType == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(fieldType));
                return EmptyHelpBox;
            }

            if (attributeType == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(attributeType));
                return EmptyHelpBox;
            }

            var message = NotSupportedMessage(property.name, fieldType, attributeType);
            return HelpBox(message, HelpBoxMessageType.Error);
        }

        public static HelpBox HelpBox(string message, HelpBoxMessageType type)
        {
            if (message == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(message));
                return EmptyHelpBox;
            }

            return new HelpBox(message, type);
        }
        
        public static HelpBox HelpBox(string message)
        {
            if (message == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(message));
                return EmptyHelpBox;
            }

            return HelpBox(message, HelpBoxMessageType.None);
        }

        public static bool IsLeftButton(ClickEvent clickEvent)
        {
            return IsMouseButton(clickEvent, MouseButtonLeft);
        }

        public static bool IsRightButton(ClickEvent clickEvent)
        {
            return IsMouseButton(clickEvent, MouseButtonRight);
        }

        public static bool IsMiddleButton(ClickEvent clickEvent)
        {
            return IsMouseButton(clickEvent, MouseButtonMiddle);
        }

        public static bool IsMouseButton(ClickEvent clickEvent, int mouseButton)
        {
            return clickEvent.button == mouseButton;
        }

        public static Label CreateLabel(string text)
        {
            var label = new Label(text);
            label.AddToClassList(PropertyField.labelUssClassName);
            label.style
                .MarginBottom(StyleDefinition.OneStyleLength)
                .MarginTop(StyleDefinition.OneStyleLength)
                .MarginLeft(new StyleLength(3f));
            return label;
        }
        
        public static Label CreateLabelFor(SerializedProperty serializedProperty)
        {
            var label = CreateLabel(serializedProperty.displayName);
            label.style.FlexGrow(StyleDefinition.OneStyleFloat);
            return label;
        }

        public static VisualElement CreateHorizontalGroup()
        {
            var element = new VisualElement();
            element.style.flexDirection = new StyleEnum<FlexDirection>(FlexDirection.Row);
            return element;
        }

        public static VisualElement CreateVerticalGroup()
        {
            var element = new VisualElement();
            element.style.flexDirection = FlexDirection.Column;
            return element;
        }

        public static Image CreateLabelIcon(IconType iconType)
        {
            var icon = iconType.GetIcon();
            return CreateLabelIcon(icon);
        }
        
        public static Image CreateLabelIcon(Texture icon)
        {
            var image = new Image
            {
                image = icon
            };

            image.style.Height(StyleDefinition.SingleLineHeight)
                .Width(StyleDefinition.SingleLineHeight)
                .AlignSelf(new StyleEnum<Align>(Align.Center));

            return image;
        }
    }
}