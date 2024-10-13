using Better.Commons.Runtime.DataStructures.Ranges;
using UnityEngine.UIElements;

namespace Better.Commons.Runtime.UIElements
{
    public class RangeSliderFloat : Slider
    {
        private Range<float> _range;

        public RangeSliderFloat()
        {
            
        }

        public RangeSliderFloat(Range<float> sliderRange) : this()
        {
            SetRange(sliderRange);
            RefreshRange();
        }

        public void SetRange(Range<float> sliderRange)
        {
            _range = sliderRange;
        }

        public void RefreshRange()
        {
            if(_range == null) return;
            lowValue = _range.Min;
            highValue = _range.Max;
        }
    }
}