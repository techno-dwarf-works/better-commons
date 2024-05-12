using System;
using UnityEngine;

namespace Better.Commons.Runtime.Conditions
{
    [Serializable]
    public class ActiveSelfCondition : ObjectCondition<GameObject, bool>
    {
        public ActiveSelfCondition(GameObject source, bool state) : base(source, state)
        {
        }

        protected ActiveSelfCondition() : this(default, true)
        {
        }

        public override bool Invoke()
        {
            return Source.activeSelf == TargetState;
        }
    }
}