using Blazonia.Core;
using Blazonia.Extensions;

namespace Blazonia.Components.Internal;

internal class ContentPropertyComponent<TControl> : NativeControlComponentBase, IContainerElementHandler, INonPhysicalChild, IHandleChildContentText
{
    private TControl _parent;
    private TextSpanContainer _textSpanContainer;

    [Parameter] public Action<TControl, object> SetPropertyAction { get; set; }
    [Parameter] public RenderFragment ChildContent { get; set; }

    protected override RenderFragment GetChildContent() => ChildContent;

    public void SetParent(object parentElement)
    {
        _parent = parentElement.Cast<TControl>();
    }

    public void RemoveFromParent(object parentElement)
    {
        // Because this Handler is used internally only, this method is no-op.
    }

    void IContainerElementHandler.AddChild(object child, int physicalSiblingIndex)
    {
        SetPropertyAction(_parent, child);
    }

    void IContainerElementHandler.RemoveChild(object child, int physicalSiblingIndex)
    {
        SetPropertyAction(_parent, null);
    }

    void IContainerElementHandler.ReplaceChild(int physicalSiblingIndex, object oldChild, object newChild)
    {
        SetPropertyAction(_parent, newChild);
    }

    public void HandleText(bool isAdd, int index, string text)
    {
        if (_parent is AvaloniaContentView handle)
        {
            handle.Content = (_textSpanContainer ??= new()).GetUpdatedText(isAdd, index, text);
        }
    }

    object IElementHandler.TargetElement => _parent;
}
