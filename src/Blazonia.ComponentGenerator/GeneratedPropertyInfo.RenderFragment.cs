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
            var itemTypeName = GenericTypeArgument is null ? "T" : GetTypeNameAndAddNamespace(GenericTypeArgument);
            return $"\r\n            RenderTreeBuilderHelper.AddDataTemplateProperty<{AvaloniaContainingTypeName}, {itemTypeName}>(builder, sequence++, {ComponentPropertyName},\r\n                ({parameterName}, nativeTemplate) => {parameterName}.{_propertyInfo.Name} = nativeTemplate);";
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
