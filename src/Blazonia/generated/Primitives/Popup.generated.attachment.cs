using ACP = Avalonia.Controls.Primitives;
using Blazonia.Components;            
using System.Runtime.Versioning;
using Blazonia.Components.Input;

namespace Blazonia.Components
{
    [RequiresPreviewFeatures]
    internal static class PopupInitializer
    {
        [System.Runtime.CompilerServices.ModuleInitializer]
        internal static void RegisterAdditionalHandlers()
        {
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("Popup.TakesFocusFromNativeControl",
                (element, value) =>
                {
                    if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(ACP.Popup.TakesFocusFromNativeControlProperty);
                    }
                    else
                    {
                        ACP.Popup.SetTakesFocusFromNativeControl((Avalonia.Controls.Control)element, (bool)value);
                    }
                });
        }
    }

    public static class PopupExtensions
    {
        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.Primitives.Popup.TakesFocusFromNativeControl" /> property.
        /// </summary>
        public static Control PopupTakesFocusFromNativeControl(this Control element, bool value)
        {
            element.AttachedProperties["Popup.TakesFocusFromNativeControl"] = value;
        
            return element;
        }
    }

    public class Popup_Attachment : NativeControlComponentBase, INonPhysicalChild, IContainerElementHandler
    {
        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.Primitives.Popup.TakesFocusFromNativeControl" /> property.
        /// </summary>
        [Parameter] public bool TakesFocusFromNativeControl { get; set; }

        private Avalonia.Controls.Control _parent;

        public object TargetElement => _parent;

        public override Task SetParametersAsync(ParameterView parameters)
        {
            foreach (var parameterValue in parameters)
            {
                var value = parameterValue.Value;
                switch (parameterValue.Name)
                {
                    case nameof(TakesFocusFromNativeControl):
                    if (!Equals(TakesFocusFromNativeControl, value))
                    {
                        TakesFocusFromNativeControl = (bool)value;
                        //NativeControl.TakesFocusFromNativeControlProperty = TakesFocusFromNativeControl;
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
                if (TakesFocusFromNativeControl == global::Avalonia.Controls.Primitives.Popup.TakesFocusFromNativeControlProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Control)parentElement).ClearValue( global::Avalonia.Controls.Primitives.Popup.TakesFocusFromNativeControlProperty);
                }
                else
                {
                     global::Avalonia.Controls.Primitives.Popup.SetTakesFocusFromNativeControl((Avalonia.Controls.Control)parentElement, TakesFocusFromNativeControl);
                }
                
            }
        }
    
        void INonPhysicalChild.SetParent(object parentElement)
        {
            var parentType = parentElement?.GetType();
            if (parentType is not null)
            {
                TakesFocusFromNativeControl = TakesFocusFromNativeControl != default ? TakesFocusFromNativeControl : global::Avalonia.Controls.Primitives.Popup.TakesFocusFromNativeControlProperty.GetDefaultValue(parentType);

                TryUpdateParent(parentElement);
            }

            _parent = (Avalonia.Controls.Control)parentElement;
        }
        
        
        public void RemoveFromParent(object parentElement)
        {
            var parentType = parentElement?.GetType();
            if (parentType is not null)
            {
                TakesFocusFromNativeControl = global::Avalonia.Controls.Primitives.Popup.TakesFocusFromNativeControlProperty.GetDefaultValue(parentType);

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
