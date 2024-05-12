using System;
using Better.Commons.Runtime.Utility;

namespace Better.Commons.Runtime.Conditions
{
    [Serializable]
    public abstract class Condition
    {
        public const bool DefaultLogException = true;
        
        public virtual void Rebuild()
        {
        }

        public abstract bool Invoke();

        public bool SafeInvoke(bool logException = DefaultLogException)
        {
            try
            {
                return Invoke();
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return false;
            }
        }

        public bool Validate(bool logException = DefaultLogException)
        {
            var isValid = Validate(out var exception);
            if (!isValid && logException)
            {
                exception ??= new InvalidOperationException();
                DebugUtility.LogException(exception);
            }

            return isValid;
        }

        protected abstract bool Validate(out Exception exception);
    }
}