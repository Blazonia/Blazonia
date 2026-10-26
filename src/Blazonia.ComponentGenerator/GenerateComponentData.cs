using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blazonia.ComponentGenerator;

public class GenerateComponentSettings
{
    private bool _isForcedGeneric;

    /// <summary>
    /// Members excluded from every component: Initialized is raised by the framework
    /// itself and has no Blazor-facing meaning.
    /// </summary>
    public static readonly string[] DefaultExcludes = { "Initialized" };

    public string FileHeader { get; set; }
    public string TypeAlias { get; set; }
    public INamedTypeSymbol TypeSymbol { get; set; }
    public HashSet<string> Exclude { get; set; } = new();
    public HashSet<string> Include { get; set; } = new();
    public HashSet<string> ContentProperties { get; set; } = new();
    public Dictionary<string, string> Aliases { get; set; } = new();
    public GenerateComponentSettings BaseTypeInfo { get; set; }
    public bool IsBaseTypeGeneric => BaseTypeInfo?.IsGeneric ?? false;

    public bool IsGeneric
    {
        get => _isForcedGeneric || IsBaseTypeGeneric;
        set => _isForcedGeneric = value;
    }

    /// <summary>
    /// Genericity declared on this registration itself (not inherited from the base chain);
    /// only these components get their item-shaped properties mapped to T.
    /// </summary>
    public bool IsExplicitlyGeneric => _isForcedGeneric;

    public AttachedPropertyGeneration AttachedPropertyGeneration { get; set; } = AttachedPropertyGeneration.ExtensionMethods | AttachedPropertyGeneration.Elements;
}
