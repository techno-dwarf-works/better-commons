using System.Text.RegularExpressions;
using UnityEngine.UIElements;

namespace Better.Commons.EditorAddons.Utility
{
    public static class StyleDefinition
    {
        public const string BetterPropertyClass = "better-property-field";
        public static readonly StyleLength SingleLineHeight = new StyleLength(new Length(18, LengthUnit.Pixel));
        public static readonly StyleLength IndentLevelPadding = new StyleLength(new Length(15, LengthUnit.Pixel));
        public const string PropertyFieldClass = "unity-property-field";

        public static string AddSubState(string style, string state)
        {
            var kebabStyle = ConvertToKebabCase(style);
            var kebabState = ConvertToKebabCase(state);
            return $"{kebabStyle}__{kebabState}";
        }
        
        public static string ConvertToKebabCase(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            // Check if the string is already in kebab case
            if (Regex.IsMatch(input, "^[a-z]+(-[a-z]+)*$"))
                return input;

            // Insert hyphen before each uppercase letter (except the first one)
            string kebabCase = Regex.Replace(input, "(?<!^)([A-Z])", "-$1");

            // Convert to lowercase
            return kebabCase.ToLower();
        }
    }
}