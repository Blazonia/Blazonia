// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Templates;
using Avalonia.Markup.Xaml.Templates;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blazonia.Components.DataTemplates;

/// <summary>
/// This ControlTemplate implementation wraps the content in an additional View, therefore it is not suitable in cases when non-View content
/// is expected from template.
/// </summary>
internal class ControlTemplateItemsComponent<TControl, TTemplate> : NativeControlComponentBase, IContainerElementHandler, INonPhysicalChild
    where TControl : TemplatedControl
{
    protected override void RenderAdditionalElementContent(RenderTreeBuilder builder, ref int sequence)
    {
        base.RenderAdditionalElementContent(builder, ref sequence);

        if (SetControlTemplateAction is not null)
        {
            RenderTreeBuilderHelper.AddContentProperty<TControl>(builder, sequence++, Template, (x, value) =>
            {
                if (typeof(ITemplate<AC.Panel>).IsAssignableFrom(typeof(TTemplate)))
                {
                    var controlTemplate = new ItemsPanelTemplate()
                    {
                        Content = (Func<IServiceProvider, object>)((serviceProvider) => new TemplateResult<AC.Control>((AC.Control)value, null))
                    };

                    SetControlTemplateAction(_parent, (TTemplate)(object)controlTemplate);
                }
                else
                {
                    throw new NotSupportedException($"{typeof(TTemplate).Name} is not yet supported");
                }
                
            });
        }
    }

    [Parameter] public Action<TControl, TTemplate> SetControlTemplateAction { get; set; }
    
    [Parameter] public RenderFragment Template { get; set; }

    private TControl _parent;

    void INonPhysicalChild.SetParent(object parentElement)
    {
        _parent = parentElement as TControl;
    }


    void INonPhysicalChild.RemoveFromParent(object parentElement) { }
    void IContainerElementHandler.AddChild(object child, int physicalSiblingIndex) { }
    void IContainerElementHandler.RemoveChild(object child, int physicalSiblingIndex) { }
    object IElementHandler.TargetElement => null;
}
