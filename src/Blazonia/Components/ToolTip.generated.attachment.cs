            
using System.Runtime.Versioning;

namespace Blazonia.Components
{
    [RequiresPreviewFeatures]
    internal static class ToolTipInitializer
    {
        [System.Runtime.CompilerServices.ModuleInitializer]
        internal static void RegisterAdditionalHandlers()
        {
        AttachedPropertyRegistry.RegisterAttachedPropertyHandler("ToolTip.BetweenShowDelay",
            (element, value) =>
            {
                if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                {
                    element.ClearValue(AC.ToolTip.BetweenShowDelayProperty);
                }
                else
                {
                    if (value is string s)
                    {
                        AC.ToolTip.SetBetweenShowDelay((Avalonia.Controls.Control)element, int.Parse(s));
                    }
                    else
                    {
                        AC.ToolTip.SetBetweenShowDelay((Avalonia.Controls.Control)element, (int)value);
                    }
                }
            });
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("ToolTip.CustomPopupPlacementCallback",
                (element, value) =>
                {
                    if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(AC.ToolTip.CustomPopupPlacementCallbackProperty);
                    }
                    else
                    {
                        AC.ToolTip.SetCustomPopupPlacementCallback((Avalonia.Controls.Control)element, (AC.Primitives.PopupPositioning.CustomPopupPlacementCallback)value);
                    }
                });
        AttachedPropertyRegistry.RegisterAttachedPropertyHandler("ToolTip.HorizontalOffset",
            (element, value) =>
            {
                if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                {
                    element.ClearValue(AC.ToolTip.HorizontalOffsetProperty);
                }
                else
                {
                    if (value is string s)
                    {
                        AC.ToolTip.SetHorizontalOffset((Avalonia.Controls.Control)element, double.Parse(s));
                    }
                    else
                    {
                        AC.ToolTip.SetHorizontalOffset((Avalonia.Controls.Control)element, (double)value);
                    }
                }
            });
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("ToolTip.IsOpen",
                (element, value) =>
                {
                    if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(AC.ToolTip.IsOpenProperty);
                    }
                    else
                    {
                        AC.ToolTip.SetIsOpen((Avalonia.Controls.Control)element, (bool)value);
                    }
                });
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("ToolTip.Placement",
                (element, value) =>
                {
                    if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(AC.ToolTip.PlacementProperty);
                    }
                    else
                    {
                        AC.ToolTip.SetPlacement((Avalonia.Controls.Control)element, (AC.PlacementMode)value);
                    }
                });
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("ToolTip.ServiceEnabled",
                (element, value) =>
                {
                    if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(AC.ToolTip.ServiceEnabledProperty);
                    }
                    else
                    {
                        AC.ToolTip.SetServiceEnabled((Avalonia.Controls.Control)element, (bool)value);
                    }
                });
        AttachedPropertyRegistry.RegisterAttachedPropertyHandler("ToolTip.ShowDelay",
            (element, value) =>
            {
                if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                {
                    element.ClearValue(AC.ToolTip.ShowDelayProperty);
                }
                else
                {
                    if (value is string s)
                    {
                        AC.ToolTip.SetShowDelay((Avalonia.Controls.Control)element, int.Parse(s));
                    }
                    else
                    {
                        AC.ToolTip.SetShowDelay((Avalonia.Controls.Control)element, (int)value);
                    }
                }
            });
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("ToolTip.ShowOnDisabled",
                (element, value) =>
                {
                    if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(AC.ToolTip.ShowOnDisabledProperty);
                    }
                    else
                    {
                        AC.ToolTip.SetShowOnDisabled((Avalonia.Controls.Control)element, (bool)value);
                    }
                });
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("ToolTip.ChildContent",
                (element, value) =>
                {
                    if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(AC.ToolTip.TipProperty);
                    }
                    else
                    {
                        AC.ToolTip.SetTip((Avalonia.Controls.Control)element, (object)value);
                    }
                });
        AttachedPropertyRegistry.RegisterAttachedPropertyHandler("ToolTip.VerticalOffset",
            (element, value) =>
            {
                if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                {
                    element.ClearValue(AC.ToolTip.VerticalOffsetProperty);
                }
                else
                {
                    if (value is string s)
                    {
                        AC.ToolTip.SetVerticalOffset((Avalonia.Controls.Control)element, double.Parse(s));
                    }
                    else
                    {
                        AC.ToolTip.SetVerticalOffset((Avalonia.Controls.Control)element, (double)value);
                    }
                }
            });
        }
    }

    public static class ToolTipExtensions
    {
        /// <summary>
        /// Defines the ToolTip.BetweenShowDelay property.
        /// </summary>
        public static Control ToolTipBetweenShowDelay(this Control element, int value)
        {
            element.AttachedProperties["ToolTip.BetweenShowDelay"] = value;
        
            return element;
        }
        public static Control ToolTipCustomPopupPlacementCallback(this Control element, AC.Primitives.PopupPositioning.CustomPopupPlacementCallback value)
        {
            element.AttachedProperties["ToolTip.CustomPopupPlacementCallback"] = value;
        
            return element;
        }
        /// <summary>
        /// Defines the ToolTip.HorizontalOffset property.
        /// </summary>
        public static Control ToolTipHorizontalOffset(this Control element, double value)
        {
            element.AttachedProperties["ToolTip.HorizontalOffset"] = value;
        
            return element;
        }
        /// <summary>
        /// Defines the ToolTip.IsOpen attached property.
        /// </summary>
        public static Control ToolTipIsOpen(this Control element, bool value)
        {
            element.AttachedProperties["ToolTip.IsOpen"] = value;
        
            return element;
        }
        /// <summary>
        /// Defines the ToolTip.Placement property.
        /// </summary>
        public static Control ToolTipPlacement(this Control element, AC.PlacementMode value)
        {
            element.AttachedProperties["ToolTip.Placement"] = value;
        
            return element;
        }
        /// <summary>
        /// Defines the ToolTip.ServiceEnabled property.
        /// </summary>
        public static Control ToolTipServiceEnabled(this Control element, bool value)
        {
            element.AttachedProperties["ToolTip.ServiceEnabled"] = value;
        
            return element;
        }
        /// <summary>
        /// Defines the ToolTip.ShowDelay property.
        /// </summary>
        public static Control ToolTipShowDelay(this Control element, int value)
        {
            element.AttachedProperties["ToolTip.ShowDelay"] = value;
        
            return element;
        }
        /// <summary>
        /// Defines the ToolTip.ShowOnDisabled property.
        /// </summary>
        public static Control ToolTipShowOnDisabled(this Control element, bool value)
        {
            element.AttachedProperties["ToolTip.ShowOnDisabled"] = value;
        
            return element;
        }
        /// <summary>
        /// Defines the ToolTip.Tip attached property.
        /// </summary>
        public static Control ToolTipChildContent(this Control element, RenderFragment value)
        {
            element.AttachedProperties["ToolTip.ChildContent"] = value;
        
            return element;
        }
        /// <summary>
        /// Defines the ToolTip.VerticalOffset property.
        /// </summary>
        public static Control ToolTipVerticalOffset(this Control element, double value)
        {
            element.AttachedProperties["ToolTip.VerticalOffset"] = value;
        
            return element;
        }
    }

    public class ToolTip_Attachment : NativeControlComponentBase, INonPhysicalChild, IContainerElementHandler
    {
        /// <summary>
        /// Defines the ToolTip.BetweenShowDelay property.
        /// </summary>
        [Parameter] public int BetweenShowDelay { get; set; }

        [Parameter] public AC.Primitives.PopupPositioning.CustomPopupPlacementCallback CustomPopupPlacementCallback { get; set; }

        /// <summary>
        /// Defines the ToolTip.HorizontalOffset property.
        /// </summary>
        [Parameter] public double HorizontalOffset { get; set; }

        /// <summary>
        /// Defines the ToolTip.IsOpen attached property.
        /// </summary>
        [Parameter] public bool IsOpen { get; set; }

        /// <summary>
        /// Defines the ToolTip.Placement property.
        /// </summary>
        [Parameter] public AC.PlacementMode Placement { get; set; }

        /// <summary>
        /// Defines the ToolTip.ServiceEnabled property.
        /// </summary>
        [Parameter] public bool ServiceEnabled { get; set; }

        /// <summary>
        /// Defines the ToolTip.ShowDelay property.
        /// </summary>
        [Parameter] public int ShowDelay { get; set; }

        /// <summary>
        /// Defines the ToolTip.ShowOnDisabled property.
        /// </summary>
        [Parameter] public bool ShowOnDisabled { get; set; }

        /// <summary>
        /// Defines the ToolTip.Tip attached property.
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Defines the ToolTip.VerticalOffset property.
        /// </summary>
        [Parameter] public double VerticalOffset { get; set; }


        protected override RenderFragment GetChildContent() => ChildContent;

        private Avalonia.Controls.Control _parent;

        public object TargetElement => _parent;

        public override Task SetParametersAsync(ParameterView parameters)
        {
            foreach (var parameterValue in parameters)
            {
                var value = parameterValue.Value;
                switch (parameterValue.Name)
                {
                    case nameof(BetweenShowDelay):
                    if (!Equals(BetweenShowDelay, value))
                    {
                        BetweenShowDelay = (int)value;
                        //NativeControl.BetweenShowDelayProperty = BetweenShowDelay;
                    }
                    break;

                    case nameof(CustomPopupPlacementCallback):
                    if (!Equals(CustomPopupPlacementCallback, value))
                    {
                        CustomPopupPlacementCallback = (AC.Primitives.PopupPositioning.CustomPopupPlacementCallback)value;
                        //NativeControl.CustomPopupPlacementCallbackProperty = CustomPopupPlacementCallback;
                    }
                    break;

                    case nameof(HorizontalOffset):
                    if (!Equals(HorizontalOffset, value))
                    {
                        HorizontalOffset = (double)value;
                        //NativeControl.HorizontalOffsetProperty = HorizontalOffset;
                    }
                    break;

                    case nameof(IsOpen):
                    if (!Equals(IsOpen, value))
                    {
                        IsOpen = (bool)value;
                        //NativeControl.IsOpenProperty = IsOpen;
                    }
                    break;

                    case nameof(Placement):
                    if (!Equals(Placement, value))
                    {
                        Placement = (AC.PlacementMode)value;
                        //NativeControl.PlacementProperty = Placement;
                    }
                    break;

                    case nameof(ServiceEnabled):
                    if (!Equals(ServiceEnabled, value))
                    {
                        ServiceEnabled = (bool)value;
                        //NativeControl.ServiceEnabledProperty = ServiceEnabled;
                    }
                    break;

                    case nameof(ShowDelay):
                    if (!Equals(ShowDelay, value))
                    {
                        ShowDelay = (int)value;
                        //NativeControl.ShowDelayProperty = ShowDelay;
                    }
                    break;

                    case nameof(ShowOnDisabled):
                    if (!Equals(ShowOnDisabled, value))
                    {
                        ShowOnDisabled = (bool)value;
                        //NativeControl.ShowOnDisabledProperty = ShowOnDisabled;
                    }
                    break;

                    case nameof(ChildContent):
                    if (!Equals(ChildContent, value))
                    {
                        ChildContent = (RenderFragment)value;
                        //NativeControl.TipProperty = ChildContent;
                    }
                    break;

                    case nameof(VerticalOffset):
                    if (!Equals(VerticalOffset, value))
                    {
                        VerticalOffset = (double)value;
                        //NativeControl.VerticalOffsetProperty = VerticalOffset;
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
                if (BetweenShowDelay == global::Avalonia.Controls.ToolTip.BetweenShowDelayProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Control)parentElement).ClearValue( global::Avalonia.Controls.ToolTip.BetweenShowDelayProperty);
                }
                else
                {
                     global::Avalonia.Controls.ToolTip.SetBetweenShowDelay((Avalonia.Controls.Control)parentElement, BetweenShowDelay);
                }
                
                if (CustomPopupPlacementCallback == global::Avalonia.Controls.ToolTip.CustomPopupPlacementCallbackProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Control)parentElement).ClearValue( global::Avalonia.Controls.ToolTip.CustomPopupPlacementCallbackProperty);
                }
                else
                {
                     global::Avalonia.Controls.ToolTip.SetCustomPopupPlacementCallback((Avalonia.Controls.Control)parentElement, CustomPopupPlacementCallback);
                }
                
                if (HorizontalOffset == global::Avalonia.Controls.ToolTip.HorizontalOffsetProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Control)parentElement).ClearValue( global::Avalonia.Controls.ToolTip.HorizontalOffsetProperty);
                }
                else
                {
                     global::Avalonia.Controls.ToolTip.SetHorizontalOffset((Avalonia.Controls.Control)parentElement, HorizontalOffset);
                }
                
                if (IsOpen == global::Avalonia.Controls.ToolTip.IsOpenProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Control)parentElement).ClearValue( global::Avalonia.Controls.ToolTip.IsOpenProperty);
                }
                else
                {
                     global::Avalonia.Controls.ToolTip.SetIsOpen((Avalonia.Controls.Control)parentElement, IsOpen);
                }
                
                if (Placement == global::Avalonia.Controls.ToolTip.PlacementProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Control)parentElement).ClearValue( global::Avalonia.Controls.ToolTip.PlacementProperty);
                }
                else
                {
                     global::Avalonia.Controls.ToolTip.SetPlacement((Avalonia.Controls.Control)parentElement, Placement);
                }
                
                if (ServiceEnabled == global::Avalonia.Controls.ToolTip.ServiceEnabledProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Control)parentElement).ClearValue( global::Avalonia.Controls.ToolTip.ServiceEnabledProperty);
                }
                else
                {
                     global::Avalonia.Controls.ToolTip.SetServiceEnabled((Avalonia.Controls.Control)parentElement, ServiceEnabled);
                }
                
                if (ShowDelay == global::Avalonia.Controls.ToolTip.ShowDelayProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Control)parentElement).ClearValue( global::Avalonia.Controls.ToolTip.ShowDelayProperty);
                }
                else
                {
                     global::Avalonia.Controls.ToolTip.SetShowDelay((Avalonia.Controls.Control)parentElement, ShowDelay);
                }
                
                if (ShowOnDisabled == global::Avalonia.Controls.ToolTip.ShowOnDisabledProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Control)parentElement).ClearValue( global::Avalonia.Controls.ToolTip.ShowOnDisabledProperty);
                }
                else
                {
                     global::Avalonia.Controls.ToolTip.SetShowOnDisabled((Avalonia.Controls.Control)parentElement, ShowOnDisabled);
                }
                
                if (VerticalOffset == global::Avalonia.Controls.ToolTip.VerticalOffsetProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Control)parentElement).ClearValue( global::Avalonia.Controls.ToolTip.VerticalOffsetProperty);
                }
                else
                {
                     global::Avalonia.Controls.ToolTip.SetVerticalOffset((Avalonia.Controls.Control)parentElement, VerticalOffset);
                }
                
            }
        }
    
        void INonPhysicalChild.SetParent(object parentElement)
        {
            var parentType = parentElement?.GetType();
            if (parentType is not null)
            {
                BetweenShowDelay = BetweenShowDelay != default ? BetweenShowDelay : global::Avalonia.Controls.ToolTip.BetweenShowDelayProperty.GetDefaultValue(parentType);
                CustomPopupPlacementCallback = CustomPopupPlacementCallback != default ? CustomPopupPlacementCallback : global::Avalonia.Controls.ToolTip.CustomPopupPlacementCallbackProperty.GetDefaultValue(parentType);
                HorizontalOffset = HorizontalOffset != default ? HorizontalOffset : global::Avalonia.Controls.ToolTip.HorizontalOffsetProperty.GetDefaultValue(parentType);
                IsOpen = IsOpen != default ? IsOpen : global::Avalonia.Controls.ToolTip.IsOpenProperty.GetDefaultValue(parentType);
                Placement = Placement != default ? Placement : global::Avalonia.Controls.ToolTip.PlacementProperty.GetDefaultValue(parentType);
                ServiceEnabled = ServiceEnabled != default ? ServiceEnabled : global::Avalonia.Controls.ToolTip.ServiceEnabledProperty.GetDefaultValue(parentType);
                ShowDelay = ShowDelay != default ? ShowDelay : global::Avalonia.Controls.ToolTip.ShowDelayProperty.GetDefaultValue(parentType);
                ShowOnDisabled = ShowOnDisabled != default ? ShowOnDisabled : global::Avalonia.Controls.ToolTip.ShowOnDisabledProperty.GetDefaultValue(parentType);
                VerticalOffset = VerticalOffset != default ? VerticalOffset : global::Avalonia.Controls.ToolTip.VerticalOffsetProperty.GetDefaultValue(parentType);

                TryUpdateParent(parentElement);
            }

            _parent = (Avalonia.Controls.Control)parentElement;
        }
        
        
        public void RemoveFromParent(object parentElement)
        {
            if (_parent is not null)
            {
                global::Avalonia.Controls.ToolTip.SetTip(_parent, default);
            }

            var parentType = parentElement?.GetType();
            if (parentType is not null)
            {
                BetweenShowDelay = global::Avalonia.Controls.ToolTip.BetweenShowDelayProperty.GetDefaultValue(parentType);
                CustomPopupPlacementCallback = global::Avalonia.Controls.ToolTip.CustomPopupPlacementCallbackProperty.GetDefaultValue(parentType);
                HorizontalOffset = global::Avalonia.Controls.ToolTip.HorizontalOffsetProperty.GetDefaultValue(parentType);
                IsOpen = global::Avalonia.Controls.ToolTip.IsOpenProperty.GetDefaultValue(parentType);
                Placement = global::Avalonia.Controls.ToolTip.PlacementProperty.GetDefaultValue(parentType);
                ServiceEnabled = global::Avalonia.Controls.ToolTip.ServiceEnabledProperty.GetDefaultValue(parentType);
                ShowDelay = global::Avalonia.Controls.ToolTip.ShowDelayProperty.GetDefaultValue(parentType);
                ShowOnDisabled = global::Avalonia.Controls.ToolTip.ShowOnDisabledProperty.GetDefaultValue(parentType);
                VerticalOffset = global::Avalonia.Controls.ToolTip.VerticalOffsetProperty.GetDefaultValue(parentType);

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
            RenderTreeBuilderHelper.AddContentProperty<Avalonia.Controls.Control>(builder, sequence++, ChildContent,
                (nativeControl, value) =>
                {
                    if (_parent is not null)
                    {
                        global::Avalonia.Controls.ToolTip.SetTip(_parent, value);
                    }
                });
        }
    }
}
