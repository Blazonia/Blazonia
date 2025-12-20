using ACP = Avalonia.Controls.Primitives;
using Blazonia.Components;            
using System.Runtime.Versioning;
using Blazonia.Components.Input;

namespace Blazonia.Components
{
    [RequiresPreviewFeatures]
    internal static class TemplatedControlInitializer
    {
        [System.Runtime.CompilerServices.ModuleInitializer]
        internal static void RegisterAdditionalHandlers()
        {
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("TemplatedControl.IsTemplateFocusTarget",
                (element, value) =>
                {
                    if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(ACP.TemplatedControl.IsTemplateFocusTargetProperty);
                    }
                    else
                    {
                        ACP.TemplatedControl.SetIsTemplateFocusTarget((Avalonia.Controls.Control)element, (bool)value);
                    }
                });
        }
    }

    public static class TemplatedControlExtensions
    {
        /// <summary>
        /// Defines the IsTemplateFocusTarget attached property.
        /// </summary>
        public static Control TemplatedControlIsTemplateFocusTarget(this Control element, bool value)
        {
            element.AttachedProperties["TemplatedControl.IsTemplateFocusTarget"] = value;
        
            return element;
        }
    }

    public class TemplatedControl_Attachment : NativeControlComponentBase, INonPhysicalChild, IContainerElementHandler
    {
        /// <summary>
        /// Defines the IsTemplateFocusTarget attached property.
        /// </summary>
        [Parameter] public bool IsTemplateFocusTarget { get; set; }

        private Avalonia.Controls.Control _parent;

        public object TargetElement => _parent;

        public override Task SetParametersAsync(ParameterView parameters)
        {
            foreach (var parameterValue in parameters)
            {
                var value = parameterValue.Value;
                switch (parameterValue.Name)
                {
                    case nameof(IsTemplateFocusTarget):
                    if (!Equals(IsTemplateFocusTarget, value))
                    {
                        IsTemplateFocusTarget = (bool)value;
                        //NativeControl.IsTemplateFocusTargetProperty = IsTemplateFocusTarget;
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
                if (IsTemplateFocusTarget == global::Avalonia.Controls.Primitives.TemplatedControl.IsTemplateFocusTargetProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Control)parentElement).ClearValue( global::Avalonia.Controls.Primitives.TemplatedControl.IsTemplateFocusTargetProperty);
                }
                else
                {
                     global::Avalonia.Controls.Primitives.TemplatedControl.SetIsTemplateFocusTarget((Avalonia.Controls.Control)parentElement, IsTemplateFocusTarget);
                }
                
            }
        }
    
        void INonPhysicalChild.SetParent(object parentElement)
        {
            var parentType = parentElement?.GetType();
            if (parentType is not null)
            {
                IsTemplateFocusTarget = IsTemplateFocusTarget != default ? IsTemplateFocusTarget : global::Avalonia.Controls.Primitives.TemplatedControl.IsTemplateFocusTargetProperty.GetDefaultValue(parentType);

                TryUpdateParent(parentElement);
            }

            _parent = (Avalonia.Controls.Control)parentElement;
        }
        
        
        public void RemoveFromParent(object parentElement)
        {
            var parentType = parentElement?.GetType();
            if (parentType is not null)
            {
                IsTemplateFocusTarget = global::Avalonia.Controls.Primitives.TemplatedControl.IsTemplateFocusTargetProperty.GetDefaultValue(parentType);

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
