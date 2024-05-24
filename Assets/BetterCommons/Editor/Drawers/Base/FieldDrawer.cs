using System.Reflection;
using Better.Commons.EditorAddons.Drawers.Caching;
using Better.Commons.Runtime.Drawers.Attributes;
using UnityEditor;
using UnityEngine;

namespace Better.Commons.EditorAddons.Drawers.Base
{
    public abstract class FieldDrawer
    {
        protected readonly FieldInfo _fieldInfo;
        protected readonly MultiPropertyAttribute _attribute;

        protected FieldDrawer(FieldInfo fieldInfo, MultiPropertyAttribute attribute)
        {
            _fieldInfo = fieldInfo;
            _attribute = attribute;
        }

        public virtual void Initialize()
        {
        }

        protected internal abstract void Deconstruct();

        protected internal abstract void PopulateContainer(ElementsContainer container);
    }
}