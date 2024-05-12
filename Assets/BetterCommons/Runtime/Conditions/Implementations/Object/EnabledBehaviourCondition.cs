using System;
using UnityEngine;

namespace Better.Commons.Runtime.Conditions
{
    [Serializable]
    public class EnabledBehaviourCondition : ObjectCondition<Behaviour, bool>
    {
        public EnabledBehaviourCondition(Behaviour source, bool state) : base(source, state)
        {
        }

        protected EnabledBehaviourCondition() : this(default, true)
        {
        }

        public override bool Invoke()
        {
            return Source.enabled == TargetState;
        }
    }
}