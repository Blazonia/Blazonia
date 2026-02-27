using AC = Avalonia.Controls;
using ACD = Avalonia.Controls.Documents;
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
    internal static class InlineInitializer
    {
        [System.Runtime.CompilerServices.ModuleInitializer]
        internal static void RegisterAdditionalHandlers()
        {
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("Inline.TextDecorations",
                (element, value) =>
                {
                    if (value?.Equals(Avalonia.AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(ACD.Inline.TextDecorationsProperty);
                    }
                    else
                    {
                        ACD.Inline.SetTextDecorations((Avalonia.Controls.Control)element, (global::Avalonia.Media.TextDecorationCollection)value);
                    }
                });
        }
    }

    public static class InlineExtensions
    {
        /// <summary>
        /// AvaloniaProperty for <see cref="P:Avalonia.Controls.Documents.Inline.TextDecorations" /> property.
        /// </summary>
        public static Control InlineTextDecorations(this Control element, global::Avalonia.Media.TextDecorationCollection value)
        {
            element.AttachedProperties["Inline.TextDecorations"] = value;
        
            return element;
        }
    }

    public class Inline_Attachment : NativeControlComponentBase, INonPhysicalChild, IContainerElementHandler
    {
        /// <summary>
        /// AvaloniaProperty for <see cref="P:Avalonia.Controls.Documents.Inline.TextDecorations" /> property.
        /// </summary>
        [Parameter] public OneOf.OneOf<global::Avalonia.Media.TextDecorationCollection, string> TextDecorations { get; set; }

        private Avalonia.Controls.Control _parent;

        public object TargetElement => _parent;

        public override Task SetParametersAsync(ParameterView parameters)
        {
            foreach (var parameterValue in parameters)
            {
                var value = parameterValue.Value;
                switch (parameterValue.Name)
                {
                    case nameof(TextDecorations):
                    if (!Equals(TextDecorations, value))
                    {
                        TextDecorations = (global::Avalonia.Media.TextDecorationCollection)value;
                        //NativeControl.TextDecorationsProperty = TextDecorations;
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
                    global::Avalonia.Media.TextDecorationCollection value = default;
                    if (TextDecorations.IsT0)
                    {
                        value = TextDecorations.AsT0;
                    }
                    else
                    {
                        value = global::Avalonia.Media.TextDecorationCollection.Parse(TextDecorations.AsT1);
                    }
                    if (value == global::Avalonia.Controls.Documents.Inline.TextDecorationsProperty.GetDefaultValue(parentElement.GetType()))
                    {
                        ((Avalonia.Controls.Control)parentElement).ClearValue( global::Avalonia.Controls.Documents.Inline.TextDecorationsProperty);
                    }
                    else
                    {
                        global::Avalonia.Controls.Documents.Inline.SetTextDecorations((Avalonia.Controls.Control)parentElement, value);
                    }
                }
                
            }
        }
    
        void INonPhysicalChild.SetParent(object parentElement)
        {
            var parentType = parentElement?.GetType();
            if (parentType is not null)
            {
                if (TextDecorations.IsT1 == false && TextDecorations.AsT0 == default)
                {
                    TextDecorations = global::Avalonia.Controls.Documents.Inline.TextDecorationsProperty.GetDefaultValue(parentType);
                }

                TryUpdateParent(parentElement);
            }

            _parent = (Avalonia.Controls.Control)parentElement;
        }
        
        
        public void RemoveFromParent(object parentElement)
        {
            var parentType = parentElement?.GetType();
            if (parentType is not null)
            {
                TextDecorations = global::Avalonia.Controls.Documents.Inline.TextDecorationsProperty.GetDefaultValue(parentType);

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
