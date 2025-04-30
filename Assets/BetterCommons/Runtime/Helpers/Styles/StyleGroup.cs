using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Better.Commons.Runtime.Extensions;
using UnityEngine;
using UnityEngine.UIElements;

namespace Better.Commons.Runtime.Helpers.Styles
{
    public class StyleGroup : IStyle, IList<IStyle>
    {
        private readonly List<IStyle> _styles;
        private IStyle _mainStyle;

        public int Count => _styles.Count;

        public bool IsReadOnly => ((ICollection<IStyle>)_styles).IsReadOnly;

        public StyleEnum<Align> alignContent
        {
            get { return _mainStyle.alignContent; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.alignContent = newValue); }
        }

        public StyleEnum<Align> alignItems
        {
            get { return _mainStyle.alignItems; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.alignItems = newValue); }
        }

        public StyleEnum<Align> alignSelf
        {
            get { return _mainStyle.alignSelf; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.alignSelf = newValue); }
        }

        public StyleColor backgroundColor
        {
            get { return _mainStyle.backgroundColor; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.backgroundColor = newValue); }
        }

        public StyleBackground backgroundImage
        {
            get { return _mainStyle.backgroundImage; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.backgroundImage = newValue); }
        }

        public StyleColor borderBottomColor
        {
            get { return _mainStyle.borderBottomColor; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.borderBottomColor = newValue); }
        }

        public StyleLength borderBottomLeftRadius
        {
            get { return _mainStyle.borderBottomLeftRadius; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.borderBottomLeftRadius = newValue); }
        }

        public StyleLength borderBottomRightRadius
        {
            get { return _mainStyle.borderBottomRightRadius; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.borderBottomRightRadius = newValue); }
        }

        public StyleFloat borderBottomWidth
        {
            get { return _mainStyle.borderBottomWidth; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.borderBottomWidth = newValue); }
        }

        public StyleColor borderLeftColor
        {
            get { return _mainStyle.borderLeftColor; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.borderLeftColor = newValue); }
        }

        public StyleFloat borderLeftWidth
        {
            get { return _mainStyle.borderLeftWidth; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.borderLeftWidth = newValue); }
        }

        public StyleColor borderRightColor
        {
            get { return _mainStyle.borderRightColor; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.borderRightColor = newValue); }
        }

        public StyleFloat borderRightWidth
        {
            get { return _mainStyle.borderRightWidth; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.borderRightWidth = newValue); }
        }

        public StyleColor borderTopColor
        {
            get { return _mainStyle.borderTopColor; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.borderTopColor = newValue); }
        }

        public StyleLength borderTopLeftRadius
        {
            get { return _mainStyle.borderTopLeftRadius; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.borderTopLeftRadius = newValue); }
        }

        public StyleLength borderTopRightRadius
        {
            get { return _mainStyle.borderTopRightRadius; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.borderTopRightRadius = newValue); }
        }

        public StyleFloat borderTopWidth
        {
            get { return _mainStyle.borderTopWidth; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.borderTopWidth = newValue); }
        }

        public StyleLength bottom
        {
            get { return _mainStyle.bottom; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.bottom = newValue); }
        }

        public StyleColor color
        {
            get { return _mainStyle.color; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.color = newValue); }
        }

        public StyleCursor cursor
        {
            get { return _mainStyle.cursor; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.cursor = newValue); }
        }

        public StyleEnum<DisplayStyle> display
        {
            get { return _mainStyle.display; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.display = newValue); }
        }

        public StyleLength flexBasis
        {
            get { return _mainStyle.flexBasis; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.flexBasis = newValue); }
        }

        public StyleEnum<FlexDirection> flexDirection
        {
            get { return _mainStyle.flexDirection; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.flexDirection = newValue); }
        }

        public StyleFloat flexGrow
        {
            get { return _mainStyle.flexGrow; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.flexGrow = newValue); }
        }

        public StyleFloat flexShrink
        {
            get { return _mainStyle.flexShrink; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.flexShrink = newValue); }
        }

        public StyleEnum<Wrap> flexWrap
        {
            get { return _mainStyle.flexWrap; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.flexWrap = newValue); }
        }

        public StyleLength fontSize
        {
            get { return _mainStyle.fontSize; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.fontSize = newValue); }
        }

        public StyleLength height
        {
            get { return _mainStyle.height; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.height = newValue); }
        }

        public StyleEnum<Justify> justifyContent
        {
            get { return _mainStyle.justifyContent; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.justifyContent = newValue); }
        }

        public StyleLength left
        {
            get { return _mainStyle.left; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.left = newValue); }
        }

        public StyleLength letterSpacing
        {
            get { return _mainStyle.letterSpacing; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.letterSpacing = newValue); }
        }

        public StyleLength marginBottom
        {
            get { return _mainStyle.marginBottom; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.marginBottom = newValue); }
        }

        public StyleLength marginLeft
        {
            get { return _mainStyle.marginLeft; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.marginLeft = newValue); }
        }

        public StyleLength marginRight
        {
            get { return _mainStyle.marginRight; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.marginRight = newValue); }
        }

        public StyleLength marginTop
        {
            get { return _mainStyle.marginTop; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.marginTop = newValue); }
        }

        public StyleLength maxHeight
        {
            get { return _mainStyle.maxHeight; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.maxHeight = newValue); }
        }

        public StyleLength maxWidth
        {
            get { return _mainStyle.maxWidth; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.maxWidth = newValue); }
        }

        public StyleLength minHeight
        {
            get { return _mainStyle.minHeight; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.minHeight = newValue); }
        }

        public StyleLength minWidth
        {
            get { return _mainStyle.minWidth; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.minWidth = newValue); }
        }

        public StyleFloat opacity
        {
            get { return _mainStyle.opacity; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.opacity = newValue); }
        }

        public StyleEnum<Overflow> overflow
        {
            get { return _mainStyle.overflow; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.overflow = newValue); }
        }

        public StyleLength paddingBottom
        {
            get { return _mainStyle.paddingBottom; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.paddingBottom = newValue); }
        }

        public StyleLength paddingLeft
        {
            get { return _mainStyle.paddingLeft; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.paddingLeft = newValue); }
        }

        public StyleLength paddingRight
        {
            get { return _mainStyle.paddingRight; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.paddingRight = newValue); }
        }

        public StyleLength paddingTop
        {
            get { return _mainStyle.paddingTop; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.paddingTop = newValue); }
        }

        public StyleEnum<Position> position
        {
            get { return _mainStyle.position; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.position = newValue); }
        }

        public StyleLength right
        {
            get { return _mainStyle.right; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.right = newValue); }
        }

        public StyleRotate rotate
        {
            get { return _mainStyle.rotate; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.rotate = newValue); }
        }

        public StyleScale scale
        {
            get { return _mainStyle.scale; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.scale = newValue); }
        }

        public StyleEnum<TextOverflow> textOverflow
        {
            get { return _mainStyle.textOverflow; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.textOverflow = newValue); }
        }

        public StyleTextShadow textShadow
        {
            get { return _mainStyle.textShadow; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.textShadow = newValue); }
        }

        public StyleLength top
        {
            get { return _mainStyle.top; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.top = newValue); }
        }

        public StyleTransformOrigin transformOrigin
        {
            get { return _mainStyle.transformOrigin; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.transformOrigin = newValue); }
        }

        public StyleList<TimeValue> transitionDelay
        {
            get { return _mainStyle.transitionDelay; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.transitionDelay = newValue); }
        }

        public StyleList<TimeValue> transitionDuration
        {
            get { return _mainStyle.transitionDuration; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.transitionDuration = newValue); }
        }

        public StyleList<StylePropertyName> transitionProperty
        {
            get { return _mainStyle.transitionProperty; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.transitionProperty = newValue); }
        }

        public StyleList<EasingFunction> transitionTimingFunction
        {
            get { return _mainStyle.transitionTimingFunction; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.transitionTimingFunction = newValue); }
        }

        public StyleTranslate translate
        {
            get { return _mainStyle.translate; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.translate = newValue); }
        }

        public StyleColor unityBackgroundImageTintColor
        {
            get { return _mainStyle.unityBackgroundImageTintColor; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.unityBackgroundImageTintColor = newValue); }
        }

        public StyleEnum<ScaleMode> unityBackgroundScaleMode
        {
            get { return _mainStyle.unityBackgroundScaleMode; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.unityBackgroundScaleMode = newValue); }
        }

        public StyleFont unityFont
        {
            get { return _mainStyle.unityFont; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.unityFont = newValue); }
        }

        public StyleFontDefinition unityFontDefinition
        {
            get { return _mainStyle.unityFontDefinition; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.unityFontDefinition = newValue); }
        }

        public StyleEnum<FontStyle> unityFontStyleAndWeight
        {
            get { return _mainStyle.unityFontStyleAndWeight; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.unityFontStyleAndWeight = newValue); }
        }

        public StyleEnum<OverflowClipBox> unityOverflowClipBox
        {
            get { return _mainStyle.unityOverflowClipBox; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.unityOverflowClipBox = newValue); }
        }

        public StyleLength unityParagraphSpacing
        {
            get { return _mainStyle.unityParagraphSpacing; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.unityParagraphSpacing = newValue); }
        }

        public StyleInt unitySliceBottom
        {
            get { return _mainStyle.unitySliceBottom; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.unitySliceBottom = newValue); }
        }

        public StyleInt unitySliceLeft
        {
            get { return _mainStyle.unitySliceLeft; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.unitySliceLeft = newValue); }
        }

        public StyleInt unitySliceRight
        {
            get { return _mainStyle.unitySliceRight; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.unitySliceRight = newValue); }
        }

        public StyleInt unitySliceTop
        {
            get { return _mainStyle.unitySliceTop; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.unitySliceTop = newValue); }
        }

        public StyleEnum<TextAnchor> unityTextAlign
        {
            get { return _mainStyle.unityTextAlign; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.unityTextAlign = newValue); }
        }

        public StyleColor unityTextOutlineColor
        {
            get { return _mainStyle.unityTextOutlineColor; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.unityTextOutlineColor = newValue); }
        }

        public StyleFloat unityTextOutlineWidth
        {
            get { return _mainStyle.unityTextOutlineWidth; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.unityTextOutlineWidth = newValue); }
        }

        public StyleEnum<TextOverflowPosition> unityTextOverflowPosition
        {
            get { return _mainStyle.unityTextOverflowPosition; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.unityTextOverflowPosition = newValue); }
        }

        public StyleEnum<Visibility> visibility
        {
            get { return _mainStyle.visibility; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.visibility = newValue); }
        }

        public StyleEnum<WhiteSpace> whiteSpace
        {
            get { return _mainStyle.whiteSpace; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.whiteSpace = newValue); }
        }

        public StyleLength width
        {
            get { return _mainStyle.width; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.width = newValue); }
        }

        public StyleLength wordSpacing
        {
            get { return _mainStyle.wordSpacing; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.wordSpacing = newValue); }
        }

#if UNITY_2022_2_OR_NEWER
        public StyleBackgroundPosition backgroundPositionX
        {
            get { return _mainStyle.backgroundPositionX; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.backgroundPositionX = newValue); }
        }

        public StyleBackgroundPosition backgroundPositionY
        {
            get { return _mainStyle.backgroundPositionY; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.backgroundPositionY = newValue); }
        }

        public StyleBackgroundRepeat backgroundRepeat
        {
            get { return _mainStyle.backgroundRepeat; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.backgroundRepeat = newValue); }
        }

        public StyleBackgroundSize backgroundSize
        {
            get { return _mainStyle.backgroundSize; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.backgroundSize = newValue); }
        }

        public StyleFloat unitySliceScale
        {
            get { return _mainStyle.unitySliceScale; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.unitySliceScale = newValue); }
        }
#endif

#if UNITY_6000_0_OR_NEWER
        public StyleEnum<TextGeneratorType> unityTextGenerator
        {
            get { return _mainStyle.unityTextGenerator; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.unityTextGenerator = newValue); }
        }

        public StyleEnum<EditorTextRenderingMode> unityEditorTextRenderingMode
        {
            get { return _mainStyle.unityEditorTextRenderingMode; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.unityEditorTextRenderingMode = newValue); }
        }
#endif
        
#if UNITY_6000_1_OR_NEWER
        public StyleEnum<SliceType> unitySliceType
        {
            get { return _mainStyle.unitySliceType; }
            set { ApplyProperty(_styles, value, (style, newValue) => style.unitySliceType = newValue); }
        }
#endif

        public StyleGroup(List<IStyle> styles) : this(styles.FirstOrDefault(), styles)
        {
        }

        public StyleGroup(IStyle mainStyle, List<IStyle> styles)
        {
            _styles = styles;
            _mainStyle = mainStyle;
            if (_mainStyle == null) return;

            foreach (var style in _styles)
            {
                style.CopyFrom(_mainStyle);
            }

            if (_styles.Contains(_mainStyle)) return;

            _styles.Add(_mainStyle);
        }

        public StyleGroup(IStyle mainStyle)
        {
            _mainStyle = mainStyle;
            _styles = new List<IStyle>();
        }

        public StyleGroup Add(IStyle style)
        {
            ((IList<IStyle>)this).Add(style);
            return this;
        }

        public StyleGroup Remove(IStyle style)
        {
            ((IList<IStyle>)this).Remove(style);
            return this;
        }

        private void ApplyProperty<T>(List<IStyle> styles, T value, Action<IStyle, T> onApply)
        {
            foreach (var style in styles)
            {
                onApply?.Invoke(style, value);
            }
        }

        public void Clear()
        {
            _styles.Clear();
        }

        public bool Contains(IStyle item)
        {
            return _styles.Contains(item);
        }

        public void CopyTo(IStyle[] array, int arrayIndex)
        {
            _styles.CopyTo(array, arrayIndex);
        }

        bool ICollection<IStyle>.Remove(IStyle item)
        {
            return _styles.Remove(item);
        }

        void ICollection<IStyle>.Add(IStyle item)
        {
            _styles.Add(item);
        }

        public IEnumerator<IStyle> GetEnumerator()
        {
            return _styles.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_styles).GetEnumerator();
        }

        public int IndexOf(IStyle item)
        {
            return _styles.IndexOf(item);
        }

        public void Insert(int index, IStyle item)
        {
            _styles.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _styles.RemoveAt(index);
        }

        public IStyle this[int index]
        {
            get => _styles[index];
            set => _styles[index] = value;
        }
    }
}