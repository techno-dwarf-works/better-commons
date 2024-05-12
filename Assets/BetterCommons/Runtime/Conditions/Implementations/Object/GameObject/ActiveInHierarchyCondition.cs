using System;
using UnityEngine;

namespace Better.Commons.Runtime.Conditions
{
    [Serializable]
    public class ActiveInHierarchyCondition : ObjectCondition<GameObject, bool>
    {
        public ActiveInHierarchyCondition(GameObject source, bool state) : base(source, state)
        {
        }

        protected ActiveInHierarchyCondition() : this(default, true)
        {
        }

        public override bool Invoke()
        {
            return Source.activeInHierarchy == TargetState;
        }
    }
}