using System;
using System.Collections.Generic;
using Better.Commons.EditorAddons.Utility;
using Better.Commons.Runtime.Extensions;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace Better.Commons.EditorAddons.Drawers
{
    public class SerializeReferenceField : VisualElement
    {
        private static readonly HashSet<SerializedObject> _recentSerializedObjects = new HashSet<SerializedObject>();

        private string _path;
        private SerializedObject _serializedObject;
        private string _referenceType;

        private long _updateInterval = 5024;
        private readonly IVisualElementScheduledItem _updateSchedule;

#if !UNITY_2022_2_OR_NEWER
        private Label _bufferLabel;
#endif

        public PropertyField PropertyField { get; private set; }

        public long UpdateInterval
        {
            get => _updateInterval;
            set
            {
                _updateInterval = Math.Max(value, 100);
                _updateSchedule.Every(_updateInterval);
            }
        }

        public SerializedPropertyType PropertyType { get; private set; }

        public SerializeReferenceField(SerializedProperty property) : this(property, string.Empty)
        {
        }

        public SerializeReferenceField(SerializedProperty property, string label)
        {
            AddToClassList(StyleDefinition.BetterPropertyClass);
            pickingMode = PickingMode.Ignore;

            if (property.propertyType != SerializedPropertyType.ManagedReference)
            {
                Debug.LogError("Property must be a ManagedReference");
                return;
            }

            _path = property.propertyPath;
            _serializedObject = property.serializedObject;
            _referenceType = property.managedReferenceFullTypename;

            PropertyType = property.propertyType;
            PropertyField = CreatePropertyField(property, label);

#if !UNITY_2022_2_OR_NEWER
            var hasLabel = HasLabel(property);
            if (!hasLabel && TryCreateBufferLabel(property, out var bufferLabel))
            {
                _bufferLabel = bufferLabel;
                Insert(0, _bufferLabel);
            }
#endif

            Add(PropertyField);

            _updateSchedule = schedule.Execute(Update).Every(_updateInterval);
            style.FlexGrow(StyleDefinition.OneStyleFloat);
            RegisterCallback<AttachToPanelEvent>(OnAttachToPanel);
            RegisterCallback<DetachFromPanelEvent>(OnDetachFromPanel);

            this.Bind(_serializedObject);
        }

        private PropertyField CreatePropertyField(SerializedProperty property, string label)
        {
            if (label.IsNullOrEmpty())
            {
                label = property.displayName;
            }

            var field = new PropertyField(property, label);
            var propertyClass = StyleDefinition.CombineSubState(StyleDefinition.BetterPropertyClass, nameof(PropertyField));
            field.AddToClassList(propertyClass);

            return field;
        }

        private void Update()
        {
            var property = _serializedObject.FindProperty(_path);
            if (property == null || property.propertyType != SerializedPropertyType.ManagedReference)
            {
                return;
            }

#if !UNITY_2022_2_OR_NEWER
            var hasLabel = HasLabel(property);
            if (hasLabel && _bufferLabel != null)
            {
                _bufferLabel.RemoveFromHierarchy();
                _bufferLabel = null;
            }
#endif

            var newType = property.managedReferenceFullTypename;

            if (_referenceType != newType)
            {
                try
                {
                    _serializedObject.ApplyModifiedProperties();
                    this.Bind(_serializedObject);
                }
                catch
                {
                    // ignored
                }
                finally
                {
#if !UNITY_2022_2_OR_NEWER
                    if (!hasLabel && TryCreateBufferLabel(property, out var label))
                    {
                        _bufferLabel = label;
                        Insert(0, _bufferLabel);
                    }
#endif
                }

                using (var e = ReferenceTypeChangeEvent.GetPooled(_referenceType, newType))
                {
                    e.target = this;
                    panel?.visualTree.SendEvent(e);
                }

                //Fix: fixing SerializedPropertyChangeEvent not been sent when set new type to null or time has no sub properties
                using (var e = SerializedPropertyChangeEvent.GetPooled(property))
                {
                    e.target = PropertyField;
                    panel?.visualTree.SendEvent(e);
                }

                _referenceType = newType;
            }

            property.Dispose();
        }

        private void ReactToEditorChange()
        {
            UpdateSerializedObjectIfNeeded();
            Update();
        }

        private void UpdateSerializedObjectIfNeeded()
        {
            if (_recentSerializedObjects.Contains(_serializedObject))
                return;

            _serializedObject.Update();

            var isTheFirstAddition = _recentSerializedObjects.Count == 0;
            _recentSerializedObjects.Add(_serializedObject);

            if (isTheFirstAddition)
                EditorApplication.delayCall += ClearRecentObjects;
        }

        private bool HasLabel(SerializedProperty property)
        {
            var query = this.Query<SerializeReferenceField>().Last();
            return query == this && ValidateBaseField(property);
        }

        private bool ValidateBaseField(SerializedProperty property)
        {
            var propertyType = property.propertyType;
            switch (propertyType)
            {
                case SerializedPropertyType.Generic:
                    return property.isArray && HasValidLabel<IntegerField>();
                case SerializedPropertyType.Integer:
                    return HasValidLabel<IntegerField>();
                case SerializedPropertyType.Boolean:
                    return HasValidLabel<Toggle>();
                case SerializedPropertyType.Float:
                    return HasValidLabel<FloatField>();
                case SerializedPropertyType.String:
                    return HasValidLabel<TextField>();
                case SerializedPropertyType.Color:
                    return HasValidLabel<ColorField>();
                case SerializedPropertyType.ObjectReference:
                    return HasValidLabel<ObjectField>();
                case SerializedPropertyType.LayerMask:
                    return HasValidLabel<LayerMaskField>();
                case SerializedPropertyType.Enum:
                    return HasValidLabel<PopupField<string>>();
                case SerializedPropertyType.Vector2:
                    return HasValidLabel<Vector2Field>();
                case SerializedPropertyType.Vector3:
                    return HasValidLabel<Vector3Field>();
                case SerializedPropertyType.Vector4:
                    return HasValidLabel<Vector4Field>();
                case SerializedPropertyType.Rect:
                    return HasValidLabel<RectField>();
                case SerializedPropertyType.ArraySize:
                    return HasValidLabel<IntegerField>();
                case SerializedPropertyType.Character:
                    return HasValidLabel<TextField>();
                case SerializedPropertyType.AnimationCurve:
                    return HasValidLabel<CurveField>();
                case SerializedPropertyType.Bounds:
                    return HasValidLabel<BoundsField>();
                case SerializedPropertyType.Gradient:
                    return HasValidLabel<GradientField>();
                case SerializedPropertyType.Quaternion:
                    return HasValidLabel<Vector4Field>();
                case SerializedPropertyType.ExposedReference:
                    return false;
                case SerializedPropertyType.FixedBufferSize:
                    return false;
                case SerializedPropertyType.Vector2Int:
                    return HasValidLabel<Vector2IntField>();
                case SerializedPropertyType.Vector3Int:
                    return HasValidLabel<Vector3IntField>();
                case SerializedPropertyType.RectInt:
                    return HasValidLabel<RectIntField>();
                case SerializedPropertyType.BoundsInt:
                    return HasValidLabel<BoundsIntField>();
                case SerializedPropertyType.Hash128:
                    return HasValidLabel<Hash128Field>();
                default:
                    return false;
            }
        }

        private bool HasValidLabel<TValueType>()
        {
            if (TryGetBaseField<TValueType>(out var baseField))
            {
                return baseField.labelElement != null;
            }

            return false;
        }

        private bool TryGetBaseField<TValueType>(out BaseField<TValueType> baseField)
        {
            baseField = PropertyField.Query().Children<BaseField<TValueType>>().First();
            var validParent = baseField.parent == PropertyField;
            if (!validParent)
            {
                baseField = null;
            }

            return validParent;
        }

        private bool TryCreateBufferLabel(SerializedProperty property, out Label label)
        {
            if (property.managedReferenceFullTypename.IsNullOrEmpty() || !property.hasVisibleChildren)
            {
                label = VisualElementUtility.CreateLabel(PropertyField.label);
                label.AddToClassList(PropertyField.labelUssClassName);
                label.name = property.propertyPath;
                label.AddToClassList(StyleDefinition.CombineSubState(nameof(SerializeReferenceField), "dummy-label"));
                return true;
            }

            label = null;
            return false;
        }

        private static void ClearRecentObjects()
        {
            _recentSerializedObjects.Clear();
        }

        private void OnAttachToPanel(AttachToPanelEvent evt)
        {
            Undo.undoRedoPerformed -= ReactToEditorChange;
            Undo.undoRedoPerformed += ReactToEditorChange;
            Undo.postprocessModifications -= OnPropertyModification;
            Undo.postprocessModifications += OnPropertyModification;

            ReactToEditorChange();
        }

        private void OnDetachFromPanel(DetachFromPanelEvent evt)
        {
            Undo.undoRedoPerformed -= ReactToEditorChange;
            Undo.postprocessModifications -= OnPropertyModification;
        }

        private bool TryNotify(PropertyModification modification, Object target)
        {
            if (modification.target != target) return false;
            ReactToEditorChange();
            return true;
        }

        private UndoPropertyModification[] OnPropertyModification(UndoPropertyModification[] modifications)
        {
            if (!_serializedObject.isEditingMultipleObjects)
            {
                foreach (var mod in modifications)
                {
                    if (TryNotify(mod.previousValue, _serializedObject.targetObject))
                    {
                        return modifications;
                    }
                }
            }
            else
            {
                foreach (var target in _serializedObject.targetObjects)
                {
                    foreach (var mod in modifications)
                    {
                        if (TryNotify(mod.previousValue, target))
                        {
                            return modifications;
                        }
                    }
                }
            }

            return modifications;
        }
    }
}