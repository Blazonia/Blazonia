// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using Avalonia.Controls.Converters;
using Avalonia.Media;
using System.Globalization;

namespace Blazonia.Components;

public static partial class AttributeHelper
{
    private static ColorToHexConverter _colorToHexConverter = new ColorToHexConverter();
    /// <summary>
    /// Helper method to deserialize <see cref="Color" /> objects.
    /// </summary>
    public static Color GetColor(object obj)
    {
        return obj switch
        {
            null => default(Color),
            Color color => color,
            string colorAsString => _colorToHexConverter.ConvertBack(colorAsString, typeof(Color), null, CultureInfo.InvariantCulture) is Color c ? c : default(Color),
            _ => throw new ArgumentException("Cannot convert parameter to Color.", nameof(obj))
        };
    }
}
