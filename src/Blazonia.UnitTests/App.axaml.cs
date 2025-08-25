using Avalonia;
using Avalonia.Markup.Xaml;
using Blazonia;

namespace Blazonina.UnitTests;

public class App : AppBase
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
public class AppBase : BlazoniaApplication<MainAppPage>
{
}
