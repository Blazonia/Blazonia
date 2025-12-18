// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Layout;
using Blazonia.ComponentGenerator;
using System.Runtime.CompilerServices;
using Avalonia.Controls.Documents;
using Avalonia.Controls.Shapes;
using Avalonia.Animation;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Controls.Primitives;

using Avalonia.Metadata;

[assembly: XmlnsPrefix("https://blazonia.github.io", "b")]
[assembly: XmlnsDefinition("https://blazonia.github.io", "Blazonia.Controls")]

[assembly: InternalsVisibleTo("BlazorBindings.UnitTests")]

[assembly: GenerateComponent(typeof(Application))]
[assembly: GenerateComponent(typeof(Animatable))]
[assembly: GenerateComponent(typeof(AttachedLayout))]
[assembly: GenerateComponent(typeof(AutoCompleteBox),
    ContentProperties = new[]
    {
        nameof(AutoCompleteBox.ItemTemplate)
    })]
[assembly: GenerateComponent(typeof(Border))]
[assembly: GenerateComponent(typeof(Brush))]
[assembly: GenerateComponent(typeof(Button))]
[assembly: GenerateComponent(typeof(ButtonSpinner))]
[assembly: GenerateComponent(typeof(Calendar))]
[assembly: GenerateComponent(typeof(CalendarDatePicker))]
[assembly: GenerateComponent(typeof(Canvas))]
[assembly: GenerateComponent(typeof(Carousel))]
[assembly: GenerateComponent(typeof(CheckBox))]
[assembly: GenerateComponent(typeof(ComboBox))]
[assembly: GenerateComponent(typeof(ContentControl),
    ContentProperties = new[]
    {
        nameof(ContentControl.Content),
        nameof(ContentControl.ContentTemplate)
    })]
[assembly: GenerateComponent(typeof(ContextMenu))]
[assembly: GenerateComponent(typeof(Control),
    ContentProperties = new[]
    {
        nameof(Control.ContextMenu)
    },
    Aliases = new[]
    {
        $"{nameof(Control.ContextMenu)}:ContextMenuSlot",
    })]
[assembly: GenerateComponent(typeof(DatePicker))]
[assembly: GenerateComponent(typeof(Decorator),
    ContentProperties = new[]
    {
        nameof(Decorator.Child)
    })]
[assembly: GenerateComponent(typeof(DataGrid),
    ContentProperties = new[]
    {
        nameof(DataGrid.DropLocationIndicatorTemplate),
        nameof(DataGrid.RowDetailsTemplate)
    },
    GenericProperties = new[]
    {
        nameof(DataGrid.ItemsSource),
        nameof(DataGrid.RowDetailsTemplate)
    })]
[assembly: GenerateComponent(typeof(DatePicker))]
[assembly: GenerateComponent(typeof(DockPanel))]
[assembly: GenerateComponent(typeof(Expander))]
[assembly: GenerateComponent(typeof(Flyout))]
[assembly: GenerateComponent(typeof(FlyoutBase))]
[assembly: GenerateComponent(typeof(GradientBrush))]
[assembly: GenerateComponent(typeof(GradientStop))]
[assembly: GenerateComponent(typeof(Grid))]
[assembly: GenerateComponent(typeof(GridSplitter),
    ContentProperties = new[]
    {
        nameof(GridSplitter.PreviewContent)
    })]
[assembly: GenerateComponent(typeof(HeaderedContentControl),
    ContentProperties = new[]
    {
        nameof(HeaderedContentControl.HeaderTemplate)
    })]
[assembly: GenerateComponent(typeof(HeaderedItemsControl),
    ContentProperties = new[]
    {
        nameof(HeaderedItemsControl.HeaderTemplate)
    })]
[assembly: GenerateComponent(typeof(HeaderedSelectingItemsControl),
    ContentProperties = new[]
    {
        nameof(HeaderedSelectingItemsControl.HeaderTemplate)
    })]

[assembly: GenerateComponent(typeof(Inline))]
[assembly: GenerateComponent(typeof(InlineUIContainer))]
[assembly: GenerateComponent(typeof(InputElement))]
[assembly: GenerateComponent(typeof(Interactive))]
[assembly: GenerateComponent(typeof(Image))]
[assembly: GenerateComponent(typeof(ItemsControl),
    ContentProperties = new string[]
    {
        nameof(ItemsControl.ItemTemplate),
        nameof(ItemsControl.ItemsPanel),
        nameof(ItemsControl.Items),
    },
    Exclude = new string[]
    {
        //nameof(ItemsControl.ItemsPanel),
        nameof(ItemsControl.ItemsSource),
    },
    GenericProperties = new string[]
    {
        nameof(ItemsControl.ItemTemplate)
        //nameof(ListBox.SelectedItems),
        //nameof(ListBox.Selection),
        //nameof(ListView.ItemsSource),
        //$"{nameof(ItemsControl.ItemsPanel)}:Avalonia.Controls.Panel",
        //nameof(ListView.GroupDisplayBinding),
        //nameof(ListView.GroupShortNameBinding)
        }
    )]
[assembly: GenerateComponent(typeof(ItemsRepeater),
    ContentProperties = new[]
    {
        nameof(ItemsRepeater.ItemTemplate)
    })]
[assembly: GenerateComponent(typeof(Label))]
[assembly: GenerateComponent(typeof(Layoutable))]
[assembly: GenerateComponent(typeof(LayoutTransformControl))]
[assembly: GenerateComponent(typeof(LinearGradientBrush))]
[assembly: GenerateComponent(typeof(ListBox),
    Exclude = new string[]
    { 
        //nameof(ListBox.ItemTemplate) 
    },
    Include = new[]
    {
        nameof(ListBox.SelectionMode),
        nameof(ListBox.SelectedItems),
        nameof(ListBox.Selection)
    },
    ContentProperties = new string[]
    {
        //nameof(ListBox.ItemTemplate),
        //nameof(ListBox.ItemsPanel),
    },
    GenericProperties = new string[]
    {
        //nameof(ListBox.SelectedItems),
        //nameof(ListBox.Selection),
        //nameof(ListView.ItemsSource),
        //$"{nameof(ListBox.ItemsPanel)}:Avalonia.Controls.Panel",
        //nameof(ListView.GroupDisplayBinding),
        //nameof(ListView.GroupShortNameBinding)
    },
    Aliases = new string[] {
        //$"{nameof(ListView.HeaderTemplate)}:Header",
        //$"{nameof(ListView.FooterTemplate)}:Footer" 
    })]
[assembly: GenerateComponent(typeof(MaskedTextBox))]
[assembly: GenerateComponent(typeof(Menu))]
[assembly: GenerateComponent(typeof(MenuBase))]
[assembly: GenerateComponent(typeof(MenuItem))]
[assembly: GenerateComponent(typeof(NativeMenu))]
[assembly: GenerateComponent(typeof(NumericUpDown))]
[assembly: GenerateComponent(typeof(Panel),
    ContentProperties = new string[]
    {
        nameof(Panel.Children)
    }
    )]
[assembly: GenerateComponent(typeof(PopupFlyoutBase))]
[assembly: GenerateComponent(typeof(ProgressBar))]
[assembly: GenerateComponent(typeof(RelativePanel))]
[assembly: GenerateComponent(typeof(RadialGradientBrush))]
[assembly: GenerateComponent(typeof(RadioButton))]
[assembly: GenerateComponent(typeof(RangeBase))]
[assembly: GenerateComponent(typeof(ScrollBar))]
[assembly: GenerateComponent(typeof(ScrollViewer))]
[assembly: GenerateComponent(typeof(Separator))]
[assembly: GenerateComponent(typeof(SelectingItemsControl),
    Include = new string[]
    {

    }
)]

[assembly: GenerateComponent(typeof(Slider))]
[assembly: GenerateComponent(typeof(Spinner))]
[assembly: GenerateComponent(typeof(SplitView),
    ContentProperties = new[]
    {
        nameof(SplitView.PaneTemplate)
    })]
[assembly: GenerateComponent(typeof(SolidColorBrush))]
[assembly: GenerateComponent(typeof(Span))]
[assembly: GenerateComponent(typeof(SplitButton))]
[assembly: GenerateComponent(typeof(StackPanel))]
[assembly: GenerateComponent(typeof(StackLayout))]
[assembly: GenerateComponent(typeof(StyledElement),
    Exclude = new[]
    {
        nameof(StyledElement.Initialized)
    })]
[assembly: GenerateComponent(typeof(TabControl),
    ContentProperties = new[]
    {
        nameof(TabControl.ContentTemplate),
        //nameof(TabControl.Items)
    },
    Include = new string[]
    {
        //nameof(TabControl.Items)
    })]
[assembly: GenerateComponent(typeof(TabItem))]
[assembly: GenerateComponent(typeof(TabStrip))]
[assembly: GenerateComponent(typeof(TemplatedControl),
    ContentProperties = new string[]
    {
        nameof(TemplatedControl.Template)
    })]
[assembly: GenerateComponent(typeof(TextBox))]
[assembly: GenerateComponent(typeof(TextElement))]
[assembly: GenerateComponent(typeof(TextBlock))]
[assembly: GenerateComponent(typeof(SelectableTextBlock))]

[assembly: GenerateComponent(typeof(Thumb))]
[assembly: GenerateComponent(typeof(TrayIcon))]
[assembly: GenerateComponent(typeof(ToggleButton))]
[assembly: GenerateComponent(typeof(ToggleSwitch),
    ContentProperties = new[]
    {
        nameof(ToggleSwitch.OnContentTemplate),
        nameof(ToggleSwitch.OffContentTemplate),
    })]
[assembly: GenerateComponent(typeof(ToggleSplitButton))]
[assembly: GenerateComponent(typeof(TopLevel))]
[assembly: GenerateComponent(typeof(TimePicker))]
[assembly: GenerateComponent(typeof(ToolTip),
    ContentProperties = new[]
    {
        nameof(ToolTip.TipProperty)
    }
    )]
[assembly: GenerateComponent(typeof(TreeView))]
[assembly: GenerateComponent(typeof(TreeViewItem))]
[assembly: GenerateComponent(typeof(TransitioningContentControl))]
[assembly: GenerateComponent(typeof(UserControl))]
[assembly: GenerateComponent(typeof(Viewbox))]
[assembly: GenerateComponent(typeof(VirtualizingLayout))]

[assembly: GenerateComponent(typeof(Visual),

    Exclude = new[] {
        nameof(Visual.ActualThemeVariantChanged),
        nameof(Visual.AttachedToLogicalTree),
        nameof(Visual.AttachedToVisualTree),
        //nameof(Visual.DataContextChanged), // ?
        nameof(Visual.DetachedFromLogicalTree),
        nameof(Visual.DetachedFromVisualTree),
        nameof(Visual.ResourcesChanged),

        //nameof(Element.Handler), nameof(Visual.ChildAdded), nameof(Visual.ChildRemoved),
        //nameof(Visual.DescendantAdded), nameof(Visual.DescendantRemoved), nameof(Visual.ParentChanged),
        //nameof(Visual.ParentChanging), nameof(Visual.HandlerChanged), nameof(Visual.HandlerChanging) 
    })]

[assembly: GenerateComponent(typeof(Window))]
[assembly: GenerateComponent(typeof(WindowBase))]
[assembly: GenerateComponent(typeof(WrapPanel))]

// Shapes
[assembly: GenerateComponent(typeof(Ellipse))]
[assembly: GenerateComponent(typeof(Line))]
[assembly: GenerateComponent(typeof(Polygon))]
[assembly: GenerateComponent(typeof(Polyline))]
[assembly: GenerateComponent(typeof(Rectangle))]
[assembly: GenerateComponent(typeof(Shape))]
