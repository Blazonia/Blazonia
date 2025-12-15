using Blazonia.Controls;
using Blazonia.Navigation;
using Microsoft.AspNetCore.Components.Rendering;
using IComponent = Microsoft.AspNetCore.Components.IComponent;

namespace Blazonia;

public partial class BlazorNavigation : INavigation
{
    private readonly AvaloniaBlazorBindingsRenderer _renderer;
    private readonly NavigationManager _navigationManager;
    private Type _wrapperComponentType;
    private AvaloniaBlazorBindingsServiceProvider _serviceProvider;
    internal BlazorNavigation(AvaloniaBlazorBindingsServiceProvider serviceProvider)
    {
        _renderer = serviceProvider.GetRequiredService<AvaloniaBlazorBindingsRenderer>();
        _navigationManager = serviceProvider.GetRequiredService<NavigationManager>();
        _serviceProvider = serviceProvider;
    }

    internal void SetWrapperComponentType(Type wrapperComponentType)
    {
        _wrapperComponentType = wrapperComponentType;
    }

    protected AvaloniaNavigation AvaloniaNavigation
    {
        get
        {
            var control = _serviceProvider.GetService<IBlazoniaNavigationControl>();
            return control.Navigation;
        }

    }

    /// <summary>
    /// Push page component <typeparamref name="T"/> to the Navigation Stack.
    /// </summary>
    public Task PushAsync<T>(Dictionary<string, object> arguments = null, bool animated = true) where T : IComponent
    {
        return Navigate(typeof(T), arguments, NavigationTarget.Navigation, animated);
    }

    /// <summary>
    /// Push page component <typeparamref name="T"/> to the Modal Stack.
    /// </summary>
    public Task PushModalAsync<T>(Dictionary<string, object> arguments = null, bool animated = true) where T : IComponent
    {
        return Navigate(typeof(T), arguments, NavigationTarget.Modal, animated);
    }

    /// <summary>
    /// Push page component from the <paramref name="renderFragment"/> to the Modal Stack.
    /// </summary>
    public Task PushModalAsync(RenderFragment renderFragment, bool animated = true)
    {
        return Navigate(renderFragment, NavigationTarget.Modal, animated);
    }

    /// <summary>
    /// Push page component from the <paramref name="renderFragment"/> to the Navigation Stack.
    /// </summary>
    public Task PushAsync(RenderFragment renderFragment, bool animated = true)
    {
        return Navigate(renderFragment, NavigationTarget.Navigation, animated);
    }

    public async Task PopModalAsync(bool animated = true)
    {
        await NavigationAction(() => AvaloniaNavigation.PopModalAsync(animated));
    }

    public async Task PopAsync(bool animated = true)
    {
        await NavigationAction(() => AvaloniaNavigation.PopAsync(animated));
    }

    public async Task PopToRootAsync(bool animated = true)
    {
        await AvaloniaNavigation.PopToRootAsync(animated);
    }

    /// <summary>
    /// Returns rendered MAUI element from component <typeparamref name="T"/>.
    /// This method is exposed for extensibility purposes, and shouldn't be used directly.
    /// </summary>
    /// <remarks>Experimental API, subject to change.</remarks>
    [RequiresPreviewFeatures]
    public async Task<T> BuildElement<T>(Type componentType, Dictionary<string, object> arguments)
        where T : AvaloniaControl
    {
        var (bindableObject, componentTask) = await _renderer.GetElementFromRenderedComponent(componentType, arguments);
        var element = (AvaloniaControl)bindableObject;
        element.DetachedFromLogicalTree += DisposeScopeWhenParentRemoved;

        return element as T
            ?? throw new InvalidOperationException($"The target component of a navigation must derive from the {typeof(T).Name} component.");

        async void DisposeScopeWhenParentRemoved(object _, EventArgs __)
        {
            if (element.Parent is null)
            {
                element.DetachedFromLogicalTree -= DisposeScopeWhenParentRemoved;

                var component = await componentTask;
                _renderer.RemoveRootComponent(component);
            }
        }
    }

    private Task Navigate(RenderFragment renderFragment, NavigationTarget target, bool animated)
    {
        return Navigate(typeof(RenderFragmentComponent), new()
        {
            [nameof(RenderFragmentComponent.RenderFragment)] = renderFragment
        }, target, animated);
    }

    private async Task Navigate(Type componentType, Dictionary<string, object> arguments, NavigationTarget target, bool animated)
    {
        if (_wrapperComponentType != null)
        {
            arguments = new()
            {
                ["ChildContent"] = RenderFragments.FromComponentType(componentType, arguments)
            };
            componentType = _wrapperComponentType;
        }

        await NavigationAction(() =>
        {
            var navigationHandler = new NavigationHandler(AvaloniaNavigation, target, animated);
            var renderTask = _renderer.AddComponent(componentType, navigationHandler, arguments);

            navigationHandler.PageClosed += async () =>
            {
                _renderer.RemoveRootComponent(await renderTask);
            };

            return Task.WhenAny(renderTask, navigationHandler.WaitForNavigation());
        });
    }

    static bool _navigationInProgress;
    static async Task NavigationAction(Func<Task> action)
    {
        // Do not allow multiple navigations at the same time.
        if (_navigationInProgress)
            return;

        try
        {
            _navigationInProgress = true;
            await action();
        }
        finally
        {
            // Small delay for animation.
            await Task.Yield();
            _navigationInProgress = false;
        }
    }

    private class RenderFragmentComponent : ComponentBase
    {
        [Parameter] public RenderFragment RenderFragment { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            RenderFragment(builder);
        }
    }
}
