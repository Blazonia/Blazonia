using Blazonia.Extensions;
using System.Collections;
using System.Diagnostics;

namespace Blazonia.Components.Internal;

internal class ListContentPropertyComponent<TControl, TItem> : NativeControlComponentBase, IContainerElementHandler, INonPhysicalChild
    where TItem : class
{
    private TControl _parent;
    private IList _propertyItems;

    [Parameter] public Func<TControl, IList> ListPropertyAccessor { get; set; }
    [Parameter] public RenderFragment ChildContent { get; set; }

    protected override RenderFragment GetChildContent() => ChildContent;

    public void SetParent(object parentElement)
    {
        _parent = parentElement.Cast<TControl>();
        _propertyItems = ListPropertyAccessor(_parent);
    }

    public void RemoveFromParent(object parentElement)
    {
        // Because this Handler is used internally only, this method is no-op.
    }

    object IElementHandler.TargetElement => _parent;

    void IContainerElementHandler.AddChild(object child, int physicalSiblingIndex)
    {
        _propertyItems.Insert(physicalSiblingIndex, child.Cast<TItem>());
    }

    void IContainerElementHandler.RemoveChild(object child, int physicalSiblingIndex)
    {
        Debug.Assert(_propertyItems[physicalSiblingIndex] == child);
        _propertyItems.Remove(child.Cast<TItem>());
    }

    void IContainerElementHandler.ReplaceChild(int physicalSiblingIndex, object oldChild, object newChild)
    {
        Debug.Assert(_propertyItems[physicalSiblingIndex] == oldChild);
        _propertyItems[physicalSiblingIndex] = newChild.Cast<TItem>();
    }
}
