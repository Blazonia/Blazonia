using Avalonia;
using Avalonia.Headless;
using Blazonia;
using Blazonina.UnitTests;
using BlazorBindings.UnitTests;

[assembly: AvaloniaTestApplication(typeof(TestAppBuilder))]

namespace BlazorBindings.UnitTests;

public class TestAppBuilder
{
    public static AppBuilder BuildAvaloniaApp() => AppBuilder.Configure<App>()
        .UseAvaloniaBlazorBindings(_ => {})
        .UseHeadless(new AvaloniaHeadlessPlatformOptions());
}

