            
using System.Runtime.Versioning;
using Blazonia.Components.Input;

namespace Blazonia.Components
{
    [RequiresPreviewFeatures]
    internal static class ScrollViewerInitializer
    {
        [System.Runtime.CompilerServices.ModuleInitializer]
        internal static void RegisterAdditionalHandlers()
        {
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("ScrollViewer.AllowAutoHide",
                (element, value) =>
                {
                    if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(AC.ScrollViewer.AllowAutoHideProperty);
                    }
                    else
                    {
                        AC.ScrollViewer.SetAllowAutoHide((Avalonia.Controls.Control)element, (bool)value);
                    }
                });
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("ScrollViewer.BringIntoViewOnFocusChange",
                (element, value) =>
                {
                    if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(AC.ScrollViewer.BringIntoViewOnFocusChangeProperty);
                    }
                    else
                    {
                        AC.ScrollViewer.SetBringIntoViewOnFocusChange((Avalonia.Controls.Control)element, (bool)value);
                    }
                });
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("ScrollViewer.HorizontalScrollBarVisibility",
                (element, value) =>
                {
                    if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(AC.ScrollViewer.HorizontalScrollBarVisibilityProperty);
                    }
                    else
                    {
                        AC.ScrollViewer.SetHorizontalScrollBarVisibility((Avalonia.Controls.Control)element, (AC.Primitives.ScrollBarVisibility)value);
                    }
                });
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("ScrollViewer.HorizontalSnapPointsAlignment",
                (element, value) =>
                {
                    if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(AC.ScrollViewer.HorizontalSnapPointsAlignmentProperty);
                    }
                    else
                    {
                        AC.ScrollViewer.SetHorizontalSnapPointsAlignment((Avalonia.Controls.Control)element, (AC.Primitives.SnapPointsAlignment)value);
                    }
                });
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("ScrollViewer.HorizontalSnapPointsType",
                (element, value) =>
                {
                    if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(AC.ScrollViewer.HorizontalSnapPointsTypeProperty);
                    }
                    else
                    {
                        AC.ScrollViewer.SetHorizontalSnapPointsType((Avalonia.Controls.Control)element, (AC.Primitives.SnapPointsType)value);
                    }
                });
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("ScrollViewer.IsDeferredScrollingEnabled",
                (element, value) =>
                {
                    if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(AC.ScrollViewer.IsDeferredScrollingEnabledProperty);
                    }
                    else
                    {
                        AC.ScrollViewer.SetIsDeferredScrollingEnabled((Avalonia.Controls.Control)element, (bool)value);
                    }
                });
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("ScrollViewer.IsScrollChainingEnabled",
                (element, value) =>
                {
                    if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(AC.ScrollViewer.IsScrollChainingEnabledProperty);
                    }
                    else
                    {
                        AC.ScrollViewer.SetIsScrollChainingEnabled((Avalonia.Controls.Control)element, (bool)value);
                    }
                });
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("ScrollViewer.IsScrollInertiaEnabled",
                (element, value) =>
                {
                    if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(AC.ScrollViewer.IsScrollInertiaEnabledProperty);
                    }
                    else
                    {
                        AC.ScrollViewer.SetIsScrollInertiaEnabled((Avalonia.Controls.Control)element, (bool)value);
                    }
                });
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("ScrollViewer.VerticalScrollBarVisibility",
                (element, value) =>
                {
                    if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(AC.ScrollViewer.VerticalScrollBarVisibilityProperty);
                    }
                    else
                    {
                        AC.ScrollViewer.SetVerticalScrollBarVisibility((Avalonia.Controls.Control)element, (AC.Primitives.ScrollBarVisibility)value);
                    }
                });
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("ScrollViewer.VerticalSnapPointsAlignment",
                (element, value) =>
                {
                    if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(AC.ScrollViewer.VerticalSnapPointsAlignmentProperty);
                    }
                    else
                    {
                        AC.ScrollViewer.SetVerticalSnapPointsAlignment((Avalonia.Controls.Control)element, (AC.Primitives.SnapPointsAlignment)value);
                    }
                });
            AttachedPropertyRegistry.RegisterAttachedPropertyHandler("ScrollViewer.VerticalSnapPointsType",
                (element, value) =>
                {
                    if (value?.Equals(AvaloniaProperty.UnsetValue) == true)
                    {
                        element.ClearValue(AC.ScrollViewer.VerticalSnapPointsTypeProperty);
                    }
                    else
                    {
                        AC.ScrollViewer.SetVerticalSnapPointsType((Avalonia.Controls.Control)element, (AC.Primitives.SnapPointsType)value);
                    }
                });
        }
    }

    public static class ScrollViewerExtensions
    {
        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.ScrollViewer.AllowAutoHide" /> property.
        /// </summary>
        public static Control ScrollViewerAllowAutoHide(this Control element, bool value)
        {
            element.AttachedProperties["ScrollViewer.AllowAutoHide"] = value;
        
            return element;
        }
        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.ScrollViewer.BringIntoViewOnFocusChange" /> property.
        /// </summary>
        public static Control ScrollViewerBringIntoViewOnFocusChange(this Control element, bool value)
        {
            element.AttachedProperties["ScrollViewer.BringIntoViewOnFocusChange"] = value;
        
            return element;
        }
        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.ScrollViewer.HorizontalScrollBarVisibility" /> property.
        /// </summary>
        public static Control ScrollViewerHorizontalScrollBarVisibility(this Control element, AC.Primitives.ScrollBarVisibility value)
        {
            element.AttachedProperties["ScrollViewer.HorizontalScrollBarVisibility"] = value;
        
            return element;
        }
        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.ScrollViewer.HorizontalSnapPointsAlignment" /> property.
        /// </summary>
        public static Control ScrollViewerHorizontalSnapPointsAlignment(this Control element, AC.Primitives.SnapPointsAlignment value)
        {
            element.AttachedProperties["ScrollViewer.HorizontalSnapPointsAlignment"] = value;
        
            return element;
        }
        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.ScrollViewer.HorizontalSnapPointsType" /> property.
        /// </summary>
        public static Control ScrollViewerHorizontalSnapPointsType(this Control element, AC.Primitives.SnapPointsType value)
        {
            element.AttachedProperties["ScrollViewer.HorizontalSnapPointsType"] = value;
        
            return element;
        }
        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.ScrollViewer.IsDeferredScrollingEnabled" /> property.
        /// </summary>
        public static Control ScrollViewerIsDeferredScrollingEnabled(this Control element, bool value)
        {
            element.AttachedProperties["ScrollViewer.IsDeferredScrollingEnabled"] = value;
        
            return element;
        }
        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.ScrollViewer.IsScrollChainingEnabled" /> property.
        /// </summary>
        public static Control ScrollViewerIsScrollChainingEnabled(this Control element, bool value)
        {
            element.AttachedProperties["ScrollViewer.IsScrollChainingEnabled"] = value;
        
            return element;
        }
        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.ScrollViewer.IsScrollInertiaEnabled" /> property.
        /// </summary>
        public static Control ScrollViewerIsScrollInertiaEnabled(this Control element, bool value)
        {
            element.AttachedProperties["ScrollViewer.IsScrollInertiaEnabled"] = value;
        
            return element;
        }
        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.ScrollViewer.VerticalScrollBarVisibility" /> property.
        /// </summary>
        public static Control ScrollViewerVerticalScrollBarVisibility(this Control element, AC.Primitives.ScrollBarVisibility value)
        {
            element.AttachedProperties["ScrollViewer.VerticalScrollBarVisibility"] = value;
        
            return element;
        }
        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.ScrollViewer.VerticalSnapPointsAlignment" /> property.
        /// </summary>
        public static Control ScrollViewerVerticalSnapPointsAlignment(this Control element, AC.Primitives.SnapPointsAlignment value)
        {
            element.AttachedProperties["ScrollViewer.VerticalSnapPointsAlignment"] = value;
        
            return element;
        }
        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.ScrollViewer.VerticalSnapPointsType" /> property.
        /// </summary>
        public static Control ScrollViewerVerticalSnapPointsType(this Control element, AC.Primitives.SnapPointsType value)
        {
            element.AttachedProperties["ScrollViewer.VerticalSnapPointsType"] = value;
        
            return element;
        }
    }

    public class ScrollViewer_Attachment : NativeControlComponentBase, INonPhysicalChild, IContainerElementHandler
    {
        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.ScrollViewer.AllowAutoHide" /> property.
        /// </summary>
        [Parameter] public bool AllowAutoHide { get; set; }

        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.ScrollViewer.BringIntoViewOnFocusChange" /> property.
        /// </summary>
        [Parameter] public bool BringIntoViewOnFocusChange { get; set; }

        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.ScrollViewer.HorizontalScrollBarVisibility" /> property.
        /// </summary>
        [Parameter] public AC.Primitives.ScrollBarVisibility HorizontalScrollBarVisibility { get; set; }

        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.ScrollViewer.HorizontalSnapPointsAlignment" /> property.
        /// </summary>
        [Parameter] public AC.Primitives.SnapPointsAlignment HorizontalSnapPointsAlignment { get; set; }

        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.ScrollViewer.HorizontalSnapPointsType" /> property.
        /// </summary>
        [Parameter] public AC.Primitives.SnapPointsType HorizontalSnapPointsType { get; set; }

        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.ScrollViewer.IsDeferredScrollingEnabled" /> property.
        /// </summary>
        [Parameter] public bool IsDeferredScrollingEnabled { get; set; }

        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.ScrollViewer.IsScrollChainingEnabled" /> property.
        /// </summary>
        [Parameter] public bool IsScrollChainingEnabled { get; set; }

        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.ScrollViewer.IsScrollInertiaEnabled" /> property.
        /// </summary>
        [Parameter] public bool IsScrollInertiaEnabled { get; set; }

        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.ScrollViewer.VerticalScrollBarVisibility" /> property.
        /// </summary>
        [Parameter] public AC.Primitives.ScrollBarVisibility VerticalScrollBarVisibility { get; set; }

        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.ScrollViewer.VerticalSnapPointsAlignment" /> property.
        /// </summary>
        [Parameter] public AC.Primitives.SnapPointsAlignment VerticalSnapPointsAlignment { get; set; }

        /// <summary>
        /// Defines the <see cref="P:Avalonia.Controls.ScrollViewer.VerticalSnapPointsType" /> property.
        /// </summary>
        [Parameter] public AC.Primitives.SnapPointsType VerticalSnapPointsType { get; set; }

        private Avalonia.Controls.Control _parent;

        public object TargetElement => _parent;

        public override Task SetParametersAsync(ParameterView parameters)
        {
            foreach (var parameterValue in parameters)
            {
                var value = parameterValue.Value;
                switch (parameterValue.Name)
                {
                    case nameof(AllowAutoHide):
                    if (!Equals(AllowAutoHide, value))
                    {
                        AllowAutoHide = (bool)value;
                        //NativeControl.AllowAutoHideProperty = AllowAutoHide;
                    }
                    break;

                    case nameof(BringIntoViewOnFocusChange):
                    if (!Equals(BringIntoViewOnFocusChange, value))
                    {
                        BringIntoViewOnFocusChange = (bool)value;
                        //NativeControl.BringIntoViewOnFocusChangeProperty = BringIntoViewOnFocusChange;
                    }
                    break;

                    case nameof(HorizontalScrollBarVisibility):
                    if (!Equals(HorizontalScrollBarVisibility, value))
                    {
                        HorizontalScrollBarVisibility = (AC.Primitives.ScrollBarVisibility)value;
                        //NativeControl.HorizontalScrollBarVisibilityProperty = HorizontalScrollBarVisibility;
                    }
                    break;

                    case nameof(HorizontalSnapPointsAlignment):
                    if (!Equals(HorizontalSnapPointsAlignment, value))
                    {
                        HorizontalSnapPointsAlignment = (AC.Primitives.SnapPointsAlignment)value;
                        //NativeControl.HorizontalSnapPointsAlignmentProperty = HorizontalSnapPointsAlignment;
                    }
                    break;

                    case nameof(HorizontalSnapPointsType):
                    if (!Equals(HorizontalSnapPointsType, value))
                    {
                        HorizontalSnapPointsType = (AC.Primitives.SnapPointsType)value;
                        //NativeControl.HorizontalSnapPointsTypeProperty = HorizontalSnapPointsType;
                    }
                    break;

                    case nameof(IsDeferredScrollingEnabled):
                    if (!Equals(IsDeferredScrollingEnabled, value))
                    {
                        IsDeferredScrollingEnabled = (bool)value;
                        //NativeControl.IsDeferredScrollingEnabledProperty = IsDeferredScrollingEnabled;
                    }
                    break;

                    case nameof(IsScrollChainingEnabled):
                    if (!Equals(IsScrollChainingEnabled, value))
                    {
                        IsScrollChainingEnabled = (bool)value;
                        //NativeControl.IsScrollChainingEnabledProperty = IsScrollChainingEnabled;
                    }
                    break;

                    case nameof(IsScrollInertiaEnabled):
                    if (!Equals(IsScrollInertiaEnabled, value))
                    {
                        IsScrollInertiaEnabled = (bool)value;
                        //NativeControl.IsScrollInertiaEnabledProperty = IsScrollInertiaEnabled;
                    }
                    break;

                    case nameof(VerticalScrollBarVisibility):
                    if (!Equals(VerticalScrollBarVisibility, value))
                    {
                        VerticalScrollBarVisibility = (AC.Primitives.ScrollBarVisibility)value;
                        //NativeControl.VerticalScrollBarVisibilityProperty = VerticalScrollBarVisibility;
                    }
                    break;

                    case nameof(VerticalSnapPointsAlignment):
                    if (!Equals(VerticalSnapPointsAlignment, value))
                    {
                        VerticalSnapPointsAlignment = (AC.Primitives.SnapPointsAlignment)value;
                        //NativeControl.VerticalSnapPointsAlignmentProperty = VerticalSnapPointsAlignment;
                    }
                    break;

                    case nameof(VerticalSnapPointsType):
                    if (!Equals(VerticalSnapPointsType, value))
                    {
                        VerticalSnapPointsType = (AC.Primitives.SnapPointsType)value;
                        //NativeControl.VerticalSnapPointsTypeProperty = VerticalSnapPointsType;
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
                if (AllowAutoHide == global::Avalonia.Controls.ScrollViewer.AllowAutoHideProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Control)parentElement).ClearValue( global::Avalonia.Controls.ScrollViewer.AllowAutoHideProperty);
                }
                else
                {
                     global::Avalonia.Controls.ScrollViewer.SetAllowAutoHide((Avalonia.Controls.Control)parentElement, AllowAutoHide);
                }
                
                if (BringIntoViewOnFocusChange == global::Avalonia.Controls.ScrollViewer.BringIntoViewOnFocusChangeProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Control)parentElement).ClearValue( global::Avalonia.Controls.ScrollViewer.BringIntoViewOnFocusChangeProperty);
                }
                else
                {
                     global::Avalonia.Controls.ScrollViewer.SetBringIntoViewOnFocusChange((Avalonia.Controls.Control)parentElement, BringIntoViewOnFocusChange);
                }
                
                if (HorizontalScrollBarVisibility == global::Avalonia.Controls.ScrollViewer.HorizontalScrollBarVisibilityProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Control)parentElement).ClearValue( global::Avalonia.Controls.ScrollViewer.HorizontalScrollBarVisibilityProperty);
                }
                else
                {
                     global::Avalonia.Controls.ScrollViewer.SetHorizontalScrollBarVisibility((Avalonia.Controls.Control)parentElement, HorizontalScrollBarVisibility);
                }
                
                if (HorizontalSnapPointsAlignment == global::Avalonia.Controls.ScrollViewer.HorizontalSnapPointsAlignmentProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Control)parentElement).ClearValue( global::Avalonia.Controls.ScrollViewer.HorizontalSnapPointsAlignmentProperty);
                }
                else
                {
                     global::Avalonia.Controls.ScrollViewer.SetHorizontalSnapPointsAlignment((Avalonia.Controls.Control)parentElement, HorizontalSnapPointsAlignment);
                }
                
                if (HorizontalSnapPointsType == global::Avalonia.Controls.ScrollViewer.HorizontalSnapPointsTypeProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Control)parentElement).ClearValue( global::Avalonia.Controls.ScrollViewer.HorizontalSnapPointsTypeProperty);
                }
                else
                {
                     global::Avalonia.Controls.ScrollViewer.SetHorizontalSnapPointsType((Avalonia.Controls.Control)parentElement, HorizontalSnapPointsType);
                }
                
                if (IsDeferredScrollingEnabled == global::Avalonia.Controls.ScrollViewer.IsDeferredScrollingEnabledProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Control)parentElement).ClearValue( global::Avalonia.Controls.ScrollViewer.IsDeferredScrollingEnabledProperty);
                }
                else
                {
                     global::Avalonia.Controls.ScrollViewer.SetIsDeferredScrollingEnabled((Avalonia.Controls.Control)parentElement, IsDeferredScrollingEnabled);
                }
                
                if (IsScrollChainingEnabled == global::Avalonia.Controls.ScrollViewer.IsScrollChainingEnabledProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Control)parentElement).ClearValue( global::Avalonia.Controls.ScrollViewer.IsScrollChainingEnabledProperty);
                }
                else
                {
                     global::Avalonia.Controls.ScrollViewer.SetIsScrollChainingEnabled((Avalonia.Controls.Control)parentElement, IsScrollChainingEnabled);
                }
                
                if (IsScrollInertiaEnabled == global::Avalonia.Controls.ScrollViewer.IsScrollInertiaEnabledProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Control)parentElement).ClearValue( global::Avalonia.Controls.ScrollViewer.IsScrollInertiaEnabledProperty);
                }
                else
                {
                     global::Avalonia.Controls.ScrollViewer.SetIsScrollInertiaEnabled((Avalonia.Controls.Control)parentElement, IsScrollInertiaEnabled);
                }
                
                if (VerticalScrollBarVisibility == global::Avalonia.Controls.ScrollViewer.VerticalScrollBarVisibilityProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Control)parentElement).ClearValue( global::Avalonia.Controls.ScrollViewer.VerticalScrollBarVisibilityProperty);
                }
                else
                {
                     global::Avalonia.Controls.ScrollViewer.SetVerticalScrollBarVisibility((Avalonia.Controls.Control)parentElement, VerticalScrollBarVisibility);
                }
                
                if (VerticalSnapPointsAlignment == global::Avalonia.Controls.ScrollViewer.VerticalSnapPointsAlignmentProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Control)parentElement).ClearValue( global::Avalonia.Controls.ScrollViewer.VerticalSnapPointsAlignmentProperty);
                }
                else
                {
                     global::Avalonia.Controls.ScrollViewer.SetVerticalSnapPointsAlignment((Avalonia.Controls.Control)parentElement, VerticalSnapPointsAlignment);
                }
                
                if (VerticalSnapPointsType == global::Avalonia.Controls.ScrollViewer.VerticalSnapPointsTypeProperty.GetDefaultValue(parentElement.GetType()))
                {
                    ((Avalonia.Controls.Control)parentElement).ClearValue( global::Avalonia.Controls.ScrollViewer.VerticalSnapPointsTypeProperty);
                }
                else
                {
                     global::Avalonia.Controls.ScrollViewer.SetVerticalSnapPointsType((Avalonia.Controls.Control)parentElement, VerticalSnapPointsType);
                }
                
            }
        }
    
        void INonPhysicalChild.SetParent(object parentElement)
        {
            var parentType = parentElement?.GetType();
            if (parentType is not null)
            {
                AllowAutoHide = AllowAutoHide != default ? AllowAutoHide : global::Avalonia.Controls.ScrollViewer.AllowAutoHideProperty.GetDefaultValue(parentType);
                BringIntoViewOnFocusChange = BringIntoViewOnFocusChange != default ? BringIntoViewOnFocusChange : global::Avalonia.Controls.ScrollViewer.BringIntoViewOnFocusChangeProperty.GetDefaultValue(parentType);
                HorizontalScrollBarVisibility = HorizontalScrollBarVisibility != default ? HorizontalScrollBarVisibility : global::Avalonia.Controls.ScrollViewer.HorizontalScrollBarVisibilityProperty.GetDefaultValue(parentType);
                HorizontalSnapPointsAlignment = HorizontalSnapPointsAlignment != default ? HorizontalSnapPointsAlignment : global::Avalonia.Controls.ScrollViewer.HorizontalSnapPointsAlignmentProperty.GetDefaultValue(parentType);
                HorizontalSnapPointsType = HorizontalSnapPointsType != default ? HorizontalSnapPointsType : global::Avalonia.Controls.ScrollViewer.HorizontalSnapPointsTypeProperty.GetDefaultValue(parentType);
                IsDeferredScrollingEnabled = IsDeferredScrollingEnabled != default ? IsDeferredScrollingEnabled : global::Avalonia.Controls.ScrollViewer.IsDeferredScrollingEnabledProperty.GetDefaultValue(parentType);
                IsScrollChainingEnabled = IsScrollChainingEnabled != default ? IsScrollChainingEnabled : global::Avalonia.Controls.ScrollViewer.IsScrollChainingEnabledProperty.GetDefaultValue(parentType);
                IsScrollInertiaEnabled = IsScrollInertiaEnabled != default ? IsScrollInertiaEnabled : global::Avalonia.Controls.ScrollViewer.IsScrollInertiaEnabledProperty.GetDefaultValue(parentType);
                VerticalScrollBarVisibility = VerticalScrollBarVisibility != default ? VerticalScrollBarVisibility : global::Avalonia.Controls.ScrollViewer.VerticalScrollBarVisibilityProperty.GetDefaultValue(parentType);
                VerticalSnapPointsAlignment = VerticalSnapPointsAlignment != default ? VerticalSnapPointsAlignment : global::Avalonia.Controls.ScrollViewer.VerticalSnapPointsAlignmentProperty.GetDefaultValue(parentType);
                VerticalSnapPointsType = VerticalSnapPointsType != default ? VerticalSnapPointsType : global::Avalonia.Controls.ScrollViewer.VerticalSnapPointsTypeProperty.GetDefaultValue(parentType);

                TryUpdateParent(parentElement);
            }

            _parent = (Avalonia.Controls.Control)parentElement;
        }
        
        
        public void RemoveFromParent(object parentElement)
        {
            var parentType = parentElement?.GetType();
            if (parentType is not null)
            {
                AllowAutoHide = global::Avalonia.Controls.ScrollViewer.AllowAutoHideProperty.GetDefaultValue(parentType);
                BringIntoViewOnFocusChange = global::Avalonia.Controls.ScrollViewer.BringIntoViewOnFocusChangeProperty.GetDefaultValue(parentType);
                HorizontalScrollBarVisibility = global::Avalonia.Controls.ScrollViewer.HorizontalScrollBarVisibilityProperty.GetDefaultValue(parentType);
                HorizontalSnapPointsAlignment = global::Avalonia.Controls.ScrollViewer.HorizontalSnapPointsAlignmentProperty.GetDefaultValue(parentType);
                HorizontalSnapPointsType = global::Avalonia.Controls.ScrollViewer.HorizontalSnapPointsTypeProperty.GetDefaultValue(parentType);
                IsDeferredScrollingEnabled = global::Avalonia.Controls.ScrollViewer.IsDeferredScrollingEnabledProperty.GetDefaultValue(parentType);
                IsScrollChainingEnabled = global::Avalonia.Controls.ScrollViewer.IsScrollChainingEnabledProperty.GetDefaultValue(parentType);
                IsScrollInertiaEnabled = global::Avalonia.Controls.ScrollViewer.IsScrollInertiaEnabledProperty.GetDefaultValue(parentType);
                VerticalScrollBarVisibility = global::Avalonia.Controls.ScrollViewer.VerticalScrollBarVisibilityProperty.GetDefaultValue(parentType);
                VerticalSnapPointsAlignment = global::Avalonia.Controls.ScrollViewer.VerticalSnapPointsAlignmentProperty.GetDefaultValue(parentType);
                VerticalSnapPointsType = global::Avalonia.Controls.ScrollViewer.VerticalSnapPointsTypeProperty.GetDefaultValue(parentType);

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
