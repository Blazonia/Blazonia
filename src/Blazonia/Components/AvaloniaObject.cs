// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using Microsoft.AspNetCore.Components.Rendering;
using System.Runtime.CompilerServices;

namespace Blazonia.Components;

public abstract class AvaloniaObject : NativeControlComponentBase, IElementHandler
{
    [Parameter] public Delegate Attached { get; set; }

    public Dictionary<string, object> AttachedProperties { get; set; } = new Dictionary<string, object>();

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> AdditionalProperties { get; set; } = new Dictionary<string, object>();

    private AvaloniaBindableObject _nativeControl;

    public AvaloniaBindableObject NativeControl => _nativeControl ??= CreateNativeElement();

    public override async Task SetParametersAsync(ParameterView parameters)
    {
        foreach (var parameterValue in parameters)
        {
            HandleParameter(parameterValue.Name, parameterValue.Value);
        }

        foreach (var parameterValue in AdditionalProperties)
        {
            HandleParameter(parameterValue.Key, parameterValue.Value);
        }

        foreach (var parameterValue in AttachedProperties)
        {
            HandleParameter(parameterValue.Key, parameterValue.Value);
        }

        await base.SetParametersAsync(ParameterView.Empty);
    }

    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "AsUntyped")]
    public static extern EventCallback AsUntyped<T>(EventCallback<T> component);

    [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "Receiver")]
    public static extern IHandleEvent? GetReceiver<T>(EventCallback<T> component);

    [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "Delegate")]
    public static extern ref MulticastDelegate? GetDelegate<T>(EventCallback<T> component);

    internal EventCallback AsUntypedEx(dynamic value)
    {
        return new EventCallback(GetReceiver(value) ?? GetDelegate(value)?.Target as IHandleEvent, GetDelegate(value));
    }

    protected virtual void HandleParameter(string name, object value)
    {
        if (name == "Attached")
        {
            var last = AttachedProperties;
            AttachedProperties = new Dictionary<string, object>();
            ((dynamic)value).Invoke((dynamic)this);

            var toReset = last?.Keys.Except(AttachedProperties.Keys) ?? Array.Empty<string>();
            foreach (var reset in toReset)
            {
                HandleParameter(reset, AvaloniaProperty.UnsetValue);
            }

            return;
        }

        if (HandleAdditionalParameter(name, value))
            return;

        if (AttachedPropertyRegistry.AttachedPropertyHandlers.TryGetValue(name, out var handler))
        {
            handler(NativeControl, value);
            return;
        }

        throw new NotImplementedException($"{GetType().FullName} doesn't recognize parameter '{name}'");
    }

    protected override void RenderAdditionalElementContent(RenderTreeBuilder builder, ref int sequence)
    {
        RenderAdditionalPartialElementContent(builder, ref sequence);
    }

    [RequiresPreviewFeatures]
    protected virtual void RenderAdditionalPartialElementContent(RenderTreeBuilder builder, ref int sequence) { }

    protected virtual bool HandleAdditionalParameter(string name, object value) => false;

    protected abstract AvaloniaBindableObject CreateNativeElement();

    object IElementHandler.TargetElement => NativeControl;
}
