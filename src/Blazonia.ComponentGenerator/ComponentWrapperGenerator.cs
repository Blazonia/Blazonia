// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using Blazonia.ComponentGenerator.Extensions;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace Blazonia.ComponentGenerator;

public partial class ComponentWrapperGenerator
{
    const string AvaloniaComponentsNamespace = "Blazonia.Components";

    public (string GroupName, string Name, string Source) GenerateComponentFile(Compilation compilation, GenerateComponentSettings generatedInfo)
    {
        //if (!System.Diagnostics.Debugger.IsAttached)
        //{
        //    System.Diagnostics.Debugger.Launch();
        //}

        var typeToGenerate = generatedInfo.TypeSymbol;
        var componentName = generatedInfo.TypeAlias ?? typeToGenerate.Name;
        var componentNamespace = GetComponentNamespace(typeToGenerate);

        var baseType = GetBaseTypeOfInterest(typeToGenerate);
        var componentBaseName = generatedInfo.BaseTypeInfo?.TypeAlias ?? baseType.Name;

        if (componentNamespace != GetComponentNamespace(baseType))
            componentBaseName = $"{GetComponentNamespace(baseType)}.{componentBaseName}";

        // header
        var headerText = generatedInfo.FileHeader;

        // usings
        var usings = GetDefaultUsings(typeToGenerate, componentNamespace);
        var generatedType = new GeneratedTypeInfo(compilation, generatedInfo, componentName, componentBaseName, typeToGenerate, usings);

        var avaloniaTypeName = generatedType.GetTypeNameAndAddNamespace(typeToGenerate);

        // props
        var valueProperties = GeneratedPropertyInfo.GetValueProperties(generatedType);
        var contentProperties = GeneratedPropertyInfo.GetContentProperties(generatedType);
        var eventCallbackProperties = GeneratedPropertyInfo.GetEventCallbackProperties(generatedType);
        var attachedProperties = GeneratedFieldInfo.GetAttachedProperties(generatedType);

        var allProperties = valueProperties.Concat(contentProperties).Concat(eventCallbackProperties);
        var propertyDeclarationBuilder = new StringBuilder();
        if (allProperties.Any())
        {
            propertyDeclarationBuilder.AppendLine();
        }
        foreach (var prop in allProperties)
        {
            propertyDeclarationBuilder.Append(prop.GetPropertyDeclaration());
        }
        var propertyDeclarations = propertyDeclarationBuilder.ToString();

        var handlePropertiesBuilder = new StringBuilder();
        foreach (var prop in valueProperties)
        {
            handlePropertiesBuilder.Append(prop.GetHandleValueProperty());
        }
        foreach (var prop in contentProperties)
        {
            handlePropertiesBuilder.Append(prop.GetHandleContentProperty());
        }
        foreach (var prop in eventCallbackProperties)
        {
            handlePropertiesBuilder.Append(prop.GetHandleEventCallbackProperty());
        }
        var handleProperties = handlePropertiesBuilder.ToString();

        var isComponentAbstract = typeToGenerate.IsAbstract || !typeToGenerate.Constructors.Any(c => c.DeclaredAccessibility == Accessibility.Public && c.Parameters.Length == 0);
        var classModifiers = string.Empty;
        if (isComponentAbstract)
        {
            classModifiers += "abstract ";
        }

        var staticConstructorBody = "\r\n            RegisterAdditionalHandlers();";

        var createNativeElement = isComponentAbstract ? "" : $@"
        protected override AvaloniaBindableObject CreateNativeElement() => new {generatedType.GetTypeNameAndAddNamespace(typeToGenerate)}();";

        var handleParameter = !allProperties.Any() ? "" : $@"
        protected override void HandleParameter(string name, object value)
        {{
            switch (name)
            {{
                {handleProperties.Trim()}

                default:
                    base.HandleParameter(name, value);
                    break;
            }}
        }}";

        var renderAdditionalElementContent = !contentProperties.Any() ? "" : $@"

        protected override void RenderAdditionalElementContent({generatedType.GetTypeNameAndAddNamespace("Microsoft.AspNetCore.Components.Rendering", "RenderTreeBuilder")} builder, ref int sequence)
        {{
            base.RenderAdditionalElementContent(builder, ref sequence);{string.Concat(contentProperties.Select(prop => prop.RenderContentProperty()))}
        }}";


        var usingsText = string.Join(
            Environment.NewLine,
            usings
                .Distinct()
                .Where(u => u.Namespace != componentNamespace)
                .Where(u => u.IsUsed)
                .Where(u => !u.IsGlobalUsing)
                .OrderBy(u => u.ComparableString)
                .Select(u => u.UsingText));

        var genericModifier = generatedInfo.IsGeneric ? "<T>" : "";
        var baseGenericModifier = generatedInfo.IsBaseTypeGeneric ? "<T>" : "";

        if (generatedInfo.BaseTypeInfo == null)
        {
            var bt = compilation.GetTypeByMetadataName(componentBaseName);
            if (bt == null)
            {
                for (int i = 1; i <= 10; i++)
                {

                    bt = compilation.GetTypeByMetadataName(componentBaseName + "`" + i);
                    if (bt != null)
                    {
                        genericModifier = "<T>";
                        baseGenericModifier = "<T>";
                        break;
                    }
                }
            }

        }
        var xmlDoc = GetXmlDocContents(typeToGenerate, "    ");

        var content = $@"{headerText}
{usingsText}

#pragma warning disable CA2252

namespace {componentNamespace}
{{
{xmlDoc}    public {classModifiers}partial class {componentName}{genericModifier} : {componentBaseName}{baseGenericModifier}
    {{
        static {componentName}()
        {{
            {staticConstructorBody.Trim()}
        }}
{propertyDeclarations}
        public new {avaloniaTypeName} NativeControl => ({avaloniaTypeName})((AvaloniaObject)this).NativeControl;
{createNativeElement}
{handleParameter}{renderAdditionalElementContent}

        static partial void RegisterAdditionalHandlers();
    }}
}}
";

        return (GetComponentGroup(typeToGenerate), componentName, content);
    }






    public (string GroupName, string Name, string Source) GenerateAttachmentFile(Compilation compilation, GenerateComponentSettings generatedInfo)
    {
        var typeToGenerate = generatedInfo.TypeSymbol;
        var componentName = generatedInfo.TypeAlias ?? typeToGenerate.Name;
        var componentNamespace = GetComponentNamespace(typeToGenerate);

        var baseType = GetBaseTypeOfInterest(typeToGenerate);
        var componentBaseName = generatedInfo.BaseTypeInfo?.TypeAlias ?? baseType.Name;

        if (componentNamespace != GetComponentNamespace(baseType))
            componentBaseName = $"{GetComponentNamespace(baseType)}.{componentBaseName}";

        // header
        var headerText = generatedInfo.FileHeader;

        // usings
        var usings = GetDefaultUsings(typeToGenerate, componentNamespace);
        var generatedType = new GeneratedTypeInfo(compilation, generatedInfo, componentName, componentBaseName, typeToGenerate, usings);

        var avaloniaTypeName = generatedType.GetTypeNameAndAddNamespace(typeToGenerate);

        // props

        var attachedProperties = GeneratedFieldInfo.GetAttachedProperties(generatedType);


        var usingsText = string.Join(
            Environment.NewLine,
            usings
                .Distinct()
                .Where(u => u.Namespace != componentNamespace)
                .Where(u => u.IsUsed)
                .Where(u => !u.IsGlobalUsing)
                .OrderBy(u => u.ComparableString)
                .Select(u => u.UsingText));

        var handleAttachedPopertiesBuilder = new StringBuilder();

        if (attachedProperties.Any())
        {
            var lowestHostType = attachedProperties[0].HostType;

            var fullTypeName = generatedInfo.TypeSymbol.GetFullName();

            var containsContent = attachedProperties.Any(x => x.IsRenderFragmentProperty);

            handleAttachedPopertiesBuilder.AppendLine($$"""
            {{usingsText}}            
            using System.Runtime.Versioning;
            using Blazonia.Components.Input;

            namespace Blazonia.Components
            {
                [RequiresPreviewFeatures]
                internal static class {{typeToGenerate.Name}}Initializer
                {
                    [System.Runtime.CompilerServices.ModuleInitializer]
                    internal static void RegisterAdditionalHandlers()
                    {
            """);

            foreach (var attached in attachedProperties)
            {
                var declaration = attached.GetRegisterAttachedPropertyDeclaration();
                if (!string.IsNullOrEmpty(declaration))
                {
                    handleAttachedPopertiesBuilder.AppendLine(declaration);
                }
            }

            handleAttachedPopertiesBuilder.AppendLine($$"""
                         }
                     }
                 """);

            if (generatedInfo.AttachedPropertyGeneration.HasFlag(AttachedPropertyGeneration.ExtensionMethods))
            {
                GenerateAttachedPropertyExtensionMethods(typeToGenerate, attachedProperties, handleAttachedPopertiesBuilder);
            }

            if (generatedInfo.AttachedPropertyGeneration.HasFlag(AttachedPropertyGeneration.Elements))
            {
                GenerateAttachedPropertyElements(attachedProperties, handleAttachedPopertiesBuilder, lowestHostType, fullTypeName, containsContent, typeToGenerate);
            }

            handleAttachedPopertiesBuilder.AppendLine($$"""
                }
                """);
        }

        var handleAttachedPoperties = handleAttachedPopertiesBuilder.ToString();

        return (GetComponentGroup(typeToGenerate), componentName, handleAttachedPoperties);
    }

    private static void GenerateAttachedPropertyElements(GeneratedFieldInfo[] attachedProperties, StringBuilder handleAttachedPopertiesBuilder, ITypeSymbol lowestHostType, string fullTypeName, bool containsContent, INamedTypeSymbol typeToGenerate)
    {
        handleAttachedPopertiesBuilder.AppendLine($$"""

                public class {{typeToGenerate.Name}}_Attachment : NativeControlComponentBase{{(true ? ", INonPhysicalChild, IContainerElementHandler" : "")}}
                {
            """);

        foreach (var attached in attachedProperties)
        {
            handleAttachedPopertiesBuilder.AppendLine(attached.GetFieldDeclaration());
        }

        if (containsContent)
        {
            handleAttachedPopertiesBuilder.AppendLine($$"""

                            protected override RenderFragment GetChildContent() => ChildContent;

                    """);
        }

        handleAttachedPopertiesBuilder.AppendLine($$"""
                        private {{lowestHostType}} _parent;

                        public object TargetElement => _parent;

                """);

        handleAttachedPopertiesBuilder.AppendLine("""
                        public override Task SetParametersAsync(ParameterView parameters)
                        {
                            foreach (var parameterValue in parameters)
                            {
                                var value = parameterValue.Value;
                                switch (parameterValue.Name)
                                {
                """);

        foreach (var attached in attachedProperties)
        {
            handleAttachedPopertiesBuilder.AppendLine($$"""
                                        {{attached.GetHandleValueField()}}
                    """);
        }

        handleAttachedPopertiesBuilder.AppendLine("""
                                }
                            }
                        
                            TryUpdateParent(_parent);
                            return base.SetParametersAsync(ParameterView.Empty);
                        }

                        private void TryUpdateParent(object parentElement)
                        {
                            if (parentElement is not null)
                            {
                """);

        foreach (var attached in attachedProperties.Where(x => !x.IsRenderFragmentProperty))
        {
            var avaloniaAttachedPropertyName = $"global::{fullTypeName}.{attached.ComponentFieldName}Property";
            if (attached.IsCanParseFromString)
            {
                handleAttachedPopertiesBuilder.AppendLine($$"""
                                    {
                                        {{attached.GetAttachedPropertyType()}} value = default;
                                        if ({{attached.ComponentFieldName}}.IsT0)
                                        {
                                            value = {{attached.ComponentFieldName}}.AsT0;
                                        }
                                        else
                                        {
                                            value = {{attached.GetAttachedPropertyType()}}.Parse({{attached.ComponentFieldName}}.AsT1);
                                        }
                                        if (value == {{avaloniaAttachedPropertyName}}.GetDefaultValue(parentElement.GetType()))
                                        {
                                            (({{attached.HostType}})parentElement).ClearValue( {{avaloniaAttachedPropertyName}});
                                        }
                                        else
                                        {
                                            global::{{fullTypeName}}.Set{{attached.ComponentFieldName}}(({{attached.HostType}})parentElement, value);
                                        }
                                    }
                                    
                    """);
            }
            else
            {
                handleAttachedPopertiesBuilder.AppendLine($$"""
                                    if ({{attached.ComponentFieldName}} == {{avaloniaAttachedPropertyName}}.GetDefaultValue(parentElement.GetType()))
                                    {
                                        (({{attached.HostType}})parentElement).ClearValue( {{avaloniaAttachedPropertyName}});
                                    }
                                    else
                                    {
                                         global::{{fullTypeName}}.Set{{attached.ComponentFieldName}}(({{attached.HostType}})parentElement, {{attached.ComponentFieldName}});
                                    }
                                    
                    """);
            }

        }

        handleAttachedPopertiesBuilder.AppendLine($$"""
                            }
                        }
                """);

        if (true)
        {
            handleAttachedPopertiesBuilder.AppendLine($$"""
                    
                        void INonPhysicalChild.SetParent(object parentElement)
                        {
                            var parentType = parentElement?.GetType();
                            if (parentType is not null)
                            {
                """);



            foreach (var attached in attachedProperties.Where(x => !x.IsRenderFragmentProperty))
            {
                var avaloniaAttachedPropertyName = $"global::{fullTypeName}.{attached.ComponentFieldName}Property";
                if (attached.IsCanParseFromString)
                {
                    handleAttachedPopertiesBuilder.AppendLine($$"""
                                    if ({{attached.ComponentFieldName}}.IsT1 == false && {{attached.ComponentFieldName}}.AsT0 == default)
                                    {
                                        {{attached.ComponentFieldName}} = {{avaloniaAttachedPropertyName}}.GetDefaultValue(parentType);
                                    }
                    """);

                }
                else
                {


                    handleAttachedPopertiesBuilder.AppendLine($$"""
                                        {{attached.ComponentFieldName}} = {{attached.ComponentFieldName}} != default ? {{attached.ComponentFieldName}} : {{avaloniaAttachedPropertyName}}.GetDefaultValue(parentType);
                        """);
                }
            }


            handleAttachedPopertiesBuilder.AppendLine($$"""

                                TryUpdateParent(parentElement);
                            }

                            _parent = ({{lowestHostType}})parentElement;
                        }
                        
                        
                """);


            handleAttachedPopertiesBuilder.AppendLine($$"""
                        public void RemoveFromParent(object parentElement)
                        {
                """);

            var renderFragmentProperties = attachedProperties.Where(x => x.IsRenderFragmentProperty);
            if (renderFragmentProperties.Any())
            {
                handleAttachedPopertiesBuilder.AppendLine($$"""
                                if (_parent is not null)
                                {
                    """);
            }

            foreach (var contentProperty in attachedProperties.Where(x => x.IsRenderFragmentProperty))
            {
                handleAttachedPopertiesBuilder.AppendLine($$"""
                                    global::{{fullTypeName}}.Set{{contentProperty.AvaloniaFieldName[..^8]}}(_parent, default);
                    """);
            }

            if (renderFragmentProperties.Any())
            {
                handleAttachedPopertiesBuilder.AppendLine($$"""
                                }

                    """);
            }

            handleAttachedPopertiesBuilder.AppendLine($$"""
                            var parentType = parentElement?.GetType();
                            if (parentType is not null)
                            {
                """);

            foreach (var attached in attachedProperties.Where(x => !x.IsRenderFragmentProperty))
            {
                var avaloniaAttachedPropertyName = $"global::{fullTypeName}.{attached.ComponentFieldName}Property";

                handleAttachedPopertiesBuilder.AppendLine($$"""
                                        {{attached.ComponentFieldName}} = {{avaloniaAttachedPropertyName}}.GetDefaultValue(parentType);
                        """);
            }


            handleAttachedPopertiesBuilder.AppendLine($$"""

                                TryUpdateParent(parentElement);
                            }

                            _parent = null;
                        }

                        public void AddChild(object child, int physicalSiblingIndex)
                        {
                        }

                        public void RemoveChild(object child, int physicalSiblingIndex)
                        {
                        }

                        protected override void RenderAdditionalElementContent(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder builder, ref int sequence)
                        {
                            base.RenderAdditionalElementContent(builder, ref sequence);
                """);

            foreach (var contentProperty in attachedProperties.Where(x => x.IsRenderFragmentProperty))
            {
                handleAttachedPopertiesBuilder.AppendLine($$"""
                                RenderTreeBuilderHelper.AddContentProperty<{{lowestHostType}}>(builder, sequence++, {{contentProperty.ComponentFieldName}},
                                    (nativeControl, value) =>
                                    {
                                        if (_parent is not null)
                                        {
                                            global::{{fullTypeName}}.Set{{contentProperty.AvaloniaFieldName[..^8]}}(_parent, value);
                                        }
                                    });
                    """);

            }
            handleAttachedPopertiesBuilder.AppendLine($$"""
                                }
                        """);
        }

        handleAttachedPopertiesBuilder.AppendLine($$"""
                }
            """);
    }

    private static void GenerateAttachedPropertyExtensionMethods(INamedTypeSymbol typeToGenerate, GeneratedFieldInfo[] attachedProperties, StringBuilder handleAttachedPopertiesBuilder)
    {
        handleAttachedPopertiesBuilder.Append($$"""

                public static class {{typeToGenerate.Name}}Extensions
                {

            """);

        foreach (var attached in attachedProperties)
        {
            var declaration = attached.GetExtensionMethodDeclaration();
            if (!string.IsNullOrEmpty(declaration))
            {
                handleAttachedPopertiesBuilder.AppendLine(declaration);
            }
        }

        handleAttachedPopertiesBuilder.AppendLine($$"""
                    }
                """);
    }

    private static List<UsingStatement> GetDefaultUsings(INamedTypeSymbol typeToGenerate, string componentNamespace)
    {
        var usings = new List<UsingStatement>
            {
                new UsingStatement { Namespace = "System", IsGlobalUsing = true },
                new UsingStatement { Namespace = "Microsoft.AspNetCore.Components", IsUsed = true, IsGlobalUsing = true },
                new UsingStatement { Namespace = "Blazonia.Core", IsUsed = true, IsGlobalUsing = true },
                new UsingStatement { Namespace = "System.Threading.Tasks", IsUsed = true, IsGlobalUsing = true },
                new UsingStatement { Namespace = "Avalonia.Controls", Alias = "AC", IsUsed = true, IsGlobalUsing = true },
                //new UsingStatement { Namespace = "Avalonia.Templ", Alias = "MMP" }
            };

        var typeNamespace = typeToGenerate.ContainingNamespace.GetFullName();
        if (typeNamespace != "Avalonia.Controls")
        {
            var typeNamespaceAlias = GetNamespaceAlias(typeNamespace);
            usings.Add(new UsingStatement { Namespace = typeNamespace, Alias = typeNamespaceAlias, IsUsed = true });
        }

        if (componentNamespace != AvaloniaComponentsNamespace)
        {
            usings.Add(new UsingStatement { Namespace = AvaloniaComponentsNamespace, IsUsed = true });
        }

        var assemblyName = typeToGenerate.ContainingAssembly.Name;
        if (assemblyName.Contains('.') && typeNamespace != assemblyName && typeNamespace.StartsWith(assemblyName))
        {
            usings.Add(new UsingStatement { Namespace = assemblyName, IsUsed = true, IsGlobalUsing = true, Alias = GetNamespaceAlias(assemblyName) });
        }

        return usings;
    }

    internal static string GetXmlDocContents(ISymbol symbol, string indent)
    {
        var xmlDocString = symbol.GetDocumentationCommentXml();

        if (string.IsNullOrEmpty(xmlDocString))
        {
            return null;
        }

        var xmlDoc = new XmlDocument();

        if (xmlDocString.StartsWith("<member ", StringComparison.Ordinal))
        {
            xmlDoc.LoadXml(xmlDocString);
        }
        else
        {
            // Returned XML doc string has no root element, which does not allow to parse it.
            xmlDoc.LoadXml($"<member>{xmlDocString}</member>");
        }

        var xmlDocNode = xmlDoc.FirstChild;

        var xmlDocContents = string.Empty;
        // Format of XML docs we're looking for in a given property:
        // <member name="P:Xamarin.Forms.ActivityIndicator.Color">
        //     <summary>Gets or sets the <see cref="T:Xamarin.Forms.Color" /> of the ActivityIndicator. This is a bindable property.</summary>
        //     <value>A <see cref="T:Xamarin.Forms.Color" /> used to display the ActivityIndicator. Default is <see cref="P:Xamarin.Forms.Color.Default" />.</value>
        //     <remarks />
        // </member>

        var summaryText = GetXmlDocText(xmlDocNode["summary"]);
        var valueText = GetXmlDocText(xmlDocNode["value"]);

        if (summaryText != null || valueText != null)
        {
            var xmlDocContentBuilder = new StringBuilder();
            if (summaryText != null)
            {
                xmlDocContentBuilder.AppendLine($"{indent}/// <summary>");
                xmlDocContentBuilder.AppendLine($"{indent}/// {summaryText}");
                xmlDocContentBuilder.AppendLine($"{indent}/// </summary>");
            }
            if (valueText != null)
            {
                xmlDocContentBuilder.AppendLine($"{indent}/// <value>");
                xmlDocContentBuilder.AppendLine($"{indent}/// {valueText}");
                xmlDocContentBuilder.AppendLine($"{indent}/// </value>");
            }
            xmlDocContents = xmlDocContentBuilder.ToString();
        }
        return xmlDocContents;

        static string GetXmlDocText(XmlElement xmlDocElement)
        {
            var allText = xmlDocElement?.InnerXml;
            allText = allText?.Replace("To be added.", "").Replace("This is a bindable property.", "");
            allText = allText is null ? null : Regex.Replace(allText, @"\s+", " ");
            return string.IsNullOrWhiteSpace(allText) ? null : allText.Trim();
        }
    }

    /// <summary>
    /// Finds the next non-generic base type of the specified type. This matches the Mobile Blazor Bindings
    /// model where there is no need to represent the intermediate generic base classes because they are
    /// generally only containers and have no API functionality that needs to be generated.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static INamedTypeSymbol GetBaseTypeOfInterest(INamedTypeSymbol type)
    {
        do
        {
            type = type.BaseType;
            if (!type.IsGenericType)
            {
                return type;
            }
        }
        while (type != null);

        return null;
    }

    public static string GetIdentifierName(string possibleIdentifier)
    {
        return ReservedKeywords.Contains(possibleIdentifier, StringComparer.Ordinal)
            ? $"@{possibleIdentifier}"
            : possibleIdentifier;
    }

    private static readonly List<string> ReservedKeywords = new List<string>
        { "class", };

    private string GetComponentGroup(INamedTypeSymbol typeToGenerate)
    {
        var nsName = typeToGenerate.ContainingNamespace.GetFullName();
        var parts = nsName.Split('.')
            .Except(["Avalonia", "Controls", "Views", "UI", "Microsoft"], StringComparer.OrdinalIgnoreCase);

        return string.Join('.', parts);
    }

    private string GetComponentNamespace(INamedTypeSymbol typeToGenerate)
    {
        var group = GetComponentGroup(typeToGenerate);
        return string.IsNullOrEmpty(group) ? "Blazonia.Components" : $"Blazonia.Components.{group}";
    }

    private static string GetNamespaceAlias(string @namespace)
    {
        return new string(@namespace.Split('.').Where(part => part != "Microsoft").Select(part => part[0]).ToArray());
    }
}