// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

namespace Blazonia;
using AvaloniaBindableObject = Avalonia.AvaloniaObject;


/// <remarks>Experimental API, subject to change.</remarks>
[RequiresPreviewFeatures]
public static class AttachedPropertyRegistry
{
    internal static readonly Dictionary<string, Action<AvaloniaBindableObject, object>> AttachedPropertyHandlers = new();

    public static void RegisterAttachedPropertyHandler(string propertyName, Action<AvaloniaBindableObject, object> handler)
    {
        AttachedPropertyHandlers[propertyName] = handler;
    }
}
