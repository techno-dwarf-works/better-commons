using Better.Commons.Runtime.DataStructures.Ranges;
using UnityEngine.UIElements;

namespace Better.Commons.Runtime.UIElements
{
    public class RangeSliderInt : SliderInt
    {
        private Range<int> _range;

        public RangeSliderInt()
        {
            
        }

        public RangeSliderInt(Range<int> sliderRange) : this()
        {
            SetRange(sliderRange);
            RefreshRange();
        }

        public void SetRange(Range<int> sliderRange)
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