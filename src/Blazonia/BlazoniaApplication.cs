using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Blazonia.Navigation;

namespace Blazonia;
public class BlazoniaApplication<T> : Application, IAvaloniaBlazorApplication
    where T : IComponent
{
    private IServiceProvider _serviceProvider = null;
    private AvaloniaNavigation _avaloniaNavigation = null;

    public BlazoniaApplication()
    {
    }

    public IServiceProvider ServiceProvider => _serviceProvider;

    public AvaloniaNavigation Navigation => _avaloniaNavigation;

    public void Initialize(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? (new ServiceCollection().BuildServiceProvider());

        Configure();

        var renderer = serviceProvider.GetRequiredService<AvaloniaBlazorBindingsRenderer>();

        if (WrapperComponentType != null)
        {
            var navigation = _serviceProvider.GetService<INavigation>();
            (navigation as BlazorNavigation)?.SetWrapperComponentType(WrapperComponentType);
        }

        var (componentType, parameters) = GetComponentToRender();
        var task = renderer.AddComponent(componentType, this, parameters);
        AwaitVoid(task);

        var navigationView = new NavigationView();
        _avaloniaNavigation = new AvaloniaNavigation(navigationView);


        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            if (desktop.MainWindow != null)
            {
                var pushTask = _avaloniaNavigation.PushAsync((Control)desktop.MainWindow.Content, false);

                desktop.MainWindow.Content = navigationView;
                AwaitVoid(pushTask);
            }
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            var pushTask = _avaloniaNavigation.PushAsync(singleViewPlatform.MainView, false);

            singleViewPlatform.MainView = navigationView;
            AwaitVoid(pushTask);
        }

        static async void AwaitVoid(Task task) => await task;
    }

    public virtual Type WrapperComponentType { get; }

    /// <summary>
    /// This method is executed before the rendering. It can be used to set resources, for example.
    /// </summary>
    protected virtual void Configure() { }

    private (Type ComponentType, Dictionary<string, object> Parameters) GetComponentToRender()
    {
        if (WrapperComponentType is null)
        {
            return (typeof(T), null);
        }
        else
        {
            var parameters = new Dictionary<string, object>
            {
                ["ChildContent"] = RenderFragments.FromComponentType(typeof(T))
            };
            return (WrapperComponentType, parameters);
        }
    }
}
