using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine.UIElements;

namespace Better.Commons.EditorAddons.Drawers
{
    public class ElementsContainer
    {
        public SerializedProperty Property { get; }
        private SortedSet<FieldVisualElement> _elements;
        private VisualElement _container;
        private IStyle _style;

        public IStyle ContainerStyle => _container.style;

        public ElementsContainer(SerializedProperty property)
        {
            Property = property;
            _elements = new SortedSet<FieldVisualElement>();
            _container = new VisualElement();
        }

        public FieldVisualElement CreateElementFrom(VisualElement element)
        {
            var item = new FieldVisualElement(element);
            _elements.Add(item);
            return item;
        }

        public FieldVisualElement CreateElement()
        {
            var item = new FieldVisualElement();
            _elements.Add(item);
            return item;
        }

        public void RemoveByTag(object tag)
        {
            _elements.RemoveWhere(x => x.ContainsTag(tag));
        }

        public IEnumerable<FieldVisualElement> GetByTag(object tag)
        {
            return _elements.Where(x => x.ContainsTag(tag));
        }
        public IEnumerable<FieldVisualElement> GetByTags(IEnumerable<object> tag)
        {
            return _elements.Where(x => x.ContainsAnyTags(tag));
        }

        public bool TryGetByTag(object tag, out FieldVisualElement element)
        {
            element = _elements.FirstOrDefault(x => x.ContainsTag(tag));
            return element != null;
        }

        public IEnumerable<FieldVisualElement> GetAll()
        {
            return _elements;
        }

        public void ClearElements()
        {
            _elements.Clear();
        }

        public VisualElement Generate()
        {
            foreach (var value in _elements)
            {
                var visualElement = value.Generate();
                _container.Add(visualElement);
            }

            return _container;
        }
    }
}