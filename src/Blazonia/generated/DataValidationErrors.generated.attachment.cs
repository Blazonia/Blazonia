            
using System.Runtime.Versioning;
using Blazonia.Components.Input;

namespace Blazonia.Components
{
    [RequiresPreviewFeatures]
    internal static class DataValidationErrorsInitializer
    {
        [System.Runtime.CompilerServices.ModuleInitializer]
        internal static void RegisterAdditionalHandlers()
        {
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("DataValidationErrors.ErrorConverter",
                (element, value) =>
                {
                    if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(AC.DataValidationErrors.ErrorConverterProperty);
                    }
                    else
                    {
                        AC.DataValidationErrors.SetErrorConverter((Avalonia.Controls.Control)element, (Func<object, object>)value);
                    }
                });
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("DataValidationErrors.Errors",
                (element, value) =>
                {
                    if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(AC.DataValidationErrors.ErrorsProperty);
                    }
                    else
                    {
                        AC.DataValidationErrors.SetErrors((Avalonia.Controls.Control)element, (IEnumerable<object>)value);
                    }
                });
        }
    }

    public static class DataValidationErrorsExtensions
    {
        /// <summary>
        /// Defines the DataValidationErrors.ErrorConverter attached property.
        /// </summary>
        public static Control DataValidationErrorsErrorConverter(this Control element, Func<object, object> value)
        {
            element.AttachedProperties["DataValidationErrors.ErrorConverter"] = value;
        
            return element;
        }
        /// <summary>
        /// Defines the DataValidationErrors.Errors attached property.
        /// </summary>
        public static Control DataValidationErrorsErrors(this Control element, IEnumerable<object> value)
        {
            element.AttachedProperties["DataValidationErrors.Errors"] = value;
        
            return element;
        }
    }

    public class DataValidationErrors_Attachment : NativeControlComponentBase, INonPhysicalChild, IContainerElementHandler
    {
        /// <summary>
        /// Defines the DataValidationErrors.ErrorConverter attached property.
        /// </summary>
        [Parameter] public Func<object, object> ErrorConverter { get; set; }

        /// <summary>
        /// Defines the DataValidationErrors.Errors attached property.
        /// </summary>
        [Parameter] public IEnumerable<object> Errors { get; set; }

        private Avalonia.Controls.Control _parent;

        public object TargetElement => _parent;

        public override Task SetParametersAsync(ParameterView parameters)
        {
            foreach (var parameterValue in parameters)
            {
                var value = parameterValue.Value;
                switch (parameterValue.Name)
                {
                    case nameof(ErrorConverter):
                    if (!Equals(ErrorConverter, value))
                    {
                        ErrorConverter = (Func<object, object>)value;
                        //NativeControl.ErrorConverterProperty = ErrorConverter;
                    }
                    break;

                    case nameof(Errors):
                    if (!Equals(Errors, value))
                    {
                        Errors = (IEnumerable<object>)value;
                        //NativeControl.ErrorsProperty = Errors;
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
                if (ErrorConverter == global::Avalonia.Controls.DataValidationErrors.ErrorConverterProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Control)parentElement).ClearValue( global::Avalonia.Controls.DataValidationErrors.ErrorConverterProperty);
                }
                else
                {
                     global::Avalonia.Controls.DataValidationErrors.SetErrorConverter((Avalonia.Controls.Control)parentElement, ErrorConverter);
                }
                
                if (Errors == global::Avalonia.Controls.DataValidationErrors.ErrorsProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Control)parentElement).ClearValue( global::Avalonia.Controls.DataValidationErrors.ErrorsProperty);
                }
                else
                {
                     global::Avalonia.Controls.DataValidationErrors.SetErrors((Avalonia.Controls.Control)parentElement, Errors);
                }
                
            }
        }
    
        void INonPhysicalChild.SetParent(object parentElement)
        {
            var parentType = parentElement?.GetType();
            if (parentType is not null)
            {
                ErrorConverter = ErrorConverter != default ? ErrorConverter : global::Avalonia.Controls.DataValidationErrors.ErrorConverterProperty.GetDefaultValue(parentType);
                Errors = Errors != default ? Errors : global::Avalonia.Controls.DataValidationErrors.ErrorsProperty.GetDefaultValue(parentType);

                TryUpdateParent(parentElement);
            }

            _parent = (Avalonia.Controls.Control)parentElement;
        }
        
        
        public void RemoveFromParent(object parentElement)
        {
            var parentType = parentElement?.GetType();
            if (parentType is not null)
            {
                ErrorConverter = global::Avalonia.Controls.DataValidationErrors.ErrorConverterProperty.GetDefaultValue(parentType);
                Errors = global::Avalonia.Controls.DataValidationErrors.ErrorsProperty.GetDefaultValue(parentType);

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
