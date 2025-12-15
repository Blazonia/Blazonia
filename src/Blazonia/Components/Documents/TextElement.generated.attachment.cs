using ACD = Avalonia.Controls.Documents;
using Blazonia.Components;            
using System.Runtime.Versioning;

namespace Blazonia.Components
{
    [RequiresPreviewFeatures]
    internal static class TextElementInitializer
    {
        [System.Runtime.CompilerServices.ModuleInitializer]
        internal static void RegisterAdditionalHandlers()
        {
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("TextElement.FontFamily",
                (element, value) =>
                {
                    if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(ACD.TextElement.FontFamilyProperty);
                    }
                    else
                    {
                        ACD.TextElement.SetFontFamily((Avalonia.Controls.Control)element, (global::Avalonia.Media.FontFamily)value);
                    }
                });
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("TextElement.FontFeatures",
                (element, value) =>
                {
                    if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(ACD.TextElement.FontFeaturesProperty);
                    }
                    else
                    {
                        ACD.TextElement.SetFontFeatures((Avalonia.Controls.Control)element, (global::Avalonia.Media.FontFeatureCollection)value);
                    }
                });
        AttachedPropertyRegistry.RegisterAttachedPropertyHandler("TextElement.FontSize",
            (element, value) =>
            {
                if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                {
                    element.ClearValue(ACD.TextElement.FontSizeProperty);
                }
                else
                {
                    if (value is string s)
                    {
                        ACD.TextElement.SetFontSize((Avalonia.Controls.Control)element, double.Parse(s));
                    }
                    else
                    {
                        ACD.TextElement.SetFontSize((Avalonia.Controls.Control)element, (double)value);
                    }
                }
            });
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("TextElement.FontStretch",
                (element, value) =>
                {
                    if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(ACD.TextElement.FontStretchProperty);
                    }
                    else
                    {
                        ACD.TextElement.SetFontStretch((Avalonia.Controls.Control)element, (global::Avalonia.Media.FontStretch)value);
                    }
                });
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("TextElement.FontStyle",
                (element, value) =>
                {
                    if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(ACD.TextElement.FontStyleProperty);
                    }
                    else
                    {
                        ACD.TextElement.SetFontStyle((Avalonia.Controls.Control)element, (global::Avalonia.Media.FontStyle)value);
                    }
                });
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("TextElement.FontWeight",
                (element, value) =>
                {
                    if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(ACD.TextElement.FontWeightProperty);
                    }
                    else
                    {
                        ACD.TextElement.SetFontWeight((Avalonia.Controls.Control)element, (global::Avalonia.Media.FontWeight)value);
                    }
                });
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("TextElement.Foreground",
                (element, value) =>
                {
                    if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(ACD.TextElement.ForegroundProperty);
                    }
                    else
                    {
                        ACD.TextElement.SetForeground((Avalonia.Controls.Control)element, (global::Avalonia.Media.IBrush)value);
                    }
                });
        }
    }

    public static class TextElementExtensions
    {
        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.Documents.TextElement.FontFamily" /> property.
        /// </summary>
        public static Control TextElementFontFamily(this Control element, global::Avalonia.Media.FontFamily value)
        {
            element.AttachedProperties["TextElement.FontFamily"] = value;
        
            return element;
        }
        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.Documents.TextElement.FontFeatures" /> property.
        /// </summary>
        public static Control TextElementFontFeatures(this Control element, global::Avalonia.Media.FontFeatureCollection value)
        {
            element.AttachedProperties["TextElement.FontFeatures"] = value;
        
            return element;
        }
        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.Documents.TextElement.FontSize" /> property.
        /// </summary>
        public static Control TextElementFontSize(this Control element, double value)
        {
            element.AttachedProperties["TextElement.FontSize"] = value;
        
            return element;
        }
        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.Documents.TextElement.FontStretch" /> property.
        /// </summary>
        public static Control TextElementFontStretch(this Control element, global::Avalonia.Media.FontStretch value)
        {
            element.AttachedProperties["TextElement.FontStretch"] = value;
        
            return element;
        }
        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.Documents.TextElement.FontStyle" /> property.
        /// </summary>
        public static Control TextElementFontStyle(this Control element, global::Avalonia.Media.FontStyle value)
        {
            element.AttachedProperties["TextElement.FontStyle"] = value;
        
            return element;
        }
        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.Documents.TextElement.FontWeight" /> property.
        /// </summary>
        public static Control TextElementFontWeight(this Control element, global::Avalonia.Media.FontWeight value)
        {
            element.AttachedProperties["TextElement.FontWeight"] = value;
        
            return element;
        }
        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.Documents.TextElement.Foreground" /> property.
        /// </summary>
        public static Control TextElementForeground(this Control element, global::Avalonia.Media.IBrush value)
        {
            element.AttachedProperties["TextElement.Foreground"] = value;
        
            return element;
        }
    }

    public class TextElement_Attachment : NativeControlComponentBase, INonPhysicalChild, IContainerElementHandler
    {
        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.Documents.TextElement.FontFamily" /> property.
        /// </summary>
        [Parameter] public OneOf.OneOf<global::Avalonia.Media.FontFamily, string> FontFamily { get; set; }

        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.Documents.TextElement.FontFeatures" /> property.
        /// </summary>
        [Parameter] public global::Avalonia.Media.FontFeatureCollection FontFeatures { get; set; }

        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.Documents.TextElement.FontSize" /> property.
        /// </summary>
        [Parameter] public double FontSize { get; set; }

        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.Documents.TextElement.FontStretch" /> property.
        /// </summary>
        [Parameter] public global::Avalonia.Media.FontStretch FontStretch { get; set; }

        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.Documents.TextElement.FontStyle" /> property.
        /// </summary>
        [Parameter] public global::Avalonia.Media.FontStyle FontStyle { get; set; }

        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.Documents.TextElement.FontWeight" /> property.
        /// </summary>
        [Parameter] public global::Avalonia.Media.FontWeight FontWeight { get; set; }

        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.Documents.TextElement.Foreground" /> property.
        /// </summary>
        [Parameter] public global::Avalonia.Media.IBrush Foreground { get; set; }

        private Avalonia.Controls.Control _parent;

        public object TargetElement => _parent;

        public override Task SetParametersAsync(ParameterView parameters)
        {
            foreach (var parameterValue in parameters)
            {
                var value = parameterValue.Value;
                switch (parameterValue.Name)
                {
                    case nameof(FontFamily):
                    if (!Equals(FontFamily, value))
                    {
                        FontFamily = (global::Avalonia.Media.FontFamily)value;
                        //NativeControl.FontFamilyProperty = FontFamily;
                    }
                    break;

                    case nameof(FontFeatures):
                    if (!Equals(FontFeatures, value))
                    {
                        FontFeatures = (global::Avalonia.Media.FontFeatureCollection)value;
                        //NativeControl.FontFeaturesProperty = FontFeatures;
                    }
                    break;

                    case nameof(FontSize):
                    if (!Equals(FontSize, value))
                    {
                        FontSize = (double)value;
                        //NativeControl.FontSizeProperty = FontSize;
                    }
                    break;

                    case nameof(FontStretch):
                    if (!Equals(FontStretch, value))
                    {
                        FontStretch = (global::Avalonia.Media.FontStretch)value;
                        //NativeControl.FontStretchProperty = FontStretch;
                    }
                    break;

                    case nameof(FontStyle):
                    if (!Equals(FontStyle, value))
                    {
                        FontStyle = (global::Avalonia.Media.FontStyle)value;
                        //NativeControl.FontStyleProperty = FontStyle;
                    }
                    break;

                    case nameof(FontWeight):
                    if (!Equals(FontWeight, value))
                    {
                        FontWeight = (global::Avalonia.Media.FontWeight)value;
                        //NativeControl.FontWeightProperty = FontWeight;
                    }
                    break;

                    case nameof(Foreground):
                    if (!Equals(Foreground, value))
                    {
                        Foreground = (global::Avalonia.Media.IBrush)value;
                        //NativeControl.ForegroundProperty = Foreground;
                    }
                    break;

                }
            }
        
            TryUpdateParent(_parent);
            return base.SetParametersAsync(ParameterView.Empty);
        }

        private void TryUpdateParent(object parentElement)
        {
            if (parentElement is not null)
            {
                {
                    global::Avalonia.Media.FontFamily value = default;
                    if (FontFamily.IsT0)
                    {
                        value = FontFamily.AsT0;
                    }
                    else
                    {
                        value = global::Avalonia.Media.FontFamily.Parse(FontFamily.AsT1);
                    }
                    if (value == global::Avalonia.Controls.Documents.TextElement.FontFamilyProperty.GetDefaultValue(parentElement.GetType()))
                    {
                        ((Avalonia.Controls.Control)parentElement).ClearValue( global::Avalonia.Controls.Documents.TextElement.FontFamilyProperty);
                    }
                    else
                    {
                        global::Avalonia.Controls.Documents.TextElement.SetFontFamily((Avalonia.Controls.Control)parentElement, value);
                    }
                }
                
                if (FontFeatures == global::Avalonia.Controls.Documents.TextElement.FontFeaturesProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Control)parentElement).ClearValue( global::Avalonia.Controls.Documents.TextElement.FontFeaturesProperty);
                }
                else
                {
                     global::Avalonia.Controls.Documents.TextElement.SetFontFeatures((Avalonia.Controls.Control)parentElement, FontFeatures);
                }
                
                if (FontSize == global::Avalonia.Controls.Documents.TextElement.FontSizeProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Control)parentElement).ClearValue( global::Avalonia.Controls.Documents.TextElement.FontSizeProperty);
                }
                else
                {
                     global::Avalonia.Controls.Documents.TextElement.SetFontSize((Avalonia.Controls.Control)parentElement, FontSize);
                }
                
                if (FontStretch == global::Avalonia.Controls.Documents.TextElement.FontStretchProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Control)parentElement).ClearValue( global::Avalonia.Controls.Documents.TextElement.FontStretchProperty);
                }
                else
                {
                     global::Avalonia.Controls.Documents.TextElement.SetFontStretch((Avalonia.Controls.Control)parentElement, FontStretch);
                }
                
                if (FontStyle == global::Avalonia.Controls.Documents.TextElement.FontStyleProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Control)parentElement).ClearValue( global::Avalonia.Controls.Documents.TextElement.FontStyleProperty);
                }
                else
                {
                     global::Avalonia.Controls.Documents.TextElement.SetFontStyle((Avalonia.Controls.Control)parentElement, FontStyle);
                }
                
                if (FontWeight == global::Avalonia.Controls.Documents.TextElement.FontWeightProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Control)parentElement).ClearValue( global::Avalonia.Controls.Documents.TextElement.FontWeightProperty);
                }
                else
                {
                     global::Avalonia.Controls.Documents.TextElement.SetFontWeight((Avalonia.Controls.Control)parentElement, FontWeight);
                }
                
                if (Foreground == global::Avalonia.Controls.Documents.TextElement.ForegroundProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Control)parentElement).ClearValue( global::Avalonia.Controls.Documents.TextElement.ForegroundProperty);
                }
                else
                {
                     global::Avalonia.Controls.Documents.TextElement.SetForeground((Avalonia.Controls.Control)parentElement, Foreground);
                }
                
            }
        }
    
        void INonPhysicalChild.SetParent(object parentElement)
        {
            var parentType = parentElement?.GetType();
            if (parentType is not null)
            {
                if (FontFamily.IsT1 == false && FontFamily.AsT0 == default)
                {
                    FontFamily = global::Avalonia.Controls.Documents.TextElement.FontFamilyProperty.GetDefaultValue(parentType);
                }
                FontFeatures = FontFeatures != default ? FontFeatures : global::Avalonia.Controls.Documents.TextElement.FontFeaturesProperty.GetDefaultValue(parentType);
                FontSize = FontSize != default ? FontSize : global::Avalonia.Controls.Documents.TextElement.FontSizeProperty.GetDefaultValue(parentType);
                FontStretch = FontStretch != default ? FontStretch : global::Avalonia.Controls.Documents.TextElement.FontStretchProperty.GetDefaultValue(parentType);
                FontStyle = FontStyle != default ? FontStyle : global::Avalonia.Controls.Documents.TextElement.FontStyleProperty.GetDefaultValue(parentType);
                FontWeight = FontWeight != default ? FontWeight : global::Avalonia.Controls.Documents.TextElement.FontWeightProperty.GetDefaultValue(parentType);
                Foreground = Foreground != default ? Foreground : global::Avalonia.Controls.Documents.TextElement.ForegroundProperty.GetDefaultValue(parentType);

                TryUpdateParent(parentElement);
            }

            _parent = (Avalonia.Controls.Control)parentElement;
        }
        
        
        public void RemoveFromParent(object parentElement)
        {
            var parentType = parentElement?.GetType();
            if (parentType is not null)
            {
                FontFamily = global::Avalonia.Controls.Documents.TextElement.FontFamilyProperty.GetDefaultValue(parentType);
                FontFeatures = global::Avalonia.Controls.Documents.TextElement.FontFeaturesProperty.GetDefaultValue(parentType);
                FontSize = global::Avalonia.Controls.Documents.TextElement.FontSizeProperty.GetDefaultValue(parentType);
                FontStretch = global::Avalonia.Controls.Documents.TextElement.FontStretchProperty.GetDefaultValue(parentType);
                FontStyle = global::Avalonia.Controls.Documents.TextElement.FontStyleProperty.GetDefaultValue(parentType);
                FontWeight = global::Avalonia.Controls.Documents.TextElement.FontWeightProperty.GetDefaultValue(parentType);
                Foreground = global::Avalonia.Controls.Documents.TextElement.ForegroundProperty.GetDefaultValue(parentType);

                TryUpdateParent(parentElement);
            }

            _parent = null;
        }

        public void AddChild(object child, int physicalSiblingIndex)
        {
        }

        public void RemoveChild(object child, int physicalSiblingIndex)
        {
        }

        protected override void RenderAdditionalElementContent(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder builder, ref int sequence)
        {
            base.RenderAdditionalElementContent(builder, ref sequence);
        }
    }
}
