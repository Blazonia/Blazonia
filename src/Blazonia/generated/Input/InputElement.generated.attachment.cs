using AC = Avalonia.Controls;
using AI = Avalonia.Input;
using AvaloniaBindableObject = Avalonia.AvaloniaObject;
using Blazonia.Components;
using Blazonia.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;            
using System.Runtime.Versioning;
using Blazonia.Components.Input;

namespace Blazonia.Components
{
    [RequiresPreviewFeatures]
    internal static class InputElementInitializer
    {
        [System.Runtime.CompilerServices.ModuleInitializer]
        internal static void RegisterAdditionalHandlers()
        {
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("InputElement.IsHoldingEnabled",
                (element, value) =>
                {
                    if (value?.Equals(Avalonia.AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(AI.InputElement.IsHoldingEnabledProperty);
                    }
                    else
                    {
                        AI.InputElement.SetIsHoldingEnabled((Avalonia.StyledElement)element, (bool)value);
                    }
                });
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("InputElement.IsHoldWithMouseEnabled",
                (element, value) =>
                {
                    if (value?.Equals(Avalonia.AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(AI.InputElement.IsHoldWithMouseEnabledProperty);
                    }
                    else
                    {
                        AI.InputElement.SetIsHoldWithMouseEnabled((Avalonia.StyledElement)element, (bool)value);
                    }
                });
        }
    }

    public static class InputElementExtensions
    {
        /// <summary>
        /// Defines the IsHoldingEnabled attached property.
        /// </summary>
        public static StyledElement InputElementIsHoldingEnabled(this StyledElement element, bool value)
        {
            element.AttachedProperties["InputElement.IsHoldingEnabled"] = value;
        
            return element;
        }
        /// <summary>
        /// Defines the IsHoldWithMouseEnabled attached property.
        /// </summary>
        public static StyledElement InputElementIsHoldWithMouseEnabled(this StyledElement element, bool value)
        {
            element.AttachedProperties["InputElement.IsHoldWithMouseEnabled"] = value;
        
            return element;
        }
    }

    public class InputElement_Attachment : NativeControlComponentBase, INonPhysicalChild, IContainerElementHandler
    {
        /// <summary>
        /// Defines the IsHoldingEnabled attached property.
        /// </summary>
        [Parameter] public bool IsHoldingEnabled { get; set; }

        /// <summary>
        /// Defines the IsHoldWithMouseEnabled attached property.
        /// </summary>
        [Parameter] public bool IsHoldWithMouseEnabled { get; set; }

        private Avalonia.StyledElement _parent;

        public object TargetElement => _parent;

        public override Task SetParametersAsync(ParameterView parameters)
        {
            foreach (var parameterValue in parameters)
            {
                var value = parameterValue.Value;
                switch (parameterValue.Name)
                {
                    case nameof(IsHoldingEnabled):
                    if (!Equals(IsHoldingEnabled, value))
                    {
                        IsHoldingEnabled = (bool)value;
                        //NativeControl.IsHoldingEnabledProperty = IsHoldingEnabled;
                    }
                    break;

                    case nameof(IsHoldWithMouseEnabled):
                    if (!Equals(IsHoldWithMouseEnabled, value))
                    {
                        IsHoldWithMouseEnabled = (bool)value;
                        //NativeControl.IsHoldWithMouseEnabledProperty = IsHoldWithMouseEnabled;
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
                if (IsHoldingEnabled == global::Avalonia.Input.InputElement.IsHoldingEnabledProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.StyledElement)parentElement).ClearValue( global::Avalonia.Input.InputElement.IsHoldingEnabledProperty);
                }
                else
                {
                     global::Avalonia.Input.InputElement.SetIsHoldingEnabled((Avalonia.StyledElement)parentElement, IsHoldingEnabled);
                }
                
                if (IsHoldWithMouseEnabled == global::Avalonia.Input.InputElement.IsHoldWithMouseEnabledProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.StyledElement)parentElement).ClearValue( global::Avalonia.Input.InputElement.IsHoldWithMouseEnabledProperty);
                }
                else
                {
                     global::Avalonia.Input.InputElement.SetIsHoldWithMouseEnabled((Avalonia.StyledElement)parentElement, IsHoldWithMouseEnabled);
                }
                
            }
        }
    
        void INonPhysicalChild.SetParent(object parentElement)
        {
            var parentType = parentElement?.GetType();
            if (parentType is not null)
            {
                IsHoldingEnabled = IsHoldingEnabled != default ? IsHoldingEnabled : global::Avalonia.Input.InputElement.IsHoldingEnabledProperty.GetDefaultValue(parentType);
                IsHoldWithMouseEnabled = IsHoldWithMouseEnabled != default ? IsHoldWithMouseEnabled : global::Avalonia.Input.InputElement.IsHoldWithMouseEnabledProperty.GetDefaultValue(parentType);

                TryUpdateParent(parentElement);
            }

            _parent = (Avalonia.StyledElement)parentElement;
        }
        
        
        public void RemoveFromParent(object parentElement)
        {
            var parentType = parentElement?.GetType();
            if (parentType is not null)
            {
                IsHoldingEnabled = global::Avalonia.Input.InputElement.IsHoldingEnabledProperty.GetDefaultValue(parentType);
                IsHoldWithMouseEnabled = global::Avalonia.Input.InputElement.IsHoldWithMouseEnabledProperty.GetDefaultValue(parentType);

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
