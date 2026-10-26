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

// ContextMenu is neither [Content]-marked nor a template type in Avalonia, so content
// rendering and the ContextMenuSlot name cannot be inferred - both stay explicit here.
[assembly: GenerateComponent(typeof(Control),
    ContentProperties = new[]
    {
        nameof(Control.ContextMenu)
    },
    Aliases = new[]
    {
        $"{nameof(Control.ContextMenu)}:ContextMenuSlot",
    })]
// ITemplate<Control> cannot be rendered as content (ControlTemplateItemsComponent only
// supports ITemplate<Panel>), so this stays a registered content property as-is.
[assembly: GenerateComponent(typeof(DataGrid),
    ContentProperties = new[]
    {
        nameof(DataGrid.DropLocationIndicatorTemplate)
    },
    IsGeneric = true)]
// PreviewContent is object-typed but not [Content]-marked in Avalonia.
[assembly: GenerateComponent(typeof(GridSplitter),
    ContentProperties = new[]
    {
        nameof(GridSplitter.PreviewContent)
    })]
// DataGridColumn derives from AvaloniaObject (not Animatable), so the assembly scan's
// Animatable filter cannot reach it - this explicit registration keeps it generated.
[assembly: GenerateComponent(typeof(DataGridColumn))]
[assembly: GenerateComponent(typeof(ItemsControl),
    Exclude = new string[]
    {
        nameof(ItemsControl.ItemsSource),
    },
    IsGeneric = true)]
[assembly: GenerateComponent(typeof(ListBox),
    Include = new[]
    {
        nameof(ListBox.SelectionMode),
        nameof(ListBox.SelectedItems),
        nameof(ListBox.Selection)
    })]

// Template is a concrete ControlTemplate (not [Content]-marked, not IControlTemplate),
// so content rendering cannot be inferred.
[assembly: GenerateComponent(typeof(TemplatedControl),
    ContentProperties = new string[]
    {
        nameof(TemplatedControl.Template)
    })]

// Tip is object-typed but not [Content]-marked in Avalonia.
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

