using System;
using System.Collections.Generic;

namespace Better.Commons.EditorAddons.Drawers.HandlersTypeCollection
{
    public class AttributeHandlersTypeCollection : BaseHandlersTypeCollection
    {
        private readonly Dictionary<Type, Type> _dictionary;
        
        public AttributeHandlersTypeCollection()
        {
            _dictionary = new Dictionary<Type,Type>();
        }

        public AttributeHandlersTypeCollection(IEqualityComparer<Type> equalityComparer)
        {
            _dictionary = new Dictionary<Type, Type>(equalityComparer);
        }
        
        public void Add(Type attributeType, Type wrapper)
        {
            _dictionary.Add(attributeType, wrapper);
        }
        
        public override bool TryGetValue(Type attributeType, Type fieldType, out Type wrapperType)
        {
            if (_dictionary.TryGetValue(attributeType, out var wrapper))
            {
                wrapperType = wrapper;
                return true;
            }

            wrapperType = null;
            return false;
        }

        public override IEnumerator<Type> GetEnumerator()
        {
            return ((IEnumerable<Type>)_dictionary.Keys).GetEnumerator();
        }
    }
}