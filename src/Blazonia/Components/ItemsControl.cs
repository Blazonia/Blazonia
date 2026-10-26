// Hand-written partial: ItemsSource assignment/sync strategy for ItemsControl<T>
// (direct assign for observable/immutable collections, synced wrapper otherwise).
// Not generated - edits here are permanent.

using Blazonia.Components.Primitives;
using Microsoft.AspNetCore.Components.Rendering;
using System.Collections.Immutable;
using System.Collections.Specialized;
using AC = Avalonia.Controls;

#pragma warning disable CA2252

namespace Blazonia.Components
{
    /// <summary>
    /// Displays a collection of items.
    /// </summary>
    public partial class ItemsControl<T> : TemplatedControl
    {
        [Parameter] public IEnumerable<T> ItemsSource { get; set; }

        private bool AssignItemsSourceDirectly => ItemsSource is INotifyCollectionChanged || ItemsSource is IImmutableList<T>;

        protected override bool HandleAdditionalParameter(string name, object value)
        {
            switch (name)
            {
                case nameof(ItemsSource):
                    if (!Equals(ItemsSource, value))
                    {
                        ItemsSource = (IEnumerable<T>)value;

                        if (AssignItemsSourceDirectly)
                            NativeControl.ItemsSource = ItemsSource;
                    }
                    return true;

                default:
                    return base.HandleAdditionalParameter(name, value);
            }
        }


        protected override void RenderAdditionalPartialElementContent(RenderTreeBuilder builder, ref int sequence)
        {
            base.RenderAdditionalPartialElementContent(builder, ref sequence);
            RenderTreeBuilderHelper.AddSyncDataTemplateProperty<AC.ItemsControl, T>(builder, sequence++, ItemTemplate,
                (nativeElement, nativeDataTemplate) => nativeElement.ItemTemplate = nativeDataTemplate);

            sequence++;
            if (!AssignItemsSourceDirectly)
            {
                RenderTreeBuilderHelper.AddItemsSourceProperty<AC.ItemsControl, T>(builder, sequence, ItemsSource, /*ItemKeySelector*/null, 
                    (nativeElement, items) => nativeElement.ItemsSource = items);
            }
        }
    }
}
