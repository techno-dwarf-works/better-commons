using Better.Commons.EditorAddons.Utility;
using Better.Commons.Runtime.Extensions;
using UnityEngine.UIElements;

namespace Better.Commons.EditorAddons.Drawers.BehavioredElements
{
    public class DefaultElementBehaviour<TElement> : IElementBehaviour<TElement> where TElement : VisualElement, new()
    {
        protected BehavioredElement<TElement> BehavioredElement { get; private set; }
        
        public virtual void OnLink(BehavioredElement<TElement> behavioredElement)
        {
            BehavioredElement = behavioredElement;
            var zeroLength = new StyleLength(0f);
            BehavioredElement.SubElement.style
                .Height(StyleDefinition.SingleLineHeight)
                .AlignSelf(new StyleEnum<Align>(Align.FlexEnd))
                .MarginBottom(zeroLength)
                .MarginTop(zeroLength)
                .Width(new StyleLength(new Length(100, LengthUnit.Percent)));
        }
        
        public virtual void OnAttach(VisualElement root)
        {
            if (root is not Label label)
            {
                label = root.Q<Label>();
            }

            BehavioredElement.RemoveFromHierarchy();
            label.style
                .Width(StyleDefinition.LabelWidthStyle)
                .FlexGrow(new StyleFloat(1f));
            
            var labelParent = label.parent;
            labelParent.style.FlexDirection(new StyleEnum<FlexDirection>(FlexDirection.Row));
            labelParent.Add(BehavioredElement);

            var checkmark = labelParent.Q<VisualElement>("unity-checkmark");
            checkmark?.style.AlignSelf(new StyleEnum<Align>(Align.Center));
        }
    }
}