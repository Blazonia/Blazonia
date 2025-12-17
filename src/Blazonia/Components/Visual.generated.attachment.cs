using A = Avalonia;            
using System.Runtime.Versioning;

namespace Blazonia.Components
{
    [RequiresPreviewFeatures]
    internal static class VisualInitializer
    {
        [System.Runtime.CompilerServices.ModuleInitializer]
        internal static void RegisterAdditionalHandlers()
        {
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("Visual.FlowDirection",
                (element, value) =>
                {
                    if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(A.Visual.FlowDirectionProperty);
                    }
                    else
                    {
                        A.Visual.SetFlowDirection((Avalonia.Visual)element, (A.Media.FlowDirection)value);
                    }
                });
        }
    }

    public static class VisualExtensions
    {
        /// <summary>
        /// Defines the <see cref="P:Avalonia.Visual.FlowDirection" /> property.
        /// </summary>
        public static Visual VisualFlowDirection(this Visual element, A.Media.FlowDirection value)
        {
            element.AttachedProperties["Visual.FlowDirection"] = value;
        
            return element;
        }
    }

    public class Visual_Attachment : NativeControlComponentBase, INonPhysicalChild, IContainerElementHandler
    {
        /// <summary>
        /// Defines the <see cref="P:Avalonia.Visual.FlowDirection" /> property.
        /// </summary>
        [Parameter] public A.Media.FlowDirection FlowDirection { get; set; }

        private Avalonia.Visual _parent;

        public object TargetElement => _parent;

        public override Task SetParametersAsync(ParameterView parameters)
        {
            foreach (var parameterValue in parameters)
            {
                var value = parameterValue.Value;
                switch (parameterValue.Name)
                {
                    case nameof(FlowDirection):
                    if (!Equals(FlowDirection, value))
                    {
                        FlowDirection = (A.Media.FlowDirection)value;
                        //NativeControl.FlowDirectionProperty = FlowDirection;
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
                if (FlowDirection == global::Avalonia.Visual.FlowDirectionProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Visual)parentElement).ClearValue( global::Avalonia.Visual.FlowDirectionProperty);
                }
                else
                {
                     global::Avalonia.Visual.SetFlowDirection((Avalonia.Visual)parentElement, FlowDirection);
                }
                
            }
        }
    
        void INonPhysicalChild.SetParent(object parentElement)
        {
            var parentType = parentElement?.GetType();
            if (parentType is not null)
            {
                FlowDirection = FlowDirection != default ? FlowDirection : global::Avalonia.Visual.FlowDirectionProperty.GetDefaultValue(parentType);

                TryUpdateParent(parentElement);
            }

            _parent = (Avalonia.Visual)parentElement;
        }
        
        
        public void RemoveFromParent(object parentElement)
        {
            var parentType = parentElement?.GetType();
            if (parentType is not null)
            {
                FlowDirection = global::Avalonia.Visual.FlowDirectionProperty.GetDefaultValue(parentType);

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
