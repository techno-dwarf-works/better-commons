using System.Threading;

namespace Better.Commons.Runtime.Conditions
{
    public class CancellationRequestedCondition : SourceCondition<CancellationToken, bool>
    {
        public CancellationRequestedCondition(CancellationToken source, bool state = true) : base(source, state)
        {
        }

        public override bool Invoke()
        {
            return Source.IsCancellationRequested == TargetState;
        }
    }
}