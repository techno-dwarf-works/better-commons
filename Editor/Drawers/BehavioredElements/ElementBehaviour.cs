using UnityEngine.UIElements;

namespace Better.Commons.EditorAddons.Drawers.BehavioredElements
{
    public interface IElementBehaviour<TElement>
        where TElement : VisualElement, new()
    {
        public void OnLink(BehavioredElement<TElement> behavioredElement);
        public void OnAttach(VisualElement root);
    }
}