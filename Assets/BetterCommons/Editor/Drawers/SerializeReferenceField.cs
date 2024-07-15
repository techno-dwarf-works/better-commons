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
        private Label _bufferLabel;
        public PropertyField PropertyField { get; set; }

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
            if (TryCreateBufferLabel(property, out var bufferLabel))
            {
                _bufferLabel = bufferLabel;
                Insert(0, _bufferLabel);
            }

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
                    if (_bufferLabel != null)
                    {
                        _bufferLabel.RemoveFromHierarchy();
                        _bufferLabel = null;
                    }
                    
                    if (TryCreateBufferLabel(property, out var label))
                    {
                        _bufferLabel = label;
                        Insert(0, _bufferLabel);
                    }
                }

                using (var e = ReferenceTypeChangeEvent.GetPooled(_referenceType, newType))
                {
                    e.target = this;
                    panel?.visualTree.SendEvent(e);
                }

                _referenceType = newType;
            }

            property.Dispose();
        }

        private bool TryCreateBufferLabel(SerializedProperty property, out Label label)
        {
            var query = this.Query<SerializeReferenceField>().Last();
            if (query == this)
            {
                if (property.managedReferenceFullTypename.IsNullOrEmpty() || !property.hasVisibleChildren)
                {
                    label = VisualElementUtility.CreateLabel(PropertyField.label);
                    label.AddToClassList(StyleDefinition.CombineSubState(nameof(SerializeReferenceField), "dummy-label"));
                    return true;
                }
            }

            label = null;
            return false;
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