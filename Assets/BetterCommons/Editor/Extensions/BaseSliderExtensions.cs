using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Better.Commons.EditorAddons.Extensions
{
    public static class BaseSliderExtensions
    {
        public static void SetupFromProperty<T>(this BaseSlider<T> self, SerializedProperty property) 
            where T : IComparable<T>
        {
            self.label = property.displayName;
            self.direction = SliderDirection.Horizontal;
            self.showInputField = true;
            self.BindProperty(property);
            self.AddToClassList("unity-base-field__aligned");
        }
    }
}