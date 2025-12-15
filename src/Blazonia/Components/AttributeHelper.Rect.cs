// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.


namespace Blazonia.Components;

public static partial class AttributeHelper
{
    /// <summary>
    /// Helper method deserialize LayoutBounds <see cref="Rect"/> objects.
    /// The difference is that "10, 15" is not a valid Rect string, but could be a valid 
    /// LayoutBounds <see cref="Rect"/> string (with Height and Width set to Auto).
    /// </summary>
    public static Rect GetBoundsRect(object value, Rect defaultValueIfNull = default)
    {
        return value switch
        {
            null => defaultValueIfNull,
            Rect rect => rect,
            string rectangleAsString => ConvertFromString(rectangleAsString) ?? defaultValueIfNull,
            _ => throw new ArgumentException("Cannot convert value to Rect.", nameof(value)),
        };
    }

    private static Rect? ConvertFromString(string rectangleAsString)
    {
        var strs = rectangleAsString.Split(',');
        if (strs.Length == 4)
        {
            var numbers = strs
                .Select(x => new { Success = double.TryParse(x, out var number), Number = number })
                .ToList();

            if (numbers.All(x => x.Success))
            {
                return new Rect(numbers[0].Number, numbers[1].Number, numbers[2].Number, numbers[3].Number);
            }
        }

        return null;
    }
}
