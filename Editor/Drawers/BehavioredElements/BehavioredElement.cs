using Better.Commons.Runtime.Extensions;
using UnityEngine.UIElements;

namespace Better.Commons.EditorAddons.Drawers.BehavioredElements
{
    public class BehavioredElement<TElement> : VisualElement where TElement : VisualElement, new()
    {
        private IElementBehaviour<TElement> _strategy;
        public TElement SubElement { get; }

        public BehavioredElement(IElementBehaviour<TElement> strategy)
        {
            _strategy = strategy;
            var zeroLength = new StyleLength(0f);
            SubElement = new TElement();
            style.AlignItems(new StyleEnum<Align>(Align.Center))
                .MarginBottom(zeroLength)
                .MarginTop(zeroLength)
                .Right(zeroLength)
                .Width(new StyleLength(new Length(100, LengthUnit.Percent)));

            Add(SubElement);
            name = nameof(BehavioredElement<TElement>);
            _strategy.OnLink(this);
        }

        public void Attach(VisualElement root)
        {
            if (root == null) return;
            _strategy.OnAttach(root);
        }
    }

    public class BehavioredElement<TElement, TElementBehaviour> : BehavioredElement<TElement> 
        where TElementBehaviour : IElementBehaviour<TElement>, new() 
        where TElement : VisualElement, new()
    {
        public BehavioredElement() : base(new TElementBehaviour())
        {
        }
    }
}