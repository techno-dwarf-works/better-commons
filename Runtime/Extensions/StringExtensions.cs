using System;
using System.Linq;
using System.Text.RegularExpressions;
using Better.Commons.Runtime.Utility;

namespace Better.Commons.Runtime.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string self)
        {
            return string.IsNullOrEmpty(self);
        }

        public static bool IsNullOrWhiteSpace(this string self)
        {
            return string.IsNullOrWhiteSpace(self);
        }
        
        public static string FormatBold(this string text)
        {
            return $"<b>{text}</b>";
        }

        public static string FormatItalic(this string text)
        {
            return $"<i>{text}</i>";
        }

        public static string FormatBoldItalic(this string text)
        {
            return $"<b><i>{text}</i></b>";
        }

        /// <summary>
        /// Makes first char upper
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static string FirstCharToUpper(this string self)
        {
            if (self.IsNullOrEmpty())
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return self;
            }

            return self.First().ToString().ToUpper() + self.Substring(1);
        }
        
        public static string ConvertToKebabCase(this string self)
        {
            if (string.IsNullOrEmpty(self))
                return self;

            // Check if the string is already in kebab case
            if (Regex.IsMatch(self, "^[a-z]+(-[a-z]+)*$"))
                return self;

            // Insert hyphen before each uppercase letter (except the first one)
            string kebabCase = Regex.Replace(self, "(?<!^)([A-Z])", "-$1");

            // Convert to lowercase
            return kebabCase.ToLower();
        }

        public static bool CompareOrdinal(this string self, string other)
        {
            return string.CompareOrdinal(self, other) == 0;
        }

        public static string PrettyCamelCase(this string self)
        {
            return Regex.Replace(self.Replace("_", ""), "((?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z]))", " $1").Trim();
        }

        public static string ToTitleCase(this string self)
        {
            return Regex.Replace(self, @"(^\w)|(\s\w)", m => m.Value.ToUpper());
        }
    }
}