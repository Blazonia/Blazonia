using Blazonia.Navigation;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Diagnostics.CodeAnalysis;

namespace Blazonia.Controls;
public class BlazoniaNavigationControl<T> : BlazoniaControl<T>, IBlazoniaNavigationControl where T : IComponent
{
    public AvaloniaNavigation Navigation { get; set; }

    [DynamicDependency(DynamicallyAccessedMemberTypes.All, "Blazonia.Navigation.AvaloniaNavigation", "Blazonia")]
    public BlazoniaNavigationControl() : base()
    {
        var navigationView = new NavigationView();

        Navigation = new AvaloniaNavigation(navigationView);

        var pushTask = Navigation.PushAsync((Avalonia.Controls.Control)this.Content, false);

        this.Content = navigationView;

    }

    public override void ConfigureServices(IServiceCollection services)
    {
        services.TryAddSingleton<INavigation>(svcs => new BlazorNavigation(svcs.GetRequiredService<AvaloniaBlazorBindingsServiceProvider>()));

        services.TryAddSingleton<IBlazoniaNavigationControl>(this);
    }
}

public interface IBlazoniaNavigationControl
{
    public AvaloniaNavigation Navigation { get; protected set; }

}