using Avalonia.Animation;
using Avalonia.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AvaloniaPage = Avalonia.Controls.Control;


namespace Blazonia.Navigation;

public class AvaloniaNavigation : INotifyPropertyChanged
{
    private Control _currentPage;
    private readonly NavigationView navigationView;
    private bool _shouldAnimate;
    private bool _reverseAnimate;

    public ObservableStack<Control> ModalStack { get; internal set; } = new ObservableStack<Control>();
    public ObservableStack<Control> NavigationStack { get; internal set; } = new ObservableStack<Control>();

    public event PropertyChangedEventHandler PropertyChanged;

    public AvaloniaNavigation(NavigationView navigationView)
    {
        this.navigationView = navigationView;
        this.navigationView.DataContext = this;
    }

    public Control CurrentPage { get => _currentPage; private set => Raise(ref _currentPage, value); }

    public bool ShouldAnimate { get => _shouldAnimate; private set => Raise(ref _shouldAnimate, value); }

    public bool ReverseAnimate { get => _reverseAnimate; private set => Raise(ref _reverseAnimate, value); }

    private void Raise<T>(ref T target, T value, [CallerMemberName] string propertyName = null)
    {
        if (target?.Equals(value) != true)
        {
            target = value;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public Task PopAsync(bool animated)
    {
        NavigationStack.Pop();

        UpdateCurrentPage(animated, true);

        return Task.CompletedTask;
    }

    public Task PopModalAsync(bool animated)
    {
        ModalStack.TryPop(out _);

        return Task.CompletedTask;
    }

    public Task PopToRootAsync(bool animated)
    {
        while (NavigationStack.Count > 1)
        {
            NavigationStack.Pop();
        }

        UpdateCurrentPage(animated, true);

        return Task.CompletedTask;
    }

    public Task PushAsync(AvaloniaPage child, bool animated)
    {
        NavigationStack.Push(child);

        UpdateCurrentPage(animated, false);

        return Task.CompletedTask;
    }

    public Task PushModalAsync(AvaloniaPage child, bool animated)
    {
        ModalStack.Push(child);

        return Task.CompletedTask;
    }

    public void RemovePage(AvaloniaPage child)
    {
        if (NavigationStack.Contains(child))
        {
            var list = new List<Control>();
            while (NavigationStack.TryPop(out var page))
            {
                if (page == child)
                {
                    break;
                }
                else
                {
                    list.Add(page);
                }
            }

            for (var i = list.Count - 1; i >= 0; i++)
            {
                NavigationStack.Push(list[i]);
            }
        }
        else if (ModalStack.Contains(child))
        {
            var list = new List<Control>();
            while (ModalStack.TryPop(out var page))
            {
                if (page == child)
                {
                    break;
                }
                else
                {
                    list.Add(page);
                }
            }

            for (var i = list.Count - 1; i >= 0; i++)
            {
                ModalStack.Push(list[i]);
            }
        }

        UpdateCurrentPage(false, true);
    }

    private void UpdateCurrentPage(bool animated, bool reverse)
    {
        ShouldAnimate = animated;
        ReverseAnimate = reverse;

        NavigationStack.TryPeek(out var current);

        CurrentPage = current;
    }
}