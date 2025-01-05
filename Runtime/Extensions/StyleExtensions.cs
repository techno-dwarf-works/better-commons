using System.Collections.Generic;
using System.Linq;
using Better.Commons.Runtime.Helpers.Styles;
using UnityEngine;
using UnityEngine.UIElements;

namespace Better.Commons.Runtime.Extensions
{
    public static class StyleExtensions
    {
        public static void CopyFrom(this IStyle self, IStyle source)
        {
            self.alignContent = source.alignContent;
            self.alignItems = source.alignItems;
            self.alignSelf = source.alignSelf;
            self.backgroundColor = source.backgroundColor;
            self.backgroundImage = source.backgroundImage;
            self.borderBottomColor = source.borderBottomColor;
            self.borderBottomLeftRadius = source.borderBottomLeftRadius;
            self.borderBottomRightRadius = source.borderBottomRightRadius;
            self.borderBottomWidth = source.borderBottomWidth;
            self.borderLeftColor = source.borderLeftColor;
            self.borderLeftWidth = source.borderLeftWidth;
            self.borderRightColor = source.borderRightColor;
            self.borderRightWidth = source.borderRightWidth;
            self.borderTopColor = source.borderTopColor;
            self.borderTopLeftRadius = source.borderTopLeftRadius;
            self.borderTopRightRadius = source.borderTopRightRadius;
            self.borderTopWidth = source.borderTopWidth;
            self.bottom = source.bottom;
            self.color = source.color;
            self.cursor = source.cursor;
            self.display = source.display;
            self.flexBasis = source.flexBasis;
            self.flexDirection = source.flexDirection;
            self.flexGrow = source.flexGrow;
            self.flexShrink = source.flexShrink;
            self.flexWrap = source.flexWrap;
            self.fontSize = source.fontSize;
            self.height = source.height;
            self.justifyContent = source.justifyContent;
            self.left = source.left;
            self.letterSpacing = source.letterSpacing;
            self.marginBottom = source.marginBottom;
            self.marginLeft = source.marginLeft;
            self.marginRight = source.marginRight;
            self.marginTop = source.marginTop;
            self.maxHeight = source.maxHeight;
            self.maxWidth = source.maxWidth;
            self.minHeight = source.minHeight;
            self.minWidth = source.minWidth;
            self.opacity = source.opacity;
            self.overflow = source.overflow;
            self.paddingBottom = source.paddingBottom;
            self.paddingLeft = source.paddingLeft;
            self.paddingRight = source.paddingRight;
            self.paddingTop = source.paddingTop;
            self.position = source.position;
            self.right = source.right;
            self.rotate = source.rotate;
            self.scale = source.scale;
            self.textOverflow = source.textOverflow;
            self.textShadow = source.textShadow;
            self.top = source.top;
            self.transformOrigin = source.transformOrigin;
            self.transitionDelay = source.transitionDelay;
            self.transitionDuration = source.transitionDuration;
            self.transitionProperty = source.transitionProperty;
            self.transitionTimingFunction = source.transitionTimingFunction;
            self.translate = source.translate;
            self.unityBackgroundImageTintColor = source.unityBackgroundImageTintColor;
            self.unityBackgroundScaleMode = source.unityBackgroundScaleMode;
            self.unityFont = source.unityFont;
            self.unityFontDefinition = source.unityFontDefinition;
            self.unityFontStyleAndWeight = source.unityFontStyleAndWeight;
            self.unityOverflowClipBox = source.unityOverflowClipBox;
            self.unityParagraphSpacing = source.unityParagraphSpacing;
            self.unitySliceBottom = source.unitySliceBottom;
            self.unitySliceLeft = source.unitySliceLeft;
            self.unitySliceRight = source.unitySliceRight;
            self.unitySliceTop = source.unitySliceTop;
            self.unityTextAlign = source.unityTextAlign;
            self.unityTextOutlineColor = source.unityTextOutlineColor;
            self.unityTextOutlineWidth = source.unityTextOutlineWidth;
            self.unityTextOverflowPosition = source.unityTextOverflowPosition;
            self.visibility = source.visibility;
            self.whiteSpace = source.whiteSpace;
            self.width = source.width;
            self.wordSpacing = source.wordSpacing;

#if UNITY_2022_2_OR_NEWER
            self.backgroundPositionX = source.backgroundPositionX;
            self.backgroundPositionY = source.backgroundPositionY;
            self.backgroundRepeat = source.backgroundRepeat;
            self.backgroundSize = source.backgroundSize;
            self.unitySliceScale = source.unitySliceScale;
#endif

#if UNITY_6000_0_OR_NEWER
            self.unityTextGenerator = source.unityTextGenerator;
            self.unityEditorTextRenderingMode = source.unityEditorTextRenderingMode;
#endif
        }

        public static IStyle AsGroup(this IEnumerable<IStyle> self)
        {
            var styles = self.ToList();
            var group = new StyleGroup(styles);
            return group;
        }

        public static IStyle SetVisible(this IStyle self, bool visible)
        {
            var visibility = visible ? UnityEngine.UIElements.Visibility.Visible : UnityEngine.UIElements.Visibility.Hidden;
            var displayStyle = visible ? StyleKeyword.Auto : StyleKeyword.None;
            return self.Visibility(visibility).Display(displayStyle);
        }

        public static IStyle AlignContent(this IStyle self, StyleEnum<Align> alignContent)
        {
            self.alignContent = alignContent;
            return self;
        }

        public static IStyle AlignItems(this IStyle self, StyleEnum<Align> alignItems)
        {
            self.alignItems = alignItems;
            return self;
        }

        public static IStyle AlignSelf(this IStyle self, StyleEnum<Align> alignSelf)
        {
            self.alignSelf = alignSelf;
            return self;
        }

        public static IStyle BackgroundColor(this IStyle self, StyleColor backgroundColor)
        {
            self.backgroundColor = backgroundColor;
            return self;
        }

        public static IStyle BackgroundImage(this IStyle self, StyleBackground backgroundImage)
        {
            self.backgroundImage = backgroundImage;
            return self;
        }

        public static IStyle BorderTopColor(this IStyle self, StyleColor borderTopColor)
        {
            self.borderTopColor = borderTopColor;
            return self;
        }

        public static IStyle BorderBottomColor(this IStyle self, StyleColor borderBottomColor)
        {
            self.borderBottomColor = borderBottomColor;
            return self;
        }

        public static IStyle BorderLeftColor(this IStyle self, StyleColor borderLeftColor)
        {
            self.borderLeftColor = borderLeftColor;
            return self;
        }

        public static IStyle BorderRightColor(this IStyle self, StyleColor borderRightColor)
        {
            self.borderRightColor = borderRightColor;
            return self;
        }

        public static IStyle BorderColor(this IStyle self, StyleColor borderColor)
        {
            self.borderTopColor = borderColor;
            self.borderLeftColor = borderColor;
            self.borderRightColor = borderColor;
            self.borderBottomColor = borderColor;
            return self;
        }

        public static IStyle BorderBottomLeftRadius(this IStyle self, StyleLength borderBottomLeftRadius)
        {
            self.borderBottomLeftRadius = borderBottomLeftRadius;
            return self;
        }

        public static IStyle BorderBottomRightRadius(this IStyle self, StyleLength borderBottomRightRadius)
        {
            self.borderBottomRightRadius = borderBottomRightRadius;
            return self;
        }

        public static IStyle BorderBottomWidth(this IStyle self, StyleFloat borderBottomWidth)
        {
            self.borderBottomWidth = borderBottomWidth;
            return self;
        }

        public static IStyle BorderWidth(this IStyle self, StyleFloat width)
        {
            self.borderTopWidth = width;
            self.borderRightWidth = width;
            self.borderBottomWidth = width;
            self.borderLeftWidth = width;
            return self;
        }

        public static IStyle BorderLeftWidth(this IStyle self, StyleFloat borderLeftWidth)
        {
            self.borderLeftWidth = borderLeftWidth;
            return self;
        }

        public static IStyle BorderRightWidth(this IStyle self, StyleFloat borderRightWidth)
        {
            self.borderRightWidth = borderRightWidth;
            return self;
        }

        public static IStyle BorderTopLeftRadius(this IStyle self, StyleLength borderTopLeftRadius)
        {
            self.borderTopLeftRadius = borderTopLeftRadius;
            return self;
        }

        public static IStyle BorderTopRightRadius(this IStyle self, StyleLength borderTopRightRadius)
        {
            self.borderTopRightRadius = borderTopRightRadius;
            return self;
        }

        public static IStyle BorderTopWidth(this IStyle self, StyleFloat borderTopWidth)
        {
            self.borderTopWidth = borderTopWidth;
            return self;
        }

        public static IStyle Bottom(this IStyle self, StyleLength bottom)
        {
            self.bottom = bottom;
            return self;
        }

        public static IStyle Color(this IStyle self, StyleColor color)
        {
            self.color = color;
            return self;
        }

        public static IStyle Cursor(this IStyle self, StyleCursor cursor)
        {
            self.cursor = cursor;
            return self;
        }

        public static IStyle Display(this IStyle self, StyleEnum<DisplayStyle> display)
        {
            self.display = display;
            return self;
        }

        public static IStyle FlexBasis(this IStyle self, StyleLength flexBasis)
        {
            self.flexBasis = flexBasis;
            return self;
        }

        public static IStyle FlexDirection(this IStyle self, StyleEnum<FlexDirection> flexDirection)
        {
            self.flexDirection = flexDirection;
            return self;
        }

        public static IStyle FlexGrow(this IStyle self, StyleFloat flexGrow)
        {
            self.flexGrow = flexGrow;
            return self;
        }

        public static IStyle FlexShrink(this IStyle self, StyleFloat flexShrink)
        {
            self.flexShrink = flexShrink;
            return self;
        }

        public static IStyle FlexWrap(this IStyle self, StyleEnum<Wrap> flexWrap)
        {
            self.flexWrap = flexWrap;
            return self;
        }

        public static IStyle FontSize(this IStyle self, StyleLength fontSize)
        {
            self.fontSize = fontSize;
            return self;
        }

        public static IStyle Height(this IStyle self, StyleLength height)
        {
            self.height = height;
            return self;
        }

        public static IStyle Width(this IStyle self, StyleLength height)
        {
            self.width = height;
            return self;
        }

        public static IStyle JustifyContent(this IStyle self, StyleEnum<Justify> justifyContent)
        {
            self.justifyContent = justifyContent;
            return self;
        }

        public static IStyle Left(this IStyle self, StyleLength left)
        {
            self.left = left;
            return self;
        }

        public static IStyle LetterSpacing(this IStyle self, StyleLength letterSpacing)
        {
            self.letterSpacing = letterSpacing;
            return self;
        }

        public static IStyle MarginBottom(this IStyle self, StyleLength marginBottom)
        {
            self.marginBottom = marginBottom;
            return self;
        }

        public static IStyle MarginLeft(this IStyle self, StyleLength marginLeft)
        {
            self.marginLeft = marginLeft;
            return self;
        }

        public static IStyle MarginRight(this IStyle self, StyleLength marginRight)
        {
            self.marginRight = marginRight;
            return self;
        }

        public static IStyle MarginTop(this IStyle self, StyleLength marginTop)
        {
            self.marginTop = marginTop;
            return self;
        }

        public static IStyle Margin(this IStyle self, StyleLength marginTop)
        {
            self.marginTop = marginTop;
            self.marginRight = marginTop;
            self.marginBottom = marginTop;
            self.marginLeft = marginTop;
            return self;
        }

        public static IStyle MaxHeight(this IStyle self, StyleLength maxHeight)
        {
            self.maxHeight = maxHeight;
            return self;
        }

        public static IStyle MaxWidth(this IStyle self, StyleLength maxWidth)
        {
            self.maxWidth = maxWidth;
            return self;
        }

        public static IStyle MinHeight(this IStyle self, StyleLength minHeight)
        {
            self.minHeight = minHeight;
            return self;
        }

        public static IStyle MinWidth(this IStyle self, StyleLength minWidth)
        {
            self.minWidth = minWidth;
            return self;
        }

        public static IStyle Opacity(this IStyle self, StyleFloat opacity)
        {
            self.opacity = opacity;
            return self;
        }

        public static IStyle Overflow(this IStyle self, StyleEnum<Overflow> overflow)
        {
            self.overflow = overflow;
            return self;
        }

        public static IStyle PaddingBottom(this IStyle self, StyleLength paddingBottom)
        {
            self.paddingBottom = paddingBottom;
            return self;
        }

        public static IStyle PaddingLeft(this IStyle self, StyleLength paddingLeft)
        {
            self.paddingLeft = paddingLeft;
            return self;
        }

        public static IStyle PaddingRight(this IStyle self, StyleLength paddingRight)
        {
            self.paddingRight = paddingRight;
            return self;
        }

        public static IStyle PaddingTop(this IStyle self, StyleLength paddingTop)
        {
            self.paddingTop = paddingTop;
            return self;
        }

        public static IStyle Padding(this IStyle self, StyleLength padding)
        {
            self.paddingTop = padding;
            self.paddingRight = padding;
            self.paddingBottom = padding;
            self.paddingLeft = padding;
            return self;
        }

        public static IStyle Position(this IStyle self, StyleEnum<Position> position)
        {
            self.position = position;
            return self;
        }

        public static IStyle Right(this IStyle self, StyleLength right)
        {
            self.right = right;
            return self;
        }

        public static IStyle Rotate(this IStyle self, StyleRotate rotate)
        {
            self.rotate = rotate;
            return self;
        }

        public static IStyle Scale(this IStyle self, StyleScale scale)
        {
            self.scale = scale;
            return self;
        }

        public static IStyle TextOverflow(this IStyle self, StyleEnum<TextOverflow> textOverflow)
        {
            self.textOverflow = textOverflow;
            return self;
        }

        public static IStyle TextShadow(this IStyle self, StyleTextShadow textShadow)
        {
            self.textShadow = textShadow;
            return self;
        }

        public static IStyle Top(this IStyle self, StyleLength top)
        {
            self.top = top;
            return self;
        }

        public static IStyle TransformOrigin(this IStyle self, StyleTransformOrigin transformOrigin)
        {
            self.transformOrigin = transformOrigin;
            return self;
        }

        public static IStyle TransitionDelay(this IStyle self, StyleList<TimeValue> transitionDelay)
        {
            self.transitionDelay = transitionDelay;
            return self;
        }

        public static IStyle TransitionDuration(this IStyle self, StyleList<TimeValue> transitionDuration)
        {
            self.transitionDuration = transitionDuration;
            return self;
        }

        public static IStyle TransitionProperty(this IStyle self, StyleList<StylePropertyName> transitionProperty)
        {
            self.transitionProperty = transitionProperty;
            return self;
        }

        public static IStyle TransitionTimingFunction(this IStyle self, StyleList<EasingFunction> transitionTimingFunction)
        {
            self.transitionTimingFunction = transitionTimingFunction;
            return self;
        }

        public static IStyle Translate(this IStyle self, StyleTranslate translate)
        {
            self.translate = translate;
            return self;
        }

        public static IStyle UnityBackgroundImageTintColor(this IStyle self, StyleColor unityBackgroundImageTintColor)
        {
            self.unityBackgroundImageTintColor = unityBackgroundImageTintColor;
            return self;
        }

        public static IStyle UnityBackgroundScaleMode(this IStyle self, StyleEnum<ScaleMode> unityBackgroundScaleMode)
        {
            self.unityBackgroundScaleMode = unityBackgroundScaleMode;
            return self;
        }

        public static IStyle UnityFont(this IStyle self, StyleFont unityFont)
        {
            self.unityFont = unityFont;
            return self;
        }

        public static IStyle UnityFontDefinition(this IStyle self, StyleFontDefinition unityFontDefinition)
        {
            self.unityFontDefinition = unityFontDefinition;
            return self;
        }

        public static IStyle UnityFontStyleAndWeight(this IStyle self, StyleEnum<FontStyle> unityFontStyleAndWeight)
        {
            self.unityFontStyleAndWeight = unityFontStyleAndWeight;
            return self;
        }

        public static IStyle UnityOverflowClipBox(this IStyle self, StyleEnum<OverflowClipBox> unityOverflowClipBox)
        {
            self.unityOverflowClipBox = unityOverflowClipBox;
            return self;
        }

        public static IStyle UnityParagraphSpacing(this IStyle self, StyleLength unityParagraphSpacing)
        {
            self.unityParagraphSpacing = unityParagraphSpacing;
            return self;
        }

        public static IStyle UnitySliceBottom(this IStyle self, StyleInt unitySliceBottom)
        {
            self.unitySliceBottom = unitySliceBottom;
            return self;
        }

        public static IStyle UnitySliceLeft(this IStyle self, StyleInt unitySliceLeft)
        {
            self.unitySliceLeft = unitySliceLeft;
            return self;
        }

        public static IStyle UnitySliceRight(this IStyle self, StyleInt unitySliceRight)
        {
            self.unitySliceRight = unitySliceRight;
            return self;
        }

        public static IStyle UnitySliceTop(this IStyle self, StyleInt unitySliceTop)
        {
            self.unitySliceTop = unitySliceTop;
            return self;
        }

        public static IStyle UnityTextAlign(this IStyle self, StyleEnum<TextAnchor> unityTextAlign)
        {
            self.unityTextAlign = unityTextAlign;
            return self;
        }

        public static IStyle UnityTextOutlineColor(this IStyle self, StyleColor unityTextOutlineColor)
        {
            self.unityTextOutlineColor = unityTextOutlineColor;
            return self;
        }

        public static IStyle UnityTextOutlineWidth(this IStyle self, StyleFloat unityTextOutlineWidth)
        {
            self.unityTextOutlineWidth = unityTextOutlineWidth;
            return self;
        }

        public static IStyle UnityTextOverflowPosition(this IStyle self, StyleEnum<TextOverflowPosition> unityTextOverflowPosition)
        {
            self.unityTextOverflowPosition = unityTextOverflowPosition;
            return self;
        }

        public static IStyle Visibility(this IStyle self, StyleEnum<Visibility> visibility)
        {
            self.visibility = visibility;
            return self;
        }

        public static IStyle WhiteSpace(this IStyle self, StyleEnum<WhiteSpace> whiteSpace)
        {
            self.whiteSpace = whiteSpace;
            return self;
        }

        public static IStyle WordSpacing(this IStyle self, StyleLength wordSpacing)
        {
            self.wordSpacing = wordSpacing;
            return self;
        }
    }
}