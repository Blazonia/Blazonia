using Blazonia.Navigation;
using AvaloniaPage = Avalonia.Controls.Control;


namespace Blazonia;

internal class NavigationHandler : IContainerElementHandler
{
    private readonly NavigationTarget _target;
    private readonly AvaloniaNavigation _navigation;
    private readonly bool _animated;
    private readonly TaskCompletionSource _taskCompletionSource = new();
    private AvaloniaPage _currentPage;
    private bool _firstAdd = true;

    public NavigationHandler(AvaloniaNavigation navigation, NavigationTarget target, bool animated)
    {
        _target = target;
        _navigation = navigation;
        _animated = animated;
    }

    public Task WaitForNavigation() => _taskCompletionSource.Task;
    public event Action PageClosed;

    public async Task AddChildAsync(AvaloniaPage child)
    {
        _currentPage = child;

        if (_target == NavigationTarget.Modal)
        {
            await _navigation.PushModalAsync(child, _firstAdd && _animated);
        }
        else
        {
            await _navigation.PushAsync(child, _firstAdd && _animated);
        }

        _taskCompletionSource.TrySetResult();
        _firstAdd = false;

        child.DetachedFromLogicalTree += ParentChanged;
    }

    public async Task RemoveChildAsync(AvaloniaPage child)
    {
        child.DetachedFromLogicalTree -= ParentChanged;
        if (_target == NavigationTarget.Modal)
        {
            if (_navigation.ModalStack.LastOrDefault() == child)
            {
                await _navigation.PopModalAsync(animated: false);
            }
        }
        else
        {
            if (_navigation.NavigationStack.Contains(child))
                _navigation.RemovePage(child);
        }
    }

    private void ParentChanged(object sender, EventArgs e)
    {
        var page = sender as AvaloniaPage;

        if (page == _currentPage &&
            page.Parent == null)
        {
            // Notify that the page is closed so that rootComponent could be removed from Blazor tree.
            PageClosed?.Invoke();
        }

        page.DetachedFromLogicalTree -= ParentChanged;
    }

    public async void RemoveChild(object child, int physicalSiblingIndex)
    {
        await RemoveChildAsync((AvaloniaPage)child);
    }

    public async void AddChild(object child, int physicalSiblingIndex)
    {
        await AddChildAsync((AvaloniaPage)child);
    }

    public object TargetElement => null;
}
