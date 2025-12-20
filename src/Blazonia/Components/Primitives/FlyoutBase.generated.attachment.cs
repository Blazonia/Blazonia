using ACP = Avalonia.Controls.Primitives;
using Blazonia.Components;            
using System.Runtime.Versioning;

namespace Blazonia.Components
{
    [RequiresPreviewFeatures]
    internal static class FlyoutBaseInitializer
    {
        [System.Runtime.CompilerServices.ModuleInitializer]
        internal static void RegisterAdditionalHandlers()
        {
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("FlyoutBase.AttachedFlyout",
                (element, value) =>
                {
                    if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(ACP.FlyoutBase.AttachedFlyoutProperty);
                    }
                    else
                    {
                        ACP.FlyoutBase.SetAttachedFlyout((Avalonia.Controls.Control)element, (ACP.FlyoutBase)value);
                    }
                });
        }
    }

    public static class FlyoutBaseExtensions
    {
        /// <summary>
        /// Defines the AttachedFlyout property
        /// </summary>
        public static Control FlyoutBaseAttachedFlyout(this Control element, ACP.FlyoutBase value)
        {
            element.AttachedProperties["FlyoutBase.AttachedFlyout"] = value;
        
            return element;
        }
    }

    public class FlyoutBase_Attachment : NativeControlComponentBase, INonPhysicalChild, IContainerElementHandler
    {
        /// <summary>
        /// Defines the AttachedFlyout property
        /// </summary>
        [Parameter] public ACP.FlyoutBase AttachedFlyout { get; set; }

        private Avalonia.Controls.Control _parent;

        public object TargetElement => _parent;

        public override Task SetParametersAsync(ParameterView parameters)
        {
            foreach (var parameterValue in parameters)
            {
                var value = parameterValue.Value;
                switch (parameterValue.Name)
                {
                    case nameof(AttachedFlyout):
                    if (!Equals(AttachedFlyout, value))
                    {
                        AttachedFlyout = (ACP.FlyoutBase)value;
                        //NativeControl.AttachedFlyoutProperty = AttachedFlyout;
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
                if (AttachedFlyout == global::Avalonia.Controls.Primitives.FlyoutBase.AttachedFlyoutProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Control)parentElement).ClearValue( global::Avalonia.Controls.Primitives.FlyoutBase.AttachedFlyoutProperty);
                }
                else
                {
                     global::Avalonia.Controls.Primitives.FlyoutBase.SetAttachedFlyout((Avalonia.Controls.Control)parentElement, AttachedFlyout);
                }
                
            }
        }
    
        void INonPhysicalChild.SetParent(object parentElement)
        {
            var parentType = parentElement?.GetType();
            if (parentType is not null)
            {
                AttachedFlyout = AttachedFlyout != default ? AttachedFlyout : global::Avalonia.Controls.Primitives.FlyoutBase.AttachedFlyoutProperty.GetDefaultValue(parentType);

                TryUpdateParent(parentElement);
            }

            _parent = (Avalonia.Controls.Control)parentElement;
        }
        
        
        public void RemoveFromParent(object parentElement)
        {
            var parentType = parentElement?.GetType();
            if (parentType is not null)
            {
                AttachedFlyout = global::Avalonia.Controls.Primitives.FlyoutBase.AttachedFlyoutProperty.GetDefaultValue(parentType);

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
