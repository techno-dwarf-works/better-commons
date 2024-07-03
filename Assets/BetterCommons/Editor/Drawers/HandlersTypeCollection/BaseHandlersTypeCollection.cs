using System;
using System.Collections;
using System.Collections.Generic;

namespace Better.Commons.EditorAddons.Drawers.HandlersTypeCollection
{
    public abstract class BaseHandlersTypeCollection : IEnumerable<Type>
    {
        public abstract bool TryGetValue(Type attributeType, Type fieldType, out Type wrapperType);
        public abstract IEnumerator<Type> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}