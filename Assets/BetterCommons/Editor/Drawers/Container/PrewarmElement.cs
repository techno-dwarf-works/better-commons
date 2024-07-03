using Better.Commons.EditorAddons.Utility;
using Better.Commons.Runtime.Extensions;
using UnityEngine.UIElements;

namespace Better.Commons.EditorAddons.Drawers.Container
{
    public class PrewarmElement : VisualElement
    {
        public PrewarmElement()
        {
            var classStyle = StyleDefinition.CombineSubState(StyleDefinition.BetterPropertyClass, nameof(PrewarmElement));
            AddToClassList(classStyle);
            style.FlexShrink(new StyleFloat(0f));
        }
    }
}