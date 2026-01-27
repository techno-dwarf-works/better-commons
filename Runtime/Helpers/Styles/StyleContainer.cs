using UnityEngine;
using UnityEngine.UIElements;

namespace Better.Commons.Runtime.Helpers.Styles
{
	public class StyleContainer : IStyle
	{
		private StyleProperty<StyleEnum<Align>> _alignContent;
		private StyleProperty<StyleEnum<Align>> _alignItems;
		private StyleProperty<StyleEnum<Align>> _alignSelf;
		private StyleProperty<StyleColor> _backgroundColor;
		private StyleProperty<StyleBackground> _backgroundImage;
		private StyleProperty<StyleColor> _borderBottomColor;
		private StyleProperty<StyleLength> _borderBottomLeftRadius;
		private StyleProperty<StyleLength> _borderBottomRightRadius;
		private StyleProperty<StyleFloat> _borderBottomWidth;
		private StyleProperty<StyleColor> _borderLeftColor;
		private StyleProperty<StyleFloat> _borderLeftWidth;
		private StyleProperty<StyleColor> _borderRightColor;
		private StyleProperty<StyleFloat> _borderRightWidth;
		private StyleProperty<StyleColor> _borderTopColor;
		private StyleProperty<StyleLength> _borderTopLeftRadius;
		private StyleProperty<StyleLength> _borderTopRightRadius;
		private StyleProperty<StyleFloat> _borderTopWidth;
		private StyleProperty<StyleLength> _bottom;
		private StyleProperty<StyleColor> _color;
		private StyleProperty<StyleCursor> _cursor;
		private StyleProperty<StyleEnum<DisplayStyle>> _display;
		private StyleProperty<StyleLength> _flexBasis;
		private StyleProperty<StyleEnum<FlexDirection>> _flexDirection;
		private StyleProperty<StyleFloat> _flexGrow;
		private StyleProperty<StyleFloat> _flexShrink;
		private StyleProperty<StyleEnum<Wrap>> _flexWrap;
		private StyleProperty<StyleLength> _fontSize;
		private StyleProperty<StyleLength> _height;
		private StyleProperty<StyleEnum<Justify>> _justifyContent;
		private StyleProperty<StyleLength> _left;
		private StyleProperty<StyleLength> _letterSpacing;
		private StyleProperty<StyleLength> _marginBottom;
		private StyleProperty<StyleLength> _marginLeft;
		private StyleProperty<StyleLength> _marginRight;
		private StyleProperty<StyleLength> _marginTop;
		private StyleProperty<StyleLength> _maxHeight;
		private StyleProperty<StyleLength> _maxWidth;
		private StyleProperty<StyleLength> _minHeight;
		private StyleProperty<StyleLength> _minWidth;
		private StyleProperty<StyleFloat> _opacity;
		private StyleProperty<StyleEnum<Overflow>> _overflow;
		private StyleProperty<StyleLength> _paddingBottom;
		private StyleProperty<StyleLength> _paddingLeft;
		private StyleProperty<StyleLength> _paddingRight;
		private StyleProperty<StyleLength> _paddingTop;
		private StyleProperty<StyleEnum<Position>> _position;
		private StyleProperty<StyleLength> _right;
		private StyleProperty<StyleRotate> _rotate;
		private StyleProperty<StyleScale> _scale;
		private StyleProperty<StyleEnum<TextOverflow>> _textOverflow;
		private StyleProperty<StyleTextShadow> _textShadow;
		private StyleProperty<StyleLength> _top;
		private StyleProperty<StyleTransformOrigin> _transformOrigin;
		private StyleProperty<StyleList<TimeValue>> _transitionDelay;
		private StyleProperty<StyleList<TimeValue>> _transitionDuration;
		private StyleProperty<StyleList<StylePropertyName>> _transitionProperty;
		private StyleProperty<StyleList<EasingFunction>> _transitionTimingFunction;
		private StyleProperty<StyleTranslate> _translate;
		private StyleProperty<StyleColor> _unityBackgroundImageTintColor;
		private StyleProperty<StyleEnum<ScaleMode>> _unityBackgroundScaleMode;
		private StyleProperty<StyleFont> _unityFont;
		private StyleProperty<StyleFontDefinition> _unityFontDefinition;
		private StyleProperty<StyleEnum<FontStyle>> _unityFontStyleAndWeight;
		private StyleProperty<StyleEnum<OverflowClipBox>> _unityOverflowClipBox;
		private StyleProperty<StyleLength> _unityParagraphSpacing;
		private StyleProperty<StyleInt> _unitySliceBottom;
		private StyleProperty<StyleInt> _unitySliceLeft;
		private StyleProperty<StyleInt> _unitySliceRight;
		private StyleProperty<StyleInt> _unitySliceTop;
		private StyleProperty<StyleEnum<TextAnchor>> _unityTextAlign;
		private StyleProperty<StyleColor> _unityTextOutlineColor;
		private StyleProperty<StyleFloat> _unityTextOutlineWidth;
		private StyleProperty<StyleEnum<TextOverflowPosition>> _unityTextOverflowPosition;
		private StyleProperty<StyleEnum<Visibility>> _visibility;
		private StyleProperty<StyleEnum<WhiteSpace>> _whiteSpace;
		private StyleProperty<StyleLength> _width;
		private StyleProperty<StyleLength> _wordSpacing;

#if UNITY_2022_2_OR_NEWER
		private StyleProperty<StyleBackgroundPosition> _backgroundPositionX;
		private StyleProperty<StyleBackgroundPosition> _backgroundPositionY;
		private StyleProperty<StyleBackgroundRepeat> _backgroundRepeat;
		private StyleProperty<StyleBackgroundSize> _backgroundSize;
		private StyleProperty<StyleFloat> _unitySliceScale;
#endif

#if UNITY_6000_0_OR_NEWER
		private StyleProperty<StyleEnum<TextGeneratorType>> _unityTextGenerator;
		private StyleProperty<StyleEnum<EditorTextRenderingMode>> _unityEditorTextRenderingMode;
		private StyleProperty<StyleEnum<SliceType>> _unitySliceType;
#endif

#if UNITY_6000_2_OR_NEWER
		private StyleProperty<StyleTextAutoSize> _unityTextAutoSize;
#endif

#if UNITY_6000_3_OR_NEWER
		private StyleProperty<StyleMaterialDefinition> _unityMaterial;
		private StyleProperty<StyleList<FilterFunction>> _filter;
		private StyleProperty<StyleRatio> _aspectRatio;
#endif

		private IStyle _cachedStyle;

		public StyleEnum<Align> alignContent
		{
			get
			{
				if (_alignContent.HasValue
					|| _cachedStyle == null)
				{
					return _alignContent.Value;
				}

				return _cachedStyle.alignContent;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.alignContent = value;
				}

				_alignContent.Value = value;
			}
		}

		public StyleEnum<Align> alignItems
		{
			get
			{
				if (_alignItems.HasValue
					|| _cachedStyle == null)
				{
					return _alignItems.Value;
				}

				return _cachedStyle.alignItems;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.alignItems = value;
				}

				_alignItems.Value = value;
			}
		}

		public StyleEnum<Align> alignSelf
		{
			get
			{
				if (_alignSelf.HasValue
					|| _cachedStyle == null)
				{
					return _alignSelf.Value;
				}

				return _cachedStyle.alignSelf;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.alignSelf = value;
				}

				_alignSelf.Value = value;
			}
		}

		public StyleColor backgroundColor
		{
			get
			{
				if (_backgroundColor.HasValue
					|| _cachedStyle == null)
				{
					return _backgroundColor.Value;
				}

				return _cachedStyle.backgroundColor;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.backgroundColor = value;
				}

				_backgroundColor.Value = value;
			}
		}

		public StyleBackground backgroundImage
		{
			get
			{
				if (_backgroundImage.HasValue
					|| _cachedStyle == null)
				{
					return _backgroundImage.Value;
				}

				return _cachedStyle.backgroundImage;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.backgroundImage = value;
				}

				_backgroundImage.Value = value;
			}
		}

		public StyleColor borderBottomColor
		{
			get
			{
				if (_borderBottomColor.HasValue
					|| _cachedStyle == null)
				{
					return _borderBottomColor.Value;
				}

				return _cachedStyle.borderBottomColor;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.borderBottomColor = value;
				}

				_borderBottomColor.Value = value;
			}
		}

		public StyleLength borderBottomLeftRadius
		{
			get
			{
				if (_borderBottomLeftRadius.HasValue
					|| _cachedStyle == null)
				{
					return _borderBottomLeftRadius.Value;
				}

				return _cachedStyle.borderBottomLeftRadius;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.borderBottomLeftRadius = value;
				}

				_borderBottomLeftRadius.Value = value;
			}
		}

		public StyleLength borderBottomRightRadius
		{
			get
			{
				if (_borderBottomRightRadius.HasValue
					|| _cachedStyle == null)
				{
					return _borderBottomRightRadius.Value;
				}

				return _cachedStyle.borderBottomRightRadius;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.borderBottomRightRadius = value;
				}

				_borderBottomRightRadius.Value = value;
			}
		}

		public StyleFloat borderBottomWidth
		{
			get
			{
				if (_borderBottomWidth.HasValue
					|| _cachedStyle == null)
				{
					return _borderBottomWidth.Value;
				}

				return _cachedStyle.borderBottomWidth;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.borderBottomWidth = value;
				}

				_borderBottomWidth.Value = value;
			}
		}

		public StyleColor borderLeftColor
		{
			get
			{
				if (_borderLeftColor.HasValue
					|| _cachedStyle == null)
				{
					return _borderLeftColor.Value;
				}

				return _cachedStyle.borderLeftColor;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.borderLeftColor = value;
				}

				_borderLeftColor.Value = value;
			}
		}

		public StyleFloat borderLeftWidth
		{
			get
			{
				if (_borderLeftWidth.HasValue
					|| _cachedStyle == null)
				{
					return _borderLeftWidth.Value;
				}

				return _cachedStyle.borderLeftWidth;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.borderLeftWidth = value;
				}

				_borderLeftWidth.Value = value;
			}
		}

		public StyleColor borderRightColor
		{
			get
			{
				if (_borderRightColor.HasValue
					|| _cachedStyle == null)
				{
					return _borderRightColor.Value;
				}

				return _cachedStyle.borderRightColor;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.borderRightColor = value;
				}

				_borderRightColor.Value = value;
			}
		}

		public StyleFloat borderRightWidth
		{
			get
			{
				if (_borderRightWidth.HasValue
					|| _cachedStyle == null)
				{
					return _borderRightWidth.Value;
				}

				return _cachedStyle.borderRightWidth;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.borderRightWidth = value;
				}

				_borderRightWidth.Value = value;
			}
		}

		public StyleColor borderTopColor
		{
			get
			{
				if (_borderTopColor.HasValue
					|| _cachedStyle == null)
				{
					return _borderTopColor.Value;
				}

				return _cachedStyle.borderTopColor;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.borderTopColor = value;
				}

				_borderTopColor.Value = value;
			}
		}

		public StyleLength borderTopLeftRadius
		{
			get
			{
				if (_borderTopLeftRadius.HasValue
					|| _cachedStyle == null)
				{
					return _borderTopLeftRadius.Value;
				}

				return _cachedStyle.borderTopLeftRadius;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.borderTopLeftRadius = value;
				}

				_borderTopLeftRadius.Value = value;
			}
		}

		public StyleLength borderTopRightRadius
		{
			get
			{
				if (_borderTopRightRadius.HasValue
					|| _cachedStyle == null)
				{
					return _borderTopRightRadius.Value;
				}

				return _cachedStyle.borderTopRightRadius;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.borderTopRightRadius = value;
				}

				_borderTopRightRadius.Value = value;
			}
		}

		public StyleFloat borderTopWidth
		{
			get
			{
				if (_borderTopWidth.HasValue
					|| _cachedStyle == null)
				{
					return _borderTopWidth.Value;
				}

				return _cachedStyle.borderTopWidth;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.borderTopWidth = value;
				}

				_borderTopWidth.Value = value;
			}
		}

		public StyleLength bottom
		{
			get
			{
				if (_bottom.HasValue
					|| _cachedStyle == null)
				{
					return _bottom.Value;
				}

				return _cachedStyle.bottom;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.bottom = value;
				}

				_bottom.Value = value;
			}
		}

		public StyleColor color
		{
			get
			{
				if (_color.HasValue
					|| _cachedStyle == null)
				{
					return _color.Value;
				}

				return _cachedStyle.color;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.color = value;
				}

				_color.Value = value;
			}
		}

		public StyleCursor cursor
		{
			get
			{
				if (_cursor.HasValue
					|| _cachedStyle == null)
				{
					return _cursor.Value;
				}

				return _cachedStyle.cursor;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.cursor = value;
				}

				_cursor.Value = value;
			}
		}

		public StyleEnum<DisplayStyle> display
		{
			get
			{
				if (_display.HasValue
					|| _cachedStyle == null)
				{
					return _display.Value;
				}

				return _cachedStyle.display;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.display = value;
				}

				_display.Value = value;
			}
		}

		public StyleLength flexBasis
		{
			get
			{
				if (_flexBasis.HasValue
					|| _cachedStyle == null)
				{
					return _flexBasis.Value;
				}

				return _cachedStyle.flexBasis;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.flexBasis = value;
				}

				_flexBasis.Value = value;
			}
		}

		public StyleEnum<FlexDirection> flexDirection
		{
			get
			{
				if (_flexDirection.HasValue
					|| _cachedStyle == null)
				{
					return _flexDirection.Value;
				}

				return _cachedStyle.flexDirection;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.flexDirection = value;
				}

				_flexDirection.Value = value;
			}
		}

		public StyleFloat flexGrow
		{
			get
			{
				if (_flexGrow.HasValue
					|| _cachedStyle == null)
				{
					return _flexGrow.Value;
				}

				return _cachedStyle.flexGrow;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.flexGrow = value;
				}

				_flexGrow.Value = value;
			}
		}

		public StyleFloat flexShrink
		{
			get
			{
				if (_flexShrink.HasValue
					|| _cachedStyle == null)
				{
					return _flexShrink.Value;
				}

				return _cachedStyle.flexShrink;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.flexShrink = value;
				}

				_flexShrink.Value = value;
			}
		}

		public StyleEnum<Wrap> flexWrap
		{
			get
			{
				if (_flexWrap.HasValue
					|| _cachedStyle == null)
				{
					return _flexWrap.Value;
				}

				return _cachedStyle.flexWrap;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.flexWrap = value;
				}

				_flexWrap.Value = value;
			}
		}

		public StyleLength fontSize
		{
			get
			{
				if (_fontSize.HasValue
					|| _cachedStyle == null)
				{
					return _fontSize.Value;
				}

				return _cachedStyle.fontSize;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.fontSize = value;
				}

				_fontSize.Value = value;
			}
		}

		public StyleLength height
		{
			get
			{
				if (_height.HasValue
					|| _cachedStyle == null)
				{
					return _height.Value;
				}

				return _cachedStyle.height;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.height = value;
				}

				_height.Value = value;
			}
		}

		public StyleEnum<Justify> justifyContent
		{
			get
			{
				if (_justifyContent.HasValue
					|| _cachedStyle == null)
				{
					return _justifyContent.Value;
				}

				return _cachedStyle.justifyContent;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.justifyContent = value;
				}

				_justifyContent.Value = value;
			}
		}

		public StyleLength left
		{
			get
			{
				if (_left.HasValue
					|| _cachedStyle == null)
				{
					return _left.Value;
				}

				return _cachedStyle.left;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.left = value;
				}

				_left.Value = value;
			}
		}

		public StyleLength letterSpacing
		{
			get
			{
				if (_letterSpacing.HasValue
					|| _cachedStyle == null)
				{
					return _letterSpacing.Value;
				}

				return _cachedStyle.letterSpacing;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.letterSpacing = value;
				}

				_letterSpacing.Value = value;
			}
		}

		public StyleLength marginBottom
		{
			get
			{
				if (_marginBottom.HasValue
					|| _cachedStyle == null)
				{
					return _marginBottom.Value;
				}

				return _cachedStyle.marginBottom;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.marginBottom = value;
				}

				_marginBottom.Value = value;
			}
		}

		public StyleLength marginLeft
		{
			get
			{
				if (_marginLeft.HasValue
					|| _cachedStyle == null)
				{
					return _marginLeft.Value;
				}

				return _cachedStyle.marginLeft;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.marginLeft = value;
				}

				_marginLeft.Value = value;
			}
		}

		public StyleLength marginRight
		{
			get
			{
				if (_marginRight.HasValue
					|| _cachedStyle == null)
				{
					return _marginRight.Value;
				}

				return _cachedStyle.marginRight;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.marginRight = value;
				}

				_marginRight.Value = value;
			}
		}

		public StyleLength marginTop
		{
			get
			{
				if (_marginTop.HasValue
					|| _cachedStyle == null)
				{
					return _marginTop.Value;
				}

				return _cachedStyle.marginTop;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.marginTop = value;
				}

				_marginTop.Value = value;
			}
		}

		public StyleLength maxHeight
		{
			get
			{
				if (_maxHeight.HasValue
					|| _cachedStyle == null)
				{
					return _maxHeight.Value;
				}

				return _cachedStyle.maxHeight;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.maxHeight = value;
				}

				_maxHeight.Value = value;
			}
		}

		public StyleLength maxWidth
		{
			get
			{
				if (_maxWidth.HasValue
					|| _cachedStyle == null)
				{
					return _maxWidth.Value;
				}

				return _cachedStyle.maxWidth;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.maxWidth = value;
				}

				_maxWidth.Value = value;
			}
		}

		public StyleLength minHeight
		{
			get
			{
				if (_minHeight.HasValue
					|| _cachedStyle == null)
				{
					return _minHeight.Value;
				}

				return _cachedStyle.minHeight;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.minHeight = value;
				}

				_minHeight.Value = value;
			}
		}

		public StyleLength minWidth
		{
			get
			{
				if (_minWidth.HasValue
					|| _cachedStyle == null)
				{
					return _minWidth.Value;
				}

				return _cachedStyle.minWidth;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.minWidth = value;
				}

				_minWidth.Value = value;
			}
		}

		public StyleFloat opacity
		{
			get
			{
				if (_opacity.HasValue
					|| _cachedStyle == null)
				{
					return _opacity.Value;
				}

				return _cachedStyle.opacity;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.opacity = value;
				}

				_opacity.Value = value;
			}
		}

		public StyleEnum<Overflow> overflow
		{
			get
			{
				if (_overflow.HasValue
					|| _cachedStyle == null)
				{
					return _overflow.Value;
				}

				return _cachedStyle.overflow;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.overflow = value;
				}

				_overflow.Value = value;
			}
		}

		public StyleLength paddingBottom
		{
			get
			{
				if (_paddingBottom.HasValue
					|| _cachedStyle == null)
				{
					return _paddingBottom.Value;
				}

				return _cachedStyle.paddingBottom;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.paddingBottom = value;
				}

				_paddingBottom.Value = value;
			}
		}

		public StyleLength paddingLeft
		{
			get
			{
				if (_paddingLeft.HasValue
					|| _cachedStyle == null)
				{
					return _paddingLeft.Value;
				}

				return _cachedStyle.paddingLeft;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.paddingLeft = value;
				}

				_paddingLeft.Value = value;
			}
		}

		public StyleLength paddingRight
		{
			get
			{
				if (_paddingRight.HasValue
					|| _cachedStyle == null)
				{
					return _paddingRight.Value;
				}

				return _cachedStyle.paddingRight;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.paddingRight = value;
				}

				_paddingRight.Value = value;
			}
		}

		public StyleLength paddingTop
		{
			get
			{
				if (_paddingTop.HasValue
					|| _cachedStyle == null)
				{
					return _paddingTop.Value;
				}

				return _cachedStyle.paddingTop;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.paddingTop = value;
				}

				_paddingTop.Value = value;
			}
		}

		public StyleEnum<Position> position
		{
			get
			{
				if (_position.HasValue
					|| _cachedStyle == null)
				{
					return _position.Value;
				}

				return _cachedStyle.position;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.position = value;
				}

				_position.Value = value;
			}
		}

		public StyleLength right
		{
			get
			{
				if (_right.HasValue
					|| _cachedStyle == null)
				{
					return _right.Value;
				}

				return _cachedStyle.right;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.right = value;
				}

				_right.Value = value;
			}
		}

		public StyleRotate rotate
		{
			get
			{
				if (_rotate.HasValue
					|| _cachedStyle == null)
				{
					return _rotate.Value;
				}

				return _cachedStyle.rotate;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.rotate = value;
				}

				_rotate.Value = value;
			}
		}

		public StyleScale scale
		{
			get
			{
				if (_scale.HasValue
					|| _cachedStyle == null)
				{
					return _scale.Value;
				}

				return _cachedStyle.scale;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.scale = value;
				}

				_scale.Value = value;
			}
		}

		public StyleEnum<TextOverflow> textOverflow
		{
			get
			{
				if (_textOverflow.HasValue
					|| _cachedStyle == null)
				{
					return _textOverflow.Value;
				}

				return _cachedStyle.textOverflow;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.textOverflow = value;
				}

				_textOverflow.Value = value;
			}
		}

		public StyleTextShadow textShadow
		{
			get
			{
				if (_textShadow.HasValue
					|| _cachedStyle == null)
				{
					return _textShadow.Value;
				}

				return _cachedStyle.textShadow;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.textShadow = value;
				}

				_textShadow.Value = value;
			}
		}

		public StyleLength top
		{
			get
			{
				if (_top.HasValue
					|| _cachedStyle == null)
				{
					return _top.Value;
				}

				return _cachedStyle.top;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.top = value;
				}

				_top.Value = value;
			}
		}

		public StyleTransformOrigin transformOrigin
		{
			get
			{
				if (_transformOrigin.HasValue
					|| _cachedStyle == null)
				{
					return _transformOrigin.Value;
				}

				return _cachedStyle.transformOrigin;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.transformOrigin = value;
				}

				_transformOrigin.Value = value;
			}
		}

		public StyleList<TimeValue> transitionDelay
		{
			get
			{
				if (_transitionDelay.HasValue
					|| _cachedStyle == null)
				{
					return _transitionDelay.Value;
				}

				return _cachedStyle.transitionDelay;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.transitionDelay = value;
				}

				_transitionDelay.Value = value;
			}
		}

		public StyleList<TimeValue> transitionDuration
		{
			get
			{
				if (_transitionDuration.HasValue
					|| _cachedStyle == null)
				{
					return _transitionDuration.Value;
				}

				return _cachedStyle.transitionDuration;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.transitionDuration = value;
				}

				_transitionDuration.Value = value;
			}
		}

		public StyleList<StylePropertyName> transitionProperty
		{
			get
			{
				if (_transitionProperty.HasValue
					|| _cachedStyle == null)
				{
					return _transitionProperty.Value;
				}

				return _cachedStyle.transitionProperty;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.transitionProperty = value;
				}

				_transitionProperty.Value = value;
			}
		}

		public StyleList<EasingFunction> transitionTimingFunction
		{
			get
			{
				if (_transitionTimingFunction.HasValue
					|| _cachedStyle == null)
				{
					return _transitionTimingFunction.Value;
				}

				return _cachedStyle.transitionTimingFunction;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.transitionTimingFunction = value;
				}

				_transitionTimingFunction.Value = value;
			}
		}

		public StyleTranslate translate
		{
			get
			{
				if (_translate.HasValue
					|| _cachedStyle == null)
				{
					return _translate.Value;
				}

				return _cachedStyle.translate;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.translate = value;
				}

				_translate.Value = value;
			}
		}

		public StyleColor unityBackgroundImageTintColor
		{
			get
			{
				if (_unityBackgroundImageTintColor.HasValue
					|| _cachedStyle == null)
				{
					return _unityBackgroundImageTintColor.Value;
				}

				return _cachedStyle.unityBackgroundImageTintColor;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.unityBackgroundImageTintColor = value;
				}

				_unityBackgroundImageTintColor.Value = value;
			}
		}

		public StyleEnum<ScaleMode> unityBackgroundScaleMode
		{
			get
			{
				if (_unityBackgroundScaleMode.HasValue
					|| _cachedStyle == null)
				{
					return _unityBackgroundScaleMode.Value;
				}

				return _cachedStyle.unityBackgroundScaleMode;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.unityBackgroundScaleMode = value;
				}

				_unityBackgroundScaleMode.Value = value;
			}
		}

		public StyleFont unityFont
		{
			get
			{
				if (_unityFont.HasValue
					|| _cachedStyle == null)
				{
					return _unityFont.Value;
				}

				return _cachedStyle.unityFont;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.unityFont = value;
				}

				_unityFont.Value = value;
			}
		}

		public StyleFontDefinition unityFontDefinition
		{
			get
			{
				if (_unityFontDefinition.HasValue
					|| _cachedStyle == null)
				{
					return _unityFontDefinition.Value;
				}

				return _cachedStyle.unityFontDefinition;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.unityFontDefinition = value;
				}

				_unityFontDefinition.Value = value;
			}
		}

		public StyleEnum<FontStyle> unityFontStyleAndWeight
		{
			get
			{
				if (_unityFontStyleAndWeight.HasValue
					|| _cachedStyle == null)
				{
					return _unityFontStyleAndWeight.Value;
				}

				return _cachedStyle.unityFontStyleAndWeight;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.unityFontStyleAndWeight = value;
				}

				_unityFontStyleAndWeight.Value = value;
			}
		}

		public StyleEnum<OverflowClipBox> unityOverflowClipBox
		{
			get
			{
				if (_unityOverflowClipBox.HasValue
					|| _cachedStyle == null)
				{
					return _unityOverflowClipBox.Value;
				}

				return _cachedStyle.unityOverflowClipBox;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.unityOverflowClipBox = value;
				}

				_unityOverflowClipBox.Value = value;
			}
		}

		public StyleLength unityParagraphSpacing
		{
			get
			{
				if (_unityParagraphSpacing.HasValue
					|| _cachedStyle == null)
				{
					return _unityParagraphSpacing.Value;
				}

				return _cachedStyle.unityParagraphSpacing;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.unityParagraphSpacing = value;
				}

				_unityParagraphSpacing.Value = value;
			}
		}

		public StyleInt unitySliceBottom
		{
			get
			{
				if (_unitySliceBottom.HasValue
					|| _cachedStyle == null)
				{
					return _unitySliceBottom.Value;
				}

				return _cachedStyle.unitySliceBottom;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.unitySliceBottom = value;
				}

				_unitySliceBottom.Value = value;
			}
		}

		public StyleInt unitySliceLeft
		{
			get
			{
				if (_unitySliceLeft.HasValue
					|| _cachedStyle == null)
				{
					return _unitySliceLeft.Value;
				}

				return _cachedStyle.unitySliceLeft;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.unitySliceLeft = value;
				}

				_unitySliceLeft.Value = value;
			}
		}

		public StyleInt unitySliceRight
		{
			get
			{
				if (_unitySliceRight.HasValue
					|| _cachedStyle == null)
				{
					return _unitySliceRight.Value;
				}

				return _cachedStyle.unitySliceRight;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.unitySliceRight = value;
				}

				_unitySliceRight.Value = value;
			}
		}

		public StyleInt unitySliceTop
		{
			get
			{
				if (_unitySliceTop.HasValue
					|| _cachedStyle == null)
				{
					return _unitySliceTop.Value;
				}

				return _cachedStyle.unitySliceTop;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.unitySliceTop = value;
				}

				_unitySliceTop.Value = value;
			}
		}

		public StyleEnum<TextAnchor> unityTextAlign
		{
			get
			{
				if (_unityTextAlign.HasValue
					|| _cachedStyle == null)
				{
					return _unityTextAlign.Value;
				}

				return _cachedStyle.unityTextAlign;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.unityTextAlign = value;
				}

				_unityTextAlign.Value = value;
			}
		}

		public StyleColor unityTextOutlineColor
		{
			get
			{
				if (_unityTextOutlineColor.HasValue
					|| _cachedStyle == null)
				{
					return _unityTextOutlineColor.Value;
				}

				return _cachedStyle.unityTextOutlineColor;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.unityTextOutlineColor = value;
				}

				_unityTextOutlineColor.Value = value;
			}
		}

		public StyleFloat unityTextOutlineWidth
		{
			get
			{
				if (_unityTextOutlineWidth.HasValue
					|| _cachedStyle == null)
				{
					return _unityTextOutlineWidth.Value;
				}

				return _cachedStyle.unityTextOutlineWidth;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.unityTextOutlineWidth = value;
				}

				_unityTextOutlineWidth.Value = value;
			}
		}

		public StyleEnum<TextOverflowPosition> unityTextOverflowPosition
		{
			get
			{
				if (_unityTextOverflowPosition.HasValue
					|| _cachedStyle == null)
				{
					return _unityTextOverflowPosition.Value;
				}

				return _cachedStyle.unityTextOverflowPosition;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.unityTextOverflowPosition = value;
				}

				_unityTextOverflowPosition.Value = value;
			}
		}

		public StyleEnum<Visibility> visibility
		{
			get
			{
				if (_visibility.HasValue
					|| _cachedStyle == null)
				{
					return _visibility.Value;
				}

				return _cachedStyle.visibility;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.visibility = value;
				}

				_visibility.Value = value;
			}
		}

		public StyleEnum<WhiteSpace> whiteSpace
		{
			get
			{
				if (_whiteSpace.HasValue
					|| _cachedStyle == null)
				{
					return _whiteSpace.Value;
				}

				return _cachedStyle.whiteSpace;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.whiteSpace = value;
				}

				_whiteSpace.Value = value;
			}
		}

		public StyleLength width
		{
			get
			{
				if (_width.HasValue
					|| _cachedStyle == null)
				{
					return _width.Value;
				}

				return _cachedStyle.width;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.width = value;
				}

				_width.Value = value;
			}
		}

		public StyleLength wordSpacing
		{
			get
			{
				if (_wordSpacing.HasValue
					|| _cachedStyle == null)
				{
					return _wordSpacing.Value;
				}

				return _cachedStyle.wordSpacing;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.wordSpacing = value;
				}

				_wordSpacing.Value = value;
			}
		}

#if UNITY_2022_2_OR_NEWER
		public StyleBackgroundPosition backgroundPositionX
		{
			get
			{
				if (_backgroundPositionX.HasValue
					|| _cachedStyle == null)
				{
					return _backgroundPositionX.Value;
				}

				return _cachedStyle.backgroundPositionX;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.backgroundPositionX = value;
				}

				_backgroundPositionX.Value = value;
			}
		}

		public StyleBackgroundPosition backgroundPositionY
		{
			get
			{
				if (_backgroundPositionY.HasValue
					|| _cachedStyle == null)
				{
					return _backgroundPositionY.Value;
				}

				return _cachedStyle.backgroundPositionY;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.backgroundPositionY = value;
				}

				_backgroundPositionY.Value = value;
			}
		}

		public StyleBackgroundRepeat backgroundRepeat
		{
			get
			{
				if (_backgroundRepeat.HasValue
					|| _cachedStyle == null)
				{
					return _backgroundRepeat.Value;
				}

				return _cachedStyle.backgroundRepeat;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.backgroundRepeat = value;
				}

				_backgroundRepeat.Value = value;
			}
		}

		public StyleBackgroundSize backgroundSize
		{
			get
			{
				if (_backgroundSize.HasValue
					|| _cachedStyle == null)
				{
					return _backgroundSize.Value;
				}

				return _cachedStyle.backgroundSize;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.backgroundSize = value;
				}

				_backgroundSize.Value = value;
			}
		}

		public StyleFloat unitySliceScale
		{
			get
			{
				if (_unitySliceScale.HasValue
					|| _cachedStyle == null)
				{
					return _unitySliceScale.Value;
				}

				return _cachedStyle.unitySliceScale;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.unitySliceScale = value;
				}

				_unitySliceScale.Value = value;
			}
		}
#endif

#if UNITY_6000_0_OR_NEWER
		public StyleEnum<TextGeneratorType> unityTextGenerator
		{
			get
			{
				if (_unitySliceScale.HasValue
					|| _cachedStyle == null)
				{
					return _unityTextGenerator.Value;
				}

				return _cachedStyle.unityTextGenerator;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.unityTextGenerator = value;
				}

				_unityTextGenerator.Value = value;
			}
		}

		public StyleEnum<EditorTextRenderingMode> unityEditorTextRenderingMode
		{
			get
			{
				if (_unitySliceScale.HasValue
					|| _cachedStyle == null)
				{
					return _unityEditorTextRenderingMode.Value;
				}

				return _cachedStyle.unityEditorTextRenderingMode;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.unityEditorTextRenderingMode = value;
				}

				_unityEditorTextRenderingMode.Value = value;
			}
		}

		public StyleEnum<SliceType> unitySliceType
		{
			get
			{
				if (_unitySliceTop.HasValue
					|| _cachedStyle == null)
				{
					return _unitySliceType.Value;
				}

				return _cachedStyle.unitySliceType;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.unitySliceType = value;
				}

				_unitySliceType.Value = value;
			}
		}
#endif

#if UNITY_6000_2_OR_NEWER
		public StyleTextAutoSize unityTextAutoSize
		{
			get
			{
				if (_unityTextAutoSize.HasValue
					|| _cachedStyle == null)
				{
					return _unityTextAutoSize.Value;
				}

				return _cachedStyle.unityTextAutoSize;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.unityTextAutoSize = value;
				}

				_unityTextAutoSize.Value = value;
			}
		}
#endif

#if UNITY_6000_3_OR_NEWER
		public StyleMaterialDefinition unityMaterial
		{
			get
			{
				if (_unityMaterial.HasValue
					|| _cachedStyle == null)
				{
					return _unityMaterial.Value;
				}

				return _cachedStyle.unityMaterial;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.unityMaterial = value;
				}

				_unityMaterial.Value = value;
			}
		}

		public StyleRatio aspectRatio
		{
			get
			{
				if (_aspectRatio.HasValue
					|| _cachedStyle == null)
				{
					return _aspectRatio.Value;
				}

				return _cachedStyle.aspectRatio;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.aspectRatio = value;
				}

				_aspectRatio.Value = value;
			}
		}

		public StyleList<FilterFunction> filter
		{
			get
			{
				if (_filter.HasValue
					|| _cachedStyle == null)
				{
					return _filter.Value;
				}

				return _cachedStyle.filter;
			}
			set
			{
				if (_cachedStyle != null)
				{
					_cachedStyle.filter = value;
				}

				_filter.Value = value;
			}
		}
#endif

		public void Setup(IStyle style)
		{
			//TODO: Add validation for style
			_cachedStyle = style;
			ForceApply();
		}

		public void Reset()
		{
			_cachedStyle = null;
		}

		private void ForceApply()
		{
			if (_alignContent.HasValue)
			{
				_cachedStyle.alignContent = _alignContent.Value;
			}

			if (_alignItems.HasValue)
			{
				_cachedStyle.alignItems = _alignItems.Value;
			}

			if (_alignSelf.HasValue)
			{
				_cachedStyle.alignSelf = _alignSelf.Value;
			}

			if (_backgroundColor.HasValue)
			{
				_cachedStyle.backgroundColor = _backgroundColor.Value;
			}

			if (_backgroundImage.HasValue)
			{
				_cachedStyle.backgroundImage = _backgroundImage.Value;
			}

			if (_borderBottomColor.HasValue)
			{
				_cachedStyle.borderBottomColor = _borderBottomColor.Value;
			}

			if (_borderBottomLeftRadius.HasValue)
			{
				_cachedStyle.borderBottomLeftRadius = _borderBottomLeftRadius.Value;
			}

			if (_borderBottomRightRadius.HasValue)
			{
				_cachedStyle.borderBottomRightRadius = _borderBottomRightRadius.Value;
			}

			if (_borderBottomWidth.HasValue)
			{
				_cachedStyle.borderBottomWidth = _borderBottomWidth.Value;
			}

			if (_borderLeftColor.HasValue)
			{
				_cachedStyle.borderLeftColor = _borderLeftColor.Value;
			}

			if (_borderLeftWidth.HasValue)
			{
				_cachedStyle.borderLeftWidth = _borderLeftWidth.Value;
			}

			if (_borderRightColor.HasValue)
			{
				_cachedStyle.borderRightColor = _borderRightColor.Value;
			}

			if (_borderRightWidth.HasValue)
			{
				_cachedStyle.borderRightWidth = _borderRightWidth.Value;
			}

			if (_borderTopColor.HasValue)
			{
				_cachedStyle.borderTopColor = _borderTopColor.Value;
			}

			if (_borderTopLeftRadius.HasValue)
			{
				_cachedStyle.borderTopLeftRadius = _borderTopLeftRadius.Value;
			}

			if (_borderTopRightRadius.HasValue)
			{
				_cachedStyle.borderTopRightRadius = _borderTopRightRadius.Value;
			}

			if (_borderTopWidth.HasValue)
			{
				_cachedStyle.borderTopWidth = _borderTopWidth.Value;
			}

			if (_bottom.HasValue)
			{
				_cachedStyle.bottom = _bottom.Value;
			}

			if (_color.HasValue)
			{
				_cachedStyle.color = _color.Value;
			}

			if (_cursor.HasValue)
			{
				_cachedStyle.cursor = _cursor.Value;
			}

			if (_display.HasValue)
			{
				_cachedStyle.display = _display.Value;
			}

			if (_flexBasis.HasValue)
			{
				_cachedStyle.flexBasis = _flexBasis.Value;
			}

			if (_flexDirection.HasValue)
			{
				_cachedStyle.flexDirection = _flexDirection.Value;
			}

			if (_flexGrow.HasValue)
			{
				_cachedStyle.flexGrow = _flexGrow.Value;
			}

			if (_flexShrink.HasValue)
			{
				_cachedStyle.flexShrink = _flexShrink.Value;
			}

			if (_flexWrap.HasValue)
			{
				_cachedStyle.flexWrap = _flexWrap.Value;
			}

			if (_fontSize.HasValue)
			{
				_cachedStyle.fontSize = _fontSize.Value;
			}

			if (_height.HasValue)
			{
				_cachedStyle.height = _height.Value;
			}

			if (_justifyContent.HasValue)
			{
				_cachedStyle.justifyContent = _justifyContent.Value;
			}

			if (_left.HasValue)
			{
				_cachedStyle.left = _left.Value;
			}

			if (_letterSpacing.HasValue)
			{
				_cachedStyle.letterSpacing = _letterSpacing.Value;
			}

			if (_marginBottom.HasValue)
			{
				_cachedStyle.marginBottom = _marginBottom.Value;
			}

			if (_marginLeft.HasValue)
			{
				_cachedStyle.marginLeft = _marginLeft.Value;
			}

			if (_marginRight.HasValue)
			{
				_cachedStyle.marginRight = _marginRight.Value;
			}

			if (_marginTop.HasValue)
			{
				_cachedStyle.marginTop = _marginTop.Value;
			}

			if (_maxHeight.HasValue)
			{
				_cachedStyle.maxHeight = _maxHeight.Value;
			}

			if (_maxWidth.HasValue)
			{
				_cachedStyle.maxWidth = _maxWidth.Value;
			}

			if (_minHeight.HasValue)
			{
				_cachedStyle.minHeight = _minHeight.Value;
			}

			if (_minWidth.HasValue)
			{
				_cachedStyle.minWidth = _minWidth.Value;
			}

			if (_alignContent.HasValue)
			{
				_cachedStyle.opacity = _opacity.Value;
			}

			if (_overflow.HasValue)
			{
				_cachedStyle.overflow = _overflow.Value;
			}

			if (_paddingBottom.HasValue)
			{
				_cachedStyle.paddingBottom = _paddingBottom.Value;
			}

			if (_paddingLeft.HasValue)
			{
				_cachedStyle.paddingLeft = _paddingLeft.Value;
			}

			if (_paddingRight.HasValue)
			{
				_cachedStyle.paddingRight = _paddingRight.Value;
			}

			if (_paddingTop.HasValue)
			{
				_cachedStyle.paddingTop = _paddingTop.Value;
			}

			if (_position.HasValue)
			{
				_cachedStyle.position = _position.Value;
			}

			if (_right.HasValue)
			{
				_cachedStyle.right = _right.Value;
			}

			if (_rotate.HasValue)
			{
				_cachedStyle.rotate = _rotate.Value;
			}

			if (_scale.HasValue)
			{
				_cachedStyle.scale = _scale.Value;
			}

			if (_textOverflow.HasValue)
			{
				_cachedStyle.textOverflow = _textOverflow.Value;
			}

			if (_textShadow.HasValue)
			{
				_cachedStyle.textShadow = _textShadow.Value;
			}

			if (_top.HasValue)
			{
				_cachedStyle.top = _top.Value;
			}

			if (_transformOrigin.HasValue)
			{
				_cachedStyle.transformOrigin = _transformOrigin.Value;
			}

			if (_transitionDelay.HasValue)
			{
				_cachedStyle.transitionDelay = _transitionDelay.Value;
			}

			if (_transitionDuration.HasValue)
			{
				_cachedStyle.transitionDuration = _transitionDuration.Value;
			}

			if (_transitionProperty.HasValue)
			{
				_cachedStyle.transitionProperty = _transitionProperty.Value;
			}

			if (_transitionTimingFunction.HasValue)
			{
				_cachedStyle.transitionTimingFunction = _transitionTimingFunction.Value;
			}

			if (_translate.HasValue)
			{
				_cachedStyle.translate = _translate.Value;
			}

			if (_unityBackgroundImageTintColor.HasValue)
			{
				_cachedStyle.unityBackgroundImageTintColor = _unityBackgroundImageTintColor.Value;
			}

			if (_unityBackgroundScaleMode.HasValue)
			{
				_cachedStyle.unityBackgroundScaleMode = _unityBackgroundScaleMode.Value;
			}

			if (_unityFont.HasValue)
			{
				_cachedStyle.unityFont = _unityFont.Value;
			}

			if (_unityFontDefinition.HasValue)
			{
				_cachedStyle.unityFontDefinition = _unityFontDefinition.Value;
			}

			if (_unityFontStyleAndWeight.HasValue)
			{
				_cachedStyle.unityFontStyleAndWeight = _unityFontStyleAndWeight.Value;
			}

			if (_unityOverflowClipBox.HasValue)
			{
				_cachedStyle.unityOverflowClipBox = _unityOverflowClipBox.Value;
			}

			if (_unityParagraphSpacing.HasValue)
			{
				_cachedStyle.unityParagraphSpacing = _unityParagraphSpacing.Value;
			}

			if (_unitySliceBottom.HasValue)
			{
				_cachedStyle.unitySliceBottom = _unitySliceBottom.Value;
			}

			if (_unitySliceTop.HasValue)
			{
				_cachedStyle.unitySliceLeft = _unitySliceTop.Value;
			}

			if (_unitySliceTop.HasValue)
			{
				_cachedStyle.unitySliceRight = _unitySliceTop.Value;
			}

			if (_unitySliceTop.HasValue)
			{
				_cachedStyle.unitySliceTop = _unitySliceTop.Value;
			}

			if (_unityTextAlign.HasValue)
			{
				_cachedStyle.unityTextAlign = _unityTextAlign.Value;
			}

			if (_unityTextOutlineColor.HasValue)
			{
				_cachedStyle.unityTextOutlineColor = _unityTextOutlineColor.Value;
			}

			if (_unityTextOutlineWidth.HasValue)
			{
				_cachedStyle.unityTextOutlineWidth = _unityTextOutlineWidth.Value;
			}

			if (_unityTextOverflowPosition.HasValue)
			{
				_cachedStyle.unityTextOverflowPosition = _unityTextOverflowPosition.Value;
			}

			if (_visibility.HasValue)
			{
				_cachedStyle.visibility = _visibility.Value;
			}

			if (_whiteSpace.HasValue)
			{
				_cachedStyle.whiteSpace = _whiteSpace.Value;
			}

			if (_width.HasValue)
			{
				_cachedStyle.width = _width.Value;
			}

			if (_wordSpacing.HasValue)
			{
				_cachedStyle.wordSpacing = _wordSpacing.Value;
			}

#if UNITY_2022_2_OR_NEWER
			if (_backgroundPositionX.HasValue)
			{
				_cachedStyle.backgroundPositionX = _backgroundPositionX.Value;
			}

			if (_backgroundPositionY.HasValue)
			{
				_cachedStyle.backgroundPositionY = _backgroundPositionY.Value;
			}

			if (_backgroundRepeat.HasValue)
			{
				_cachedStyle.backgroundRepeat = _backgroundRepeat.Value;
			}

			if (_backgroundSize.HasValue)
			{
				_cachedStyle.backgroundSize = _backgroundSize.Value;
			}

			if (_unitySliceScale.HasValue)
			{
				_cachedStyle.unitySliceScale = _unitySliceScale.Value;
			}
#endif

#if UNITY_6000_0_OR_NEWER
			if (_unityTextGenerator.HasValue)
			{
				_cachedStyle.unityTextGenerator = _unityTextGenerator.Value;
			}

			if (_unityEditorTextRenderingMode.HasValue)
			{
				_cachedStyle.unityEditorTextRenderingMode = _unityEditorTextRenderingMode.Value;
			}

			if (_unitySliceType.HasValue)
			{
				_cachedStyle.unitySliceType = _unitySliceType.Value;
			}
#endif

#if UNITY_6000_2_OR_NEWER
			if (_unityTextAutoSize.HasValue)
			{
				_cachedStyle.unityTextAutoSize = _unityTextAutoSize.Value;
			}
#endif
			
#if UNITY_6000_3_OR_NEWER
			if (_unityMaterial.HasValue)
			{
				_cachedStyle.unityMaterial = _unityMaterial.Value;
			}
			
			if (_filter.HasValue)
			{
				_cachedStyle.filter = _filter.Value;
			}
			
			if (_aspectRatio.HasValue)
			{
				_cachedStyle.aspectRatio = _aspectRatio.Value;
			}
#endif
		}
	}
}