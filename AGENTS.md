# Agent Instructions for Blazonia

## Build/Lint/Test Commands

### Build Commands
- **Restore dependencies**: `dotnet restore Blazonia.slnx`
- **Build main library**: `dotnet build src/Blazonia/Blazonia.csproj -c Debug`
- **Build component generator**: `dotnet build src/Blazonia.ComponentGenerator/Blazonia.ComponentGenerator.csproj -c Debug`
- **Build example app**: `dotnet build src/Blazonia.HelloWorld/Blazonia.HelloWorld.csproj -c Debug`
- **Build all**: `dotnet build Blazonia.slnx`

### Test Commands
- **Run all tests**: `dotnet test src/Blazonia.UnitTests/Blazonina.UnitTests.csproj -c Debug`
- **Run single test**: `dotnet test src/Blazonia.UnitTests/Blazonina.UnitTests.csproj --filter "FullyQualifiedName=Blazonina.UnitTests.Elements.TestClass.TestMethod"`
- **Run tests with coverage**: `dotnet test src/Blazonia.UnitTests/Blazonina.UnitTests.csproj -p:CollectCoverage=true -p:CoverletOutputFormat=cobertura,lcov`

### Package Commands
- **Pack main library**: `dotnet pack src/Blazonia/Blazonia.csproj -o ./packages -c Release`
- **Pack component generator**: `dotnet pack src/Blazonia.ComponentGenerator/Blazonia.ComponentGenerator.csproj -o ./packages -c Release`

## Code Style Guidelines

### General
- **Target Framework**: .NET 8.0 (tests use .NET 9.0) - Install .NET 9 SDK for full functionality
- **Language**: C# with nullable reference types and implicit usings enabled
- **IDE**: JetBrains Rider recommended (Blazonia.slnx included)
- **Indentation**: 4 spaces, no tabs
- **Line endings**: CRLF
- **File encoding**: UTF-8

### Naming Conventions
- **Classes/Structs/Enums/Interfaces**: PascalCase
- **Interfaces**: Must start with 'I' (e.g., `IElementHandler`)
- **Methods/Properties/Events**: PascalCase
- **Fields**: camelCase (private) or PascalCase (public)
- **Parameters**: camelCase
- **Local variables**: camelCase
- **Test namespace**: RootNamespace is "Blazonina.UnitTests" (note spelling)

### Code Style
- **Namespaces**: Use file-scoped namespaces (`namespace MyNamespace;`)
- **Access modifiers**: Required for non-interface members
- **Expression-bodied members**: Preferred for properties, accessors, and simple methods
- **Pattern matching**: Use modern pattern matching over `as` with null checks
- **Null checking**: Use `is null` over reference equality methods
- **Var usage**: Use `var` when type is apparent
- **Braces**: Required for all blocks
- **Using statements**: Place outside namespace

### Testing Specifics
- **Framework**: xUnit with Avalonia.Headless.XUnit
- **Test attribute**: Use `[AvaloniaFact]` for UI tests, `[Fact]` for pure logic tests
- **Test files**: Razor files in `src/Blazonia.UnitTests/Elements/` inheriting `ElementTestBase`
- **Adding tests**: Must explicitly include new .razor files in `Blazonina.UnitTests.csproj`
- **Aliases**: Use `A` (Avalonia), `AC` (Avalonia.Controls), `AM` (Avalonia.Media) in tests
- **Rendering**: Use `Render<T>()` to convert Blazor fragments to Avalonia elements for assertions

### Imports/Usings
- **System directives**: No special sorting required
- **Import groups**: No separation between groups
- **Placement**: Outside namespace

### Formatting
- **Spaces**: Around binary operators, after commas, before colons in inheritance
- **Parentheses**: Minimal usage, only for clarity
- **New lines**: Before open braces, between query clauses, before catch/else/finally
- **Indentation**: Block contents and case contents indented

### Error Handling
- **Exceptions**: Use appropriate exception types
- **Null checks**: Use pattern matching and null propagation
- **Resource management**: Use `using` statements for disposables

### Dependencies
- **Package management**: Centralized via `Directory.Packages.props`
- **Common packages**: Avalonia, Microsoft.AspNetCore.Components, xUnit, coverlet

## Project Structure
- `src/Blazonia/` - Main library
- `src/Blazonia.ComponentGenerator/` - Source generator for components
- `src/Blazonia.UnitTests/` - Unit tests (xUnit with coverlet coverage, RootNamespace: Blazonina.UnitTests)
- `src/Blazonia.HelloWorld/` - Example application

## Testing
- **Framework**: xUnit with Avalonia.Headless.XUnit
- **Coverage**: coverlet.msbuild (Cobertura and LCOV formats)
- **Output**: `src/Blazonia.UnitTests/TestResults/`
- **Headless testing**: Avalonia.Headless.XUnit for UI tests
- **Test discovery**: New .razor files must be explicitly included in csproj

## Additional Notes
- **Cross-platform**: Supports desktop, mobile, and web via Avalonia
- **No HTML/WebView**: Pure native Avalonia controls
- **Single file components**: Razor syntax for UI development
- **SDK requirement**: .NET 9 SDK required for running tests (net9.0 target framework)