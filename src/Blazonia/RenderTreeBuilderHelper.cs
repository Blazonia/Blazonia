// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using Avalonia.Controls.Primitives;
using Avalonia.Controls.Templates;
using Blazonia.Components.DataTemplates;
using Blazonia.Components.Internal;
using Microsoft.AspNetCore.Components.Rendering;
using System.Collections;
using AvaloniaDataTemplate = Avalonia.Controls.Templates.IDataTemplate;
using AC = Avalonia.Controls;

namespace Blazonia;

/// <remarks>Experimental API, subject to change.</remarks>
[RequiresPreviewFeatures]
public static class RenderTreeBuilderHelper
{
    public static void AddContentProperty<TControl>(
        RenderTreeBuilder builder,
        int sequence,
        RenderFragment content,
        Action<TControl, object> setPropertyAction)
    {
        if (content != null)
        {
            builder.OpenRegion(sequence);

            builder.OpenComponent<ContentPropertyComponent<TControl>>(0);
            builder.AddAttribute(1, nameof(ContentPropertyComponent<TControl>.ChildContent), content);
            builder.AddAttribute(2, nameof(ContentPropertyComponent<TControl>.SetPropertyAction), setPropertyAction);
            builder.CloseComponent();

            builder.CloseRegion();
        }
    }

    public static void AddListContentProperty<TControl, TItem>(
        RenderTreeBuilder builder,
        int sequence,
        RenderFragment content,
        Func<TControl, IList> listPropertyAccessor)
        where TItem : class
    {
        if (content != null)
        {
            builder.OpenRegion(sequence);

            builder.OpenComponent<ListContentPropertyComponent<TControl, TItem>>(0);
            builder.AddAttribute(1, nameof(ListContentPropertyComponent<TControl, TItem>.ChildContent), content);
            builder.AddAttribute(2, nameof(ListContentPropertyComponent<TControl, TItem>.ListPropertyAccessor), listPropertyAccessor);
            builder.CloseComponent();

            builder.CloseRegion();
        }
    }

    public static void AddDataTemplateProperty<TControl, TItem>(
        RenderTreeBuilder builder,
        int sequence,
        RenderFragment<TItem> template,
        Action<TControl, AvaloniaDataTemplate> setDataTemplateAction)
    {
        if (template != null)
        {
            builder.OpenRegion(sequence);

            builder.OpenComponent<DataTemplateItemsComponent<TControl, TItem>>(0);
            builder.AddAttribute(1, nameof(DataTemplateItemsComponent<TControl, TItem>.SetDataTemplateAction), setDataTemplateAction);
            builder.AddAttribute(2, nameof(DataTemplateItemsComponent<TControl, TItem>.Template), template);
            builder.CloseComponent();

            builder.CloseRegion();
        }
    }

    public static void AddDataTemplateProperty<T>(
        RenderTreeBuilder builder,
        int sequence,
        RenderFragment template,
        Action<T, AvaloniaDataTemplate> setDataTemplateAction)
        where T : AC.Control
    {
        if (template != null)
        {
            builder.OpenRegion(sequence);

            builder.OpenComponent<DataTemplateItemsComponent<T, IDataTemplate>>(0);
            builder.AddAttribute(1, nameof(DataTemplateItemsComponent<T, IDataTemplate>.SetDataTemplateAction), setDataTemplateAction);
            builder.AddAttribute(2, nameof(DataTemplateItemsComponent<T, IDataTemplate>.Template), template);
            builder.CloseComponent();

            builder.CloseRegion();
        }
    }

    public static void AddDataTemplateProperty<T>(
        RenderTreeBuilder builder,
        int sequence,
        RenderFragment<AvaloniaDataTemplate> template,
        Action<T, AvaloniaDataTemplate> setDataTemplateAction)
        where T : AC.Control
    {
        if (template != null)
        {
            builder.OpenRegion(sequence);

            builder.OpenComponent<DataTemplateItemsComponent<T, IDataTemplate>>(0);
            builder.AddAttribute(1, nameof(DataTemplateItemsComponent<T, IDataTemplate>.SetDataTemplateAction), setDataTemplateAction);
            builder.AddAttribute(2, nameof(DataTemplateItemsComponent<T, IDataTemplate>.Template), template);
            builder.CloseComponent();

            builder.CloseRegion();
        }
    }

    
    public static void AddControlTemplateProperty<TNativeControl, TNativeTemplate>(
        RenderTreeBuilder builder,
        int sequence,
        RenderFragment template,
        //Action<T, Avalonia.Controls.ITemplate<T>> setControlTemplateAction)
        Action<TNativeControl, TNativeTemplate> setControlTemplateAction)
        where TNativeControl : TemplatedControl //AvaloniaBindableObject
    {
        if (template != null)
        {
            builder.OpenRegion(sequence);

            builder.OpenComponent<ControlTemplateItemsComponent<TNativeControl, TNativeTemplate>>(0);
            builder.AddAttribute(1, nameof(ControlTemplateItemsComponent<TNativeControl, TNativeTemplate>.SetControlTemplateAction), setControlTemplateAction);
            builder.AddAttribute(2, nameof(ControlTemplateItemsComponent<TNativeControl, TNativeTemplate>.Template), template);
            builder.AddComponentReferenceCapture(3, reference => { });
            builder.CloseComponent();

            builder.CloseRegion();
        }
    }

    internal static void AddSyncDataTemplateProperty<TControl, TItem>(
        RenderTreeBuilder builder,
        int sequence,
        RenderFragment<TItem> template,
        Action<TControl, AvaloniaDataTemplate> setDataTemplateAction)
    {
        if (template != null)
        {
            builder.OpenRegion(sequence);

            builder.OpenComponent<SyncDataTemplateItemsComponent<TControl, TItem>>(0);
            builder.AddAttribute(1, nameof(SyncDataTemplateItemsComponent<TControl, TItem>.SetDataTemplateAction), setDataTemplateAction);
            builder.AddAttribute(2, nameof(SyncDataTemplateItemsComponent<TControl, TItem>.Template), template);
            builder.CloseComponent();

            builder.CloseRegion();
        }
    }

    //internal static void AddSyncDataTemplateProperty<T>(
    //    RenderTreeBuilder builder,
    //    int sequence,
    //    RenderFragment template,
    //    Action<T, AC.DataTemplate> setDataTemplateAction)
    //    where T : AvaloniaBindableObject
    //{
    //    if (template != null)
    //    {
    //        builder.OpenRegion(sequence);

    //        builder.OpenComponent<SyncControlTemplateItemsComponent<T>>(0);
    //        builder.AddAttribute(1, nameof(SyncControlTemplateItemsComponent<T>.SetDataTemplateAction), setDataTemplateAction);
    //        builder.AddAttribute(2, nameof(SyncControlTemplateItemsComponent<T>.Template), template);
    //        builder.CloseComponent();

    //        builder.CloseRegion();
    //    }
    //}

    internal static void AddItemsSourceProperty<TControl, TItem>(
        RenderTreeBuilder builder,
        int sequence,
        IEnumerable<TItem> items,
        Func<TItem, object> keySelector,
        Action<TControl, ICollection<TItem>> collectionSetter)
    {
        if (items is null)
            return;

        builder.OpenRegion(sequence);

        builder.OpenComponent<ItemsSourceComponent<TControl, TItem>>(0);
        builder.AddAttribute(1, nameof(ItemsSourceComponent<TControl, TItem>.Items), items);
        builder.AddAttribute(2, nameof(ItemsSourceComponent<TControl, TItem>.CollectionSetter), collectionSetter);

        if (keySelector != null)
            builder.AddAttribute(3, nameof(ItemsSourceComponent<TControl, TItem>.KeySelector), keySelector);

        builder.CloseComponent();

        builder.CloseRegion();
    }
}
