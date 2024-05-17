using System;
using System.Collections.Generic;
using System.Linq;
using Better.Commons.Runtime.Utility;
using UnityEngine.UIElements;

namespace Better.Commons.EditorAddons.Drawers
{
    public class FieldVisualElement : IComparable<FieldVisualElement>
    {
        private readonly VisualElement _root;

        private readonly HashSet<object> _tags;

        public List<VisualElement> Elements { get; private set; }
        public int Order { get; set; }
        public IStyle RootStyle => _root.style;

        public FieldVisualElement()
        {
            Elements = new List<VisualElement>();
            _root = new VisualElement();
            _tags = new HashSet<object>();
        }

        public FieldVisualElement(VisualElement element) : this()
        {
            Elements.Add(element);
        }

        public bool ContainsTag(object value)
        {
            return _tags != null && _tags.Contains(value);
        }

        public bool ContainsAllTags(IEnumerable<object> values)
        {
            if (values == null)
            {
                var message = $"{nameof(values)} cannot be null";
                DebugUtility.LogException(message);
                return false;
            }

            foreach (var value in values)
            {
                if (!ContainsTag(value))
                {
                    return false;
                }
            }

            return true;
        }

        public bool ContainsAnyTags(IEnumerable<object> values)
        {
            if (values == null)
            {
                var message = $"{nameof(values)} cannot be null";
                DebugUtility.LogException(message);
                return false;
            }

            foreach (var value in values)
            {
                if (ContainsTag(value))
                {
                    return true;
                }
            }

            return false;
        }

        public void AddTag(object value)
        {
            if (value == null)
            {
                var message = $"{nameof(value)} cannot be null";
                DebugUtility.LogException(message);
                return;
            }

            if (!ContainsTag(value))
            {
                _tags.Add(value);
            }
        }

        public void AddTags(IEnumerable<object> values)
        {
            if (values == null)
            {
                var message = $"{nameof(values)} cannot be null";
                DebugUtility.LogException(message);
                return;
            }

            foreach (var value in values)
            {
                AddTag(value);
            }
        }

        public void RemoveTag(object value)
        {
            _tags?.Remove(value);
        }

        public void RemoveTags(IEnumerable<object> values)
        {
            if (values == null)
            {
                var message = $"{nameof(values)} cannot be null";
                DebugUtility.LogException(message);
                return;
            }

            foreach (var value in values)
            {
                RemoveTag(value);
            }
        }

        public int CompareTo(FieldVisualElement other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return Order.CompareTo(other.Order);
        }

        public VisualElement Generate()
        {
            foreach (var visualElement in Elements)
            {
                _root.Add(visualElement);
            }

            return _root;
        }
    }

    public class Container
    {
        private SortedSet<FieldVisualElement> _elements;
        private VisualElement _container;
        private IStyle _style;

        public IStyle ContainerStyle => _container.style;

        public Container()
        {
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

        public void RemoveBy(object tag)
        {
            _elements.RemoveWhere(x => x.ContainsTag(tag));
        }

        public IEnumerable<FieldVisualElement> GetElements(object tag)
        {
            return _elements.Where(x => x.ContainsTag(tag));
        }

        public IEnumerable<FieldVisualElement> GetAllElements()
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