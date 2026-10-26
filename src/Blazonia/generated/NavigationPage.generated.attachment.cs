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
    internal static class NavigationPageInitializer
    {
        [System.Runtime.CompilerServices.ModuleInitializer]
        internal static void RegisterAdditionalHandlers()
        {
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("NavigationPage.BackButtonContent",
                (element, value) =>
                {
                    if (value?.Equals(Avalonia.AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(AC.NavigationPage.BackButtonContentProperty);
                    }
                    else
                    {
                        AC.NavigationPage.SetBackButtonContent((Avalonia.Controls.Page)element, (object)value);
                    }
                });
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("NavigationPage.BarHeightOverride",
                (element, value) =>
                {
                    if (value?.Equals(Avalonia.AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(AC.NavigationPage.BarHeightOverrideProperty);
                    }
                    else
                    {
                        AC.NavigationPage.SetBarHeightOverride((Avalonia.Controls.Page)element, (Nullable<double>)value);
                    }
                });
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("NavigationPage.BarLayoutBehavior",
                (element, value) =>
                {
                    if (value?.Equals(Avalonia.AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(AC.NavigationPage.BarLayoutBehaviorProperty);
                    }
                    else
                    {
                        AC.NavigationPage.SetBarLayoutBehavior((Avalonia.Controls.Page)element, (Nullable<AC.BarLayoutBehavior>)value);
                    }
                });
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("NavigationPage.BottomCommandBar",
                (element, value) =>
                {
                    if (value?.Equals(Avalonia.AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(AC.NavigationPage.BottomCommandBarProperty);
                    }
                    else
                    {
                        AC.NavigationPage.SetBottomCommandBar((Avalonia.Controls.Page)element, (AC.Control)value);
                    }
                });
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("NavigationPage.HasBackButton",
                (element, value) =>
                {
                    if (value?.Equals(Avalonia.AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(AC.NavigationPage.HasBackButtonProperty);
                    }
                    else
                    {
                        AC.NavigationPage.SetHasBackButton((Avalonia.Controls.Page)element, (bool)value);
                    }
                });
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("NavigationPage.HasNavigationBar",
                (element, value) =>
                {
                    if (value?.Equals(Avalonia.AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(AC.NavigationPage.HasNavigationBarProperty);
                    }
                    else
                    {
                        AC.NavigationPage.SetHasNavigationBar((Avalonia.Controls.Page)element, (bool)value);
                    }
                });
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("NavigationPage.IsBackButtonEnabled",
                (element, value) =>
                {
                    if (value?.Equals(Avalonia.AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(AC.NavigationPage.IsBackButtonEnabledProperty);
                    }
                    else
                    {
                        AC.NavigationPage.SetIsBackButtonEnabled((Avalonia.Controls.Page)element, (bool)value);
                    }
                });
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("NavigationPage.TopCommandBar",
                (element, value) =>
                {
                    if (value?.Equals(Avalonia.AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(AC.NavigationPage.TopCommandBarProperty);
                    }
                    else
                    {
                        AC.NavigationPage.SetTopCommandBar((Avalonia.Controls.Page)element, (AC.Control)value);
                    }
                });
        }
    }

    public static class NavigationPageExtensions
    {
        /// <summary>
        /// Defines the <see cref="F:Avalonia.Controls.NavigationPage.BackButtonContentProperty" /> attached property.
        /// </summary>
        public static Page NavigationPageBackButtonContent(this Page element, object value)
        {
            element.AttachedProperties["NavigationPage.BackButtonContent"] = value;
        
            return element;
        }
        /// <summary>
        /// Defines the <see cref="F:Avalonia.Controls.NavigationPage.BarHeightOverrideProperty" /> attached property.
        /// </summary>
        public static Page NavigationPageBarHeightOverride(this Page element, Nullable<double> value)
        {
            element.AttachedProperties["NavigationPage.BarHeightOverride"] = value;
        
            return element;
        }
        /// <summary>
        /// Defines the <see cref="F:Avalonia.Controls.NavigationPage.BarLayoutBehaviorProperty" /> attached property.
        /// </summary>
        public static Page NavigationPageBarLayoutBehavior(this Page element, Nullable<AC.BarLayoutBehavior> value)
        {
            element.AttachedProperties["NavigationPage.BarLayoutBehavior"] = value;
        
            return element;
        }
        /// <summary>
        /// Defines the <see cref="F:Avalonia.Controls.NavigationPage.BottomCommandBarProperty" /> attached property.
        /// </summary>
        public static Page NavigationPageBottomCommandBar(this Page element, AC.Control value)
        {
            element.AttachedProperties["NavigationPage.BottomCommandBar"] = value;
        
            return element;
        }
        /// <summary>
        /// Defines the <see cref="F:Avalonia.Controls.NavigationPage.HasBackButtonProperty" /> attached property.
        /// </summary>
        public static Page NavigationPageHasBackButton(this Page element, bool value)
        {
            element.AttachedProperties["NavigationPage.HasBackButton"] = value;
        
            return element;
        }
        /// <summary>
        /// Defines the <see cref="F:Avalonia.Controls.NavigationPage.HasNavigationBarProperty" /> attached property.
        /// </summary>
        public static Page NavigationPageHasNavigationBar(this Page element, bool value)
        {
            element.AttachedProperties["NavigationPage.HasNavigationBar"] = value;
        
            return element;
        }
        /// <summary>
        /// Defines the <see cref="F:Avalonia.Controls.NavigationPage.IsBackButtonEnabledProperty" /> attached property.
        /// </summary>
        public static Page NavigationPageIsBackButtonEnabled(this Page element, bool value)
        {
            element.AttachedProperties["NavigationPage.IsBackButtonEnabled"] = value;
        
            return element;
        }
        /// <summary>
        /// Defines the <see cref="F:Avalonia.Controls.NavigationPage.TopCommandBarProperty" /> attached property.
        /// </summary>
        public static Page NavigationPageTopCommandBar(this Page element, AC.Control value)
        {
            element.AttachedProperties["NavigationPage.TopCommandBar"] = value;
        
            return element;
        }
    }

    public class NavigationPage_Attachment : NativeControlComponentBase, INonPhysicalChild, IContainerElementHandler
    {
        /// <summary>
        /// Defines the <see cref="F:Avalonia.Controls.NavigationPage.BackButtonContentProperty" /> attached property.
        /// </summary>
        [Parameter] public object BackButtonContent { get; set; }

        /// <summary>
        /// Defines the <see cref="F:Avalonia.Controls.NavigationPage.BarHeightOverrideProperty" /> attached property.
        /// </summary>
        [Parameter] public Nullable<double> BarHeightOverride { get; set; }

        /// <summary>
        /// Defines the <see cref="F:Avalonia.Controls.NavigationPage.BarLayoutBehaviorProperty" /> attached property.
        /// </summary>
        [Parameter] public Nullable<AC.BarLayoutBehavior> BarLayoutBehavior { get; set; }

        /// <summary>
        /// Defines the <see cref="F:Avalonia.Controls.NavigationPage.BottomCommandBarProperty" /> attached property.
        /// </summary>
        [Parameter] public AC.Control BottomCommandBar { get; set; }

        /// <summary>
        /// Defines the <see cref="F:Avalonia.Controls.NavigationPage.HasBackButtonProperty" /> attached property.
        /// </summary>
        [Parameter] public bool HasBackButton { get; set; }

        /// <summary>
        /// Defines the <see cref="F:Avalonia.Controls.NavigationPage.HasNavigationBarProperty" /> attached property.
        /// </summary>
        [Parameter] public bool HasNavigationBar { get; set; }

        /// <summary>
        /// Defines the <see cref="F:Avalonia.Controls.NavigationPage.IsBackButtonEnabledProperty" /> attached property.
        /// </summary>
        [Parameter] public bool IsBackButtonEnabled { get; set; }

        /// <summary>
        /// Defines the <see cref="F:Avalonia.Controls.NavigationPage.TopCommandBarProperty" /> attached property.
        /// </summary>
        [Parameter] public AC.Control TopCommandBar { get; set; }

        private Avalonia.Controls.Page _parent;

        public object TargetElement => _parent;

        public override Task SetParametersAsync(ParameterView parameters)
        {
            foreach (var parameterValue in parameters)
            {
                var value = parameterValue.Value;
                switch (parameterValue.Name)
                {
                    case nameof(BackButtonContent):
                    if (!Equals(BackButtonContent, value))
                    {
                        BackButtonContent = (object)value;
                        //NativeControl.BackButtonContentProperty = BackButtonContent;
                    }
                    break;

                    case nameof(BarHeightOverride):
                    if (!Equals(BarHeightOverride, value))
                    {
                        BarHeightOverride = (Nullable<double>)value;
                        //NativeControl.BarHeightOverrideProperty = BarHeightOverride;
                    }
                    break;

                    case nameof(BarLayoutBehavior):
                    if (!Equals(BarLayoutBehavior, value))
                    {
                        BarLayoutBehavior = (Nullable<AC.BarLayoutBehavior>)value;
                        //NativeControl.BarLayoutBehaviorProperty = BarLayoutBehavior;
                    }
                    break;

                    case nameof(BottomCommandBar):
                    if (!Equals(BottomCommandBar, value))
                    {
                        BottomCommandBar = (AC.Control)value;
                        //NativeControl.BottomCommandBarProperty = BottomCommandBar;
                    }
                    break;

                    case nameof(HasBackButton):
                    if (!Equals(HasBackButton, value))
                    {
                        HasBackButton = (bool)value;
                        //NativeControl.HasBackButtonProperty = HasBackButton;
                    }
                    break;

                    case nameof(HasNavigationBar):
                    if (!Equals(HasNavigationBar, value))
                    {
                        HasNavigationBar = (bool)value;
                        //NativeControl.HasNavigationBarProperty = HasNavigationBar;
                    }
                    break;

                    case nameof(IsBackButtonEnabled):
                    if (!Equals(IsBackButtonEnabled, value))
                    {
                        IsBackButtonEnabled = (bool)value;
                        //NativeControl.IsBackButtonEnabledProperty = IsBackButtonEnabled;
                    }
                    break;

                    case nameof(TopCommandBar):
                    if (!Equals(TopCommandBar, value))
                    {
                        TopCommandBar = (AC.Control)value;
                        //NativeControl.TopCommandBarProperty = TopCommandBar;
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
                if (BackButtonContent == global::Avalonia.Controls.NavigationPage.BackButtonContentProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Page)parentElement).ClearValue( global::Avalonia.Controls.NavigationPage.BackButtonContentProperty);
                }
                else
                {
                     global::Avalonia.Controls.NavigationPage.SetBackButtonContent((Avalonia.Controls.Page)parentElement, BackButtonContent);
                }
                
                if (BarHeightOverride == global::Avalonia.Controls.NavigationPage.BarHeightOverrideProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Page)parentElement).ClearValue( global::Avalonia.Controls.NavigationPage.BarHeightOverrideProperty);
                }
                else
                {
                     global::Avalonia.Controls.NavigationPage.SetBarHeightOverride((Avalonia.Controls.Page)parentElement, BarHeightOverride);
                }
                
                if (BarLayoutBehavior == global::Avalonia.Controls.NavigationPage.BarLayoutBehaviorProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Page)parentElement).ClearValue( global::Avalonia.Controls.NavigationPage.BarLayoutBehaviorProperty);
                }
                else
                {
                     global::Avalonia.Controls.NavigationPage.SetBarLayoutBehavior((Avalonia.Controls.Page)parentElement, BarLayoutBehavior);
                }
                
                if (BottomCommandBar == global::Avalonia.Controls.NavigationPage.BottomCommandBarProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Page)parentElement).ClearValue( global::Avalonia.Controls.NavigationPage.BottomCommandBarProperty);
                }
                else
                {
                     global::Avalonia.Controls.NavigationPage.SetBottomCommandBar((Avalonia.Controls.Page)parentElement, BottomCommandBar);
                }
                
                if (HasBackButton == global::Avalonia.Controls.NavigationPage.HasBackButtonProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Page)parentElement).ClearValue( global::Avalonia.Controls.NavigationPage.HasBackButtonProperty);
                }
                else
                {
                     global::Avalonia.Controls.NavigationPage.SetHasBackButton((Avalonia.Controls.Page)parentElement, HasBackButton);
                }
                
                if (HasNavigationBar == global::Avalonia.Controls.NavigationPage.HasNavigationBarProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Page)parentElement).ClearValue( global::Avalonia.Controls.NavigationPage.HasNavigationBarProperty);
                }
                else
                {
                     global::Avalonia.Controls.NavigationPage.SetHasNavigationBar((Avalonia.Controls.Page)parentElement, HasNavigationBar);
                }
                
                if (IsBackButtonEnabled == global::Avalonia.Controls.NavigationPage.IsBackButtonEnabledProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Page)parentElement).ClearValue( global::Avalonia.Controls.NavigationPage.IsBackButtonEnabledProperty);
                }
                else
                {
                     global::Avalonia.Controls.NavigationPage.SetIsBackButtonEnabled((Avalonia.Controls.Page)parentElement, IsBackButtonEnabled);
                }
                
                if (TopCommandBar == global::Avalonia.Controls.NavigationPage.TopCommandBarProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Page)parentElement).ClearValue( global::Avalonia.Controls.NavigationPage.TopCommandBarProperty);
                }
                else
                {
                     global::Avalonia.Controls.NavigationPage.SetTopCommandBar((Avalonia.Controls.Page)parentElement, TopCommandBar);
                }
                
            }
        }
    
        void INonPhysicalChild.SetParent(object parentElement)
        {
            var parentType = parentElement?.GetType();
            if (parentType is not null)
            {
                BackButtonContent = BackButtonContent != default ? BackButtonContent : global::Avalonia.Controls.NavigationPage.BackButtonContentProperty.GetDefaultValue(parentType);
                BarHeightOverride = BarHeightOverride != default ? BarHeightOverride : global::Avalonia.Controls.NavigationPage.BarHeightOverrideProperty.GetDefaultValue(parentType);
                BarLayoutBehavior = BarLayoutBehavior != default ? BarLayoutBehavior : global::Avalonia.Controls.NavigationPage.BarLayoutBehaviorProperty.GetDefaultValue(parentType);
                BottomCommandBar = BottomCommandBar != default ? BottomCommandBar : global::Avalonia.Controls.NavigationPage.BottomCommandBarProperty.GetDefaultValue(parentType);
                HasBackButton = HasBackButton != default ? HasBackButton : global::Avalonia.Controls.NavigationPage.HasBackButtonProperty.GetDefaultValue(parentType);
                HasNavigationBar = HasNavigationBar != default ? HasNavigationBar : global::Avalonia.Controls.NavigationPage.HasNavigationBarProperty.GetDefaultValue(parentType);
                IsBackButtonEnabled = IsBackButtonEnabled != default ? IsBackButtonEnabled : global::Avalonia.Controls.NavigationPage.IsBackButtonEnabledProperty.GetDefaultValue(parentType);
                TopCommandBar = TopCommandBar != default ? TopCommandBar : global::Avalonia.Controls.NavigationPage.TopCommandBarProperty.GetDefaultValue(parentType);

                TryUpdateParent(parentElement);
            }

            _parent = (Avalonia.Controls.Page)parentElement;
        }
        
        
        public void RemoveFromParent(object parentElement)
        {
            var parentType = parentElement?.GetType();
            if (parentType is not null)
            {
                BackButtonContent = global::Avalonia.Controls.NavigationPage.BackButtonContentProperty.GetDefaultValue(parentType);
                BarHeightOverride = global::Avalonia.Controls.NavigationPage.BarHeightOverrideProperty.GetDefaultValue(parentType);
                BarLayoutBehavior = global::Avalonia.Controls.NavigationPage.BarLayoutBehaviorProperty.GetDefaultValue(parentType);
                BottomCommandBar = global::Avalonia.Controls.NavigationPage.BottomCommandBarProperty.GetDefaultValue(parentType);
                HasBackButton = global::Avalonia.Controls.NavigationPage.HasBackButtonProperty.GetDefaultValue(parentType);
                HasNavigationBar = global::Avalonia.Controls.NavigationPage.HasNavigationBarProperty.GetDefaultValue(parentType);
                IsBackButtonEnabled = global::Avalonia.Controls.NavigationPage.IsBackButtonEnabledProperty.GetDefaultValue(parentType);
                TopCommandBar = global::Avalonia.Controls.NavigationPage.TopCommandBarProperty.GetDefaultValue(parentType);

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
