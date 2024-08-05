using System;
using System.Collections.Generic;
using System.Linq;
using Better.Commons.EditorAddons.Helpers;
using Better.Commons.EditorAddons.Utility;
using Better.Commons.Runtime.Extensions;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Better.Commons.EditorAddons.Drawers.Container
{
    public class ElementsContainer
    {
        public VisualElement RootElement { get; set; }
        public PrewarmElement CoreElement { get; }
        public bool Used { get; private set; }
        public SerializedObject SerializedObject => SerializedProperty.serializedObject;
        public SerializedProperty SerializedProperty { get; }
        public LabelContainer LabelContainer { get; }
        public List<SubPrewarmElement> PrewarmChildren { get; }

        public event Action<ElementsContainer> SerializedObjectChanged;
        public event Action<ElementsContainer> SerializedPropertyChanged;

        public ElementsContainer(SerializedProperty serializedProperty)
        {
            Used = false;
            SerializedProperty = serializedProperty;
            RootElement = CreateRootElement();

            var classStyle = StyleDefinition.CombineSubState(StyleDefinition.BetterPropertyClass, nameof(ElementsContainer));
            RootElement.AddToClassList(classStyle);
            RootElement.TrackSerializedObjectValue(SerializedObject, OnSerializedObjectChanged);

            LabelContainer = new LabelContainer(serializedProperty.displayName);
            PrewarmChildren = new List<SubPrewarmElement>();

            CoreElement = new PrewarmElement();
            PropertyField propertyField;
            if (serializedProperty.propertyType == SerializedPropertyType.ManagedReference)
            {
                var referenceField = new SerializeReferenceField(serializedProperty);
                propertyField = referenceField.PropertyField;
                CoreElement.Add(referenceField);
            }
            else
            {
                propertyField = new PropertyField(serializedProperty);
                CoreElement.Add(propertyField);
            }

            RootElement.Add(CoreElement);
            propertyField.RegisterCallback<SerializedPropertyChangeEvent>(OnSerializedPropertyChanged);
            propertyField.RegisterCallback<GeometryChangedEvent>(ScheduleUpdateGeometry);
            propertyField.style.FlexGrow(StyleDefinition.OneStyleFloat);
        }

        private VisualElement CreateRootElement()
        {
            var rootElement = new VisualElement();
            rootElement.name = $"{nameof(ElementsContainer)}";
            return rootElement;
        }

        public SubPrewarmElement CreateElementFrom(VisualElement element)
        {
            var item = new SubPrewarmElement();
            item.Add(element);
            PrewarmChildren.Add(item);
            RootElement.Add(item);
            return item;
        }

        public SubPrewarmElement GetByTag(object tag)
        {
            if (TryGetByTag(tag, out var fieldVisualElement))
            {
                return fieldVisualElement;
            }

            throw new KeyNotFoundException($"Element with tag: {tag} not found");
        }

        public IEnumerable<SubPrewarmElement> GetByTags(IEnumerable<object> tag)
        {
            return PrewarmChildren.Where(x => x.ContainsAnyTags(tag));
        }

        public bool TryGetByTag(object tag, out SubPrewarmElement element)
        {
            element = PrewarmChildren.FirstOrDefault(x => x.ContainsTag(tag));
            return element != null;
        }

        internal void Use()
        {
            Used = true;
        }

        private void OnSerializedObjectChanged(SerializedObject obj)
        {
            SerializedObjectChanged?.Invoke(this);
        }

        private void OnSerializedPropertyChanged(SerializedPropertyChangeEvent changeEvent)
        {
            SerializedPropertyChanged?.Invoke(this);
        }

        private void ScheduleUpdateGeometry(GeometryChangedEvent changedEvent)
        {
            if (changedEvent.target is not PropertyField element) return;
            {
                element.schedule.Execute(() => OnGeometryChanged(element));
            }
        }

        private void OnGeometryChanged(VisualElement element)
        {
            var label = element.Q<Label>(className: PropertyField.labelUssClassName);
            if (label != null)
            {
                LabelContainer.Setup(label);
            }
            else
            {
                LabelContainer.Reset();
            }
        }
    }
}