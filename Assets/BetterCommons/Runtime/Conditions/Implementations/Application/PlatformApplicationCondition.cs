using System;
using UnityEngine;

namespace Better.Commons.Runtime.Conditions
{
    [Serializable]
    public class PlatformApplicationCondition : ApplicationCondition<RuntimePlatform>
    {
        public PlatformApplicationCondition(RuntimePlatform state) : base(state)
        {
        }

        protected PlatformApplicationCondition() : this(RuntimePlatform.WindowsEditor)
        {
        }

        public override bool Invoke()
        {
            return Application.platform == TargetState;
        }
    }
}