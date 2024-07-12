using Better.Commons.Runtime.Extensions;
using UnityEngine.UIElements;

namespace Better.Commons.EditorAddons.Utility
{
    public static class StyleDefinition
    {
        public const string BetterPropertyClass = "better-property-field";
        private static float _spaceHeight = 6f;
        public static readonly StyleLength SingleLineHeight = new StyleLength(new Length(18, LengthUnit.Pixel));
        public static readonly StyleLength IndentLevelPadding = new StyleLength(new Length(15, LengthUnit.Pixel));
        public static readonly StyleFloat OneStyleFloat = new StyleFloat(1f);
        public static readonly StyleFloat ZeroStyleFloat = new StyleFloat(0f);
        public static readonly StyleLength OneStyleLength = new StyleLength(1f);
        public static readonly StyleLength LabelWidthStyle = new StyleLength(new Length(45, LengthUnit.Percent));

        public const string PropertyFieldClass = "unity-property-field";
        public const string EmptyName = "empty";
        public static float SpaceHeight => _spaceHeight;

        public static string CombineSubState(string style, string state)
        {
            var kebabStyle = style.ConvertToKebabCase();
            var kebabState = state.ConvertToKebabCase();
            return $"{kebabStyle}__{kebabState}";
        }
    }
}