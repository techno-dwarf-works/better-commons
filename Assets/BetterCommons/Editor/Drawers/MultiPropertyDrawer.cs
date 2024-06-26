﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Better.Commons.EditorAddons.Drawers.Attributes;
using Better.Commons.EditorAddons.Drawers.Base;
using Better.Commons.Runtime.Comparers;
using Better.Commons.Runtime.Drawers.Attributes;
using Better.Commons.Runtime.Extensions;
using Better.Internal.Core.Runtime;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace Better.Commons.EditorAddons.Drawers
{
    [CustomPropertyDrawer(typeof(MultiPropertyAttribute), true)]
    public sealed class MultiPropertyDrawer : PropertyDrawer
    {
        private static Dictionary<Type, Type> _fieldDrawers = new Dictionary<Type, Type>(AssignableFromComparer.Instance);
        private bool _initialized;
        private FieldDrawer _rootDrawer;

        [InitializeOnLoadMethod]
        [DidReloadScripts]
        private static void OnInitialize()
        {
            var types = typeof(FieldDrawer).GetAllInheritedTypesWithoutUnityObject();
            foreach (var type in types)
            {
                var atts = type.GetCustomAttributes<MultiCustomPropertyDrawer>();
                foreach (var att in atts)
                {
                    if (att == null) continue;
                    if (!_fieldDrawers.ContainsKey(att.ForAttribute))
                    {
                        _fieldDrawers.Add(att.ForAttribute, type);
                    }
                    else if (att.Override)
                    {
                        _fieldDrawers[att.ForAttribute] = type;
                    }
                }
            }
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            TryInitialize();

            if (_rootDrawer == null)
            {
                EditorGUI.PropertyField(position, property, label, true);
                return;
            }

            if (_rootDrawer.PreDrawInternal(ref position, property, label))
            {
                _rootDrawer.DrawFieldInternal(position, property, label);
            }

            _rootDrawer.PostDrawInternal(position, property, label);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            TryInitialize();
            if (_rootDrawer == null)
            {
                return EditorGUI.GetPropertyHeight(property, label, true);
            }

            var height = _rootDrawer.GetPropertyHeightInternal(property, label);
            if (height.IsValid)
            {
                return height.Value + EditorGUI.GetPropertyHeight(property, label, true);
            }

            return height.Value;
        }

        private IOrderedEnumerable<MultiPropertyAttribute> GetAttributes(FieldInfo field)
        {
            return field.GetCustomAttributes<MultiPropertyAttribute>().OrderBy(att => att.order);
        }

        private void TryInitialize()
        {
            if (_initialized) return;

            _initialized = true;
            var attributes = GetAttributes(fieldInfo);
            var drawers = new List<FieldDrawer>();
            var param = new object[] { fieldInfo, null };
            foreach (var propertyAttribute in attributes)
            {
                if (!_fieldDrawers.TryGetValue(propertyAttribute.GetType(), out var drawerType)) continue;

                param[1] = propertyAttribute;
                var drawer = (FieldDrawer)Activator.CreateInstance(drawerType, Defines.ConstructorFlags, null, param, null);
                drawers.Add(drawer);
            }

            if (drawers.Count <= 0) return;

            _rootDrawer = drawers[0];
            if (drawers.Count < 2)
            {
                drawers[0].Initialize(null);
            }
            else
            {
                for (var index = 0; index < drawers.Count - 1; index++)
                {
                    drawers[index].Initialize(drawers[index + 1]);
                }

                drawers[drawers.Count - 1].Initialize(null);
            }
        }
    }
}