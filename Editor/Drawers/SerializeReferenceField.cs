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

            PropertyField = CreatePropertyField(property, label);

#if !UNITY_2022_2_OR_NEWER
            if (IsLastSerializeField() && TryCreateBufferLabel(property, out var bufferLabel))
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
            var isLast = IsLastSerializeField();
            if (!isLast && _bufferLabel != null)
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
                    if (isLast && TryCreateBufferLabel(property, out var label))
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

                //Fix: fixing SerializedPropertyChangeEvent not been sent when set new type to null
                if (newType.IsNullOrEmpty())
                {
                    using (var e = SerializedPropertyChangeEvent.GetPooled(property))
                    {
                        e.target = PropertyField;
                        panel?.visualTree.SendEvent(e);
                    }
                }

                _referenceType = newType;
            }

            property.Dispose();
        }


#if !UNITY_2022_2_OR_NEWER

        private bool IsLastSerializeField()
        {
            var query = this.Query<SerializeReferenceField>().Last();
            return query == this;
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
#endif

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