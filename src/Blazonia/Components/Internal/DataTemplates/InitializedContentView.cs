// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

namespace Blazonia.Components.DataTemplates;

internal class InitializedContentView : ContentControl//Control
{
    [Parameter] public new AvaloniaContentView NativeControl { get; set; }
    
    protected override AvaloniaContentView CreateNativeElement() => NativeControl;

    protected override void HandleParameter(string name, object value)
    {
        if (name == nameof(NativeControl))
        {
            NativeControl = (AvaloniaContentView)value;
        }
        else
        {
            base.HandleParameter(name, value);
        }
    }
}
