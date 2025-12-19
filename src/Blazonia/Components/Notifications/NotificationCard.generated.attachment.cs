using ACN = Avalonia.Controls.Notifications;
using Blazonia.Components;            
using System.Runtime.Versioning;
using Blazonia.Components.Input;

namespace Blazonia.Components
{
    [RequiresPreviewFeatures]
    internal static class NotificationCardInitializer
    {
        [System.Runtime.CompilerServices.ModuleInitializer]
        internal static void RegisterAdditionalHandlers()
        {
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("NotificationCard.CloseOnClick",
                (element, value) =>
                {
                    if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(ACN.NotificationCard.CloseOnClickProperty);
                    }
                    else
                    {
                        ACN.NotificationCard.SetCloseOnClick((Avalonia.Controls.Button)element, (bool)value);
                    }
                });
        }
    }

    public static class NotificationCardExtensions
    {
        /// <summary>
        /// Defines the CloseOnClick property.
        /// </summary>
        public static Button NotificationCardCloseOnClick(this Button element, bool value)
        {
            element.AttachedProperties["NotificationCard.CloseOnClick"] = value;
        
            return element;
        }
    }

    public class NotificationCard_Attachment : NativeControlComponentBase, INonPhysicalChild, IContainerElementHandler
    {
        /// <summary>
        /// Defines the CloseOnClick property.
        /// </summary>
        [Parameter] public bool CloseOnClick { get; set; }

        private Avalonia.Controls.Button _parent;

        public object TargetElement => _parent;

        public override Task SetParametersAsync(ParameterView parameters)
        {
            foreach (var parameterValue in parameters)
            {
                var value = parameterValue.Value;
                switch (parameterValue.Name)
                {
                    case nameof(CloseOnClick):
                    if (!Equals(CloseOnClick, value))
                    {
                        CloseOnClick = (bool)value;
                        //NativeControl.CloseOnClickProperty = CloseOnClick;
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
                if (CloseOnClick == global::Avalonia.Controls.Notifications.NotificationCard.CloseOnClickProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Button)parentElement).ClearValue( global::Avalonia.Controls.Notifications.NotificationCard.CloseOnClickProperty);
                }
                else
                {
                     global::Avalonia.Controls.Notifications.NotificationCard.SetCloseOnClick((Avalonia.Controls.Button)parentElement, CloseOnClick);
                }
                
            }
        }
    
        void INonPhysicalChild.SetParent(object parentElement)
        {
            var parentType = parentElement?.GetType();
            if (parentType is not null)
            {
                CloseOnClick = CloseOnClick != default ? CloseOnClick : global::Avalonia.Controls.Notifications.NotificationCard.CloseOnClickProperty.GetDefaultValue(parentType);

                TryUpdateParent(parentElement);
            }

            _parent = (Avalonia.Controls.Button)parentElement;
        }
        
        
        public void RemoveFromParent(object parentElement)
        {
            var parentType = parentElement?.GetType();
            if (parentType is not null)
            {
                CloseOnClick = global::Avalonia.Controls.Notifications.NotificationCard.CloseOnClickProperty.GetDefaultValue(parentType);

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
