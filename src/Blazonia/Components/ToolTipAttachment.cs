using Microsoft.AspNetCore.Components.Rendering;

namespace Blazonia.Components;

public class ToolTipAttachment : NativeControlComponentBase, INonPhysicalChild, IContainerElementHandler
{
    [Parameter] public AC.PlacementMode Placement { get; set; }

    [Parameter] public RenderFragment ChildContent { get; set; }
    public object TargetElement => _parent;

    private readonly List<AC.Control> _children = new();
    private AC.Control _parent;

    public override Task SetParametersAsync(ParameterView parameters)
    {
        var handledChildContent = false;
        foreach (var parameterValue in parameters)
        {
            switch (parameterValue.Name)
            {
                case nameof(Placement):
                    var placement = (AC.PlacementMode)parameterValue.Value;
                    if (placement != Placement)
                    {
                        Placement = placement;

                        TryUpdateParent();
                    }
                    break;
                case nameof(ChildContent):
                    {
                        ChildContent = (RenderFragment)parameterValue.Value;
                        handledChildContent = true;
                        break;
                    }
            }
        }

        if (!handledChildContent)
        {
            ChildContent = builder => { };
        }


        return base.SetParametersAsync(ParameterView.Empty);
    }

    protected override RenderFragment GetChildContent() => ChildContent;

    void INonPhysicalChild.SetParent(object parentElement)
    {
        _parent = (AC.Control)parentElement;
        TryUpdateParent();
    }

    private void TryUpdateParent()
    {
        if (_parent is not null)
        {
            AC.ToolTip.SetPlacement(_parent, Placement);
        }
    }

    public void RemoveFromParent(object parentElement)
    {
        foreach (var child in _children)
        {

        }
        _children.Clear();

        AC.ToolTip.SetTip(_parent, null);

        _parent = null;
    }

    public void AddChild(object child, int physicalSiblingIndex)
    {
        var childView = child.Cast<AC.Control>();

        _children.Add(childView);
    }

    public void RemoveChild(object child, int physicalSiblingIndex)
    {
        _children.Remove((AC.Control)child);
    }

    protected override void RenderAdditionalElementContent(RenderTreeBuilder builder, ref int sequence)
    {
        base.RenderAdditionalElementContent(builder, ref sequence);

        RenderTreeBuilderHelper.AddContentProperty<AC.Shapes.Ellipse>(builder, sequence++, ChildContent,
            (nativeControl, value) => AC.ToolTip.SetTip(_parent, value));
    }
}
