using Better.Commons.Runtime.Helpers.Styles;
using UnityEngine.UIElements;

namespace Better.Commons.EditorAddons.Helpers
{
    public class LabelContainer
    {
        private readonly StyleContainer _styleContainer;
        private Label _label;

        public string Suffix { get; set; }
        public string Prefix { get; set; }
        public string DefaultText { get; }
        public string Text { get; set; }
        public string Tooltip { get; set; }

        public IStyle Style => _styleContainer;

        public LabelContainer(string defaultText)
        {
            DefaultText = defaultText;
            Text = defaultText;
            _styleContainer = new StyleContainer();
        }

        public void Setup(Label label)
        {
            //TODO: Add validation for label
            _label = label;
            _styleContainer.Setup(_label.style);

            Rebuild();
        }

        public void Rebuild()
        {
            if (_label == null)
            {
                return;
            }

            _label.text = $"{Prefix}{Text}{Suffix}";
            _label.tooltip = Tooltip;
        }

        public void Reset()
        {
            _label = null;
            _styleContainer.Reset();
        }

        public void SoftReset()
        {
            if (_label is { panel: not null })
            {
                return;
            }

            _label = null;
            _styleContainer.Reset();
        }
    }
}