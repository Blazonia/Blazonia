using ACP = Avalonia.Controls.Primitives;
using Blazonia.Components;            
using System.Runtime.Versioning;
using Blazonia.Components.Input;

namespace Blazonia.Components
{
    [RequiresPreviewFeatures]
    internal static class AdornerLayerInitializer
    {
        [System.Runtime.CompilerServices.ModuleInitializer]
        internal static void RegisterAdditionalHandlers()
        {
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("AdornerLayer.AdornedElement",
                (element, value) =>
                {
                    if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(ACP.AdornerLayer.AdornedElementProperty);
                    }
                    else
                    {
                        ACP.AdornerLayer.SetAdornedElement((Avalonia.Visual)element, (global::Avalonia.Visual)value);
                    }
                });
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("AdornerLayer.Adorner",
                (element, value) =>
                {
                    if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(ACP.AdornerLayer.AdornerProperty);
                    }
                    else
                    {
                        ACP.AdornerLayer.SetAdorner((Avalonia.Visual)element, (AC.Control)value);
                    }
                });
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("AdornerLayer.IsClipEnabled",
                (element, value) =>
                {
                    if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(ACP.AdornerLayer.IsClipEnabledProperty);
                    }
                    else
                    {
                        ACP.AdornerLayer.SetIsClipEnabled((Avalonia.Visual)element, (bool)value);
                    }
                });
        }
    }

    public static class AdornerLayerExtensions
    {
        /// <summary>
        /// Allows for getting and setting of the adorned element.
        /// </summary>
        public static Visual AdornerLayerAdornedElement(this Visual element, global::Avalonia.Visual value)
        {
            element.AttachedProperties["AdornerLayer.AdornedElement"] = value;
        
            return element;
        }
        /// <summary>
        /// Allows for getting and setting of the adorner for control.
        /// </summary>
        public static Visual AdornerLayerAdorner(this Visual element, AC.Control value)
        {
            element.AttachedProperties["AdornerLayer.Adorner"] = value;
        
            return element;
        }
        /// <summary>
        /// Allows for controlling clipping of the adorner.
        /// </summary>
        public static Visual AdornerLayerIsClipEnabled(this Visual element, bool value)
        {
            element.AttachedProperties["AdornerLayer.IsClipEnabled"] = value;
        
            return element;
        }
    }

    public class AdornerLayer_Attachment : NativeControlComponentBase, INonPhysicalChild, IContainerElementHandler
    {
        /// <summary>
        /// Allows for getting and setting of the adorned element.
        /// </summary>
        [Parameter] public global::Avalonia.Visual AdornedElement { get; set; }

        /// <summary>
        /// Allows for getting and setting of the adorner for control.
        /// </summary>
        [Parameter] public AC.Control Adorner { get; set; }

        /// <summary>
        /// Allows for controlling clipping of the adorner.
        /// </summary>
        [Parameter] public bool IsClipEnabled { get; set; }

        private Avalonia.Visual _parent;

        public object TargetElement => _parent;

        public override Task SetParametersAsync(ParameterView parameters)
        {
            foreach (var parameterValue in parameters)
            {
                var value = parameterValue.Value;
                switch (parameterValue.Name)
                {
                    case nameof(AdornedElement):
                    if (!Equals(AdornedElement, value))
                    {
                        AdornedElement = (global::Avalonia.Visual)value;
                        //NativeControl.AdornedElementProperty = AdornedElement;
                    }
                    break;

                    case nameof(Adorner):
                    if (!Equals(Adorner, value))
                    {
                        Adorner = (AC.Control)value;
                        //NativeControl.AdornerProperty = Adorner;
                    }
                    break;

                    case nameof(IsClipEnabled):
                    if (!Equals(IsClipEnabled, value))
                    {
                        IsClipEnabled = (bool)value;
                        //NativeControl.IsClipEnabledProperty = IsClipEnabled;
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
                if (AdornedElement == global::Avalonia.Controls.Primitives.AdornerLayer.AdornedElementProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Visual)parentElement).ClearValue( global::Avalonia.Controls.Primitives.AdornerLayer.AdornedElementProperty);
                }
                else
                {
                     global::Avalonia.Controls.Primitives.AdornerLayer.SetAdornedElement((Avalonia.Visual)parentElement, AdornedElement);
                }
                
                if (Adorner == global::Avalonia.Controls.Primitives.AdornerLayer.AdornerProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Visual)parentElement).ClearValue( global::Avalonia.Controls.Primitives.AdornerLayer.AdornerProperty);
                }
                else
                {
                     global::Avalonia.Controls.Primitives.AdornerLayer.SetAdorner((Avalonia.Visual)parentElement, Adorner);
                }
                
                if (IsClipEnabled == global::Avalonia.Controls.Primitives.AdornerLayer.IsClipEnabledProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Visual)parentElement).ClearValue( global::Avalonia.Controls.Primitives.AdornerLayer.IsClipEnabledProperty);
                }
                else
                {
                     global::Avalonia.Controls.Primitives.AdornerLayer.SetIsClipEnabled((Avalonia.Visual)parentElement, IsClipEnabled);
                }
                
            }
        }
    
        void INonPhysicalChild.SetParent(object parentElement)
        {
            var parentType = parentElement?.GetType();
            if (parentType is not null)
            {
                AdornedElement = AdornedElement != default ? AdornedElement : global::Avalonia.Controls.Primitives.AdornerLayer.AdornedElementProperty.GetDefaultValue(parentType);
                Adorner = Adorner != default ? Adorner : global::Avalonia.Controls.Primitives.AdornerLayer.AdornerProperty.GetDefaultValue(parentType);
                IsClipEnabled = IsClipEnabled != default ? IsClipEnabled : global::Avalonia.Controls.Primitives.AdornerLayer.IsClipEnabledProperty.GetDefaultValue(parentType);

                TryUpdateParent(parentElement);
            }

            _parent = (Avalonia.Visual)parentElement;
        }
        
        
        public void RemoveFromParent(object parentElement)
        {
            var parentType = parentElement?.GetType();
            if (parentType is not null)
            {
                AdornedElement = global::Avalonia.Controls.Primitives.AdornerLayer.AdornedElementProperty.GetDefaultValue(parentType);
                Adorner = global::Avalonia.Controls.Primitives.AdornerLayer.AdornerProperty.GetDefaultValue(parentType);
                IsClipEnabled = global::Avalonia.Controls.Primitives.AdornerLayer.IsClipEnabledProperty.GetDefaultValue(parentType);

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
