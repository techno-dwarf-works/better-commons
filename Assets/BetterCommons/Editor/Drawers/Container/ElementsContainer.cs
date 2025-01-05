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
        public List<ContainerPrewarmElement> ContainersPrewarmChildren { get; }

        public event Action<ElementsContainer> SerializedObjectChanged;
        public event Action<ElementsContainer> SerializedPropertyChanged;

        public const string Tag = nameof(ElementsContainer);

        public ElementsContainer(SerializedProperty serializedProperty)
        {
            Used = false;
            SerializedProperty = serializedProperty;
            RootElement = CreateRootElement();

            var classStyle = StyleDefinition.CombineSubState(StyleDefinition.BetterPropertyClass, nameof(ElementsContainer));
            RootElement.AddToClassList(classStyle);
            RootElement.TrackSerializedObjectValue(SerializedObject, OnSerializedObjectChanged);

            LabelContainer = new LabelContainer(serializedProperty.displayName);
            ContainersPrewarmChildren = new List<ContainerPrewarmElement>();

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

            CreateElementFrom(CoreElement);

            propertyField.name = $"{nameof(ElementsContainer)}_{SerializedProperty.propertyPath}";
            propertyField.RegisterCallback<SerializedPropertyChangeEvent>(OnSerializedPropertyChanged);
            propertyField.RegisterCallback<AttachToPanelEvent>(ScheduleAttachToPanel);
            propertyField.style.FlexGrow(StyleDefinition.OneStyleFloat);
        }

        private VisualElement CreateRootElement()
        {
            var rootElement = new VisualElement();
            rootElement.name = $"{nameof(ElementsContainer)}";
            return rootElement;
        }

        public SubPrewarmElement CreateElementFrom(VisualElement element, string tag = Tag)
        {
            if(!TryGetByTag(tag, out var containerPrewarmElement))
            {
                containerPrewarmElement = new ContainerPrewarmElement();
                containerPrewarmElement.AddTag(tag);
                ContainersPrewarmChildren.Add(containerPrewarmElement);
                RootElement.Add(containerPrewarmElement);
            }
            
            var item = new SubPrewarmElement();
            item.Add(element);
            containerPrewarmElement.Add(item);
            return item;
        }
        
        public bool TryGetByTag(object containerTag, object subTag, out SubPrewarmElement element)
        {
            if (!TryGetByTag(containerTag, out var bufferElement))
            {
                element = null;
                return false;
            }
            
            return bufferElement.TryGetByTag(subTag, out element);
        }

        public IEnumerable<ContainerPrewarmElement> GetByTags(IEnumerable<object> tag)
        {
            return ContainersPrewarmChildren.Where(x => x.ContainsAnyTags(tag));
        }

        public bool TryGetByTag(object tag, out ContainerPrewarmElement element)
        {
            element = ContainersPrewarmChildren.FirstOrDefault(x => x.ContainsTag(tag));
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

        private void ScheduleAttachToPanel(AttachToPanelEvent changedEvent)
        {
            if (changedEvent.target is not PropertyField element) return;

            element.schedule.Execute(() => OnAttachToPanel(element));
        }

        private void OnAttachToPanel(VisualElement element)
        {
            var propertyPath = SerializedProperty.propertyPath;
            var propertyFields = element.Query<PropertyField>().Where(field => field.bindingPath.CompareOrdinal(propertyPath)).Build();
            var parentField = propertyFields.First();
            var labels = parentField.Query<Label>().Class(PropertyField.labelUssClassName).Where(field =>
            {
                var firstAncestor = field.GetFirstAncestorOfType<PropertyField>();
                return firstAncestor != null && firstAncestor.Equals(parentField);
            });
            var label = labels.First();
            if (label != null)
            {
                LabelContainer.Setup(label);
            }
            else
            {
                LabelContainer.SoftReset();
            }
        }
    }
}