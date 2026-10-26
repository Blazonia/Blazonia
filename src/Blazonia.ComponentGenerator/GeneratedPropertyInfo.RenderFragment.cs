using Blazonia.ComponentGenerator.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Linq;

namespace Blazonia.ComponentGenerator;

public partial class GeneratedPropertyInfo
{
    private static readonly (string TypeName, bool AllowDescendantTypes)[] ContentTypes =
    [
        ("Avalonia.Controls.Templates.IDataTemplate", false),
    ];

    /// <summary>
    /// The only panel template shape that ControlTemplateItemsComponent can render.
    /// </summary>
    private const string PanelTemplateFullName = "Avalonia.Controls.ITemplate<Avalonia.Controls.Panel>";

    public bool IsRenderFragmentProperty => Kind == GeneratedPropertyKind.RenderFragment;

    public bool IsPanelTemplate =>
        _propertyInfo.Type.GetFullName().StartsWith("Avalonia.Controls.ITemplate<Avalonia.Controls.Panel>");

    public bool IsControlTemplate =>
        //_propertyInfo.Type.GetFullName() == "Avalonia.Markup.Xaml.ControlTemplate" ||
        _propertyInfo.Type.GetFullName() == "Avalonia.Controls.Templates.IControlTemplate" ||
        _propertyInfo.Type.GetFullName().StartsWith("Avalonia.Controls.ITemplate<");
    public bool IsDataTemplate =>
        _propertyInfo.Type.GetFullName() == "Avalonia.Markup.Xaml.DataTemplate" ||
        _propertyInfo.Type.GetFullName() == "Avalonia.Controls.Templates.IDataTemplate";
    public bool ForceContent => ContainingType.Settings.ContentProperties.Contains(_propertyInfo.Name);

    public string GetHandleContentProperty()
    {
        return $@"                case nameof({ComponentPropertyName}):
                    {ComponentPropertyName} = ({ComponentType})value;
                    break;
";
    }

    public string RenderContentProperty()
    {
        var type = _propertyInfo.Type;
        var parameterName = "nativeControl";

        if (IsPanelTemplate)
        {
            return $"\r\n            RenderTreeBuilderHelper.AddControlTemplateProperty<{AvaloniaContainingTypeName}, AC.ITemplate<AC.Panel>>(builder, sequence++, {ComponentPropertyName},\r\n                ({parameterName}, nativeTemplate) => {parameterName}.{_propertyInfo.Name} = nativeTemplate);";
        }

        if (IsControlTemplate)
        {
            // RenderTreeBuilderHelper.AddControlTemplateProperty<MC.TemplatedView>(builder, sequence++, ControlTemplate, (x, template) => x.ControlTemplate = template);
            return $"\r\n            RenderTreeBuilderHelper.AddControlTemplateProperty<{AvaloniaContainingTypeName}, {type.GetFullName()}>(builder, sequence++, {ComponentPropertyName},\r\n                ({parameterName}, nativeTemplate) => {parameterName}.{_propertyInfo.Name} = nativeTemplate);";
        }
        else if (IsDataTemplate && !IsGeneric)
        {
            // RenderTreeBuilderHelper.AddDataTemplateProperty<MC.Shell>(builder, sequence++, FlyoutContent, (x, template) => x.FlyoutContentTemplate = template);
            return $"\r\n            RenderTreeBuilderHelper.AddDataTemplateProperty<{AvaloniaContainingTypeName}>(builder, sequence++, {ComponentPropertyName},\r\n                ({parameterName}, nativeTemplate) => {parameterName}.{_propertyInfo.Name} = nativeTemplate);";
        }
        else if (IsDataTemplate && IsGeneric)
        {
            // RenderTreeBuilderHelper.AddDataTemplateProperty<MC.ItemsView, T>(builder, sequence++, ItemTemplate, (x, template) => x.ItemTemplate = template);
            return $"\r\n            RenderTreeBuilderHelper.AddDataTemplateProperty<{AvaloniaContainingTypeName}, T>(builder, sequence++, {ComponentPropertyName},\r\n                ({parameterName}, nativeTemplate) => {parameterName}.{_propertyInfo.Name} = nativeTemplate);";
        }
        else if (/*!ForceContent &&*/ IsIListGeneric(type, out var itemType))
        {
            // RenderTreeBuilderHelper.AddListContentProperty<MC.Layout, IView>(builder, sequence++, ChildContent, x => x.Children);
            var itemTypeName = GetTypeNameAndAddNamespace(itemType);
            return $"\r\n            RenderTreeBuilderHelper.AddListContentProperty<{AvaloniaContainingTypeName}, {itemTypeName}>(builder, sequence++, {ComponentPropertyName},\r\n                {parameterName} => {parameterName}.{_propertyInfo.Name});";
        }
        else if (/*!ForceContent &&*/ IsIList(type))
        {
            // RenderTreeBuilderHelper.AddListContentProperty<MC.Layout, IView>(builder, sequence++, ChildContent, x => x.Children);
            var itemTypeName = "object";
            return $"\r\n            RenderTreeBuilderHelper.AddListContentProperty<{AvaloniaContainingTypeName}, {itemTypeName}>(builder, sequence++, {ComponentPropertyName},\r\n                {parameterName} => {parameterName}.{_propertyInfo.Name});";
        }
        else
        {
            // RenderTreeBuilderHelper.AddContentProperty<MC.ContentPage>(builder, sequence++, ChildContent, (x, value) => x.Content = (MC.View)value);
            var propTypeName = GetTypeNameAndAddNamespace(type);
            return $"\r\n            RenderTreeBuilderHelper.AddContentProperty<{AvaloniaContainingTypeName}>(builder, sequence++, {ComponentPropertyName},\r\n                ({parameterName}, data) => {parameterName}.{_propertyInfo.Name} = ({propTypeName})data);";
        }
    }

    internal static GeneratedPropertyInfo[] GetContentProperties(GeneratedTypeInfo containingType)
    {
        var componentInfo = containingType.Settings;
        var propInfos = GetMembers<IPropertySymbol>(componentInfo.TypeSymbol, containingType.Settings.Include)
            .Where(e => !componentInfo.Exclude.Contains(e.Name))
            .Where(IsPublicProperty)
            .Where(prop => !IsReferenceProperty(containingType, prop))
            .Where(prop => IsRenderFragmentPropertySymbol(containingType, prop))
            .OrderBy(prop => prop.Name, StringComparer.OrdinalIgnoreCase);

        return propInfos.Select(prop => new GeneratedPropertyInfo(containingType, prop, GeneratedPropertyKind.RenderFragment)).ToArray();
    }

    private static bool IsReferenceProperty(GeneratedTypeInfo containingType, IPropertySymbol prop)
    {
        if (containingType.Settings.ContentProperties.Contains(prop.Name))
            return false;

        // RenderFragment property makes sense when we're creating a new element.
        // However, some properties expect not a new element, but a reference to an existing one.
        // E.g. VisibleViews, SelectedItem, CurrentItem, etc.
        // As for now we exclude such properties.
        var referenceNames = new[] { "Visible", "Selected", "Current" };
        return referenceNames.Any(n => prop.Name.Contains(n));
    }

    private static bool IsRenderFragmentPropertySymbol(GeneratedTypeInfo containingType, IPropertySymbol prop)
    {
        if (containingType.Settings.ContentProperties.Contains(prop.Name))
            return true;

        var type = prop.Type;

        // Avalonia marks the XAML child property with [Content]; expose it as Blazor child
        // content too - unless its type is a leaf value meant for attribute assignment or a
        // hand-written partial already owns ChildContent (TextBlock maps raw child text to Text).
        if (HasAvaloniaContentAttribute(prop)
            && !ComponentOwnsHandWrittenChildContent(containingType)
            && IsContentEligibleType(containingType, prop))
            return true;

        if (IsContent(type) && HasPublicSetter(prop))
            return true;

        if (IsIListGeneric(type, out var itemType) && IsContent(itemType))
        {
            return true;
        }

        return false;

        bool IsContent(ITypeSymbol type)
        {
            var compilation = containingType.Compilation;
            foreach (var contentType in ContentTypes)
            {
                var contentTypeSymbol = compilation.GetTypeByMetadataName(contentType.TypeName);
                if (contentTypeSymbol == null)
                    continue;

                if (SymbolEqualityComparer.Default.Equals(type, contentTypeSymbol))
                    return true;

                // Constructed generics (e.g. ITemplate<Panel>) match their unbound definition (ITemplate`1).
                if (type is INamedTypeSymbol { IsGenericType: true } constructed
                    && SymbolEqualityComparer.Default.Equals(constructed.ConstructedFrom, contentTypeSymbol))
                    return true;

                var conversion = compilation.ClassifyConversion(type, contentTypeSymbol);
                if (conversion is { IsIdentity: true })
                    return true;
                if (contentType.AllowDescendantTypes && conversion is { IsReference: true, IsImplicit: true })
                    return true;
            }

            // Panel templates render via AddControlTemplateProperty, which only supports
            // ITemplate<Panel> and requires a TemplatedControl host.
            if (type.GetFullName() == PanelTemplateFullName)
            {
                var templatedControl = compilation.GetTypeByMetadataName("Avalonia.Controls.Primitives.TemplatedControl");
                return templatedControl != null
                    && compilation.ClassifyConversion(containingType.AvaloniaType, templatedControl) is { IsReference: true, IsImplicit: true };
            }

            return false;
        }
    }

    private static bool HasAvaloniaContentAttribute(IPropertySymbol prop)
        => prop.GetAttributes().Any(a => a.AttributeClass?.ToDisplayString() == "Avalonia.Metadata.ContentAttribute");

    /// <summary>
    /// Whether a hand-written partial of the component already declares ChildContent
    /// (as opposed to a previously generated one); such components keep their [Content]
    /// properties as value parameters.
    /// </summary>
    private static bool ComponentOwnsHandWrittenChildContent(GeneratedTypeInfo containingType)
    {
        return containingType.Compilation.Assembly.GlobalNamespace
            .GetAllTypes()
            .Any(t => t.Name == containingType.TypeName
                && t.ContainingNamespace.GetFullName().StartsWith("Blazonia")
                && t.GetMembers("ChildContent").Any(m => m.DeclaringSyntaxReferences.All(r => !r.SyntaxTree.FilePath.Contains("generated"))));
    }

    /// <summary>
    /// Whether an [Content]-marked property can carry child markup. Collections go through the
    /// getter-based list branch (no setter needed) but must hold renderable component items;
    /// object/Control children are assigned by the render helpers and need a public setter.
    /// Leaf values such as TextBox.Text or Image.Source stay attribute parameters.
    /// </summary>
    private static bool IsContentEligibleType(GeneratedTypeInfo containingType, IPropertySymbol prop)
    {
        var type = prop.Type;
        var compilation = containingType.Compilation;

        if (IsIListGeneric(type, out var itemType))
            return itemType.SpecialType == SpecialType.System_Object || IsGeneratableComponent(containingType, itemType);

        if (IsIList(type))
            return true;

        if (prop.SetMethod?.DeclaredAccessibility != Accessibility.Public)
            return false;

        if (type.SpecialType == SpecialType.System_Object)
            return true;

        var control = compilation.GetTypeByMetadataName("Avalonia.Controls.Control");
        if (control == null)
            return false;

        var conversion = compilation.ClassifyConversion(type, control);
        return conversion.IsIdentity || conversion is { IsReference: true, IsImplicit: true };
    }

    private static bool IsGeneratableComponent(GeneratedTypeInfo containingType, ITypeSymbol type)
    {
        var animatable = containingType.Compilation.GetTypeByMetadataName("Avalonia.Animation.Animatable");
        if (animatable == null)
            return false;

        var conversion = containingType.Compilation.ClassifyConversion(type, animatable);
        return conversion.IsIdentity || conversion is { IsReference: true, IsImplicit: true };
    }

    private static bool IsIListGeneric(ITypeSymbol type, out ITypeSymbol itemType)
    {
        var isList = TypeEqualsIList(type, out var outItemType) || type.AllInterfaces.Any(i => IsIListGeneric(i, out outItemType));
        itemType = outItemType;
        return isList;

        static bool TypeEqualsIList(ITypeSymbol type, out ITypeSymbol itemType)
        {
            if (type is INamedTypeSymbol namedType
                && namedType.IsGenericType
                && namedType.ConstructedFrom.SpecialType == SpecialType.System_Collections_Generic_IList_T)
            {
                itemType = namedType.TypeArguments[0];
                return true;
            }
            else
            {
                itemType = null;
                return false;
            }
        }
    }

    private static bool IsIList(ITypeSymbol type)
    {
        var isList = TypeEqualsIList(type) || type.AllInterfaces.Any(i => IsIList(i));
        return isList;

        static bool TypeEqualsIList(ITypeSymbol type)
        {
            if ((type is INamedTypeSymbol namedType2 &&
                !namedType2.IsGenericType &&
                namedType2.AllInterfaces.Any(x => x.GetFullName() == "System.Collections.IList")))
            {
                var objectTypeSymbol = GetObjectTypeSymbol(type);
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    private static ITypeSymbol GetObjectTypeSymbol(ITypeSymbol type)
    {
        while (type.BaseType is not null)
        {
            type = type.BaseType;
        }

        return type;
    }
}
