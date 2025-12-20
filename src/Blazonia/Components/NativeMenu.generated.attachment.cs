            
using System.Runtime.Versioning;

namespace Blazonia.Components
{
    [RequiresPreviewFeatures]
    internal static class NativeMenuInitializer
    {
        [System.Runtime.CompilerServices.ModuleInitializer]
        internal static void RegisterAdditionalHandlers()
        {
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("NativeMenu.Menu",
                (element, value) =>
                {
                    if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(AC.NativeMenu.MenuProperty);
                    }
                    else
                    {
                        AC.NativeMenu.SetMenu((Avalonia.AvaloniaObject)element, (AC.NativeMenu)value);
                    }
                });
        }
    }

    public static class NativeMenuExtensions
    {
        public static AvaloniaObject NativeMenuMenu(this AvaloniaObject element, AC.NativeMenu value)
        {
            element.AttachedProperties["NativeMenu.Menu"] = value;
        
            return element;
        }
    }

    public class NativeMenu_Attachment : NativeControlComponentBase, INonPhysicalChild, IContainerElementHandler
    {
        [Parameter] public AC.NativeMenu Menu { get; set; }

        private Avalonia.AvaloniaObject _parent;

        public object TargetElement => _parent;

        public override Task SetParametersAsync(ParameterView parameters)
        {
            foreach (var parameterValue in parameters)
            {
                var value = parameterValue.Value;
                switch (parameterValue.Name)
                {
                    case nameof(Menu):
                    if (!Equals(Menu, value))
                    {
                        Menu = (AC.NativeMenu)value;
                        //NativeControl.MenuProperty = Menu;
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
                if (Menu == global::Avalonia.Controls.NativeMenu.MenuProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.AvaloniaObject)parentElement).ClearValue( global::Avalonia.Controls.NativeMenu.MenuProperty);
                }
                else
                {
                     global::Avalonia.Controls.NativeMenu.SetMenu((Avalonia.AvaloniaObject)parentElement, Menu);
                }
                
            }
        }
    
        void INonPhysicalChild.SetParent(object parentElement)
        {
            var parentType = parentElement?.GetType();
            if (parentType is not null)
            {
                Menu = Menu != default ? Menu : global::Avalonia.Controls.NativeMenu.MenuProperty.GetDefaultValue(parentType);

                TryUpdateParent(parentElement);
            }

            _parent = (Avalonia.AvaloniaObject)parentElement;
        }
        
        
        public void RemoveFromParent(object parentElement)
        {
            var parentType = parentElement?.GetType();
            if (parentType is not null)
            {
                Menu = global::Avalonia.Controls.NativeMenu.MenuProperty.GetDefaultValue(parentType);

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
