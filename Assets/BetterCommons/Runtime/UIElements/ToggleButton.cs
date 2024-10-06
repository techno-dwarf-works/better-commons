using System;
using UnityEngine.UIElements;

namespace Better.Commons.Runtime.UIElements
{
    public class ToggleButton : Button
    {
        public event Action<bool> Toggled; 
        
        private bool _toggled;

        public ToggleButton(Action clickEvent, Action<bool> toggleEvent, bool defaultState = false) : base(clickEvent)
        {
            clicked += OnClicked;
            Toggled = toggleEvent;
            SetToggled(defaultState);
        }

        public ToggleButton(Action<bool> toggled, bool defaultState = false) : this(null, toggled, defaultState)
        {
        }

        public ToggleButton(bool defaultState = false) : this(null, defaultState)
        {
        }

        private void OnClicked()
        {
            SetToggled(!_toggled);
        }

        private void SetToggled(bool toggled)
        {
            _toggled = toggled;
            Toggled?.Invoke(_toggled);
        }
    }
}