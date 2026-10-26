using AC = Avalonia.Controls;
using AvaloniaBindableObject = Avalonia.AvaloniaObject;
using Blazonia.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;            
using System.Runtime.Versioning;
using Blazonia.Components.Input;

namespace Blazonia.Components
{
    [RequiresPreviewFeatures]
    internal static class TabbedPageInitializer
    {
        [System.Runtime.CompilerServices.ModuleInitializer]
        internal static void RegisterAdditionalHandlers()
        {
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("TabbedPage.IsTabEnabled",
                (element, value) =>
                {
                    if (value?.Equals(Avalonia.AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(AC.TabbedPage.IsTabEnabledProperty);
                    }
                    else
                    {
                        AC.TabbedPage.SetIsTabEnabled((Avalonia.Controls.Page)element, (bool)value);
                    }
                });
        }
    }

    public static class TabbedPageExtensions
    {
        /// <summary>
        /// Defines the <see cref="F:Avalonia.Controls.TabbedPage.IsTabEnabledProperty" /> attached property.
        /// </summary>
        public static Page TabbedPageIsTabEnabled(this Page element, bool value)
        {
            element.AttachedProperties["TabbedPage.IsTabEnabled"] = value;
        
            return element;
        }
    }

    public class TabbedPage_Attachment : NativeControlComponentBase, INonPhysicalChild, IContainerElementHandler
    {
        /// <summary>
        /// Defines the <see cref="F:Avalonia.Controls.TabbedPage.IsTabEnabledProperty" /> attached property.
        /// </summary>
        [Parameter] public bool IsTabEnabled { get; set; }

        private Avalonia.Controls.Page _parent;

        public object TargetElement => _parent;

        public override Task SetParametersAsync(ParameterView parameters)
        {
            foreach (var parameterValue in parameters)
            {
                var value = parameterValue.Value;
                switch (parameterValue.Name)
                {
                    case nameof(IsTabEnabled):
                    if (!Equals(IsTabEnabled, value))
                    {
                        IsTabEnabled = (bool)value;
                        //NativeControl.IsTabEnabledProperty = IsTabEnabled;
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
                if (IsTabEnabled == global::Avalonia.Controls.TabbedPage.IsTabEnabledProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Page)parentElement).ClearValue( global::Avalonia.Controls.TabbedPage.IsTabEnabledProperty);
                }
                else
                {
                     global::Avalonia.Controls.TabbedPage.SetIsTabEnabled((Avalonia.Controls.Page)parentElement, IsTabEnabled);
                }
                
            }
        }
    
        void INonPhysicalChild.SetParent(object parentElement)
        {
            var parentType = parentElement?.GetType();
            if (parentType is not null)
            {
                IsTabEnabled = IsTabEnabled != default ? IsTabEnabled : global::Avalonia.Controls.TabbedPage.IsTabEnabledProperty.GetDefaultValue(parentType);

                TryUpdateParent(parentElement);
            }

            _parent = (Avalonia.Controls.Page)parentElement;
        }
        
        
        public void RemoveFromParent(object parentElement)
        {
            var parentType = parentElement?.GetType();
            if (parentType is not null)
            {
                IsTabEnabled = global::Avalonia.Controls.TabbedPage.IsTabEnabledProperty.GetDefaultValue(parentType);

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
