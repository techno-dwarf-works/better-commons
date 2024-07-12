using System.Collections.Generic;
using Better.Commons.Runtime.Utility;

namespace Better.Commons.EditorAddons.Drawers.Container
{
    public class SubPrewarmElement : PrewarmElement
    {
        private readonly HashSet<object> _tags;

        public SubPrewarmElement() : base()
        {
            _tags = new HashSet<object>();
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
    }
}