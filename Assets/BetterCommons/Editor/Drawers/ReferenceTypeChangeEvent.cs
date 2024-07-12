using UnityEngine.UIElements;

namespace Better.Commons.EditorAddons.Drawers
{
    public class ReferenceTypeChangeEvent : EventBase<ReferenceTypeChangeEvent>
    {
        public string PreviousTypeName { get; protected set; }

        public string NewTypeName { get; protected set; }

        protected override void Init()
        {
            base.Init();
            PreviousTypeName = string.Empty;
            NewTypeName = string.Empty;
            bubbles = true;
            tricklesDown = true;
        }

        public static ReferenceTypeChangeEvent GetPooled(string previousTypeName, string newTypeName)
        {
            var e = GetPooled();
            e.PreviousTypeName = previousTypeName;
            e.NewTypeName = newTypeName;
            return e;
        }
    }
}