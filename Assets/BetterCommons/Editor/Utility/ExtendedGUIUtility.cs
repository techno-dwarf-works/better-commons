﻿using System;
using Better.Commons.EditorAddons.Enums;
using Better.Commons.EditorAddons.Extensions;
using Better.Commons.Runtime.Utility;
using UnityEditor;
using UnityEngine;

namespace Better.Commons.EditorAddons.Utility
{
    public static class ExtendedGUIUtility
    {
        private static float _spaceHeight = 6f;
        private static GUIStyle _helpBoxStyle;
        public static float SpaceHeight => _spaceHeight;

        public const int MouseButtonLeft = 0;
        public const int MouseButtonRight = 1;
        public const int MouseButtonMiddle = 2;

        /// <summary>
        /// Override for default Inspector HelpBox with RTF text
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        /// <param name="useSpace"></param>
        public static void HelpBox(string message, IconType type, bool useSpace = true)
        {
            var style = new GUIStyle(EditorStyles.helpBox) { richText = true, fontSize = 11 };
            HelpBox(message, type, style, useSpace);
        }

        /// <summary>
        /// Override for default Inspector HelpBox with Rich text
        /// </summary>
        /// <param name="message"></param>
        /// <param name="position"></param>
        /// <param name="type"></param>
        public static void HelpBox(Rect position, string message, IconType type)
        {
            HelpBox(message, position, type, CreateOrReturnHelpBoxStyle());
        }

        public static string NotSupportedMessage(string fieldName, Type fieldType, Type attributeType)
        {
            return
                $"Field {FormatBold(fieldName)} of type {FormatBold(fieldType.Name)} not supported for {FormatBold(attributeType.Name)}";
        }

        /// <summary>
        /// Not supported Inspector HelpBox with RTF text
        /// </summary>
        /// <param name="position"></param>
        /// <param name="label"></param>
        /// <param name="fieldType"></param>
        /// <param name="attributeType"></param>
        /// <param name="property"></param>
        /// <param name="offset"></param>
        public static void NotSupportedAttribute(Rect position, SerializedProperty property, GUIContent label, Type fieldType, Type attributeType, float offset)
        {
            if (property == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(property));
                return;
            }

            if (label == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(label));
                return;
            }

            if (fieldType == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(fieldType));
                return;
            }

            if (attributeType == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(attributeType));
                return;
            }

            HelpBoxFromRect(position, property, label, NotSupportedMessage(property.name, fieldType, attributeType), IconType.ErrorMessage, offset);
        }

        /// <summary>
        /// Not supported Inspector HelpBox with RTF text
        /// </summary>
        /// <param name="position"></param>
        /// <param name="label"></param>
        /// <param name="fieldType"></param>
        /// <param name="attributeType"></param>
        /// <param name="property"></param>
        public static void NotSupportedAttribute(Rect position, SerializedProperty property, GUIContent label, Type fieldType, Type attributeType)
        {
            var offset = EditorGUI.GetPropertyHeight(property, label, true) + SpaceHeight;
            NotSupportedAttribute(position, property, label, fieldType, attributeType, offset);
        }

        public static void HelpBoxFromRect(Rect position, SerializedProperty property, GUIContent label, string message, IconType messageType, float offset = 0)
        {
            if (property == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(property));
                return;
            }

            if (label == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(label));
                return;
            }

            var buffer = new Rect(position);

            var lab = new GUIContent(label);

            buffer.y += offset;

            label.image = lab.image;
            label.text = lab.text;
            label.tooltip = lab.tooltip;

            HelpBox(buffer, message, messageType);
        }

        public static string FormatBold(string text)
        {
            return $"<b>{text}</b>";
        }

        public static string FormatItalic(string text)
        {
            return $"<i>{text}</i>";
        }

        public static string FormatBoldItalic(string text)
        {
            return $"<b><i>{text}</i></b>";
        }

        public static string BeautifyFormat(string text)
        {
            return $"\"<b><i>{text}</i></b>\"";
        }

        /// <summary>
        /// Override for default Inspector HelpBox with style
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        /// <param name="style"></param>
        /// <param name="useSpace"></param>
        private static void HelpBox(string message, IconType type, GUIStyle style, bool useSpace)
        {
            if (style == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(style));
                return;
            }

            var icon = type.GetIconName();
            if (useSpace)
            {
                EditorGUILayout.Space(_spaceHeight);
            }

            EditorGUILayout.LabelField(GUIContent.none, EditorGUIUtility.TrTextContentWithIcon(message, icon), style);
        }

        /// <summary>
        /// Override for default Inspector HelpBox with style
        /// </summary>
        /// <param name="message"></param>
        /// <param name="position"></param>
        /// <param name="type"></param>
        /// <param name="style"></param>
        private static void HelpBox(string message, Rect position, IconType type, GUIStyle style)
        {
            var icon = type.GetIconName();
            var rect = new Rect(position);
            var withIcon = EditorGUIUtility.TrTextContentWithIcon(message, icon);
            rect.height = style.CalcHeight(withIcon, rect.width);
            EditorGUI.LabelField(rect, GUIContent.none, withIcon, style);
        }

        /// <summary>
        /// Override for default Inspector HelpBox with style
        /// </summary>
        /// <param name="message"></param>
        /// <param name="position"></param>
        /// <param name="style"></param>
        private static void HelpBox(Rect position, GUIContent message, GUIStyle style)
        {
            EditorGUI.LabelField(position, GUIContent.none, message, style);
        }

        /// <summary>
        /// Override for default Inspector HelpBox with style
        /// </summary>
        /// <param name="message"></param>
        /// <param name="position"></param>
        public static void HelpBox(Rect position, GUIContent message)
        {
            if (message == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(message));
                return;
            }

            HelpBox(position, message, CreateOrReturnHelpBoxStyle());
        }

        public static float GetHelpBoxHeight(float width, string message, IconType type)
        {
            var icon = type.GetIconName();
            var withIcon = EditorGUIUtility.TrTextContentWithIcon(message, icon);
            return CreateOrReturnHelpBoxStyle().CalcHeight(withIcon, width);
        }

        public static float GetHelpBoxHeight(string message, IconType type)
        {
            var icon = type.GetIconName();
            var withIcon = EditorGUIUtility.TrTextContentWithIcon(message, icon);
            return CreateOrReturnHelpBoxStyle().CalcHeight(withIcon, EditorGUIUtility.currentViewWidth);
        }

        public static float GetHelpBoxHeight(GUIContent message)
        {
            if (message == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(message));
                return 0;
            }

            return CreateOrReturnHelpBoxStyle().CalcHeight(message, EditorGUIUtility.currentViewWidth);
        }

        public static float GetHelpBoxHeight(string message)
        {
            return GetHelpBoxHeight(new GUIContent(message));
        }

        private static GUIStyle CreateOrReturnHelpBoxStyle()
        {
            if (_helpBoxStyle == null)
                _helpBoxStyle = new GUIStyle(EditorStyles.helpBox) { richText = true, fontSize = 11, wordWrap = true };
            return _helpBoxStyle;
        }

        public static int SelectionGrid(int selected, string[] texts, int xCount, GUIStyle style,
            params GUILayoutOption[] options)
        {
            var bufferSelected = selected;
            GUILayout.BeginVertical();
            var count = 0;
            var isHorizontal = false;

            for (var index = 0; index < texts.Length; index++)
            {
                var text = texts[index];

                if (count == 0)
                {
                    GUILayout.BeginHorizontal();
                    isHorizontal = true;
                }

                count++;
                if (GUILayout.Toggle(bufferSelected == index, text, new GUIStyle(style), options))
                    bufferSelected = index;

                if (count == xCount)
                {
                    GUILayout.EndHorizontal();
                    count = 0;
                    isHorizontal = false;
                }
            }

            if (isHorizontal) GUILayout.EndHorizontal();
            GUILayout.EndVertical();
            return bufferSelected;
        }

        public static bool IsLeftButtonDown()
        {
            return IsMouseButton(EventType.MouseDown, MouseButtonLeft);
        }

        public static bool IsRightButtonDown()
        {
            return IsMouseButton(EventType.MouseDown, MouseButtonRight);
        }

        public static bool IsMiddleButtonDown()
        {
            return IsMouseButton(EventType.MouseDown, MouseButtonMiddle);
        }

        public static bool IsLeftButtonUp()
        {
            return IsMouseButton(EventType.MouseUp, MouseButtonLeft);
        }

        public static bool IsRightButtonUp()
        {
            return IsMouseButton(EventType.MouseUp, MouseButtonRight);
        }

        public static bool IsMiddleButtonUp()
        {
            return IsMouseButton(EventType.MouseUp, MouseButtonMiddle);
        }

        public static bool IsMouseButton(EventType eventType, int mouseButton)
        {
            var current = Event.current;
            return current.type == eventType && current.button == mouseButton && current.isMouse;
        }

        public static Rect GetClickRect(Rect position, GUIContent label)
        {
            if (label == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(label));
                return Rect.zero;
            }

            var copy = position;
            copy.size = GUIStyle.none.CalcSize(label);
            return copy;
        }

        public static bool IsClickedAt(Rect position)
        {
            var current = Event.current;
            var contains = position.Contains(current.mousePosition);
            if (contains && IsLeftButtonDown())
            {
                return true;
            }

            return false;
        }
    }
}