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
using Avalonia.Controls.Chrome;
using Avalonia.Controls.Embedding;
using Avalonia.Controls.Notifications;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Remote;

[assembly: XmlnsPrefix("https://blazonia.github.io", "b")]
[assembly: XmlnsDefinition("https://blazonia.github.io", "Blazonia.Controls")]

[assembly: InternalsVisibleTo("BlazorBindings.UnitTests")]

[assembly: GenerateComponentsFromAssembly("Avalonia.Base")]
[assembly: GenerateComponentsFromAssembly("Avalonia.Controls")]
[assembly: GenerateComponentsFromAssembly("Avalonia.Controls.DataGrid")]
[assembly: GenerateComponentsFromAssembly("Avalonia.Controls.ItemsRepeater")]

[assembly: GenerateComponent(typeof(AutoCompleteBox),
    ContentProperties = new[]
    {
        nameof(AutoCompleteBox.ItemTemplate)
    })]
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
[assembly: GenerateComponent(typeof(DataGridColumn),
    ContentProperties = new[]
    {
        nameof(DataGridColumn.HeaderTemplate)
    })]
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
[assembly: GenerateComponent(typeof(Panel),
    ContentProperties = new string[]
    {
        nameof(Panel.Children)
    }
    )]
[assembly: GenerateComponent(typeof(SelectingItemsControl),
    Include = new string[]
    {

    }
)]

[assembly: GenerateComponent(typeof(SplitView),
    ContentProperties = new[]
    {
        nameof(SplitView.PaneTemplate)
    })]
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
[assembly: GenerateComponent(typeof(TemplatedControl),
    ContentProperties = new string[]
    {
        nameof(TemplatedControl.Template)
    })]

[assembly: GenerateComponent(typeof(ToggleSwitch),
    ContentProperties = new[]
    {
        nameof(ToggleSwitch.OnContentTemplate),
        nameof(ToggleSwitch.OffContentTemplate),
    })]
[assembly: GenerateComponent(typeof(ToolTip),
    ContentProperties = new[]
    {
        nameof(ToolTip.TipProperty)
    }
    )]

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

