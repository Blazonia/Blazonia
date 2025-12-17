using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace Blazonia.Controls;
public class BlazoniaControl<T> : ContentControl where T : IComponent
{
    public IServiceProvider serviceProvider = null;

    public BlazoniaControl()
    {

        var services = new ServiceCollection();

        ConfigureServices(services);

        services.TryAddSingleton<Control>(this);

        services.TryAddSingleton<IServiceProvider>(svcs => svcs.GetRequiredService<AvaloniaBlazorBindingsServiceProvider>());

        services.TryAddSingleton(new AvaloniaBlazorBindingsServiceProvider(() => serviceProvider));

        services.TryAddSingleton(svcs => new AvaloniaBlazorBindingsRenderer(svcs.GetRequiredService<AvaloniaBlazorBindingsServiceProvider>(), svcs.GetRequiredService<ILoggerFactory>()));

        services.AddLogging();

        serviceProvider = services.BuildServiceProvider();

        Init();

    }

    public virtual void ConfigureServices(IServiceCollection services)
    {

    }

    protected virtual ContentControlHandler GetContentControlHandler() => new ContentControlHandler(this);
    protected async void Init()
    {

        var renderer = serviceProvider.GetRequiredService<AvaloniaBlazorBindingsRenderer>();

        await renderer.AddComponent<T>(GetContentControlHandler());

    }

}


public class ContentControlHandler : IContainerElementHandler
{
    private readonly ContentControl _control;

    public ContentControlHandler(ContentControl control)
    {
        _control = control;
    }

    public void AddChild(object child, int physicalSiblingIndex)
    {
        _control.Content = child.Cast<AC.Control>();
    }

    public void RemoveChild(object child, int physicalSiblingIndex)
    {
        _control.Content = null;
    }

    public object TargetElement => _control;
}
