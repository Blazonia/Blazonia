namespace Blazonia.ComponentGenerator;

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
public class GenerateComponentAttribute : Attribute
{
    public GenerateComponentAttribute(Type typeToGenerate)
    {
    }

    /// <summary>
    /// Exclude members from generation.
    /// </summary>
    public string[] Exclude { get; set; }

    /// <summary>
    /// Include members to generation which would usually be excluded.
    /// </summary>
    public string[] Include { get; set; }

    /// <summary>
    /// Renders property as RenderFragment.
    /// </summary>
    public string[] ContentProperties { get; set; }

    /// <summary>
    /// Generate parameters with different name. Format: "{MauiName}:{GeneratedName}".
    /// </summary>
    public string[] Aliases { get; set; }

    /// <summary>
    /// Generate generic component type.
    /// </summary>
    public bool IsGeneric { get; set; }
}