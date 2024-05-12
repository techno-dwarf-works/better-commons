using System;
using UnityEngine;

namespace Better.Commons.Runtime.Conditions
{
    [Serializable]
    public class SystemLanguageCondition : ApplicationCondition<SystemLanguage>
    {
        public SystemLanguageCondition(SystemLanguage state) : base(state)
        {
        }

        protected SystemLanguageCondition() : this(SystemLanguage.English)
        {
        }

        public override bool Invoke()
        {
            return Application.systemLanguage == TargetState;
        }
    }
}